using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLhocphi
{
    public partial class LOP : Form
    {
        public LOP()
        {
            InitializeComponent();
        }

        private void LOP_Load(object sender, EventArgs e)
        {
            dgvLop.AutoGenerateColumns = false;
            LoadMaKhoa();
            LoadData();
        }
        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"SELECT MaLop, TenLop, MaKhoa, MaNganh, SiSo FROM Lop";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
        }

        void LoadMaKhoa()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT MaKhoa FROM Khoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaKhoa.DataSource = dt;
                cboMaKhoa.DisplayMember = "MaKhoa";
                cboMaKhoa.ValueMember = "MaKhoa";

                cboMaKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;

                cboMaKhoa.SelectedIndexChanged += CboMaKhoa_SelectedIndexChanged;
            }
        }
        void LoadMaNganh(string maKhoa)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT MaNganh FROM Nganh WHERE MaKhoa = @MaKhoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@MaKhoa", maKhoa);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaNganh.DataSource = dt;
                cboMaNganh.DisplayMember = "MaNganh";
                cboMaNganh.ValueMember = "MaNganh";

                cboMaNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaNganh.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void CboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKhoa.SelectedIndex != -1)
            {
                LoadMaNganh(cboMaKhoa.SelectedValue.ToString());
            }
        }
        void ClearText()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSS.Clear();
            cboMaKhoa.SelectedIndex = -1;
            cboMaNganh.SelectedIndex = -1;
            txtMaLop.Enabled = true;
        }

        // ================= KIỂM TRA TRÙNG MÃ LỚP =================
        bool KiemTraTrung(string ma)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Lop WHERE MaLop = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", ma);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtTenLop.Text == "" || cboMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (KiemTraTrung(txtMaLop.Text))
            {
                MessageBox.Show("Mã lớp đã tồn tại!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "INSERT INTO Lop(MaLop, TenLop, MaKhoa, MaNganh, SiSo) " +
                             "VALUES(@Ma, @Ten, @MaKhoa, @MaNganh, @SiSo)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaLop.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenLop.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", cboMaKhoa.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaNganh", cboMaNganh.SelectedValue?.ToString() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SiSo", int.TryParse(txtSiSo.Text, out int siso) ? siso : 0);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm lớp thành công!", "Thông báo");
            LoadData();
            ClearText();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLop.Rows[e.RowIndex];

            txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
            txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
            txtSiSo.Text = row.Cells["SiSo"].Value.ToString();
            cboMaKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();
            cboMaNganh.SelectedValue = row.Cells["MaNganh"].Value.ToString();

            txtMaLop.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Chọn lớp cần sửa!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "UPDATE Lop SET TenLop=@Ten, MaKhoa=@MaKhoa, MaNganh=@MaNganh, SiSo=@SiSo " +
                             "WHERE MaLop=@Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaLop.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenLop.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", cboMaKhoa.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaNganh", cboMaNganh.SelectedValue?.ToString() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SiSo", int.TryParse(txtSiSo.Text, out int siso) ? siso : 0);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật lớp thành công!", "Thông báo");
            LoadData();
            ClearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Chọn lớp cần xoá!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "DELETE FROM Lop WHERE MaLop=@Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaLop.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xoá lớp thành công!", "Thông báo");
            LoadData();
            ClearText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"SELECT MaLop, TenLop, MaKhoa, MaNganh, SiSo FROM Lop
                               WHERE MaLop LIKE '%' + @key + '%'
                                  OR TenLop LIKE N'%' + @key + '%'
                                  OR MaKhoa LIKE '%' + @key + '%'
                                  OR MaNganh LIKE '%' + @key + '%'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@key", txtTim.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class NGANH : Form
    {
        public NGANH()
        {
            InitializeComponent();
        }


        private void NGANH_Load(object sender, EventArgs e)
        {
            dgvNganh.AutoGenerateColumns = false;
            LoadMaKhoa();
            LoadData();
        }
        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"SELECT MaNganh, TenNganh, MaKhoa FROM Nganh";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNganh.DataSource = dt;
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

                // Thiết lập autocomplete
                cboMaKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        void ClearText()
        {
            txtMaNganh.Clear();
            txtTenNganh.Clear();
            cboMaKhoa.SelectedIndex = -1;
            txtMaNganh.Enabled = true;
        }

        // ================= KIỂM TRA TRÙNG MÃ NGÀNH =================
        bool KiemTraTrung(string ma)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Nganh WHERE MaNganh = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", ma);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNganh.Rows[e.RowIndex];

            txtMaNganh.Text = row.Cells["MaNganh"].Value.ToString();
            txtTenNganh.Text = row.Cells["TenNganh"].Value.ToString();
            cboMaKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();

            txtMaNganh.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNganh.Text == "" || txtTenNganh.Text == "" || cboMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (KiemTraTrung(txtMaNganh.Text))
            {
                MessageBox.Show("Mã ngành đã tồn tại!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "INSERT INTO Nganh(MaNganh, TenNganh, MaKhoa) VALUES(@Ma, @Ten, @MaKhoa)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaNganh.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenNganh.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", cboMaKhoa.SelectedValue.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm ngành thành công!", "Thông báo");
            LoadData();
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNganh.Text == "")
            {
                MessageBox.Show("Chọn ngành cần sửa!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "UPDATE Nganh SET TenNganh = @Ten, MaKhoa = @MaKhoa WHERE MaNganh = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaNganh.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenNganh.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", cboMaKhoa.SelectedValue.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật ngành thành công!", "Thông báo");
            LoadData();
            ClearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNganh.Text == "")
            {
                MessageBox.Show("Chọn ngành cần xoá!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "DELETE FROM Nganh WHERE MaNganh = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaNganh.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xoá ngành thành công!", "Thông báo");
            LoadData();
            ClearText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"SELECT MaNganh, TenNganh, MaKhoa FROM Nganh
                               WHERE MaNganh LIKE '%' + @key + '%'
                                  OR TenNganh LIKE N'%' + @key + '%'
                                  OR MaKhoa LIKE '%' + @key + '%'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@key", txtTim.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNganh.DataSource = dt;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLhocphi
{
    public partial class KHOA : Form
    {

        public KHOA()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Khoa", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhoa.DataSource = dt;
            }
        }

        private void KHOA_Load(object sender, EventArgs e)
        {
            dgvKhoa.AutoGenerateColumns = false;
            LoadData();
        }

        void ClearText()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtMaKhoa.Enabled = true;
        }

        bool KiemTraTrung(string ma)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Khoa WHERE MaKhoa = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", ma);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKhoa.Rows[e.RowIndex];

            txtMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();
            txtTenKhoa.Text = row.Cells["TenKhoa"].Value.ToString();

            txtMaKhoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == "" || txtTenKhoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (KiemTraTrung(txtMaKhoa.Text))
            {
                MessageBox.Show("Mã khoa đã tồn tại!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                string sql =
                    "INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES(@Ma, @Ten)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaKhoa.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenKhoa.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Thêm khoa thành công!", "Thông báo");
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Chọn khoa cần sửa!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                string sql =
                    "UPDATE Khoa SET TenKhoa = @Ten WHERE MaKhoa = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaKhoa.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenKhoa.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("update khoa thành công!", "Thông báo");

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Chọn khoa cần xoá!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "DELETE FROM Khoa WHERE MaKhoa = @Ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Ma", txtMaKhoa.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("xoá khoa thành công!", "Thông báo");

            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql =
                    @"SELECT MaKhoa, TenKhoa FROM Khoa
                      WHERE MaKhoa LIKE '%' + @key + '%'
                         OR TenKhoa LIKE N'%' + @key + '%'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@key", txtTimKiem.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhoa.DataSource = dt;
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLhocphi
{
    public partial class HOCKY : Form
    {
        public HOCKY()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void HOCKY_Load(object sender, EventArgs e)
        {
            dgvHocKy.AutoGenerateColumns = false; // bạn tự tạo cột
            LoadData();      // HIỆN DỮ LIỆU CÓ SẴN
            ClearText();
        }

        // ================= LOAD DATA =================
        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM HocKi", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHocKy.DataSource = dt;
            }
        }

        // ================= CLEAR =================
        void ClearText()
        {
            txtMaHocKy.Clear();
            txtTenHocKy.Clear();
            txtNamHoc.Clear();
            txtMaHocKy.Enabled = true;
        }

        // ================= KIỂM TRA TRÙNG =================
        bool KiemTraTrung(string ma)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM HocKi WHERE MaHocKi=@Ma", con);
                cmd.Parameters.AddWithValue("@Ma", ma);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaHocKy.Text == "" ||
                txtTenHocKy.Text == "" ||
                txtNamHoc.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            if (KiemTraTrung(txtMaHocKy.Text))
            {
                MessageBox.Show("Mã học kỳ đã tồn tại!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO HocKi (MaHocKi, TenHocKi, NamHoc)
                      VALUES (@Ma, @Ten, @Nam)", con);

                cmd.Parameters.AddWithValue("@Ma", txtMaHocKy.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenHocKy.Text);
                cmd.Parameters.AddWithValue("@Nam", txtNamHoc.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm học kỳ thành công!");
            LoadData();
            ClearText();
        }

        // ================= CLICK GRID =================
        private void dgvHocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvHocKy.Rows[e.RowIndex];

            txtMaHocKy.Text = r.Cells["MaHocKi"].Value.ToString();
            txtTenHocKy.Text = r.Cells["TenHocKi"].Value.ToString();
            txtNamHoc.Text = r.Cells["NamHoc"].Value.ToString();

            txtMaHocKy.Enabled = false;
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHocKy.Text == "")
            {
                MessageBox.Show("Chọn học kỳ cần sửa!");
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE HocKi SET
                      TenHocKi=@Ten,
                      NamHoc=@Nam
                      WHERE MaHocKi=@Ma", con);

                cmd.Parameters.AddWithValue("@Ma", txtMaHocKy.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenHocKy.Text);
                cmd.Parameters.AddWithValue("@Nam", txtNamHoc.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật học kỳ thành công!");
            LoadData();
            ClearText();
        }

        // ================= XOÁ =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHocKy.Text == "") return;

            if (MessageBox.Show("Xoá học kỳ?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM HocKi WHERE MaHocKi=@Ma", con);
                cmd.Parameters.AddWithValue("@Ma", txtMaHocKy.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Xoá học kỳ thành công!");
            LoadData();
            ClearText();
        }

        // ================= TÌM KIẾM =================
        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT * FROM HocKi
                      WHERE MaHocKi LIKE '%' + @k + '%'
                         OR TenHocKi LIKE N'%' + @k + '%'
                         OR NamHoc LIKE N'%' + @k + '%'", con);

                da.SelectCommand.Parameters.AddWithValue("@k", txtTim.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHocKy.DataSource = dt;
            }
        }
    }
}

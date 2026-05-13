using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLhocphi
{
    public partial class DANGKYMONHOC : Form
    {
        public DANGKYMONHOC()
        {
            InitializeComponent();
        }

        private void DANGKYMONHOC_Load(object sender, EventArgs e)
        {
            dgvDK.AutoGenerateColumns = false;
            LoadSinhVien();
            LoadHocKy();
            LoadMonHoc();
            LoadData();
            ClearText();
        }

        // ================= LOAD DATA =================
        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT MaDK, MaSV, MaMon, SoTinChi, MaHocKi, TrangThai
                      FROM DangKyMonHoc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDK.DataSource = dt;
            }
        }

        // ================= LOAD COMBOBOX =================
        void LoadSinhVien()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaSV FROM SinhVien", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaSV.DataSource = dt;
                cboMaSV.DisplayMember = "MaSV";
                cboMaSV.ValueMember = "MaSV";
                cboMaSV.SelectedIndex = -1;
            }
        }

        void LoadHocKy()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaHocKi FROM HocKi", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboHocKy.DataSource = dt;
                cboHocKy.DisplayMember = "MaHocKi";
                cboHocKy.ValueMember = "MaHocKi";
                cboHocKy.SelectedIndex = -1;
            }
        }

        void LoadMonHoc()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT MaMon, TenMon, SoTinChi FROM MonHoc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaMon.DataSource = dt;
                cboMaMon.DisplayMember = "TenMon";   // hiển thị tên môn
                cboMaMon.ValueMember = "MaMon";      // giá trị thực là MaMon
                cboMaMon.SelectedIndex = -1;

                cboMaMon.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaMon.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        // ================= CLEAR =================
        void ClearText()
        {
            txtMaDK.Text = TaoMaDK();
            cboMaSV.SelectedIndex = -1;
            cboHocKy.SelectedIndex = -1;
            cboMaMon.SelectedIndex = -1;
            txtSoTinChi.Clear();
        }

        // ================= TẠO MÃ ĐK 8 KÝ TỰ =================
        string TaoMaDK()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[r.Next(s.Length)]).ToArray());
        }

        // ================= EVENTS =================
        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn học kỳ có thể load môn học tương ứng (nếu cần)
            LoadMonHoc();
        }

        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaMon.SelectedValue == null || cboMaMon.SelectedValue.ToString() == "")
            {
                txtSoTinChi.Clear();
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT SoTinChi FROM MonHoc WHERE MaMon=@Ma", con);
                cmd.Parameters.AddWithValue("@Ma", cboMaMon.SelectedValue.ToString());
                con.Open();
                object kq = cmd.ExecuteScalar();
                txtSoTinChi.Text = kq?.ToString() ?? "";
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboMaSV.SelectedIndex == -1 ||
                cboHocKy.SelectedIndex == -1 ||
                cboMaMon.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO DangKyMonHoc
                      (MaDK, MaSV, MaMon, SoTinChi, MaHocKi, TrangThai)
                      VALUES(@MaDK,@MaSV,@MaMon,@SoTC,@MaHK,N'Chờ xác nhận')", con);

                cmd.Parameters.AddWithValue("@MaDK", txtMaDK.Text);
                cmd.Parameters.AddWithValue("@MaSV", cboMaSV.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaMon", cboMaMon.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoTC", txtSoTinChi.Text);
                cmd.Parameters.AddWithValue("@MaHK", cboHocKy.SelectedValue.ToString());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearText();
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDK.Text == "")
            {
                MessageBox.Show("Chọn bản ghi để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE DangKyMonHoc SET
                      MaSV=@MaSV, MaMon=@MaMon,
                      SoTinChi=@SoTC, MaHocKi=@MaHK,
                      TrangThai=@TrangThai
                      WHERE MaDK=@MaDK", con);

                cmd.Parameters.AddWithValue("@MaDK", txtMaDK.Text);
                cmd.Parameters.AddWithValue("@MaSV", cboMaSV.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaMon", cboMaMon.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SoTC", txtSoTinChi.Text);
                cmd.Parameters.AddWithValue("@MaHK", cboHocKy.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@TrangThai", "Chờ xác nhận");

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearText();
        }

        // ================= XOÁ =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDK.Text == "")
            {
                MessageBox.Show("Chọn bản ghi để xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM DangKyMonHoc WHERE MaDK=@Ma", con);
                    cmd.Parameters.AddWithValue("@Ma", txtMaDK.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadData();
                ClearText();
            }
        }

        // ================= CLICK DATAGRID =================
        private void dgvDK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvDK.Rows[e.RowIndex];
            txtMaDK.Text = r.Cells["MaDK"].Value.ToString();
            cboMaSV.SelectedValue = r.Cells["MaSV"].Value.ToString();
            cboHocKy.SelectedValue = r.Cells["MaHocKi"].Value.ToString();

            LoadMonHoc(); // load để ComboBox có dữ liệu
            cboMaMon.SelectedValue = r.Cells["MaMon"].Value.ToString();

            txtSoTinChi.Text = r.Cells["SoTinChi"].Value.ToString();
        }

        // ================= TÌM KIẾM =================
        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT MaDK, MaSV, MaMon, SoTinChi, MaHocKi, TrangThai
                      FROM DangKyMonHoc
                      WHERE MaDK     LIKE '%' + @k + '%'
                         OR MaSV     LIKE '%' + @k + '%'
                         OR MaMon    LIKE '%' + @k + '%'
                         OR MaHocKi  LIKE '%' + @k + '%'
                         OR TrangThai LIKE N'%' + @k + '%'", con);

                da.SelectCommand.Parameters.AddWithValue("@k", txtTim.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDK.DataSource = dt;
            }
        }
    }
}

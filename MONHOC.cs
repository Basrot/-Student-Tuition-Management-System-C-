using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QLhocphi
{
    public partial class MONHOC : Form
    {
        public MONHOC()
        {
            InitializeComponent();
        }

        // ================= LOAD DATA =================
        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM MonHoc", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMonHoc.DataSource = dt;
            }
        }


        // ================= CLEAR =================
        void ClearText()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtSoTinChi.Clear();
            txtDonGia.Clear();
            rdoMo.Checked = false;
            rdoDong.Checked = false;
            txtMaMon.Enabled = false; // Mã môn TỰ SINH
        }

        // ================= SINH MÃ MÔN =================
        string TaoMaMon(string tenMon)
        {
            StringBuilder ma = new StringBuilder();
            string[] words = tenMon.Trim().Split(' ');

            foreach (string w in words)
            {
                if (!string.IsNullOrWhiteSpace(w))
                    ma.Append(char.ToUpper(w[0]));
            }
            return ma.ToString();
        }

        // ================= KIỂM TRA TRÙNG =================
        bool KiemTraTrung(string ma)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM MonHoc WHERE MaMon=@Ma", con);
                cmd.Parameters.AddWithValue("@Ma", ma);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ================= THÊM =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenMon.Text == "" ||
                txtSoTinChi.Text == "" ||
                txtDonGia.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtSoTinChi.Text, out int soTC) ||
                !decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Số tín chỉ / đơn giá không hợp lệ!");
                return;
            }

            if (!rdoMo.Checked && !rdoDong.Checked)
            {
                MessageBox.Show("Chọn trạng thái!");
                return;
            }

            string maMon = TaoMaMon(txtTenMon.Text);
            txtMaMon.Text = maMon;

            if (KiemTraTrung(maMon))
            {
                MessageBox.Show("Mã môn đã tồn tại (trùng tên môn)!");
                return;
            }

            string trangThai = rdoMo.Checked ? "Đang mở" : "Đóng";

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO MonHoc
                      (MaMon, TenMon, SoTinChi, DonGia, TrangThai)
                      VALUES (@Ma,@Ten,@TC,@Gia,@TT)", con);

                cmd.Parameters.AddWithValue("@Ma", maMon);
                cmd.Parameters.AddWithValue("@Ten", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@TC", soTC);
                cmd.Parameters.AddWithValue("@Gia", donGia);
                cmd.Parameters.AddWithValue("@TT", trangThai);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearText();
        }

        // ================= CLICK GRID =================
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvMonHoc.Rows[e.RowIndex];

            txtMaMon.Text = r.Cells["MaMon"].Value.ToString();
            txtTenMon.Text = r.Cells["TenMon"].Value.ToString();
            txtSoTinChi.Text = r.Cells["SoTinChi"].Value.ToString();
            txtDonGia.Text = r.Cells["DonGia"].Value.ToString();

            string tt = r.Cells["TrangThai"].Value.ToString();
            rdoMo.Checked = tt == "Đang mở";
            rdoDong.Checked = tt == "Đóng";

            txtMaMon.Enabled = false;
        }

        // ================= SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text == "") return;

            if (!int.TryParse(txtSoTinChi.Text, out int soTC) ||
                !decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
                return;
            }

            string trangThai = rdoMo.Checked ? "Đang mở" : "Đóng";

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE MonHoc SET
                      TenMon=@Ten,
                      SoTinChi=@TC,
                      DonGia=@Gia,
                      TrangThai=@TT
                      WHERE MaMon=@Ma", con);

                cmd.Parameters.AddWithValue("@Ma", txtMaMon.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@TC", soTC);
                cmd.Parameters.AddWithValue("@Gia", donGia);
                cmd.Parameters.AddWithValue("@TT", trangThai);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearText();
        }

        // ================= XOÁ =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text == "") return;

            if (MessageBox.Show("Xoá môn học?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM MonHoc WHERE MaMon=@Ma", con);
                cmd.Parameters.AddWithValue("@Ma", txtMaMon.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadData();
            ClearText();
        }

        // ================= TÌM KIẾM =================
        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT * FROM MonHoc
                      WHERE MaMon LIKE '%' + @k + '%'
                         OR TenMon LIKE N'%' + @k + '%'", con);

                da.SelectCommand.Parameters.AddWithValue("@k", txtTim.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMonHoc.DataSource = dt;
            }
        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MONHOC_Load_1(object sender, EventArgs e)
        {
            dgvMonHoc.AutoGenerateColumns = false; // bạn đã tạo cột
            LoadData();     // HIỆN DỮ LIỆU CÓ SẴN
            ClearText();

        }
    }
}

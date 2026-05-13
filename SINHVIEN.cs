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
    public partial class SINHVIEN : Form
    {
        private bool isAddingNew = false; // kiểm soát khi thêm mới
      
        public SINHVIEN()
        {
            InitializeComponent();
        }

        private void SINHVIEN_Load(object sender, EventArgs e)
        {
            dgvSinhVien.AutoGenerateColumns = false;

            LoadMaLop();
            SetupComboGioiTinh();
            LoadData();

            ClearText();
            isAddingNew = false;
        }
        // ================= LOAD DỮ LIỆU SINH VIÊN =================
        void ClearText()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboMaLop.SelectedIndex = -1;
            cboMaNganh.SelectedIndex = -1;
            cboGioiTinh.SelectedIndex = -1;
            rdoDangHoc.Checked = false;
            rdoThoiHoc.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }

        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop, MaNganh, TrangThai FROM SinhVien";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSinhVien.DataSource = dt;
            }
        }

        // ================= LOAD COMBOBOX LỚP =================
        void LoadMaLop()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT MaLop, MaKhoa FROM Lop";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaLop.DataSource = dt;
                cboMaLop.DisplayMember = "MaLop";
                cboMaLop.ValueMember = "MaLop";
                cboMaLop.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaLop.AutoCompleteSource = AutoCompleteSource.ListItems;

                cboMaLop.SelectedIndexChanged += cboMaLop_SelectedIndexChanged;
            }
        }

        // ================= LOAD COMBOBOX NGÀNH =================
        void LoadMaNganh(string maKhoa)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT MaNganh FROM Nganh WHERE MaKhoa=@MaKhoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@MaKhoa", maKhoa);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaNganh.DataSource = dt;
                cboMaNganh.DisplayMember = "MaNganh";
                cboMaNganh.ValueMember = "MaNganh";
                cboMaNganh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMaNganh.AutoCompleteSource = AutoCompleteSource.ListItems;

                cboMaNganh.SelectedIndexChanged += cboMaNganh_SelectedIndexChanged;
            }
        }

        // ================= SETUP GIỚI TÍNH =================
        void SetupComboGioiTinh()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
        }

        // ================= CELL CLICK =================
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            isAddingNew = false; // không sinh MaSV khi sửa

            DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();
            cboMaLop.SelectedValue = row.Cells["MaLop"].Value?.ToString();

            // Lấy MaKhoa của lớp để lọc ngành
            string maLop = row.Cells["MaLop"].Value.ToString();
            string maKhoa = GetMaKhoaByMaLop(maLop);
            LoadMaNganh(maKhoa);
            cboMaNganh.SelectedValue = row.Cells["MaNganh"].Value?.ToString();

            string trangThai = row.Cells["TrangThai"].Value?.ToString();
            rdoDangHoc.Checked = trangThai == "Đang học";
            rdoThoiHoc.Checked = trangThai == "Thôi học";
        }

        string GetMaKhoaByMaLop(string maLop)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "SELECT MaKhoa FROM Lop WHERE MaLop=@MaLop";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                con.Open();
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        // ================= COMBOBOX CHỌN LỚP =================
        private void cboMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAddingNew) return; // chỉ sinh MaSV khi thêm
            if (cboMaLop.SelectedIndex == -1) return;

            string maKhoa = ((DataRowView)cboMaLop.SelectedItem)["MaKhoa"].ToString();
            LoadMaNganh(maKhoa);
            CapNhatMaSV();
        }

        private void cboMaNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAddingNew) return; // chỉ sinh MaSV khi thêm
            CapNhatMaSV();
        }

        // ================= SINH MÃ SINH VIÊN =================
        private void CapNhatMaSV()
        {
            if (cboMaLop.SelectedIndex != -1 && cboMaNganh.SelectedIndex != -1)
            {
                string maLop = cboMaLop.SelectedValue.ToString();
                string maNganh = cboMaNganh.SelectedValue.ToString();
                txtMaSV.Text = maLop.Substring(0, 2) + maNganh.Substring(0, 2) + new Random().Next(0, 999999).ToString("D6");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboMaLop.SelectedIndex == -1 || cboMaNganh.SelectedIndex == -1 || string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            isAddingNew = true;
            CapNhatMaSV();
            string maSV = txtMaSV.Text.Trim();
            string trangThai = rdoDangHoc.Checked ? "Đang học" : "Thôi học";

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaLop, MaNganh, TrangThai)
                               VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaLop, @MaNganh, @TrangThai)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@MaLop", cboMaLop.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaNganh", cboMaNganh.SelectedValue?.ToString() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm sinh viên thành công!");
            LoadData();
            ClearText();
            isAddingNew = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Chọn sinh viên cần sửa!");
                return;
            }

            string trangThai = rdoDangHoc.Checked ? "Đang học" : "Thôi học";

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"UPDATE SinhVien SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh,
                               MaLop=@MaLop, MaNganh=@MaNganh, TrangThai=@TrangThai
                               WHERE MaSV=@MaSV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@MaLop", cboMaLop.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaNganh", cboMaNganh.SelectedValue?.ToString() ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                    MessageBox.Show("Không tìm thấy sinh viên để sửa!");
                else
                    MessageBox.Show("Cập nhật thành công!");
            }

            LoadData();
            ClearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Chọn sinh viên cần xoá!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = "DELETE FROM SinhVien WHERE MaSV=@MaSV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                    MessageBox.Show("Không tìm thấy sinh viên để xoá!");
                else
                    MessageBox.Show("Xoá thành công!");
            }

            LoadData();
            ClearText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = DB.GetConnection())
            {
                string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop, MaNganh, TrangThai 
                               FROM SinhVien
                               WHERE MaSV LIKE '%' + @key + '%'
                                  OR HoTen LIKE N'%' + @key + '%'
                                  OR MaLop LIKE '%' + @key + '%'
                                  OR MaNganh LIKE '%' + @key + '%'";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@key", txtTim.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSinhVien.DataSource = dt;
            }
        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


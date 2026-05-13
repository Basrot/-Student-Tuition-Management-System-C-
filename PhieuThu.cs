using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLhocphi
{
    public partial class Phiếu_Thu : Form
    {
        public Phiếu_Thu()
        {
            InitializeComponent();
        }

     
        // ================= LOAD DATA =================
        void LoadData()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaPhieuThu, MaSV, MaHocKi, NguoiLap, NgayLap FROM PhieuThu", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhieuThu.DataSource = dt;
            }
        }

        // ================= SETUP DATAGRIDVIEW =================
        void SetupDataGridView()
        {
            dgvPhieuThu.Columns.Clear();

            dgvPhieuThu.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã phiếu thu",
                Name = "MaPhieuThu",
                DataPropertyName = "MaPhieuThu"
            });

            dgvPhieuThu.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã SV",
                Name = "MaSV",
                DataPropertyName = "MaSV"
            });

            dgvPhieuThu.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Mã học kỳ",
                Name = "MaHocKi",
                DataPropertyName = "MaHocKi"
            });

            dgvPhieuThu.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Người lập",
                Name = "NguoiLap",
                DataPropertyName = "NguoiLap"
            });

            dgvPhieuThu.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Ngày lập",
                Name = "NgayLap",
                DataPropertyName = "NgayLap"
            });
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

        void LoadHocKi()
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaHocKi FROM HocKi", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaHocKi.DataSource = dt;
                cboMaHocKi.DisplayMember = "MaHocKi";
                cboMaHocKi.ValueMember = "MaHocKi";
                cboMaHocKi.SelectedIndex = -1;
            }
        }

        // ================= CLEAR FORM =================
        void ClearText()
        {
            GenerateMaPhieuThu();
            cboMaSV.SelectedIndex = -1;
            cboMaHocKi.SelectedIndex = -1;
            txtNguoiLap.Clear();
            dtpNgayLap.Value = DateTime.Today;
        }

        // ================= TẠO MÃ PHIẾU THU 10 KÝ TỰ =================
        void GenerateMaPhieuThu()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string ma;
            Random r = new Random();
            using (SqlConnection con = DB.GetConnection())
            {
                do
                {
                    ma = new string(Enumerable.Repeat(chars, 10)
                        .Select(s => s[r.Next(s.Length)]).ToArray());

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PhieuThu WHERE MaPhieuThu=@Ma", con);
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();
                    if (count == 0) break; // chưa tồn tại => dùng được
                } while (true);
            }
            txtMaPhieuThu.Text = ma;
        }





        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (cboMaSV.SelectedIndex == -1 || cboMaHocKi.SelectedIndex == -1)
            {
                MessageBox.Show("Nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO PhieuThu (MaPhieuThu, MaSV, MaHocKi, NguoiLap, NgayLap) VALUES(@MaPhieuThu, @MaSV, @MaHocKi, @NguoiLap, @NgayLap)", con);

                cmd.Parameters.AddWithValue("@MaPhieuThu", txtMaPhieuThu.Text);
                cmd.Parameters.AddWithValue("@MaSV", cboMaSV.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaHocKi", cboMaHocKi.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@NguoiLap", txtNguoiLap.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearText();
        }

        private void Phiếu_Thu_Load_1(object sender, EventArgs e)
        {
            dgvPhieuThu.AutoGenerateColumns = false;
            SetupDataGridView();
            LoadSinhVien();
            LoadHocKi();
            LoadData();
            GenerateMaPhieuThu();
        }

        private void dgvPhieuThu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = dgvPhieuThu.Rows[e.RowIndex];
            txtMaPhieuThu.Text = r.Cells["MaPhieuThu"].Value.ToString();
            cboMaSV.SelectedValue = r.Cells["MaSV"].Value.ToString();
            cboMaHocKi.SelectedValue = r.Cells["MaHocKi"].Value.ToString();
            txtNguoiLap.Text = r.Cells["NguoiLap"].Value.ToString();
            dtpNgayLap.Value = Convert.ToDateTime(r.Cells["NgayLap"].Value);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuThu.Text == "")
            {
                MessageBox.Show("Chọn phiếu thu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE PhieuThu SET MaSV=@MaSV, MaHocKi=@MaHocKi, NguoiLap=@NguoiLap, NgayLap=@NgayLap WHERE MaPhieuThu=@MaPhieuThu", con);

                cmd.Parameters.AddWithValue("@MaPhieuThu", txtMaPhieuThu.Text);
                cmd.Parameters.AddWithValue("@MaSV", cboMaSV.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaHocKi", cboMaHocKi.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@NguoiLap", txtNguoiLap.Text);
                cmd.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Sửa phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtMaPhieuThu.Text == "")
            {
                MessageBox.Show("Chọn phiếu thu để xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM PhieuThu WHERE MaPhieuThu=@MaPhieuThu", con);
                    cmd.Parameters.AddWithValue("@MaPhieuThu", txtMaPhieuThu.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xoá phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearText();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DB.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MaPhieuThu, MaSV, MaHocKi, NguoiLap, NgayLap FROM PhieuThu " +
                    "WHERE MaPhieuThu LIKE '%' + @k + '%' OR MaSV LIKE '%' + @k + '%' OR MaHocKi LIKE '%' + @k + '%' OR NguoiLap LIKE N'%' + @k + '%'", con);

                da.SelectCommand.Parameters.AddWithValue("@k", txtTim.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPhieuThu.DataSource = dt;
            }
        }
    }
}

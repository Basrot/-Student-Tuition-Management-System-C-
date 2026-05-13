using QLhocphi;
using System;
using System.Windows.Forms;

namespace QuanLyHP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hàm mở form con trong panel
        void OpenChildForm(Form child)
        {
            panel_main.Controls.Clear();
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel_main.Controls.Add(child);
            child.Show();
        }

        // Mở form Khoa
        private void btnKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KHOA());
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SINHVIEN());
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LOP());
        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NGANH());
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MONHOC());
        }

        private void btnHocKy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HOCKY());
        }

        private void btnDKMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DANGKYMONHOC());
        }

        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Phiếu_Thu());
        }

        private void btnPhieuTT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Phiếu_Thanh_Toán());
        }

        private void btnTraCuuCN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CONGNO());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            {
                OpenChildForm(new THONGKE());
            }
        }
    }
}

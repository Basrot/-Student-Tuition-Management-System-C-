using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLhocphi
{
    public partial class THONGKE : Form
    {
        string connStr =
    "Server=localhost;Database=QuanLyHP;User Id=sa;Password=0846316066;TrustServerCertificate=True;";
        public THONGKE()
        {
            InitializeComponent();
        }
        string VND(double x)
        {
            return x.ToString("c0", new CultureInfo("vi-VN"));
        }
        void LoadTongQuan()
        {
            using (SqlConnection c = new SqlConnection(connStr))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = c;
                cmd.CommandText = "SELECT COUNT(*) FROM SinhVien";
                lblTongSV.Text = "Tổng SV: " + cmd.ExecuteScalar();

                cmd.CommandText = "SELECT SUM(TongHocPhi) FROM v_CongNo";
                lblTongHocPhi.Text = "Tổng học phí: " +
                    VND(Convert.ToDouble(cmd.ExecuteScalar()));

                cmd.CommandText = "SELECT SUM(DaThu) FROM v_CongNo";
                lblDaThu.Text = "Đã thu: " +
                    VND(Convert.ToDouble(cmd.ExecuteScalar()));

                cmd.CommandText = "SELECT SUM(ConNo) FROM v_CongNo";
                lblConNo.Text = "Còn nợ: " +
                    VND(Convert.ToDouble(cmd.ExecuteScalar()));
            }
        }
        void LoadSinhVienCongNo()
        {
            dgvSinhVienCongNo.Rows.Clear();

            string dk = cboTrangThaiDongPhi.SelectedIndex == 0
                ? "WHERE DaThu < TongHocPhi"
                : "WHERE DaThu = TongHocPhi";

            string sql = "SELECT * FROM v_CongNo " + dk;

            using (SqlConnection c = new SqlConnection(connStr))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(sql, c);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    dgvSinhVienCongNo.Rows.Add(
                        r["MaSV"],
                        r["HoTen"],
                        r["MaLop"],
                        r["TenKhoa"],
                        VND(Convert.ToDouble(r["TongHocPhi"])),
                        VND(Convert.ToDouble(r["DaThu"])),
                        VND(Convert.ToDouble(r["ConNo"]))
                    );
                }
            }
        }
        void LoadTheoKhoa()
        {
            dgvThongKeKhoa.Rows.Clear();

            string sql = @"
        SELECT TenKhoa, COUNT(MaSV) SoSV, SUM(ConNo) TongNo
        FROM v_CongNo
        GROUP BY TenKhoa";

            using (SqlConnection c = new SqlConnection(connStr))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(sql, c);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    dgvThongKeKhoa.Rows.Add(
                        r["TenKhoa"],
                        r["SoSV"],
                        VND(Convert.ToDouble(r["TongNo"]))
                    );
                }
            }
        }
        void LoadTheoNganh()
        {
            dgvThongKeNganh.Rows.Clear();

            string sql = @"
        SELECT n.TenNganh, COUNT(*) SoSV
        FROM SinhVien sv
        JOIN Nganh n ON sv.MaNganh = n.MaNganh
        GROUP BY n.TenNganh";

            using (SqlConnection c = new SqlConnection(connStr))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(sql, c);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    dgvThongKeNganh.Rows.Add(
                        r["TenNganh"],
                        r["SoSV"]
                    );
                }
            }
        }
        void LoadChart()
        {
            chartHocPhi.Series.Clear();

            Series s = new Series("Học phí");
            s.ChartType = SeriesChartType.Pie;

            using (SqlConnection c = new SqlConnection(connStr))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(DaThu) FROM v_CongNo", c);
                s.Points.AddXY("Đã thu", Convert.ToDouble(cmd.ExecuteScalar()));

                cmd.CommandText = "SELECT SUM(ConNo) FROM v_CongNo";
                s.Points.AddXY("Còn nợ", Convert.ToDouble(cmd.ExecuteScalar()));
            }

            chartHocPhi.Series.Add(s);
        }
        private void THONGKE_Load(object sender, EventArgs e)
        {
            cboTrangThaiDongPhi.SelectedIndex = 0;

            LoadTongQuan();
            LoadSinhVienCongNo();
            LoadTheoKhoa();
            LoadTheoNganh();
            LoadChart();
        }
        private void cboTrangThaiDongPhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSinhVienCongNo();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvSinhVienCongNo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

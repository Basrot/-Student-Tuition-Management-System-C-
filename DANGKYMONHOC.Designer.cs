namespace QLhocphi
{
    partial class DANGKYMONHOC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DANGKYMONHOC));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDK = new System.Windows.Forms.DataGridView();
            this.panel_cover = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.txtMaDK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnLop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.rbHuy = new System.Windows.Forms.RadioButton();
            this.rbChoXacNhan = new System.Windows.Forms.RadioButton();
            this.rbDaXacNhan = new System.Windows.Forms.RadioButton();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoTinChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMaMon = new System.Windows.Forms.ComboBox();
            this.cboMaSV = new System.Windows.Forms.ComboBox();
            this.MaDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTinChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHocKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDK)).BeginInit();
            this.panel_cover.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1106, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mã Môn";
            // 
            // dgvDK
            // 
            this.dgvDK.BackgroundColor = System.Drawing.Color.White;
            this.dgvDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDK,
            this.MaSV,
            this.MaMon,
            this.SoTinChi,
            this.MaHocKi,
            this.TrangThai});
            this.dgvDK.Location = new System.Drawing.Point(281, 558);
            this.dgvDK.Name = "dgvDK";
            this.dgvDK.RowHeadersWidth = 62;
            this.dgvDK.RowTemplate.Height = 28;
            this.dgvDK.Size = new System.Drawing.Size(1277, 230);
            this.dgvDK.TabIndex = 13;
            this.dgvDK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDK_CellClick);
            // 
            // panel_cover
            // 
            this.panel_cover.Controls.Add(this.label8);
            this.panel_cover.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cover.Location = new System.Drawing.Point(0, 0);
            this.panel_cover.Name = "panel_cover";
            this.panel_cover.Size = new System.Drawing.Size(1617, 77);
            this.panel_cover.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(357, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(787, 32);
            this.label8.TabIndex = 1;
            this.label8.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI ";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Moccasin;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(1019, 486);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(179, 37);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "XOÁ";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Moccasin;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(737, 486);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(179, 37);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Moccasin;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(475, 486);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(179, 37);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.Moccasin;
            this.btnTim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(1210, 193);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(179, 37);
            this.btnTim.TabIndex = 9;
            this.btnTim.Text = "TÌM KIẾM ";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(384, 200);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(707, 26);
            this.txtTim.TabIndex = 8;
            // 
            // txtMaDK
            // 
            this.txtMaDK.Location = new System.Drawing.Point(492, 271);
            this.txtMaDK.Name = "txtMaDK";
            this.txtMaDK.Size = new System.Drawing.Size(372, 26);
            this.txtMaDK.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã Đăng Ký";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 887);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1617, 25);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1617, 80);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel_logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 912);
            this.panel1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 736);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HỆ THỐNG";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Azure;
            this.button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button11.Location = new System.Drawing.Point(6, 29);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(198, 42);
            this.button11.TabIndex = 10;
            this.button11.Text = "ĐĂNG XUẤT";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnKhoa);
            this.groupBox1.Controls.Add(this.btnLop);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 575);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH MỤC QUẢN LÍ ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Azure;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(6, 518);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(207, 42);
            this.button2.TabIndex = 10;
            this.button2.Text = "THỐNG KÊ";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Azure;
            this.button10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button10.Location = new System.Drawing.Point(6, 470);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(207, 42);
            this.button10.TabIndex = 9;
            this.button10.Text = "TRA CƯU CÔNG NỢ ";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Azure;
            this.button9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button9.Location = new System.Drawing.Point(6, 422);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(207, 42);
            this.button9.TabIndex = 8;
            this.button9.Text = "PHIẾU THANH TOÁN";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Azure;
            this.button8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button8.Location = new System.Drawing.Point(6, 374);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(207, 42);
            this.button8.TabIndex = 7;
            this.button8.Text = "PHIẾU THU";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Azure;
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.Location = new System.Drawing.Point(6, 326);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(207, 42);
            this.button7.TabIndex = 6;
            this.button7.Text = "ĐĂNG KÝ MÔN HỌC";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Azure;
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(6, 278);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(207, 42);
            this.button6.TabIndex = 5;
            this.button6.Text = "HỌC KỲ ";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Azure;
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button5.Location = new System.Drawing.Point(6, 230);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(207, 42);
            this.button5.TabIndex = 4;
            this.button5.Text = "MÔN HỌC ";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Azure;
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(6, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(207, 42);
            this.button4.TabIndex = 3;
            this.button4.Text = "NGÀNH";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnKhoa
            // 
            this.btnKhoa.BackColor = System.Drawing.Color.Azure;
            this.btnKhoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKhoa.Location = new System.Drawing.Point(6, 134);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(207, 42);
            this.btnKhoa.TabIndex = 2;
            this.btnKhoa.Text = "KHOA";
            this.btnKhoa.UseVisualStyleBackColor = false;
            // 
            // btnLop
            // 
            this.btnLop.BackColor = System.Drawing.Color.Azure;
            this.btnLop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLop.Location = new System.Drawing.Point(6, 86);
            this.btnLop.Name = "btnLop";
            this.btnLop.Size = new System.Drawing.Size(207, 42);
            this.btnLop.TabIndex = 1;
            this.btnLop.Text = "LỚP";
            this.btnLop.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Azure;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(6, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "SINH VIÊN";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel_logo
            // 
            this.panel_logo.Controls.Add(this.pictureBox2);
            this.panel_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(251, 125);
            this.panel_logo.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(31, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 91);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(327, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã Sinh Viên";
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.rbHuy);
            this.panel_main.Controls.Add(this.rbChoXacNhan);
            this.panel_main.Controls.Add(this.rbDaXacNhan);
            this.panel_main.Controls.Add(this.cboHocKy);
            this.panel_main.Controls.Add(this.label4);
            this.panel_main.Controls.Add(this.txtSoTinChi);
            this.panel_main.Controls.Add(this.label5);
            this.panel_main.Controls.Add(this.label6);
            this.panel_main.Controls.Add(this.cboMaMon);
            this.panel_main.Controls.Add(this.cboMaSV);
            this.panel_main.Controls.Add(this.label3);
            this.panel_main.Controls.Add(this.dgvDK);
            this.panel_main.Controls.Add(this.btnXoa);
            this.panel_main.Controls.Add(this.btnSua);
            this.panel_main.Controls.Add(this.btnThem);
            this.panel_main.Controls.Add(this.btnTim);
            this.panel_main.Controls.Add(this.txtTim);
            this.panel_main.Controls.Add(this.txtMaDK);
            this.panel_main.Controls.Add(this.label2);
            this.panel_main.Controls.Add(this.label1);
            this.panel_main.Controls.Add(this.panel3);
            this.panel_main.Controls.Add(this.panel2);
            this.panel_main.Controls.Add(this.panel_cover);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1617, 912);
            this.panel_main.TabIndex = 11;
            // 
            // rbHuy
            // 
            this.rbHuy.AutoSize = true;
            this.rbHuy.Location = new System.Drawing.Point(1450, 422);
            this.rbHuy.Name = "rbHuy";
            this.rbHuy.Size = new System.Drawing.Size(136, 24);
            this.rbHuy.TabIndex = 28;
            this.rbHuy.TabStop = true;
            this.rbHuy.Text = "Huỷ Xác Nhận";
            this.rbHuy.UseVisualStyleBackColor = true;
            // 
            // rbChoXacNhan
            // 
            this.rbChoXacNhan.AutoSize = true;
            this.rbChoXacNhan.Location = new System.Drawing.Point(1271, 422);
            this.rbChoXacNhan.Name = "rbChoXacNhan";
            this.rbChoXacNhan.Size = new System.Drawing.Size(137, 24);
            this.rbChoXacNhan.TabIndex = 27;
            this.rbChoXacNhan.TabStop = true;
            this.rbChoXacNhan.Text = "Chờ Xác Nhận";
            this.rbChoXacNhan.UseVisualStyleBackColor = true;
            // 
            // rbDaXacNhan
            // 
            this.rbDaXacNhan.AutoSize = true;
            this.rbDaXacNhan.Location = new System.Drawing.Point(1111, 422);
            this.rbDaXacNhan.Name = "rbDaXacNhan";
            this.rbDaXacNhan.Size = new System.Drawing.Size(129, 24);
            this.rbDaXacNhan.TabIndex = 26;
            this.rbDaXacNhan.TabStop = true;
            this.rbDaXacNhan.Text = "Đã Xác Nhận";
            this.rbDaXacNhan.UseVisualStyleBackColor = true;
            // 
            // cboHocKy
            // 
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(1106, 343);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(366, 28);
            this.cboHocKy.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(941, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 26);
            this.label4.TabIndex = 21;
            this.label4.Text = "Trạng Thái";
            // 
            // txtSoTinChi
            // 
            this.txtSoTinChi.Location = new System.Drawing.Point(1106, 271);
            this.txtSoTinChi.Name = "txtSoTinChi";
            this.txtSoTinChi.Size = new System.Drawing.Size(372, 26);
            this.txtSoTinChi.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(941, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Mã Học Kỳ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(937, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 26);
            this.label6.TabIndex = 18;
            this.label6.Text = "Số Tín Chỉ";
            // 
            // cboMaMon
            // 
            this.cboMaMon.FormattingEnabled = true;
            this.cboMaMon.Location = new System.Drawing.Point(492, 418);
            this.cboMaMon.Name = "cboMaMon";
            this.cboMaMon.Size = new System.Drawing.Size(366, 28);
            this.cboMaMon.TabIndex = 17;
            this.cboMaMon.SelectedIndexChanged += new System.EventHandler(this.cboMaMon_SelectedIndexChanged);
            // 
            // cboMaSV
            // 
            this.cboMaSV.FormattingEnabled = true;
            this.cboMaSV.Location = new System.Drawing.Point(492, 343);
            this.cboMaSV.Name = "cboMaSV";
            this.cboMaSV.Size = new System.Drawing.Size(366, 28);
            this.cboMaSV.TabIndex = 16;
            // 
            // MaDK
            // 
            this.MaDK.DataPropertyName = "MaDK";
            this.MaDK.HeaderText = "Mã Đăng Ký ";
            this.MaDK.MinimumWidth = 8;
            this.MaDK.Name = "MaDK";
            this.MaDK.Width = 150;
            // 
            // MaSV
            // 
            this.MaSV.DataPropertyName = "MaSV";
            this.MaSV.HeaderText = "Mã Sinh Viên";
            this.MaSV.MinimumWidth = 8;
            this.MaSV.Name = "MaSV";
            this.MaSV.Width = 150;
            // 
            // MaMon
            // 
            this.MaMon.DataPropertyName = "MaMon";
            this.MaMon.HeaderText = "Mã Môn";
            this.MaMon.MinimumWidth = 8;
            this.MaMon.Name = "MaMon";
            this.MaMon.Width = 150;
            // 
            // SoTinChi
            // 
            this.SoTinChi.DataPropertyName = "SoTinChi";
            this.SoTinChi.HeaderText = "Số tín Chỉ ";
            this.SoTinChi.MinimumWidth = 8;
            this.SoTinChi.Name = "SoTinChi";
            this.SoTinChi.Width = 150;
            // 
            // MaHocKi
            // 
            this.MaHocKi.DataPropertyName = "MaHocKi";
            this.MaHocKi.HeaderText = "Mã Học Kì ";
            this.MaHocKi.MinimumWidth = 8;
            this.MaHocKi.Name = "MaHocKi";
            this.MaHocKi.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 150;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(275, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "ĐĂNG KÝ MÔN HỌC";
            // 
            // DANGKYMONHOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 912);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_main);
            this.Name = "DANGKYMONHOC";
            this.Text = "DANGKYMONHOC";
            this.Load += new System.EventHandler(this.DANGKYMONHOC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDK)).EndInit();
            this.panel_cover.ResumeLayout(false);
            this.panel_cover.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel_main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDK;
        private System.Windows.Forms.Panel panel_cover;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.TextBox txtMaDK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnLop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.ComboBox cboMaSV;
        private System.Windows.Forms.ComboBox cboMaMon;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoTinChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbHuy;
        private System.Windows.Forms.RadioButton rbChoXacNhan;
        private System.Windows.Forms.RadioButton rbDaXacNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTinChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHocKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Label label7;
    }
}
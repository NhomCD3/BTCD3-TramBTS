namespace QLTramBTS
{
    partial class ThongtinMaynoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoLanViPham = new System.Windows.Forms.TextBox();
            this.dtpNgayGioChayMayNo = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayGioMatDien = new System.Windows.Forms.DateTimePicker();
            this.cbTramId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbVP = new System.Windows.Forms.Label();
            this.txtSoGioChay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lbHang = new System.Windows.Forms.Label();
            this.lbMa = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoLanViPham);
            this.groupBox1.Controls.Add(this.dtpNgayGioChayMayNo);
            this.groupBox1.Controls.Add(this.dtpNgayGioMatDien);
            this.groupBox1.Controls.Add(this.cbTramId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbVP);
            this.groupBox1.Controls.Add(this.txtSoGioChay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.lbHang);
            this.groupBox1.Controls.Add(this.lbMa);
            this.groupBox1.Controls.Add(this.lbTen);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chạy máy nổ";
            // 
            // txtSoLanViPham
            // 
            this.txtSoLanViPham.Enabled = false;
            this.txtSoLanViPham.Location = new System.Drawing.Point(578, 43);
            this.txtSoLanViPham.Name = "txtSoLanViPham";
            this.txtSoLanViPham.Size = new System.Drawing.Size(301, 20);
            this.txtSoLanViPham.TabIndex = 21;
            // 
            // dtpNgayGioChayMayNo
            // 
            this.dtpNgayGioChayMayNo.Location = new System.Drawing.Point(132, 70);
            this.dtpNgayGioChayMayNo.Name = "dtpNgayGioChayMayNo";
            this.dtpNgayGioChayMayNo.Size = new System.Drawing.Size(296, 20);
            this.dtpNgayGioChayMayNo.TabIndex = 20;
            this.dtpNgayGioChayMayNo.ValueChanged += new System.EventHandler(this.dtpNgayGioChayMayNo_ValueChanged);
            // 
            // dtpNgayGioMatDien
            // 
            this.dtpNgayGioMatDien.Location = new System.Drawing.Point(132, 43);
            this.dtpNgayGioMatDien.Name = "dtpNgayGioMatDien";
            this.dtpNgayGioMatDien.Size = new System.Drawing.Size(296, 20);
            this.dtpNgayGioMatDien.TabIndex = 19;
            this.dtpNgayGioMatDien.ValueChanged += new System.EventHandler(this.dtpNgayGioChayMayNo_ValueChanged);
            // 
            // cbTramId
            // 
            this.cbTramId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTramId.FormattingEnabled = true;
            this.cbTramId.Location = new System.Drawing.Point(578, 70);
            this.cbTramId.Name = "cbTramId";
            this.cbTramId.Size = new System.Drawing.Size(301, 21);
            this.cbTramId.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(464, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã trạm";
            // 
            // lbVP
            // 
            this.lbVP.AutoSize = true;
            this.lbVP.Location = new System.Drawing.Point(464, 47);
            this.lbVP.Name = "lbVP";
            this.lbVP.Size = new System.Drawing.Size(77, 13);
            this.lbVP.TabIndex = 8;
            this.lbVP.Text = "Số lần vi phạm";
            // 
            // txtSoGioChay
            // 
            this.txtSoGioChay.Location = new System.Drawing.Point(578, 16);
            this.txtSoGioChay.Name = "txtSoGioChay";
            this.txtSoGioChay.Size = new System.Drawing.Size(301, 20);
            this.txtSoGioChay.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số giờ chạy máy nổ";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(132, 16);
            this.txtMa.MaxLength = 50;
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(296, 20);
            this.txtMa.TabIndex = 3;
            // 
            // lbHang
            // 
            this.lbHang.AutoSize = true;
            this.lbHang.Location = new System.Drawing.Point(6, 74);
            this.lbHang.Name = "lbHang";
            this.lbHang.Size = new System.Drawing.Size(112, 13);
            this.lbHang.TabIndex = 2;
            this.lbHang.Text = "Ngày giờ chạy máy nổ";
            // 
            // lbMa
            // 
            this.lbMa.AutoSize = true;
            this.lbMa.Location = new System.Drawing.Point(6, 47);
            this.lbMa.Name = "lbMa";
            this.lbMa.Size = new System.Drawing.Size(93, 13);
            this.lbMa.TabIndex = 1;
            this.lbMa.Text = "Ngày giờ mất điện";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Location = new System.Drawing.Point(6, 20);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(22, 13);
            this.lbTen.TabIndex = 0;
            this.lbTen.Text = "Mã";
            // 
            // listView
            // 
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(13, 121);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(885, 266);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(96, 397);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(181, 397);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(345, 397);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(730, 397);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "TÌm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(427, 398);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(262, 397);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Thiết lập lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(597, 398);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(129, 21);
            this.cbSearch.TabIndex = 8;
            // 
            // ThongtinMaynoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 437);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThongtinMaynoForm";
            this.Text = "Quản lý dữ liệu trạm phát sóng BTS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbHang;
        private System.Windows.Forms.Label lbMa;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label lbVP;
        private System.Windows.Forms.TextBox txtSoGioChay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.DateTimePicker dtpNgayGioChayMayNo;
        private System.Windows.Forms.DateTimePicker dtpNgayGioMatDien;
        private System.Windows.Forms.ComboBox cbTramId;
        private System.Windows.Forms.TextBox txtSoLanViPham;
        private System.Windows.Forms.ComboBox cbSearch;
    }
}
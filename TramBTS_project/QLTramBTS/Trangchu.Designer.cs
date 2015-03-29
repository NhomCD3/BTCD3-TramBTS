namespace QLTramBTS
{
    partial class Trangchu
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
            this.tabBTS = new System.Windows.Forms.TabControl();
            this.tabThongtinBTS = new System.Windows.Forms.TabPage();
            this.tabThongtinMayno = new System.Windows.Forms.TabPage();
            this.tabQLMayno = new System.Windows.Forms.TabPage();
            this.tabQLChiphi = new System.Windows.Forms.TabPage();
            this.tabBTS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBTS
            // 
            this.tabBTS.Controls.Add(this.tabThongtinBTS);
            this.tabBTS.Controls.Add(this.tabThongtinMayno);
            this.tabBTS.Controls.Add(this.tabQLMayno);
            this.tabBTS.Controls.Add(this.tabQLChiphi);
            this.tabBTS.Location = new System.Drawing.Point(0, 0);
            this.tabBTS.Name = "tabBTS";
            this.tabBTS.SelectedIndex = 0;
            this.tabBTS.Size = new System.Drawing.Size(928, 458);
            this.tabBTS.TabIndex = 0;
            this.tabBTS.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabBTS_Selecting);
            // 
            // tabThongtinBTS
            // 
            this.tabThongtinBTS.Location = new System.Drawing.Point(4, 22);
            this.tabThongtinBTS.Name = "tabThongtinBTS";
            this.tabThongtinBTS.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongtinBTS.Size = new System.Drawing.Size(920, 432);
            this.tabThongtinBTS.TabIndex = 0;
            this.tabThongtinBTS.Text = "Thông tin trạm BTS";
            this.tabThongtinBTS.UseVisualStyleBackColor = true;
            // 
            // tabThongtinMayno
            // 
            this.tabThongtinMayno.Location = new System.Drawing.Point(4, 22);
            this.tabThongtinMayno.Name = "tabThongtinMayno";
            this.tabThongtinMayno.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongtinMayno.Size = new System.Drawing.Size(920, 432);
            this.tabThongtinMayno.TabIndex = 1;
            this.tabThongtinMayno.Text = "Thông tin chạy máy nổ";
            this.tabThongtinMayno.UseVisualStyleBackColor = true;
            // 
            // tabQLMayno
            // 
            this.tabQLMayno.Location = new System.Drawing.Point(4, 22);
            this.tabQLMayno.Name = "tabQLMayno";
            this.tabQLMayno.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLMayno.Size = new System.Drawing.Size(920, 432);
            this.tabQLMayno.TabIndex = 2;
            this.tabQLMayno.Text = "Quản lý thời gian chạy máy nổ";
            this.tabQLMayno.UseVisualStyleBackColor = true;
            // 
            // tabQLChiphi
            // 
            this.tabQLChiphi.Location = new System.Drawing.Point(4, 22);
            this.tabQLChiphi.Name = "tabQLChiphi";
            this.tabQLChiphi.Padding = new System.Windows.Forms.Padding(3);
            this.tabQLChiphi.Size = new System.Drawing.Size(920, 432);
            this.tabQLChiphi.TabIndex = 3;
            this.tabQLChiphi.Text = "Quản lý chi phí chạy máy nổ";
            this.tabQLChiphi.UseVisualStyleBackColor = true;
            // 
            // Trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 458);
            this.Controls.Add(this.tabBTS);
            this.Name = "Trangchu";
            this.Text = "Quản lý trạm BTS";
            this.tabBTS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBTS;
        private System.Windows.Forms.TabPage tabThongtinBTS;
        private System.Windows.Forms.TabPage tabThongtinMayno;
        private System.Windows.Forms.TabPage tabQLMayno;
        private System.Windows.Forms.TabPage tabQLChiphi;
    }
}
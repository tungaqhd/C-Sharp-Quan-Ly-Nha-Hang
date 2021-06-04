
namespace BTL_Quan_Ly_Nha_Hang
{
    partial class QuanLyPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyPanel));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khuyếnMãiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem,
            this.menuToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.khuyếnMãiToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1505, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trangChủToolStripMenuItem.Image")));
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(132, 29);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem});
            this.nhânViênToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhânViênToolStripMenuItem.Image")));
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(135, 29);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(237, 30);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýSảnPhẩmToolStripMenuItem,
            this.thốngKêKhoToolStripMenuItem});
            this.sảnPhẩmToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sảnPhẩmToolStripMenuItem.Image")));
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem_Click);
            // 
            // thốngKêKhoToolStripMenuItem
            // 
            this.thốngKêKhoToolStripMenuItem.Name = "thốngKêKhoToolStripMenuItem";
            this.thốngKêKhoToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.thốngKêKhoToolStripMenuItem.Text = "Quản lý kho";
            this.thốngKêKhoToolStripMenuItem.Click += new System.EventHandler(this.thốngKêKhoToolStripMenuItem_Click);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMenuToolStripMenuItem,
            this.quảnLýMenuToolStripMenuItem});
            this.menuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menuToolStripMenuItem.Image")));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // thêmMenuToolStripMenuItem
            // 
            this.thêmMenuToolStripMenuItem.Name = "thêmMenuToolStripMenuItem";
            this.thêmMenuToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.thêmMenuToolStripMenuItem.Text = "Thêm Menu";
            this.thêmMenuToolStripMenuItem.Click += new System.EventHandler(this.thêmMenuToolStripMenuItem_Click);
            // 
            // quảnLýMenuToolStripMenuItem
            // 
            this.quảnLýMenuToolStripMenuItem.Name = "quảnLýMenuToolStripMenuItem";
            this.quảnLýMenuToolStripMenuItem.Size = new System.Drawing.Size(203, 30);
            this.quảnLýMenuToolStripMenuItem.Text = "Quản lý Menu";
            this.quảnLýMenuToolStripMenuItem.Click += new System.EventHandler(this.quảnLýMenuToolStripMenuItem_Click);
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hóaĐơnToolStripMenuItem.Image")));
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(121, 29);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa đơn";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // khuyếnMãiToolStripMenuItem
            // 
            this.khuyếnMãiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("khuyếnMãiToolStripMenuItem.Image")));
            this.khuyếnMãiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.khuyếnMãiToolStripMenuItem.Name = "khuyếnMãiToolStripMenuItem";
            this.khuyếnMãiToolStripMenuItem.Size = new System.Drawing.Size(147, 29);
            this.khuyếnMãiToolStripMenuItem.Text = "Khuyến mãi";
            this.khuyếnMãiToolStripMenuItem.Click += new System.EventHandler(this.khuyếnMãiToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đăngXuấtToolStripMenuItem.Image")));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(135, 29);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kháchHàngToolStripMenuItem.Image")));
            this.kháchHàngToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(149, 29);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // chartDoanhThu
            // 
            this.chartDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend2);
            this.chartDoanhThu.Location = new System.Drawing.Point(23, 201);
            this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Doanh thu";
            this.chartDoanhThu.Series.Add(series2);
            this.chartDoanhThu.Size = new System.Drawing.Size(1469, 557);
            this.chartDoanhThu.TabIndex = 1;
            this.chartDoanhThu.Text = "chart1";
            title2.Name = "Biểu đồ doanh thu";
            this.chartDoanhThu.Titles.Add(title2);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(23, 162);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(402, 33);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(430, 162);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(402, 33);
            this.dtpTo.TabIndex = 2;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(843, 161);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(108, 34);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Lọc";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến:";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Open Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(18, 46);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(107, 30);
            this.lblWelcome.TabIndex = 6;
            this.lblWelcome.Text = "Xin chào";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
            this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnXuat.Location = new System.Drawing.Point(959, 161);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(180, 34);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất báo cáo";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // QuanLyPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 770);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "QuanLyPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuanLyPanel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khuyếnMãiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
    }
}
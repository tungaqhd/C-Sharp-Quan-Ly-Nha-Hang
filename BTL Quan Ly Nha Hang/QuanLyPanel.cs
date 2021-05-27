using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTL_Quan_Ly_Nha_Hang
{
    public partial class QuanLyPanel : Form
    {
        public NhanVien nv;
        public QuanLyPanel()
        {
            InitializeComponent();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham qlspForm = new QuanLySanPham();
            qlspForm.ShowDialog();

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void thêmMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemMenuForm themMenuForm = new ThemMenuForm();
            themMenuForm.ShowDialog();

        }

        private void quảnLýMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMenuForm qlmnForm = new QuanLyMenuForm();
            qlmnForm.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThongTinNhanVien quanLyThongTinNhanVien = new QuanLyThongTinNhanVien();
            quanLyThongTinNhanVien.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlyhoadon quanlyhoadon = new Quanlyhoadon();
            quanlyhoadon.ShowDialog();
        }

        private void QuanLyPanel_Load(object sender, EventArgs e)
        {
            DateTime to = DateTime.Now;
            DateTime from = DateTime.Now.AddDays(-7);
            dtpTo.Value = to;
            dtpFrom.Value = from;
            HienThiChart(from, to);
            lblWelcome.Text = "Xin chào " + nv.ten_nv.ToString();
        }

        private void HienThiChart(DateTime fr, DateTime to)
        {
            chartDoanhThu.Series["Doanh thu"].Points.Clear();
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var stats = (
                        from ct in db.ChiTietHoaDons
                        join hd in db.HoaDons
                        on ct.ma_hd equals hd.ma_hd
                        join sp in db.SanPhams
                        on ct.ma_sp equals sp.ma_sp
                        where hd.trang_thai_hd == 1 && hd.ngay >= fr && hd.ngay <= to
                        select new
                        {
                            so_luong = ct.so_luong,
                            don_gia = sp.don_gia,
                            ngay = hd.ngay
                        } into tmp
                        group tmp by new { tmp.ngay } into final
                        select new
                        {
                            ngay = final.Key.ngay,
                            doanh_thu = final.Sum(f => f.so_luong * f.don_gia)
                        }
                    ).ToList();

                foreach (var tt in stats)
                {
                    chartDoanhThu.Series["Doanh thu"].Points.AddXY(tt.ngay, tt.doanh_thu);
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            HienThiChart(from, to);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DateTime fr = dtpFrom.Value;
            DateTime to = dtpTo.Value;

            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            app.Visible = false;

            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Name = "Doanh thu";


            using (NhaHangEntities db = new NhaHangEntities())
            {
                var stats = (
                        from ct in db.ChiTietHoaDons
                        join hd in db.HoaDons
                        on ct.ma_hd equals hd.ma_hd
                        join sp in db.SanPhams
                        on ct.ma_sp equals sp.ma_sp
                        where hd.trang_thai_hd == 1 && hd.ngay >= fr && hd.ngay <= to
                        select new
                        {
                            so_luong = ct.so_luong,
                            don_gia = sp.don_gia,
                            ngay = hd.ngay
                        } into tmp
                        group tmp by new { tmp.ngay } into final
                        select new
                        {
                            ngay = final.Key.ngay,
                            doanh_thu = final.Sum(f => f.so_luong * f.don_gia)
                        }
                    ).ToList();

                worksheet.Cells[1, 1] = "Ngày";
                worksheet.Cells[1, 2] = "Doanh thu";

                for(int i=0;i<stats.Count;++i)
                {
                    worksheet.Cells[i+2, 1] = "'"+stats[i].ngay.ToString();
                    worksheet.Cells[i + 2, 2] = stats[i].doanh_thu.ToString();
                }
            }


            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm";
            saveFileDialog.FilterIndex = 2;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }

            
            app.Quit();

        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhuyenMaiForm khuyenMaiForm = new KhuyenMaiForm();
            khuyenMaiForm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void thốngKêKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlykho quanlykho = new Quanlykho();
            quanlykho.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Quan_Ly_Nha_Hang
{
    public partial class Quanlyhoadon : Form
    {
        int idx = -1;

        public Quanlyhoadon()
        {
            InitializeComponent();
        }
        public void HienThi(DateTime from, DateTime to)
        {
            dtgvHoaDon.DataSource = null;
            using(NhaHangEntities db = new NhaHangEntities())
            {
                dtgvHoaDon.DataSource = db.HoaDons.Where(h => h.ngay >= from && h.ngay <= to).Select(h => new
                {
                    h.ma_hd,
                    h.NhanVien.ten_nv,
                    h.Ban.ten_ban,
                    h.ngay,
                    h.trang_thai_hd
                }).ToList();

                dtgvHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
                dtgvHoaDon.Columns[1].HeaderText = "Tên nhân viên";
                dtgvHoaDon.Columns[2].HeaderText = "Tên bàn";
                dtgvHoaDon.Columns[3].HeaderText = "Ngày tạo";
                dtgvHoaDon.Columns[4].HeaderText = "Trạng thái";
            }
             
        }

        private void Quanlyhoadon_Load(object sender, EventArgs e)
        {
            DateTime to = DateTime.Now;
            DateTime from = DateTime.Now.AddDays(-14);
            dtpFrom.Value = from;
            dtpTo.Value = to;
            HienThi(from, to);
        }

        private void dataGridViewhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectRowhoadon = e.RowIndex;
            //DataGridViewRow row = dtgvHoaDon.Rows[selectRowhoadon];
            //int mahd = Convert.ToInt32(row.Cells[0].Value);
            //List<ChiTietHoaDon> cthd = db.ChiTietHoaDons.Where(ct => ct.ma_hd == mahd).ToList();
            //dtgvChiTiet.DataSource = cthd;

        }

        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            int maHD = Convert.ToInt32(dtgvHoaDon.Rows[idx].Cells[0].Value.ToString());
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var ct = (from c in db.ChiTietHoaDons
                          join s in db.SanPhams on c.ma_sp equals s.ma_sp
                          where c.ma_hd == maHD
                          select new { c.ma_sp, s.ten_sp, c.so_luong, s.don_gia } into tmp
                          group tmp by new { tmp.ma_sp, tmp.ten_sp, tmp.don_gia } into final
                          select new
                          {
                              ma_sp = final.Key.ma_sp,
                              ten_sp = final.Key.ten_sp,
                              don_gia = final.Key.don_gia,
                              so_luong = final.Sum(f => f.so_luong),
                              tong = final.Sum(f => f.so_luong * f.don_gia)
                          }).ToList();

                dtgvChiTiet.DataSource = null;
                dtgvChiTiet.DataSource = ct;
                dtgvChiTiet.Columns[0].HeaderText = "Mã sản phẩm";
                dtgvChiTiet.Columns[1].HeaderText = "Tên sản phẩm";
                dtgvChiTiet.Columns[2].HeaderText = "Đơn giá";
                dtgvChiTiet.Columns[3].HeaderText = "Số lượng";
                dtgvChiTiet.Columns[4].HeaderText = "Thành tiền";
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value;
            DateTime to = dtpTo.Value;
            HienThi(from, to);
        }
    }
}

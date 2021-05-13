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
    public partial class ThanhToanForm : Form
    {
        public int maBan;
        public int maHD;
        Ban ban;
        public string maGiamGia;
        NhaHangEntities db = new NhaHangEntities();
        public ThanhToanForm()
        {
            InitializeComponent();
        }

        private void ThanhToanForm_Load(object sender, EventArgs e)
        {
            ban = db.Bans.Where(b => b.ma_ban == maBan).FirstOrDefault();
            lbltenBan.Text = ban.ten_ban;

            int tongTien = 0;
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

            foreach (var tt in ct)
            {
                tongTien += (int)tt.tong;
            }
            lblTongTien.Text = tongTien + "";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ban.trang_thai = 1;
            HoaDon hd = db.HoaDons.Where(h => h.ma_hd == maHD).FirstOrDefault();
            hd.trang_thai_hd = 1;
            db.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}

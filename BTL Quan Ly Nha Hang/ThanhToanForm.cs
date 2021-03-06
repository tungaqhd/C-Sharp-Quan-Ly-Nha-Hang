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
        int tongTien;
        Ban ban;
        public string maGiamGia;
        NhaHangEntities db = new NhaHangEntities();
        KhuyenMai km;
        KhachHang kh;
        public ThanhToanForm()
        {
            InitializeComponent();
        }

        private void ThanhToanForm_Load(object sender, EventArgs e)
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                km = db.KhuyenMais.Find(maGiamGia);
                if (km != null)
                {
                    lblGiamGia.Text = km.tien_giam + " vnđ";
                }
                else
                {
                    lblGiamGia.Text = "0 vnđ";
                }
            }

            ban = db.Bans.Where(b => b.ma_ban == maBan).FirstOrDefault();
            lbltenBan.Text = ban.ten_ban;

            tongTien = 0;
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
            lblTongTien.Text = tongTien + " vnđ";
            int thanhToan = km != null ? tongTien - (int)km.tien_giam : tongTien;
            lblThanhToan.Text = thanhToan + " vnđ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSDT.Text == "" || txtHoTen.Text == "")
                {
                    throw new Exception("Vui lòng nhập thông tin khách hàng");
                }
                int diem = Convert.ToInt32(txtDiem.Text);
                int diemDung = txtDiemSD.Text == "" ? 0 : Convert.ToInt32(txtDiemSD.Text);
                if(diemDung > diem)
                {
                    throw new FormatException();
                }

                ban.trang_thai = 1;
                HoaDon hd = db.HoaDons.Where(h => h.ma_hd == maHD).FirstOrDefault();
                if (km != null)
                {
                    hd.ma_km = km.ma_km;
                }
                hd.trang_thai_hd = 1;
                
                if (kh == null)
                {
                    string hoTen = txtHoTen.Text;
                    string sdt = txtSDT.Text;
                    kh = new KhachHang() { ho_ten = hoTen, sdt = sdt, diem = 0 };
                    db.KhachHangs.Add(kh);
                }

                tongTien -= diemDung;
                kh.diem -= diemDung;
                kh.diem += (int)(tongTien * 0.02);
                
                hd.ma_kh = kh.ma_kh;
                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Điểm không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text;
            kh = db.KhachHangs.Where(k => k.sdt == sdt).FirstOrDefault();
            if (kh != null)
            {
                txtHoTen.Text = kh.ho_ten;
                txtDiem.Text = kh.diem + "";
                txtHoTen.Enabled = false;
            }
        }

        private void txtDiemSD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int diem = txtDiemSD.Text != "" ? Convert.ToInt32(txtDiemSD.Text) : 0;
                int tienKm = km != null ? (int)km.tien_giam : 0;
                lblDiem.Text = diem + "";

                lblThanhToan.Text = tongTien - tienKm - diem + "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Điểm không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

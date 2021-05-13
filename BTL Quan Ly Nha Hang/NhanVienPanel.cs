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
    public partial class NhanVienPanel : Form
    {
        int idx = -1;
        int idxBan = -1;
        int idxMenu = -1;
        public int maNv = -1;
        List<Ban> dsBan;
        public NhanVienPanel()
        {
            InitializeComponent();
        }

        private void NhanVienPanel_Load(object sender, EventArgs e)
        {
            HienThiBan();

            HienThiSanPham();
            HienThiMenu();
        }

        private void HienThiSanPham()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                dtgvSanPham.DataSource = db.SanPhams.ToList();
                dtgvSanPham.Columns[0].HeaderText = "Mã";
                dtgvSanPham.Columns[1].HeaderText = "Tên";
                dtgvSanPham.Columns[2].HeaderText = "Số lượng còn";
                dtgvSanPham.Columns[3].HeaderText = "Loại";
                dtgvSanPham.Columns[4].HeaderText = "Đơn giá";
            }
        }

        private void HienThiBan()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                dsBan = db.Bans.ToList();
                lvBan.View = View.LargeIcon;
                lvBan.Items.Clear();
                foreach (Ban ban in dsBan)
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = ban.ten_ban;
                    it.ImageIndex = (int)ban.trang_thai;

                    lvBan.Items.Add(it);
                }
            }
        }

        private void HienThiChiTietHoaDon()
        {
            int maHD = Convert.ToInt32(txtMaHD.Text);
            int tongTien = 0;
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var ct = (from c in db.ChiTietHoaDons
                      join s in db.SanPhams on c.ma_sp equals s.ma_sp
                      where c.ma_hd == maHD
                      select new { c.ma_sp, s.ten_sp, c.so_luong, s.don_gia } into tmp
                      group tmp by new {tmp.ma_sp, tmp.ten_sp, tmp.don_gia} into final
                      select new
                      {
                          ma_sp = final.Key.ma_sp,
                          ten_sp = final.Key.ten_sp,
                          don_gia = final.Key.don_gia,
                          so_luong = final.Sum(f => f.so_luong),
                          tong = final.Sum(f => f.so_luong * f.don_gia)
                      }).ToList();

                dtgvChiTietHD.DataSource = null;
                dtgvChiTietHD.DataSource = ct;
                dtgvChiTietHD.Columns[0].HeaderText = "Mã sản phẩm";
                dtgvChiTietHD.Columns[1].HeaderText = "Tên sản phẩm";
                dtgvChiTietHD.Columns[2].HeaderText = "Đơn giá";
                dtgvChiTietHD.Columns[3].HeaderText = "Số lượng";
                dtgvChiTietHD.Columns[4].HeaderText = "Thành tiền";

                foreach(var tt in ct)
                {
                    tongTien += (int)tt.tong;
                }
                txtTongTien.Text = tongTien + "";
            }
        }

        private void HienThiMenu()
        {
            dtgvMenu.DataSource = null;
            using (NhaHangEntities db = new NhaHangEntities())
            {
                dtgvMenu.DataSource = db.Menus.ToList();
            }
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            cbxMon.Text = dtgvSanPham.Rows[idx].Cells[5].Value.ToString();
            txtTenMon.Text = dtgvSanPham.Rows[idx].Cells[1].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ten = txtTenMon.Text;
            using (NhaHangEntities db = new NhaHangEntities())
            {
                dtgvSanPham.DataSource = db.SanPhams.Where(sp => sp.ten_sp.Contains(ten)).ToList();
            }
        }

        private void lvBan_Click(object sender, EventArgs e)
        {
            idxBan = lvBan.SelectedItems[0].Index;
            LoadBan(idxBan);
        }

        private void LoadBan(int maban)
        {
            Ban ban = dsBan[idxBan];

            txtTenban.Text = ban.ten_ban;
            txtTrangThai.Text = ban.trang_thai == 0 ? "Trống" : "Có người";
            using (NhaHangEntities db = new NhaHangEntities())
            {
                HoaDon hd = db.HoaDons.Where(h => h.ma_ban == ban.ma_ban && h.trang_thai_hd == 0).FirstOrDefault();
                if (hd != null)
                {
                    txtMaHD.Text = hd.ma_hd + "";
                    HienThiChiTietHoaDon();
                }
                else
                {
                    txtMaHD.Text = "";
                    dtgvChiTietHD.DataSource = null;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(idx == -1)
            {
                MessageBox.Show("Chưa chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maSp = Convert.ToInt32(dtgvSanPham.Rows[idx].Cells[0].Value.ToString());
            int maHd = Convert.ToInt32(txtMaHD.Text);
            int soLuong = 0;
            try
            {
                soLuong = Convert.ToInt32(txtSoLuong.Text);
                if(soLuong <= 0)
                {
                    throw new Exception();
                }
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon() { ma_sp = maSp, ma_hd = maHd, so_luong = soLuong });
                    db.SaveChanges();
                }
                HienThiChiTietHoaDon();
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            int maBan = dsBan[idxBan].ma_ban;
            DateTime ngay = DateTime.Now;
            using (NhaHangEntities db = new NhaHangEntities())
            {
                db.HoaDons.Add(new HoaDon() { ma_ban = maBan, ma_nv = maNv, ngay = ngay, trang_thai_hd = 0 });
                Ban ban = db.Bans.Where(b => b.ma_ban == maBan).FirstOrDefault();
                ban.trang_thai = 0;
                db.SaveChanges();
            }

            HienThiBan();
            LoadBan(idxBan);
            lvBan.Items[idxBan].Selected = true;
            HienThiChiTietHoaDon();

        }

        private void dtgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idxMenu = e.RowIndex;
            txtTenMenu.Text = dtgvMenu.Rows[idxMenu].Cells[1].Value.ToString();
        }

        private void btnTimMenu_Click(object sender, EventArgs e)
        {
            string ten = txtTenMenu.Text;
            using (NhaHangEntities db = new NhaHangEntities())
            {
                dtgvMenu.DataSource = db.Menus.Where(mn => mn.ten_menu.Contains(ten)).ToList();
            }
        }

        private void btnThemMenu_Click(object sender, EventArgs e)
        {
            if (idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (idxMenu == -1)
            {
                MessageBox.Show("Chưa chọn Menu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maMenu = Convert.ToInt32(dtgvMenu.Rows[idxMenu].Cells[0].Value.ToString());
            int maHd = Convert.ToInt32(txtMaHD.Text);


            try
            {
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    int sl = Convert.ToInt32(txtSoLuongMenu.Text);
                    if (sl<= 0)
                    {
                        throw new Exception();
                    }
                    for (int i = 0; i < sl; ++i)
                    {
                        List<ChiTietMenu> ct = db.ChiTietMenus.Where(c => c.ma_menu == maMenu).ToList();
                        foreach (ChiTietMenu c in ct)
                        {
                            db.ChiTietHoaDons.Add(new ChiTietHoaDon() { ma_sp = c.ma_sp, ma_hd = maHd, so_luong = 1 });
                        }
                    }
                    db.SaveChanges();
                }
                HienThiChiTietHoaDon();
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (idxBan == -1)
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bàn này còn trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ThanhToanForm thanhToanForm = new ThanhToanForm();
            thanhToanForm.maBan = dsBan[idxBan].ma_ban;
            thanhToanForm.maHD = Convert.ToInt32(txtMaHD.Text);
            thanhToanForm.maGiamGia = txtGiamGia.Text;
            
            if (thanhToanForm.ShowDialog(this) == DialogResult.OK)
            {
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    HienThiBan();
                    LoadBan(idxBan);
                    lvBan.Items[idxBan].Selected = true;
                    MessageBox.Show("Đã thanh toán", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

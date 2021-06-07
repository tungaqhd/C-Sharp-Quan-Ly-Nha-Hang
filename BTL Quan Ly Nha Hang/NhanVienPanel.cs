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
        public NhanVien nv;
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

            lblWelcome.Text = "Xin chào " + nv.ten_nv;
        }

        private void HienThiSanPham()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var sp = (from s in db.SanPhams select new { ma_sp = s.ma_sp, ten_sp = s.ten_sp, mo_ta = s.mo_ta, so_luong = s.so_luong, don_gia = s.don_gia, loai = s.loai, anh = s.anh }).ToList();
                dtgvSanPham.DataSource = sp;
                ((DataGridViewImageColumn)dtgvSanPham.Columns[6]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                dtgvSanPham.Columns[0].HeaderText = "Mã";
                dtgvSanPham.Columns[1].HeaderText = "Tên";
                dtgvSanPham.Columns[2].HeaderText = "Mô tả";
                dtgvSanPham.Columns[3].HeaderText = "Số lượng còn";
                dtgvSanPham.Columns[4].HeaderText = "Đơn giá";
                dtgvSanPham.Columns[5].HeaderText = "Loại";
                dtgvSanPham.Columns[6].HeaderText = "Ảnh";
            }
        }

        private void HienThiBanChuyen(int maBan)
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var banTrong = db.Bans.Where(b => b.trang_thai == 1 && b.ma_ban != maBan).ToList();
                cbxChuyenBan.ValueMember = "ma_ban";
                cbxChuyenBan.DisplayMember = "ten_ban";
                cbxChuyenBan.DataSource = banTrong;
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
                          group tmp by new { tmp.ma_sp, tmp.ten_sp, tmp.don_gia } into final
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

                foreach (var tt in ct)
                {
                    tongTien += (int)tt.tong;
                }
                txtTongTien.Text = tongTien + "";
            }
        }

        private bool kiemTraHoaDonTonTai()
        {
            if (idxBan == -1)
            {
                return false;
            }

            int maBan = dsBan[idxBan].ma_ban;
            if (dsBan[idxBan].trang_thai == 1)
            {
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    DateTime ngay = DateTime.Now;

                    db.HoaDons.Add(new HoaDon() { ma_ban = maBan, ma_nv = nv.ma_nv, ngay = ngay, trang_thai_hd = 0 });
                    Ban ban = db.Bans.Where(b => b.ma_ban == maBan).FirstOrDefault();
                    ban.trang_thai = 0;

                    db.SaveChanges();
                }
            }

            HienThiBan();
            LoadBan(idxBan);
            lvBan.Items[idxBan].Selected = true;
            return true;
        }

        private void HienThiMenu()
        {
            dtgvMenu.DataSource = null;
            using (NhaHangEntities db = new NhaHangEntities())
            {
                dtgvMenu.DataSource = (from m in db.Menus select new { ma_menu = m.ma_menu, ten_menu = m.ten_menu }).ToList();
                dtgvMenu.Columns[0].HeaderText = "Mã menu";
                dtgvMenu.Columns[1].HeaderText = "Tên menu";
            }
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idx = e.RowIndex;
                cbxMon.Text = dtgvSanPham.Rows[idx].Cells[5].Value.ToString();
                txtTenMon.Text = dtgvSanPham.Rows[idx].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
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
            HienThiBanChuyen(dsBan[idxBan].ma_ban);
        }

        private void LoadBan(int maban)
        {
            Ban ban = dsBan[idxBan];

            txtTenban.Text = ban.ten_ban;
            txtTrangThai.Text = ban.trang_thai == 1 ? "Trống" : "Có người";
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
                    txtTongTien.Text = "";
                    txtMaHD.Text = "";
                    dtgvChiTietHD.DataSource = null;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!kiemTraHoaDonTonTai())
            {
                MessageBox.Show("Chưa chọn bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (idx == -1)
            {
                MessageBox.Show("Chưa chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maSp = Convert.ToInt32(dtgvSanPham.Rows[idx].Cells[0].Value.ToString());
            int maHd = Convert.ToInt32(txtMaHD.Text);
            int soLuong;
            try
            {
                soLuong = Convert.ToInt32(txtSoLuong.Text);
                if (soLuong <= 0)
                {
                    throw new Exception();
                }

                int maBan = dsBan[idxBan].ma_ban;
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    SanPham sp = db.SanPhams.Find(maSp);
                    if(sp.so_luong < soLuong)
                    {
                        throw new Exception();
                    }
                    sp.so_luong -= soLuong;
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon() { ma_sp = maSp, ma_hd = maHd, so_luong = soLuong });
                    db.SaveChanges();
                }
                HienThiChiTietHoaDon();
                HienThiSanPham();
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void dtgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idxMenu = e.RowIndex;
                txtTenMenu.Text = dtgvMenu.Rows[idxMenu].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
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
            if (!kiemTraHoaDonTonTai())
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
                    if (sl <= 0)
                    {
                        throw new Exception();
                    }
                    List<ChiTietMenu> ct = db.ChiTietMenus.Where(c => c.ma_menu == maMenu).ToList();
                    foreach (ChiTietMenu c in ct)
                    {
                        if(c.SanPham.so_luong < sl)
                        {
                            throw new Exception(c.SanPham.ten_sp + " không còn đủ hàng");
                        }
                    }
                    for (int i = 0; i < sl; ++i)
                    {
                        foreach (ChiTietMenu c in ct)
                        {
                            int maSp = (int)c.ma_sp;
                            SanPham s = db.SanPhams.Find(maSp);
                            s.so_luong -= sl;
                            db.ChiTietHoaDons.Add(new ChiTietHoaDon() { ma_sp = c.ma_sp, ma_hd = maHd, so_luong = 1 });
                        }
                    }
                    db.SaveChanges();
                }
                HienThiChiTietHoaDon();
                HienThiSanPham();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (txtGiamGia.Text != "")
            {
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    KhuyenMai km = db.KhuyenMais.Find(txtGiamGia.Text);
                    if (km == null)
                    {
                        MessageBox.Show("Mã khuyến mãi không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if(km.yeu_cau > Convert.ToInt32(txtTongTien.Text))
                    {
                        MessageBox.Show("Hóa đơn chưa đạt giá trị tối thiểu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            ThanhToanForm thanhToanForm = new ThanhToanForm();
            thanhToanForm.maBan = dsBan[idxBan].ma_ban;
            thanhToanForm.maHD = Convert.ToInt32(txtMaHD.Text);
            thanhToanForm.maGiamGia = txtGiamGia.Text;

            if (thanhToanForm.ShowDialog(this) == DialogResult.OK)
            {
                HienThiBan();
                LoadBan(idxBan);
                lvBan.Items[idxBan].Selected = true;
                MessageBox.Show("Đã thanh toán", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thêmBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Closed += (s, args) => this.Close();
            dangNhap.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlykho quanlykho = new Quanlykho();
            quanlykho.ShowDialog();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanlyhoadon quanlyhoadon = new Quanlyhoadon();
            quanlyhoadon.ShowDialog();
        }

        private void btnChuyenban_Click(object sender, EventArgs e)
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

            try
            {
                int idCu = dsBan[idxBan].ma_ban;
                int idMoi = Convert.ToInt32(cbxChuyenBan.SelectedValue.ToString());
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    Ban banCu = db.Bans.Where(b => b.ma_ban == idCu).FirstOrDefault();
                    banCu.trang_thai = 1;
                    Ban banMoi= db.Bans.Where(b => b.ma_ban == idMoi).FirstOrDefault();
                    banMoi.trang_thai = 0;
                    HoaDon hdCu = db.HoaDons.Where(h => h.ma_ban == idCu && h.trang_thai_hd == 0).FirstOrDefault();
                    hdCu.ma_ban = idMoi;
                    db.SaveChanges();
                }

                HienThiBan();
                LoadBan(idxBan);
                lvBan.Items[idxBan].Selected = true;
                MessageBox.Show("Đã chuyển bàn", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class ThemMenuForm : Form
    {
        NhaHangEntities db = new NhaHangEntities();

        List<int> dsMenu = new List<int>();
        List<int> dsMenuEdit = new List<int>();

        int selectedRowSanPham = 0;
        int selectedRowMenu = 0;
        public bool isEditing = false;
        public int editId = -1;
        public string tenMenu = "";
        public ThemMenuForm()
        {
            InitializeComponent();
        }

        void captNhatMenu()
        {
            List<SanPham> dsSp = new List<SanPham>();
            foreach (int ma in dsMenu)
            {
                SanPham rs = db.SanPhams.Where(s => s.ma_sp == ma).FirstOrDefault();
                if (rs != null)
                {
                    dsSp.Add(rs);
                }
            }
            dtgvMenu.DataSource = dsSp;
            dtgvMenu.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvMenu.Columns[1].HeaderText = "Tên";
            dtgvMenu.Columns[2].HeaderText = "Mô tả";
            dtgvMenu.Columns[3].HeaderText = "Số lượng";
            dtgvMenu.Columns[4].HeaderText = "Đơn giá";
            dtgvMenu.Columns[5].HeaderText = "Loại";
            dtgvMenu.Columns[6].HeaderText = "Ảnh";
        }

        private void ThemMenuForm_Load(object sender, EventArgs e)
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var dsSp = (from sp in db.SanPhams select new { ma_sp = sp.ma_sp, ten_sp = sp.ten_sp, mo_ta = sp.mo_ta, so_luong = sp.so_luong, don_gia = sp.don_gia, loai = sp.loai, anh = sp.anh }).ToList();
                dtgvSanPham.DataSource = dsSp;
                ((DataGridViewImageColumn)dtgvSanPham.Columns[6]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                dtgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dtgvSanPham.Columns[1].HeaderText = "Tên";
                dtgvSanPham.Columns[2].HeaderText = "Mô tả";
                dtgvSanPham.Columns[3].HeaderText = "Số lượng";
                dtgvSanPham.Columns[4].HeaderText = "Đơn giá";
                dtgvSanPham.Columns[5].HeaderText = "Loại";
                dtgvSanPham.Columns[6].HeaderText = "Ảnh";

                if (isEditing)
                {
                    tbxTen.Text = tenMenu;
                    List<ChiTietMenu> dsMon = db.ChiTietMenus.Where(ct => ct.ma_menu == editId).ToList();
                    foreach (ChiTietMenu mon in dsMon)
                    {
                        dsMenu.Add((int)mon.ma_sp);
                    }
                    captNhatMenu();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int maSp = Convert.ToInt32(dtgvSanPham.Rows[selectedRowSanPham].Cells[0].Value.ToString());
            dsMenu.Add(maSp);
            captNhatMenu();
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowSanPham = e.RowIndex;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSp = Convert.ToInt32(dtgvMenu.Rows[selectedRowMenu].Cells[0].Value.ToString());
            dsMenu.Remove(maSp);
            captNhatMenu();
        }

        private void dtgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowMenu = e.RowIndex;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = tbxTen.Text;
            if (ten == "")
            {
                MessageBox.Show("Tên menu không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isEditing)
            {
                Menu menu = db.Menus.Find(editId);
                menu.ten_menu = tbxTen.Text;
                db.ChiTietMenus.RemoveRange(db.ChiTietMenus.Where(m => m.ma_menu == menu.ma_menu));

                foreach (int maSp in dsMenu)
                {
                    db.ChiTietMenus.Add(new ChiTietMenu() { ma_menu = menu.ma_menu, ma_sp = maSp });
                }
            }
            else
            {
                Menu menu = new Menu() { ten_menu = ten };
                db.Menus.Add(menu);
                db.SaveChanges();

                foreach (int maSp in dsMenu)
                {
                    db.ChiTietMenus.Add(new ChiTietMenu() { ma_menu = menu.ma_menu, ma_sp = maSp });
                }
            }
            db.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}

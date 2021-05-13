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
        int selectedRowMenu= 0;
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
            foreach(int ma in dsMenu)
            {
                SanPham rs = db.SanPhams.Where(s => s.ma_sp == ma).FirstOrDefault();
                if(rs != null)
                {
                    dsSp.Add(rs);
                }
            }
            dtgvMenu.DataSource = dsSp;
        }

        private void ThemMenuForm_Load(object sender, EventArgs e)
        {
            List<SanPham> dsSp = db.SanPhams.ToList();
            dtgvSanPham.DataSource = dsSp;

            if(isEditing)
            {
                tbxTen.Text = tenMenu;
                List<ChiTietMenu> dsMon = db.ChiTietMenus.Where(ct => ct.ma_menu == editId).ToList();
                foreach(ChiTietMenu mon in dsMon)
                {
                    dsMenu.Add((int)mon.ma_sp);
                    dsMenuEdit.Add((int)mon.ma_sp);
                }
                captNhatMenu();
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
            if(isEditing)
            {
                Menu menu = db.Menus.Find(editId);
                menu.ten_menu = tbxTen.Text;
                var themMenu = dsMenu.Where(sp => !dsMenuEdit.Any(spCu => sp == spCu));

                foreach (int maSp in themMenu)
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

        }
    }
}

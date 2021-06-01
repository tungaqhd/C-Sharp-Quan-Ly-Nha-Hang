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
    public partial class QuanLyMenuForm : Form
    {
        NhaHangEntities db = new NhaHangEntities();
        int selected = 0;
        public QuanLyMenuForm()
        {
            InitializeComponent();
        }

        private void QuanLyMenuForm_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            var ds = (from mn in db.Menus select new { ma_mn = mn.ma_menu, ten_mn = mn.ten_menu }).ToList();
            dtgvMenu.DataSource = ds;
            dtgvMenu.Columns[0].HeaderText = "Mã Menu";
            dtgvMenu.Columns[1].HeaderText = "Tên Menu";
        }

        private void dtgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = e.RowIndex;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                ThemMenuForm themMenuForm = new ThemMenuForm();
                themMenuForm.isEditing = true;
                themMenuForm.tenMenu = dtgvMenu.Rows[selected].Cells[1].Value.ToString();
                themMenuForm.editId = Convert.ToInt32(dtgvMenu.Rows[selected].Cells[0].Value.ToString());
                if (themMenuForm.ShowDialog(this) == DialogResult.OK)
                {
                    HienThi();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            var ds = db.Menus.Where(mn => mn.ten_menu.Contains(name)).Select(mn => new { ma_mn = mn.ma_menu, ten_mn = mn.ten_menu }).ToList();
            dtgvMenu.DataSource = ds;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maMenu = Convert.ToInt32(dtgvMenu.Rows[selected].Cells[0].Value.ToString());
            Menu mn = db.Menus.Find(maMenu);
            db.Menus.Remove(mn);
            db.SaveChanges();
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemMenuForm themMenuForm = new ThemMenuForm();
            if (themMenuForm.ShowDialog(this) == DialogResult.OK)
            {
                HienThi();
            }
        }
    }
}

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
            List<Menu> ds = db.Menus.ToList();
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
            ThemMenuForm themMenuForm = new ThemMenuForm();
            themMenuForm.isEditing = true;
            themMenuForm.tenMenu = dtgvMenu.Rows[selected].Cells[1].Value.ToString();
            themMenuForm.editId = Convert.ToInt32(dtgvMenu.Rows[selected].Cells[0].Value.ToString());
            themMenuForm.ShowDialog();
        }
    }
}

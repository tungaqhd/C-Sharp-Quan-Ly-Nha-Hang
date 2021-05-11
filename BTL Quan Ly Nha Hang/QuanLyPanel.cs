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
    public partial class QuanLyPanel : Form
    {
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
    }
}

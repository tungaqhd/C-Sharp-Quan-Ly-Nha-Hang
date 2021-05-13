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
    public partial class QuanLyBan : Form
    {
        int idx;
        public QuanLyBan()
        {
            InitializeComponent();
        }

        private void HienThi()
        {
            using(NhaHangEntities db = new NhaHangEntities())
            {
                dtgvBan.DataSource = null;

                var dsBan = db.Bans.Select(b => new { b.ma_ban, b.ten_ban }).ToList();

                dtgvBan.DataSource = dsBan;
                dtgvBan.Columns[0].HeaderText = "Mã bàn";
                dtgvBan.Columns[1].HeaderText = "Tên bàn";
            }
        }

        private void QuanLyBan_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
            txtTenBan.Text = dtgvBan.Rows[idx].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                db.Bans.Add(new Ban() { ten_ban = txtTenBan.Text, trang_thai = 0 });
                db.SaveChanges();
            }
            HienThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(dtgvBan.Rows[idx].Cells[0].Value.ToString());
            using (NhaHangEntities db = new NhaHangEntities())
            {
                Ban b = db.Bans.Where(tmp => tmp.ma_ban == maBan).FirstOrDefault();
                b.ten_ban = txtTenBan.Text;
                db.SaveChanges();
            }
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(dtgvBan.Rows[idx].Cells[0].Value.ToString());
            using (NhaHangEntities db = new NhaHangEntities())
            {
                Ban b = db.Bans.Where(tmp => tmp.ma_ban == maBan).FirstOrDefault();
                db.Bans.Remove(b);
                db.SaveChanges();
            }
            HienThi();
        }
    }
}

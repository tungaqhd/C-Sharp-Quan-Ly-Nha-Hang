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
    public partial class Quanlykho : Form
    {
        int idx = -1;
        public Quanlykho()
        {
            InitializeComponent();
        }

        private void ThongKeKho_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var sp = (from s in db.SanPhams
                          select new
                          {
                              ma_sp = s.ma_sp,
                              ten_sp = s.ten_sp,
                              mo_ta = s.mo_ta,
                              so_luong = s.so_luong,
                              don_gia = s.don_gia,
                              loai = s.loai,
                              anh = s.anh
                          }).ToList();
                dtgvSanPham.DataSource = sp;
                dtgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dtgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dtgvSanPham.Columns[2].HeaderText = "Mô tả";
                dtgvSanPham.Columns[3].HeaderText = "Số lượng";
                dtgvSanPham.Columns[4].HeaderText = "Đơn giá";
                dtgvSanPham.Columns[5].HeaderText = "Loại";
                dtgvSanPham.Columns[6].HeaderText = "Ảnh";
            }
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (idx == -1)
            {
                MessageBox.Show("Bạn phải chọn một sản phẩm", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            try
            {
                int sl = Convert.ToInt32(txtSoLuong.Text);
                int id = Convert.ToInt32(dtgvSanPham.Rows[idx].Cells[0].Value.ToString());
                using(NhaHangEntities db = new NhaHangEntities())
                {
                    SanPham sp = db.SanPhams.Where(s => s.ma_sp == id).FirstOrDefault();
                    sp.so_luong += sl;
                    db.SaveChanges();
                }
                HienThi();
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }
        }
    }
}

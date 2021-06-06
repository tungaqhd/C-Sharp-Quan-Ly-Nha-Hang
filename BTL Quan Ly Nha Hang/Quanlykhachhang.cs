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
    public partial class Quanlykhachhang : Form
    {
        int idx = -1;
        public Quanlykhachhang()
        {
            InitializeComponent();
        }

        private void HienThi()
        {
            using(NhaHangEntities db = new NhaHangEntities())
            {
                var dsKH = db.KhachHangs.Select(kh => new { ma_kh = kh.ma_kh, ho_ten = kh.ho_ten, sdt = kh.sdt, diem = kh.diem }).ToList();
                dtgvKH.DataSource = dsKH;
                dtgvKH.Columns[0].HeaderText = "Mã khách hàng";
                dtgvKH.Columns[1].HeaderText = "Họ và tên";
                dtgvKH.Columns[2].HeaderText = "Số điện thoại";
                dtgvKH.Columns[3].HeaderText = "Điểm";
            }
        }

        private void Quanlykhachhang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sdt = txtSdt.Text;
            using(NhaHangEntities db = new NhaHangEntities())
            {
                var dsKH = db.KhachHangs.Where(kh => kh.sdt.Contains(sdt)).Select(kh => new { ma_kh = kh.ma_kh, ho_ten = kh.ho_ten, sdt = kh.sdt, diem = kh.diem }).ToList();
                dtgvKH.DataSource = dsKH;
            }    
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(idx == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (NhaHangEntities db = new NhaHangEntities())
                {
                    int id = Convert.ToInt32(dtgvKH.Rows[idx].Cells[0].Value.ToString());
                    KhachHang kh = db.KhachHangs.Find(id);
                    kh.ho_ten = txtHoTen.Text;
                    kh.sdt = txtSdt.Text;
                    kh.diem = Convert.ToInt32(txtDiem.Text);

                    db.SaveChanges();
                }
                HienThi();
                ResetForm();
            }
            catch (FormatException)
            {
                MessageBox.Show("Điểm không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;

            txtHoTen.Text = dtgvKH.Rows[idx].Cells[1].Value.ToString();
            txtSdt.Text = dtgvKH.Rows[idx].Cells[2].Value.ToString();
            txtDiem.Text = dtgvKH.Rows[idx].Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idx == -1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (NhaHangEntities db = new NhaHangEntities())
            {
                int maKh = Convert.ToInt32(dtgvKH.Rows[idx].Cells[0].Value.ToString());
                KhachHang khach = db.KhachHangs.Find(maKh);
                db.KhachHangs.Remove(khach);
                db.SaveChanges();
            }
            HienThi();
            ResetForm();
        }

        private void ResetForm()
        {
            txtDiem.Text = "";
            txtHoTen.Text = "";
            txtSdt.Text = "";
        }
    }
}

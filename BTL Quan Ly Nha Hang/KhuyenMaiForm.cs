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
    public partial class KhuyenMaiForm : Form
    {
        public KhuyenMaiForm()
        {
            InitializeComponent();
        }

        private void KhuyenMaiForm_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var cp = (from km in db.KhuyenMais select new { ma_km = km.ma_km, ten_km = km.ten_km, yeu_cau = km.yeu_cau, tien_giam = km.tien_giam }).ToList();
                dtgvKM.DataSource = cp;

                dtgvKM.Columns[0].HeaderText = "Mã khuyến mãi";
                dtgvKM.Columns[1].HeaderText = "Tên";
                dtgvKM.Columns[2].HeaderText = "Giá trị hóa đơn tối thiểu";
                dtgvKM.Columns[3].HeaderText = "Tiền giảm";
            }
        }

        private void ResetForm()
        {
            txtMaKM.Text = "";
            txtTienGiam.Text = "";
            txtTen.Text = "";
            txtToiThieu.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maKm = txtMaKM.Text;
                string tenKm = txtTen.Text;
                if (maKm == "" || tenKm == "")
                {
                    throw new Exception("Khuyến mãi không hợp lệ");
                }
                int toiThieu = Convert.ToInt32(txtToiThieu.Text);
                int tienGiam = Convert.ToInt32(txtTienGiam.Text);

                using (NhaHangEntities db = new NhaHangEntities())
                {
                    KhuyenMai km = new KhuyenMai() { ma_km = maKm, ten_km = tenKm, yeu_cau = toiThieu, tien_giam = tienGiam };
                    db.KhuyenMais.Add(km);
                    db.SaveChanges();
                }
                HienThi();
                ResetForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maKm = txtMaKM.Text;
                string tenKm = txtTen.Text;
                if (maKm == "" || tenKm == "")
                {
                    throw new Exception("Khuyến mãi không hợp lệ");
                }
                int toiThieu = Convert.ToInt32(txtToiThieu.Text);
                int tienGiam = Convert.ToInt32(txtTienGiam.Text);

                using (NhaHangEntities db = new NhaHangEntities())
                {
                    KhuyenMai kf = db.KhuyenMais.Where(k => k.ma_km == maKm).FirstOrDefault();
                    if (kf == null)
                    {
                        throw new Exception("Mã khuyến mãi này không tồn tại!");
                    }
                    kf.ten_km = tenKm;
                    kf.yeu_cau = toiThieu;
                    kf.tien_giam = tienGiam;
                    db.SaveChanges();
                }
                HienThi();
                ResetForm();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKm = txtMaKM.Text;

                using (NhaHangEntities db = new NhaHangEntities())
                {
                    KhuyenMai kf = db.KhuyenMais.Where(k => k.ma_km == maKm).FirstOrDefault();
                    if (kf == null)
                    {
                        throw new Exception("Mã khuyến mãi này không tồn tại!");
                    }
                    db.KhuyenMais.Remove(kf);
                    db.SaveChanges();
                }
                HienThi();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            try
            {
                txtMaKM.Text = dtgvKM.Rows[idx].Cells[0].Value.ToString();
                txtTen.Text = dtgvKM.Rows[idx].Cells[1].Value.ToString();
                txtToiThieu.Text = dtgvKM.Rows[idx].Cells[2].Value.ToString();
                txtTienGiam.Text = dtgvKM.Rows[idx].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

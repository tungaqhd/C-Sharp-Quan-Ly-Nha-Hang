using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Quan_Ly_Nha_Hang
{
    public partial class QuanLySanPham : Form
    {
        int selectedRow = 0;
        MemoryStream ms;
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        private void updateData()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var dsSp = (from s in db.SanPhams
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
                dtgvSanPham.DataSource = dsSp;
            }
        }

        private void resetForm()
        {

            tbxMa.Text = "";

            tbxTen.Text = "";

            tbxMoTa.Text = "";

            tbxSoLuong.Text = "";

            tbxDonGia.Text = "";

            ptbPreview.Image = null;
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            updateData();

            dtgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvSanPham.Columns[2].HeaderText = "Mô tả";
            dtgvSanPham.Columns[3].HeaderText = "Số lượng";
            dtgvSanPham.Columns[4].HeaderText = "Đơn giá";
            dtgvSanPham.Columns[5].HeaderText = "Loại";
            dtgvSanPham.Columns[6].HeaderText = "Ảnh";

            cbxLoai.Text = "Đồ ăn";

            ((DataGridViewImageColumn)dtgvSanPham.Columns[6]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = tbxTen.Text;
            string moTa = tbxMoTa.Text;
            int soLuong = Convert.ToInt32(tbxSoLuong.Text);
            int donGia = Convert.ToInt32(tbxDonGia.Text);
            string loai = cbxLoai.Text;

            using (NhaHangEntities db = new NhaHangEntities())
            {
                db.SanPhams.Add(new SanPham() { ten_sp = ten, mo_ta = moTa, so_luong = soLuong, don_gia = donGia, loai = loai });
                db.SaveChanges();
            }

            updateData();
        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            tbxMa.Enabled = false;
            tbxMa.Text = dtgvSanPham.Rows[selectedRow].Cells[0].Value.ToString();

            tbxTen.Text = dtgvSanPham.Rows[selectedRow].Cells[1].Value.ToString();

            tbxMoTa.Text = dtgvSanPham.Rows[selectedRow].Cells[2].Value.ToString();

            tbxSoLuong.Text = dtgvSanPham.Rows[selectedRow].Cells[3].Value.ToString();

            tbxDonGia.Text = dtgvSanPham.Rows[selectedRow].Cells[4].Value.ToString();

            cbxLoai.Text = dtgvSanPham.Rows[selectedRow].Cells[5].Value.ToString();

            if (dtgvSanPham.Rows[selectedRow].Cells[6].Value == null)
            {
                ptbPreview.Image = null;
            }
            else
            {
                ptbPreview.Image = ConvertBinaryToImage((byte[])dtgvSanPham.Rows[selectedRow].Cells[6].Value);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        byte[] ConvertImageToBinary(Image img)
        {
            try
            {
                ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        Image ConvertBinaryToImage(byte[] data)
        {
            ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int maSp;
            try
            {
                maSp = Convert.ToInt32(tbxMa.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (NhaHangEntities db = new NhaHangEntities())
            {
                SanPham sp = db.SanPhams.Find(maSp);

                sp.ten_sp = tbxTen.Text;
                sp.mo_ta = tbxMoTa.Text;
                sp.so_luong = Convert.ToInt32(tbxSoLuong.Text);
                sp.don_gia = Convert.ToInt32(tbxDonGia.Text);
                sp.loai = cbxLoai.Text;

                if (ptbPreview.Image != null)
                {
                    sp.anh = ConvertImageToBinary(ptbPreview.Image);
                }

                db.SaveChanges();
            }

            updateData();
            resetForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSp = Convert.ToInt32(tbxMa.Text);
            using (NhaHangEntities db = new NhaHangEntities())
            {
                SanPham sp = db.SanPhams.Find(maSp);
                db.SanPhams.Remove(sp);
                db.SaveChanges();
            }

            updateData();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                ptbPreview.Image = new Bitmap(open.FileName);
            }

        }
    }
}

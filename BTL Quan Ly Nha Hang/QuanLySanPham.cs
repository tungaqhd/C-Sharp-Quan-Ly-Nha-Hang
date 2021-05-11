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
    public partial class QuanLySanPham : Form
    {
        NhaHangEntities db = new NhaHangEntities();
        int selectedRow = 0;
        public QuanLySanPham()
        {
            InitializeComponent();
        }

        private void addBinding()
        {
            //tbxMa.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "ma_sp"));
            //tbxTen.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "ten_sp"));
            //tbxMoTa.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "mo_ta"));
            //tbxDonGia.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "don_gia"));
            //tbxSoLuong.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "so_luong"));
        }
        private void updateData()
        {
            List<SanPham> dsSp = db.SanPhams.ToList();
            foreach (SanPham sp in dsSp)
            {
                sp.ChiTietHoaDons = null;
            }
            dtgvSanPham.DataSource = dsSp;
        }

        private void resetForm()
        {

            tbxMa.Text = "";

            tbxTen.Text = "";

            tbxMoTa.Text = "";

            tbxSoLuong.Text = "";

            tbxDonGia.Text = "";
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

            cbxLoai.Text = "Đồ ăn";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = tbxTen.Text;
            string moTa = tbxMoTa.Text;
            int soLuong = Convert.ToInt32(tbxSoLuong.Text);
            int donGia = Convert.ToInt32(tbxDonGia.Text);
            string loai = cbxLoai.Text;

            db.SanPhams.Add(new SanPham() { ten_sp = ten, mo_ta = moTa, so_luong = soLuong, don_gia = donGia, loai = loai });
            db.SaveChanges();

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

            string loai = dtgvSanPham.Rows[selectedRow].Cells[5].Value.ToString();
            cbxLoai.Text = loai;   
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int maSp = Convert.ToInt32(tbxMa.Text);
            SanPham sp = db.SanPhams.Find(maSp);

            sp.ten_sp = tbxTen.Text;
            sp.mo_ta = tbxMoTa.Text;
            sp.so_luong = Convert.ToInt32(tbxSoLuong.Text);
            sp.don_gia = Convert.ToInt32(tbxDonGia.Text);
            sp.loai = cbxLoai.Text;

            db.SaveChanges();

            updateData();
            resetForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maSp = Convert.ToInt32(tbxMa.Text);
            SanPham sp = db.SanPhams.Find(maSp);
            db.SanPhams.Remove(sp);
            db.SaveChanges();

            updateData();
        }
    }
}

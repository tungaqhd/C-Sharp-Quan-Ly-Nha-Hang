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
    public partial class QuanLyThongTinNhanVien : Form
    {
        public QuanLyThongTinNhanVien()
        {
            InitializeComponent();
        }
        NhaHangEntities db = new NhaHangEntities();
        int selectedRow = 0;
        #region methods
        //void addBinding()
        //{
        //    txtManv.DataBindings.Add(new Binding("Text", dataGridView1, "ma_nv"));
        //    txtTennv.DataBindings.Add(new Binding("Text", dataGridView1, "ten_nv"));
        //    txtUsername.DataBindings.Add(new Binding("Text", dataGridView1, "username"));
        //    txtPassword.DataBindings.Add(new Binding("Text", dataGridView1, "password"));
        //    dateTimePicker1.DataBindings.Add(new Binding("Text", dataGridView1, "ngay_sinh"));
        //    txtChucvu.DataBindings.Add(new Binding("Text", dataGridView1, "chuc_vu"));
        //}
        //void LoadData()
        //{
        //    dataGridView1.DataSource = db.NhanViens.ToList();
        //}

        void themNhanVien()
        {
            string tennv = txtTennv.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            DateTime ngaysinh = dateTimePicker1.Value;
            string chucvu = cbxChucVu.SelectedValue.ToString();
            db.NhanViens.Add(new NhanVien() { ten_nv = tennv, username = Username, password = Password, ngay_sinh = ngaysinh, chuc_vu = chucvu });
            db.SaveChanges();
        }



        void xoaNhanVien()
        {
            int manv = Convert.ToInt32(txtManv.Text);
            NhanVien nv = db.NhanViens.Find(manv);
            db.NhanViens.Remove(nv);
            db.SaveChanges();
        }

        void suaNhanVien()
        {
            int manv = Convert.ToInt32(txtManv.Text);
            NhanVien nv = db.NhanViens.Find(manv);
            nv.ten_nv = txtTennv.Text;
            nv.username = txtUsername.Text;
            nv.password = txtPassword.Text;
            nv.ngay_sinh = dateTimePicker1.Value;
            nv.chuc_vu = cbxChucVu.SelectedValue.ToString();
            db.SaveChanges();
        }
        private void QuanLyThongTinNhanVien_Load(object sender, EventArgs e)
        {
            txtManv.Enabled = false;
            updateData();
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Username";
            dataGridView1.Columns[3].HeaderText = "Password";
            dataGridView1.Columns[4].HeaderText = "Ngày sinh";
            dataGridView1.Columns[5].HeaderText = "Chức vụ";

            IDictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("Nhân viên", "nhanvien");
            comboSource.Add("Quản lý", "quanly");

            cbxChucVu.DataSource = new BindingSource(comboSource, null);
            cbxChucVu.DisplayMember = "Key";
            cbxChucVu.ValueMember = "Value";
        }

        private void updateData()
        {
            List<NhanVien> dsNV = db.NhanViens.ToList();
            for(int i= 0;i < dsNV.Count;++i)
            {
                dsNV[i].HoaDons = null;
            }
            dataGridView1.DataSource = dsNV;
        }

        private void resetForm()
        {
            txtManv.Text = "";

            txtTennv.Text = "";

            txtUsername.Text = "";

            txtPassword.Text = "";
        }
        #endregion
        #region Events

        private void btnThem_Click(object sender, EventArgs e)
        {
            themNhanVien();
            resetForm();
            updateData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            suaNhanVien();
            resetForm();
            updateData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xoaNhanVien();
            resetForm();
            updateData();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            txtManv.Enabled = false;
            txtManv.Text = dataGridView1.Rows[selectedRow].Cells[0].Value.ToString();
            txtTennv.Text = dataGridView1.Rows[selectedRow].Cells[1].Value.ToString();
            txtUsername.Text = dataGridView1.Rows[selectedRow].Cells[2].Value.ToString();
            txtPassword.Text = dataGridView1.Rows[selectedRow].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[selectedRow].Cells[4].Value.ToString();
            cbxChucVu.SelectedValue = dataGridView1.Rows[selectedRow].Cells[5].Value.ToString();
        }

        #endregion

      
    }
}

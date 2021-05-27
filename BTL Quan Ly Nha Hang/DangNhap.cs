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
    public partial class DangNhap : Form
    {
        NhaHangEntities db = new NhaHangEntities();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text;
            string password = tbxPassword.Text;

            var user = db.NhanViens.Where(u => u.username == username && u.password == password).FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                if(user.chuc_vu == "quanly")
                {
                    QuanLyPanel quanLyPanel = new QuanLyPanel();
                    quanLyPanel.nv = user;
                    quanLyPanel.Closed += (s, args) => this.Close();
                    quanLyPanel.Show();
                }
                else
                {
                    NhanVienPanel nhanVienPanel = new NhanVienPanel();
                    nhanVienPanel.nv = user;
                    nhanVienPanel.Closed += (s, args) => this.Close(); 
                    nhanVienPanel.Show();
                }
            }    
        }
    }
}

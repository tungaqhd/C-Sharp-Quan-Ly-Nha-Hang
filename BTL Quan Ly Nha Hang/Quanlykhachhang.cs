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
    }
}

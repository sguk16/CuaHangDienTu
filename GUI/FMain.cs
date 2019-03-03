using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace GUI
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            LoadKH();
        }
        private void LoadKH()
        {
            List<KhachHang> list= KhachHangBUS.ListKH();
            dgvKhachHang.DataSource = KhachHangBUS.ListKH();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FKhachHang fKhachHang = new FKhachHang();
            fKhachHang.ShowDialog();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FSanPham fSanPham = new FSanPham();
            fSanPham.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FHoaDon fHoaDon = new FHoaDon();
            fHoaDon.ShowDialog();
        }
    }
}

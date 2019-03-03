namespace GUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using BUS;
    using DTO;

    public partial class FMain : Form
    {
        private const int tabKH = 0;
        private const int tabTB = 1;
        private const int tabHD = 2;
        public FMain()
        {
            InitializeComponent();
            LoadKhachHang();
        }
        private void LoadKhachHang()
        {
            List<KhachHang> list = KhachHangBUS.ListKH();
            if(list.Count > 0)
            {
                dgvKhachHang.DataSource = list;
                dgvKhachHang.Columns[0].Visible = false;
                dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
                dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
                dgvKhachHang.Columns[3].HeaderText = "Số điện thoại";
            }
            else
            {
                dgvKhachHang.DataSource = null;
            }
            
        }
        private void LoadThietBi()
        {
            List<ThietBi> list = ThietBiBUS.ListTB();
            if(list.Count > 0)
            {
                dgvSanPham.DataSource = list;
                dgvSanPham.Columns[0].Visible = false;
                dgvSanPham.Columns[1].HeaderText = "Tên thiết bị";
                dgvSanPham.Columns[2].HeaderText = "Số Lượng";
                dgvSanPham.Columns[3].HeaderText = "Giá";
                dgvSanPham.Columns[4].HeaderText = "Loại";
            }
            else
            {
                dgvSanPham.DataSource = null;
            }
        }
        private void LoadHoaDon()
        {
            List<HoaDon> list = HoaDonBUS.ListHD();
            if (list.Count > 0)
            {
                dgvHoaDon.DataSource = list;
                dgvHoaDon.Columns[0].Visible = false;
                dgvHoaDon.Columns[1].HeaderText = "Khách hàng";
                dgvHoaDon.Columns[2].HeaderText = "Ngày lập";
                dgvHoaDon.Columns[3].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns[4].HeaderText = "Địa chỉ giao";
                dgvHoaDon.Columns[5].Visible = false;
                dgvHoaDon.Columns[6].HeaderText = "Trạng thái";
            }
            else
            {
                dgvHoaDon.DataSource = null;
                lblKH.Text = String.Empty;
                lblMaHD.Text = String.Empty;
                lblNgay.Text = String.Empty;
                lblStt.Text = String.Empty;
                lblDiaChi.Text = String.Empty;
                lblTien.Text = String.Empty;
            }
        }


        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FKhachHang fKhachHang = new FKhachHang();
            fKhachHang.ShowDialog();
            LoadKhachHang();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FSanPham fSanPham = new FSanPham();
            fSanPham.ShowDialog();
            LoadThietBi();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FHoaDon fHoaDon = new FHoaDon();
            fHoaDon.ShowDialog();
            LoadHoaDon();
        }

        private void tctMain_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case tabKH: LoadKhachHang(); break;
                case tabTB: LoadThietBi(); break;
                case tabHD: LoadHoaDon(); break;
            }
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                int index = dgvHoaDon.CurrentRow.Index;
                HoaDon hoadon = (dgvHoaDon.DataSource as List<HoaDon>)[index];
                lblMaHD.Text = hoadon.Mahd;
                lblKH.Text = hoadon.Makh.ToString();
                lblNgay.Text = hoadon.Ngaylap.ToShortDateString();
                lblDiaChi.Text = hoadon.Diachigiao;
                lblStt.Text = hoadon.TrangThai;
                lblTien.Text = hoadon.Thanhtien.ToString("#,0");
                dgvCTHD.DataSource = CTHDBUS.GetCTHD(hoadon.Mahd);
                dgvCTHD.Columns[0].Visible = false;
                dgvCTHD.Columns[1].HeaderText = "Thiết bị";
                dgvCTHD.Columns[2].HeaderText = "Số lượng";
            }
        }
    }
}

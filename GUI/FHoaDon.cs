namespace GUI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using BUS;
    using DTO;

    public partial class FHoaDon : Form
    {
        private static List<PCTHD> pnlCTHD;
        public FHoaDon()
        {
            InitializeComponent();
            pnlCTHD = new List<PCTHD>();
            //LoadThietBi();
            LoadLoai();
            LoadKhachHang();
            lblNgay.Text = DateTime.Now.ToShortDateString();
        }
        private void LoadThietBi()
        {
            List<ThietBi> list = ThietBiBUS.ListTB();
            if (list.Count > 0)
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
        private void LoadKhachHang()
        {
            List<KhachHang> list = KhachHangBUS.ListKH();
            if (list.Count > 0)
            {
                cbbKH.DataSource = list;
                cbbKH.DisplayMember = "Tenkh";
                cbbKH.SelectedIndex = -1;
                txbDiaChi.Text = String.Empty;
            }
        }
        private void LoadLoai()
        {
            String[] list = ThietBiBUS.Loaitb();
            cbbLoai.DataSource = list;
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            FKhachHang fKhachHang = new FKhachHang();
            fKhachHang.ShowDialog();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ThietBi thietBi = (dgvSanPham.DataSource as List<ThietBi>)[e.RowIndex];
            if (KiemTraTB(thietBi))
            {
                pnlCTHD.Add(new PCTHD(thietBi));
                SumPrice_ValueChanged(null, new EventArgs());
                flpHoaDon.Controls.Add(pnlCTHD[pnlCTHD.Count - 1]);
            }
        }
        private static int Sum()
        {
            int sum = 0;
            foreach (PCTHD item in pnlCTHD)
                sum += (item.ThietBi.Dongia * item.Soluong);
            return sum;
        }
        public static void SumPrice_ValueChanged(object sender, EventArgs e)
        {
            lblSum.Text = Sum().ToString("#,0");
        }
        private bool KiemTraTB(ThietBi thietBi)
        {
            foreach (PCTHD item in pnlCTHD)
                if (item.ThietBi.Matb == thietBi.Matb) return false;
            return true;
        }

        private void flpHoaDon_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnlCTHD.Remove(e.Control as PCTHD);
            SumPrice_ValueChanged(null, new EventArgs());
        }

        private void lblSum_TextChanged(object sender, EventArgs e)
        {
            lblConLai.Text = (Sum() * (100 - (int)nudSale.Value) / 100).ToString("#,0");
        }

        private void nudSale_ValueChanged(object sender, EventArgs e)
        {
            lblConLai.Text = (Sum() * (100 - (int)nudSale.Value) / 100).ToString("#,0");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                return;
            }
            HoaDon hoaDon = new HoaDon(
                String.Empty,
                DateTime.Now,
                cbbKH.SelectedValue as KhachHang,
                txbDiaChi.Text,
                Sum() * (100 - (int)nudSale.Value) / 100,
                0
            );
            List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();
            foreach (PCTHD chitiet in pnlCTHD)
                chiTietHoaDons.Add(chitiet.CTHD);
            if (HoaDonBUS.AddHoaDon(hoaDon, chiTietHoaDons) == 0) MessageBox.Show("Lưu không thành công.", "Thông báo");
            else this.Close();
        }
        private bool CheckInput()
        {
            if (cbbKH.SelectedValue == null) return false;
            if (txbDiaChi.Text == String.Empty) return false;
            if (pnlCTHD.Count == 0) return false;
            return true;
        }

        private void cbbKH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbKH.SelectedValue != null)
            {
                KhachHang khachHang = cbbKH.SelectedValue as KhachHang;
                lblSDT.Text = khachHang.Sdt;
                txbDiaChi.Text = khachHang.Diachi;
            }
        }

        private void btnThemKH_Click_1(object sender, EventArgs e)
        {
            FKhachHang khachHang = new FKhachHang();
            khachHang.ShowDialog();
            LoadKhachHang();
        }

        private void cbbLoai_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbLoai.SelectedValue != null)
            {
                dgvSanPham.DataSource = ThietBiBUS.GetThietBiTheoLoai(cbbLoai.SelectedValue as String);
                dgvSanPham.Columns[0].Visible = false;
                dgvSanPham.Columns[1].HeaderText = "Tên thiết bị";
                dgvSanPham.Columns[2].HeaderText = "Số Lượng";
                dgvSanPham.Columns[3].HeaderText = "Giá";
                dgvSanPham.Columns[4].HeaderText = "Loại";
            }
        }
    }
}

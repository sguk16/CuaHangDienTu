namespace GUI
{
    using System;
    using System.Windows.Forms;
    using BUS;
    using DTO;
    public partial class FSanPham : Form
    {
        public FSanPham()
        {
            InitializeComponent();
        }

        private void txbTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)8 || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
            if (e.KeyChar == (char)13)
                btnLuu.PerformClick();
        }

        private void txbGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
                e.Handled = false;
            else e.Handled = true;
            if (e.KeyChar == (char)13)
                btnLuu.PerformClick();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin rỗng
            if (!CheckEmpty()) { MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo"); return; }
            // Thực hiện thêm thiết bị
            ThietBi tbMoi = new ThietBi(String.Empty, txbTen.Text, txbLoai.Text, Int32.Parse(txbSoLuong.Text), Int32.Parse(txbGia.Text));
            if (ThietBiBUS.AddThietBi(tbMoi) > 0) this.Close();
            else MessageBox.Show("Lưu không thành công.", "Thông báo");
        }
        private bool CheckEmpty()
        {
            if (txbTen.Text == String.Empty) return false;
            if (txbGia.Text == String.Empty) return false;
            if (txbSoLuong.Text == String.Empty) return false;
            if (txbLoai.Text == String.Empty) return false;
            return true;
        }
    }
}

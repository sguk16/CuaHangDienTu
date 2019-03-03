namespace GUI
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using BUS;
    using DTO;

    public partial class FKhachHang : Form
    {
        private const string pPhone = @"^0[35789]\d{8}$";
        public FKhachHang()
        {
            InitializeComponent();
        }

        private void txbSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
                e.Handled = false;
            else e.Handled = true;
            if (e.KeyChar == (char)13)
                btnLuu.PerformClick();
        }

        private void txbTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)8 || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
            if (e.KeyChar == (char)13)
                btnLuu.PerformClick();
        }

        private void txbDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnLuu.PerformClick();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng thì thông báo cho người dùng
            if (!CheckEmpty()) { MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo"); return; }
            // Kiểm tra số điện thoại hợp lệ
            if (!CheckPhone(txbSoDienThoai.Text)) { MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo"); return; }
            // Thực hiện thêm thông tin
            KhachHang khMoi = new KhachHang(String.Empty, txbTen.Text, txbDiaChi.Text, txbSoDienThoai.Text);
            if (KhachHangBUS.AddKhachHang(khMoi) > 0)
                this.Close();
            else
                MessageBox.Show("Lưu không thành công.", "Thông báo");
        }
        private bool CheckEmpty()
        {
            if (txbTen.Text == String.Empty) return false;
            if (txbDiaChi.Text == String.Empty) return false;
            if (txbSoDienThoai.Text == String.Empty) return false;
            return true;
        }
        private bool CheckPhone(String sdt)
        {
            Regex pattern = new Regex(pPhone, RegexOptions.IgnoreCase);
            return pattern.Match(sdt).Success;
        }
    }
}

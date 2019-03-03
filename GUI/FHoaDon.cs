namespace GUI
{
    using System;
    using System.Windows.Forms;

    public partial class FHoaDon : Form
    {
        public FHoaDon()
        {
            InitializeComponent();
        }

        private void txbTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)8 || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
            if (e.KeyChar == (char)13)
                btnTim.PerformClick();
        }
    }
}

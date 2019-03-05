using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public class PCTHD : Panel
    {
        private ThietBi thietBi;
        private Label lbl1;
        private Label lblThietBi;
        private Label lbl2;
        private NumericUpDown nudSoLuong;
        private Label lbl3;
        private Label lblGia;
        private Button btnDelete;

        public ThietBi ThietBi { get => thietBi; }
        public ChiTietHoaDon CTHD { get => new ChiTietHoaDon(String.Empty, thietBi, (int)nudSoLuong.Value); }
        public int Soluong
        {
            get => (int)nudSoLuong.Value;
        }

        public PCTHD(ThietBi thietBi)
        {
            this.thietBi = thietBi;
            InitPCTHD();
            lblGia.Text = thietBi.Dongia.ToString("#,0");
        }
        private void InitPCTHD()
        {
            lbl1 = new Label();
            lblThietBi = new Label();
            lbl2 = new Label();
            nudSoLuong = new NumericUpDown();
            lbl3 = new Label();
            lblGia = new Label();
            btnDelete = new Button();
            // 
            // PCTHD
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.lblThietBi);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.btnDelete);
            this.Location = new System.Drawing.Point(3, 3);
            this.Size = new System.Drawing.Size(340, 100);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(3, 5);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(128, 23);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Thiết bị:";
            // 
            // lblThietBi
            // 
            this.lblThietBi.AutoSize = true;
            this.lblThietBi.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThietBi.Location = new System.Drawing.Point(105, 5);
            this.lblThietBi.Name = "lblThietBi";
            this.lblThietBi.Size = new System.Drawing.Size(128, 23);
            this.lblThietBi.TabIndex = 0;
            this.lblThietBi.Text = "<Tên thiết bị>";
            //
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(3, 36);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(86, 23);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Số lượng:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.AutoSize = true;
            this.nudSoLuong.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(105, 36);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            thietBi.SL,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(140, 31);
            this.nudSoLuong.TabIndex = 0;
            this.nudSoLuong.Text = "1";
            this.nudSoLuong.ValueChanged += new EventHandler(FHoaDon.SumPrice_ValueChanged);
            this.nudSoLuong.KeyPress += new KeyPressEventHandler(nudSoLuong_KeyPress);
            //
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(3, 77);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(89, 23);
            this.lbl3.TabIndex = 0;
            this.lbl3.Text = "Đơn giá:";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.Location = new System.Drawing.Point(105, 77);
            this.lblGia.Name = "nudSoLuong";
            this.lblGia.Size = new System.Drawing.Size(140, 23);
            this.lblGia.TabIndex = 0;
            this.lblGia.Text = "0";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Location = new System.Drawing.Point(300, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "x";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void nudSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
                e.Handled = false;
            else e.Handled = true;
        }
    }
}

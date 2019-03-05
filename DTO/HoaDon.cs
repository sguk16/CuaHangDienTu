namespace DTO
{
    using System;

    public class HoaDon
    {
        private String mahd,diachigiao;
        KhachHang makh;
        DateTime ngaylap;
        private int thanhtien,giaohang;
        public string ToSQLString()
        {
            DateTime time = DateTime.Now;
            String format = "yyyy-MM-dd HH:mm:ss";
            return $"dbo.AUTO_IDHD(),'{makh.Makh}','{ngaylap.ToString(format)}',{thanhtien},N'{diachigiao}',{giaohang}";
        }
        public string Mahd { get => mahd; set => mahd = value; }
        public KhachHang Makh { get => makh; set => makh = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public string Diachigiao { get => diachigiao; set => diachigiao = value; }
        public int Thanhtien { get => thanhtien; set => thanhtien = value; }
        public int Giaohang { get => giaohang; set => giaohang = value; }
        public String TrangThai
        {
            get => giaohang == 1 ? "Đã giao" : "Chưa giao";
        }
        
        public HoaDon(String mahd, DateTime ngaylap, KhachHang makh, String diachigiao, int thanhtien,int giaohang)
        {
            this.mahd = mahd;
            this.ngaylap = ngaylap;
            this.makh = makh;
            this.diachigiao = diachigiao;
            this.thanhtien = thanhtien;
            this.giaohang = giaohang;
        }
        public HoaDon(String[] data)
        {
            this.mahd = data[0];
            this.ngaylap = DateTime.Parse(data[1]);
            this.thanhtien = Int32.Parse(data[2]);
            this.diachigiao = data[3];
            this.giaohang = data[4] == "True" ? 1 : 0;
            makh = new KhachHang(new string[] {data[5],data[6], data[7], data[8]});
        }
    }
}

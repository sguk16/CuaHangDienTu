namespace DTO
{
    using System;

    public class ChiTietHoaDon
    {
        private String mahd;
        ThietBi matb;
        private int soluong;
        public override string ToString()
        {
            return $"'{mahd}','{matb.Matb}',{soluong}";
        }
        public string Mahd { get => mahd; set => mahd = value; }
        public ThietBi Matb { get => matb; set => matb = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public ChiTietHoaDon(String mahd, ThietBi matb, int soluong)
        {
            this.mahd = mahd;
            this.matb = matb;
            this.soluong = soluong;
        }
        public ChiTietHoaDon(String[] data)
        {
            this.mahd = data[0];
            this.soluong = int.Parse(data[1]);
            this.matb = new ThietBi(new string[] { data[2], data[3], data[6], data[5], data[4] });
        }
    }
}

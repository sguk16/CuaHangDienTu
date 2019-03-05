namespace DTO
{
    using System;

    public class ThietBi
    {
        private String matb, tentb,loaitb;
        private int sl, dongia;
        public string ToSQLString()
        {
            return $"dbo.AUTO_IDTB(),N'{tentb}',{dongia},{sl},N'{loaitb}'";
        }
        public override string ToString()
        {
            return tentb;
        }
        public ThietBi(string matb, string tentb, string loaitb, int sl, int dongia)
        {
            this.matb = matb;
            this.tentb = tentb;
            this.loaitb = loaitb;
            this.sl = sl;
            this.dongia = dongia;
        }
        public ThietBi(String[] data)
        {
            this.matb = data[0];
            this.tentb = data[1];
            this.dongia = Int32.Parse(data[2]);
            this.sl = Int32.Parse(data[3]);
            this.loaitb = data[4];
        }

        public string Matb { get => matb; set => matb = value; }
        public string Tentb { get => tentb; set => tentb = value; }
        public int SL { get => sl; set => sl = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public string Loaitb { get => loaitb; set => loaitb = value; }
    }
}

namespace BUS
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using DAO;

    public class CTHDBUS
    {
        public static List<ChiTietHoaDon> ListCTHD()
        {
            return CTHDDAO.GetAllCTHD();
        }
        public static List<ChiTietHoaDon> GetCTHD(String mahd)
        {
            return CTHDDAO.GetCTHD(mahd);
        }
        public static int AddCTHD(ChiTietHoaDon cthd)
        {
            return CTHDDAO.AddCTHD(cthd);
        }
        public static int EditCTHD(ChiTietHoaDon cthd)
        {
            return CTHDDAO.EditCTHD(cthd);
        }
    }
}

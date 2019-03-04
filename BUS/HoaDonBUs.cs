namespace BUS
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using DAO;

    public class HoaDonBUS
    {
        public static List<HoaDon> ListHD()
        {
            return HoaDonDAO.GetAllHoaDon();
        }
        public static HoaDon GetHoaDon(String id)
        {
            return HoaDonDAO.GetHoaDon(id);
        }
        public static int AddHoaDon(HoaDon hd,List<ChiTietHoaDon> cthd)
        {
            return HoaDonDAO.AddHoaDon(hd,cthd);
        }
        public static int EditHoaDon(HoaDon hd)
        {
            return HoaDonDAO.EditHoaDon(hd);
        }
    }
}

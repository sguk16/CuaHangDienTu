namespace BUS
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using DAO;

    public class KhachHangBUS
    {
        public static List<KhachHang> ListKH()
        {
            return KhachHangDAO.GetAllKhachHang();
        }
        public static List<KhachHang> GetNameKhachhang(string name)
        {
            return KhachHangDAO.GetNameKhachhang(name);
        }
        public static KhachHang GetKhachHang(String id)
        {
            return new KhachHang(ExecuteQuery.getOne(id, "KhachHang"));
        }
        public static int AddKhachHang(KhachHang kh)
        {
            return KhachHangDAO.AddKhachHang(kh);
        }
        public static int EditKhachHang(KhachHang kh)
        {
            return KhachHangDAO.EditKhachHang(kh);
        }
    }
}

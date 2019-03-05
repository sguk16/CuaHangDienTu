namespace BUS
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using DAO;

    public class ThietBiBUS
    {
        public static List<ThietBi> ListTB()
        {
            return ThietBiDAO.GetAllThietBi();
        }
        public static ThietBi GetThietBi(String id)
        {
            return ThietBiDAO.GetThietBi(id);
        }
        public static List<ThietBi> GetThietBiTheoLoai(String loai)
        {
            return ThietBiDAO.GetThietBiTheoLoai(loai);
        }
        public static String[] Loaitb()
        {
            return ThietBiDAO.LoaiTB();
        }
        public static int AddThietBi(ThietBi tb)
        {
            return ThietBiDAO.AddThietBi(tb);
        }
        public static int EditThietBi(ThietBi tb)
        {
            return ThietBiDAO.EditThietBi(tb);
        }
    }
}

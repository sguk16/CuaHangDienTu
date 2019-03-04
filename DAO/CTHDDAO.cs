namespace DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DTO;

    public class CTHDDAO
    {
        public static List<ChiTietHoaDon> GetAllCTHD()
        {
            List<ChiTietHoaDon> result = new List<ChiTietHoaDon>();
            List<String[]> data = ExecuteQuery.getAll("CTHoaDon");
            for(int i=0;i<data.Count();i++)
                result.Add(new ChiTietHoaDon(data[i]));
            return result;
        }
        //Get Danh sách ct hóa đơn theo mã hd
        public static List<ChiTietHoaDon> GetCTHD(String id)
        {
            List<ChiTietHoaDon> result = new List<ChiTietHoaDon>();
            List<String[]> data = ExecuteQuery.getAll("CTHoaDon WHERE id=\'" + id + "\'");
            for (int i = 0; i < data.Count(); i++)
                result.Add(new ChiTietHoaDon(data[i]));
            return result;
        }
        public static int AddCTHD(ChiTietHoaDon cthd)
        {
            return ExecuteQuery.AddRows(cthd.ToString(), "CTHoaDon");
        }
        public static int EditCTHD(ChiTietHoaDon cthd)
        {
            int result = 0;
            //sẽ thực hiện sau khi bàn bạc
            return result;
        }
        public static int DeleteThietBi(ChiTietHoaDon cthd)
        {
            return ExecuteQuery.DeleteRows(cthd.Mahd, "CTHoaDon");
        }
    }
}

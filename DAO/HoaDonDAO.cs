﻿namespace DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;
    using DTO;

    public class HoaDonDAO
    {
        public static List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> result = new List<HoaDon>();
            List<String[]> data = ExecuteQuery.getAll("HoaDon");
            for (int i = 0; i < data.Count(); i++)
                result.Add(new HoaDon(data[i]));
            return result;
        }
        public static HoaDon GetHoaDon(String id)
        {
            return new HoaDon(ExecuteQuery.getOne(id, "HoaDon"));
        }
        public static int AddHoaDon(HoaDon hd, List<ChiTietHoaDon> cthd)
        {
            int i = 0;
            Console.Out.Write(hd.ToSQLString());
            if (ExecuteQuery.AddRows(hd.ToSQLString(), "HoaDon") > 0)
                foreach (ChiTietHoaDon x in cthd)
                    i += CTHDDAO.AddCTHD(x);
            return i;

        }
        public static int EditHoaDon(HoaDon hd)
        {
            int result = 0;
            SqlConnection conn = GetConnect.GetDBConnection();
            conn.Open();
            String format = "yyyy-MM-dd HH:mm:ss";
            String sql = "UPDATE HoaDon \n" +
                "SET idkhachhang='" + hd.Makh + "',ngay=" + hd.Ngaylap.ToString(format) + ",tongtien=" + hd.Thanhtien + ",diachigiao='" + hd.Diachigiao + "',giaohang=" + hd.Giaohang + "\n" +
                "WHERE id='" + hd.Mahd + "'";
            Console.WriteLine(sql);
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static int DeleteHoaDon(HoaDon hd)
        {
            return ExecuteQuery.DeleteRows(hd.Mahd, "HoaDon");
        }
    }
}

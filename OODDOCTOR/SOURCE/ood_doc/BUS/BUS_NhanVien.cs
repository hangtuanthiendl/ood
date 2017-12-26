using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public void ThemNhanVien(string TENNV, string NGAYSINH, Boolean GTINH, String DIACHI,
            int SDT, string CHUCVU, int enabled, int role, string temppassword)
        {
            db.ThemNhanVien(TENNV, NGAYSINH,  GTINH, DIACHI,SDT, CHUCVU, enabled, role, temppassword);
        }
        public void XoaNhanVien(int a)
        {
            db.XoaNhanVien(a);
        }

        public List<DTO_Profile> DanhSachNhanVien()
        {
            return db.DanhSachNhanVien();
        }
    }
}

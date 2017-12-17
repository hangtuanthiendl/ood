using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public void ThemNhanVien()
        {
            db.ThemNhanVien();
        }

        public List<DTO_Profile> DanhSachNhanVien()
        {
            return db.DanhSachNhanVien();
        }
    }
}

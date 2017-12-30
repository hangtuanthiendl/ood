using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_DichVu
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public List<DTO_DichVu> DanhSachDichvu()
        {
            return db.DanhSachDichvu();
        }
        public void ThemDichVu(string _TENDV1, long _MANV1, double _GIADV1)
        {
            db.ThemDichVu(_TENDV1, _MANV1, _GIADV1);
        }
        public void XoaDichVu(int a)
        {
            db.XoaDichVu(a);
        }

        public void SuaDichVu(long _MADV, string _TENDV1, long _MANV1, double _GIADV1)
        {
            db.SuaDichVu(_MADV, _TENDV1, _MANV1, _GIADV1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_Thuoc
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public List<DTO_Thuoc> DanhSachThuoc()
        {
            return db.DanhSachThuoc();
        }
        public void SuaThuoc(long _MATHUOC, string _TENTHUOC, int _SOLUONGCON, double _GIA, long _MANV1)
        {
            db.SuaThuoc(_MATHUOC, _TENTHUOC, _SOLUONGCON, _GIA, _MANV1);
        }
        public void ThemThuoc(string _TENTHUOC, int _SOLUONGCON, double _GIA, long _MANV1)
        {
            db.ThemThuoc(_TENTHUOC, _SOLUONGCON, _GIA, _MANV1);
        }
        public void XoaThuoc(int a)
        {
            db.XoaThuoc(a);
        }
    }
}

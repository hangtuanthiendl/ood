using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_HDTK
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public DataTable ThongKeTienKham(string NGAY1, string NGAY2)
        {
            return db.ThongKeTienKham(NGAY1, NGAY2);
        }
        public DataTable DoanhThuTienKham(int YEAR)
        {
            return db.DoanhThuTienKham(YEAR);
        }
    }
}

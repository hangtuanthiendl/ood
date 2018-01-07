using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DONTHUOC
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public DataTable ThongKeTienThuoc(string NGAY1, string NGAY2)
        {
            return db.ThongKeTienThuoc(NGAY1, NGAY2);
        }
        public DataTable DoanhThuTienThuoc(int YEAR)
        {
            return db.DoanhThuTienThuoc(YEAR);
        }
    }
}

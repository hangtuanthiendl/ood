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
    }
}

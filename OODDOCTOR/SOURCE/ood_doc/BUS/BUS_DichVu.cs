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
    }
}

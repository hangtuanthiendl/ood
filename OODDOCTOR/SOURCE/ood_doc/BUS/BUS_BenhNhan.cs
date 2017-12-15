using DAL;
namespace BUS
{
    public class BUS_BenhNhan
    {
        DAL_dbConnect db = new DAL_dbConnect();
        public void ThemBenhNhan()
        {
            db.ThemBenhNhan();
        }
    }
}

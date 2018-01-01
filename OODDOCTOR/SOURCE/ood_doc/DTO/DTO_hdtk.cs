using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Hdtk
    {
        private long _MAHDTK;
        private long _MANV;
        private long _MAPKB;
        private DateTime _NGAYLAPDT;
        private double _THANHTIEN;

        public DTO_Hdtk(long MAHDTK, long MAPKB, long MANV, DateTime NGAYLAPDT, double THANHTIEN)
        {
            _MAHDTK = MAHDTK;
            _MAPKB = MAPKB;
            _MANV = MANV;
            _NGAYLAPDT = NGAYLAPDT;
            _THANHTIEN = THANHTIEN;
        }

        public long MAHDTK
        {
            get { return _MAHDTK; }
            set { _MAHDTK = value; }
        }
        public long MAPKB
        {
            get { return _MAPKB; }
            set { _MAPKB = value; }
        }
        public long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }
        public double THANHTIEN
        {
            get { return _THANHTIEN; }
            set { _THANHTIEN = value; }
        }

        public DateTime NGAYLAPDT
        {
            get { return _NGAYLAPDT; }
            set { _NGAYLAPDT = value; }
        }
    }
}

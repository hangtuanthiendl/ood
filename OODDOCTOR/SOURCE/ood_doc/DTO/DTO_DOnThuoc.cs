using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_DOnThuoc
    {
        private long _MADT;
        private DateTime _NGAYLAPDT;
        private double _THANHTIEN;
        private long _MAPKB;

        public long MAPKB
        {
            get { return _MAPKB; }
            set { _MAPKB = value; }
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

        public long MADT
        {
            get { return _MADT; }
            set { _MADT = value; }
        }

    }
}

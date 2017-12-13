using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_DonGiaDichVu
    {
        private long _MADV;
        private long _MANV;
        private double _GIADICHVU;

        public double GIADICHVU
        {
            get { return _GIADICHVU; }
            set { _GIADICHVU = value; }
        }

        public  long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

        public long MADV
        {
            get { return _MADV; }
            set { _MADV = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_CtDonThuoc
    {
        private long _MADT;
        private long _MATHUOC;
        private int _SOLUONG;
        private string _CACHDUNG;

        public string CACHDUNG
        {
            get { return _CACHDUNG; }
            set { _CACHDUNG = value; }
        }

        public int SOLUONG
        {
            get { return _SOLUONG; }
            set { _SOLUONG = value; }
        }

        public long MATHUOC
        {
            get { return _MATHUOC; }
            set { _MATHUOC = value; }
        }

        public long MADT
        {
            get { return _MADT; }
            set { _MADT = value; }
        }

    }
}

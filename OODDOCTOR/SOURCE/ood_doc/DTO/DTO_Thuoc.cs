using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_Thuoc
    {
        private long _MATHUOC;
        private string _TENTHUOC;
        private int _SOLUONGCON;

        public int SOLUONGCON
        {
            get { return _SOLUONGCON; }
            set { _SOLUONGCON = value; }
        }

        public string TENTHUOC
        {
            get { return _TENTHUOC; }
            set { _TENTHUOC = value; }
        }

        public long MATHUOC
        {
            get { return _MATHUOC; }
            set { _MATHUOC = value; }
        }

    }
}

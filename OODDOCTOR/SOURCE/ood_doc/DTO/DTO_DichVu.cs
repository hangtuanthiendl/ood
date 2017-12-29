using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_DichVu
    {
        private long _MADV;
        private string _TENDV;

        public string TENDV
        {
            get { return _TENDV; }
            set { _TENDV = value; }
        }

        public long MADV
        {
            get { return _MADV; }
            set { _MADV = value; }
        }

    }
}

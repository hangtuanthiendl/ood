using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DichVu
    {
        private long _MADV;
        private string _TENDV;
        private long _MANV;
        private double _GIADV;
        public DTO_DichVu( long _MADV1,string _TENDV1,long _MANV1,double _GIADV1)
        {
            this._MADV = _MADV1;
            this._TENDV = _TENDV1;
            this._MANV = _MANV1;
            this._GIADV = _GIADV1;
        }
        public double GIADV
        {
            get { return _GIADV; }
            set { _GIADV = value; }
        }

        public long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

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

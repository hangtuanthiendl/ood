using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Thuoc
    {
        private long _MATHUOC;
        private string _TENTHUOC;
        private int _SOLUONGCON;
        private double _DONGIA;
        private long _MANV;
        public DTO_Thuoc(long _MATHUOC,string _TENTHUOC,int _SOLUONGCON,double _DONGIA,long _MANV)
        {
            this._MATHUOC = _MATHUOC;
            this._TENTHUOC = _TENTHUOC;
            this._SOLUONGCON = _SOLUONGCON;
            this._DONGIA = _DONGIA;
            this._MANV = _MANV;
        }
        public long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

        public double DONGIA
        {
            get { return _DONGIA; }
            set { _DONGIA = value; }
        }

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

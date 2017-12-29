using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_Pkb
    {
        private long _MAPKB;
        private long _MABN;
        private long _MANV;
        private long _MABS;
        private string _TRCHUNG;
        private string _CDOAN;
        private DateTime _NGAYKHAM;
        private string _LICHHEN;
        private string _GCHU;

        public string GCHU
        {
            get { return _GCHU; }
            set { _GCHU = value; }
        }

        public string LICHHEN
        {
            get { return _LICHHEN; }
            set { _LICHHEN = value; }
        }


        public DateTime NGAYKHAM
        {
            get { return _NGAYKHAM; }
            set { _NGAYKHAM = value; }
        }


        public string CDOAN
        {
            get { return _CDOAN; }
            set { _CDOAN = value; }
        }

        public string TRCHUNG
        {
            get { return _TRCHUNG; }
            set { _TRCHUNG = value; }
        }

        public long MABS
        {
            get { return _MABS; }
            set { _MABS = value; }
        }

        public long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

        public long MABN
        {
            get { return _MABN; }
            set { _MABN = value; }
        }

        public long MAPKB
        {
            get { return _MAPKB; }
            set { _MAPKB = value; }
        }

    }
}

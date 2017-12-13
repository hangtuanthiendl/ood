using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_Profile
    {
        private long _MANV;
        private string _TENNV;
        private DateTime _NGAYSINH;
        private bool _GIOITINH;
        private string _DIACHI;
        private int _SDT;
        private string _CHUCVU;

        public  string CHUCVU
        {
            get { return _CHUCVU; }
            set { _CHUCVU = value; }
        }

        public int SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }

        public string DIACHI
        {
            get { return _DIACHI; }
            set { _DIACHI = value; }
        }

        public bool GIOITINH
        {
            get { return _GIOITINH; }
            set { _GIOITINH = value; }
        }


        public DateTime NGAYSINH
        {
            get { return _NGAYSINH; }
            set {_NGAYSINH = value; }
        }

        public string TENNV
        {
            get { return _TENNV; }
            set { _TENNV = value; }
        }

        public long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

    }
}

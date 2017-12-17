using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Profile
    {
        private long _MANV;
        private string _TENNV;
        private DateTime _NGAYSINH;
        private bool _GIOITINH;
        private string _DIACHI;
        private int _SDT;
        private string _CHUCVU;
        private bool _ENABLED;
        private int _ROLE;
        private string _PASSWORDRESSETHASH;
        private string _TEMPPASSWORD;
        
        public DTO_Profile(long _MANV1,string _TENNV1,DateTime _NGAYSINH1,
        bool _GIOITINH1,string _DIACHI1,int _SDT1,string _CHUCVU1,bool _ENABLED1,
        int _ROLE1, string _PASSWORDRESSETHASH1,string _TEMPPASSWORD1)
        {
            _MANV = _MANV1;
            _TENNV = _TENNV1;
            _NGAYSINH = _NGAYSINH1;
            _GIOITINH = _GIOITINH1;
            _DIACHI = _DIACHI1;
            _SDT = _SDT1;
            _CHUCVU = _CHUCVU1;
            _ENABLED = _ENABLED1;
            _ROLE = _ROLE1;
            _PASSWORDRESSETHASH = _PASSWORDRESSETHASH1;
            _TEMPPASSWORD = _TEMPPASSWORD1;
        }
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

        public string TEMPPASSWORD
        {
            get { return _TEMPPASSWORD; }
            set { _TEMPPASSWORD = value; }
        }

        public string PASSWORDRESETHASH
        {
            get { return _PASSWORDRESSETHASH; }
            set { _PASSWORDRESSETHASH = value; }
        }

        public int ROLE
        {
            get { return _ROLE; }
            set { _ROLE = value; }
        }


        public bool ENABLED
        {
            get { return _ENABLED; }
            set { _ENABLED = value; }
        }

    }
}

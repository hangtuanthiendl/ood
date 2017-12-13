using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_User
    {
        private long _MANV;
        private bool _ENABLED;
        private int _ROLE;
        private string _PASSWORDRESSETHASH;
        private string _TEMPPASSWORD;

        public  string TEMPPASSWORD
        {
            get { return _TEMPPASSWORD; }
            set { _TEMPPASSWORD = value; }
        }

        public  string PASSWORDRESETHASH
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

        public long MANV
        {
            get { return _MANV; }
            set { _MANV = value; }
        }

    }
}

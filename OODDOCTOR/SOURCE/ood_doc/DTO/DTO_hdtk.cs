using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_Hdtk
    {
        private long _MAHDTK;
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public long MAHDTK
        {
            get { return _MAHDTK; }
            set { _MAHDTK = value; }
        }

    }
}

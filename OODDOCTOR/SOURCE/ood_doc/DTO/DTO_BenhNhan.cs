using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BenhNhan
    {
        private long _MABN;
        private string _TENBN;
        private DateTime _NGAYSINH;
        private bool _GTINH;
        private string _DCHI;
        private int _SDT;
        private string _CTY;
        private string _TSBENH;

        public long MABN
        {
            get { return _MABN; }
            set { _MABN = value; }
        }

        public string TENBN
        {
            get { return _TENBN; }
            set { _TENBN = value; }
        }
        public DateTime NGAYSINH
        {
            get { return _NGAYSINH; }
            set { _NGAYSINH = value; }
        }
        public bool GTINH
        {
            get { return _GTINH; }
            set { _GTINH = value; }
        }
        public string DCHI
        {
            get { return _DCHI; }
            set { _DCHI = value; }
        }
        public int SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        public string CTY
        {
            get { return _CTY; }
            set { _CTY = value; }
        }
        public string TSBENH
        {
            get { return _TSBENH; }
            set { _TSBENH = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using System.Diagnostics;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.Metro.ColorTables;
using BUS;
using DTO;
namespace GUI
{
    public partial class GIAM_DOC : MetroAppForm
    {
        BUS_NhanVien nv = new BUS_NhanVien();
        List<DTO_Profile> list;
        public GIAM_DOC()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            list = nv.DanhSachNhanVien();
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nv.ThemNhanVien();
        }
    }
}

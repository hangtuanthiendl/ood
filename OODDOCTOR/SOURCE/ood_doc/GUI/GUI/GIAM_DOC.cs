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

namespace GUI
{
    public partial class GIAM_DOC : MetroAppForm
    {
        public GIAM_DOC()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

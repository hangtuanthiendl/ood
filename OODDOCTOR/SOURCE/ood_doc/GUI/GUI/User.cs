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
namespace GUI
{
    public partial class User : MetroAppForm
    {
        public User()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

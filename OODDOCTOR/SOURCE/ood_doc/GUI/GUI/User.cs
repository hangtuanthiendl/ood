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
using DAL;
using MySql.Data.MySqlClient;

namespace GUI
{
    public partial class User : MetroAppForm
    {
        DAL_dbConnect con = new DAL_dbConnect();

        public User()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (con.KiemTraUser(textBoxX2.Text, textBoxX1.Text) != -1)
            {
                //MessageBox.Show("Đăng nhập thành công! Role :" + con.KiemTraUser(textBoxX2.Text, textBoxX1.Text));
                switch (con.KiemTraUser(textBoxX2.Text, textBoxX1.Text))
                {
                    case 2://Nhan Vien
                        NHAN_VIEN nv = new NHAN_VIEN();
                        nv.Show();
                        break;

                    case 1://Bac Si
                        BACSI bs = new BACSI();
                        bs.Show();
                        break;

                    case 0://Giam Doc
                        GIAM_DOC gd = new GIAM_DOC();
                        gd.Show();
                        break;
                }
            }
            else
                MessageBox.Show("Đăng nhập thất bại! Role :" + con.KiemTraUser(textBoxX2.Text, textBoxX1.Text));
            this.Hide();
            textBoxX1.ResetText();
            textBoxX2.ResetText();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX1.PerformClick();
            }
        }
    }
}

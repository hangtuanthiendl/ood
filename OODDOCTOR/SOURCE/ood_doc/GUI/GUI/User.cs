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
            DTO.DTO_Profile prf = con.KiemTraUser(textBoxX2.Text, textBoxX1.Text);
            if (prf != null)
            {
                if (prf.ROLE != -1)
                {
                    MessageBox.Show("Đăng nhập thành công! Xin chào " + prf.TENNV);
                    this.Hide();
                    switch (prf.ROLE)
                    {
                        case 2://Nhan Vien
                            NHAN_VIEN nv = new NHAN_VIEN();
                            nv.ShowDialog();
                            break;

                        case 1://Bac Si
                            BACSI bs = new BACSI();
                            bs.ShowDialog();
                            break;

                        case 0://Giam Doc
                            GIAM_DOC gd = new GIAM_DOC(prf);
                            gd.ShowDialog();
                            break;
                    }
                    
                   // textBoxX1.ResetText();
                   // textBoxX2.ResetText();
                }
            }
            else
                MessageBox.Show("Đăng nhập thất bại!");
            
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

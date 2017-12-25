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
        int Select = -1;
        BUS_NhanVien nv = new BUS_NhanVien();
        List<DTO_Profile> list;
        public GIAM_DOC()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;   
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {
           dTOProfileBindingSource.Clear();
           list = nv.DanhSachNhanVien();
            for (int i = 0; i<list.Count; i++)
            {
                dTOProfileBindingSource.Add(list[i]);
            }       
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nv.ThemNhanVien();
            
        }

        private void advTree2_Click(object sender, EventArgs e)
        {

        }

        private void lvNHANVIEN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.RowIndex >= 0)
            {
                Select = Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value);
                txbMANV.Text = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbHoTen.Text = dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbDiaChi.Text = dataGridViewX1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txbSDT.Text = dataGridViewX1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbChucVu.Text = dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //Kiểm tra giới tính
                if(Convert.ToBoolean(dataGridViewX1.Rows[e.RowIndex].Cells[5].Value.ToString()) == true)
                {
                    chkNam.Checked = true;
                }
                else
                {
                    chkNu.Checked = true;
                }

                //Kiểm tra role
                if (Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[8].Value.ToString()) == 1)
                {
                    cbRole.SelectedIndex = 1;
                }
                if (Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[8].Value.ToString()) == 2)
                {
                    cbRole.SelectedIndex = 2;
                }
                if (Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[8].Value.ToString()) == 3)
                {
                    cbRole.SelectedIndex = 3;
                }
            }
           
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Select > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa nhân viên có mã: " + Select, "Hãy cẩn thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    nv.XoaNhanVien(Select);
                    dTOProfileBindingSource.Clear();
                    list = nv.DanhSachNhanVien();
                    for (int i = 0; i < list.Count; i++)
                    {
                        dTOProfileBindingSource.Add(list[i]);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Enabled = false;
                btnSua.Enabled = false;

                XuliCacCongCu(1);
            }
            else
            {
                btnThem.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                
                XuliCacCongCu(0);
            }
        }

        void XuliCacCongCu(int a)
        {
            if (a == 1)
            {
                txbDiaChi.Enabled = true;
                txbHoTen.Enabled = true;
                txbSDT.Enabled = true;
                txtbChucVu.Enabled = true;
                chkNam.Enabled = true;
                chkNu.Enabled = true;
                dtpNgaySinh.Enabled = true;
                cbRole.Enabled = true;
                dataGridViewX1.Enabled = false;
            }
            else
            {
                txbDiaChi.Enabled = false;
                txbHoTen.Enabled = false;
                txbSDT.Enabled = false;
                txtbChucVu.Enabled = false;
                chkNam.Enabled = false;
                chkNu.Enabled = false;
                dtpNgaySinh.Enabled = false;
                cbRole.Enabled = false;
                dataGridViewX1.Enabled = true;
            }
        }
    }
}

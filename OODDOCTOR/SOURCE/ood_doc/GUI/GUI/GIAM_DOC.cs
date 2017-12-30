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
        BUS_DichVu dv = new BUS_DichVu();

        List<DTO_Profile> list;
        List<DTO_DichVu> listdv;
        DTO_Profile prf;
        public GIAM_DOC(DTO_Profile prf1)
        {
            prf = prf1;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd-MM-yyyy";
            dtpNgaySinh.ShowUpDown = true;
            LoadLaiBangDichVu();
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            LoadLaibangNhanVien();
            
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
                txbMANV.Text = "######";
            }
            else
            {
                btnThem.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                nv.ThemNhanVien(txbHoTen.Text, dtpNgaySinh.Value.ToString("yyyy-MM-dd"), true,
                    txbDiaChi.Text, 0123456, txtbChucVu.Text, 2, cbRole.SelectedIndex, "123456");
                LoadLaibangNhanVien();
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
                dgvNHANVIEN.Enabled = false;
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
                dgvNHANVIEN.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                XuliCacCongCu(1);
            }
            else
            {
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                nv.SuaNhanVien(Convert.ToInt32(txbMANV.Text) ,txbHoTen.Text, dtpNgaySinh.Value.ToString("yyyy-MM-dd"), true,
                txbDiaChi.Text, 0123456, txtbChucVu.Text, 2, cbRole.SelectedIndex, "123456");
                LoadLaibangNhanVien();
                XuliCacCongCu(0);
            }
        }

        //==================================================================================================
        //CÁC HÀM XỬ LÍ KHÁC
        //Các hàm load bảng
        void LoadLaibangNhanVien()
        {
            dTOProfileBindingSource.Clear();
            list = nv.DanhSachNhanVien();
            for (int i = 0; i < list.Count; i++)
            {
                dTOProfileBindingSource.Add(list[i]);
            }
        }
        void LoadLaiBangDichVu()
        {
            dTODichVuBindingSource.Clear();
            listdv = dv.DanhSachDichvu(); ;
            for (int i = 0; i < listdv.Count; i++)
            {
                dTODichVuBindingSource.Add(listdv[i]);
            }
        }
    }
}

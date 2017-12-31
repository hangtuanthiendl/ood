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
        int Select2 = -1;
        int Select3 = -1;
        BUS_NhanVien nv = new BUS_NhanVien();
        BUS_DichVu dv = new BUS_DichVu();
        BUS_Thuoc thuoc = new BUS_Thuoc();
        List<DTO_Profile> list;
        List<DTO_DichVu> listdv;
        List<DTO_Thuoc> listthuoc;
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
            LoadLaiThuoc();
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
        //==================================================================================================
        //Tab Profile

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

        private void dgvNHANVIEN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Select = Convert.ToInt32(dgvNHANVIEN.Rows[e.RowIndex].Cells[0].Value);
                txbMANV.Text = dgvNHANVIEN.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbHoTen.Text = dgvNHANVIEN.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbDiaChi.Text = dgvNHANVIEN.Rows[e.RowIndex].Cells[4].Value.ToString();
                txbSDT.Text = dgvNHANVIEN.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtbChucVu.Text = dgvNHANVIEN.Rows[e.RowIndex].Cells[1].Value.ToString();
                //Kiểm tra giới tính
                if (Convert.ToBoolean(dgvNHANVIEN.Rows[e.RowIndex].Cells[5].Value.ToString()) == true)
                {
                    chkNam.Checked = true;
                }
                else
                {
                    chkNu.Checked = true;
                }

                //Kiểm tra role
                if (Convert.ToInt32(dgvNHANVIEN.Rows[e.RowIndex].Cells[8].Value.ToString()) == 1)
                {
                    cbRole.SelectedIndex = 1;
                }
                if (Convert.ToInt32(dgvNHANVIEN.Rows[e.RowIndex].Cells[8].Value.ToString()) == 2)
                {
                    cbRole.SelectedIndex = 2;
                }
                if (Convert.ToInt32(dgvNHANVIEN.Rows[e.RowIndex].Cells[8].Value.ToString()) == 3)
                {
                    cbRole.SelectedIndex = 3;
                }
            }

        }

        //==================================================================================================
        //Tab Dịch Vụ
        private void dgvDichVU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select2 = Convert.ToInt32(dgvDICHVU.Rows[e.RowIndex].Cells[0].Value);
            if (e.RowIndex >= 0)
            {
                txbMADV.Text = dgvDICHVU.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbTENDV.Text = dgvDICHVU.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbMANV2.Text = dgvDICHVU.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbGIADV2.Text = dgvDICHVU.Rows[e.RowIndex].Cells[3].Value.ToString();
                            
            }
        }

        private void btnThemDv_Click(object sender, EventArgs e)
        {
            if (btnThemDv.Text == "Thêm")
            {
                btnThemDv.Text = "Lưu";
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                XuliCacCongCuTabDichVu(1);
                txbMADV.Text = "######";
            }
            else
            {
                btnThemDv.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                dv.ThemDichVu(txbTENDV.Text, Convert.ToInt32(txbMANV2.Text), Convert.ToDouble(txbGIADV2.Text));
                this.LoadLaiBangDichVu();
                XuliCacCongCuTabDichVu(0);
            }
        }

        private void btnXoaDv_Click(object sender, EventArgs e)
        {
            if (Select2 > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa dịch vụ có mã: " + Select2, "Hãy cẩn thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dv.XoaDichVu(Select2);
                    dTOProfileBindingSource.Clear();
                    this.LoadLaiBangDichVu();
                }
            }
        }

        private void btnSuaDv_Click(object sender, EventArgs e)
        {
            if (btnSuaDv.Text == "Sửa")
            {
                btnSuaDv.Text = "Lưu";
                btnXoaDv.Enabled = false;
                btnThemDv.Enabled = false;
                this.XuliCacCongCuTabDichVu(1);
            }
            else
            {
                btnSuaDv.Text = "Sửa";
                btnXoaDv.Enabled = true;
                btnThemDv.Enabled = true;
                dv.SuaDichVu(Convert.ToInt32(txbMADV.Text), txbTENDV.Text, Convert.ToInt32(txbMANV2.Text), Convert.ToDouble(txbGIADV2.Text));
                this.XuliCacCongCuTabDichVu(0);
                this.LoadLaiBangDichVu();
            }
        }

        //==================================================================================================
        //Tab Thuốc
        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (btnThemThuoc.Text == "Thêm")
            {
                btnThemThuoc.Text = "Lưu";
                btnXoaThuoc.Enabled = false;
                btnSuaThuoc.Enabled = false;
                this.XuliCacCongCuThuoc(1);
                txbMATHUOC.Text = "######";
                txbMANV3.Text = prf.MANV.ToString();
            }
            else
            {
                btnThemThuoc.Text = "Thêm";
                btnXoaThuoc.Enabled = true;
                btnSuaThuoc.Enabled = true;
                thuoc.ThemThuoc(txbTENTHUOC.Text, Convert.ToInt32(txbSOLUONG.Text), Convert.ToDouble(txbDONGIA.Text), prf.MANV);
                //dv.ThemDichVu(txbTENDV.Text, Convert.ToInt32(txbMANV2.Text), Convert.ToDouble(txbGIADV2.Text));
                this.LoadLaiThuoc();
                this.XuliCacCongCuThuoc(0);
            }
        }
        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            if (Select3 > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa dịch vụ có mã: " + Select3, "Hãy cẩn thận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    thuoc.XoaThuoc(Select3);
                    dTOThuocBindingSource.Clear();
                    this.LoadLaiThuoc();
                }
            }
        }
        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            if (btnSuaThuoc.Text == "Sửa")
            {
                btnSuaThuoc.Text = "Lưu";
                btnXoaThuoc.Enabled = false;
                btnThemThuoc.Enabled = false;
                this.XuliCacCongCuThuoc(1);
            }
            else
            {
                btnSuaThuoc.Text = "Sửa";
                btnXoaThuoc.Enabled = true;
                btnThemThuoc.Enabled = true;
                thuoc.SuaThuoc(Convert.ToInt32(txbMATHUOC.Text), txbTENTHUOC.Text, Convert.ToInt32(txbSOLUONG.Text), Convert.ToDouble(txbDONGIA.Text), Convert.ToInt32(txbMANV3.Text));
                this.XuliCacCongCuThuoc(0);
                this.LoadLaiThuoc();
            }
        }
        private void dgvTHUOC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Select3 = Convert.ToInt32(dgvTHUOC.Rows[e.RowIndex].Cells[0].Value);
            if (e.RowIndex >= 0)
            {
                txbMATHUOC.Text = dgvTHUOC.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbTENTHUOC.Text = dgvTHUOC.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbSOLUONG.Text = dgvTHUOC.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbDONGIA.Text = dgvTHUOC.Rows[e.RowIndex].Cells[3].Value.ToString();
                txbMANV3.Text = dgvTHUOC.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }
        //==================================================================================================
        //CÁC HÀM XỬ LÍ KHÁC
        //Các hàm xử lí enabled
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

        void XuliCacCongCuTabDichVu(int a)
        {
            if (a == 1)
            {
                txbMADV.Enabled = true;
                txbTENDV.Enabled = true;
                txbMANV2.Enabled = true;
                txbGIADV2.Enabled = true;
                dgvDICHVU.Enabled = false;
            }
            else
            {
                txbMADV.Enabled = false;
                txbTENDV.Enabled = false;
                txbMANV2.Enabled = false;
                txbGIADV2.Enabled = false;
                dgvDICHVU.Enabled = true;
            }
        }
        void XuliCacCongCuThuoc(int a)
        {
            if (a == 1)
            {
                //txbMATHUOC.Enabled = true;
                txbTENTHUOC.Enabled = true;
                txbSOLUONG.Enabled = true;
                txbDONGIA.Enabled = true;
                //txbMANV3.Enabled = true;
                dgvTHUOC.Enabled = false;
            }
            else
            {
                //txbMATHUOC.Enabled = false;
                txbTENTHUOC.Enabled = false;
                txbSOLUONG.Enabled = false;
                txbDONGIA.Enabled = false;
                //txbMANV3.Enabled = false;
                dgvTHUOC.Enabled = true;
            }
        }
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
        void LoadLaiThuoc()
        {
            dTOThuocBindingSource.Clear();
            listthuoc = thuoc.DanhSachThuoc(); ;
            for (int i = 0; i < listthuoc.Count; i++)
            {
                dTOThuocBindingSource.Add(listthuoc[i]);
            }
        }

        
    }
}

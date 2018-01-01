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
        BUS_HDTK hdtk = new BUS_HDTK();
        BUS_DONTHUOC donthuoc = new BUS_DONTHUOC();
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
            ngayKham1.Format = DateTimePickerFormat.Custom;
            ngayKham1.CustomFormat = "dd-MM-yyyy";
            ngayKham1.ShowUpDown = true;
            ngayKham2.Format = DateTimePickerFormat.Custom;
            ngayKham2.CustomFormat = "dd-MM-yyyy";
            ngayKham2.ShowUpDown = true;
            ngayThuoc1.Format = DateTimePickerFormat.Custom;
            ngayThuoc1.CustomFormat = "dd-MM-yyyy";
            ngayThuoc1.ShowUpDown = true;
            ngayThuoc2.Format = DateTimePickerFormat.Custom;
            ngayThuoc2.CustomFormat = "dd-MM-yyyy";
            ngayThuoc2.ShowUpDown = true;
        }

        private void NHANVIEN_Load(object sender, EventArgs e)
        {
            LoadLaibangNhanVien();
            XuliBaocaoTienKham(1);
            XuliBaoCaoTienThuoc(1);
            Xulitienkham(2);
            Xulitienthuoc(2);
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
        void XuliBaocaoTienKham(int a)
        {
            if (a == 1)
            {
                chart1.Hide();
                dataGridViewX2.Show();
            }
            else
            {
                chart1.Show();
                dataGridViewX2.Hide();
            }
        }
        void XuliBaoCaoTienThuoc(int a)
        {
            if (a == 1)
            {
                chart2.Hide();
                dataGridViewX3.Show();
            }
            else
            {
                chart2.Show();
                dataGridViewX3.Hide();
            }
        }
        void XuliBaoCaoKham(int a)
        {
            if (a == 1)
            {
                ngayKham1.Enabled = true;
                ngayKham2.Enabled = true;
            }
            else
            {
                ngayKham1.Enabled = false;
                ngayKham2.Enabled = false;
            }
        }
        void XuliDoanhThuKham(int a)
        {
            if (a == 1)
            {
                numKham.Enabled = true;
            }
            else
            {
                numKham.Enabled = false;
            }
        }
        void Xulitienkham(int a)
        {
            if (a == 1)
            {
                ngayKham1.Enabled = true;
                ngayKham2.Enabled = true;
                numKham.Enabled = true;
            }
            else
            {
                ngayKham1.Enabled = false;
                ngayKham2.Enabled = false;
                numKham.Enabled = false;
            }
        }
        void XuliBaoCaoThuoc(int a)
        {
            if (a == 1)
            {
                ngayThuoc1.Enabled = true;
                ngayThuoc2.Enabled = true;
            }
            else
            {
                ngayThuoc1.Enabled = false;
                ngayThuoc2.Enabled = false;
            }
        }
        void XuliDoanhThuThuoc(int a)
        {
            if (a == 1)
            {
                numThuoc.Enabled = true;
            }
            else
            {
                numThuoc.Enabled = false;
            }
        }
        void Xulitienthuoc(int a)
        {
            if (a == 1)
            {
                ngayThuoc1.Enabled = true;
                ngayThuoc2.Enabled = true;
                numThuoc.Enabled = true;
            }
            else
            {
                ngayThuoc1.Enabled = false;
                ngayThuoc2.Enabled = false;
                numThuoc.Enabled = false;
            }
        }
        void LoadBaocaoKham(string ngay1, string ngay2)
        {
            //dTOHdtkBindingSource.Clear();
            DataTable table = new DataTable();
            table = hdtk.ThongKeTienKham(ngay1, ngay2);
            XuliBaocaoTienKham(1);
            if (table.Rows.Count != 0)
            {
                dataGridViewX2.DataSource = table;
                int sum = 0;
                for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                {
                    sum = sum + int.Parse(dataGridViewX2.Rows[i].Cells[4].Value.ToString());
                }
                txtBaoCaoKham.Text = sum.ToString("N0");
            }
            else
            {
                MessageBox.Show("Chưa có báo cáo tiền khám từ ngày: " + ngay1 + " đến: " + ngay2, "Thông báo", MessageBoxButtons.OK);
            }
        }
        void LoadDoanhThuKham(string YEAR)
        {
            DataTable table = hdtk.DoanhThuTienKham(int.Parse(YEAR));
            XuliBaocaoTienKham(2);
            //dataGridViewX3.DataSource = table;
            int sum = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sum = sum + int.Parse(table.Rows[i][1].ToString());
            }
            txtDoanhThuKham.Text = sum.ToString("N0");

            chart1.Series.Clear();
            if (table.Rows.Count > 0)
            {
                chart1.Series.Add("Doanh thu");
                int x, y;
                int j = 1;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //MessageBox.Show("Không có dữ liệu để thống kê năm " + int.Parse(table.Rows[i][0].ToString()), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    x = int.Parse(table.Rows[i][0].ToString());

                    y = int.Parse(table.Rows[i][1].ToString());

                    if (x == j)
                    {
                        chart1.Series["Doanh thu"].Points.AddXY(x, y);
                        j++;
                    }
                    else
                    {

                        for (; j < x; j++)
                        {
                            chart1.Series["Doanh thu"].Points.AddXY(j, 0);
                        }

                        chart1.Series["Doanh thu"].Points.AddXY(x, y);
                        j++;

                    }
                }
                if (j < 13)
                {
                    for (; j < 13; j++)
                    {
                        chart1.Series["Doanh thu"].Points.AddXY(j, 0);
                    }
                }
            }
            else
                MessageBox.Show("Không có dữ liệu để thống kê tiền khám năm " + YEAR, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void LoadBaocaoThuoc(string ngay1, string ngay2)
        {
            //dTOHdtkBindingSource.Clear();
            DataTable table = new DataTable();
            table = donthuoc.ThongKeTienThuoc(ngay1, ngay2);
            XuliBaoCaoTienThuoc(1);
            if (table.Rows.Count != 0)
            {
                dataGridViewX3.DataSource = table;
                int sum = 0;
                for (int i = 0; i < dataGridViewX3.Rows.Count; i++)
                {
                    sum = sum + int.Parse(dataGridViewX3.Rows[i].Cells[4].Value.ToString());
                }
                txtBaoCaoThuoc.Text = sum.ToString("N0");
            }
            else
            {
                MessageBox.Show("Chưa có báo cáo tiền thuốc từ ngày: " + ngay1 + " đến: " + ngay2, "Thông báo", MessageBoxButtons.OK);
            }
        }
        void LoadDoanhThuThuoc(string YEAR)
        {
            DataTable table = donthuoc.DoanhThuTienThuoc(int.Parse(YEAR));
            XuliBaoCaoTienThuoc(2);
            //dataGridViewX3.DataSource = table;
            int sum = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sum = sum + int.Parse(table.Rows[i][1].ToString());
            }
            txtDoanhThuThuoc.Text = sum.ToString("N0");

            chart2.Series.Clear();
            if (table.Rows.Count > 0)
            {
                chart2.Series.Add("Doanh thu");
                int x, y;
                int j = 1;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    //MessageBox.Show("Không có dữ liệu để thống kê năm " + int.Parse(table.Rows[i][0].ToString()), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    x = int.Parse(table.Rows[i][0].ToString());

                    y = int.Parse(table.Rows[i][1].ToString());

                    if (x == j)
                    {
                        chart2.Series["Doanh thu"].Points.AddXY(x, y);
                        j++;
                    }
                    else
                    {

                        for (; j < x; j++)
                        {
                            chart2.Series["Doanh thu"].Points.AddXY(j, 0);
                        }

                        chart2.Series["Doanh thu"].Points.AddXY(x, y);
                        j++;

                    }
                }
                if (j < 13)
                {
                    for (; j < 13; j++)
                    {
                        chart2.Series["Doanh thu"].Points.AddXY(j, 0);
                    }
                }
            }
            else
                MessageBox.Show("Không có dữ liệu để thống kê tiền thuốc năm " + YEAR, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnBCKham_Click(object sender, EventArgs e)
        {
            if (btnBCKham.Text == "Báo cáo khám")
            {
                btnBCKham.Text = "Lập báo cáo khám";
                XuliBaoCaoKham(1);
            }
            else
            {
                btnBCKham.Text = "Báo cáo khám";
                txtDoanhThuKham.Text = "";
                LoadBaocaoKham(ngayKham1.Value.ToString("yyyy-MM-dd"), ngayKham2.Value.ToString("yyyy-MM-dd"));
                XuliBaoCaoKham(2);
            }
        }

        private void btnDTKham_Click(object sender, EventArgs e)
        {
            if (btnDTKham.Text == "Doanh thu khám")
            {
                btnDTKham.Text = "Xem doanh thu khám";
                XuliDoanhThuKham(1);
            }
            else
            {
                btnDTKham.Text = "Doanh thu khám";
                txtBaoCaoKham.Text = "";
                LoadDoanhThuKham(numKham.Text);
                XuliDoanhThuKham(2);
            }
        }

        private void btnBCThuoc_Click(object sender, EventArgs e)
        {
            if (btnBCThuoc.Text == "Báo cáo thuốc")
            {
                btnBCThuoc.Text = "Lập báo cáo thuốc";
                XuliBaoCaoThuoc(1);
            }
            else
            {
                btnBCThuoc.Text = "Báo cáo thuốc";
                txtDoanhThuThuoc.Text = "";
                LoadBaocaoThuoc(ngayThuoc1.Value.ToString("yyyy-MM-dd"), ngayThuoc2.Value.ToString("yyyy-MM-dd"));
                XuliBaoCaoThuoc(2);
            }
        }

        private void btnDTThuoc_Click(object sender, EventArgs e)
        {
            if (btnDTThuoc.Text == "Doanh thu thuốc")
            {
                btnDTThuoc.Text = "Xem doanh thu thuốc";
                XuliDoanhThuThuoc(1);
            }
            else
            {
                btnDTThuoc.Text = "Doanh thu thuốc";
                txtBaoCaoThuoc.Text = "";
                LoadDoanhThuThuoc(numThuoc.Text);
                XuliDoanhThuThuoc(2);
            }
        }
    }
}

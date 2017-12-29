namespace GUI
{
    partial class BACSI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.btnTaiKhoan = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.tabBenhNhan = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.advTree2 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader9 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader10 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader11 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader12 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader13 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader14 = new DevComponents.AdvTree.ColumnHeader();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.btnThoat = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(1083, 587);
            this.superTabControlPanel5.TabIndex = 2;
            this.superTabControlPanel5.TabItem = this.btnTaiKhoan;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.AttachedControl = this.superTabControlPanel5;
            this.btnTaiKhoan.GlobalItem = false;
            this.btnTaiKhoan.Image = global::GUI.Properties.Resources._004_care;
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Text = "TÀI KHOẢN";
            // 
            // superTabItem1
            // 
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "superTabItem1";
            // 
            // tabBenhNhan
            // 
            this.tabBenhNhan.AttachedControl = this.superTabControlPanel2;
            this.tabBenhNhan.GlobalItem = false;
            this.tabBenhNhan.Image = global::GUI.Properties.Resources._004_care1;
            this.tabBenhNhan.Name = "tabBenhNhan";
            this.tabBenhNhan.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBenhNhan.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBenhNhan.Text = "BỆNH NHÂN";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.tableLayoutPanel1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 78);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1083, 509);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabBenhNhan;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.itemPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.advTree2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1083, 509);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.ForeColor = System.Drawing.Color.Black;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(761, 3);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(319, 503);
            this.itemPanel1.TabIndex = 0;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // advTree2
            // 
            this.advTree2.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree2.AllowDrop = true;
            this.advTree2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.advTree2.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree2.Columns.Add(this.columnHeader8);
            this.advTree2.Columns.Add(this.columnHeader9);
            this.advTree2.Columns.Add(this.columnHeader10);
            this.advTree2.Columns.Add(this.columnHeader11);
            this.advTree2.Columns.Add(this.columnHeader12);
            this.advTree2.Columns.Add(this.columnHeader13);
            this.advTree2.Columns.Add(this.columnHeader14);
            this.advTree2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advTree2.ForeColor = System.Drawing.Color.Black;
            this.advTree2.Location = new System.Drawing.Point(3, 3);
            this.advTree2.Name = "advTree2";
            this.advTree2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree2.NodesConnector = this.nodeConnector2;
            this.advTree2.NodeStyle = this.elementStyle2;
            this.advTree2.PathSeparator = ";";
            this.advTree2.Size = new System.Drawing.Size(752, 503);
            this.advTree2.Styles.Add(this.elementStyle2);
            this.advTree2.TabIndex = 1;
            this.advTree2.Text = "advTree2";
            // 
            // columnHeader8
            // 
            this.columnHeader8.MaxInputLength = 1;
            this.columnHeader8.MinimumWidth = 100;
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.StretchToFill = true;
            this.columnHeader8.Text = "MANV";
            this.columnHeader8.Width.Absolute = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.MinimumWidth = 300;
            this.columnHeader9.Name = "columnHeader9";
            this.columnHeader9.StretchToFill = true;
            this.columnHeader9.Text = "Họ và tên";
            this.columnHeader9.Width.Absolute = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.MinimumWidth = 100;
            this.columnHeader10.Name = "columnHeader10";
            this.columnHeader10.StretchToFill = true;
            this.columnHeader10.Text = "Ngày sinh";
            this.columnHeader10.Width.Absolute = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.MinimumWidth = 50;
            this.columnHeader11.Name = "columnHeader11";
            this.columnHeader11.StretchToFill = true;
            this.columnHeader11.Text = "Giới tính";
            this.columnHeader11.Width.Absolute = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.MinimumWidth = 100;
            this.columnHeader12.Name = "columnHeader12";
            this.columnHeader12.StretchToFill = true;
            this.columnHeader12.Text = "Địa chỉ";
            this.columnHeader12.Width.Absolute = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.MinimumWidth = 150;
            this.columnHeader13.Name = "columnHeader13";
            this.columnHeader13.StretchToFill = true;
            this.columnHeader13.Text = "SDT";
            this.columnHeader13.Width.Absolute = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.MinimumWidth = 100;
            this.columnHeader14.Name = "columnHeader14";
            this.columnHeader14.StretchToFill = true;
            this.columnHeader14.Text = "Chức vụ";
            this.columnHeader14.Width.Absolute = 150;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "Chưa lấy được dữ liệu";
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel4;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Image = global::GUI.Properties.Resources._005_pills;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabItem2.Text = "THUỐC";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 78);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(1083, 509);
            this.superTabControlPanel4.TabIndex = 2;
            this.superTabControlPanel4.TabItem = this.superTabItem2;
            // 
            // btnThoat
            // 
            this.btnThoat.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.HotFontBold = true;
            this.btnThoat.Image = global::GUI.Properties.Resources._003_cancel;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnThoat.Text = "THOÁT";
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel4);
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 1);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(1083, 587);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 2;
            this.superTabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabBenhNhan,
            this.superTabItem2,
            this.btnTaiKhoan,
            this.btnThoat});
            this.superTabControl1.Text = "Dịch vụ";
            // 
            // BACSI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 589);
            this.Controls.Add(this.superTabControl1);
            this.Name = "BACSI";
            this.Text = "BACSI";
            this.superTabControlPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.SuperTabItem btnTaiKhoan;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabItem tabBenhNhan;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.AdvTree.AdvTree advTree2;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private DevComponents.AdvTree.ColumnHeader columnHeader9;
        private DevComponents.AdvTree.ColumnHeader columnHeader10;
        private DevComponents.AdvTree.ColumnHeader columnHeader11;
        private DevComponents.AdvTree.ColumnHeader columnHeader12;
        private DevComponents.AdvTree.ColumnHeader columnHeader13;
        private DevComponents.AdvTree.ColumnHeader columnHeader14;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.ButtonItem btnThoat;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
    }
}
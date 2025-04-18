namespace QuanLyQuanCafe
{
    partial class formTableManager
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
            flpTable = new FlowLayoutPanel();
            pnlTopRight = new Panel();
            nmFoodCount = new NumericUpDown();
            btnAddFood = new Button();
            cmbFood = new ComboBox();
            cmbCategory = new ComboBox();
            pnlBill = new Panel();
            lsvBill = new ListView();
            l = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            pnlBottomRight = new Panel();
            txtTotalPrice = new TextBox();
            numericUpDown1 = new NumericUpDown();
            cmbSwitchTable = new ComboBox();
            btnCheckOut = new Button();
            btnDiscount = new Button();
            btnSwitchTable = new Button();
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoảnToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCáNhânToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            chwcToolStripMenuItem = new ToolStripMenuItem();
            thêmMónToolStripMenuItem = new ToolStripMenuItem();
            thanhToánToolStripMenuItem = new ToolStripMenuItem();
            pnlTopRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).BeginInit();
            pnlBill.SuspendLayout();
            pnlBottomRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // flpTable
            // 
            flpTable.AutoScroll = true;
            flpTable.Location = new Point(12, 31);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(440, 596);
            flpTable.TabIndex = 0;
            // 
            // pnlTopRight
            // 
            pnlTopRight.Controls.Add(nmFoodCount);
            pnlTopRight.Controls.Add(btnAddFood);
            pnlTopRight.Controls.Add(cmbFood);
            pnlTopRight.Controls.Add(cmbCategory);
            pnlTopRight.Location = new Point(458, 31);
            pnlTopRight.Name = "pnlTopRight";
            pnlTopRight.Size = new Size(409, 69);
            pnlTopRight.TabIndex = 1;
            // 
            // nmFoodCount
            // 
            nmFoodCount.Location = new Point(343, 21);
            nmFoodCount.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmFoodCount.Name = "nmFoodCount";
            nmFoodCount.Size = new Size(63, 27);
            nmFoodCount.TabIndex = 3;
            nmFoodCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(243, 0);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(94, 66);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm món";
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // cmbFood
            // 
            cmbFood.FormattingEnabled = true;
            cmbFood.Location = new Point(3, 37);
            cmbFood.Name = "cmbFood";
            cmbFood.Size = new Size(234, 28);
            cmbFood.TabIndex = 1;
            cmbFood.SelectedIndexChanged += cmbFood_SelectedIndexChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(3, 3);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(234, 28);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // pnlBill
            // 
            pnlBill.Controls.Add(lsvBill);
            pnlBill.Location = new Point(458, 102);
            pnlBill.Name = "pnlBill";
            pnlBill.Size = new Size(409, 449);
            pnlBill.TabIndex = 2;
            // 
            // lsvBill
            // 
            lsvBill.Columns.AddRange(new ColumnHeader[] { l, columnHeader1, columnHeader2, columnHeader3 });
            lsvBill.GridLines = true;
            lsvBill.Location = new Point(3, 4);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(403, 442);
            lsvBill.TabIndex = 0;
            lsvBill.UseCompatibleStateImageBehavior = false;
            lsvBill.View = View.Details;
            // 
            // l
            // 
            l.Text = "Ten mon";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "So luong";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Don gia";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Thanh tien ";
            // 
            // pnlBottomRight
            // 
            pnlBottomRight.Controls.Add(txtTotalPrice);
            pnlBottomRight.Controls.Add(numericUpDown1);
            pnlBottomRight.Controls.Add(cmbSwitchTable);
            pnlBottomRight.Controls.Add(btnCheckOut);
            pnlBottomRight.Controls.Add(btnDiscount);
            pnlBottomRight.Controls.Add(btnSwitchTable);
            pnlBottomRight.Location = new Point(458, 554);
            pnlBottomRight.Name = "pnlBottomRight";
            pnlBottomRight.Size = new Size(409, 73);
            pnlBottomRight.TabIndex = 3;
            // 
            // txtTotalPrice
            // 
            txtTotalPrice.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotalPrice.Location = new Point(217, 22);
            txtTotalPrice.Name = "txtTotalPrice";
            txtTotalPrice.ReadOnly = true;
            txtTotalPrice.Size = new Size(106, 28);
            txtTotalPrice.TabIndex = 5;
            txtTotalPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(116, 42);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(95, 27);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            // 
            // cmbSwitchTable
            // 
            cmbSwitchTable.FormattingEnabled = true;
            cmbSwitchTable.Location = new Point(3, 39);
            cmbSwitchTable.Name = "cmbSwitchTable";
            cmbSwitchTable.Size = new Size(107, 28);
            cmbSwitchTable.TabIndex = 3;
            // 
            // btnCheckOut
            // 
            btnCheckOut.CausesValidation = false;
            btnCheckOut.Location = new Point(324, 3);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(82, 64);
            btnCheckOut.TabIndex = 2;
            btnCheckOut.Text = "Thanh toán";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // btnDiscount
            // 
            btnDiscount.Location = new Point(116, 3);
            btnDiscount.Name = "btnDiscount";
            btnDiscount.Size = new Size(95, 39);
            btnDiscount.TabIndex = 1;
            btnDiscount.Text = "Giam giá";
            btnDiscount.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnDiscount.UseVisualStyleBackColor = true;
            // 
            // btnSwitchTable
            // 
            btnSwitchTable.Location = new Point(3, 0);
            btnSwitchTable.Name = "btnSwitchTable";
            btnSwitchTable.Size = new Size(107, 38);
            btnSwitchTable.TabIndex = 0;
            btnSwitchTable.Text = "Chuyển bàn";
            btnSwitchTable.UseVisualStyleBackColor = true;
            btnSwitchTable.Click += btnSwitchTable_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinTàiKhoảnToolStripMenuItem, chwcToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(879, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(67, 24);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinCáNhânToolStripMenuItem, đăngXuấtToolStripMenuItem });
            thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            thôngTinTàiKhoảnToolStripMenuItem.Size = new Size(151, 24);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            thôngTinCáNhânToolStripMenuItem.Size = new Size(210, 26);
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            thôngTinCáNhânToolStripMenuItem.Click += thôngTinCáNhânToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(210, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // chwcToolStripMenuItem
            // 
            chwcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thêmMónToolStripMenuItem, thanhToánToolStripMenuItem });
            chwcToolStripMenuItem.Name = "chwcToolStripMenuItem";
            chwcToolStripMenuItem.Size = new Size(93, 24);
            chwcToolStripMenuItem.Text = "Chức năng";
            // 
            // thêmMónToolStripMenuItem
            // 
            thêmMónToolStripMenuItem.Name = "thêmMónToolStripMenuItem";
            thêmMónToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            thêmMónToolStripMenuItem.Size = new Size(217, 26);
            thêmMónToolStripMenuItem.Text = "Thêm món";
            thêmMónToolStripMenuItem.Click += thêmMónToolStripMenuItem_Click;
            // 
            // thanhToánToolStripMenuItem
            // 
            thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            thanhToánToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            thanhToánToolStripMenuItem.Size = new Size(217, 26);
            thanhToánToolStripMenuItem.Text = "Thanh toán";
            thanhToánToolStripMenuItem.Click += thanhToánToolStripMenuItem_Click;
            // 
            // formTableManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 639);
            Controls.Add(pnlBottomRight);
            Controls.Add(pnlBill);
            Controls.Add(pnlTopRight);
            Controls.Add(flpTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "formTableManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hai Dang Coffe";
            FormClosing += formTableManager_FormClosing;
            pnlTopRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).EndInit();
            pnlBill.ResumeLayout(false);
            pnlBottomRight.ResumeLayout(false);
            pnlBottomRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpTable;
        private Panel pnlTopRight;
        private Panel pnlBill;
        private Panel pnlBottomRight;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private NumericUpDown nmFoodCount;
        private Button btnAddFood;
        private ComboBox cmbFood;
        private ComboBox cmbCategory;
        private ListView lsvBill;
        private Button btnCheckOut;
        private Button btnDiscount;
        private Button btnSwitchTable;
        private ComboBox cmbSwitchTable;
        private NumericUpDown numericUpDown1;
        private ColumnHeader l;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private TextBox txtTotalPrice;
        private ToolStripMenuItem chwcToolStripMenuItem;
        private ToolStripMenuItem thêmMónToolStripMenuItem;
        private ToolStripMenuItem thanhToánToolStripMenuItem;
    }
}
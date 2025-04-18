using Microsoft.Identity.Client;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class formTableManager : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public formTableManager(AccountDTO loginAccount)
        {
            this.loginAccount = loginAccount;
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cmbSwitchTable);
            LoginAccount = loginAccount;
        }

        #region Methods
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + loginAccount.DisplayName + ")";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table table in tableList)
            {
                Button btn = new Button() { Width = TableDAO.w, Height = TableDAO.h };
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += btn_Click;
                btn.Tag = table;
                switch (table.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.Aquamarine;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void LoadCategory()
        {
            List<Category> categories = CategoryDAO.Instances.GetCategoryList();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
        }

        void LoadFood(int id)
        {
            List<Food> foods = FoodDAO.Instances.GetFoodListByCategoryID(id);
            cmbFood.DataSource = foods;
            cmbFood.DisplayMember = "Name";
        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        void ShowBill(int id)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            lsvBill.Items.Clear();
            List<Menu> menu = MenuDAO.Instances.GetAll(id);
            float totalPrice = 0;
            foreach (Menu item in menu)
            {
                ListViewItem lstItem = new ListViewItem(item.FoodName.ToString());
                lstItem.SubItems.Add(item.Count.ToString());
                lstItem.SubItems.Add(item.Price.ToString("c"));
                lstItem.SubItems.Add(item.TotalPrice.ToString("c"));
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lstItem);
            }
            txtTotalPrice.Text = totalPrice.ToString("c");
        }

        #endregion

        #region Events

        private void formTableManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void btn_Click(object? sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(idTable);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Close();
            f.ShowDialog();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e) => thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = loginAccount;
            f.InsertFood += F_InsertFood;
            f.UpdateFood += F_UpdateFood;
            f.DeleteFood += F_DeleteFood;
            f.ShowDialog();
        }

        private void F_DeleteFood(object? sender, EventArgs e)
        {
            LoadFood((cmbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
            LoadTable();
        }

        private void F_UpdateFood(object? sender, EventArgs e)
        {
            LoadFood((cmbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void F_InsertFood(object? sender, EventArgs e)
        {
            LoadFood((cmbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void cmbFood_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFood(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Chọn bàn để thêm món");
                return;
            }
            int idBill = BillDAO.Instances.getUnCheckOutBillIdByTableId(table.ID);
            int idFood = (cmbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;
            if (idBill == -1)
            {
                BillDAO.Instances.Insert(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instances.GetMaxIDBill(), idFood, count);
            }

            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }


        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instances.getUnCheckOutBillIdByTableId(table.ID);
            int discount = (int)numericUpDown1.Value;
            double totalPrice = Convert.ToDouble(txtTotalPrice.Text.Split(' ')[0]);
            double finalTotalPrice = totalPrice - (totalPrice * discount) / 100;
            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Check out for  {0} ? \n TotalPrice: {1} \n Discount: {2} \n FinalTotalPrice: {3}", table.Name, totalPrice, discount, finalTotalPrice), "Question ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BillDAO.Instances.CheckOut(idBill, discount, (float)finalTotalPrice);
                }
                ShowBill(table.ID);
                LoadTable();
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {

            int idFromTable = (lsvBill.Tag as Table).ID;
            int idDesTable = (cmbSwitchTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Switch table{0} to table {1} ?", ((lsvBill.Tag as Table).Name), (cmbSwitchTable.SelectedItem as Table).Name), "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(idFromTable, idDesTable);
                LoadTable();
            }
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }
        
        #endregion

    }
}

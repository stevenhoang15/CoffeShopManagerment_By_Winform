using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();

        public AccountDTO loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }
        #region Methods
        void Load()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            LoadDatePicker();
            GetListBillByDate(dtpkFromDay.Value, dtpkToDay.Value);
            LoadListFood();
            LoadListAccount();
            LoadListCategoryForDataGridView();
            LoadListTable();
            AddFoodBinding();
            AddAccountBinding();
            AddCategoryBinding();
            AddTableBinding();
            LoadListCategory(cmbCategory);
        }

        void AddCategoryBinding()
        {
            txbCategoryId.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void AddFoodBinding()
        {
            txtBoxFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtBoxFoodId.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "id", true, DataSourceUpdateMode.Never));
            nmrFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txbAccountType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            txbIdTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadDatePicker()
        {
            DateTime toDay = DateTime.Now;
            dtpkFromDay.Value = new DateTime(toDay.Year, toDay.Month, 1);
            if (toDay.Month == 7)
            {
                dtpkToDay.Value = dtpkFromDay.Value.AddMonths(1);
            }
            dtpkToDay.Value = dtpkFromDay.Value.AddMonths(1).AddDays(-1);
        }

        void GetListBillByDate(DateTime dayFrom, DateTime dayTo)
        {
            dtgvBill.DataSource = BillDAO.Instances.GetListBillByDate(dayFrom, dayTo);
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instances.GetListFood();
        }

        void LoadListCategory(ComboBox cmb)
        {
            cmb.DataSource = CategoryDAO.Instances.GetCategoryList();
            cmb.DisplayMember = "Name";
        }

        void LoadListCategoryForDataGridView()
        {
            categoryList.DataSource = CategoryDAO.Instances.GetCategoryList();
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> foods = new List<Food>();
            foods = FoodDAO.Instances.SearchFoodByName(name);
            return foods;
        }

        void LoadBillByDateAndPage(DateTime dayFrom, DateTime dayTo, int pageNum)
        {
            dtgvBill.DataSource = BillDAO.Instances.GetListBillByDateAndPage(dayFrom, dayTo, pageNum);
        }

        void ExportReport(DataGridView dataGridView, string filePath)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.Add("Report");
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value;
                    }
                }

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }
        #endregion

        #region Events
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            GetListBillByDate(dtpkFromDay.Value, dtpkToDay.Value);
        }
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void txtBoxFoodId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                    Category category = CategoryDAO.Instances.GetCategoryById(id);
                    cmbCategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cmbCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cmbCategory.SelectedIndex = index;
                }
            }
            catch { }
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {

            string name = txtBoxFoodName.Text;
            int idCategory = (cmbCategory.SelectedItem as Category).ID;
            float price = (float)nmrFoodPrice.Value;
            if (FoodDAO.Instances.InsertFood(name, idCategory, price))
            {
                MessageBox.Show("Thêm mới món ăn thành công.");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm món ăn mới thất bại.");
            }
        }
        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBoxFoodId.Text);
            string name = txtBoxFoodName.Text;
            int idCategory = (cmbCategory.SelectedItem as Category).ID;
            float price = (float)nmrFoodPrice.Value;
            if (FoodDAO.Instances.UpdateFood(id, name, idCategory, price))
            {
                MessageBox.Show("Sửa món ăn thành công.");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa món ăn thất bại.");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(txtBoxFoodId.Text);
            if (FoodDAO.Instances.DeleteFood(idFood))
            {
                MessageBox.Show("Xóa món ăn thành công");
                LoadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa món ăn");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Food> f = SearchFoodByName(txbFoodNameSearch.Text);
            foodList.DataSource = f;
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = Convert.ToInt32(txbAccountType.Text);
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Insert account successfully");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Cannot insert account");
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            int type = Convert.ToInt32(txbAccountType.Text);
            if (AccountDAO.Instance.UpdateAccount(userName, type))
            {
                MessageBox.Show("Update account successfully");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Cannot update account");
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Cannot delete the current account");
                return;
            }

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Delete account successfully");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Cannot delete account");
            }
        }

        private void btnResetAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Reset password successfully");
            }
            else
            {
                MessageBox.Show("Cannot reset password");
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            txtPageNumber.Text = "1";
            dtgvBill.DataSource = BillDAO.Instances.GetListBillByDateAndPage(dtpkFromDay.Value, dtpkToDay.Value, Convert.ToInt32(txtPageNumber.Text));
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            DateTime dayFrom = dtpkFromDay.Value;
            DateTime dayTo = dtpkToDay.Value;
            int billCounter = BillDAO.Instances.GetNumBillByDate(dayFrom, dayTo);
            int lastPage = billCounter / 10;
            if (billCounter % 10 != 0)
            {
                lastPage++;
            }
            txtPageNumber.Text = lastPage.ToString();
        }

        private void btnPrevioursPage_Click(object sender, EventArgs e)
        {
            int pageNum = Convert.ToInt32(txtPageNumber.Text);
            if (pageNum > 1)
            {
                pageNum--;
            }

            txtPageNumber.Text = pageNum.ToString();
        }



        private void txtPageNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvBill.DataSource = BillDAO.Instances.GetListBillByDateAndPage(dtpkFromDay.Value, dtpkToDay.Value, Convert.ToInt32(txtPageNumber.Text));
            }
            catch { }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            int pageNum = Convert.ToInt32(txtPageNumber.Text);
            int billCounter = BillDAO.Instances.GetNumBillByDate(dtpkFromDay.Value, dtpkToDay.Value);
            int lastPage = billCounter / 10;
            if (billCounter % 10 != 0)
            {
                lastPage++;
            }
            if (pageNum < lastPage)
            {
                pageNum++;
            }

            txtPageNumber.Text = pageNum.ToString();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save an excell file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportReport(dtgvBill, filePath);
                MessageBox.Show("Export report successfully");
            }
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategoryForDataGridView();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryId.Text);
            string name = txbCategoryName.Text;
            try
            {
                if (CategoryDAO.Instances.InsertCategory(name))
                {
                    MessageBox.Show("Insert Category Succesfully");
                    LoadListCategoryForDataGridView();
                    LoadListCategory(cmbCategory);
                }
                else
                {
                    MessageBox.Show("Cannot insert category");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot insert duplicate name category");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryId.Text);
            if (CategoryDAO.Instances.DeleteCategory(id))
            {
                MessageBox.Show("Delete category succesfully");
                LoadListCategoryForDataGridView();
                LoadListFood();
                LoadListCategory(cmbCategory);
            }
            else
            {
                MessageBox.Show("Cannot delete category");
            }
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryId.Text);
            if (CategoryDAO.Instances.UpdateCategory(id, name))
            {
                MessageBox.Show("Update category successfully");
                LoadListCategoryForDataGridView();
                LoadListFood();
                LoadListCategory(cmbCategory);
            }
            else
            {
                MessageBox.Show("Cannot update category");
            }
        }

        private void btnAccountSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorySearch_Click(object sender, EventArgs e)
        {
            string key = txbCategoryNameSearch.Text;
            if (key != null)
            {
                categoryList.DataSource = CategoryDAO.Instances.SearchCategory(key);
            }
            else
            {
                MessageBox.Show("Enter name category");
            }

        }

        private void txbIdTable_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Insert table successfully");
                LoadListTable();
            }

            else
            {
                MessageBox.Show("Cannot insert table");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIdTable.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Delete table successfully");
                LoadListTable();
            }
            else
            {
                MessageBox.Show("Check out before delete table, please");
            }
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            int id = Convert.ToInt32(txbIdTable.Text);
            if (TableDAO.Instance.UpdateTable(id, name))
            {
                MessageBox.Show("Update table successfully");
                LoadListTable();
            }

            else
            {
                MessageBox.Show("Cannot update table");
            }
        }

        private event EventHandler insertFood;
        private event EventHandler updateFood;
        private event EventHandler deleteFood;

        public event EventHandler InsertFood
        {
            add
            {
                insertFood += value;
            }

            remove
            {
                insertFood -= value;
            }
        }

        public event EventHandler UpdateFood
        {
            add
            {
                updateFood += value;
            }

            remove
            {
                updateFood -= value;
            }
        }

        public event EventHandler DeleteFood
        {
            add
            {
                deleteFood += value;
            }

            remove
            {
                deleteFood -= value;
            }
        }


        #endregion

    }
}

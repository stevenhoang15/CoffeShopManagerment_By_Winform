using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Data;
using System.Diagnostics;

namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void label1_Click_1(object sender, EventArgs e)
        //{

        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtBoxUserName.Text;
            string password = txtBoxUserPassword.Text;
            if(CheckLogin(userName, password))
            {
                AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                formTableManager f = new formTableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không hợp lệ");
            }           
        }

        public bool CheckLogin(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
    }
}

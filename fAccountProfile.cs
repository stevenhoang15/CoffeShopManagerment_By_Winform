using Microsoft.Identity.Client.NativeInterop;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fAccountProfile : Form
    {
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; ChangeAccount(); }
        }

        public fAccountProfile(AccountDTO account)
        {
            InitializeComponent();
            LoginAccount = account;
        }
        public void ChangeAccount()
        {
            txtDisplayName.Text = loginAccount.DisplayName;
            txtUserName.Text = loginAccount.UserName;
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; } 
            remove { updateAccount -= value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string displayName = txtDisplayName.Text;
            string newPass = textBox1.Text;
            string reenterNewPass = textBox2.Text;

            if (!newPass.Equals(reenterNewPass))
            {
                MessageBox.Show("Incorrect Password and Reenter Newpassword");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName, displayName, password, newPass)) 
                {
                    MessageBox.Show("Update account successfully");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
        }
    }
    public class AccountEvent : EventArgs
    {
        private AccountDTO acc;

        public AccountDTO Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(AccountDTO acc)
        {
            this.Acc = acc;
        }
    }
}

using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value; 
        }

        private AccountDAO () { }

        public string EncodPassword(string password)
        {
            string hasPass = " ";
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] hasData = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach(byte item in hasData)
                {
                    sb.Append(item.ToString("x2"));
                    hasPass = sb.ToString();
                }
            }
            return hasPass;
        }
       
        public bool Login(string username, string password)
        {
            string hasPass = EncodPassword(password);
            DataTable data = new DataTable();
            string query = "select * from Account a where a.UserName = @userName and a.PassWord = @password";
            data = DataProvider.Instance.ExcuteQuery(query, new object[] { username, hasPass});
            return (data.Rows.Count > 0);
        }

        public AccountDTO GetAccountByUserName(string userName)
        {
            string query = "select * from Account where UserName = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                return new AccountDTO(row);
            }
            return null;
        }

        public bool UpdateAccount(string userName, string displayName, string password, string newPassword)
        {
            string hasPass = EncodPassword(password);
            string newHasPass = EncodPassword(newPassword);
            string query = "exec usp_UpdateAccount @userName , @displayName , @password , @newPassword";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName, displayName, hasPass, newHasPass });
            return (result > 0);
        }

        public DataTable GetListAccount()
        {
            string query = "select UserName, DisplayName, type from Account";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public int GetAccountTypeByUserName(string userName)
        {
            int type = 0;
            string query = "select type from Account where UserName = " + userName;

            return 0;
        }

        public bool InsertAccount(string userName, string displayName, int type, string password = "202cb962ac59075b964b07152d234b70")
        {
            string query = String.Format("INSERT INTO [dbo].[Account] ([UserName] , [DisplayName] , [Type], [Password]) VALUES(N'{0}' , N'{1}' , {2}, N'{3}')", userName, displayName, type, password);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool UpdateAccount(string userName, int type)
        {
            string query = String.Format("UPDATE [dbo].[Account] SET [type] = {0} WHERE UserName = N'{1}'", type, userName);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool DeleteAccount(string userName)
        {
            int results = 0;
            string query = String.Format("delete [dbo].[Account] WHERE UserName = N'{0}'", userName);
            results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool ResetPassword(string userName)
        {
            int results = 0;
            string query = String.Format("UPDATE [dbo].[Account] SET [password] = N'{0}' WHERE UserName = N'{1}'", "202cb962ac59075b964b07152d234b70", userName);
            results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class AccountDTO
    {
        public AccountDTO(string userName, string displayName, int type, string password) 
        { 
            this.DisplayName = displayName;
            this.UserName = userName;
            this.Password = password;
            this.Type = type;
        }

        public AccountDTO(DataRow row)
        {
            this.DisplayName = row["displayName"].ToString();
            this.UserName = row["userName"].ToString();
            this.Password = row["password"].ToString();
            this.Type = (int)row["type"];
        }


        private string userName;
        private string password;
        private string displayName;
        private int type;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }
    }
}

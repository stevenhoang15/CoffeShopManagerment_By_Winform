using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        public Table(int id, string name, string status)
        {
            this.iD = id;
            this.name = name;
            this.status = status;
        }

        public Table (DataRow row)
        {
            this.iD = (int)row["iD"];
            this.name = row["name"].ToString();
            this.status = (string)row["status"];    
        }

        private string status;

        private int iD;

        private string name;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}

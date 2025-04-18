using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            set => instance = value; 
        }

        private TableDAO() { }

        public static int w = 90;
        public static int h = 90;

        public void SwitchTable(int idFromTable, int idDesTable)
        {
            DataProvider.Instance.ExcuteQuery("exec usp_SwitchTable @idFromTable , @idDesTable", new object[] {idFromTable, idDesTable});
        }

        public List<Table> LoadTableList()
        {
            List<Table> table = new List<Table>();
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExcuteQuery("exec usp_GetTableList");
            foreach (DataRow row in data.Rows)
            {
                Table itiem = new Table(row);
                table.Add(itiem);
            }
            
            return table;
        }

        public bool InsertTable(string name)
        {
            string query = String.Format("INSERT INTO [dbo].[TableFood] ([name] ,[status]) VALUES (N'{0}',N'Trong')", name);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool DeleteTable(int id)
        {
            string query = String.Format("delete TableFood where id = {0}", id);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool UpdateTable(int id, string name)
        {
            string query = String.Format("update TableFood set name = N'{0}' where id = {1}", name, id);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }
    }
}

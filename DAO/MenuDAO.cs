using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instances;

        private MenuDAO() { }

        public static MenuDAO Instances 
        {   get { if (instances == null) instances = new MenuDAO(); return instances; } 
            set => instances = value; 
        }

        public List<Menu> GetAll(int id)
        {
            List<Menu> list = new List<Menu>();
            string query = "select f.name, bi.count, f.price, f.price*bi.count as totalPrice from Bill b, BillInfo bi, Food f where bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable = @id";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] {id});
            foreach (DataRow row in data.Rows)
            {
                Menu menu = new Menu(row);
                list.Add(menu);
            }
            return list;
        }
    }
}

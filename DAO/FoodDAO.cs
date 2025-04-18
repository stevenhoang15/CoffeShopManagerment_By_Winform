using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private FoodDAO() { }
        private static FoodDAO instances;

        public static FoodDAO Instances 
        {   get { if (instances == null) instances = new FoodDAO(); return instances; }
            private set => instances = value; 
        }

        public List<Food> GetFoodListByCategoryID(int id)
        {
            List<Food> foods = new List<Food>();
            string query = "select * from Food where idCategory = @id ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] {id});
            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                foods.Add(food);
            }
            return foods;
        }

        public List<Food> GetListFood()
        {
            List<Food> foods = new List<Food>();
            string query = "select * from Food";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Food f = new Food(row);
                foods.Add(f);
            }
            return foods;
        }

        public bool InsertFood(string name, int idCategory, float price)
        {
            string query = String.Format("INSERT INTO [dbo].[Food] ([name] , [idCategory] , [price]) VALUES(N'{0}' , {1} , {2})", name , idCategory , price );
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool UpdateFood(int id, string name, int idCategory, float price)
        {
            string query = String.Format("UPDATE [dbo].[Food] SET [name] = N'{0}' ,[idCategory] = {1}, [price] = {2} WHERE id = {3}", name, idCategory, price, id);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool DeleteFood(int id) 
        {
            int results = 0;
            BillInfoDAO.Instance.DeleteBillInfoByFoodId(id);
            string query = String.Format("delete [dbo].[Food] WHERE id = {0}", id);
            results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> foods = new List<Food>();
            string query = string.Format("select * from Food where dbo.fuConvertToUnsign1(name) like dbo.fuConvertToUnsign1(N'%{0}%')", name);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Food f = new Food(row);
                foods.Add(f);
            }
            return foods;
        }


    }
}

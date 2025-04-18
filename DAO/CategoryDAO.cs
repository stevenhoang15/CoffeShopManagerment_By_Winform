using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instances;

        public static CategoryDAO Instances 
        {   get { if (instances == null) instances = new CategoryDAO(); return instances; }
            private set => instances = value; 
        }

        private CategoryDAO() { }

        public List<Category> GetCategoryList()
        {
            List<Category> categories = new List<Category>();
            string query = "select * from FoodCategory";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Category category = new Category(row);
                categories.Add(category);
            }
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category c = null;
            string query = "select * from FoodCategory where id = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                c = new Category(row);
            }
            return c;
        }

        public bool InsertCategory(string name)
        {
            string query = String.Format("INSERT INTO [dbo].[FoodCategory] VALUES (N'{0}')", name);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public bool DeleteCategory(int id)
        {
            string query = "usp_DeleteCategory @idCategory";
            int results = DataProvider.Instance.ExcuteNonQuery(query, new object[] { id });
            return results > 0;
        }

        public bool UpdateCategory(int id, string name)
        {
            string query = String.Format("update FoodCategory set name = N'{0}' where id = {1}", name, id);
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }

        public List<Category> SearchCategory(string key)
        {
            List<Category> categories = new List<Category>();
            string query = String.Format("select * from FoodCategory where [dbo].[fuConvertToUnsign1](name) like [dbo].[fuConvertToUnsign1](N'%{0}%')", key);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Category category = new Category(row);
                categories.Add(category);
            }
            return categories;
        }
    }
}

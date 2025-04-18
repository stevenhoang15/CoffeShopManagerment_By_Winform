using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        { 
            get { if (instance == null) instance = new BillInfoDAO(); return instance; } 
            set => instance = value; 
        }

        public bool DeleteBillInfoByFoodId(int id)
        {
            string query = "delete BillInfo where idFood = " + id;
            int results = DataProvider.Instance.ExcuteNonQuery(query);
            return results > 0;
        }
        private BillInfoDAO() { }

        public List<BillInfor> getLstBillInfo(int id)
        {
            List<BillInfor> lstBillInfo = new List<BillInfor>();
            string query = "select * from BillInfo where idBill = @id";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] {id});
            foreach (DataRow dr in data.Rows)
            {
                BillInfor billInfo = new BillInfor(dr);
                lstBillInfo.Add(billInfo);
            }
            return lstBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            string query = "exec usp_InsertBillInfo @idBill , @idFood , @count";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] {idBill, idFood, count});
        }
    }
}

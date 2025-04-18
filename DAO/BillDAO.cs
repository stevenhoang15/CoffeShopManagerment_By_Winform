using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instances;
        public static BillDAO Instances 
        {
            get { if (instances == null) instances = new BillDAO(); return instances; } 
            set => instances = value; 
        }

        private BillDAO() { }

        public int getUnCheckOutBillIdByTableId(int tableId) 
        {
            string query = "select * from Bill where idTable = @tableId and status = 0";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { tableId });
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }

        public void Insert(int idTable)
        {
            string query = "exec usp_InsertBill @idTable";
            DataProvider.Instance.ExcuteNonQuery(query, new object[] { idTable });
        }

        public void CheckOut(int idBill, int discount, float totalPrice)
        {
            string query = "update Bill set status = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice + ", DateCheckOut = GETDATE()" + "where id = " + idBill;
            DataProvider.Instance.ExcuteQuery(query);
        }

        public DataTable GetListBillByDate (DateTime dayFrom, DateTime dayTo)
        {
            DataTable dt = new DataTable();
            string query = "exec usp_LoadBill @dayFrom , @dayTo";
            dt = DataProvider.Instance.ExcuteQuery(query, new object[] { dayFrom, dayTo });
            return dt;
        }

        public DataTable GetListBillByDateAndPage(DateTime dayFrom, DateTime dayTo, int pageNum)
        {
            DataTable dt = new DataTable();
            string query = "exec USP_GetListBillByDateAndPage @dayFrom , @dayTo , @pageNum";
            dt = DataProvider.Instance.ExcuteQuery(query, new object[] {dayFrom, dayTo,  pageNum});
            return dt;
        }

        public int GetNumBillByDate(DateTime dayFrom, DateTime dayTo)
        {
            string query = "exec USP_GetNumBillByDate @dayFrom , @dayTo";
            int n = (int) DataProvider.Instance.ExcuteScalar(query, new object[] {dayFrom, dayTo});
            return n;
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}

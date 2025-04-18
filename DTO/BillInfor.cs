using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfor
    {
        public BillInfor(int iD, int idBill, int idFood, int count) 
        { 
            this.iD = iD;
            this.idBill = idBill;
            this.idFood = idFood;
            this.count = count;
        }

        public BillInfor(DataRow row)
        {
            this.iD = (int)row["iD"];
            this.idBill = (int)row["idBill"];
            this.idFood = (int)row["idFood"];
            this.count = (int)row["count"];
        }

        private int iD;
        private int idBill;
        private int idFood;
        private int count;
        public int ID { get => iD; set => iD = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int Count { get => count; set => count = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public Bill(int iD, DateTime dateCheckIn, DateTime? dateCheckOut, int status, int discount) 
        { 
            this.ID = iD;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["iD"];
            this.DateCheckIn = (DateTime)row["dateCheckIn"];
            var dateCheckOutTemp = row["dateCheckOut"];
            if(dateCheckOutTemp.ToString() != null )
            {
                this.DateCheckOut = (DateTime?)dateCheckOut;
            }
           
            this.Status = (int)row["status"];
            this.Discount = (int)row["discount"];
        }

        private int discount;

        private int status;
        
        private DateTime? dateCheckOut;
        
        private DateTime dateCheckIn;
        
        private int iD;
        public int ID { get => iD; set => iD = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        private string connectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyQuanCafe;Integrated Security=True;Trust Server Certificate=True";

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value;
        }

        private DataProvider() { }

        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPa = query.Split(' ');
                    int i = 0;
                    foreach (string s in listPa)
                    {
                        if (s.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(s, parameter[i++]);
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);
                connection.Close();
            }

            return data;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPa = query.Split(" ");
                    int i = 0;
                    foreach (string s in listPa)
                    {
                        if (s.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(s, parameter[i++]);
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = null;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] lstPa = query.Split(" ");
                    int i = 0;
                    foreach(string s in lstPa)
                    {
                        if (s.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(s, parameter[i++]);
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}

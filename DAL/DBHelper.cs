using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace DAL
{
    public class DBHelper
    {

        /*
         * 链接sql数据库
         */
        public static string  getConn() {
            string strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            return strConn;
        }

        public static DataTable getDt(string strSQL)
        {
            SqlConnection conn = new SqlConnection(getConn());
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strSQL,conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
         
        public static void Getdt(string strSQL)
        {
            SqlConnection conn = new SqlConnection(getConn());
            conn.Open();

            SqlCommand cmd = new SqlCommand(strSQL,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }



        /*
         *读取Excel表 
         */
        public static DataTable getExcle(string url)
        {
            string strConn = "provider=Microsoft.ACE.OLEDB.12.0;data source='" + url + "';Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();

            DataTable tableName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });//得到所以sheet的名字
            string firstSheetName = tableName.Rows[0][2].ToString();//得到第一个sheet表名

            string strSQL = string.Format(("SELECT * FROM [{0}]"),firstSheetName);
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();

            return ds.Tables[0];
        }

        private static DataTable GetExcelTableName(string v)
        {
            throw new NotImplementedException();
        }

        /*
         *批量导入excel数据到数据库
         */
        public static void SQLBulkCopy(DataTable dt,string table1)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = table1;
                    for (int i = 0; i < 13; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Rows[0][i].ToString());
                    }//对应表导入
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        //外聘教师
        public static void waiteaSQLBulkCopy(DataTable dt, string table1)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = table1;
                    for (int i = 0; i < 14; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Rows[0][i].ToString());
                    }//对应表导入
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        //外聘教师导入到全校教师
        public static void waipinTea(DataTable dt, string table1)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = table1;
                    for (int i = 0; i < 9; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Rows[0][i].ToString());
                    }//对应表导入
                    bulkCopy.WriteToServer(dt);
                }
            }
        }


        /*
         *系部数据导入（初始信息）
         */
        public static void xibu(DataTable dt, string table1)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = table1;
                    for (int i = 0; i < 15; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Rows[0][i].ToString());
                    }//对应表导入
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        public static void Loubaochaxun(DataTable dt, string table1)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = table1;
                    for (int i = 0; i <6; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }//对应表导入
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        public static void Loubaochaxun1(DataTable dt, string table1)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = table1;
                    for (int i = 0; i < 7; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        /*
         * 拆分初始数据
         */
        //插入数据
        public static void sqlbl(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = "考勤课程";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }//对应表导入
                    bulkCopy.WriteToServer(dt);
                }
            }
        }

        //录入考勤基础数据
        public static void datakaoqin(DataTable dt,string ta)
        {
            using (SqlConnection conn = new SqlConnection(getConn()))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = ta;
                    for (int i = 0; i < 11; i++)
                    {
                        bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
    }
}

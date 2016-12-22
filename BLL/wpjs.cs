using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class wpjs
    {
        public static void rowupdate(string stuname, string stuid, string week, string kecheng)
        {

            string SQL = "update 外聘教师 set " + stuname + "='" + stuid + "'where " + week + "'";
            DBHelper.Getdt(SQL);

        }
        public static void rowdelete(string id, string key)
        {
            string SQL = "delete from 外聘教师 where " + id + "='" + key + "'";
            DBHelper.Getdt(SQL);
        }
        public static DataTable find()
        {
            string SQL = "select * from 外聘教师";
            DataTable dt = DBHelper.getDt(SQL);
            return dt;
        }
        public static DataTable Griview(string column, string name)
        {
            string SQL = "select * from 外聘教师 where " + column + "='" + name + "'";

            DataTable dt = DBHelper.getDt(SQL);
            return dt;

        }
    }
}

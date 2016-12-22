using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class jsqk
    {
        public static void rowupdate(string role, string struserrole, string userid, string struserid,string zc,string xq,string jc,string kc)
        {

            string SQL = "update 录入考勤 set " + role + "='" + struserrole + "' where " + userid + "='" + struserid + "' and 周次='"+zc+"' and 星期='"+xq+"' and 节次='"+jc+"' and 课程='"+kc+"'";
            DBHelper.Getdt(SQL);

        }
        //public static void rowdelete(string id, string key)
        //{
        //    string SQL = "delete from 录入考勤 where " + id + "='" + key + "'";
        //    DBHelper.Getdt(SQL);
        //}
        public static DataTable find()
        {
            string SQL = "select * from 录入考勤";
            DataTable dt = DBHelper.getDt(SQL);
            return dt;
        }
        public static DataTable Griview(string column, string name)
        {
            string SQL = "select * from 录入考勤 where " + column + "='" + name + "'";

            DataTable dt = DBHelper.getDt(SQL);
            return dt;

        }
    }
}

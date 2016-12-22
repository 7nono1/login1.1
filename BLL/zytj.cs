using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
     public  class zytj
    {
        public static DataTable getWork(string department)
        {
            String strSQL = "SELECT distinct 系部,学号,姓名,周次,星期,节次 FROM 考勤课程 WHERE 系部='" + department + "'AND 是否考勤<>'完成'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getWork1(string ID)
        {
            String strSQL = "SELECT 系部,学号,姓名,周次,星期,节次 FROM 考勤课程 WHERE 学号='" + ID + "'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getWorkTable()
        {
            String strSQL = "SELECT  distinct 系部,学号,姓名,未完成作业次数 FROM 作业统计121";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getWorkTable(string selectIndex, string selectIndex1)
        {
            String strSQL = "SELECT  distinct 系部,学号,姓名,未完成作业次数 FROM 作业统计121 WHERE "+selectIndex+"='"+selectIndex1+"'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }

 

        public static DataTable getWorkTable1(string selectIndex, string selectIndex1)
        {
            String strSQL = "SELECT  系部,学号,姓名,未完成作业次数 FROM 作业统计121 WHERE " + selectIndex + "='" + selectIndex1 + "'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static void getWork()
        {
            DAL.DBHelper.getDt("DELETE FROM 作业统计121");

        }
      
        public static DataTable setWork()
        {
            string str = "select distinct 系部,学号,姓名,周次,星期,节次, 未完成作业次数=COUNT(*) over (partition by 姓名) from  作业统计121 order by 姓名";
            return DAL.DBHelper.getDt(str);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class kaoqin
    {
        public static DataTable GetDatatableBySQL1(string TeacherID, string CurrentWeek)
        {
            string sql = "select 星期,节次,课程,工号,教师姓名,周次 from 录入考勤   where 工号='" + TeacherID + "' AND 周次='" + CurrentWeek + "'";
            DataTable dt = DAL.DBHelper.getDt(sql);
            return dt;
        }
      

        public static bool InsertTabTeachers(string w,string v1,string l,string k,string j,string x,string id)
        {
            try
            {
                string strSQL = "UPDATE  考勤课程  SET 出勤 = '"+v1+"' WHERE 周次='"+w+"' AND 学号='"+id+"'AND 课程='"+k+"' AND 节次='"+j+"'AND 星期='"+x+"'";
                DBHelper.Getdt(strSQL);
                string str = "UPDATE 录入考勤 SET 是否考勤='是' WHERE 周次='" + w + "' AND 工号='" + l + "' AND 课程='" + k + "' AND 节次='" + j + "'AND 星期='" + x + "'";
                DBHelper.Getdt(str);
                string str1 = "UPDATE 考勤课程 SET 是否考勤='是' WHERE 周次='" + w + "' AND 工号='" + l + "' AND 课程='" + k + "' AND 节次='" + j + "'AND 星期='" + x + "'";
                DBHelper.Getdt(str1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable Loadused(string ID,string Swe,string Currwork,string j,string Week)
        {
            string sql = "select 系部,行政班级,学号,姓名 from 考勤课程 WHERE 工号='"+ID+"' AND 周次='"+Swe+"' AND 课程='"+Currwork+"' AND 节次='"+j+"' AND 星期='"+Week+"'";
            DataTable dt = DBHelper.getDt(sql);
            return dt;
        }

        public static DataTable loadjilu(string id,string week)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < Convert.ToInt32(week); i++)
            {
                string sql = "select 课程,周次,星期,节次,地点,是否考勤,布置作业 from 录入考勤 where 工号='" + id + "' and 周次='" + i.ToString() + "'";
                dt.Merge(DBHelper.getDt(sql));
            }
            return dt;
        }

        
    }
}

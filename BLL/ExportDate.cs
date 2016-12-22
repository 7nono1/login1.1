using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class ExportDate
    {
        //查询学生缺勤情况
        public static System.Data.DataTable stukaoqin(string wherew)
        {
            string strSQL = "SELECT 系部,学号,姓名,周次,出勤,星期,节次,课程号,课程,地点,上课班级名称,行政班级 FROM 考勤课程"+wherew;
            System.Data.DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        //查询教师漏报情况
        public static System.Data.DataTable tealoubao(string wherew)
        {
            string strSQL = "SELECT * FROM 漏报分析" + wherew;
            System.Data.DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        //查询学生作业情况
        public static System.Data.DataTable stuzuoye(string wherew)
        {
            string strSQL = "SELECT 系部,学号,姓名,周次,作业,星期,节次,课程号,课程,地点,上课班级名称,行政班级 FROM 考勤课程" + wherew;
            System.Data.DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        //查询教师作业情况
        public static System.Data.DataTable teazuoye(string wherew)
        {
            string strSQL = "SELECT 承担单位,工号,教师姓名,课程号,课程,星期,周次,节次,地点,布置作业 FROM 录入考勤" + wherew;
            System.Data.DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
    }
}

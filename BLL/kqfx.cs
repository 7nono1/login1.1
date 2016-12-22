using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class kqfx
    {
        public static DataTable initialDatattable()
        {


            double good = 0;
            double Attendance = 0;
            double School = 0;
            deleteTacher();
            string[] allDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i == 0)
                    {
                        good = 0;
                        Attendance = 0;
                        School = 0;
                        good = getTeacher(allDepartment[j], i, "是").Rows.Count + good;
                        Attendance = getTeacher(allDepartment[j], i, "否").Rows.Count + Attendance;
                    }
                    else
                    {
                        good = getTeacher(allDepartment[j], i, "是").Rows.Count + good;
                        Attendance = getTeacher(allDepartment[j], i, "否").Rows.Count + Attendance;
                    }
                }
                School = good  + Attendance ;
                double Attendance1 = Attendance / School;
               getTacher(allDepartment[j], (int)School,(int)Attendance, Attendance1.ToString());

            }
            DataTable dt = getTacher();
            return dt;
        }
        public static DataTable getTeacher(string department,int week,string finish)
        {
         
         return    DAL.DBHelper.getDt("SELECT * FROM  录入考勤 WHERE  承担单位='" + department + "'AND 周次='" + week + "'AND 是否考勤 ='"+finish+"'");

        }
        public static DataTable getTeacher(string department, int week)
        {

            return DAL.DBHelper.getDt("SELECT * FROM  录入考勤 WHERE  承担单位='" + department + "'AND 周次='" + week + "'AND 是否考勤<>'是'");

        }
        public static void getTacher(string department,int School, int noFinish,string finish)
        {
            DAL.DBHelper.Getdt("INSERT INTO 考勤记录(系部,老师考勤总次数,未考勤次数,未考勤率)VALUES('" + department + "','" + School + "','" + noFinish + "','" + finish + "') ");
        }
        public static DataTable getTacher()
        {
           return DAL.DBHelper.getDt("select * from 考勤记录");
        }
        public static void deleteTacher()
        {
            DAL.DBHelper.Getdt("DELETE FROM 考勤记录 ");
        }
    }
}

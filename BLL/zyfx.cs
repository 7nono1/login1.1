using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class zyfx
    {
        public static DataTable initialDatattable()
        {


            double good = 0;
            double Attendance = 0;
            double School = 0;
            deleteWork();
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
                        good = getWork(allDepartment[j], i, "完成").Rows.Count + good;
                        Attendance = getWork(allDepartment[j], i, "未完成").Rows.Count + Attendance;
                    }
                    else
                    {
                        good = getWork(allDepartment[j], i, "完成").Rows.Count + good;
                        Attendance = getWork(allDepartment[j], i, "未完成").Rows.Count + Attendance;
                    }
                }
                School = good + Attendance;
                double Attendance1 = Attendance / School;
                getWork(allDepartment[j], (int)School, (int)Attendance, Attendance1.ToString());

            }
            DataTable dt = getWork();
            return dt;
        }
        public static DataTable getWork(string department, int week, string finish)
        {

            return DAL.DBHelper.getDt("SELECT * FROM  考勤课程 WHERE  承担单位='" + department + "'AND 周次='" + week + "'AND 作业 ='" + finish + "'");

        }
        public static DataTable getWork(string department, int week)
        {

            return DAL.DBHelper.getDt("SELECT * FROM  考勤课程 WHERE  承担单位='" + department + "'AND 周次='" + week + "'AND 作业<>'完成'");

        }
        public static void getWork(string department, int School, int noFinish, string finish)
        {
            DAL.DBHelper.Getdt("INSERT INTO 作业分析(系部,作业总次数,未完成作业次数,未完成作业率)VALUES('" + department + "','" + School + "','" + noFinish + "','" + finish + "') ");
        }
        public static DataTable getWork()
        {
            return DAL.DBHelper.getDt("select * from 作业分析");
        }
        public static DataTable getWork(string str )
        {
            return DAL.DBHelper.getDt("select * from 作业分析 where 系部='"+str+"'");
        }
        public static void deleteWork()
        {
            DAL.DBHelper.Getdt("DELETE FROM 作业分析 ");
        }

    }
}

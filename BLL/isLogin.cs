using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class isLogin
    {
        /*
         *登陆信息 
         */
        public static DataTable login(string IDl)
        {
            String strSQL = "SELECT * from 教师 WHERE 工号='" + IDl + "'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getStudent(string department,int Weeked)
        {
            String strSQL = "SELECT * FROM 考勤课程 WHERE  承担单位='" + department + "' AND 周次='" + Weeked + "'AND  出勤<>'正常'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getStudent(string department, int Weeked, string state)
        {
            String strSQL = "SELECT*FROM 考勤课程 WHERE 承担单位='"+ department +"' AND 周次='" + Weeked + "'AND 出勤= '" + state + "' ";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getTeacher(string department)
        {
            String strSQL = "SELECT distinct 承担单位,工号,教师姓名,周次,星期,节次 FROM 考勤课程 WHERE 承担单位='" + department + "'AND 是否考勤 <> '是'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getTeacher1(string UidID)
        {
            String strSQL = "SELECT  承担单位,工号,教师姓名,周次,星期,节次 FROM 漏报分析 WHERE 工号='" + UidID + "'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getTeacher(string SelectIndex,string SelectIndex1)
        {
            String strSQL = "SELECT distinct 承担单位,工号,教师姓名,未考勤次数 FROM 漏报分析 WHERE "+SelectIndex+"='" + SelectIndex1+"'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
    
        public static void SETTeacher(int sum)
        {

            string str = "UPDATA 漏报分析 SET (未考勤次数)=('" + sum + "')";
            DAL.DBHelper.Getdt(str);

        }
        public static DataTable setWeiKaoqin()
        { 
            string str = "select distinct 承担单位,工号,教师姓名,周次,星期,节次,未考勤次数=COUNT(*) over (partition by 教师姓名) from  漏报分析 order by 教师姓名";
          return  DAL.DBHelper.getDt(str);
           
        }
        public static void getTeacher1()
        {
            DAL.DBHelper.getDt("DELETE FROM 漏报分析");
           
        }

        public static DataTable getStudent()
        {
            String strSQL = "SELECT * FROM  考勤课程";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getTeacherTable()
        {
            String strSQL = "SELECT  distinct 承担单位,工号,教师姓名,未考勤次数 FROM  漏报分析";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }
        public static DataTable getWork(string department, int Weeked)
        {
            String strSQL = "SELECT * FROM 考勤课程 WHERE  承担单位='" + department + "' AND 周次='" + Weeked + "'AND 作业 <> '正常'";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;
        }

        /**
         * 查询教师信息
         */
        public static DataTable Adminteach()
        {
            string str = "SELECT 工号,姓名,权限,部门 FROM 教师";
            DataTable dt = DAL.DBHelper.getDt(str);
            return dt;
        }

        /**
         * 新增教师用户
         * 
         */
        public static int creatTeach(string YN, string dpm, string usrid, string userName, string sex, string Pwd, string permissions)
        {
            if (YN == "外聘教师")
            {
              string str = "INSERT INTO 教师(工号,密码,姓名,权限,性别,部门)VALUES('" + usrid + "','" + PWDProcess.MD5Encrypt(Pwd,PWDProcess.CreateKey(usrid)) + "','" + userName + "','" + permissions + "','" + sex + "','" + dpm + "')";
                 DAL.DBHelper.Getdt(str);
                string str1 = "INSERT INTO 外聘教师(工号,密码,姓名,权限,性别,部门)VALUES('" + usrid + "','" + PWDProcess.MD5Encrypt(Pwd, PWDProcess.CreateKey(usrid)) + "','" + userName + "','" + permissions + "','" + sex + "','" + dpm + "')";
                DAL.DBHelper.Getdt(str1);
            }
            if (YN == "本校教师")
            {
                string str = "INSERT INTO 教师(工号,密码,姓名,权限,性别,部门)VALUES('" + usrid + "','" + PWDProcess.MD5Encrypt(Pwd, PWDProcess.CreateKey(usrid)) + "','" + userName + "','" + permissions + "','" + sex + "','" + dpm + "')";
                DAL.DBHelper.Getdt(str);
            }

            DataTable dt = DAL.DBHelper.getDt("SELECT * FROM 教师 WHERE 工号='" + usrid + "'");
            if (dt.Rows.Count == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static void getStudent(string depatmentnt, int Student, int late, string late1, int Early, string Early1, int Attendance, string Attendance1, int Leave, string Leave1, int sum, string sum1)
        {


            string str = "INSERT INTO 缺勤分析(系部,在校人次,旷课人次,旷课率,迟到人次,迟到率,早退人次,早退率,请假人次,请假率,总缺勤人次,总缺勤率)VALUES('" + depatmentnt + "','" + Student + "','" + late + "','" + late1 + "','" + Early + "','" + Early1 + "','" + Leave + "','" + Leave1 + "','" + Attendance + "','" + Attendance1 + "','" + sum + "','" + sum1 + "')";

            DAL.DBHelper.Getdt(str);
            DataTable dt = DAL.DBHelper.getDt("select * from 缺勤分析");

        }
        public static DataTable getStudent1()
        {

            DataTable dt = DAL.DBHelper.getDt("select * from 缺勤分析");
            return dt;

        }
        public static DataTable getStudent2(string str)
        {

            DataTable dt = DAL.DBHelper.getDt("select * from 缺勤分析 where 系部 ='"+ str + "'");
            return dt;

        }
        public static void deleteStudent()
        {
            DAL.DBHelper.getDt("DELETE FROM 缺勤分析");
        }
        /*
         * 修改教师密码
         */
        public static int updt(string pwd, string id, string ypwd)
        {
            string str = "UPDATE 教师 SET 密码='" + PWDProcess.MD5Encrypt(pwd.Trim(),PWDProcess.CreateKey(id.Trim())) + "' WHERE 工号='" + id.Trim() + "'";
            DAL.DBHelper.Getdt(str);
            DataTable dtt = DAL.DBHelper.getDt("SELECT 密码 FROM 教师 WHERE 工号='" + id.Trim() + "'");
            if (dtt.Rows[0][0].ToString() == PWDProcess.MD5Encrypt(pwd.Trim(), PWDProcess.CreateKey(id.Trim())))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /**
         * 发布通知 
         */
        public static int sendmarg(string message, string id)
        {
            DataTable dt = DAL.DBHelper.getDt("SELECT 工号 FROM 教师 WHERE 权限='" + id + "'");
            string timer = System.DateTime.Now.ToShortDateString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string str = "INSERT INTO 消息(时间,信息,用户名,阅读状态)VALUES('" + timer + "','" + message + "','" + dt.Rows[i][0] + "','1')";
                DAL.DBHelper.Getdt(str);
            }

            return 1;
        }

        /*
         *查询消息
         */
        public static DataTable readmarg(string id, string num)
        {
            DataTable dt = DAL.DBHelper.getDt("SELECT 时间,信息 FROM 消息 WHERE 用户名='" + id + "' AND 阅读状态='" + num + "'");
            return dt;
        }
        /*
         *修改标记消息阅读状态
         */
        public static void upmarg(string id, string marg, string timema)
        {
            DAL.DBHelper.Getdt("UPDATE 消息 SET 阅读状态='2' WHERE 时间='" + timema + "' AND 信息='" + marg + "' AND 用户名='" + id + "'");
        }
        /*
         *所有消息已读
         */
        public static void upmarg1(string id)
        {
            DAL.DBHelper.Getdt("UPDATE 消息 SET 阅读状态='2' WHERE 用户名='" + id + "'");
        }

        /*
         *删除历史信息
         */
        public static void delemarg(string id, string marg, string timemarg)
        {
            DAL.DBHelper.Getdt("DELETE FROM 消息 WHERE 用户名='" + id + "' AND 时间='" + timemarg + "' AND 信息='" + marg + "' AND 阅读状态='2'");
        }

        /*
         * treeview链接数据库
         */
        public static DataTable Atr()
        {
            return DAL.DBHelper.getDt("select aid,aname from tree");
        }
        public static DataTable Btr()
        {
            return DAL.DBHelper.getDt("select bid,bname from tree");
        }
        public static DataTable Ctr()
        {
            return DAL.DBHelper.getDt("select cid,cname from tree");
        }
        public static DataTable Dtr()
        {
            return DAL.DBHelper.getDt("select did,dname from tree");
        }

        /*
         *数据的导入 
         */
        public static int excle(string url, string tb)
        {

            DataTable dt = DAL.DBHelper.getExcle(url);
            if (tb == "全校教师")
            {
                DataTable dtt = DAL.DBHelper.getDt("SELECT * FROM 教师 WHERE 工号='"+dt.Rows[5][1]+"'");
                if (dtt.Rows.Count == 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][2] = PWDProcess.MD5Encrypt(dt.Rows[i][2].ToString(),PWDProcess.CreateKey(dt.Rows[i][1].ToString()));
                    }
                    DAL.DBHelper.SQLBulkCopy(dt, "教师");
                    DAL.DBHelper.getDt("DELETE FROM 教师 WHERE 部门='部门'");
                }
                else
                {
                    return 3;
                }
            }
            if (tb == "外聘教师")
            {
                DataTable dtt = DAL.DBHelper.getDt("SELECT * FROM 外聘教师 WHERE 工号='" + dt.Rows[5][1] + "'");
                if (dtt.Rows.Count == 0)
                {
                    DAL.DBHelper.waiteaSQLBulkCopy(dt, tb);
                    DAL.DBHelper.getDt("DELETE FROM 外聘教师 WHERE 部门='部门'");
                }
                if (dtt.Rows.Count != 0)
                {
                    return 3;
                }
                DataTable dtt1 = DAL.DBHelper.getDt("SELECT * FROM 教师 WHERE 工号='" + dt.Rows[5][1] + "'");
                if (dtt1.Rows.Count == 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][2] = PWDProcess.MD5Encrypt(dt.Rows[i][2].ToString(), PWDProcess.CreateKey(dt.Rows[i][1].ToString()));
                    }
                    DAL.DBHelper.waipinTea(dt, "教师");
                    DAL.DBHelper.getDt("DELETE FROM 教师 WHERE 部门='部门'");
                }
               if(dtt1.Rows.Count!=0)
                {
                    return 3;
                }
            }
            if (tb == "信息艺术系" || tb == "会计系" || tb == "商务外语系" || tb == "食品工程系" || tb == "建筑工程系" || tb == "机械工程系" || tb == "经济管理系" || tb == "教务处" || tb == "基础教学部")
            {
                DAL.DBHelper.xibu(dt,"初始信息");
                DAL.DBHelper.getDt("DELETE FROM 初始信息 WHERE 承担单位='承担单位'");
            }
            return 1;
        }
        public static void inster(DataTable dt,string tableName)
        {
            DAL.DBHelper.Loubaochaxun(dt, tableName);
        }
        public static void inster1(DataTable dt, string tableName)
        {
            DAL.DBHelper.Loubaochaxun1(dt, tableName);
        }
        //导入日历
        public static int calender(string y,string m,string d,string w,int sweek)
        {
            string ssweek = "";
            if (sweek == 1)
            {
                ssweek = "星期一";
            }
            if (sweek == 2)
            {
                ssweek = "星期二";
            }
            if (sweek == 3)
            {
                ssweek = "星期三";
            }
            if (sweek == 4)
            {
                ssweek = "星期四";
            }
            if (sweek == 5)
            {
                ssweek = "星期五";
            }
            if (sweek == 6)
            {
                ssweek = "星期六";
            }
            if (sweek == 7)
            {
                ssweek = "星期七";
            }
            DAL.DBHelper.Getdt("INSERT INTO 校历 VALUES('"+w+"','"+y+"','"+m+"','"+d+"','"+ssweek+"')");
            return 1;
        }

        /*
         *清空所有数据
         */

        public static void wipe(string tb)
        {
            if (tb == "教师" || tb == "外聘教师"||tb=="校历")
            {
                DAL.DBHelper.Getdt("DELETE FROM " + tb);
            }
            else
            {
                DAL.DBHelper.Getdt("DELETE FROM 初始信息 WHERE 承担单位='" + tb + "'");
                DAL.DBHelper.Getdt("DELETE FROM 考勤课程 WHERE 承担单位='" + tb + "'");
                DAL.DBHelper.Getdt("DELETE FROM 录入考勤 WHERE 承担单位='" + tb + "'");
            }
        }
        public static void de()
        {

            DAL.DBHelper.Getdt("DELETE FROM 初始信息");
            DAL.DBHelper.Getdt("DELETE FROM 教师");
            DAL.DBHelper.Getdt("DELETE FROM 消息");
            DAL.DBHelper.Getdt("DELETE FROM 外聘教师");
            DAL.DBHelper.Getdt("DELETE FROM 考勤课程");
            DAL.DBHelper.Getdt("DELETE FROM 录入考勤");
            DAL.DBHelper.Getdt("DELETE FROM 校历");
        }

        /*
         * 读取当前周次
         */
        public static string dweek()
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            string da=System.DateTime.Now.ToShortDateString();
            string[] w = da.Split(new char[] { '/'},StringSplitOptions.RemoveEmptyEntries);
            DataTable dt = DAL.DBHelper.getDt("SELECT 周次 FROM 校历 WHERE STUYEAR='"+w[0]+"' AND STUMOTH='"+w[1]+"' AND STUDAY='"+w[2]+"'");
            if (dt.Rows.Count>0)
            {
                i = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            else {
                i = 0;
            }
            if (i < 10)
            {
                return ("0" + i.ToString());
            }
            else
            {
                return i.ToString();
            }
        }
    }
}

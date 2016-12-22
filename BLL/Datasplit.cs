using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Datasplit
    {
        /*
         * 读取数据
         */
        public static DataTable getdata()
        {
            string str = "SELECT * FROM 初始信息";
            return DAL.DBHelper.getDt(str);
        }
        /*
         * 拆分数据
         */
        public static int a()
        {
            if (getdata().Rows.Count > 0)
            {
                DataTable dt = getdata();
                DataTable dtt = DAL.DBHelper.getDt("select top(0)* from 考勤课程").Clone();
                StringBuilder classtype = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] strtea1 = dt.Rows[i][1].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);//拆分教师工号和姓名
                    string[] strtype1 = dt.Rows[i][3].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);//拆分课程和课程号
                    string[] strclass1 = dt.Rows[i][2].ToString().Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);//拆分时间地点
                    for (int j = 0; j < strclass1.Length; j++)
                    {
                        string[] strclass2 = strclass1[j].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);//拆分周次，星期，节次，地点
                        string[] strclass3 = strclass2[3].ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);//拆分地点
                        if (strclass3.Length == 1)
                        {
                            classtype.Append(strclass3[0].ToString());
                        }
                        else
                        {
                            for (int c = 0; c < strclass3.Length; c++)
                            {
                                classtype.Append(strclass3[c]);
                            }
                        }
                        /*
                         * 教师工号strtea1[0]
                         * 教师姓名strtea1[1]
                         * 课程号strtype1[0] 
                         * 课程strtype1[1]
                         * 周次strclass2[0]    strSplit3[0]||strSplit3[0],[1],[n]
                         * 星期strclass2[1]
                         * 节次strclass2[2]
                         * 地点classtype.toString()
                         */
                        //拆分周次
                        int dan = Convert.ToInt32(strclass2[0].IndexOf("单").ToString());//查看是否是单周
                        int shuang = Convert.ToInt32(strclass2[0].IndexOf("双").ToString());//查看是否是双周
                        if (dan > 0)//如果单周
                        {
                            string[] strSplit = strclass2[0].ToString().Split(new char[] { '周' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] strSplit2 = strSplit[0].Split(new char[] { ',', '单', '，' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int dana = 0; dana < strSplit2.Length; dana++)
                            {
                                string[] strSplit3 = strSplit2[dana].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                if (strSplit3.Length == 1)
                                {
                                    DataRow row = dtt.NewRow();
                                    string[] aa = { dt.Rows[i][0].ToString(), strtea1[0].ToString(), strtea1[1].ToString(), strtype1[0].ToString(), strtype1[1].ToString(), strclass2[1].ToString(), strSplit3[0].ToString(), strclass2[2].ToString(), classtype.ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), "正常", "完成", "否", dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString(), dt.Rows[i][14].ToString(), "否" };
                                    for (int addrow = 0; addrow < aa.Length; addrow++)
                                    {
                                        row[addrow] = aa[addrow];
                                    }
                                    dtt.Rows.Add(row);
                                }
                                if (strSplit3.Length == 2)
                                {
                                    for (int danb = Convert.ToInt32(strSplit3[0]); danb <= Convert.ToInt32(strSplit3[1]); danb++)
                                    {
                                        if (danb % 2 != 0)
                                        {
                                            DataRow row = dtt.NewRow();
                                            string[] aa = { dt.Rows[i][0].ToString(), strtea1[0].ToString(), strtea1[1].ToString(), strtype1[0].ToString(), strtype1[1].ToString(), strclass2[1].ToString(), danb.ToString(), strclass2[2].ToString(), classtype.ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), "正常", "完成", "否", dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString(), dt.Rows[i][14].ToString(), "否" };
                                            for (int addrow = 0; addrow < aa.Length; addrow++)
                                            {
                                                row[addrow] = aa[addrow];
                                            }
                                            dtt.Rows.Add(row);
                                        }
                                    }
                                }
                            }
                        }
                        if (shuang > 0)//如果双周
                        {
                            string[] strSplit = strclass2[0].ToString().Split(new char[] { '周' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] strSplit2 = strSplit[0].Split(new char[] { ',', '双', '，' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int dana = 0; dana < strSplit2.Length; dana++)
                            {
                                string[] strSplit3 = strSplit2[dana].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                if (strSplit3.Length == 1)
                                {
                                    DataRow row = dtt.NewRow();
                                    string[] aa = { dt.Rows[i][0].ToString(), strtea1[0].ToString(), strtea1[1].ToString(), strtype1[0].ToString(), strtype1[1].ToString(), strclass2[1].ToString(), strSplit3[0].ToString(), strclass2[2].ToString(), classtype.ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), "正常", "完成", "否", dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString(), dt.Rows[i][14].ToString(), "否" };
                                    for (int addrow = 0; addrow < aa.Length; addrow++)
                                    {
                                        row[addrow] = aa[addrow];
                                    }
                                    dtt.Rows.Add(row);
                                }
                                if (strSplit3.Length == 2)
                                {
                                    for (int danb = Convert.ToInt32(strSplit3[0]); danb <= Convert.ToInt32(strSplit3[1]); danb++)
                                    {
                                        if (danb % 2 == 0)
                                        {
                                            DataRow row = dtt.NewRow();
                                            string[] aa = { dt.Rows[i][0].ToString(), strtea1[0].ToString(), strtea1[1].ToString(), strtype1[0].ToString(), strtype1[1].ToString(), strclass2[1].ToString(), danb.ToString(), strclass2[2].ToString(), classtype.ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), "正常", "完成", "否", dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString(), dt.Rows[i][14].ToString(), "否" };
                                            for (int addrow = 0; addrow < aa.Length; addrow++)
                                            {
                                                row[addrow] = aa[addrow];
                                            }
                                            dtt.Rows.Add(row);
                                        }
                                    }
                                }
                            }
                        }
                        if (dan == -1 && shuang == -1)
                        {
                            string[] strSplit2 = strclass2[0].Split(new char[] { ',', '周', '，' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int dana = 0; dana < strSplit2.Length; dana++)
                            {
                                string[] strSplit3 = strSplit2[dana].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                if (strSplit3.Length == 1)
                                {
                                    DataRow row = dtt.NewRow();
                                    string[] aa = { dt.Rows[i][0].ToString(), strtea1[0].ToString(), strtea1[1].ToString(), strtype1[0].ToString(), strtype1[1].ToString(), strclass2[1].ToString(), strSplit3[0].ToString(), strclass2[2].ToString(), classtype.ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), "正常", "完成", "否", dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString(), dt.Rows[i][14].ToString(), "否" };
                                    for (int addrow = 0; addrow < aa.Length; addrow++)
                                    {
                                        row[addrow] = aa[addrow];
                                    }
                                    dtt.Rows.Add(row);
                                }
                                if (strSplit3.Length == 2)
                                {
                                    for (int danb = Convert.ToInt32(strSplit3[0]); danb <= Convert.ToInt32(strSplit3[1]); danb++)
                                    {
                                        DataRow row = dtt.NewRow();
                                        string[] aa = { dt.Rows[i][0].ToString(), strtea1[0].ToString(), strtea1[1].ToString(), strtype1[0].ToString(), strtype1[1].ToString(), strclass2[1].ToString(), danb.ToString(), strclass2[2].ToString(), classtype.ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(), dt.Rows[i][11].ToString(), "正常", "完成", "否", dt.Rows[i][12].ToString(), dt.Rows[i][13].ToString(), dt.Rows[i][14].ToString(), "否" };
                                        for (int addrow = 0; addrow < aa.Length; addrow++)
                                        {
                                            row[addrow] = aa[addrow];
                                        }
                                        dtt.Rows.Add(row);
                                    }
                                }
                            }
                        }
                        classtype.Clear();
                    }
                }
                DAL.DBHelper.sqlbl(dtt);
                DAL.DBHelper.Getdt("DELETE FROM 初始信息");
                return 1;
            }
            else
            {
                return 2;
            }
        }
        
        /*
         *生成录入考勤表
         */
        public static DataTable chakaoqin()
        {
            String strSQL = "SELECT distinct 承担单位,工号,教师姓名,课程号,课程,星期,周次,节次,地点,布置作业,是否考勤 FROM 考勤课程 ";
            DataTable dt = DAL.DBHelper.getDt(strSQL);
            return dt;

        }
        public static int kaoqin()
        {
            DataTable dt = chakaoqin();
            DAL.DBHelper.datakaoqin(dt,"录入考勤");
            return 1;
        }
    }
}

using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class exportData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Visible = false;
        Label5.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //学生缺勤
        System.Data.DataTable dt = BLL.ExportDate.stukaoqin("");
        if (dt.Rows.Count > 0)
        {
            try
            {
                string Filename = System.DateTime.Now.ToString("yyyyMMddhhmmssffff") + "学生缺勤";
                ex(dt, Filename);
                Response.Redirect("./导出数据/" + Filename + ".xlsx");
                Label4.Visible = true;
                Label4.Text = "成功！";
            }
            catch
            {
                Label4.Visible = true;
                Label4.Text = "失败!";
            }
        }
        else
        {
            Label4.Visible = true;
            Label4.Text = "无数据！";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //教师漏报
        System.Data.DataTable dt = BLL.ExportDate.tealoubao("");
        if (dt.Rows.Count > 0)
        {
            try
            {
                string Filename = System.DateTime.Now.ToString("yyyyMMddhhmmssffff") + "教师漏报";
                ex(dt, Filename);
                Response.Redirect("./导出数据/" + Filename + ".xlsx");
                Label5.Visible = true;
                Label5.Text = "成功！";
            }
            catch
            {
                Label5.Visible = true;
                Label5.Text = "失败!";
            }
        }
        else
        {
            Label5.Visible = true;
            Label5.Text = "无数据！";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        //教师作业
        System.Data.DataTable dt = BLL.ExportDate.teazuoye("");
        if (dt.Rows.Count > 0)
        {
            try
            {
                string Filename = System.DateTime.Now.ToString("yyyyMMddhhmmssffff") + "教师作业";
                ex(dt, Filename);
                Response.Redirect("./导出数据/" + Filename + ".xlsx");
                Label6.Visible = true;
                Label6.Text = "成功！";
            }
            catch
            {
                Label6.Visible = true;
                Label6.Text = "失败!";
            }
        }
        else
        {
            Label6.Visible = true;
            Label6.Text = "无数据！";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //学生作业
        System.Data.DataTable dt = BLL.ExportDate.stuzuoye("");
        if (dt.Rows.Count > 0)
        {
            try
            {
                string Filename = System.DateTime.Now.ToString("yyyyMMddhhmmssffff") + "学生作业";
                ex(dt, Filename);
                Response.Redirect("./导出数据/" + Filename + ".xlsx");
                Label7.Visible = true;
                Label7.Text = "成功！";
            }
            catch
            {
                Label7.Visible = true;
                Label7.Text = "失败!";
            }
        }
        else
        {
            Label7.Visible = true;
            Label7.Text = "无数据！";
        }
    }

    private void ex(System.Data.DataTable dt, string name)
    {
        object miss = Missing.Value;
        Application excelApp = new Application();
        excelApp.Workbooks.Add(miss);
        //导入数据
        int zongrow = dt.Rows.Count;
        int z1 = zongrow / 60000;
        int z2 = z1 * 60000;
        int z4 = 0;
        int z5 = 0;
        int z6 = 0;
        int z7 = 0;
        int i1 = 0;
        if (z2 < zongrow)
        {
            z1 += 1;
            z5 = zongrow - z2;
        }
        if (z2 > zongrow) { z5 = z2 - zongrow; }
        if (z2 == zongrow) { z5 = 60000; }
        if (z1 < 1) { z1 = 1; }
        for (int z3 = 1; z3 <= z1; z3++)
        {
            i1 = 0;
            if (z1 == 1)
            { z4 = dt.Rows.Count; z6 = dt.Rows.Count; }
            if (z1 > 1 && z3 != z1)
            { z4 = 60000; z6 += 60000 * z3; if (z3 >= 2) { z7 += 60000 * (z3 - 1); } }
            if (z3 == z1 && z1 > 1) { z4 = z5; z6 += z5; z7 += 60000 * (z3 - 1); }
            Worksheet workSheet = (Worksheet)excelApp.Worksheets[z3];
            object[,] dataArray = new object[z4 + 1, dt.Columns.Count];
            workSheet.Columns.EntireColumn.AutoFit();//自适应列宽
            for (int i = z7; i < z6 + 1; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (i == z7)
                    {
                        dataArray[i1, j] = dt.Columns[j].ColumnName;
                    }
                    else
                    {
                        if (j == 1)
                        {
                            dataArray[i1, j] = "[" + dt.Rows[i - 1][j].ToString() + "]";
                        }
                        else
                        {
                            dataArray[i1, j] = dt.Rows[i - 1][j].ToString();
                        }
                    }
                }
                i1++;
            }
            workSheet.get_Range(workSheet.Cells[1, 1], workSheet.Cells[z4 + 1, dt.Columns.Count]).Value2 = dataArray;
            workSheet = null;
        }
        //保存
        Workbook workBook = excelApp.Workbooks[1];
        workBook.RefreshAll();
        workBook.SaveAs(Server.MapPath("./ ") + "导出数据/" + name, miss, miss, miss, miss, miss, XlSaveAsAccessMode.xlNoChange, miss, miss, miss, miss, miss);
        workBook.Close(false, miss, miss);
        workBook = null;
        excelApp.Quit();
        excelApp = null;
        GC.Collect();
    }
}
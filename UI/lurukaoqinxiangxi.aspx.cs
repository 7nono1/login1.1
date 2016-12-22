using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class lurukaoqinxiangxi : System.Web.UI.Page
{
    System.Drawing.Color c;
   // radio条目变色
    protected void rdo_CheckChange(object sender, EventArgs e)
    {
        foreach (GridViewRow row in this.gvAttendanceDetails.Rows)
        {
            Control ct1 = row.FindControl("rdoNormal");
            Control ct2 = row.FindControl("rdoLate");
            Control ct3 = row.FindControl("rdoAbsence");
            Control ct4 = row.FindControl("rdoEarly");
            Control ct5 = row.FindControl("rdoLeave");
            TableCellCollection cell = row.Cells;
            if ((ct1 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor = c;
            }
            if ((ct2 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Yellow;
            }
            if ((ct3 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Red;
            }
            if ((ct4 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Yellow;
            }
            if ((ct5 as RadioButton).Checked)
            {
                this.gvAttendanceDetails.Rows[row.DataItemIndex].BackColor = System.Drawing.Color.Blue;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = BLL.kaoqin.Loadused(Session["userID"].ToString().Trim(), Session["stuweek"].ToString().Trim(), Session["录入课程"].ToString().Trim(), Session["录入节次"].ToString().Trim(), Session["录入星期"].ToString().Trim());
            //Load加载的时候调用数据库
            gvAttendanceDetails.DataSource = dt;
            gvAttendanceDetails.DataKeyNames = new string[] { "学号" };
            gvAttendanceDetails.DataBind();
        }

    }

    protected void btnAttendance_Click(object sender, EventArgs e)//录入考勤
    {
        foreach (GridViewRow row in this.gvAttendanceDetails.Rows)
        {
            Control ctl2 = row.FindControl("rdoLate");//迟到
            Control ctl3 = row.FindControl("rdoAbsence");//旷课
            Control ctl4 = row.FindControl("rdoEarly");//早退
            Control ctl5 = row.FindControl("rdoLeave");//请假
            TableCellCollection cell = row.Cells;
            string a = row.Cells[2].Text.Trim();
            if ((ctl2 as RadioButton).Checked)
            //录入考勤的方法，即老师考勤完毕 数据进入数据库
            {
                BLL.kaoqin.InsertTabTeachers(Session["stuweek"].ToString().Trim(), "迟到", Session["userID"].ToString().Trim(), Session["录入课程"].ToString().Trim(), Session["录入节次"].ToString().Trim(), Session["录入星期"].ToString().Trim(), a);
            }
            if ((ctl3 as RadioButton).Checked)
            {
                BLL.kaoqin.InsertTabTeachers(Session["stuweek"].ToString().Trim(), "旷课", Session["userID"].ToString().Trim(), Session["录入课程"].ToString().Trim(), Session["录入节次"].ToString().Trim(), Session["录入星期"].ToString().Trim(), a);
            }
            if ((ctl4 as RadioButton).Checked)
            {
                BLL.kaoqin.InsertTabTeachers(Session["stuweek"].ToString().Trim(), "早退", Session["userID"].ToString().Trim(), Session["录入课程"].ToString().Trim(), Session["录入节次"].ToString().Trim(), Session["录入星期"].ToString().Trim(), a);
            }
            if ((ctl5 as RadioButton).Checked)
            {
                BLL.kaoqin.InsertTabTeachers(Session["stuweek"].ToString().Trim(), "请假", Session["userID"].ToString().Trim(), Session["录入课程"].ToString().Trim(), Session["录入节次"].ToString().Trim(), Session["录入星期"].ToString().Trim(), a);
            }
        }
        Label1.Visible = true;
        Label1.Text = "上报成功";
    }
    protected void btnUnNormal_Click(object sender, EventArgs e)
    {
        Response.Redirect("lurukaoqin.aspx");
    }
}
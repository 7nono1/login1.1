using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class lurukaoqin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getTable();
    }

    public void getTable()
    {
        DataTable dt = new DataTable();
        dt = BLL.kaoqin.GetDatatableBySQL1(Session["userID"].ToString().Trim(), Session["stuweek"].ToString().Trim());
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        getTable();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            Session["录入课程"] = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text.ToString();
            Session["录入节次"] = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text.ToString();
            Session["录入星期"] = GridView1.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.ToString();
            Response.Redirect("lurukaoqinxiangxi.aspx");
        }
    }
}
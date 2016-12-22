using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class jiaoshichaxun : System.Web.UI.Page
{
    protected void Inquire()
    {
        if (DropDownList1.SelectedItem.ToString() == "所有记录")
        {
            DataTable dt = cxjs.find();
            BindToGridView(dt);

        }
        else if (DropDownList1.SelectedItem.ToString() != "所有记录" && TextBox1.Text != "")
        {
            if (DropDownList1.SelectedItem.Text == "按部门查询")
            {
                DataTable dt = cxjs.Griview("部门", TextBox1.Text);
                BindToGridView(dt);

            }
            else if (DropDownList1.SelectedItem.Text == "按教师工号查询")
            {
                DataTable dt = cxjs.Griview("工号", TextBox1.Text);
                BindToGridView(dt);
            }
            else if (DropDownList1.SelectedItem.Text == "按教师姓名查询")
            {
                DataTable dt = cxjs.Griview("姓名", TextBox1.Text);
                BindToGridView(dt);
            }
            else if (DropDownList1.SelectedItem.Text == "按权限查询")
            {
                DataTable dt = cxjs.Griview("权限", TextBox1.Text);
                BindToGridView(dt);
            }

        }
    }
    protected void BindToGridView(DataTable dt)
    {
        GridView1.DataSource = dt;
        GridView1.DataKeyNames = new string[] { "工号" };
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.ToString() == "所有记录")

        {
            Label2.Visible = false;
            TextBox1.Visible = false;
        }
        else
        {
            Label2.Visible = true;
            TextBox1.Visible = true;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        Inquire();


    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string a = ((Label)GridView1.Rows[e.NewEditIndex].Cells[3].FindControl("labRols")).Text;
        int b = Convert.ToInt32(a) - 1;
        GridView1.EditIndex = e.NewEditIndex;
        Inquire();

        DropDownList dll = (DropDownList)GridView1.Rows[e.NewEditIndex].Cells[3].FindControl("dropRols");
        dll.SelectedIndex = b;
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Inquire();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        cxjs.rowdelete("工号", GridView1.DataKeys[e.RowIndex].Value.ToString());
        {
            Inquire();
        }

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string strUserRole = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[3].FindControl("dropRols")).SelectedItem.ToString();
        string strUserID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        cxjs.rowupdate("权限", strUserRole, "工号", strUserID);




        GridView1.EditIndex = -1;
        Inquire();


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Inquire();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = cxjs.find();
            BindToGridView(dt);
            Label2.Visible = false;
            TextBox1.Visible = false;
        }
    }
}
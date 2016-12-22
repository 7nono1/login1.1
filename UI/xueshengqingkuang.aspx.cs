﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class xueshengqingkuang : System.Web.UI.Page
{
    protected void Inquire()
    {
        if (DropDownList1.SelectedItem.ToString() == "所有记录")
        {
            DataTable dt = xsqk.find();
            BindToGridView(dt);

        }
        else if (DropDownList1.SelectedItem.ToString() != "所有记录" && TextBox1.Text != "")
        {
            if (DropDownList1.SelectedItem.Text == "按学号查询")
            {
                DataTable dt = xsqk.Griview("学号", TextBox1.Text);
                BindToGridView(dt);

            }
            else if (DropDownList1.SelectedItem.Text == "按姓名查询")
            {
                DataTable dt = xsqk.Griview("姓名", TextBox1.Text);
                BindToGridView(dt);
            }
            else if (DropDownList1.SelectedItem.Text == "按周次查询")
            {
                DataTable dt = xsqk.Griview("周次", TextBox1.Text);
                BindToGridView(dt);
            }
            else if (DropDownList1.SelectedItem.Text == "按课程查询")
            {
                DataTable dt = xsqk.Griview("课程", TextBox1.Text);
                BindToGridView(dt);
            }

        }
    }
    protected void BindToGridView(DataTable dt)
    {
        GridView1.DataSource = dt;
        GridView1.DataKeyNames = new string[] { "学号" };
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
        int b = 0;
        string a = ((Label)GridView1.Rows[e.NewEditIndex].Cells[6].FindControl("chuqinlab")).Text;
        GridView1.EditIndex = e.NewEditIndex;
        if (a == "正常")
        {
            b = 0;
        }
        if (a == "迟到")
        {
            b = 1;
        }
        if (a == "早退")
        {
            b = 2;
        }
        if (a == "旷课")
        {
            b = 3;
        }
        if (a == "请假")
        {
            b = 4;
        }
        Inquire();
        DropDownList ddl = (DropDownList)GridView1.Rows[e.NewEditIndex].Cells[6].FindControl("chuqindrop");
        ddl.SelectedIndex = b;
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Inquire();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string zc = GridView1.Rows[e.RowIndex].Cells[3].Text.ToString();
        string zq = GridView1.Rows[e.RowIndex].Cells[4].Text.ToString();
        string jc = GridView1.Rows[e.RowIndex].Cells[5].Text.ToString();
        string kc = GridView1.Rows[e.RowIndex].Cells[2].Text.ToString();
        xsqk.rowdelete("学号", GridView1.DataKeys[e.RowIndex].Value.ToString(), zc, zq, jc, kc);
        {
            Inquire();
        }

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string strUserRole = ((DropDownList)(GridView1.Rows[e.RowIndex].Cells[6].FindControl("chuqindrop"))).SelectedItem.ToString();
        string zc = GridView1.Rows[e.RowIndex].Cells[3].Text.ToString();
        string zq = GridView1.Rows[e.RowIndex].Cells[4].Text.ToString();
        string jc = GridView1.Rows[e.RowIndex].Cells[5].Text.ToString();
        string kc = GridView1.Rows[e.RowIndex].Cells[2].Text.ToString();
        string strUserID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        xsqk.rowupdate("出勤", strUserRole, "学号", strUserID, zc, zq, jc, kc);




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
            DataTable dt = xsqk.find();
            BindToGridView(dt);
            Label2.Visible = false;
            TextBox1.Visible = false;
        }
    }
}
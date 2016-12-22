using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                getdata();
            }
    }

    private void getdata()
    {
        DataTable dt = BLL.isLogin.readmarg(Session["userID"].ToString().Trim(), "1");
        //DataTable dt = BLL.isLogin.readmarg("121");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CheckBoxList1.Items.Add(dt.Rows[i][1].ToString() + "(时间：" + dt.Rows[i][0].ToString() + ")");

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected == true)
            {
                string[] str = CheckBoxList1.Items[i].Text.Split('(');
                string[] str1 = str[1].Split('：');
                string[] str2 = str1[1].Split(')');
                BLL.isLogin.upmarg(Session["userID"].ToString().Trim(), str[0].ToString(), str2[0].ToString());
                //BLL.isLogin.upmarg("121", str[0].ToString(), str2[0].ToString());
            }
        }
        CheckBoxList1.Items.Clear();
        getdata();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        BLL.isLogin.upmarg1(Session["userID"].ToString().Trim());

        CheckBoxList1.Items.Clear();
        getdata();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("hosmarg.aspx");
    }
}
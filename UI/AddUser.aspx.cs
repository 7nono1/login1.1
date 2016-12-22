using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            labID.Visible = false;
            LabName.Visible = false;
            labpwd1.Visible = false;
            labpwd2.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "" && Password1.Value != "" && Password2.Value != "")
        {
            string YN = DropDownList1.SelectedValue.ToString().Trim();//教师类型
            string dpm = DropDownList2.SelectedValue.ToString().Trim();//所属部门
            string userID111 = TextBox1.Text.ToString().Trim();//教师工号
            string userName111 = TextBox2.Text.ToString().Trim();//教师姓名
            string pawd11 = Password1.Value.ToString().Trim();//密码
            string pawd1 = Password2.Value.ToString().Trim();//确认密码
            string sex = DropDownList4.SelectedValue.ToString().Trim();//性别
            int pms = DropDownList3.SelectedIndex;//权限
            if (pawd1 == pawd11)
            {
                DataTable dt = BLL.isLogin.login(userID111);
                if (dt.Rows.Count == 0)
                {
                    int i = BLL.isLogin.creatTeach(YN, dpm, userID111, userName111, sex, pawd1, (pms + 1).ToString().Trim());
                    if (i == 1)
                    {
                        Response.Write("<Script Language=JavaScript>alert('修改成功！');</Script>");
                    }
                    else
                    {
                        Response.Write("<Script Language=JavaScript>alert('修改失败！');</Script>");
                    }
                }
                else
                {
                    labID.Visible = true;
                    labID.Text = "该账号已存在";
                }
            }
            else
            {
                labpwd2.Visible = true;
                labpwd2.Text = "密码不一致";
            }
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert('请补充完整信息！');</Script>");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        labID.Visible = false;
        LabName.Visible = false;
        labpwd1.Visible = false;
        labpwd2.Visible = false;
        DropDownList1.SelectedIndex = 1;
        DropDownList2.SelectedIndex = 2;
        TextBox1.Text = "";
        TextBox2.Text = "";
        Password1.Value = "";
        Password2.Value = "";
        DropDownList4.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 3;
    }
}
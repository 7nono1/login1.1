using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class alterPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Label6.Visible = false;
            Label5.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (surePwd.Value.ToString() == userPwd.Value.Trim())
        {
            int i = BLL.isLogin.updt(userPwd.Value.ToString(), Session["userID"].ToString().Trim(), userPwd.Value.Trim());
            if (i == 0)
            {
                Label6.Visible = true;
                Label6.Text = "对不起，修改失败！";
            }
            else
            {
                Label6.Visible = true;
                Label6.Text = "修改成功！";
            }
        }
        else
        {
            Label5.Visible = true;
            Label5.Text = "密码不一致";
        }
    }
}
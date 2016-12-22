using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sendNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //清空数据并重置
        textarea.Value = "";
        CheckBox1.Checked = false;
        CheckBox2.Checked = false;
        CheckBox3.Checked = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //发送消息
        if (textarea.Value != "")
        {
            if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true)
            {
                if (CheckBox1.Checked == true)
                {
                    int i = BLL.isLogin.sendmarg(textarea.Value.ToString(), "2");
                }
                if (CheckBox2.Checked == true)
                {

                    int i = BLL.isLogin.sendmarg(textarea.Value.ToString(), "3");
                }
                if (CheckBox3.Checked == true)
                {

                    int i = BLL.isLogin.sendmarg(textarea.Value.ToString(), "4");
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "请先选择收件人……";
            }
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "请先输入信息内容";
        }

    }
}
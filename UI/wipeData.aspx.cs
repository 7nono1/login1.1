using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wipeData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox1.Text);
        }
        if (CheckBox2.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox2.Text);
        }
        if (CheckBox3.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox3.Text);
        }
        if (CheckBox4.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox4.Text);
        }
        if (CheckBox5.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox5.Text);
        }
        if (CheckBox6.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox6.Text);
        }
        if (CheckBox7.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox7.Text);
        }
        if (CheckBox8.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox8.Text);
        }
        if (CheckBox9.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox9.Text);
        }
        if (CheckBox10.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox10.Text);
        }
        if (CheckBox11.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox11.Text);
        }
        if (CheckBox12.Checked == true)
        {
            BLL.isLogin.wipe(CheckBox12.Text);
        }
        Button2.Text = "清除成功(可继续)";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BLL.isLogin.de();
        Button1.Text = "清除成功";
    }
}
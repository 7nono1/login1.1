using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yiwangjilu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = BLL.kaoqin.loadjilu(Session["userID"].ToString().Trim(), Session["stuweek"].ToString().Trim());
        GridView1.DataBind();
    }
}
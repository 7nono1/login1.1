using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Labteaname.Text = "欢迎" + " " + Session["userName"].ToString() + " [" + rl() + "]" + "[当前第" + Session["stuweek"].ToString() + "周]";
            closeform.InnerHtml = "[退出并关闭]";
            tree(rl());
        }
    }
    //判断权限
    private string rl()
    {
        StringBuilder role = new StringBuilder();
        role.Append(Session["userCols"].ToString());
        if (role.ToString() == "1")
        {
            role.Clear();
            role.Append("管理员");
        }
        if (role.ToString() == "2")
        {
            role.Clear();
            role.Append("院系领导");
        }
        if (role.ToString() == "3")
        {
            role.Clear();
            role.Append("辅导员");
        }
        if (role.ToString() == "4")
        {
            role.Clear();
            role.Append("教师");
        }
        return role.ToString();
    }
    //treeview赋值
    private DataTable decidetree(string id)
    {
        DataTable dt = new DataTable();
        if (id == "管理员")
        {
            dt = BLL.isLogin.Atr();
        }
        if (id == "院系领导")
        {
            dt = BLL.isLogin.Btr();
        }
        if (id == "辅导员")
        {
            dt = BLL.isLogin.Ctr();
        }
        if (id == "教师")
        {
            dt = BLL.isLogin.Dtr();
        }
        return dt;
    }
    private void tree(string id)
    {
        DataTable dt = decidetree(id);
        TreeNode tn = new TreeNode(dt.Rows[0][1].ToString());
        tn.NavigateUrl = "";
        TreeView1.Nodes.Add(tn);
        for (int i = 1; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][0].ToString() != null && dt.Rows[i][0].ToString() != "")
            {
                if (dt.Rows[i][0].ToString() == "10")
                {
                    TreeNode father = new TreeNode(dt.Rows[i][1].ToString());
                    TreeView1.Nodes[0].ChildNodes.Add(father);
                }
                if (dt.Rows[i][0].ToString() != "10" && dt.Rows[i][0].ToString() != "0")
                {
                    TreeNode child = new TreeNode(dt.Rows[i][1].ToString());
                    TreeView1.Nodes[0].ChildNodes[(Int32.Parse(dt.Rows[i][0].ToString()))].ChildNodes.Add(child);

                }
            }
        }
    }
    //treeview点击事件
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (rl() == "管理员")
        {
            admin();
        }
        if (rl() == "院系领导")
        {
            lead();
        }
        if (rl() == "辅导员")
        {
            tutor();
        }
        if (rl() == "教师")
        {
            tea();
        }
    }
    private void admin()//管理员
    {
        switch (TreeView1.SelectedNode.Text)
        {
            case "首页消息":
                Response.Redirect("message.aspx"); break;
            case "本校教师":
                Response.Redirect("jiaoshichaxun.aspx"); break;
            case "外聘教师":
                Response.Redirect("waipinjiaoshi.aspx"); break;
            case "修改密码":
                Response.Redirect("alterPwd.aspx"); break;
            case "新增用户":
                Response.Redirect("AddUser.aspx"); break;
            case "发布通知":
                Response.Redirect("sendNew.aspx"); break;


            case "导入数据":
                Response.Redirect("ImportData.aspx"); break;
            case "清空数据":
                Response.Redirect("wipeData.aspx"); break;
            case "导出数据":
                Response.Redirect("exportData.aspx"); break;


            case "异动处理":
                Response.Redirect("xueshengqingkuang.aspx"); break;
            case "学生情况":
                Response.Redirect("xueshengqingkuang.aspx"); break;
            case "教师情况":
                Response.Redirect("jiaoshiqingkuang.aspx"); break;
            case "作业情况":
                Response.Redirect("zuoyeqingkuang.aspx"); break;

            case "数据分析":
                Response.Redirect("Kaoqinfenxi.aspx"); break;
            case "考勤分析":
                Response.Redirect("Kaoqinfenxi.aspx"); break;
            case "作业分析":
                Response.Redirect("Zuoyefenxi.aspx"); break;
            case "漏报分析":
                Response.Redirect("Loubaofenxi.aspx"); break;
            case "缺勤分析":
                Response.Redirect("Queqinfenxi.aspx"); break;
            case "作业统计":
                Response.Redirect("Zuoyetongji.aspx"); break;

            case "考勤信息":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "录入考勤":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "以往记录":
                Response.Redirect("yiwangjilu.aspx"); break;
        }
    }
    private void lead()//院系领导
    {
        switch (TreeView1.SelectedNode.Text)
        {
            case "首页消息":
                Response.Redirect("message.aspx"); break;
            case "个人信息":
                Response.Redirect("alterPwd.aspx"); break;
            case "修改密码":
                Response.Redirect("alterPwd.aspx"); break;


            case "数据分析":
                Response.Redirect("DAform.aspx"); break;
            case "系部分析":
                Response.Redirect("Department.aspx"); break;
            case "作业分析":
                Response.Redirect("Work.aspx"); break;
            case "漏报分析":
                Response.Redirect("LouBao.aspx"); break;
            case "缺勤汇总":
                Response.Redirect("Queqin.aspx"); break;
            case "导出数据":
                Response.Redirect("exportData.aspx"); break;


            case "考勤信息":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "录入考勤":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "以往记录":
                Response.Redirect("yiwangjilu.aspx"); break;
        }
    }
    private void tutor()//辅导员
    {
        switch (TreeView1.SelectedNode.Text)
        {
            case "首页消息":
                Response.Redirect("message.aspx"); break;
            case "修改密码":
                Response.Redirect("alterPwd.aspx"); break;

            case "数据分析":
                Response.Redirect("departmentFenXi.aspx"); break;
            case "本系分析":
                Response.Redirect("departmentFenXi.aspx"); break;
            case "缺勤汇总":
                Response.Redirect("DEpartment.aspx"); break;
            case "导出数据":
                Response.Redirect("exportData.aspx"); break;

            case "考勤信息":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "录入考勤":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "以往记录":
                Response.Redirect("yiwangjilu.aspx"); break;
        }
    }
    private void tea()//普通教师
    {
        switch (TreeView1.SelectedNode.Text)
        {
            case "首页消息":
                Response.Redirect("message.aspx"); break;
            case "修改密码":
                Response.Redirect("alterPwd.aspx"); break;


            case "考勤信息":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "录入考勤":
                Response.Redirect("lurukaoqin.aspx"); break;
            case "以往记录":
                Response.Redirect("yiwangjilu.aspx"); break;
        }
    }
}

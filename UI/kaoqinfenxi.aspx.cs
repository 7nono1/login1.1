using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using dotnetCHARTING;
using System.Data;
using System.Data.SqlClient;
using BLL;

public partial class kaoqinfenxi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = BLL.kqfx.initialDatattable();
        GridView1.DataKeyNames = new string[] { "系部" };
        GridView1.DataBind();
        if (!Page.IsPostBack)
        {
            DataTable dt = BLL.kqfx.getTacher();


            Drawing("Column", "1");

            DropDownList1.Items.Add(new ListItem("柱状图", "Column"));
            DropDownList1.Items.Add(new ListItem("折线图", "Spline"));

            DropDownList2.Items.Add(new ListItem("全院情况", "1"));
            DropDownList2.Items.Add(new ListItem("信息与艺术系", "2"));
            DropDownList2.Items.Add(new ListItem("建筑系", "3"));
            DropDownList2.Items.Add(new ListItem("机电系", "4"));
            DropDownList2.Items.Add(new ListItem("机械工程系", "5"));
            DropDownList2.Items.Add(new ListItem("食品工程系", "6"));
            DropDownList2.Items.Add(new ListItem("经济管理系", "7"));
            DropDownList2.Items.Add(new ListItem("商务外语系", "8"));
        }

    }

    private void Drawing(string type, string department)
    {
        Charting c = new Charting();

        c.Title = "考勤情况";
        c.XTitle = "周次";
        c.YTitle = "未考勤教师人数（人）";
        c.PicHight = 300; c.PicWidth = 800;
        c.PhaysicalImagePath = "ChartImages";//统计图片存放的文件夹名称，缺少对应的文件夹生成不了统计图片
        c.FileName = "Statistics51aspx";
        if (type == "Column")
        {
            c.Type = SeriesType.Column;
        }
        else
        {
            c.Type = SeriesType.Spline;

        }

        if (department == "1")
        {
            c.DataSource = GetDataSource(1, 7);
        }
        else if (department == "2")
        {
            c.DataSource = GetDataSource(1, 1);
        }
        else if (department == "3")
        {
            c.DataSource = GetDataSource(2, 2);
        }
        else if (department == "4")
        {
            c.DataSource = GetDataSource(3, 3);
        }

        else if (department == "5")
        {
            c.DataSource = GetDataSource(4, 4);
        }

        else if (department == "6")
        {
            c.DataSource = GetDataSource(5, 5);
        }

        else if (department == "7")
        {
            c.DataSource = GetDataSource(6, 6);
        }

        else if (department == "8")
        {
            c.DataSource = GetDataSource(7, 7);
        }
        c.Use3D = true;

        c.CreateStatisticPic(this.Chart1);

    }




    private SeriesCollection GetDataSource(int i, int x)
    {
        SeriesCollection SC = new SeriesCollection();
        string droplist1 = DropDownList2.SelectedValue;


        for (int a = i; a <= x; a++) //对比的项数
        {
            Series s = new Series();
            if (a == 1)
            {
                getSc("信息工程系", s);
                SC.Add(s);
            }
            else if (a == 2)
            {
                getSc("建筑工程系", s);
                SC.Add(s);
            }
            else if (a == 3)
            {
                getSc("会计系", s);
                SC.Add(s);
            }
            else if (a == 4)
            {
                getSc("机械工程系", s);
                SC.Add(s);
            }
            else if (a == 5)
            {
                getSc("食品工程系", s);
                SC.Add(s);
            }
            else if (a == 6)
            {
                getSc("经济管理系", s);
                SC.Add(s);
            }
            else
            {
                getSc("商务外语系", s);
                SC.Add(s);

            }

            //各个数据项代表的名称.     
        }
        return SC;
    }
    public static void getSc(string departement, Series s)
    {
        Random rd = new Random();
        s.Name = (departement);
        for (int b = 1; b <= 19; b++) //X轴尺度个数，如19个周表示有19个尺度数
        {
            DataTable dt = BLL.kqfx.getTeacher(departement, b);
            int i = dt.Rows.Count;
            Element e = new Element();
            e.Name = b.ToString();//对应于X轴个尺度的名称
            e.YValue = i;//与X轴对应的Y轴的数值
            s.Elements.Add(e);
        }
    }




    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        Drawing(DropDownList1.SelectedValue, DropDownList2.SelectedValue);
    }


    protected void DropDownList2_TextChanged(object sender, EventArgs e)
    {
        Drawing(DropDownList2.SelectedValue, DropDownList1.SelectedValue);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
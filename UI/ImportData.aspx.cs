using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImportData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        labdaoru.Visible = false;
        labchuli.Visible = false;
        labxiaoli.Visible = false;
    }
    
    /*
     *导入数据
     */

    string cur = string.Empty;
    private void exl()
    {

        string tempPath = Path.GetTempPath();
        HttpPostedFile ff = this.FileUpload1.PostedFile;//文件所有属性
        string filename = ff.FileName;//文件名
        string path = Server.MapPath("./") + "importDB\\";//要上传的工程文件夹
        string Filename = Path.GetFileName(filename);//文件名
        Filename = System.DateTime.Now.ToString("yyyyMMddhhmmssffff") + Filename;//将日期与文件名合并（带扩展名  ）
        this.cur = path + Filename;//将路径加文件名合并
        ff.SaveAs(this.cur);//上传
        int send = BLL.isLogin.excle(cur, DropDownList1.SelectedValue.ToString().Trim());
        if (send == 1)
        {
            labdaoru.Visible = true;
            labdaoru.Text = "成功！";
        }
        else
        {
            labdaoru.Visible = true;
            labdaoru.Text = "数据重复！";
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "")
        {
            if (FileUpload1.FileName != "")
            {
                exl();
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('请先选择上传文件！');</Script>");
            }
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert('请先选择数据类型！');</Script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        labchuli.Visible = true;
        int i = BLL.Datasplit.a();
        if (i == 1)
        {
            labchuli.Text = "成功！";
        }
        if (i == 2)
        {
            labchuli.Text = "您已解析过课程";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int sday = Convert.ToInt32(TextBox3.Text);//获取起始日
        int sum = sday - 1;//总天数，控制月份转换
        int moth = Convert.ToInt32(DropDownList2.SelectedItem.ToString().Trim());//获取起始月
        int week = Convert.ToInt32(DropDownList3.SelectedItem.ToString().Trim());//获取总周次
        int moco = 0;//每月的总天数
        string we = "";//周次
        string mo = "";//月份
        int y = Convert.ToInt32(TextBox1.Text);
        for (int j = 0; j < week; j++)
        {
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    we = (j + 1).ToString();
                }
                sum++;
                if (moth == 1 || moth == 3 || moth == 5 || moth == 7 || moth == 8 || moth == 10 || moth == 12)
                {
                    moco = 31;
                }
                if (moth == 4 || moth == 6 || moth == 9 || moth == 11)
                {
                    moco = 30;
                }
                if (sum > moco)
                {
                    sum = 1;
                    moth++;

                    if (moth > 12)
                    {
                        moth = 1;
                        y++;
                    }
                    mo = moth.ToString();
                }
                int fan = BLL.isLogin.calender(y.ToString(), moth.ToString(), sum.ToString(), we, (i + 1));
                if (fan == 1)
                {
                    labxiaoli.Visible = true;
                    labxiaoli.Text = "成功";
                }
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        labdaoru.Visible = false;
        labchuli.Visible = false;
    }

    protected void FileUpload1_DataBinding(object sender, EventArgs e)
    {
        labdaoru.Visible = false;
        labchuli.Visible = false;
    }
}
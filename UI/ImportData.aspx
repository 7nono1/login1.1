<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ImportData.aspx.cs" Inherits="ImportData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
         #importmain {
             width:700px;
             height:500px;
             border:1px solid #87CEFA;
         }
         #importtop1,#importtop2 {
             width:100%;
             height:30px;
             background-color:#00FFFF;
             font-size:15px;
         }
         #importcen1 {
             width:100%;
             height:180px;
         }
        .d1 {
            width:150px;
            height:22px;
            border:1px solid #87CEFA;
            border-radius:8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="importmain">
        <div id="importtop1">
            导入教师和课程数据
        </div>
        <div id="importcen1">
            <div style="margin-top:20px; margin-left:80px;">
                选择数据类型：<asp:DropDownList ID="DropDownList1" runat="server" CssClass="d1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
              <asp:ListItem Value="全校教师"></asp:ListItem>
              <asp:ListItem Value="会计系"></asp:ListItem>
              <asp:ListItem Value="信息艺术系"></asp:ListItem>
              <asp:ListItem Value="商务外语系"></asp:ListItem>
              <asp:ListItem Value="食品工程系"></asp:ListItem>
              <asp:ListItem Value="建筑工程系"></asp:ListItem>
              <asp:ListItem Value="机械工程系"></asp:ListItem>
              <asp:ListItem Value="经济管理系"></asp:ListItem>
              <asp:ListItem Value="教务处"></asp:ListItem>
              <asp:ListItem Value="基础教学部"></asp:ListItem>
              <asp:ListItem Value="外聘教师"></asp:ListItem>
          </asp:DropDownList><br /><br />
                选择导入文件：<asp:FileUpload ID="FileUpload1" runat="server" CssClass="d1" OnDataBinding="FileUpload1_DataBinding" />
                <br />
                <br />
                <br />
                <asp:Label ID="labdaoru" runat="server" Text="Label" Width="150px"></asp:Label>
                <asp:Label ID="labchuli" runat="server" Text="Label" Width="150px"></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" Text="请先导入" CssClass="d1" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="处理导入的数据" CssClass="d1" OnClick="Button2_Click" />
            </div>
        </div>
        <div id="importtop2">
            导入校历
        </div>
        <div>
            本学期开始日期：<br />年：<asp:TextBox ID="TextBox1" runat="server" CssClass="d1"></asp:TextBox>
            月：<asp:DropDownList ID="DropDownList2" runat="server" CssClass="d1">
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3" Selected="True"></asp:ListItem>
                <asp:ListItem Value="4"></asp:ListItem>
                <asp:ListItem Value="5"></asp:ListItem>
                <asp:ListItem Value="6"></asp:ListItem>
                <asp:ListItem Value="7"></asp:ListItem>
                <asp:ListItem Value="8"></asp:ListItem>
                <asp:ListItem Value="9"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
              </asp:DropDownList>日：<asp:TextBox ID="TextBox3" runat="server" CssClass="d1"></asp:TextBox>
            <br />
            <br />
            本学期共几周：<br />
            周次：<asp:DropDownList ID="DropDownList3" runat="server" CssClass="d1">
                <asp:ListItem Value="20" Selected="True"></asp:ListItem>
                <asp:ListItem Value="19"></asp:ListItem>
                <asp:ListItem Value="18"></asp:ListItem>
                <asp:ListItem Value="17"></asp:ListItem>
                <asp:ListItem Value="16"></asp:ListItem>
                <asp:ListItem Value="15"></asp:ListItem>
                <asp:ListItem Value="14"></asp:ListItem>
                <asp:ListItem Value="13"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="9"></asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;&nbsp; <asp:Button ID="Button3" runat="server" Text="导入校历" CssClass="d1" OnClick="Button3_Click" />
            <asp:Label ID="labxiaoli" runat="server" Text="ffd"></asp:Label>
        </div>
    </div>
</asp:Content>


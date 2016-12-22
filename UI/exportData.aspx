<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="exportData.aspx.cs" Inherits="exportData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">
        .aa:hover {
            background-color:#F99;
        }
        .aa {
            background-color:#FFFF99;
	cursor: pointer;
        }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" CssClass="aa" runat="server" Font-Size="20px" Height="46px" Text="导出学生缺勤情况" Width="256px" BorderStyle="None" OnClick="Button1_Click" />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button2" CssClass="aa" runat="server" Font-Size="20px" Height="46px" Text="导出教师漏报情况" Width="256px" BorderStyle="None" OnClick="Button2_Click" />
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button3" CssClass="aa" runat="server" Height="46px" Text="导出教师批改作业情况" Width="256px" BorderStyle="None" Font-Size="20px" OnClick="Button3_Click" />
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button4" CssClass="aa" runat="server" Height="46px" Text="导出学生作业完成情况" Width="256px" BorderStyle="None" Font-Size="20px" OnClick="Button4_Click" />
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
</asp:Content>


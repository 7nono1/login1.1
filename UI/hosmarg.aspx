<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="hosmarg.aspx.cs" Inherits="hosmarg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .main {
        }
        .listbox1 {
            margin-top:50px;
        }
        .panel {
        margin-left:20px;
        background-color:#FF9;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="height:35px; margin-left:30px; margin-top:10px; width: 865px;">
        <a href="message.aspx" style="text-decoration:none; color:cyan;">首页</a>><a href="message.aspx" style="text-decoration:none;color:cyan;">消息管理</a>>
         <a href="hosmarg.aspx" style="text-decoration:none;color:cyan;">历史记录</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
         <asp:Button ID="Button1" runat="server" BorderStyle="None" Height="34px" OnClick="Button1_Click" Text="删除已勾选的历史信息" BackColor="#66FF33" />
    </div>
    <div class="main">
        <asp:Panel ID="Panel1" cssClass="panel" runat="server" Height="548px" Width="828px" ScrollBars="Auto">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellSpacing="20" EnableTheming="True">
            </asp:CheckBoxList>
        </asp:Panel>
        </div>
</asp:Content>

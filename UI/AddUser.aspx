<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .d1 {
            width:150px;
            height:22px;
            border:1px solid #87CEFA;
            border-radius:8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="border:1px solid #87CEFA; width:300px; height:450px; margin-left:300px; margin-top:50px;">
        <div style="margin-left:40px;margin-top:20px;">
        教师类型：<asp:DropDownList ID="DropDownList1" runat="server" CssClass="d1">
        <asp:ListItem Value="外聘教师"></asp:ListItem>
        <asp:ListItem Selected="True" Value="本校教师"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        所属部门：<asp:DropDownList ID="DropDownList2" runat="server" CssClass="d1">
            <asp:ListItem Value="安全保卫处"></asp:ListItem>
            <asp:ListItem Value="办公室"></asp:ListItem>
            <asp:ListItem Value="教务处"></asp:ListItem>
            <asp:ListItem Value="基础部"></asp:ListItem>
            <asp:ListItem Value="机电工程系"></asp:ListItem>
            <asp:ListItem Value="经济管理系"></asp:ListItem>
            <asp:ListItem Value="建筑工程系"></asp:ListItem>
            <asp:ListItem Value="会计系"></asp:ListItem>
            <asp:ListItem Value="食品工程系"></asp:ListItem>
            <asp:ListItem Value="商务外语系"></asp:ListItem>
            <asp:ListItem Value="信息艺术系"></asp:ListItem>
            <asp:ListItem Value="学生公寓管理中心"></asp:ListItem>
            <asp:ListItem Value="总务处"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        教师工号：<asp:TextBox ID="TextBox1" runat="server" CssClass="d1"></asp:TextBox>
        <asp:Label ID="labID" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        教师姓名：<asp:TextBox ID="TextBox2" runat="server" CssClass="d1"></asp:TextBox>
        <asp:Label ID="LabName" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        密&nbsp;&nbsp;&nbsp;&nbsp;  码：<input id="Password1" type="password" runat="server" class="d1" /><asp:Label ID="labpwd1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        确认密码：<input id="Password2" type="password" runat="server" class="d1" /><asp:Label ID="labpwd2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />性&nbsp;&nbsp;&nbsp;&nbsp; 别：<asp:DropDownList ID="DropDownList4" runat="server" CssClass="d1">
        <asp:ListItem Value="男"></asp:ListItem>
        <asp:ListItem Selected="True" Value="女"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        权&nbsp;&nbsp;&nbsp;&nbsp;  限：<asp:DropDownList ID="DropDownList3" runat="server" CssClass="d1">
            <asp:ListItem Value="(01)管理员"></asp:ListItem>
            <asp:ListItem Value="(02)院系领导"></asp:ListItem>
            <asp:ListItem Value="(03)辅导员"></asp:ListItem>
            <asp:ListItem Value="(04)普通教师"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br /><asp:Button ID="Button2" runat="server" Height="27px" Text="确定" Width="112px" OnClick="Button2_Click" CssClass="easyui-linkbutton" />
&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Height="27px" Text="重置" Width="112px" OnClick="Button3_Click" CssClass="easyui-linkbutton" />
	</div>
        </div>
</asp:Content>


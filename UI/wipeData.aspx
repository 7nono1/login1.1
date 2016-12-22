<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="wipeData.aspx.cs" Inherits="wipeData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .main {
            height:393px;
            width: 568px;
            margin-left:180px;
            margin-top:50px;
            background-color:#ff2775;
            border-radius:15px;
        }
        .wipebtn {
            border-top-left-radius:15px;
            border-top-right-radius:15px;
            background-color:#00FF99;
            font-size:36px;
            color:white;
        }
            .wipebtn:hover {
                background-color:#ff2775;
            }
        .left {
            width: 481px;
            height: 247px;
            margin-left:50px;
        }
        .right {
            height: 85px;
            width: 568px;
        }
         .wipe1btn {
             border-bottom-left-radius:15px;
             border-bottom-right-radius:15px;
            background-color:#00FF99;
            font-size:36px;
            color:white;
        }
            .wipe1btn:hover {
                background-color:#ff2775;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <div class="main">

        <asp:Button ID="Button1" runat="server" Height="64px" Text="清空所有数据" Width="569px" CssClass="wipebtn" OnClick="Button1_Click" />
        <div class="left">
        <br />
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="教务处" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox2" runat="server" Text="会计系" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox9" runat="server" Text="机械工程系" />
            <br />
        <br />
        <br />
        <asp:CheckBox ID="CheckBox3" runat="server" Text="校历" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox4" runat="server" Text="基础教学部" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox10" runat="server" Text="商务外语系" />
            <br />
        <br />
        <br />
        <asp:CheckBox ID="CheckBox5" runat="server" Text="信息工程系" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox6" runat="server" Text="经济管理系" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox7" runat="server" Text="食品工程系" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:CheckBox ID="CheckBox8" runat="server" Text="建筑工程系" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox11" runat="server" Text="教师" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox12" runat="server" Text="外聘教师" />
            </div>
        <div class="right">

            <asp:Button ID="Button2" runat="server" Height="87px" Text="清空选中数据" Width="569px" CssClass="wipe1btn" OnClick="Button2_Click" />

        </div>

    </div>
</asp:Content>


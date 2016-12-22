<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="sendNew.aspx.cs" Inherits="sendNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .check {
            margin-left:200px;
            margin-top:60px;
            width:656px;
            height:446px;
            background-color:#EEEEEE;
            border-radius:15px;
            border:1px solid #87CEFA;
        }
        .boxleft {
        margin-left:100px;
        }
        .textarea {
            width: 572px;
            height: 387px;
            margin-left:45px;
        }
        .btn1 {
            background-color:#00FF99;
        border-bottom-left-radius:10px;
        font-size:20px;
        color:white;
        }
            .btn1:hover {
            background-color:#ff2775;
            }
        .btn2 {
        border-bottom-right-radius:10px;
        background-color:#00FF99;
        font-size:20px;
        color:white;
        }
            .btn2:hover {
            background-color:#ff2775;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 514px">
        <div class="check">
            <div class="cheleft">
                <br />
                <br />
    <label><asp:CheckBox ID="CheckBox1" runat="server" CssClass="boxleft" Text="院系领导" /></label>
    <label><asp:CheckBox ID="CheckBox2" runat="server" CssClass="boxleft" Text="各系辅导员" /></label>
    <label><asp:CheckBox ID="CheckBox3" runat="server" CssClass="boxleft" Text="教师" /></label>
                </div>
            <div class="textarea">
                <br />
                <textarea runat="server" id="textarea" style="width: 559px; height: 292px"></textarea>
                <br />
                <asp:Button ID="Button1" runat="server" Text="重置" Height="41px" Width="282px" BorderStyle="None" CssClass="btn1" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="发送" Height="41px" Width="279px" BorderStyle="None" CssClass="btn2" OnClick="Button2_Click" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="message.aspx.cs" Inherits="message" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        * {
        margin:0;
        padding:0;
        }
        .main {            
            height: 561px;
            width: 832px;
            margin-left:80px;
        }
        .marglist {       
             height: 509px;
            width: 811px;
            background-color:#FFFF99;
        }
        .checklist {
            float:left;
        }
        .checkboxlist {
        margin-left:20px;
        }
        .btn {            
            height: 52px;
        }
        .btn1 {
            border:none;
            background-color:#FF9;
            border-top-left-radius:10px;
            font-size:26px;
            color:#000;
        }
            .btn1:hover {
                 background-color: #ff2775;
            }
        .btn2 {
            border:none;
            background-color:#FF9;
            font-size:26px;
            color:#000;
        }
            .btn2:hover {
                 background-color: #ff2775;
            }
        .btn3 {
            border:none;
            background-color:#FF9;
            border-top-right-radius:10px;
            font-size:26px;
            color:#000;
        }
            .btn3:hover {
                 background-color: #ff2775;
            }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="main">

        <div class="btn">

            <asp:Button ID="Button1" CssClass="btn1" runat="server" Height="52px" Text="标记已读" Width="264px" OnClick="Button1_Click" />
            <asp:Button ID="Button2" CssClass="btn2" runat="server" Height="52px" Text="全部标记已读" Width="267px" OnClick="Button2_Click" />
            <asp:Button ID="Button3" CssClass="btn3" runat="server" Height="52px" Text="历史记录" Width="264px" OnClick="Button3_Click" />

        </div>

        <div class="marglist">
    <div class="checklist">
        </div>
            <asp:Panel ID="Panel1" runat="server" Height="494px" ScrollBars="Auto">
                <asp:CheckBoxList ID="CheckBoxList1" CssClass="checkboxlist" runat="server" CellSpacing="20">
                </asp:CheckBoxList>
            </asp:Panel>
            </div>
        </div>
</asp:Content>



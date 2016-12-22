<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="alterPwd.aspx.cs" Inherits="alterPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <style type="text/css">
        .Button1 {
    border-style: none;
    border-color: inherit;
    border-width: medium;
    color:#FFF;
    outline: none;
    background: #3ea751;
    border-radius:15px;
	cursor: pointer;
	font-size: 30px;
    margin-left: 4px;
    margin-top:20px;
}
.Button1:hover{
    background-color: #ff2775;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 606px;">
        <div style="height:323px; width:496px; margin-left:28%; margin-top:100px; border-radius:15px; border:1px solid #87CEFA">
            <div style=" margin-left:50px;">
            </div>
            <div style=" margin-left:50px;">
                新密码：<input type="text" id="userPwd" runat="server"
                    style="width: 44%; padding: 2em 1em 0em 2em; font-size: 18px; outline: none; background: no-repeat 10px 15px; font-weight: 100; border-bottom: 1px solid black; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium; margin-left: 14px;" />
                 <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Label"></asp:Label>
            </div>
            <div style=" margin-left:50px;">
                确认密码：<input type="text" id="surePwd" runat="server"
                    style="width: 44%; padding: 2em 1em 0em 2em; font-size: 18px; outline: none; background: no-repeat 10px 15px; font-weight: 100; border-bottom: 1px solid black; border-left-style: none; border-left-color: inherit; border-left-width: medium; border-right-style: none; border-right-color: inherit; border-right-width: medium; border-top-style: none; border-top-color: inherit; border-top-width: medium;" />
                 <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Label"></asp:Label>
            </div>
            <div style="height:59px; width:213px; margin-left:126px; margin-top:2em; border-radius:15px;">
                
                <asp:Button ID="Button1" CssClass="Button1" runat="server" Height="53px"  Text="提交" Width="205px" OnClick="Button1_Click" BackColor="#00ff99"  />
                
            </div>
        </div>
       

    </div>
</asp:Content>


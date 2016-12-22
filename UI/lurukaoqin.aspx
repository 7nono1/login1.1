<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="lurukaoqin.aspx.cs" Inherits="lurukaoqin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin-left:150px;">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        Height="16px" OnPageIndexChanging="GridView1_PageIndexChanging" Width="791px" OnRowCommand="GridView1_RowCommand" >
         <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="工号" HeaderText="工号" />
            <asp:BoundField DataField="教师姓名" HeaderText="教师姓名" />
            <asp:BoundField DataField="周次" HeaderText="周次" />
            <asp:BoundField DataField="星期" HeaderText="星期" />
            <asp:BoundField DataField="节次" HeaderText="节次" />
            <asp:BoundField DataField="课程" HeaderText="课程" />
            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="easyui-linkbutton" ControlStyle-Width="50px" HeaderText="考勤" Text="考勤"  CommandName="select" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
        </div>
</asp:Content>


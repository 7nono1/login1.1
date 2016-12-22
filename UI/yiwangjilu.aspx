<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="yiwangjilu.aspx.cs" Inherits="yiwangjilu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Panel ID="Panel1" runat="server" Height="515px" ScrollBars="Auto">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" Height="154px" Width="693px" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="课程" HeaderText="课程名" ItemStyle-Width="200px" >
            <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="周次" HeaderText="周次" />
            <asp:BoundField DataField="节次" HeaderText="节次" />
            <asp:BoundField DataField="星期" HeaderText="星期" />
            <asp:BoundField DataField="地点" HeaderText="上课地点" />
            <asp:BoundField DataField="是否考勤" HeaderText="是否考勤" />
            <asp:BoundField DataField="布置作业" HeaderText="是否布置作业" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    </asp:Panel>

</asp:Content>


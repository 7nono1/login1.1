<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="kaoqinfenxi.aspx.cs" Inherits="kaoqinfenxi" %>
<%@ Register assembly="dotnetCHARTING" namespace="dotnetCHARTING" tagprefix="dotnetCHARTING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="3" AutoGenerateColumns="False" Height="200px" Width="800px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="系部" DataField="系部" />
            <asp:BoundField HeaderText="老师考勤总次数" DataField="老师考勤总次数" />
            <asp:BoundField DataField="未考勤次数" HeaderText="未考勤人数" />
            <asp:BoundField HeaderText="未考勤率" DataField="未考勤率" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <dotnetCHARTING:Chart ID="Chart1" runat="server" Height="355px" Width="375px" Enabled="False">
    </dotnetCHARTING:Chart>
    <asp:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" OnTextChanged="DropDownList1_TextChanged"  >
    </asp:DropDownList>
    </asp:Content>


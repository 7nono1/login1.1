<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="waipinjiaoshi.aspx.cs" Inherits="waipinjiaoshi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .d1 {
            width:150px;
            height:22px;
            border:1px solid #87CEFA;
            border-radius:8px;
        }
        .jscxcon1 {
            margin-top:20px;
        }
        #jscxcon {
            margin-top:30px;
            margin-left:200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="jscxcon">
    <div class="top1">查询范围
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Size="12pt"
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" CssClass="d1">
        <asp:ListItem>所有记录</asp:ListItem>
        <asp:ListItem>按部门查询</asp:ListItem>
        <asp:ListItem>按教师工号查询</asp:ListItem>
        <asp:ListItem>按权限查询</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="查询条件"></asp:Label><asp:TextBox ID="TextBox1"  CssClass="d1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" CssClass="d1" />

    </div>
    <div class="jscxcon1"  ><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" PageSize="16" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
        onrowupdating="GridView1_RowUpdating" 
            onrowdatabound="GridView1_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="部门" HeaderText="所属部门" ReadOnly="True">
            <ControlStyle Width="100px" />
            <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="工号" HeaderText="教师工号" ReadOnly="True">
            <ControlStyle Width="100px" />
            <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="姓名" HeaderText="教师姓名" ReadOnly="True">
            <ControlStyle Width="100px" />
            <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="密码" HeaderText="用户密码" Visible="False">
            <ControlStyle Width="100px" />
            <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="教师权限">
                <ItemTemplate>
                    <asp:Label ID="labRols" runat="server" Text='<%# Bind("权限") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList runat="server" ID="dropRols">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True">
            <ControlStyle Width="100px" />
            <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
            <ControlStyle Width="100px" />
            <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
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
        <br />
        </div>
        </div>
</asp:Content>


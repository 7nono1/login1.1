<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="lurukaoqinxiangxi.aspx.cs" Inherits="lurukaoqinxiangxi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left: 150px; margin-top: 50px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUnNormal" runat="server" Text="返回主页面" OnClick="btnUnNormal_Click" Style="border: Solid 1px #87CEFA; width: 100px;" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAttendance" runat="server" OnClick="btnAttendance_Click" Text="上报考勤结果" Style="border: Solid 1px #87CEFA; width: 100px;" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvAttendanceDetails" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="学号" Font-Size="12px" CellSpacing="2">
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <Columns>
                        <asp:BoundField DataField="系部" HeaderText="系部" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="行政班级" HeaderText="行政班级" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="学号" HeaderText="学号" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="姓名" HeaderText="姓名" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="出勤情况">
                            <ItemTemplate>
                                <asp:RadioButton ID="rdoNormal" runat="server" GroupName="g1" Text="正常" Checked="true"
                                    AutoPostBack="false" OnCheckedChanged="rdo_CheckChange" />
                                <asp:RadioButton ID="rdoLate" runat="server" GroupName="g1" Text="迟到"
                                    AutoPostBack="false" OnCheckedChanged="rdo_CheckChange" />
                                <asp:RadioButton ID="rdoAbsence" runat="server" GroupName="g1" Text="旷课"
                                    AutoPostBack="false" OnCheckedChanged="rdo_CheckChange" />
                                <asp:RadioButton ID="rdoEarly" runat="server" GroupName="g1" Text="早退"
                                    AutoPostBack="false" OnCheckedChanged="rdo_CheckChange" />
                                <asp:RadioButton ID="rdoLeave" runat="server" GroupName="g1" Text="请假"
                                    AutoPostBack="false" OnCheckedChanged="rdo_CheckChange" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="true" ForeColor="White" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="true" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:SqlDataSource ID="sqlDataSourceAttendanceDetails" runat="server" ConnectionString="%$ConnectionStrings:SDBISASConnectionString2 %>"
                    SelectCommand="SELECT DISTINCT[studentDepartment],[StudentID],[StudentName],[t4]FROM[TabAllCourse]WHERE(([TeacherID]=@TeacherID)AND([Course]=@Course)AND([TimeAndArea]=@TimeAndArea))">
                    <SelectParameters>
                        <asp:SessionParameter Name="TeacherID" SessionField="UserID" Type="String" />
                        <asp:SessionParameter Name="Course" SessionField="CurrentCourse" Type="String" />
                        <asp:SessionParameter Name="TimeAndArea" SessionField="WeekRange" Type="String" />
                    </SelectParameters>

                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Label_Assign_Master.aspx.cs" Inherits="Admin_Label_Assign_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>

    <table align="center" style="width: 600px; height: 465px">
        <tr>
        <td>
        <table align="center">
      <tr>
            <td align="center" colspan="3">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="USER MANAGE FORM"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Assign ID"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Select Level"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="220px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Select ID"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="220px" 
                    AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtname" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lb_Message" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table>
                    <tr>
                        <td>
                        <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Save" Width="65px" 
                            onclick="Button1_Click" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Reset" Width="65px" 
                            onclick="Button2_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="Assign_ID" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="Assign_ID" HeaderText="Assign_ID" ReadOnly="True" 
                            SortExpression="Assign_ID" />
                        <asp:BoundField DataField="Level_Name" HeaderText="Level_Name" 
                            SortExpression="Level_Name" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Mode" HeaderText="Mode" SortExpression="Mode" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
                    DeleteCommand="DELETE FROM [Level_AssignMaster] WHERE [Assign_ID] = @Assign_ID" 
                    InsertCommand="INSERT INTO [Level_AssignMaster] ([Assign_ID], [Level_Name], [ID], [Name], [Mode]) VALUES (@Assign_ID, @Level_Name, @ID, @Name, @Mode)" 
                    SelectCommand="SELECT * FROM [Level_AssignMaster] ORDER BY [Assign_ID], [ID], [Level_Name]" 
                    
                    UpdateCommand="UPDATE [Level_AssignMaster] SET [Level_Name] = @Level_Name, [ID] = @ID, [Name] = @Name, [Mode] = @Mode WHERE [Assign_ID] = @Assign_ID">
                    <DeleteParameters>
                        <asp:Parameter Name="Assign_ID" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Level_Name" Type="String" />
                        <asp:Parameter Name="ID" Type="String" />
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Mode" Type="String" />
                        <asp:Parameter Name="Assign_ID" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Assign_ID" Type="Decimal" />
                        <asp:Parameter Name="Level_Name" Type="String" />
                        <asp:Parameter Name="ID" Type="String" />
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Mode" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


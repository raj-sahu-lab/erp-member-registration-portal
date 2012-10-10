<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="VillageMaster.aspx.cs" Inherits="Admin_VillageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="VILLAGE MASTER"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Sr No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
            </td>
             <td><asp:Label ID="Label3" runat="server" Text="Select Country"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_country" runat="server" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                            <asp:ListItem>--Select Country--</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
         </asp:DropDownList>
        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="State Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_state" runat="server" Width="195px" 
                    AutoPostBack="True" onselectedindexchanged="ddl_state_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="District Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_district" runat="server" Width="195px" 
                    AutoPostBack="True" onselectedindexchanged="ddl_district_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>       
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Vidhansabha Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Vidhansabha" runat="server" Width="195px">
                </asp:DropDownList>
            </td>
             <td>
                <asp:Label ID="Label2" runat="server" Text="Village Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlabel_name" runat="server" Width="170px"></asp:TextBox>
            </td>
        </tr>     
        <tr>
            <td colspan="4">
                <asp:Label ID="lb_Message" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
          
                        <td align="right">
                        <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Save" Width="65px" 
                            onclick="Button1_Click" />
                        </td>
                        <td align="center">
                            &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Reset" Width="65px" 
                            onclick="Button2_Click" />
                        </td>
                  <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="Sr_No" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="Sr_No" HeaderText="Sr_No" ReadOnly="True" 
                            SortExpression="Sr_No" />
                        <asp:BoundField DataField="Country" HeaderText="Country" 
                            SortExpression="Country" />
                        <asp:BoundField DataField="State_Name" HeaderText="State_Name" 
                            SortExpression="State_Name" />
                        <asp:BoundField DataField="District" HeaderText="District" 
                            SortExpression="District" />
                        <asp:BoundField DataField="Vidhansabha" HeaderText="Vidhansabha" 
                            SortExpression="Vidhansabha" />
                        <asp:BoundField DataField="Village" HeaderText="Village" 
                            SortExpression="Village" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
                    DeleteCommand="DELETE FROM [VillageMaster] WHERE [Sr_No] = @Sr_No" 
                    InsertCommand="INSERT INTO [VillageMaster] ([Sr_No], [Country], [State_Name], [District], [Vidhansabha], [Village]) VALUES (@Sr_No, @Country, @State_Name, @District, @Vidhansabha, @Village)" 
                    SelectCommand="SELECT * FROM [VillageMaster] ORDER BY [Sr_No], [Country], [State_Name]" 
                    UpdateCommand="UPDATE [VillageMaster] SET [Country] = @Country, [State_Name] = @State_Name, [District] = @District, [Vidhansabha] = @Vidhansabha, [Village] = @Village WHERE [Sr_No] = @Sr_No">
                    <DeleteParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Country" Type="String" />
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="District" Type="String" />
                        <asp:Parameter Name="Vidhansabha" Type="String" />
                        <asp:Parameter Name="Village" Type="String" />
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                        <asp:Parameter Name="Country" Type="String" />
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="District" Type="String" />
                        <asp:Parameter Name="Vidhansabha" Type="String" />
                        <asp:Parameter Name="Village" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


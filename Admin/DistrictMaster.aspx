<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DistrictMaster.aspx.cs" Inherits="Admin_DistrictMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="DISTRICT MASTER"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Entry no."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
            </td>
        </tr>
          <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Select Rashtra"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_country" runat="server" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Select ORG wise Kshetra/Zonee"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_kshetraorg" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetraorg_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Select RSS wise Kshetra/Zonee"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_kshetrarss" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetrarss_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="RSS Wise Prant Name "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_prant_rss" runat="server" AutoPostBack="true" Width="195px" OnSelectedIndexChanged="ddl_prant_rss_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="ORG Wise Prant Name "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_prant_org" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_org_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Govt Wise Prant Name "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_prant_govt" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_govt_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
          <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Loksabha Name "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_lokshabhaname" runat="server" Width="195px">
                        </asp:DropDownList>
                    </td>
                </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="District Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlabel_name" runat="server" Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
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
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="Sr_No" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        
                        <asp:BoundField DataField="Sr_No" HeaderText="Entry No." ReadOnly="True" 
                            SortExpression="Sr_No" />
                         <asp:BoundField DataField="kshetraorg" HeaderText="kshetra org"/>
                                <asp:BoundField DataField="kshetrarss" HeaderText="kshetra rss"/>
                                <asp:BoundField DataField="prantrss" HeaderText="pran trss"/>
                                <asp:BoundField DataField="prantorg" HeaderText="prant org"/>
                                 <asp:BoundField DataField="prantgovt" HeaderText="prant govt"/>
                                <asp:BoundField DataField="Loksabha" HeaderText="Loksabha" />
                        <asp:BoundField DataField="District" HeaderText="District" 
                            SortExpression="District" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="false" 
                            ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
                    DeleteCommand="DELETE FROM [DistrictMaster] WHERE [Sr_No] = @Sr_No" 
                    InsertCommand="INSERT INTO [DistrictMaster] ([Sr_No], [State_Name], [District]) VALUES (@Sr_No, @State_Name, @District)" 
                    SelectCommand="SELECT * FROM [DistrictMaster] ORDER BY [Sr_No], [State_Name], [District]" 
                    
                    UpdateCommand="UPDATE [DistrictMaster] SET [State_Name] = @State_Name, [District] = @District WHERE [Sr_No] = @Sr_No">
                    <DeleteParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="District" Type="String" />
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="District" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


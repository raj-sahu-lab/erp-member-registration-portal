<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TehsilMaster.aspx.cs" Inherits="Admin_TehsilMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="Tehsil MASTER"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Entry No."></asp:Label>
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
                        <asp:Label ID="Label11" runat="server" Text="Loksabha Name "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_lokshabhaname" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_lokshabhaname_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="District Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_distr" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_distr_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>      
         <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Vidhansabha  Name"></asp:Label>
            </td>
            <td>
                 <asp:DropDownList ID="ddl_vidhansabha" runat="server" Width="195px">
                        </asp:DropDownList>
            </td>
        </tr>      
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Tehsil Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlabel_name" runat="server" Width="170px"></asp:TextBox>
            </td>
            
        </tr>    
        <tr>
             <td>
                <asp:Label ID="Label4" runat="server" Text="Tehsil Code"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcode" runat="server" Width="170px" MaxLength="3"></asp:TextBox>
            </td>
        </tr>  
        <tr>
            <td colspan="2">
                <asp:Label ID="lb_Message" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
          
            <td align="center" colspan="2">
                        <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Save" Width="65px" 
                            onclick="Button1_Click" />
                     
                            &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Reset" Width="65px" 
                            onclick="Button2_Click" />
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
                        <asp:BoundField DataField="Country" HeaderText="Rastra" 
                            SortExpression="Country" />
                       <asp:BoundField DataField="kshetraorg" HeaderText="Org kshetra"/>
                                <asp:BoundField DataField="kshetrarss" HeaderText="RSS kshetra"/>
                                <asp:BoundField DataField="prantrss" HeaderText="RSS Wise Prant"/>
                                <asp:BoundField DataField="prantorg" HeaderText="Org Wise prant"/>
                                 <asp:BoundField DataField="prantgovt" HeaderText="Govt Wise prant"/>
                                <asp:BoundField DataField="Loksabha" HeaderText="Loksabha" />
                        <asp:BoundField DataField="District" HeaderText="District" 
                            SortExpression="District" />
                         <asp:BoundField DataField="Vidhansabha" HeaderText="Vidhansabha" />
                        <asp:BoundField DataField="Tehsil" HeaderText="Tehsil" 
                            SortExpression="Tehsil" />
                        <asp:BoundField DataField="Tehsil_Code" HeaderText="Code" /> 
                         <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                            ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
                    DeleteCommand="DELETE FROM [TehsilMaster] WHERE [Sr_No] = @Sr_No" 
                    InsertCommand="INSERT INTO [TehsilMaster] ([Sr_No], [Country], [State_Name], [District], [Tehsil], [Tehsil_Code]) VALUES (@Sr_No, @Country, @State_Name, @District, @Tehsil, @Tehsil_Code)" 
                    SelectCommand="SELECT * FROM [TehsilMaster] ORDER BY [Sr_No], [Tehsil_Code], [Tehsil]" 
                    UpdateCommand="UPDATE [TehsilMaster] SET [Country] = @Country, [State_Name] = @State_Name, [District] = @District, [Tehsil] = @Tehsil, [Tehsil_Code] = @Tehsil_Code WHERE [Sr_No] = @Sr_No">
                    <DeleteParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Country" Type="String" />
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="District" Type="String" />
                        <asp:Parameter Name="Tehsil" Type="String" />
                        <asp:Parameter Name="Tehsil_Code" Type="String" />
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                        <asp:Parameter Name="Country" Type="String" />
                        <asp:Parameter Name="State_Name" Type="String" />
                        <asp:Parameter Name="District" Type="String" />
                        <asp:Parameter Name="Tehsil" Type="String" />
                        <asp:Parameter Name="Tehsil_Code" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


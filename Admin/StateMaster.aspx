<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="StateMaster.aspx.cs" Inherits="Admin_StateMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px"
                            Font-Underline="True" ForeColor="#003399" Text="PRANT MASTER"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <table align="center">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="Entry No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="135px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="Select Rastra"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_country" runat="server" Width="160px" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="Select ORG wise Kshetra/Zone"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_ORGzone" runat="server" Width="160px" AutoPostBack="true" OnSelectedIndexChanged="ddl_ORGzone_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="Select RSS wise Kshetra/Zone"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_RSSzone" runat="server" Width="160px" AutoPostBack="false">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="RSS Wise Prant Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtrss_prant_name" runat="server" Width="135px"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="ORG Wise Prant Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg_prant_name" runat="server" Width="135px"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="Govt Wise Prant Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtgovt_prant_name" runat="server" Width="135px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="Prant Code"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtcode" runat="server" Width="135px" MaxLength="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:center">
                                                <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True"
                                                    ForeColor="White" Height="30px" Text="Save" Width="65px"
                                                    OnClick="Button1_Click" />
                                           
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True"
                            ForeColor="White" Height="30px" Text="Reset" Width="65px"
                            OnClick="Button2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lb_Message" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        
                        </table>

                    </td>
                   
                </tr>
                <tr>
                    <td>
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                        DataKeyNames="Sr_No" DataSourceID="SqlDataSource1">
                                        <RowStyle ForeColor="#000066" />
                                        <Columns>
                                           
                                            <asp:BoundField DataField="Sr_No" HeaderText="Entry No" ReadOnly="True"
                                                SortExpression="Sr_No" />
                                            <asp:BoundField DataField="Country" HeaderText="Rastra" />
                                            <asp:BoundField DataField="orgwisekshetra" HeaderText="ORG Wise Kshetra" />
                                            <asp:BoundField DataField="rsswisekshetra" HeaderText="RSS Wise Kshetra" />
                                            
                                            <asp:BoundField DataField="rsswiseprant" HeaderText="RSS Prant" />
                                                  <asp:BoundField DataField="orgwiseprant" HeaderText="ORG Prant" />
                                                        <asp:BoundField DataField="govtwiseprant" HeaderText="Govt Prant" />
                                          
                                            <asp:BoundField DataField="State_Code" HeaderText="State_Code" /> 
                                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True"
                                                ShowSelectButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
<%-- InsertCommand="INSERT INTO [StateMaster] ([Sr_No], [Country], [Zone], [State_Name], [State_Code]) VALUES (@Sr_No, @Country, @Zone, @State_Name, @State_Code)"
                                       --%>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                        ConnectionString="<%$ ConnectionStrings:BITRSS %>"
                                        DeleteCommand="DELETE FROM [StateMaster] WHERE [Sr_No] = @Sr_No"
                                        SelectCommand="SELECT * FROM [StateMaster] ORDER BY [Sr_No]"
                                        UpdateCommand="UPDATE [StateMaster] SET [Country] = @Country,orgwisekshetra=@orgwisekshetra,rsswisekshetra=@rsswisekshetra,rsswiseprant=@rsswiseprant,orgwiseprant=@orgwiseprant,govtwiseprant=@govtwiseprant, [State_Code] = @State_Code WHERE [Sr_No] = @Sr_No">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Sr_No" Type="Decimal" />
                                        </DeleteParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Country" Type="String" />
                                      
                                            <asp:Parameter Name="orgwisekshetra" Type="String" />
                                            <asp:Parameter Name="rsswisekshetra" Type="String" />
                                            <asp:Parameter Name="rsswiseprant" Type="String" />
                                            <asp:Parameter Name="orgwiseprant" Type="String" />
                                            <asp:Parameter Name="govtwiseprant" Type="String" />
                                            <asp:Parameter Name="State_Name" Type="String" />
                                            <asp:Parameter Name="State_Code" Type="String" />
                                            <asp:Parameter Name="Sr_No" Type="Decimal" />
                                        </UpdateParameters>
                                     
                                    </asp:SqlDataSource>
<%--   <InsertParameters>
                                            <asp:Parameter Name="Sr_No" Type="Decimal" />
                                            <asp:Parameter Name="Country" Type="String" />
                                            <asp:Parameter Name="Zone" Type="String" />
                                            <asp:Parameter Name="State_Name" Type="String" />
                                            <asp:Parameter Name="State_Code" Type="String" />
                                        </InsertParameters>--%>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


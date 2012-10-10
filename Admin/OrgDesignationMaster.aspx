<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="RSSDesignationMaster.aspx.cs" Inherits="Admin_RSSDesignationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px"
                            Font-Underline="True" ForeColor="#003399" Text="DESIGNATION MASTER"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table>
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
                                                <asp:Label ID="Label3" runat="server" Text="Select level"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_level" runat="server" Width="159px">

                                                </asp:DropDownList>
                                               </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Designation"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtlabel_name" runat="server" Width="135px"></asp:TextBox>
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
                            <tr>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                        AllowSorting="True" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                        DataKeyNames="Sr_No" DataSourceID="SqlDataSource1">
                                        <RowStyle ForeColor="#000066" />
                                        <Columns>
                                           
                                            <asp:BoundField DataField="Sr_No" HeaderText="Entry No." ReadOnly="True"
                                                SortExpression="Sr_No" />
                                            <asp:BoundField DataField="Designation_Name" HeaderText="Designation_Name"
                                                SortExpression="Designation_Name" />
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
                                        DeleteCommand="DELETE FROM [RSSDesignationMaster] WHERE [Sr_No] = @Sr_No"
                                        InsertCommand="INSERT INTO [RSSDesignationMaster] ([Sr_No], [Designation_Name]) VALUES (@Sr_No, @Designation_Name)"
                                        SelectCommand="SELECT * FROM [RSSDesignationMaster] ORDER BY [Sr_No], [Designation_Name]"
                                        UpdateCommand="UPDATE [RSSDesignationMaster] SET [Designation_Name] = @Designation_Name WHERE [Sr_No] = @Sr_No">
                                        <DeleteParameters>
                                            <asp:Parameter Name="Sr_No" Type="Decimal" />
                                        </DeleteParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="Designation_Name" Type="String" />
                                            <asp:Parameter Name="Sr_No" Type="Decimal" />
                                        </UpdateParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="Sr_No" Type="Decimal" />
                                            <asp:Parameter Name="Designation_Name" Type="String" />
                                        </InsertParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                   
                                                <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True"
                                                    ForeColor="White" Height="30px" Text="Save" Width="65px"
                                                    OnClick="Button1_Click" />
                                            
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True"
                            ForeColor="White" Height="30px" Text="Reset" Width="65px"
                            OnClick="Button2_Click" />
                                           
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


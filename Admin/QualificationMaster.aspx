<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="QualificationMaster.aspx.cs" Inherits="Admin_QualificationMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="Qualification MASTER"></asp:Label>
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
                <asp:Label ID="Label2" runat="server" Text="Qualification Name"></asp:Label>
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
                     
                        <asp:BoundField DataField="Sr_No" HeaderText="Entry No" ReadOnly="True" 
                            SortExpression="Sr_No" />
                        <asp:BoundField DataField="Qualification_Name" HeaderText="Qualification_Name" 
                            SortExpression="Qualification_Name" /> 
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
                    DeleteCommand="DELETE FROM [QualificationMaster] WHERE [Sr_No] = @Sr_No" 
                    InsertCommand="INSERT INTO [QualificationMaster] ([Sr_No], [Qualification_Name]) VALUES (@Sr_No, @Qualification_Name)" 
                    SelectCommand="SELECT * FROM [QualificationMaster] ORDER BY [Sr_No], [Qualification_Name]" 
                    
                    UpdateCommand="UPDATE [QualificationMaster] SET [Qualification_Name] = @Qualification_Name WHERE [Sr_No] = @Sr_No">
                    <DeleteParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Qualification_Name" Type="String" />
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                        <asp:Parameter Name="Qualification_Name" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
            </tr>
            <tr>            
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
            </table>
            
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


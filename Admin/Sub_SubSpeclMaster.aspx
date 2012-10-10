<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Sub_SubSpeclMaster.aspx.cs" Inherits="Admin_Sub_SubSpeclMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="SUB SUB SPECIALIZATION MASTER"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Entry No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
            </td>
            <td><asp:Label ID="Label3" runat="server" Text="Select Specialization"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_country" runat="server" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged"></asp:DropDownList>                           
        </td>
        </tr>
       
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Select Sub Specialization"></asp:Label>
            </td>
            <td>             
                <asp:DropDownList ID="ddl_state" runat="server" Width="195px">
                </asp:DropDownList>
            </td>
             <td>
                <asp:Label ID="Label2" runat="server" Text="Sub-Sub Specialization"></asp:Label>
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
           
          <td align="center" colspan="4" >

                        <asp:Button ID="Button1" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Save" Width="65px" 
                            onclick="Button1_Click" />
                      
                        <asp:Button ID="Button2" runat="server" BackColor="#FF6600" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Reset" Width="65px" 
                            onclick="Button2_Click" />
                        </td>
                
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="Sr_No" DataSourceID="SqlDataSource1">
                    <RowStyle ForeColor="#000066" />
                    <Columns>
                        
                        <asp:BoundField DataField="Sr_No" HeaderText="Entry No" ReadOnly="True" 
                            SortExpression="Sr_No" />
                        <asp:BoundField DataField="Specialization_Name" 
                            HeaderText="Specialization_Name" SortExpression="Specialization_Name" />
                        <asp:BoundField DataField="Sub_Specialization" HeaderText="Sub_Specialization" 
                            SortExpression="Sub_Specialization" />
                        <asp:BoundField DataField="Sub_Sub_Specialization" 
                            HeaderText="Sub_Sub_Specialization" SortExpression="Sub_Sub_Specialization" />
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
                    DeleteCommand="DELETE FROM [Sub_SubSpeclMaster] WHERE [Sr_No] = @Sr_No" 
                    InsertCommand="INSERT INTO [Sub_SubSpeclMaster] ([Sr_No], [Specialization_Name], [Sub_Specialization], [Sub_Sub_Specialization]) VALUES (@Sr_No, @Specialization_Name, @Sub_Specialization, @Sub_Sub_Specialization)" 
                    SelectCommand="SELECT * FROM [Sub_SubSpeclMaster] ORDER BY [Sr_No], [Specialization_Name], [Sub_Specialization]" 
                    UpdateCommand="UPDATE [Sub_SubSpeclMaster] SET [Specialization_Name] = @Specialization_Name, [Sub_Specialization] = @Sub_Specialization, [Sub_Sub_Specialization] = @Sub_Sub_Specialization WHERE [Sr_No] = @Sr_No">
                    <DeleteParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Specialization_Name" Type="String" />
                        <asp:Parameter Name="Sub_Specialization" Type="String" />
                        <asp:Parameter Name="Sub_Sub_Specialization" Type="String" />
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Sr_No" Type="Decimal" />
                        <asp:Parameter Name="Specialization_Name" Type="String" />
                        <asp:Parameter Name="Sub_Specialization" Type="String" />
                        <asp:Parameter Name="Sub_Sub_Specialization" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


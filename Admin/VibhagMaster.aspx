<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="VibhagMaster.aspx.cs" Inherits="Admin_VibhagMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center">
        <tr>
            <td align="center">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="VIBHAG MASTER"></asp:Label>
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
                <asp:Label ID="Label1" runat="server" Text="Sr No."></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtcomm_id" runat="server" ReadOnly="True" Width="135px"></asp:TextBox>
            </td>           
        </tr>
        <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Select Country"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_country" runat="server" Width="160px" AutoPostBack="true" 
                onselectedindexchanged="ddl_country_SelectedIndexChanged">
        </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label6" runat="server" Text="Select Zone"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_zone" runat="server" Width="160px" AutoPostBack="true" 
                onselectedindexchanged="ddl_zone_SelectedIndexChanged">
        </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label4" runat="server" Text="Select Prant"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_prant" runat="server" Width="160px" AutoPostBack="True" 
                onselectedindexchanged="ddl_prant_SelectedIndexChanged">
        </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label7" runat="server" Text="Select Kshetra"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_kshetra" runat="server" Width="160px" AutoPostBack="false">
        </asp:DropDownList>
        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Vibhag Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlabel_name" runat="server" Width="135px"></asp:TextBox>
            </td>
        </tr>
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
                          <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                              ShowSelectButton="True" />
                          <asp:BoundField DataField="Sr_No" HeaderText="Sr_No" ReadOnly="True" 
                              SortExpression="Sr_No" />
                          <asp:BoundField DataField="Country" HeaderText="Country" 
                              SortExpression="Country" />
                          <asp:BoundField DataField="Zone" HeaderText="Zone" SortExpression="Zone" />
                          <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                          <asp:BoundField DataField="Kshetra" HeaderText="Kshetra" 
                              SortExpression="Kshetra" />
                          <asp:BoundField DataField="Vibhag_Name" HeaderText="Vibhag_Name" 
                              SortExpression="Vibhag_Name" />
                      </Columns>
                      <FooterStyle BackColor="White" ForeColor="#000066" />
                      <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                      <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                  </asp:GridView>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
                      DeleteCommand="DELETE FROM [VibhagMaster] WHERE [Sr_No] = @Sr_No" 
                      InsertCommand="INSERT INTO [VibhagMaster] ([Sr_No], [Country], [Zone], [State], [Kshetra], [Vibhag_Name]) VALUES (@Sr_No, @Country, @Zone, @State, @Kshetra, @Vibhag_Name)" 
                      SelectCommand="SELECT * FROM [VibhagMaster] ORDER BY [Sr_No], [Country], [Zone]" 
                      
                      UpdateCommand="UPDATE [VibhagMaster] SET [Country] = @Country, [Zone] = @Zone, [State] = @State, [Kshetra] = @Kshetra, [Vibhag_Name] = @Vibhag_Name WHERE [Sr_No] = @Sr_No">
                      <DeleteParameters>
                          <asp:Parameter Name="Sr_No" Type="Decimal" />
                      </DeleteParameters>
                      <UpdateParameters>
                          <asp:Parameter Name="Country" Type="String" />
                          <asp:Parameter Name="Zone" Type="String" />
                          <asp:Parameter Name="State" Type="String" />
                          <asp:Parameter Name="Kshetra" Type="String" />
                          <asp:Parameter Name="Vibhag_Name" Type="String" />
                          <asp:Parameter Name="Sr_No" Type="Decimal" />
                      </UpdateParameters>
                      <InsertParameters>
                          <asp:Parameter Name="Sr_No" Type="Decimal" />
                          <asp:Parameter Name="Country" Type="String" />
                          <asp:Parameter Name="Zone" Type="String" />
                          <asp:Parameter Name="State" Type="String" />
                          <asp:Parameter Name="Kshetra" Type="String" />
                          <asp:Parameter Name="Vibhag_Name" Type="String" />
                      </InsertParameters>
                  </asp:SqlDataSource>
              </td>
              </tr>          
            </table>
            
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


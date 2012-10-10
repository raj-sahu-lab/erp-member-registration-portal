<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="KshetraMaster.aspx.cs" Inherits="Admin_KshetraMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center" style="width:100%">
        <tr>
            <td align="center">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="KSHETRA MASTER"></asp:Label>
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
        <td><asp:Label ID="Label3" runat="server" Text="Select Rastra"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddl_country" runat="server" Width="160px">
        </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label6" runat="server" Text="ORG wise Kshetra Zone"></asp:Label></td>
        <td>
         <asp:TextBox ID="txtorgwise" runat="server" Width="135px"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td><asp:Label ID="Label4" runat="server" Text="RSS wise Kshetra Zone" ></asp:Label></td>
        <td>
       <asp:TextBox ID="txtrsswise" runat="server" Width="135px" ></asp:TextBox>
        </td>
        </tr>
       <%-- <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Kshetra Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtlabel_name" runat="server" Width="135px"></asp:TextBox>
            </td>
        </tr>--%>
         <tr>
                        <td style="text-align:right">
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
                      DataKeyNames="Sr_No" DataSourceID="SqlDataSource1" Width="100%">
                      <RowStyle ForeColor="#000066" />
                      <Columns>
                          
                          <asp:BoundField DataField="Sr_No" HeaderText="Entry No" ReadOnly="True" 
                              SortExpression="Sr_No" />
                          <asp:BoundField DataField="Country" HeaderText="Rastra" 
                              SortExpression="Country" />
                          <asp:BoundField DataField="orgwise" HeaderText="ORG Wise" SortExpression="orgwise" />
                          <asp:BoundField DataField="rsswise" HeaderText="RSS Wise" SortExpression="rsswise" />
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
                      DeleteCommand="DELETE FROM [KshetraMaster] WHERE [Sr_No] = @Sr_No" 
                      InsertCommand="INSERT INTO [KshetraMaster] ([Sr_No], [Country], [orgwise], [rsswise]) VALUES (@Sr_No, @Country, @orgwise, @rsswise)" 
                      SelectCommand="SELECT * FROM [KshetraMaster] ORDER BY [Sr_No], [Country], [orgwise],[rsswise]" 
                      UpdateCommand="UPDATE [KshetraMaster] SET [Country] = @Country, [orgwise] = @orgwise, [rsswise] = @rsswise WHERE [Sr_No] = @Sr_No">
                      <DeleteParameters>
                          <asp:Parameter Name="Sr_No" Type="Decimal" />
                      </DeleteParameters>
                      <UpdateParameters>
                          <asp:Parameter Name="Country" Type="String" />
                          <asp:Parameter Name="orgwise" Type="String" />
                           <asp:Parameter Name="rsswise" Type="String" />
                          
                          <asp:Parameter Name="Sr_No" Type="Decimal" />
                      </UpdateParameters>
                      <InsertParameters>
                          <asp:Parameter Name="Sr_No" Type="Decimal" />
                          <asp:Parameter Name="Country" Type="String" />
                          <asp:Parameter Name="Zone" Type="String" />
                          <asp:Parameter Name="State" Type="String" />
                          <asp:Parameter Name="Kshetra_Name" Type="String" />
                      </InsertParameters>
                  </asp:SqlDataSource>
       
           </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


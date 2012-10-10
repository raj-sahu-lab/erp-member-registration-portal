<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="LoginPasswordDetails.aspx.cs" Inherits="Admin_LoginPasswordDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script type="text/javascript" language="javascript">
        $(document).ready(function() {
        $('#<%=GridView1.ClientID %>').Scrollable();
        }
)
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="width: 1020px; height: 465px">
<asp:Panel ID="Panel1" runat="server" Height="465px" ScrollBars="Both" Width="1020px">
 <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" PageSize="100"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Login_ID" 
        DataSourceID="SqlDataSource1" Width="100%">
     <RowStyle ForeColor="#000066" />
     <Columns>
         <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
         <asp:BoundField DataField="Login_ID" HeaderText="Login_ID" ReadOnly="True" 
             SortExpression="Login_ID" />
         <asp:BoundField DataField="Password" HeaderText="Password" 
             SortExpression="Password" />
         <asp:BoundField DataField="Login_Type" HeaderText="Login_Type" 
             SortExpression="Login_Type" />
         <asp:BoundField DataField="Security_Hint" HeaderText="Security_Hint" 
             SortExpression="Security_Hint" />
         <asp:BoundField DataField="Answer" HeaderText="Answer" 
             SortExpression="Answer" />
     </Columns>
     <FooterStyle BackColor="White" ForeColor="#000066" />
     <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
     <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
     <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BITRSS %>" 
        DeleteCommand="DELETE FROM [Login] WHERE [Login_ID] = @Login_ID" 
        InsertCommand="INSERT INTO [Login] ([Login_ID], [Password], [Login_Type], [Security_Hint], [Answer]) VALUES (@Login_ID, @Password, @Login_Type, @Security_Hint, @Answer)" 
        SelectCommand="SELECT * FROM [Login] ORDER BY [Login_ID]" 
        UpdateCommand="UPDATE [Login] SET [Password] = @Password, [Login_Type] = @Login_Type, [Security_Hint] = @Security_Hint, [Answer] = @Answer WHERE [Login_ID] = @Login_ID">
        <DeleteParameters>
            <asp:Parameter Name="Login_ID" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Login_Type" Type="String" />
            <asp:Parameter Name="Security_Hint" Type="String" />
            <asp:Parameter Name="Answer" Type="String" />
            <asp:Parameter Name="Login_ID" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Login_ID" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Login_Type" Type="String" />
            <asp:Parameter Name="Security_Hint" Type="String" />
            <asp:Parameter Name="Answer" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    </asp:Panel>
</div>
</asp:Content>


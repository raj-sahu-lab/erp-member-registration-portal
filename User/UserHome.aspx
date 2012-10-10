<%@ Page Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="User_UserHome" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center" style="width: 100%; height: 465px">
    <table align="center" width="600px">
        <tr>
            <td bgcolor="Blue" colspan="2" align="center">
             <asp:Label ID="Label2" runat="server" Text="CURRENT MONTH COMMISSION STATEMENT" Font-Bold="True" 
                    Font-Size="Large" ForeColor="White"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Self Bonus :"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lb_self_bonus" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Level Bonus"></asp:Label>
            </td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" runat="server" Text="1st Level :"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lb_first_level" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label7" runat="server" Text="2nd Level :"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lb_second_level" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server" Text="3rd Level :"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lb_third_level" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="4-20th Level :"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lb_fourth_level" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Matching Bonus"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
              <asp:Label ID="Label10" runat="server" Text="Matching Point * 10%"></asp:Label>
             
             </td>
            <td align="right">
                <asp:Label ID="lb_matching_bonus" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
              <asp:Label ID="Label11" runat="server" Text="Total :"></asp:Label>
             
             </td>
            <td align="right">
                <asp:Label ID="lb_total" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="Deduction"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
       <tr>
            <td align="right">
              <asp:Label ID="Label13" runat="server" Text="TDS(%) :"></asp:Label>
              <asp:Label ID="lb_tds" runat="server" Text=""></asp:Label>
             </td>
            <td align="right">
                <asp:Label ID="lb_ded_tds" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
              <asp:Label ID="Label14" runat="server" Text="Processing Charge(%) :"></asp:Label>
             <asp:Label ID="lb_pc" runat="server" Text=""></asp:Label>
             </td>
            <td align="right">
                <asp:Label ID="lb_ded_pc" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
              <asp:Label ID="Label15" runat="server" Text="Other(%) :"></asp:Label>
             <asp:Label ID="lb_other" runat="server" Text=""></asp:Label>
             </td>
            <td align="right">
                <asp:Label ID="lb_ded_other" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
             <asp:Label ID="lb_other0" runat="server" Text="Grand Total (Payable):"></asp:Label>
             </td>
            <td align="right">
                <asp:Label ID="lb_grand_total" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" bgcolor="Blue" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
              <asp:Label ID="lb_message" runat="server" ForeColor="Red"></asp:Label>
             
             </td>
        </tr>
    </table>

</div>
</asp:Content>


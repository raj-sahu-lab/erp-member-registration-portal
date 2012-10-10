<%@ Page Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="User_UploadData.aspx.cs" Inherits="User_UploadData" Title="USER UPLOAD DATA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="width: 100%; height: 100%">
    <table align="center" width="600px">
        <tr>
            <td bgcolor="Blue" align="center">
             <asp:Label ID="Label2" runat="server" Text="USER DOCUMENT UPLOAD" Font-Bold="True" 
                    Font-Size="Large" ForeColor="White"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
            <table align="center">
<tr>
<td>
    <asp:Label ID="Label18" runat="server" Text="User ID"></asp:Label></td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label17" runat="server" Text="Upload Profile Photo"></asp:Label></td>
<td>
   <asp:FileUpload ID="fileImage" runat="server" />
    <asp:Button ID="btnfileupload" runat="server" CausesValidation="false"  CssClass="form_button" OnClick="btnfileupload_Click"
Text="Upload Image" />
    </td>
<td>
    &nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="center">
    <asp:Image ID="Image1" runat="server" Width="200px" 
        ImageUrl="~/Img_Merchant/17.jpg" Height="150px" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label1" runat="server" Text="Upload Photo for Address Proof"></asp:Label></td>
<td>
   <asp:FileUpload ID="fileImage1" runat="server" />
    <asp:Button ID="btnfileupload1" runat="server" CausesValidation="false"  
        CssClass="form_button" OnClick="btnfileupload1_Click"
Text="Upload Image" />
    </td>
<td>
    &nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="3">
    <asp:Image ID="Image2" runat="server" Width="500px" 
        ImageUrl="~/Img_Merchant/17.jpg" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Upload Photo for ID Proof"></asp:Label></td>
<td>
   <asp:FileUpload ID="fileImage2" runat="server" />
    <asp:Button ID="btnfileupload2" runat="server" CausesValidation="false"  CssClass="form_button" OnClick="btnfileupload2_Click"
Text="Upload Image" />
    </td>
<td>
    &nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="3">
    <asp:Image ID="Image3" runat="server" Width="500px" 
        ImageUrl="~/Img_Merchant/17.jpg" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label4" runat="server" Text="Upload Cancelled Cheque Book OR Passbook Copy"></asp:Label></td>
<td>
   <asp:FileUpload ID="fileImage3" runat="server" />
    <asp:Button ID="Button1" runat="server" CausesValidation="false"  
        CssClass="form_button" Text="Upload Image" onclick="Button1_Click" />
    </td>
<td>
    &nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="3">
    <asp:Image ID="Image4" runat="server" Width="500px" 
        ImageUrl="~/Img_Merchant/17.jpg" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td colspan="3" align="center" style="color: #FF0000; font-weight: bold">
    *&nbsp; Upload only .jpg format images
            
            </td>          
        </tr>
        </table>

</div>
</asp:Content>


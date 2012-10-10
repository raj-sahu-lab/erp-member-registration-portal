<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forget_ID.aspx.cs" Inherits="Forget_ID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"> 
<title>
Forget ID
</title>
<link href="https://chatserver.comm100.com/css/comm100_livechatbutton.css" rel="stylesheet" type="text/css" />
<link rel="Slide/css/stylesheet" type="text/css" href="http://cdn.webrupee.com/font" />
<link href="Slide/Flash/js-image-slider.css" rel="stylesheet" type="text/css" />
<script src="Slide/Flash/js-image-slider.js" type="text/javascript"></script>
<link href="css/Style.css" rel="stylesheet" type="text/css" />
<link href="css/msgpop.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <table bgcolor="White" style="width: 100%">
                <tr>
                <td>
                <table width="100%">
                <tr>
                <td>
                <table style= "background-color: #FFFFFF" width="100%" align="center">
                        <tr>
                            <td colspan="2" align="center" style="font-weight: 700">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                            Font-Names="Comic Sans MS" Font-Size="Larger" Font-Underline="False" 
                            ForeColor="#003300" Text="Forget ID"></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td 
                                align="left" class="style16">
                                <asp:Label ID="Label15" runat="server" Text="Enter your Mobile No :" 
                                    ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox 
                            ID="TextBox3" runat="server" Height="21px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td 
                                align="left" class="style16">
                                &nbsp;&nbsp;</td>
                            <td align="center">
                        <asp:Button ID="Button8" runat="server" BackColor="#FF6600" BorderStyle="Outset" 
            ForeColor="White" Height="25px" Text="Submit" Width="65px" BorderColor="White" Font-Bold="True" 
                                    Font-Size="Small" onclick="Button8_Click" />
                            </td>
                        </tr>                      
                       
                        <tr>
                        <td>
                        
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">                                                                                        
                                   
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                                        ForeColor="#CC0066"></asp:Label>
                                   
                                    &nbsp;                                                                                        
                                   
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Italic="True" 
                                        ForeColor="#CC0066"></asp:Label>
                                   
                                    </td>
                        </tr>
                       
                    </table>
                </td>
                </tr>
                </table>
                </td>                
                </tr>
            </table>
   </div>
    </form>
</body>
</html>
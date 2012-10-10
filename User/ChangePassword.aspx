<%@ Page Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="User_ChangePassword" Title="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../css/form1.css" rel="stylesheet" type="text/css" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="width: 900px; height: 100%">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
 <ContentTemplate>      
    <div style=" text-align:justify; width:900px; height:465px; margin-left:10px;"> 
    <div class="form">        
        <div id="Div1">
                <div class="columns">
                    <div id="UpdatePanel2">
                    <div class="reghead">
                        <span id="Label5" style="font-weight:bold;">Security Detail</span>
                    </div>
                     <div class="rows">                               
                                <asp:TextBox ID="txtuser_id" runat="server" ReadOnly="True" Visible="false" Width="250px" Height="18px"></asp:TextBox>
                            </div> 
                    <div class="rows btop">
                        <span id="Label51" class="label">Password  :  *</span>
                         <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="250px" Height="18px"></asp:TextBox>                     
                    </div>
                    <div class="rows">
                        <span id="Label52" class="label">Confirm Password  :  *</span>
                        <asp:TextBox ID="txtconfirm_password" runat="server" TextMode="Password" Width="250px" Height="18px"></asp:TextBox>                       
                    </div>
                    <div class="rows">
                        <span id="Label4" class="label">Select Hint Question  :  *</span>
                         <asp:DropDownList ID="ddlhint_que" runat="server" Height="30px" Width="275px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>What is the name of your first school?</asp:ListItem>
                            <asp:ListItem>What is your birth Place?</asp:ListItem>
                            <asp:ListItem>What is your favourite food?</asp:ListItem>
                             <asp:ListItem>What is your favourite game?</asp:ListItem>
                            <asp:ListItem>What is your favourite movie?</asp:ListItem>
                            <asp:ListItem>What is your favourite pass-time?</asp:ListItem>
                             <asp:ListItem>What is your Mother's Maiden Name?</asp:ListItem>                                             
                        </asp:DropDownList> 
                        <span id="rfv_hintQues" style="color:Red;visibility:hidden;">*</span>
                    </div>
                    <div class="rows">
                        <span id="Label53" class="label">Answer  :  *</span>
                        <asp:TextBox ID="txtans" runat="server" Height="18px" Width="250px"></asp:TextBox>                        
                    </div>
                    <div class="rows">
                    </div>
                    <div class="rows">                     
                            <asp:Label ID="Label36" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                       
                    </div>
                    <div class="rows" align="center">                    
                            <span>
                                 <asp:Button ID="Button1" runat="server" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Change" Width="65px" 
                            onclick="Button1_Click" />
                              <asp:Button ID="Button2" runat="server" Font-Bold="True" 
                            ForeColor="White" Height="30px" Text="Reset" Width="65px" 
                    onclick="Button2_Click" />
                            </span>                      
                    </div>
                    <div class="bbottom">
                        &nbsp;
                    </div> 
                    <h3>
                    </h3>
</div>
    </div>  
    </div> 
    </div>  
</ContentTemplate>
</asp:UpdatePanel>   

</div>
</asp:Content>


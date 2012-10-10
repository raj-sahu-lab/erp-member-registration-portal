<%@ Page Language="C#" MasterPageFile="~/User/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserRecord.aspx.cs" Inherits="User_UserRecord" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/form1.css" rel="stylesheet" type="text/css" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="width: 900px; height: 100%">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
 <ContentTemplate>      
    <div style=" text-align:justify; width:900px;  margin-left:10px;">  
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="form">
        <div id="UpdateProgress" style="display:none;">
<div style="background:white ;padding:20px; border:2px solid #666;">
<img id="Img1" src="" alt="Processing" style="border-width:0px;" /></div>
</div>
        <div id="Div1">
                <div class="columns">
                    <div class="reghead">
                        <span id="Label1" style="font-weight:bold;">Sponsor Detail</span>
                    </div>
                    <div id="UpdatePanel2">
                            <div class="rows btop">
                                <span id="lbl_jndt" class="label">Date :</span>
                                <asp:Label ID="lb_date" runat="server" Text="30-04-1987"></asp:Label>
                            </div>
                            <div class="rows">
                                <span id="lbl_sponsno" class="label">Sponsor No :  *</span>
                                <asp:TextBox ID="txtsponsor_no" runat="server" Width="250px" Height="18px" 
                                    ReadOnly="True"></asp:TextBox>                              
                                <span id="rfv_sponsno" style="color:Red;visibility:hidden;">*</span>
                                <span id="rv_sponsno" style="color:Red;visibility:hidden;">*</span>                              
                            </div>
                             <div class="rows">
                                <span id="Span47" class="label">Sponsor Name :  *</span>
                                <asp:TextBox ID="txtsponsor_name" runat="server" Width="250px" Height="18px" 
                                     ReadOnly="True"></asp:TextBox>                              
                                <span id="Span48" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span49" style="color:Red;visibility:hidden;">*</span>                              
                            </div>
                             <div class="rows">
                                <span id="Span41" class="label">Speel Sponsor No :</span>
                                <asp:TextBox ID="txtspil_sponsorno" runat="server" ReadOnly="True"  
                                     Width="250px" Height="18px" AutoPostBack="True"></asp:TextBox>                                                           
                              </div>
                             <div class="rows">
                                <span id="Span42" class="label">Speel Sponsor Name :  *</span>
                                <asp:TextBox ID="txtspil_sponsorname" runat="server" Width="250px" Height="18px" 
                                     ReadOnly="True"></asp:TextBox> 
                             </div>              
                            <div class="rows">                               
                                <asp:TextBox ID="txtuser_id" runat="server" ReadOnly="True" Visible="false" Width="250px" Height="18px"></asp:TextBox>
                            </div>                          
                             <div class="rows">
                                <span id="Span1" class="label">Binary Side :</span>
                                  <asp:DropDownList ID="ddl_binary_side" runat="server" Width="275px" 
                                     Height="30px" Enabled="False">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Left</asp:ListItem>
                            <asp:ListItem>Right</asp:ListItem>
                        </asp:DropDownList>
                            </div>             
                    <div class="bbottom">
                        &nbsp;
                    </div>
                    <h3>
                    </h3>
                    <div class="reghead">
                        <span id="Span18" style="font-weight:bold;">Personal Detail</span>
                    </div>
                    <div class="photodiv">
                    </div>
                    <div class="rows btop">
                        <span id="lbl_aplnm" class="label">Applicant Name :  *</span>
                       <asp:DropDownList ID="ddl_head1" runat="server" Width="50px" Height="30px">
                            <asp:ListItem>Mr.</asp:ListItem>
                            <asp:ListItem>Miss</asp:ListItem>
                            <asp:ListItem>Mrs.</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtuser_name" runat="server" Width="195px" ReadOnly="True"></asp:TextBox>
                        <span id="rfv_aplnm" style="color:Red;visibility:hidden;">*</span>
                        <span id="rv_aplnm" style="color:Red;visibility:hidden;">*</span>
                    </div>  
                     <div class="rows">
                        <span id="Span2" class="label">F/H Name :  *</span>
                       <asp:TextBox ID="txtf_h_name" runat="server" Width="250px" Height="18px"></asp:TextBox>
                        <span id="Span3" style="color:Red;visibility:hidden;">*</span>
                        <span id="Span4" style="color:Red;visibility:hidden;">*</span>
                    </div>  
                    <div class="rows">
                        <span id="lbl_apldob" class="label">Applicant DOB :  *  (DD/MM/YYYY) </span>
                        <asp:TextBox ID="txtuser_dob" runat="server" Width="250px" Height="18px"></asp:TextBox>
                        <span id="rfv_apldob" style="color:Red;visibility:hidden;">*</span>
                        <span id="rv_apldob" style="color:Red;visibility:hidden;">*</span>
                        <input type="hidden" name="MaskedEditExtender1_ClientState" id="MaskedEditExtender1_ClientState" />
                    </div>  
                     <div class="rows">
                        <span id="Span5" class="label">Sex : * </span>
                         <asp:DropDownList ID="ddl_sex" runat="server" Height="30px" Width="275px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>   
                        <span id="Span6" style="color:Red;visibility:hidden;">*</span>                                  
                    </div> 
                    <div class="rows">
                        <span id="lbl_nomin" class="label">Nominee Name :  *</span>
                         <asp:DropDownList ID="ddl_head2" runat="server" Width="50px" Height="30px">
                                        <asp:ListItem>Mr.</asp:ListItem>
                                        <asp:ListItem>Miss</asp:ListItem>
                                        <asp:ListItem>Mrs.</asp:ListItem>
                                    </asp:DropDownList>
                        <asp:TextBox ID="txtnominee_name" runat="server" Width="195px" Height="18px"></asp:TextBox>          
                        <span id="rfv_nomin" style="color:Red;visibility:hidden;">*</span>
                        <span id="rv_nomin" style="color:Red;visibility:hidden;">*</span>
                    </div>
                      <div class="rows">   
                       <span id="Span19" class="label">Nominee DOB :  *</span>                    
                        <asp:TextBox ID="txtnominee_dob" runat="server" Width="250px" Height="18px"></asp:TextBox>
                        <span id="rfv_nomdob" style="color:Red;visibility:hidden;">*</span>
                        <span id="rv_nomdob" style="color:Red;visibility:hidden;">*</span>                      
                    </div>	
                     <div class="rows">
                        <span id="lbl_fathHus" class="label">Relation :  *</span>
                       <asp:DropDownList ID="ddlrelation" runat="server" Height="30px" Width="275px" 
                             AutoPostBack="false">
                            <asp:ListItem>--Relationship--</asp:ListItem>
                            <asp:ListItem>Son</asp:ListItem>
                            <asp:ListItem>Daughter</asp:ListItem>
                            <asp:ListItem>Father</asp:ListItem>
                            <asp:ListItem>Mother</asp:ListItem>
                            <asp:ListItem>Wife</asp:ListItem>
                            <asp:ListItem>Husband</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <span id="rfv_fathhus" style="color:Red;visibility:hidden;">*</span>
                        <span id="rv_fathhus" style="color:Red;visibility:hidden;">*</span>
                    </div>                                  
                    <div class="bbottom">
                        &nbsp;
                    </div>
                    <h3>
                    </h3>
                    <div class="reghead">
                        <span id="Label2" style="font-weight:bold;">Communication Detail</span>
                    </div>
                    <div class="rows btop">
                        <span id="lbl_hno" class="label">Address :  *</span>
                        <asp:TextBox ID="txtaddress" runat="server" Height="100px" Width="250px" TextMode="MultiLine"></asp:TextBox>
                        <span id="rfv_hno" style="color:Red;visibility:hidden;">*</span>
                    </div> 
                    <div class="rows">
                        <span id="lbl_post" class="label">City :</span>
                       <asp:TextBox ID="txtcity" runat="server" Width="250px" Height="18px"></asp:TextBox>
                    </div>
                    <div class="rows">
                        <span id="lbl_city" class="label">State :  *</span>
                       <asp:DropDownList ID="txtstate" runat="server" Height="30px" Width="275px">
                            <asp:ListItem>--State--</asp:ListItem>
                            <asp:ListItem>Andra Pradesh</asp:ListItem>
                            <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                            <asp:ListItem>Assam</asp:ListItem>
                            <asp:ListItem>Bihar</asp:ListItem>
                            <asp:ListItem>Chhattisgarh</asp:ListItem>
                            <asp:ListItem>Goa</asp:ListItem>
                            <asp:ListItem>Gujarat</asp:ListItem>
                            <asp:ListItem>Haryana</asp:ListItem>
                            <asp:ListItem>Himachal Pradesh</asp:ListItem>
                            <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                            <asp:ListItem>Jharkhand</asp:ListItem>
                            <asp:ListItem>Karnataka</asp:ListItem>
                            <asp:ListItem>Kerala</asp:ListItem>
                            <asp:ListItem>Madya Pradesh</asp:ListItem>
                            <asp:ListItem>Maharashtra</asp:ListItem>
                            <asp:ListItem>Manipur</asp:ListItem>
                            <asp:ListItem>Meghalaya</asp:ListItem>
                            <asp:ListItem>Mizoram</asp:ListItem>
                            <asp:ListItem>Nagaland</asp:ListItem>
                            <asp:ListItem>Orissa</asp:ListItem>
                            <asp:ListItem>Punjab</asp:ListItem>
                            <asp:ListItem>Rajasthan</asp:ListItem>
                            <asp:ListItem>Sikkim</asp:ListItem>
                            <asp:ListItem>Tamil Nadu</asp:ListItem>
                            <asp:ListItem>Tripura</asp:ListItem>
                            <asp:ListItem>Uttaranchal</asp:ListItem>
                            <asp:ListItem>Uttar Pradesh</asp:ListItem>
                            <asp:ListItem>West Bengal</asp:ListItem>
                            <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                            <asp:ListItem>Chandigarh</asp:ListItem>
                            <asp:ListItem>Dadar and Nagar Haveli</asp:ListItem>
                            <asp:ListItem>Daman and Diu</asp:ListItem>
                            <asp:ListItem>Delhi</asp:ListItem>
                            <asp:ListItem>Lakshadeep</asp:ListItem>
                            <asp:ListItem>Pondicherry</asp:ListItem>                            
                         </asp:DropDownList>
                        <span id="rfv_city" style="color:Red;visibility:hidden;">*</span>
                    </div>
                    <div class="rows">
                        <span id="lbl_pincode" class="label">Pincode :</span>
                        <asp:TextBox ID="txtpincode" runat="server" Width="250px" Height="18px" MaxLength="6"></asp:TextBox>
                        <span id="rv_pincode" style="color:Red;visibility:hidden;">*</span>
                    </div>                   
                      <div class="rows">
                        <span id="Span7" class="label">Nationality : * </span>
                         <asp:DropDownList ID="ddlnationality" runat="server" Height="30px" Width="275px">
                            <asp:ListItem>--Nationality--</asp:ListItem>
                            <asp:ListItem>Indian</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>    
                        <span id="Span8" style="color:Red;visibility:hidden;">*</span>                                  
                    </div>
                     <div class="rows">
                        <span id="lbl_phR" class="label">Mobile No :</span>
                        <asp:TextBox ID="txtmobile_no" runat="server" Width="250px" Height="18px" 
                            MaxLength="10" ReadOnly="True"></asp:TextBox>
                        <span id="rv_phR" style="color:Red;visibility:hidden;">*</span>
                    </div>
                     <div class="rows">
                        <span id="lbl_tehsil" class="label">Email :</span>
                         <asp:TextBox ID="txtemail" runat="server" Width="250px" Height="18px"></asp:TextBox>
                    </div>
                        <div class="rows">
                        <span id="Label21" class="label">ID Proof Type:  *</span>
                          <asp:DropDownList ID="ddlid_proof" runat="server" Height="30px" Width="275px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Adhar Card</asp:ListItem>
                            <asp:ListItem>Bank account/Passbook With Photogarh</asp:ListItem>
                            <asp:ListItem>Central/State Government certified ID proof</asp:ListItem>
                             <asp:ListItem>Certification from any of the Authorities</asp:ListItem>
                            <asp:ListItem>Domicile certificate with communication address and photograph</asp:ListItem>
                            <asp:ListItem>Driving License (Valid)</asp:ListItem>
                             <asp:ListItem>Pan Card</asp:ListItem>
                            <asp:ListItem>Passport (Valid)</asp:ListItem>
                            <asp:ListItem>Ration Card With Photogarh</asp:ListItem>
                             <asp:ListItem>Voter's Identity Card</asp:ListItem>
                            <asp:ListItem>Written confirmation from the banks certifying identity proof</asp:ListItem>                         
                        </asp:DropDownList>                      
                        <span id="rfv_IdProof" style="color:Red;visibility:hidden;">*</span>
                    </div>
                    <div class="rows">
                        <span id="Label22" class="label">Address Proof Type:  *</span>
                         <asp:DropDownList ID="ddladdress_proof" runat="server" Height="30px" Width="275px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Adhar Card</asp:ListItem>
                            <asp:ListItem>Bank account/Passbook With Photogarh</asp:ListItem>
                            <asp:ListItem>Central/State Government certified ID proof</asp:ListItem>
                             <asp:ListItem>Certification from any of the Authorities</asp:ListItem>
                            <asp:ListItem>Domicile certificate with communication address and photograph</asp:ListItem>
                            <asp:ListItem>Driving License (Valid)</asp:ListItem>
                             <asp:ListItem>Pan Card</asp:ListItem>
                            <asp:ListItem>Passport (Valid)</asp:ListItem>
                            <asp:ListItem>Ration Card With Photogarh</asp:ListItem>
                             <asp:ListItem>Voter's Identity Card</asp:ListItem>
                            <asp:ListItem>Written confirmation from the banks certifying identity proof</asp:ListItem>                         
                        </asp:DropDownList>   
                        <span id="rfv_AddProof" style="color:Red;visibility:hidden;">*</span>
                    </div>
                       <div class="rows">
                    </div>
                    <div class="rows" style="height: 220px; display:none;">
                        <div class="dividad">                            
                        </div>
                        <div class="dividad">
                        </div>
                    </div>
                    <div class="bbottom">
                        &nbsp;
                    </div>
                    <h3>
                        </h3>
                    <div class="reghead">
                        <span id="Label3" style="font-weight:bold;">Bank Account Detail</span>
                    </div>
                     <div class="rows btop">
                        </div>
                             <div class="photodiv">
                    </div>
                    <div class="rows">
                                <span id="Span9" class="label">A/C Holder Name : </span>
                                <asp:TextBox ID="txtac_holder_name" runat="server" Height="18px" Width="250px" 
                                    ReadOnly="True"></asp:TextBox>
                                <span id="Span10" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span11" style="color:Red;visibility:hidden;">*</span>
                    </div>
                     <div class="rows">
                                <span id="Span12" class="label">Applicant A/c No. : </span>
                                <asp:TextBox ID="txtacc_no" runat="server" Height="18px" Width="250px"></asp:TextBox>
                                <span id="Span13" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span14" style="color:Red;visibility:hidden;">*</span>
                    </div>
                     <div class="rows">
                                <span id="Span15" class="label">Bank Name : </span>
                                <asp:TextBox ID="txtbank_name" runat="server" Height="18px" Width="250px"></asp:TextBox>
                                <span id="Span16" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span17" style="color:Red;visibility:hidden;">*</span>
                    </div>  
                     <div class="rows">
                                <span id="Span20" class="label">Branch Name : </span>
                                <asp:TextBox ID="txtbranch_name" runat="server" Height="18px" Width="250px"></asp:TextBox>
                                <span id="Span27" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span28" style="color:Red;visibility:hidden;">*</span>
                    </div>                  
                    <div class="rows">
                                <span id="Span21" class="label">Bank IFSC Code : </span>
                                <asp:TextBox ID="txtifsc_code" runat="server" Height="18px" Width="250px" MaxLength="11"></asp:TextBox>
                                <span id="Span22" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span23" style="color:Red;visibility:hidden;">*</span>
                    </div>
                    <div class="rows">
                                <span id="Span24" class="label">PAN No : </span>
                                <asp:TextBox ID="txtpan_no" runat="server" Height="18px" Width="250px"></asp:TextBox>
                                <span id="Span25" style="color:Red;visibility:hidden;">*</span>
                                <span id="Span26" style="color:Red;visibility:hidden;">*</span>
                    </div>  
        
	  <div class="bbottom">
                        &nbsp;
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
                            ForeColor="White" Height="30px" Text="Update" Width="65px" 
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


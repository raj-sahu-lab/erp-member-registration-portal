<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Admin_Registration" Title="Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <script type="text/javascript"  language="javascript">
     function validate() {
         if (document.getElementById('<%=txtname.ClientID %>').value == "") {
                 alert("Enter Name!");
                 document.getElementById('<%=txtname.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtdob.ClientID %>').value == "") {
                 alert("Select Date of birth");
                 document.getElementById('<%=txtdob.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtpermanent_addr.ClientID %>').value == "") {
                 alert("Enter Permanent Address!");
                 document.getElementById('<%=txtpermanent_addr.ClientID %>').focus();
                return false;
            }
       
         if (document.getElementById('<%=txtemail_id1.ClientID %>').value == "") {
             alert("Enter Primary Email ID!");
             document.getElementById('<%=txtemail_id1.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtemail_id1.ClientID %>') != null) {
                 var ema = document.getElementById('<%=txtemail_id1.ClientID %>');

                 var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

                 if (!filter.test(ema.value)) {
                     alert("Enter Valid Email ID");
                     document.getElementById('<%=txtemail_id1.ClientID %>').focus();
                    return false;

                }
            }
       

           
        }

 </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="width: 100%">
        <ajax:TabContainer ID="TabContainer1" runat="server">
            <ajax:TabPanel ID="tbpnluser" runat="server" >
                <HeaderTemplate>
                    Personal Details
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="UserReg" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Registration ID"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtreg_id" runat="server" Width="200px" ReadOnly="true"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Date"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtname" runat="server" Width="200px"></asp:TextBox></td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Nick Name"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtnickname" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Sex"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlsex" runat="server" Width="225px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="DOB"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtdob" runat="server" Width="200px"
                                        ToolTip="Date Format-dd-mm-yyyy" AutoPostBack="True" OnTextChanged="txtdob_TextChanged"></asp:TextBox>
                                    <ajax:CalendarExtender ID="txtdob_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtdob">
                                    </ajax:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Age"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtage" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Nationality"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlnationality" runat="server" Width="225px">
                                        <asp:ListItem>Bharat</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text="Marriage Date"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtmarriage_date" runat="server" Width="200px"
                                        ToolTip="Date Format-dd-mm-yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="txtmarriage_date_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtmarriage_date">
                                    </ajax:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="Occasion"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_occasion" runat="server" Width="225px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label53" runat="server" Text="Total No of Family Member"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtfamily_member" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label54" runat="server" Text="Present Organization"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_organization1" runat="server" Width="225px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">Aadhar Card Number</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtaadhar" runat="server" Width="550px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text="Name of Family Member"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtname_familymember" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Text="Member ID"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtmember_rss" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Button ID="btnadd_p" runat="server" Text="Add" OnClick="btnadd_p_Click" /></td>
                                <td align="left">
                                    <asp:Button ID="btnreset_p" runat="server" Text="Reset" OnClick="btnreset_p_Click" /></td>

                                <td></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <%--  <td>Organization</td>--%>
                                <td>Family Member Name</td>
                                <td>Family Member ID</td>
                            </tr>
                            <tr>
                                <%--  <td>
                                    <asp:ListBox ID="lb_p_org" runat="server" Width="330px" Height="100px"></asp:ListBox></td>--%>
                                <td>
                                    <asp:ListBox ID="lb_p_membername" runat="server" Width="230px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="lb_p_memberid" runat="server" Width="200px" Height="100px"></asp:ListBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="tbpnlusrdetails" runat="server">
                <HeaderTemplate>
                    Photo
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:FileUpload ID="fileImage" runat="server" />
                                    <asp:Button ID="btnfileupload" runat="server" CausesValidation="false" CssClass="form_button" OnClick="btnfileupload_Click"
                                        Text="Upload Image" />
                                </td>
                                <td align="right">
                                    <asp:Image ID="Image3" runat="server" Width="250px" Height="250px" ImageUrl="" /></td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center" style="color: #FF0000; font-weight: bold">*&nbsp; Upload only .jpg format images</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel1" runat="server">
                <HeaderTemplate>
                    Communication
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel3" runat="server">
                        <table>
                            <tr>
                                <td style="vertical-align: top">
                                    <asp:Label ID="Label16" runat="server" Text="Permanent Address"></asp:Label></td>
                                <td colspan="3">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtpermanent_addr" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_country" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_kshetraorg" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetraorg_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_kshetrarss" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetrarss_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_prant_rss" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddl_prant_rss_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_prant_org" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_org_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_prant_govt" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_govt_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_lokshabhaname" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_lokshabhaname_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_distr" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_distr_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_vidhansabha" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_vidhansabha_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_tehsil" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_tehsil_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_nagar" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_nagar_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_upnagar" runat="server" Width="195px">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtpincode" runat="server" placeholder="PinCode:"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:TextBox ID="txtfax" runat="server" placeholder="FAX Number:"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>Landline Number</td>
                                            <td>
                                                <asp:TextBox ID="txtlandline11" runat="server" Width="200px" placeholder="LandLine No. 1"></asp:TextBox></td>

                                            <td align="right">
                                                <asp:TextBox ID="txtlandline12" runat="server" Width="200px" placeholder="LandLine No. 2"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td style="vertical-align: top">
                                    <asp:Label ID="Label17" runat="server" Text="Current Address"></asp:Label></td>
                                <td colspan="3">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtcurr_addr" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_country1" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_kshetraorg1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetraorg_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_kshetrarss1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetrarss_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_prant_rss1" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddl_prant_rss_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_prant_org1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_org_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_prant_govt1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_govt_SelectedIndexChanged1">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_lokshabhaname1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_lokshabhaname_SelectedIndexChanged1">
                                                </asp:DropDownList></td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_distr1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_distr_SelectedIndexChanged1">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_vidhansabha1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_vidhansabha_SelectedIndexChanged1">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_tehsil1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_tehsil_SelectedIndexChanged1">
                                                </asp:DropDownList></td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_nagar1" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_nagar_SelectedIndexChanged1">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_upnagar1" runat="server" Width="195px">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtpincode1" runat="server" placeholder="PinCode:"></asp:TextBox></td>
                                            <td align="right">
                                                <asp:TextBox ID="txtfax1" runat="server" placeholder="FAX Number:"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>LandLine Number</td>
                                            <td>
                                                <asp:TextBox ID="txtlandline21" runat="server" Width="200px" placeholder="LandLine No. 1"></asp:TextBox></td>

                                            <td align="right">
                                                <asp:TextBox ID="txtlandline22" runat="server" Width="200px" placeholder="LandLine No. 2"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="Office Address"></asp:Label></td>
                                <td colspan="3">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtoffice_addr" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_country2" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged2">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_kshetraorg2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetraorg_SelectedIndexChanged2">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_kshetrarss2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetrarss_SelectedIndexChanged2">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_prant_rss2" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddl_prant_rss_SelectedIndexChanged2">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_prant_org2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_org_SelectedIndexChanged2">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_prant_govt2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_govt_SelectedIndexChanged2">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_lokshabhaname2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_lokshabhaname_SelectedIndexChanged2">
                                                </asp:DropDownList></td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_distr2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_distr_SelectedIndexChanged2">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_vidhansabha2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_vidhansabha_SelectedIndexChanged2">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddl_tehsil2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_tehsil_SelectedIndexChanged2">
                                                </asp:DropDownList></td>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_nagar2" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_nagar_SelectedIndexChanged2">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:DropDownList ID="ddl_upnagar2" runat="server" Width="195px">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtpincode2" runat="server" placeholder="PinCode:"></asp:TextBox></td>
                                            <td align="right">
                                                <asp:TextBox ID="txtfax2" runat="server" placeholder="FAX Number:"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>LandLine Number</td>
                                            <td>
                                                <asp:TextBox ID="txtlandline31" runat="server" Width="200px" placeholder="LandLine No. 1"></asp:TextBox></td>

                                            <td align="right">
                                                <asp:TextBox ID="txtlandline32" runat="server" Width="200px" placeholder="LandLine No. 2"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Email ID(primary)"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtemail_id1" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label62" runat="server" Text="Email ID(Alternate)"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtemail_id2" runat="server" TextMode="SingleLine"></asp:TextBox></td>



                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="Email ID(Alternate)"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtemail_id3" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label63" runat="server" Text="Email ID(Alternate)"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtemail_id4" runat="server" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="Primary Contact No"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtcontact_no1" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="Alternate Contact No1"></asp:Label></td>
                                <td align="right">
                                    <asp:TextBox ID="txtcontact_no2" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text="Alternate Contact No2"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtcontact_no3" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text="Whatsapp Contact No3"></asp:Label></td>
                                <td align="right">
                                    <asp:TextBox ID="txtcontact_no4" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <%--  <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="Fax No"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtfax_no1" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label40" runat="server" Text="Fax No"></asp:Label></td>
                                <td align="right">
                                    <asp:TextBox ID="txtfax_no2" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="Label41" runat="server" Text="Blog Link"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtblog_link" runat="server" Width="610px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label42" runat="server" Text="Facebook Link"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtfb_link" runat="server" Width="610px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label56" runat="server" Text="Website Link"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtweb_link" runat="server" Width="610px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label57" runat="server" Text="Twitter Link"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txttwitter_link" runat="server" Width="610px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label58" runat="server" Text="LinkedIn Link"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtlinkedin_link" runat="server" Width="610px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel2" runat="server">
                <HeaderTemplate>
                    Qualification
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel4" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Qualification"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_qualification" runat="server" Width="225px">
                                        <asp:ListItem>-Select Qualification-</asp:ListItem>
                                        <asp:ListItem>5th Pass</asp:ListItem>
                                        <asp:ListItem>8th Pass</asp:ListItem>
                                        <asp:ListItem>10th Pass</asp:ListItem>
                                        <asp:ListItem>12th Pass</asp:ListItem>
                                        <asp:ListItem>Graduate</asp:ListItem>
                                        <asp:ListItem>Post Graduate</asp:ListItem>
                                        <asp:ListItem>Illetrate</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:Label ID="Label30" runat="server" Text="Specialization"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlspecialization" runat="server" Width="225px" OnSelectedIndexChanged="ddlspecialization_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Text="Sub Specialization"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlspecialization1" runat="server" Width="225px" OnSelectedIndexChanged="ddlspecialization1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Text="Sub-Sub Specialization"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlspelization2" runat="server" Width="225px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Any Other Details"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtcourse1" runat="server" Width="580px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:Label ID="lblress" runat="server" ForeColor="#cc0000"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CssClass="form_button" OnClick="Button1_Click"
                                        Text="Upload Ressume" />
                                </td>

                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel6" runat="server">
                <HeaderTemplate>
                    Employment
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel8" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Occupation"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddloccupation" runat="server" Width="225px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="Specialization"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlspecialization4" runat="server" Width="225px" OnSelectedIndexChanged="ddlspecialization4_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label35" runat="server" Text="Sub Specialization"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlspecialization5" runat="server" Width="225px" OnSelectedIndexChanged="ddlspecialization5_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label36" runat="server" Text="Sub-Sub Specialization"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlspecialization6" runat="server" Width="225px"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table>
                                        <tr>
                                            <td>SN</td>
                                            <td>Organization Name</td>
                                            <td>Service From</td>
                                            <td>Service To</td>
                                            <td>Achievement</td>
                                            <td>Remark</td>
                                        </tr>
                                        <tr>
                                            <td>1.</td>
                                            <td>
                                                <asp:TextBox ID="txtorg1" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg1_fromdate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg1_fromdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg1_fromdate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg1_todate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg1_todate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg1_todate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg1_achievement" runat="server" Width="170px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg1_remark" runat="server" Width="160px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2.</td>
                                            <td>
                                                <asp:TextBox ID="txtorg2" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg2_fromdate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg2_fromdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg2_fromdate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg2_todate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg2_todate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg2_todate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg2_achievement" runat="server" Width="170px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg2_remark" runat="server" Width="160px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.</td>
                                            <td>
                                                <asp:TextBox ID="txtorg3" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg3_fromdate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg3_fromdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg3_fromdate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg3_todate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg3_todate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg3_todate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg3_achievement" runat="server" Width="170px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg3_remark" runat="server" Width="160px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4.</td>
                                            <td>
                                                <asp:TextBox ID="txtorg4" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg4_fromdate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg4_fromdate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg4_fromdate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>(MM/dd/yyyy)<br />
                                                <asp:TextBox ID="txtorg4_todate" runat="server" Width="67px"></asp:TextBox>
                                                <ajax:CalendarExtender ID="txtorg4_todate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg4_todate">
                                                </ajax:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg4_achievement" runat="server" Width="170px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtorg4_remark" runat="server" Width="160px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel5" runat="server">
                <HeaderTemplate>
                    Extra Activity
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel7" runat="server">
                        <table>
                            <tr>
                                <td colspan="4">
                                    <table>
                                        <tr>
                                            <td>SN</td>
                                            <td colspan="2">Hobbies</td>
                                            <td>Extra Activities</td>
                                        </tr>
                                        <tr>
                                            <td>1.</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txthobbies1" runat="server" Width="321px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtextra_act1" runat="server" Width="363px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2.</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txthobbies2" runat="server" Width="321px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtextra_act2" runat="server" Width="363px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3.</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txthobbies3" runat="server" Width="321px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtextra_act3" runat="server" Width="363px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4.</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txthobbies4" runat="server" Width="321px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtextra_act4" runat="server" Width="363px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5.</td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txthobbies5" runat="server" Width="321px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtextra_act5" runat="server" Width="363px" TextMode="SingleLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Achievements"></asp:Label></td>
                                <td colspan="3" align="right">
                                    <asp:TextBox ID="txtachievements" runat="server" Width="600px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label38" runat="server" Text="Future Ambition"></asp:Label></td>
                                <td colspan="3" align="right">
                                    <asp:TextBox ID="txtfuture_ambition" runat="server" Width="600px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <asp:Label ID="Label37" runat="server" Text="Behavior Analysis"></asp:Label></td>
                                <td colspan="3" align="right">
                                    <asp:TextBox ID="txtbehavior_analysis" runat="server" Width="600px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel3" runat="server">
                <HeaderTemplate>
                    Meeting
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel5" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Reason for Meeting"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtmeeting_reason" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Text="Place of Meeting"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtmeeting_place" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label55" runat="server" Text="Date of Meeting"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtmeeting_date" runat="server" Width="200px" ToolTip="Date Formate- dd-mm-yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="txtmeeting_date_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtmeeting_date">
                                    </ajax:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Assign work"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlassign_work" runat="server" Width="225px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label43" runat="server" Text="Invite for any Purpose"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtany_purpose" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel4" runat="server">
                <HeaderTemplate>
                    Sangh Pariwar
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel6" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label44" runat="server" Text="Organization" Width="150px"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlorganization_serving" runat="server" Width="225px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Org1</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:Label ID="Label59" runat="server" Text="Present/Past"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddl_present_past" runat="server" Width="225px" >
                                        <asp:ListItem Text="Present"></asp:ListItem>
                                        <asp:ListItem Text="Past"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                
                              
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label61" runat="server" Text="Level" Width="150px"></asp:Label></td>
                                <td colspan="3" >
                                    <asp:DropDownList ID="ddl_rsslevel" runat="server" Width="600px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                              
                                 <td>
                                    <asp:Label ID="Label3" runat="server" Text="Designation" Width="150px"></asp:Label></td>
                                <td align="right">
                                    <asp:DropDownList ID="ddlrssdesignation" runat="server" Width="225px">
                                    </asp:DropDownList>
                                </td>
                                  <td>
                                    <asp:Label ID="Label60" runat="server" Text="Organization Training" Width="150px"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_sanghsiksha" runat="server" Width="225px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label45" runat="server" Text="Date from"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtorg_date_from" runat="server" Width="200px" ToolTip="Date Format- dd-mm-yyyy"></asp:TextBox>

                                    <ajax:CalendarExtender ID="txtorg_date_from_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg_date_from">
                                    </ajax:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label46" runat="server" Text="Date to"></asp:Label></td>
                                <td align="right">
                                    <asp:TextBox ID="txtorg_date_to" runat="server" Width="200px" ToolTip="Date Format- dd-mm-yyyy"></asp:TextBox>
                                    <ajax:CalendarExtender ID="txtorg_date_to_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtorg_date_to">
                                    </ajax:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label47" runat="server" Text="Vicharpariwar"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlarea_of_work" runat="server" Width="225px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Indian</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--<asp:Label ID="Label48" runat="server" Text="Place of Work"></asp:Label>--%>
                                    <asp:Label ID="Label48" runat="server" Text="Rastra"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:DropDownList ID="ddl_country3" runat="server" Width="225px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged3">
                                    </asp:DropDownList>

                                    <%-- <asp:DropDownList ID="ddlplace_of_work" runat="server" Width="225px">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Indian</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:DropDownList>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label64" runat="server" Text="Select ORG wise Kshetra/Zonee"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_kshetraorg3" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetraorg_SelectedIndexChanged3">
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Label ID="Label65" runat="server" Text="Select RSS wise Kshetra/Zonee"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_kshetrarss3" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetrarss_SelectedIndexChanged3">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label66" runat="server" Text="RSS Wise Prant Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_prant_rss3" runat="server" AutoPostBack="true" Width="225px" OnSelectedIndexChanged="ddl_prant_rss_SelectedIndexChanged3">
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Label ID="Label67" runat="server" Text="ORG Wise Prant Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_prant_org3" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_org_SelectedIndexChanged3">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label68" runat="server" Text="Govt Wise Prant Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_prant_govt3" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_govt_SelectedIndexChanged3">
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Label ID="Label69" runat="server" Text="Loksabha Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_lokshabhaname3" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_lokshabhaname_SelectedIndexChanged3">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label70" runat="server" Text="District Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_distr3" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_distr_SelectedIndexChanged3">
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Label ID="Label71" runat="server" Text="Vidhansabha  Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_vidhansabha3" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_vidhansabha_SelectedIndexChanged3">
                                    </asp:DropDownList></td>
                            </tr>

                            <tr>
                                <td>Tehsil</td>
                                <td>
                                    <asp:DropDownList ID="ddl_tehsil3" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_tehsil_SelectedIndexChanged3">
                                    </asp:DropDownList></td>

                                <td>Nagar</td>
                                <td>
                                    <asp:DropDownList ID="ddl_nagar3" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_nagar_SelectedIndexChanged3">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Upnagar</td>
                                <td>
                                    <asp:DropDownList ID="ddl_upnagar3" runat="server" Width="225px">
                                    </asp:DropDownList></td>

                                <td>Pincode</td>
                                <td>
                                    <asp:TextBox ID="txtpincode3" runat="server" placeholder="PinCode:"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label49" runat="server" Text="Achievement"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtachievement_work" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label50" runat="server" Text="Remarks"></asp:Label></td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtadditional_remarks" runat="server" Width="600px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <asp:Label ID="Label51" runat="server" Text="Varsh Attended"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlvarsh_attended" runat="server" Width="225px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label52" runat="server" Text="Additional Details"></asp:Label></td>
                                <td align="right">
                                    <asp:TextBox ID="txtadditional_details" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right">
                                    <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btn_add_Click" /></td>
                                <td align="left">
                                    <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnbtnreset_Click" /></td>

                                <td></td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>Org Serving</td>
                                <td>RSS Desig</td>
                                <td>From Date</td>
                                <td>To Date</td>
                                <td>Vicharpariwar</td>
                                <td>Present/Past</td>
                                <td>Achievement</td>
                                <td>Remarks</td>
                                <td>District </td>
                                <td>Nagar</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="ListBox1" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox10" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox2" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox3" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox4" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox5" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox6" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox7" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox8" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBox9" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="ListBoxcountry" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxkshetraorg" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxkshetrarss" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxprant_rss" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxprant_org" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxprant_govt" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxlokshabhaname" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxvidhansabha" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxtehsil" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxupnagar" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ListBox ID="ListBoxpincode" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxsanghsiksha" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                                <td>
                                    <asp:ListBox ID="ListBoxrsslevel" runat="server" Width="70px" Height="100px"></asp:ListBox></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel ID="TabPanel7" runat="server">
                <HeaderTemplate>
                    Memo
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="btnmemoupload" runat="server" CausesValidation="false" CssClass="form_button" OnClick="btnmemoupload_Click"
                                        Text="Upload Image" />
                                </td>
                                <td align="right">
                                    <asp:Image ID="Image1" runat="server" Width="250px" Height="250px" ImageUrl="" /></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="color: #FF0000; font-weight: bold">*&nbsp; Upload only .jpg format images</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label27" runat="server" Text="Discription"></asp:Label>
                                    <asp:TextBox ID="txtmemo" runat="server" Width="600px" Height="50px" TextMode="SingleLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_save" runat="server" Text="Save" OnClientClick="return validate();"  OnClick="btn_save_Click" /></td>
                                <td>
                                    <%--   <asp:Button ID="btn_open" runat="server" Text="Open" OnClick="btn_open_Click" />--%></td>
                                <td>
                                    <%--<asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click" />--%></td>
                                <td>
                                    <%--<asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="btn_delete_Click" />--%></td>
                                <td>
                                    <asp:Button ID="btn_reset" runat="server" Text="Reset" OnClick="btn_reset_Click" /></td>
                                <td>
                                    <%-- <asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btn_print_Click" />--%></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </ajax:TabPanel>
        </ajax:TabContainer>

    </div>
    <%--<cc1:Accordion runat="server" ID="Accordion1" HeaderCssClass="HeaderCSS" HeaderSelectedCssClass="HeaderSelectedCSS"
            ContentCssClass="ContentCss" Width="780px" Height="430px" BorderStyle="Solid"
            BackColor="#d8e4f8" BorderColor="#d8e4f8" Style="color: #000099; background-color: #d8e4f8;"
            RequireOpenedPane="false">
            <Panes>                
                <cc1:AccordionPane runat="server" ID="AccordionPane1">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Personal Details</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                            
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane2">
                    <Header>
                       <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Upload Photo
                        </a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                           
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane3">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Communication Detail
                            <asp:Label ID="Label2" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
                        </a>
                        <hr />
                    </Header>
                    <Content>
                         <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                           
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane4">
                    <Header>
                       <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Qualification Details</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                           
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane7">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Meeting Details</a>                      
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                            
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane8">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Sangh Pariwar Details</a>                      
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                            
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane6">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Extra Activity</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                            
                        </div>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane runat="server" ID="AccordionPane5">
                    <Header>
                        <a style="font-family: 'verdana'; font-size: 14px; font-weight: bold; text-transform: none; color: #000066; text-decoration: none;">Employment Details</a>
                        <hr />
                    </Header>
                    <Content>
                        <div style="background-color: #D5F7FF; font-size: 12px; color: #000000;">
                            
                        </div>
                    </Content>
                </cc1:AccordionPane>  
            </Panes>
        </cc1:Accordion>--%>

    <asp:HiddenField ID="hidden_img" runat="server" Value="" />
      <asp:HiddenField ID="hidden_memo" runat="server" Value="" />
      <asp:HiddenField ID="hidden_resume" runat="server" Value="" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/ReportMasterPage.master" AutoEventWireup="true" CodeFile="designationwisefilter.aspx.cs" Inherits="Admin_designationwisefilter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript" language="javascript">
          function printDiv() {
              var prtContent = document.getElementById('DivIdToPrint');
              var WinPrint = window.open('', '',
  'letf=0,top=0,width=1100,height=1000,toolbar=0,scrollbars=0,status=0');
              WinPrint.document.write(prtContent.innerHTML);
              WinPrint.document.close();
              WinPrint.focus();
              WinPrint.print();
              WinPrint.close();
              prtContent.innerHTML = strOldOne;
          }
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%=GV_personal_details.ClientID %>').Scrollable();
        }
)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table align="center">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px"
                            Font-Underline="True" ForeColor="#003399" Text="DESIGNATION WISE FILTER"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Select Rashtra"></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddl_country" runat="server" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Select ORG wise Kshetra/Zonee"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_kshetraorg" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetraorg_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Select RSS wise Kshetra/Zonee"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_kshetrarss" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_kshetrarss_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="RSS Wise Prant Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_prant_rss" runat="server" AutoPostBack="true" Width="195px" OnSelectedIndexChanged="ddl_prant_rss_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="ORG Wise Prant Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_prant_org" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_org_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Govt Wise Prant Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_prant_govt" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_prant_govt_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                         
                        </table>
                    </td>
                    <td colspan="2">

                        <table>
   <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Loksabha Name "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_lokshabhaname" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_lokshabhaname_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="District Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_distr" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_distr_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Vidhansabha  Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_vidhansabha" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_vidhansabha_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Tehsil Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_tehsil" runat="server" Width="195px" OnSelectedIndexChanged="ddl_tehsil_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Nagar Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_nagar" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_nagar_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="UpNagar Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_upnagar" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_upnagar_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                               <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Select Designation"></asp:Label>
                                </td>
                                <td>
                                    
                                      <asp:DropDownList ID="ddlrssdesignation" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddl_ocass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>




            </table>
            <div style="text-align: left; overflow-x: scroll; width: 800px; background-color: White; color: Black;" id="DivIdToPrint">
                <asp:GridView ID="GV_personal_details" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                    CellPadding="3"
                    PageSize="500" AllowPaging="true" GridLines="Vertical">
                    <RowStyle ForeColor="#000066" />
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <Columns>
                         <asp:BoundField DataField="Reg_ID" HeaderText="Registration ID" />
                                    <asp:BoundField DataField="Reg_Date" HeaderText="Reg Date" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Nick_Name" HeaderText="Nick Name" />
                                    <asp:BoundField DataField="Sex" HeaderText="Sex" />

                                    <asp:BoundField DataField="DOB" HeaderText="DOB" />
                                    <asp:BoundField DataField="Age" HeaderText="Age" />
                                    <asp:BoundField DataField="Nationality" HeaderText="Nationality" />
                                    <asp:BoundField DataField="Marriage_Date" HeaderText="Marriage_Date" />
                                    <asp:BoundField DataField="No_of_Family_Member" HeaderText="No_of_Family_Member" />

                                    <asp:BoundField DataField="Anniversary_Date" HeaderText="Anniversary_Date" />
                                    <asp:BoundField DataField="aadhar" HeaderText="aadhar" />
                                    <asp:BoundField DataField="Presentorganization" HeaderText="Present organization" />
                                    <asp:BoundField DataField="Address" HeaderText="Permament Address" />
                                    <asp:BoundField DataField="rastra1" HeaderText="P Rastra" />
                                    <asp:BoundField DataField="kshetraorg1" HeaderText="P kshetraorg" />
                                    <asp:BoundField DataField="kshetrarss1" HeaderText="P kshetrarss" />

                                    <asp:BoundField DataField="prantrss1" HeaderText="P Prantrss" />


                                    <asp:BoundField DataField="prantorg1" HeaderText="P prantorg" />
                                    <asp:BoundField DataField="prantgovt1" HeaderText="P prantgovt" />
                                    <asp:BoundField DataField="loksabha1" HeaderText="P loksabha" />

                                    <asp:BoundField DataField="district1" HeaderText="P district" />
                                    <asp:BoundField DataField="vidhansabha1" HeaderText="P vidhansabha" />
                                    <asp:BoundField DataField="tehsil1" HeaderText="P tehsil" />
                                    <asp:BoundField DataField="nagar1" HeaderText="P nagar" />
                                    <asp:BoundField DataField="upnagar1" HeaderText="P upnagar" />
                                    <asp:BoundField DataField="pincode1" HeaderText="P pincode" />

                                    <asp:BoundField DataField="fax1" HeaderText="P fax" />
                                    <asp:BoundField DataField="landno11" HeaderText="P landno 1" />
                                    <asp:BoundField DataField="landno12" HeaderText="P landno 2" />
                                    <asp:BoundField DataField="Address1" HeaderText="Current Address" />
                                    <asp:BoundField DataField="rastra2" HeaderText="C rastra" />
                                    <asp:BoundField DataField="kshetraorg2" HeaderText="C kshetraorg" />
                                    <asp:BoundField DataField="kshetrarss2" HeaderText="C kshetrarss2" />
                                    <asp:BoundField DataField="prantrss2" HeaderText="C prantrss" />
                                    <asp:BoundField DataField="prantorg2" HeaderText="C prantorg" />
                                    <asp:BoundField DataField="prantgovt2" HeaderText="C prantgovt" />
                                    <asp:BoundField DataField="loksabha2" HeaderText="C loksabha" />
                                    <asp:BoundField DataField="district2" HeaderText="C district" />
                                    <asp:BoundField DataField="vidhansabha2" HeaderText="C vidhansabha" />
                                    <asp:BoundField DataField="tehsil2" HeaderText="C tehsil" />
                                    <asp:BoundField DataField="nagar2" HeaderText="C nagar" />
                                    <asp:BoundField DataField="upnagar2" HeaderText="C upnagar" />
                                    <asp:BoundField DataField="pincode2" HeaderText="C pincode" />
                                    <asp:BoundField DataField="fax2" HeaderText="C fax" />
                                    <asp:BoundField DataField="landno21" HeaderText="C landno 1" />
                                    <asp:BoundField DataField="landno22" HeaderText="C landno 2" />
                                    <asp:BoundField DataField="Address2" HeaderText="Office Address" />
                                    <asp:BoundField DataField="rastra3" HeaderText="O rastra" />
                                    <asp:BoundField DataField="kshetraorg3" HeaderText="O kshetraorg" />
                                    <asp:BoundField DataField="kshetrarss3" HeaderText="O kshetrarss" />
                                    <asp:BoundField DataField="prantrss3" HeaderText="O prantrss" />
                                    <asp:BoundField DataField="prantorg3" HeaderText="O prantorg" />
                                    <asp:BoundField DataField="prantgovt3" HeaderText="O prantgovt" />
                                    <asp:BoundField DataField="loksabha3" HeaderText="O loksabha" />
                                    <asp:BoundField DataField="district3" HeaderText="O district" />
                                    <asp:BoundField DataField="vidhansabha3" HeaderText="O vidhansabha" />
                                    <asp:BoundField DataField="tehsil3" HeaderText="O tehsil" />
                                    <asp:BoundField DataField="nagar3" HeaderText="O nagar" />
                                    <asp:BoundField DataField="upnagar3" HeaderText="O upnagar" />
                                    <asp:BoundField DataField="pincode3" HeaderText="O pincode" />
                                    <asp:BoundField DataField="fax3" HeaderText="O fax" />
                                    <asp:BoundField DataField="landno31" HeaderText="O landno 1" />
                                    <asp:BoundField DataField="landno32" HeaderText="O landno 2" />
                                    <asp:BoundField DataField="Email_ID1" HeaderText="Email_ID1" />
                                    <asp:BoundField DataField="Email_ID2" HeaderText="Email_ID2" />
                                    <asp:BoundField DataField="Email_ID3" HeaderText="Email_ID3" />
                                    <asp:BoundField DataField="Email_ID4" HeaderText="Email_ID4" />
                                    <asp:BoundField DataField="Contact_No1" HeaderText="Contact_No1" />
                                    <asp:BoundField DataField="Contact_No2" HeaderText="Contact_No2" />
                                    <asp:BoundField DataField="Contact_No3" HeaderText="Contact_No3" />
                                    <asp:BoundField DataField="Contact_No4" HeaderText="Contact_No4" />
                                    <asp:BoundField DataField="bloglink" HeaderText="bloglink" />
                                    <asp:BoundField DataField="fblink" HeaderText="fblink" />
                                    <asp:BoundField DataField="website" HeaderText="website" />
                                    <asp:BoundField DataField="twitter" HeaderText="twitter" />
                                    <asp:BoundField DataField="linkedIn" HeaderText="linkedIn" />


                                    <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                                    <asp:BoundField DataField="QSpecialization" HeaderText="QSpecialization" />
                                    <asp:BoundField DataField="QSpecialization1" HeaderText="QSpecialization1" />
                                    <asp:BoundField DataField="QSpecialization2" HeaderText="QSpecialization2" />
                                    <asp:BoundField DataField="Q_AnyOtherDetails" HeaderText="Q_AnyOtherDetails" />
                                    <asp:BoundField DataField="Occupation" HeaderText="Occupation" />
                                    <asp:BoundField DataField="ESpecialization" HeaderText="ESpecialization" />
                                    <asp:BoundField DataField="ESpecialization1" HeaderText="ESpecialization1" />
                                    <asp:BoundField DataField="ESpecialization2" HeaderText="ESpecialization2" />
                                    <asp:BoundField DataField="Organization1" HeaderText="Organization" />
                                    <asp:BoundField DataField="Service_From1" HeaderText="Service_From" />
                                    <asp:BoundField DataField="Service_To1" HeaderText="Service_To" />
                                    <asp:BoundField DataField="Achivement1" HeaderText="Achivement 1" />
                                    <asp:BoundField DataField="Remark1" HeaderText="Designation 1" />
                                    <asp:BoundField DataField="Organization2" HeaderText="Organization 2" />
                                    <asp:BoundField DataField="Service_From2" HeaderText="Service_From 2" />
                                    <asp:BoundField DataField="Service_To2" HeaderText="Service_To 2" />
                                    <asp:BoundField DataField="Achivement2" HeaderText="Achivement 2" />
                                    <asp:BoundField DataField="Remark2" HeaderText="Designation 2" />
                                    <asp:BoundField DataField="Organization3" HeaderText="Organization 3" />
                                    <asp:BoundField DataField="Service_From3" HeaderText="Service_From 3" />
                                    <asp:BoundField DataField="Service_To3" HeaderText="Service_To 3" />
                                    <asp:BoundField DataField="Achivement3" HeaderText="Achivement 3" />
                                    <asp:BoundField DataField="Remark3" HeaderText="Designation 3" />
                                     <asp:BoundField DataField="Organization4" HeaderText="Organization 4" />
                                    <asp:BoundField DataField="Service_From4" HeaderText="Service_From 4" />
                                    <asp:BoundField DataField="Service_To4" HeaderText="Service_To 4" />
                                    <asp:BoundField DataField="Achivement4" HeaderText="Achivement 4" />
                                    <asp:BoundField DataField="Remark4" HeaderText="Designation 4" />
                                    <asp:BoundField DataField="Hobbies1" HeaderText="Hobbies 1" />
                                    <asp:BoundField DataField="Extra_Activities1" HeaderText="Extra_Activities 1" />
                                    <asp:BoundField DataField="Hobbies2" HeaderText="Hobbies 2" />
                                    <asp:BoundField DataField="Extra_Activities2" HeaderText="Extra_Activities 2" />
                                    <asp:BoundField DataField="Hobbies3" HeaderText="Hobbies 3" />
                                    <asp:BoundField DataField="Extra_Activities3" HeaderText="Extra_Activities 3" />
                                    <asp:BoundField DataField="Hobbies4" HeaderText="Hobbies 4" />
                                    <asp:BoundField DataField="Extra_Activities4" HeaderText="Extra_Activities 4" />
                                     <asp:BoundField DataField="Hobbies5" HeaderText="Hobbies 5" />
                                    <asp:BoundField DataField="Extra_Activities5" HeaderText="Extra_Activities 5" />
 
                                    <asp:BoundField DataField="Achievements" HeaderText="Achievements" />
                                    <asp:BoundField DataField="Future_Ambition" HeaderText="Future_Ambition" />
                                    <asp:BoundField DataField="Meeting_Reason" HeaderText="Meeting_Reason" />
                                    <asp:BoundField DataField="Meeting_Place" HeaderText="Meeting_Place" />
                                    <asp:BoundField DataField="Meeting_Date" HeaderText="Meeting_Date" />
                                    <asp:BoundField DataField="Assign_Work" HeaderText="Assign_Work" />
                                    <asp:BoundField DataField="Inviting_Purpose" HeaderText="Inviting_Purpose" />
                                    <asp:BoundField DataField="Memo_Discription" HeaderText="Memo_Discription" />
                                    <asp:BoundField DataField="rastra4" HeaderText="rastra4" />
                                    <asp:BoundField DataField="kshetraorg4" HeaderText="kshetraorg4" />
                                    <asp:BoundField DataField="kshetrarss4" HeaderText="kshetrarss4" />
                                    <asp:BoundField DataField="prantrss4" HeaderText="prantrss4" />
                                    <asp:BoundField DataField="prantorg4" HeaderText="prantorg4" />
                                    <asp:BoundField DataField="prantgovt4" HeaderText="prantgovt4" />
                                    <asp:BoundField DataField="loksabha4" HeaderText="loksabha4" />
                                    <asp:BoundField DataField="district4" HeaderText="district4" />
                                    <asp:BoundField DataField="vidhansabha4" HeaderText="vidhansabha4" />
                                    <asp:BoundField DataField="tehsil4" HeaderText="tehsil4" />
                                    <asp:BoundField DataField="nagar4" HeaderText="nagar4" />
                                    <asp:BoundField DataField="upnagar4" HeaderText="upnagar4" />
                                    <asp:BoundField DataField="pincode4" HeaderText="pincode4" />
                                    <asp:BoundField DataField="Organization" HeaderText="Organization" />
                                    <asp:BoundField DataField="RSSDesignation" HeaderText="Designation" />
                                   
                                    <asp:BoundField DataField="From_Date" HeaderText="From_Date" />
                                    <asp:BoundField DataField="To_Date" HeaderText="To_Date" />
                                    <asp:BoundField DataField="Achievement_During_Work" HeaderText="Achievement_During_Work" />
                                    <asp:BoundField DataField="Additional_Remark" HeaderText="Additional_Remark" />
                                    <asp:BoundField DataField="present_past" HeaderText="present_past" />
                                    <asp:BoundField DataField="sanghsiksha" HeaderText="sanghsiksha" />
                                    <asp:BoundField DataField="level" HeaderText="level" />
                                    <asp:BoundField DataField="vicharpariwar" HeaderText="vicharpariwar" />
                                    <asp:BoundField DataField="familymembername" HeaderText="familymembername" />
                    </Columns>
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


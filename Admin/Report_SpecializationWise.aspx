<%@ Page Language="C#" MasterPageFile="~/Admin/ReportMasterPage.master" AutoEventWireup="true" CodeFile="Report_SpecializationWise.aspx.cs" Inherits="Admin_Report_SpecializationWise" Title="Reporting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language ="javascript" >
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
     $(document).ready(function() {
     $('#<%=GV_personal_details.ClientID %>').Scrollable();
     }
)
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <table align="center" width="600px">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="20px" 
                    Font-Underline="True" ForeColor="#003399" Text="Specialization wise Member Report"></asp:Label>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center">
        <table>         
        <tr>
            <td colspan="2" align="center">
            <table width="100%">           
            <tr>
            <td><asp:Label ID="Label3" runat="server" Text="From Date"></asp:Label></td>
            <td>
        <table>
            <tr>
            <td> <asp:TextBox ID="txtfrom_date" runat="server" Width="150px"></asp:TextBox></td>
            <td> 
            <script language="JavaScript" type="text/javascript">
                var o_cal = new tcal({
                    // form name
                    'formname': 'aspnetForm',
                    // input name
                    'controlname': 'ctl00$ContentPlaceHolder1$txtfrom_date'
                });
                     </script>
            </td>
            </tr>
            </table>
        </td>
            <td><asp:Label ID="Label4" runat="server" Text="To Date"></asp:Label></td>
            <td>
        <table>
            <tr>
            <td> <asp:TextBox ID="txtto_date" runat="server" Width="150px"></asp:TextBox></td>
            <td> <script language="JavaScript" type="text/javascript">

                     var o_cal = new tcal({
                         // form name
                         'formname': 'aspnetForm',
                         // input name
                         'controlname': 'ctl00$ContentPlaceHolder1$txtto_date'
                     });

                     // individual template parameters can be modified via the calendar variable
	
	
	</script></td>
            </tr>
            </table>
        </td>
            </tr>
            <tr>
            
        <td>
            <asp:Label ID="Label1" runat="server" Text="Select Option"></asp:Label></td>
         <td>
                <asp:DropDownList ID="ddl_option" runat="server" Width="200px" Height="30px" 
                    AutoPostBack="true" onselectedindexchanged="ddl_option_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Personal Details</asp:ListItem>                  
                    <asp:ListItem>Communication Details</asp:ListItem>
                    <asp:ListItem>Qualification Details</asp:ListItem>
                    <asp:ListItem>Employment Details</asp:ListItem>
                    <asp:ListItem>Extra Activity Details</asp:ListItem>
                    <asp:ListItem>Meeting Details</asp:ListItem>
                    <asp:ListItem>Sangh Pariwar Details</asp:ListItem>                   
                </asp:DropDownList>
            </td> 
            <td>
            <asp:Label ID="Label9" runat="server" Text="Select Specialization"></asp:Label></td>
         <td>
                <asp:DropDownList ID="ddl_zone" runat="server" Width="200px" Height="30px" AutoPostBack="True" OnSelectedIndexChanged="ddl_zone_SelectedIndexChanged"></asp:DropDownList>
            </td> 
        </tr>
            <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Country"></asp:Label></td>
            <td><asp:DropDownList ID="ddl_country" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged">
                            <asp:ListItem>--Select Country--</asp:ListItem>
                            <asp:ListItem>India</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList></td>            
            <td><asp:Label ID="Label6" runat="server" Text="State"></asp:Label></td>
            <td><asp:DropDownList ID="ddl_state" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            <td><asp:Label ID="Label7" runat="server" Text="District"></asp:Label></td>
            <td><asp:DropDownList ID="ddl_district" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddl_district_SelectedIndexChanged"></asp:DropDownList></td>       
            <td><asp:Label ID="Label8" runat="server" Text="City"></asp:Label></td>
            <td><asp:DropDownList ID="ddl_city" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddl_city_SelectedIndexChanged"></asp:DropDownList></td>                            
            </tr>
            </table>
            </td>
        </tr>
        
        <tr>
            <td colspan="2" align="center">
            <div style="text-align:right">
                   <input type="button" width="120px" height="20px" value ="Print " onclick="printDiv()" />
           </div>
           </td>
        </tr> 
        </table>
        </td>
        </tr>       
        <tr>
        <td colspan="2" align="center">
        <asp:Panel ID="Panel2" runat="server" Height="230px" ScrollBars="Both" Width="800px">
        <div style="text-align:left; margin:0px auto 10px auto; background-color:White; color:Black; width:100%;" id="DivIdToPrint">
        <asp:GridView ID="GV_personal_details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Address, Country, State, District, Vidhansabha, Village, Address1, Country1, State1, District1, Vidhansabha1, Village1, Address2, Country2, State2, District2, Vidhansabha2, Village2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Qualification, QSpecialization, QSpecialization1, QSpecialization2, Q_AnyOtherDetails, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose, Sr_No, Organization, RSSDesignation ,From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Reg Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regdate" runat="server" Text='<%# Bind("Reg_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="40%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Nick Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_nickname" runat="server" Text='<%# Bind("Nick_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Sex">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sex" runat="server" Text='<%# Bind("Sex") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="DOB">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_dob" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Age">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_age" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>    
                                                 <asp:TemplateField HeaderText="Nationality">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_nationality" runat="server" Text='<%# Bind("Nationality") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Marriage">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_marriagedate" runat="server" Text='<%# Bind("Marriage_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="40%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Anniversary">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_annidate" runat="server" Text='<%# Bind("Anniversary_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Family Member">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_familymember" runat="server" Text='<%# Bind("No_of_Family_Member") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Member ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_memberid" runat="server" Text='<%# Bind("RSS_Member_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                           
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView>
        <asp:GridView ID="GV_communication_details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>       
                                            <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField>                                         
                                                <asp:TemplateField HeaderText="Country">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_country" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="State">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_state" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                   
                                                 <asp:TemplateField HeaderText="District">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_district" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="40%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="City">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_city" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Country1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_country1" runat="server" Text='<%# Bind("Country1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="State1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_state1" runat="server" Text='<%# Bind("State1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="District1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_district1" runat="server" Text='<%# Bind("District1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="City1">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_city1" runat="server" Text='<%# Bind("City1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Country2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_country2" runat="server" Text='<%# Bind("Country2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="State2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_state2" runat="server" Text='<%# Bind("State2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="District2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_district2" runat="server" Text='<%# Bind("District2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="City2">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_city2" runat="server" Text='<%# Bind("City2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Email ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_emailid1" runat="server" Text='<%# Bind("Email_ID1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Email ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_emailid2" runat="server" Text='<%# Bind("Email_ID2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Contact No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_contactno1" runat="server" Text='<%# Bind("Contact_No1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Contact No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_contactno2" runat="server" Text='<%# Bind("Contact_No2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Contact No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_contactno3" runat="server" Text='<%# Bind("Contact_No3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Contact No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_contactno4" runat="server" Text='<%# Bind("Contact_No4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                   
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView>
        <asp:GridView ID="GV_Qulification_Details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                 
                                                 <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_course1" runat="server" Text='<%# Bind("Course1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_course2" runat="server" Text='<%# Bind("Course2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_course3" runat="server" Text='<%# Bind("Course3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_course4" runat="server" Text='<%# Bind("Course4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Course">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_course5" runat="server" Text='<%# Bind("Course5") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>  
                                                <asp:TemplateField HeaderText="Specialization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_qspecialization" runat="server" Text='<%# Bind("QSpecialization") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Sub Specialization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_qspecialization1" runat="server" Text='<%# Bind("QSpecialization1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Sub Sub Specialization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_qspecialization2" runat="server" Text='<%# Bind("QSpecialization2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                                
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView>  
        <asp:GridView ID="GV_Employment_Details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                 
                                                 <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Occupation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_occupation" runat="server" Text='<%# Bind("Occupation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Specialization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_especialization" runat="server" Text='<%# Bind("ESpecialization") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Sub Specialization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_eSpecialization1" runat="server" Text='<%# Bind("ESpecialization1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Sub Sub Specialization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_eSpecialization2" runat="server" Text='<%# Bind("ESpecialization2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_srno1" runat="server" Text='<%# Bind("Sr_No1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_orgnization1" runat="server" Text='<%# Bind("Organization1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Service From">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_servicefrom1" runat="server" Text='<%# Bind("Service_From1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Service To">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_serviceto" runat="server" Text='<%# Bind("Service_To1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Achivement">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_achivement1" runat="server" Text='<%# Bind("Achivement1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Remark">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_remark" runat="server" Text='<%# Bind("Remark1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_srno2" runat="server" Text='<%# Bind("Sr_No2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_orgaqnization2" runat="server" Text='<%# Bind("Organization2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Service From">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_servicefrom2" runat="server" Text='<%# Bind("Service_From2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Service To">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_serviceto2" runat="server" Text='<%# Bind("Service_To2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Achivement">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_achivement2" runat="server" Text='<%# Bind("Achivement2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Remark">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_remark2" runat="server" Text='<%# Bind("Remark2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_srno" runat="server" Text='<%# Bind("Sr_No3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_organization3" runat="server" Text='<%# Bind("Organization3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Service From">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_servicefrom" runat="server" Text='<%# Bind("Service_From3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Service To">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_serviceto2" runat="server" Text='<%# Bind("Service_To3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Achivement">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_achivement3" runat="server" Text='<%# Bind("Achivement3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>  
                                                 <asp:TemplateField HeaderText="Remark">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_remark3" runat="server" Text='<%# Bind("Remark3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_srno" runat="server" Text='<%# Bind("Sr_No4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_organization4" runat="server" Text='<%# Bind("Organization4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Service From">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_servicefrom4" runat="server" Text='<%# Bind("Service_From4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Service To">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_serviceto4" runat="server" Text='<%# Bind("Service_To4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Achivement">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_achivement4" runat="server" Text='<%# Bind("Achivement4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Remark">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_remark4" runat="server" Text='<%# Bind("Remark4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                          
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView>  
        <asp:GridView ID="GV_Extra_Activity_Details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                 
                                                 <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_asr_no1" runat="server" Text='<%# Bind("ASr_No1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Hobby">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_hobbies1" runat="server" Text='<%# Bind("Hobbies1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                 <asp:TemplateField HeaderText="Extra Activity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_extra_activities1" runat="server" Text='<%# Bind("Extra_Activities1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_asr_no2" runat="server" Text='<%# Bind("ASr_No2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Hobby">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_hobbies2" runat="server" Text='<%# Bind("Hobbies2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Extra Activity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_extra_activities2" runat="server" Text='<%# Bind("Extra_Activities2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_asr_no3" runat="server" Text='<%# Bind("ASr_No3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Hobby">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_hobbies3" runat="server" Text='<%# Bind("Hobbies3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Extra Activity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_extra_activities3" runat="server" Text='<%# Bind("Extra_Activities3") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_asr_no4" runat="server" Text='<%# Bind("ASr_No4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Hobby">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_hobbies4" runat="server" Text='<%# Bind("Hobbies4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                
                                                 <asp:TemplateField HeaderText="Extra Activity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_extra_activities4" runat="server" Text='<%# Bind("Extra_Activities4") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_asr_no5" runat="server" Text='<%# Bind("ASr_No5") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Hobby">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_hobbies5" runat="server" Text='<%# Bind("Hobbies5") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Extra Activity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_extra_activities5" runat="server" Text='<%# Bind("Extra_Activities5") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                              
                                                 <asp:TemplateField HeaderText="Achievements">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_achievements" runat="server" Text='<%# Bind("Achievements") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Behavior Analysis">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_behavior_analysis" runat="server" Text='<%# Bind("Behavior_Analysis") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Future Ambition">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_future_ambition" runat="server" Text='<%# Bind("Future_Ambition") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                           
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView> 
        <asp:GridView ID="GV_Meeting_Details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Reg_Date, Name, Nick_Name, Sex, DOB, Age, Nationality, Marriage_Date, Anniversary_Date, No_of_Family_Member, RSS_Member_ID, Country, State, District, City, Country1, State1, District1, City1, Country2, State2, District2, City2, Email_ID1, Email_ID2, Contact_No1, Contact_No2, Contact_No3, Contact_No4, Course1,Course2, Course3, Course4, Course5, QSpecialization, QSpecialization1, QSpecialization2, Occupation, ESpecialization, ESpecialization1, ESpecialization2, Sr_No1, Organization1, Service_From1, Service_To1, Achivement1, Remark1, Sr_No2, Organization2, Service_From2, Service_To2, Achivement2, Remark2, Sr_No3, Organization3, Service_From3, Service_To3, Achivement3, Remark3, Sr_No4, Organization4, Service_From4, Service_To4, Achivement4, Remark4, ASr_No1, Hobbies1, Extra_Activities1, ASr_No2, Hobbies2, Extra_Activities2, ASr_No3, Hobbies3, Extra_Activities3, ASr_No4, Hobbies4, Extra_Activities4, ASr_No5, Hobbies5, Extra_Activities5, Achievements, Behavior_Analysis, Future_Ambition, Meeting_Reason, Meeting_Place, Meeting_Date, Assign_Work, Inviting_Purpose"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                 
                                                 <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField>                                               
                                                <asp:TemplateField HeaderText="Meeting Reason">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_meetingreason" runat="server" Text='<%# Bind("Meeting_Reason") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Meeting Place">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_meetingplace" runat="server" Text='<%# Bind("Meeting_Place") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>             
                                                <asp:TemplateField HeaderText="Meeting Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_meetingdate" runat="server" Text='<%# Bind("Meeting_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="Assign Work">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_assign_work" runat="server" Text='<%# Bind("Assign_Work") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Inviting Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_inviting_purpose" runat="server" Text='<%# Bind("Inviting_Purpose") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                                                       
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView> 
        <asp:GridView ID="GV_SanghPariwar_details" runat="server" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" OnPageIndexChanging="Paging_UplinerDetails"
                                            CellPadding="3" DataKeyNames="Reg_ID, Reg_Date, Name, RSS_Member_ID, Sr_No, Organization, From_Date, To_Date, Work_Area, Work_Place, Achievement_During_Work, Additional_Remark, Varsh_Attended, Additional_Details, Memo_Discription"
                                            PageSize="500" AllowPaging="true" GridLines="Vertical" Width="100%" Height="15px">   
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Reg ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_regid" runat="server" Text='<%# Bind("Reg_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                                                 
                                                 <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="20%"></ItemStyle>
                                                </asp:TemplateField>                                               
                                                <asp:TemplateField HeaderText="Sr No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Sr_No" runat="server" Text='<%# Bind("Sr_No") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Organization">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Organization" runat="server" Text='<%# Bind("Organization") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>             
                                                <asp:TemplateField HeaderText="From Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_From_Date" runat="server" Text='<%# Bind("From_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="15%"></ItemStyle>
                                                </asp:TemplateField>                                                                 
                                                 <asp:TemplateField HeaderText="To Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_To_Date" runat="server" Text='<%# Bind("To_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>                 
                                                <asp:TemplateField HeaderText="Work Area">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Work_Area" runat="server" Text='<%# Bind("Work_Area") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>   
                                                <asp:TemplateField HeaderText="Work Place">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Work_Place" runat="server" Text='<%# Bind("Work_Place") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>   
                                                <asp:TemplateField HeaderText="Achievement During Work">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Achievement_During_Work" runat="server" Text='<%# Bind("Achievement_During_Work") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>   
                                                <asp:TemplateField HeaderText="Additional Remark">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Additional_Remark" runat="server" Text='<%# Bind("Additional_Remark") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>   
                                                <asp:TemplateField HeaderText="Varsh Attended">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Varsh_Attended" runat="server" Text='<%# Bind("Varsh_Attended") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField>   
                                                <asp:TemplateField HeaderText="Additional Details">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Additional_Details" runat="server" Text='<%# Bind("Additional_Details") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" Width="2%" />
                                                    <ItemStyle Width="10%"></ItemStyle>
                                                </asp:TemplateField> 
                                                 <asp:TemplateField HeaderText="Memo Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_MemoDescription" runat="server" Width="400px" Text='<%# Bind("Memo_Discription") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                                                           
                                                 </Columns>
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                        </asp:GridView>                         
        </div>
 </asp:Panel>
        </td>
        </tr>     
    </table>
</ContentTemplate>
            <Triggers>              
 <asp:AsyncPostBackTrigger ControlID="ddl_option" EventName="SelectedIndexChanged" /> 
 <asp:AsyncPostBackTrigger ControlID="ddl_country" EventName="SelectedIndexChanged" /> 
 <asp:AsyncPostBackTrigger ControlID="ddl_state" EventName="SelectedIndexChanged" /> 
 <asp:AsyncPostBackTrigger ControlID="ddl_district" EventName="SelectedIndexChanged" /> 
 <asp:AsyncPostBackTrigger ControlID="ddl_city" EventName="SelectedIndexChanged" /> 
               </Triggers>
 </asp:UpdatePanel>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


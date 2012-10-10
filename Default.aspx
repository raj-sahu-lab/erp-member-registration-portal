<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>	RSS </title>
<link rel="stylesheet" href="css/Layout.css" type="text/css" />
<link rel="stylesheet" href="css/cal.css" type="text/css" />
<script type="text/javascript" src="js/datetimepickerh.js"></script>
<script type="text/javascript" src="js/md5-min.js"></script>
<link href="SKN/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form name="form1" method="post" id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div id="loginheader">
            <div id="loginboxheader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="25%" valign="top">
                            <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" bgcolor="#FF3300">
                                        <img src="images/rssh.png" alt="" height="70px" />                                       
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                        <td width="53%" valign="top" bgcolor="#FF3300">
                            <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <h2 align="center">
                                            <span id="span1" style="font-size:XX-Large;"></span>&nbsp;</h2>
                                        <h1 align="center">
                                            <span id="Label5" style="font-size:X-Large;"></span>&nbsp;</h1>
                                        <h3 align="center" style="color: #00008b">
                                            <span id="lblheading" style="font-size:Large;text-decoration:none;"></span>
                                        </h3>
                                        <h3 align="center" style="color: #00008b">
                                            
                                        </h3>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="22%" valign="top" align="right" bgcolor="#FF3300">
                          
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <%--<td width="20%" valign="top">
                                        <div>
                                            <h1 class="Grey_Table" style="text-align: center;">                                                
                                                <span style="left: 0px; top: 0px">RSS MENU</span>
                                            </h1>
                                            <div class="brd_LR_innber pad" style="background-color: #d8e4f8; height: 320px;">
                                               <table>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="lnkdaiylreport" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">Home</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A1" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">About Us</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A2" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">Videos</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A3" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">Press Release</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A4" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">FAQs</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A5" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">Resourses</a>
                                                        </td>
                                                </tr>
                                                <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A6" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">Contact Us</a>
                                                        </td>
                                                </tr>
                                                 <tr>
                                                        <td>
                                                            <img src="images/arrow-right.gif" />
                                                            <a id="A7" href="javascript:__doPostBack('lnkdaiylreport','')" style="color:DarkBlue;font-size:12px;font-weight:bold;text-decoration:none;">Registration</a>
                                                        </td>
                                                </tr>
                                               </table> 
                                            </div>
                                            <div class="Grey_Table">
                                                                                           
                                            </div>
                                        </div>
                                    </td>--%>            
                                     <td valign="top" style="width: 1%">
                                     </td>                       
                                    <td width="79%" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td id="tdloginbox" width="80%">
                                                    <div>
                                                        <h1 class="Grey_Table" style="text-align: center;">
                                                            <span style="left: 0px; top: 0px">NEWS AND UPDATES</span></h1>
                                                        <div class="brd_LR_innber pad" style="background-color: #d8e4f8; height: 320px;">
                                                        <marquee direction="Up" scrolldelay="1.8" scrollamount="1" onmouseout="this.setAttribute('scrollamount', 1, 0);" onmouseover="this.setAttribute('scrollamount', 0, 0);" height="200px";>
                                                            &nbsp;&nbsp;<asp:Label ID="lb_news" runat="server" Text="Welcome to RSS......"></asp:Label>&nbsp;                       
                                                        </marquee>                                                          
                                                        </div>
                                                        <div class="Grey_Table">
                                                            <div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                 <td valign="top" style="width: 1%">
                                                 </td> 
                                                <td id="td1" width="19%">
                                                    <div>
                                                        <h1 class="Grey_Table" style="text-align: center;">
                                                            <span style="left: 0px; top: 0px">LOGIN FORM</span></h1>
                                                        <div class="brd_LR_innber pad" style="background-color: #d8e4f8; height: 320px;">
                                                             <table id="Login1" cellpadding="0" cellspacing="8">                   
                    <tr>
                    <td>Login Mode</td>
                    <td><asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="205px" AutoPostBack="false">
                    </asp:DropDownList>
                     </td>
                    </tr>
                    <tr>
                    <td>ID NO.</td>
                    <td><asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox> </td>
                    </tr>
                    <tr><td></td><td></td></tr>
                    <tr>
                    <td><div class="Detail">
                                    PASSWORD</div></td>
                    <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="180px"></asp:TextBox> </td>
                    </tr>
                    <tr>
                    <td colspan="2" align="center"> <asp:Button ID="BtnLogin" runat="server" Text="Login" onclick="BtnLogin_Click" />
                    <br />
                    </td>
                   
                    </tr>
                    <tr>
                    <td>
                                                             
                                  <script>
                                      function PopupCenter(pageURL, title, w, h) {
                                          var left = (screen.width / 2) - (w / 2);
                                          var top = (screen.height / 2) - (h / 2);
                                          var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
                                      }
                                                                </script>

<%--<a href="javascript:void(0);" onclick="PopupCenter('http://[your-website.com]/Forget_ID.aspx', 'myPop1',550,180);" class="Link">Forget ID ?</a>--%>
                              
         </td>
                    <td>
          <script>
              function PopupCenter(pageURL, title, w, h) {
                  var left = (screen.width / 2) - (w / 2);
                  var top = (screen.height / 2) - (h / 2);
                  var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
              }
                                                                </script>
<%--<a href="javascript:void(0);" onclick="PopupCenter('http://[your-website.com]/Forget_Password.aspx', 'myPop1',550,150);" class="Link">Forget Password ?</a>--%>
                                   
         </td>
                    
                    </tr>
                </table>                                                          
                                                        </div>
                                                        <div class="Grey_Table">
                                                            <div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>                                
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="40%" valign="top">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="right">
                            <div id="footer">                            
                            <div style="padding: 5px; border: solid 1px #ccc;">
                                
    <div align="center" style="padding-left:5px; padding-right:5px;width:100%; height: 125px;" >
    <div style="height:120px; vertical-align:middle;padding-top:5px;">
            <script type="text/javascript">
                var sliderwidth = "960px"
                //Specify the slider's height
                var sliderheight = "120px"
                //Specify the slider's slide speed (larger is faster 1-10)
                var slidespeed = 2
                //configure background color:
                slidebgcolor = "#FFFFFF"

                //Specify the slider's images
                var leftrightslide = new Array()
                var finalslide = ''
                leftrightslide[0] = '<img src="Img_Member/1.jpg" border=0>'
                leftrightslide[1] = '<img src="Img_Member/2.jpg" border=0>'
                leftrightslide[2] = '<img src="Img_Member/3.jpg" border=0>'
//                leftrightslide[3] = '<img src="Img_Member/4.jpg" border=0>'
//                leftrightslide[4] = '<img src="Img_Member/5.jpg" border=0>'
//                leftrightslide[5] = '<img src="Img_Member/6.jpg" border=0>'
//                leftrightslide[6] = '<img src="Img_Member/7.jpg" border=0>'
//                leftrightslide[7] = '<img src="Img_Member/8.jpg" border=0>'
//                leftrightslide[8] = '<img src="Img_Member/9.jpg" border=0>'
//                leftrightslide[9] = '<img src="Img_Member/10.jpg" border=0>'
//                leftrightslide[10] = '<img src="Img_Member/11.jpg" border=0>'
//                leftrightslide[11] = '<img src="Img_Member/12.jpg" border=0>'
//                leftrightslide[12] = '<img src="Img_Member/13.jpg" border=0>'
//                leftrightslide[13] = '<img src="Img_Member/14.jpg" border=0>'
//                leftrightslide[14] = '<img src="Img_Member/15.jpg" border=0>'
//                leftrightslide[15] = '<img src="Img_Member/16.jpg" border=0>'
//                leftrightslide[16] = '<img src="Img_Member/17.jpg" border=0>'

                //Specify gap between each image (use HTML):
                var imagegap = " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  "

                //Specify pixels gap between each slideshow rotation (use integer):
                var slideshowgap = 10


                ////NO NEED TO EDIT BELOW THIS LINE////////////

                var copyspeed = slidespeed
                leftrightslide = '<nobr>' + leftrightslide.join(imagegap) + '</nobr>'
                var iedom = document.all || document.getElementById
                if (iedom)
                    document.write('<span id="temp" style="visibility:hidden;position:absolute;top:-100px;left:-9000px">' + leftrightslide + '</span>')
                var actualwidth = ''
                var cross_slide, ns_slide

                function fillup() {
                    if (iedom) {
                        cross_slide = document.getElementById ? document.getElementById("test2") : document.all.test2
                        cross_slide2 = document.getElementById ? document.getElementById("test3") : document.all.test3
                        cross_slide.innerHTML = cross_slide2.innerHTML = leftrightslide
                        actualwidth = document.all ? cross_slide.offsetWidth : document.getElementById("temp").offsetWidth
                        cross_slide2.style.left = actualwidth + slideshowgap + "px"
                    }
                    else if (document.layers) {
                        ns_slide = document.ns_slidemenu.document.ns_slidemenu2
                        ns_slide2 = document.ns_slidemenu.document.ns_slidemenu3
                        ns_slide.document.write(leftrightslide)
                        ns_slide.document.close()
                        actualwidth = ns_slide.document.width
                        ns_slide2.left = actualwidth + slideshowgap
                        ns_slide2.document.write(leftrightslide)
                        ns_slide2.document.close()
                    }
                    lefttime = setInterval("slideleft()", 30)
                }
                window.onload = fillup

                function slideleft() {
                    if (iedom) {
                        if (parseInt(cross_slide.style.left) > (actualwidth * (-1) + 8))
                            cross_slide.style.left = parseInt(cross_slide.style.left) - copyspeed + "px"
                        else
                            cross_slide.style.left = parseInt(cross_slide2.style.left) + actualwidth + slideshowgap + "px"

                        if (parseInt(cross_slide2.style.left) > (actualwidth * (-1) + 8))
                            cross_slide2.style.left = parseInt(cross_slide2.style.left) - copyspeed + "px"
                        else
                            cross_slide2.style.left = parseInt(cross_slide.style.left) + actualwidth + slideshowgap + "px"

                    }
                    else if (document.layers) {
                        if (ns_slide.left > (actualwidth * (-1) + 8))
                            ns_slide.left -= copyspeed
                        else
                            ns_slide.left = ns_slide2.left + actualwidth + slideshowgap

                        if (ns_slide2.left > (actualwidth * (-1) + 8))
                            ns_slide2.left -= copyspeed
                        else
                            ns_slide2.left = ns_slide.left + actualwidth + slideshowgap
                    }
                }


                if (iedom || document.layers) {
                    with (document) {
                        document.write('<table border="0" cellspacing="0" cellpadding="0"><td>')
                        if (iedom) {
                            write('<div style="position:relative;width:' + sliderwidth + ';height:' + sliderheight + ';overflow:hidden">')
                            write('<div style="position:absolute;width:' + sliderwidth + ';height:' + sliderheight + ';background-color:' + slidebgcolor + '" onMouseover="copyspeed=0" onMouseout="copyspeed=slidespeed">')
                            write('<div id="test2" style="position:absolute;left:0px;top:0px"></div>')
                            write('<div id="test3" style="position:absolute;left:-100%;top:0px"></div>')
                            write('</div></div>')
                        }
                        else if (document.layers) {
                            write('<ilayer width=' + sliderwidth + ' height=' + sliderheight + ' name="ns_slidemenu" bgColor=' + slidebgcolor + '>')
                            write('<layer name="ns_slidemenu2" left=0 top=0 onMouseover="copyspeed=0" onMouseout="copyspeed=slidespeed"></layer>')
                            write('<layer name="ns_slidemenu3" left=0 top=0 onMouseover="copyspeed=0" onMouseout="copyspeed=slidespeed"></layer>')
                            write('</ilayer>')
                        }
                        document.write('</td></table>')
                    }
                }
</script>
</div> 
    </div>           
                    </div>
                     <p align="right"><font color="darkolivegreen" size="2">Site Designed & Developed By [Company Name]</font></p>
                    </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</form>
</body>
</html>
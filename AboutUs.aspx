<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"><meta http-equiv="X-Frame-Options" content="deny" />
<link href="https://chatserver.comm100.com/css/comm100_livechatbutton.css" rel="stylesheet" type="text/css" />
<link rel="Slide/css/stylesheet" type="text/css" href="http://cdn.webrupee.com/font" />
<link href="Slide/Flash/js-image-slider.css" rel="stylesheet" type="text/css" />
<script src="Slide/Flash/js-image-slider.js" type="text/javascript"></script>
<link href="css/Style.css" rel="stylesheet" type="text/css" />
<link href="css/msgpop.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .style1
            {
                width:826px;
            }
            #mcts1
            {
                width: 35px;
            }
        </style>
   
    <style type="text/css">
        .circle
        {
            color: #FFF;
            text-align: center;
            float: left;
            width: 40px;
            height: 30px;
            background-color: #00A8F9;
            border: 1px solid #DDD;
            padding: 0px 5px 10px 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            font-family: Cambria;
            font-size: 30px;
        }
        .styletable
        {
            color: #00A8F9;
            font-family: Cambria;
            font-size: 12px;
            font-weight: bold;
        }
    </style>
<meta http-equiv="X-Frame-Options" content="deny" />
<style> html{display:none;} </style>
<script>
   if(self == top) {
       document.documentElement.style.display = 'block';
   }
</script>
<title>

</title>
<link href="css/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <table cellpadding="0" cellspacing="0" align="center" class="header" style="font-size: 0.80em; color:#999;">
        <tr>
            <td valign="top">
                <a href="">
                    <img src="images/sun logo.jpg" style="padding:2px 2px 2px 0px;" alt=""  title="" width="140px" border="0" /></a>
            </td>
            <td valign="top" align="right" valign="bottom" >
              <div  style="padding:5px 0px 5px 0px; width:840px;">
              <asp:Image ID="Image2" runat="server" ImageUrl="images/fb.png" Width="30px" />
              <asp:Image ID="Image3" runat="server" ImageUrl="images/twitter.jpg" Width="30px" />
              <asp:Image ID="Image4" runat="server" ImageUrl="images/googleplus.png" Width="30px" />
              <asp:Image ID="Image5" runat="server" ImageUrl="images/linkedin.png" Width="30px" />
              <asp:Image ID="Image6" runat="server" ImageUrl="images/youtube.png" Width="30px" />
     </div>
          <div style="  font-size:14px; color:Black; height:60px;">
              <asp:Image ID="Image1" runat="server" ImageUrl="images/org-banner.png" Width="885px" />
          <marquee Direction="Left" onmouseout="this.setAttribute('scrollamount', 3, 0);"  onmouseover="this.setAttribute('scrollamount', 0, 0);" scrolldelay="3" scrollamount="1"> <a href="">Increase your income & sales</a></marquee></div>

               
                      <div style=" padding: 5px 0px; vertical-align:top; color:#f4af3b; border:solid 0px #999;background:#fff; width:880px;  height:25px;   box-shadow:1px 1px 1px 3px silver;  margin-bottom:5px; border-radius:4px; font-size:16px; background-color:Black; ">

                                <a  style="font-size: 14px; font-weight:bold;" href="Default.aspx" title="">Home </a>&nbsp;|&nbsp;
                                <a  style="font-size: 14px; font-weight:bold;" href="AboutUs.aspx" title="">About Us</a>&nbsp;|
                                <a  style="font-size: 14px; font-weight:bold;" href="Services.aspx" title="">Services</a>&nbsp;|                                
                                <a  style="font-size: 14px; font-weight:bold;" href="Registration.aspx" title="">Registration</a>&nbsp;|
                                <a  style="font-size: 14px; font-weight:bold;" href="Plans.aspx"title="">Plans</a>&nbsp;|
                                <a  style="font-size: 14px; font-weight:bold;" href="Clients.aspx" title="">Clients</a>&nbsp;|
                                <a  style="font-size: 14px; font-weight:bold;" href="FAQs.aspx" title="On our Services">FAQ </a>&nbsp;|&nbsp;
                                <a  style="font-size: 14px; font-weight:bold;" href="ContactUs.aspx" title="">Contact us</a>&nbsp;&nbsp;
                </div>          
            </td>
        </tr> 
    </table>
</div>
<table cellpadding="0" cellspacing="0" align="center" class="content">
           <tr>
                <td valign="top" align="left">
                <div>
                 <asp:Image ID="Image7" runat="server" ImageUrl="~/images/aboutus.jpg" Width="100%" />
    </div>
                </td>
                </tr>
                </table>
    
    <div style="box-shadow:1px 1px 1px 3px silver; height:40px;  margin-bottom:-60px; background-color:Black;">

      <div style="color:color:#999;padding-top:5px;  text-align:center;"><a>COPYRIGHT © 2013. ALL RIGHTS RESERVED. | DESIGNED & DEVELOPED BY : [Company Name]</a></div>
            
            <script type="text/javascript">

                var _gaq = _gaq || [];
                _gaq.push(['_setAccount', 'UA-39120498-1']);
                _gaq.push(['_trackPageview']);

                (function() {
                    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
                })();

</script>
    </div>
    </form>
</body>
</html>
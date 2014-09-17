<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Entry.aspx.cs" Inherits="Exam.HR_Entry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mahindra Holiday Login Page for Candidate</title>	
<link rel="stylesheet" type="text/css" href="style2.css" />
<link rel="stylesheet" type="text/css" href="reset.css" />
<script type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 107%;
        }
    </style>

</head>
<body>
 
    <!-- page Container -->	
<div id="mh-container">		
 
<!-- content 	
<div id="mh-content">	-->			
 
<!-- welcome content -->			
<div id="mh-welcome">
<p class="welcome-cand">Candidate Entry for HR</p>
<p class="welcome-text">Please Enter Candidate Details </p>
</div>
<!-- end of welcome -->			
 
 
<!-- Login starts-->			
<div id="mh-login-container">
 
 
<div id="mh-loginform">
 
    <form id="form1" runat="server">
  
     <asp:ScriptManager ID="smScriptManager" runat="server" /> 
        <asp:Timer ID="tmrTimer" runat="server" ontick="tmrTimer_Tick" /> 
        <br /> 
        <hr /> 
        <br /> This is where the content is in your site. These banners can wrap...
        <br /> 
        <asp:UpdatePanel ID="bpBannerPanel" runat="server" UpdateMode="Conditional"> 
        <Triggers> 
        <asp:AsyncPostBackTrigger ControlID="tmrTimer" /> 
        </Triggers> 
        <ContentTemplate> 
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </ContentTemplate> 
        </asp:UpdatePanel> 
        <br />
  
  
  
  
  
  
  
<div class="level"><label for="CandidateName">First Name :</label></div>
<div class="input">
    <asp:TextBox ID="txtCDFname" runat="server"></asp:TextBox>
                </div><br />  
 
 <div class="level"><label for="CandidateName">Last Name  :</label></div>
<div class="input">
    <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                </div><br />  
 
<div class="level"><label for="Mobile">Mobile :</label></div>
<div class="input">
    <asp:TextBox ID="txtCDmobile" runat="server" MaxLength="10"></asp:TextBox>
    
 
 

 
     </div>
     
     <br /> 


</table>
<div class="level"><label for="Email">Email :</label></div>

<div class="input">
    <asp:TextBox ID="txtCDemail" runat="server"></asp:TextBox>
   
                </div><br />  
 
 <table width ="100%" cellpadding ="0" cellspacing ="0">
 <tr>
 <td width="60%" align="left">
     <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Candidate Login</asp:LinkButton>--%>
     <table class="style1">
         <tr>
             <td>
             <asp:ImageButton ID="ImageButton2" runat="server" onclick="ImageButton2_Click"
        ImageUrl="~/images/CandidateLogin-Button.jpg" />
                 &nbsp;</td>
             <td >
             
    
 </td>
 <td>
             <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/images/Submit-button.jpg" onclick="ImageButton1_Click" Width="75px" />
 
             </td>
         </tr>
        
                            </table>
 </td>
 
 </tr>
 
 </table>
 <table>
 <tr>
 <td width="30%" >
  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
        ControlToValidate="txtCDmobile" ErrorMessage ="InValid Mobile No"
        ValidationExpression="^9[0-9]{9}$"></asp:RegularExpressionValidator> 
  </td>
  <td width="30%" >
  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtCDemail" ErrorMessage="InValid Email Id" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  </asp:RegularExpressionValidator>
    
 </td>
  <td width="40%" >
<asp:Label ID="lblmsg" text="" runat="server" Width="202px" Font-Bold="True" 
         ForeColor="Black" ></asp:Label>
 </td>
 </tr>
 </table>

 
 </form>
</div>
<!-- End of Login-form -->
</div>
<!-- End of Login-container -->	
 
 
</div>
 
<div id="footer">

<p>Copyright &copy; MahindraHolidays 2013</p>
 
 
 
<!-- End of footer -->
 
 
</div>
<!-- End of page container -->	
    
</body>
</html>

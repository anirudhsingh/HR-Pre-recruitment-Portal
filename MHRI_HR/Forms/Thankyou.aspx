<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thankyou.aspx.cs" Inherits="Exam.Thankyou" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 
  <head>
<meta http-equiv="expires" content="-1" />
    <meta http-equiv="Cache-Control" content="no-cache" />
     <meta http-equiv="Pragma" content="no-cache" />
    <title>Mahindra Holiday HR Login Page</title>	

      <link href="../css/styleHRLogin_Thanku.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    window.history.forward(1);
</script>
</head>
 
<body onload="history.go(1);">
    <!-- page Container -->
    <form id="Form1" runat="server" >
  <div id="thank-container">
<div class="rsi_header rsi_header_image"></div>
<div class="rsi_clear"></div>

       
        <div id="thank-mh-container">
        
        
        
         <table width="100%">
            <tr>
                <td width="30%">
                
                </td>
                <td width="65%">
                </td>
                <td width="5%">
                </td>
            </tr>
       
        
            <tr>
                <td align="center" width="30%">
                </td>
                <td align="center" width="65%">
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red" Visible="False"  Font-Bold="True"></asp:Label>
                </td>
                <td width="5%">
               
                </td>
            </tr>
            
            <tr>
           
            </tr>
        </table>
           <div id="thank-mh-thanktext" style="color:#0D9DDB">
              Thank You!
          </div>
            <div id="Div2" >
             <br /><br />
          </div>
          
           <div id="Div3" >
               <br /><br />
          </div>
          
        <div id="Div1" align="center">
              <asp:ImageButton ID="imgSubmit" runat="server" Visible="false"
                  ImageUrl="~/images/Submit-button.jpg" onclick="imgSubmit_Click" />&nbsp;&nbsp;<br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"> </asp:ScriptManager>
                <asp:Timer ID="TimerToReloadHRpage" runat="server" OnTick="TimerToReloadHRpage_Tick" Interval="20000">
              </asp:Timer>
            
             
          </div>
        </div>
    </div>
    <!-- End of Login-form -->
    <div style="padding-left:11.5%">
            <p>
             Copyright &copy; MahindraHolidays 2013</p>
        </div>
        
    <%--<div id="thank-footer">
        <p>
            Copyright &copy; MahindraHolidays 2013</p>
    </div>--%>
    </form>
</body>

</html>
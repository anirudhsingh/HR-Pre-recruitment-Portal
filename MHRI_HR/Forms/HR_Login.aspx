<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_Login.aspx.cs" Inherits="Exam.HR" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <meta http-equiv="expires" content="-1" />
    <meta http-equiv="Cache-Control" content="no-cache" />
     <meta http-equiv="Pragma" content="no-cache" />
    <title>CMPET Application</title>
    <link href="../css/styleHRLogin_Thanku.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        window.history.forward(1);
    </script>

</head>
<body onload="history.go(1);">

    <form id="form1" runat="server">
    <div id="hr-container">
        <div class="rsi_header rsi_header_image">
        </div>
        <div class="rsi_clear">
        </div>
        <!-- Login starts-->
        <div id="hrlogin-mh-login-container">
            <%--<div id="hrlogin-mh-loginform">
            </div>--%>
            <div class="rsi_clear">
            </div>
            
             <div id="hrlogin-mh-loginform" style="height: 50px">
            </div>
            <div class="hrlogin-level" style="width: 109px">
                <asp:Label ID="Label1" Font-Names="Museo500" Font-Size="19px" runat="server" Text="HR Login" Font-Bold="true" ForeColor="Black"></asp:Label>
            </div>
            <div class="hrlogin-level" style="width: 70px">
                <table width="100%">
                    <tr>
                        <td align="right" style="width: 90%">
                            <asp:Label ID="lblmsg" Font-Size="Medium" runat="server" Width="197px" Height="25px"
                                Font-Bold="false" ForeColor="Black"></asp:Label>
                        </td>
                        <td style="width: 10%">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="rsi_clear">
            </div>
            <div class="hrlogin-level" style="width: 90px">
                <label for="LoginID">
                    Login ID :</label></div>
            <div>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtHRid" Style="font: 12px Museo300" Width="193px" Height="25px"
                    runat="server" BorderWidth="0px">
                    
                   
                </asp:TextBox>
            </div>
            <div class="rsi_clear">
            </div>
            <div class="hrlogin-level" style="width: 95px">
                <label for="Password">
                    Password :</label></div>
            <div class="hrlogin-input" style="border: 0">
                <asp:TextBox ID="txtHRpwd" runat="server" Width="193px" Height="25px" TextMode="Password"
                    BorderWidth="0px" MaxLength="5"></asp:TextBox>
            </div>
            <div class="rsi_clear">
            </div>
            <div id="rsi-next2" style="width: 50px">
                <asp:ImageButton ID="btnHRlogin" runat="server" Height="26px" ImageUrl="~/images/Login-button.jpg"
                    OnClick="HRloginButton_Click" Width="78px" />
            </div>
        </div>
        <!-- End of Login-form -->
    </div>
    <!-- End of Login-container -->
    <div style="padding-left: 11.5%">
        <p>
            Copyright &copy; MahindraHolidays 2013</p>
    </div>
    </form>
    <!--Rsi Container-->
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateLogin.aspx.cs" MaintainScrollPositionOnPostback="true" EnableEventValidation="false"
    Inherits="Exam.HRLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <meta http-equiv="expires" content="-1" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <title>Candidate Detail Page</title>
    <link href="../css/styleCandidate.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        window.history.forward(1);
    </script>

</head>
<body onload="history.go(1);">
    <div id="login-container">
        <div class="rsi_header rsi_header_image">
        </div>
        <div class="rsi_clear">
        </div>
        <div id="candidate-mh-container">
            
            <div id="candidate-mh-welcome">
                <p class="candidate-welcome-cand">
                    <strong>Welcome Candidate!</strong></p>
            
            </div>
            
            <div id="candidate-mh-login-container">
                <div id="candidate-mh-loginform">
                    <form id="form1" runat="server">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="candidate-level">
                        <label for="FirstName">
                            First Name :</label></div>
                    <div class="candidate-input">
                        <asp:TextBox ID="txtfirstname" runat="server" CssClass="candidate-input" Font-Names="Museo300"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtfirstname"
                            ForeColor="Red" ToolTip="" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="LastName">
                            Last Name :</label></div>
                    <div class="candidate-input">
                        <asp:TextBox ID="txtlastname" runat="server" Font-Names="Museo300"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtlastname"
                            ForeColor="Red" ToolTip="" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="Mobile">
                            Mobile :</label></div>
                    <div class="candidate-input">
                        <asp:TextBox ID="txtmobile" runat="server" Font-Names="Museo300" MaxLength="10" ToolTip="9999999999"></asp:TextBox>
                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmobile"
                            ForeColor="Red" ToolTip="" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="Email">
                            Email :</label></div>
                    <div class="candidate-input">
                        <asp:TextBox ID="txtEmail" runat="server" Font-Names="Museo300" ToolTip="abc@xxxx.com"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            ForeColor="Red" ToolTip="" Display="Dynamic">*</asp:RequiredFieldValidator>
                       
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="PanNo">
                            Pan No :</label></div>
                    <div class="candidate-input">
                        <asp:TextBox ID="txtpanno" runat="server" Font-Names="Museo300" MaxLength="12" ToolTip="ABCD1234"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpanno"
                            ForeColor="Red" ToolTip="" Display="Dynamic">*</asp:RequiredFieldValidator>
                       
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="Location">
                            Location :</label></div>
                    <div class="candidate-input">
                        <asp:DropDownList ID="ddllocation" runat="server" Font-Names="Museo300"> 
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="Position">
                            Position :</label></div>
                    <div class="candidate-input">
                        <asp:DropDownList ID="ddlposition" runat="server" Font-Names="Museo300">
                        </asp:DropDownList>
                    </div>
                    <br/>
                    
                      
                    <div class="candidate-level" >
                        <label for="Location">
                            Date of Birth :</label></div>
                    <div>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:DropDownList ID="ddlday" style="border:0" Font-Names="Museo300" runat="server" CssClass="candidate-DOB-date" Width="50px">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                         <asp:DropDownList ID="ddldobmonth"  style="border:0" Font-Names="Museo300" runat="server" CssClass="candidate-DOB-month"
                            Width="50px">
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:TextBox ID="txtyear" runat="server" Width="120px" Font-Names="Museo300" MaxLength="4" AutoPostBack="false"
                            Text="YYYY" ToolTip="Year YYYY Format" OnTextChanged="txtyear_TextChanged" CssClass="candidate-DOB-year"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtyear"
                            ForeColor="Red" ToolTip="" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    
               
                    <div class="candidate-level" style="width:120px">
                        <label for="Qualification">
                            Highest Qualification :</label>
                    </div>
                    <div class="candidate-input">
                        <asp:DropDownList ID="ddlQualification" Font-Names="Museo300" runat="server" Width="93%">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="candidate-level">
                        <label for="Experience">
                            Total Experience :</label></div>
                    <div class="candidate-input">
                        <asp:DropDownList ID="ddlExpeience" runat="server" Font-Names="Museo300" Width="93%" AutoPostBack="false">
                        </asp:DropDownList>
                    </div>
                    <br />
                    
                    <div class="voluntary">
                        <div class="vol-input">
                            <asp:CheckBox ID="chkdeclaration" runat="server" Text="" AutoPostBack="false" /></div>
                        <div class="voluntary-text">
                            I Voluntarily agree to undergo psychometic testing
                            <br>
                            which is a mandatory assignment as part of the
                            <br>
                            selection process of Mahindra Holidays &amp;
                            <br>
                            Resorts India Limited</div>
                    </div>
                    <div id="rsi-next1">
                        <asp:ImageButton ID="BtnLogin" runat="server" Enabled="true" ImageUrl="~/images/Login-button.jpg"
                            OnClick="BtnLogin_Click" />
                        &nbsp;&nbsp;
                    </div>
                    <br />
                    
                    </form>
                </div>
                <!-- End of Login-form -->
            </div>
            <!-- End of Login-container -->
        </div>
        <div id="footer">
            <p>
                Copyright &copy; MahindraHolidays 2013</p>
            <!-- End of footer -->
        </div>
    </div>
    <!-- End of page container -->
</body>
</html>

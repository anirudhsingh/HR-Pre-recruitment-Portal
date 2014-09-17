<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAF.aspx.cs" Inherits="Exam.CAF" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="expires" content="-1" />
    <meta http-equiv="Cache-Control" content="no-cache" />
     <meta http-equiv="Pragma" content="no-cache" />
    <link href="../css/style_New.css" rel="stylesheet" type="text/css" />
    <title>Mahindra Holiday Candidate Aptitude Form Page</title>
    <style type="text/css">
        window.history.forward(1);
        .style1
        {
            width: 410px;
        }
    </style>
</head>
<body onload="history.go(1);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div id="rsi-container">
        <%--<div id="rsi-welcome-user">Welcome User!</div>--%>
        <div class="rsi_header rsi_header_image">
            <div class="header_content">
               
               <table width="100%">
               <tr>
               <td style="width:3%"></td>
               
               <td style="width:40%" align="left"> Candidate Aptitude Forms</td>
               <td style="width:56%" align="right"><asp:Label ID="lblCandidateDetails" runat="server" Font-Size="Medium" Text="" Font-Bold="false" ForeColor="#0D9DDB"></asp:Label>
                            
               </td>
               <td style="width:1%" ></td>
               </tr>
               </table>
               
                 
                
                </div>
               
        </div>
        <asp:UpdatePanel ID="UpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                         <td style="width:30%">
                        </td>
                         <td style="width:30%">
                        </td>
                        
                        <td style="width:20%" align="right">
                        
                            
                        </td>
                         <td style="width:5%">
                        </td>
                    <%--</tr>
                        <td style="width:100%" colspan="3" align="right">
                            <asp:Label ID="Label312" runat="server" Text="fffffffffffffffff" Font-Bold="True" ForeColor="Blue"></asp:Label>
                        </td>
                    <tr>--%>
                    
                    </tr>
                </table>
                <div id="mhrsi-content">
                    <!--rsimenu-->
                    <div class="rsiquestion_text">
                      <div class="heading">
                            
                         <table>
                         <tr>
                         <td>
                         CAF Instructions
                         </td>
                         
                         <td align="right">
                         <asp:Label ID="lblTimeleft" runat="server" Text="" Font-Size="Medium" Font-Bold="True" ForeColor="#FF9E1B"></asp:Label>
                         </td>
                         </tr>
                         </table>
                         
                         </div>
                    </div>
                    
                    
                    <div>
                        <div>
                            <table>
                                <tr>
                                    
                                    <td style="width:35%">
                                        <asp:Label ID="lblmsg" runat="server" Width="640px" Font-Bold="True" ForeColor="Black"
                                            Height="16px"></asp:Label>
                                    </td>
                                   
                                    
                                </tr>
                                <tr>
                               
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                       </td>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<div id="caf-question-container">--%>
                                            <div>
                                                <div class="rsiquestion_text">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center" width="7%">
                                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("QNo") %>' Font-Bold="true" />
                                                            </td>
                                                            <td width="89%" colspan="2">
                                                                <%-- <div id="caf-question-container">

       <div class="caf-question-text">--%>
                                                                <p>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Q1") %>' Font-Bold="true" />
                                                                </p>
                                                                <br></br>
                                                                <p>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Q2") %>' Font-Bold="true" /></p>
                                                                <p>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("strImageURL") %>' Visible='<%#Eval("IsImageURL") %>' /></p>
                                                                <br></br>
                                                                <%--<div class="radio">--%>
                                                                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" GroupName="ge"
                                                                    Text='<%#Eval("A1") %>' />
                                                                <br></br>
                                                                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="true" GroupName="ge"
                                                                    Text='<%#Eval("A2") %>' />
                                                                <br></br>
                                                                <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="true" GroupName="ge"
                                                                    Text='<%#Eval("A3") %>' />
                                                                <br></br>
                                                                <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="true" GroupName="ge"
                                                                    Text='<%#Eval("A4") %>' />
                                                                    </td>
                                                                    <td width="4%">
                                                                    </td>
                                                                    </tr>
                                                                    </table>
                                                                <%-- </div>--%>
                                                </div>
                                            </div>
                                            </td>
                                            <td width="40%">
                                            </td>
                                            </tr> </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    
                                 
                                    <td>
                                        <asp:Image ID="Image2" runat="server" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <table>
                                        <tr>
                                            <td width="7%">
                                            </td>
                                           <%-- <td align="left" width="12%">
                                                <asp:ImageButton ID="lbtnPrev" runat="server" ImageUrl="~/images/Back-button.jpg"
                                                    OnClick="ImageButton2_Click1" Visible="true" />
                                   
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    
                                            </td>
                                           
                                            <td align="left" width="25%">
                                             
                                                <asp:ImageButton ID="lbtnNext" runat="server" ImageUrl="~/images/Next-button.jpg"
                                                    OnClick="ImageButton3_Click1" Visible="true" />
                                            </td>--%>
                                            <td width="5%">
                                            </td>
                                            <td width="20%">
                                            </td>
                                            <td align="right" width="10%">
                                                
                                            </td>
                                            <td width="18%">
                                            </td>
                                            
                                        </tr>
                                        <%--<tr>
                                        <td colspan="7" align="center" width="100%">
                                      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Submit-button.jpg"
                                                    OnClick="ImageButton1_Click1" Visible="true" />
                                            </td>
                                        </tr>--%>
                                    </table>
                                    
                                    <%--         <td class="style1">
 
        <asp:LinkButton ID="lbtnPrev" runat="server" onclick="lbtnPrev_Click" 
            Font-Names="Tahoma" Font-Size="Medium">Prev</asp:LinkButton>
    <asp:LinkButton ID="lbtnNext" runat="server" onclick="lbtnNext_Click" Font-Names="Tahoma" Font-Size="Medium">Next</asp:LinkButton>
 
                            </td>--%>
                                    <td>
                                        <%-- <asp:ImageButton ID="ImageButton1" runat="server" 
                                    ImageUrl="~/images/Submit-button.jpg" onclick="ImageButton1_Click1" 
                                    Visible="true" />--%>
                                    </td>
                                </tr>
                               
                            </table>
                            <table>
                                <tr>
                                <td style="width:7%">
                                
                                </td>
                                     <td align="right" >
                                     

                                               <asp:LinkButton ID="linkprev" runat="server"  OnClick="BtnPrevious_Click1" Visible="true">
                                                <asp:Image ID="imgprev" runat="server" ImageUrl="~/images/Back-button.jpg"/>
                                                </asp:LinkButton> &nbsp;&nbsp;                                       
                                     
                                                 <asp:LinkButton ID="linknxt" runat="server" OnClick="BtnNext_Click1" Visible="true">
                                                  <asp:Image ID="imgnxt" runat="server" ImageUrl="~/images/Next-button.jpg" />
                                                  </asp:LinkButton>  &nbsp;&nbsp;  
                                     
                                               <!-- <asp:ImageButton ID="BtnPrevious" runat="server" ImageUrl="~/images/Back-button.jpg"
                                                    OnClick="BtnPrevious_Click1" Visible="true" /> &nbsp;&nbsp;
                                                   
                                                <asp:ImageButton ID="BtnNext" runat="server" ImageUrl="~/images/Next-button.jpg"
                                                    OnClick="BtnNext_Click1" Visible="true" />  &nbsp;&nbsp;
                                                    
                                            <!-- <asp:ImageButton ID="BtnSubmit1" runat="server"  ImageUrl="~/images/Submit-button.jpg"
                                                     OnClick="BtnSubmit_Click1" Visible="false" />-->
                                                   
                                            </td>
                                           
                                         <td align="left">
                                             
                                               <%-- <asp:ImageButton ID="lbtnNext" runat="server" ImageUrl="~/images/Next-button.jpg"
                                                    OnClick="ImageButton3_Click1" Visible="true" />--%>
                                            </td>
                                </tr>
                                
                                    <tr>
                                 <td colspan="3">
                                 
                                 </td>
                                 
                                 
                                 </tr>
                                 
                                <!-- <tr>
                                 <td colspan="3">
                                 
                                 </td>
                                 
                                 
                                 </tr>-->
                                  <tr>
                                  <td width="7%"></td>
                                        <td  align="right" width="100%" colspan="2">
                                        
                                        <asp:LinkButton ID="LnkSubmit" runat="server"  OnClick="BtnSubmit_Click1"
                                        Visible="false" style="position:relative;right:15px;top:5px;">
                                        <asp:Image ID="imgSubmit" runat="server" ImageUrl="~/images/Submit-button.jpg" />           
                                                    </asp:LinkButton>
                                      <!--<asp:ImageButton ID="BtnSubmit" runat="server"  ImageUrl="~/images/Submit-button.jpg"
                                                    OnClick="BtnSubmit_Click1" Visible="false"  style="position:relative;right:15px;top:5px;"/>-->
                                            </td>
                                        </tr>
                            </table>
                        </div>
                    </div>    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
                    
                
        
        
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Timer ID="TimeLeftForCAFTest" runat="server" OnTick="TimeLeftForCAFTest_Tick" Interval="1000">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        
         <div style="padding-left:11.5%">
            <p>
             Copyright &copy; MahindraHolidays 2013</p>
        </div>
        
        
    </form>
</body>
</html>

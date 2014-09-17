<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PSI.aspx.cs" Inherits="Exam.PSI" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="expires" content="-1" />
    <meta http-equiv="Cache-Control" content="no-cache" />
     <meta http-equiv="Pragma" content="no-cache" />
    <meta name="description" content="" />
    <meta name="keywords" content="" />
    <title>Mahindra Holiday PSI Page</title>

    
    <link href="../css/Stylesheet_PSI.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        window.history.forward(1);
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 486px;
        }
        .style2
        {
            height: 343px;
        }
        .style3
        {
            height: 1px;
        }
        .style4
        {
            height: 48px;
        }
        .cssPager td
        {
            padding-left: 4px;
            padding-right: 4px;
            padding-top: 4px;
        }
    </style>
</head>
<body onload="history.go(1);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="rsi-container">
        <div class="rsi_header rsi_header_image">
            <div class="header_content">
            <table width="100%">
               <tr>
               <td style="width:3%"></td>
               
               <td style="width:20%" align="left"> PSI Instrument</td>
               <td style="width:70%" align="right"><asp:Label ID="lblCandidateDetails" Font-Size="Medium" runat="server" Text="" Font-Bold="false" ForeColor="#0D9DDB"></asp:Label>
                            
               </td>
               <td style="width:7%" ></td>
               </tr>
               </table>
               
            
            
                </div>
        </div>
       <%-- <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td width="30%">
                </td>
                <td width="30%">
                </td>
                <td width="40%">
                    <asp:Label ID="lblCandidateDetails" runat="server" Text="Welcome Rupali asdsjahhsfkadsjah" Font-Bold="false" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
        </table>--%>
        <div class="rsi_clear">
        </div>
        <div class="rsiquestion_text">
            <div class="heading">
                What to do on this test.</div>
            <div class="desc">
                <p style="width: 92%">
                    The following items are arranged in pairs (‘a’ and ‘b’) and each member of the pair
                    represents a preference you may or may not hold. Rate your preference for each item,
                    by giving it a score on a scale ranging from 0 to 5. (For example, 0 meaning you
                    really feel negative about it or strongly about the other member of the pair, and
                    5 meaning you strongly prefer it or do not prefer the other member of the pair).
                    The scores for ‘a’ and ‘b’ must add up to 5. For example: 0 and 5, or 1 and 4, or
                    2 and 3, etc.) Do not use fractions such as 2.5.
                </p>
            </div>
        </div>
        <div class="rsi_clear">
        </div>
        <div id="mhrsi-content">
            <div id="rsi-question-container">
                <%-- <div class="question-container bgcol">--%>
                <div>
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblmsg" runat="server" Width="640px" Font-Bold="True" ForeColor="Black"
                                    Height="16px"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <%--<td style="width:3%">
                            </td>--%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <td colspan="2" align="left" style="height: 100%;width:97%" >
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            Font-Names="Museo300" Font-Size="Medium" ShowHeader="False" BorderColor="Black"
                                            BackColor="White" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True"
                                            OnPageIndexChanging="GridView1_PageIndexChanging" RowStyle-VerticalAlign="Middle"
                                            PageSize="16" OnDataBinding="GridView1_DataBinding" OnDataBound="GridView1_DataBound"
                                            OnPreRender="GridView1_PreRender" Height="550px" Width="100%">
                                            <PagerStyle CssClass="cssPager" />
                                            <PagerSettings Mode="NextPrevious" FirstPageText="" LastPageText="" NextPageImageUrl="~/images/Next-button.jpg"
                                                NextPageText="&gt;" PreviousPageImageUrl="~/images/Back-button.jpg" PreviousPageText="&lt;" />
                                         
                                            <PagerStyle VerticalAlign="Top" HorizontalAlign="Right" />
                                            <RowStyle VerticalAlign="Middle"></RowStyle>
                                            <Columns>
                                                <asp:BoundField HeaderText="SRNO" DataField="ID" Visible="False" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle Width="100px"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="QuestionNo" DataField="QuestionNo" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="40" HeaderImageUrl="~/images/Number-bg.png">
                                                    <ItemStyle Width="60px"></ItemStyle>
                                                    <%--<ItemStyle Width="60px" CssClass="question-container bgcol"></ItemStyle>--%>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Quesstate" DataField="Question" ItemStyle-HorizontalAlign="Justify">
                                                    <ItemStyle HorizontalAlign="Justify"></ItemStyle>
                                                    <%--<ItemStyle HorizontalAlign="Justify" CssClass="question-container bgcol"></ItemStyle>--%>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Grade" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <div style="text-align: center;">
                                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%#  
                    Bind("Grade") %>' Style="text-align: center" Font-Names="Museo300" Font-Bold="True" Height="19px" Width="22px" MaxLength="1" OnTextChanged="TextBox2_TextChanged"
                                                                AutoPostBack="true" AutoCompleteType="none"></asp:TextBox>                                                                
                                                            <br />    
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"
        ValidationExpression="^[0-5]*$" ></asp:RegularExpressionValidator>                                                        
                                                        </div>                                                        
                                                    </ItemTemplate>
                                                  
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="QuestionGrade" HeaderText="OriGrade" />
                                            </Columns>
                                            <EditRowStyle BorderStyle="None" />
                                        </asp:GridView>
                          
                                    </td>
                                    
                                    
                                    <td valign="bottom" style="width:3%">
                                       
                                    </td>
                                    
                                    <triggers>
                                 <asp:AsyncPostBackTrigger ControlID="textbox2" EventName="TextChanged" />
                                </triggers>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </tr>
                       <tr>
                            <td colspan="2" align="right">
                                <asp:ImageButton ID="ImageButton1" CssClass="shift" runat="server" ImageUrl="~/images/Submit-button.jpg"
                                    OnClick="ImageButton1_Click1" Visible="false" />&nbsp;&nbsp;<br />
                            </td>
                            <td style="width: 130px">
                            </td>
                        </tr>
                    </table>
                </div>
                <!--end of RSI question container--->
            </div>
            <!--end of mhrsi-content--->
        </div>
        <!--end of rsi-container--->
        <%--</table>--%>
    </div>
    <!--end of RSI question container-->
    <%--</div>--%>
    <!--end of mhrsi-content-->
    <!--<div id="rsi-next"><a href=""><img src="images/Next-button.jpg" alt="Next" /></a></div>-->
    <!--<div id="rsi-back"><a href=""><img src="images/Back-button.jpg" alt="Back" /></a></div>-->
   <%-- </div>--%>
    <!--Rsi Container-->
    <%--<div id="rsi-footer">
        <p>
            Copyright © MahindraHolidays 2013
        </p>
    </div>--%>
    
    <div style="padding-left:11.5%">
            <p>
             Copyright &copy; MahindraHolidays 2013</p>
        </div>
        
        
    <!--end of Footer-->
    </form>
</body>
</html>

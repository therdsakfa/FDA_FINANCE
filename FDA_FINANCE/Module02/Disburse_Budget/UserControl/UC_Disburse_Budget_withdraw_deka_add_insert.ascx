<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_withdraw_deka_add_insert.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_withdraw_deka_add_insert" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="หน้าฏีกา">
    <table width="100%">
        <tr>
            <td style="width: 65%">
                <table width="100%">
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">วันที่ทำฏีกา :</td>
                        <td style="width: 80%">
                            <asp:TextBox ID="txt_deka_date" runat="server" Height="30px" Width="30%"></asp:TextBox>
                        </td>
                    </tr>
                       <tr>
                        <td align="right" style="width: 20%">ประเภทฏีกา :</td>
                        <td style="width: 80%">
                              <asp:DropDownList ID="dd_typeDeka" runat="server" AutoPostBack="true" DataValueField="ID" DataTextField="TypePay_Deka_Name" Height="30px" Width="40%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" style="width: 20%">เลขที่ฏีกา :</td>
                        <td style="width: 80%">
                       <asp:TextBox ID="txt_DekaNum" runat="server" Height="30px" Width="30%" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">ชื่อผู้เบิก :</td>
                        <td style="width: 80%">
                            <asp:DropDownList ID="dd_disburse_Name" runat="server" Height="30px" Width="90%" DataValueField="IDA" DataTextField="Name_Disburse">

                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <table width="100%">
                    <tr>
                        <td align="right" style="width: 20%">ประเภทการเบิก : </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="dd_payW" runat="server" DataValueField="ID" DataTextField="BG_TypeMoneyW" Height="30px" Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%">ที่คลังรับใบกันเงิน :          
                        </td>
                        <td style="width: 30%">
                            <asp:TextBox ID="txt_treasury" runat="server" Height="30px" Width="75%" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">ประจำเดือน : </td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="dd_month" runat="server" DataValueField="Month_number" DataTextField="Month_name" Height="30px" Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 20%">งบประมาณปี :
                        </td>
                        <td style="width: 20%">
                                 <asp:DropDownList ID="ddl_year" runat="server" DataValueField="BUDGET_PLAN_ID" DataTextField="BUDGET_DESCRIPTION" Height="30px" Width="75%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <table width="100%">
                    <tr>
                        <td align="right" style="width: 20%">หมวดงบ : </td>

                        <td style="width: 80%">
                              <asp:DropDownList ID="ddl_BudgetGroup" runat="server" Height="30px" Width="40%">
                        <asp:ListItem Value="1">งบดำเนินงาน</asp:ListItem>
                        <asp:ListItem Value="2">งบเงินอุดหนุน</asp:ListItem>
                        <asp:ListItem Value="3">งบบุคลากร</asp:ListItem>
                        <asp:ListItem Value="4">งบรายจ่ายอื่น</asp:ListItem>
                        <asp:ListItem Value="5">งบลงทุน</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">แผนงาน : </td>

                        <td style="width: 80%">
                            <asp:DropDownList ID="ddl_plan" runat="server" Height="30px" Width="90%"  AutoPostBack="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">ผลผลิต : </td>

                        <td style="width: 80%">
                             <asp:DropDownList ID="ddl_product" runat="server" Height="30px" Width="90%" AutoPostBack="True">
                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">กิจกรรม : </td>

                        <td style="width: 80%">
                                <asp:DropDownList ID="ddl_act" runat="server" Height="30px" Width="90%" AutoPostBack="True">
                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">ประเภทการจ่าย : </td>

                        <td style="width: 80%">
                            <asp:DropDownList ID="dd_pay" runat="server" DataValueField="ID" DataTextField="BG_PayTypeName" Height="30px" Width="30%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">ชื่อธนาคาร : </td>

                        <td style="width: 80%">
                            <asp:DropDownList ID="dd_Bank" runat="server" DataValueField="BANK_ID" DataTextField="BANK_NAME" Height="30px" Width="30%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <table width="100%">
                    <tr>
                        <td align="right" style="width: 20%">ชื่อบัญชี : </td>
                        <td style="width: 80%">
                            <asp:DropDownList ID="dd_Account" runat="server"  DataValueField="IDA" DataTextField="ACCOUNTNAME"  Height="30px" Width="90%" AutoPostBack="true">

                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                </table>
                             <table width="100%">
                    <tr>
        
                        <td  align="right"  style="width: 20%">เลขที่บัญชี :</td>
                        <td style="width: 80%">
                            <asp:TextBox ID="txt_BankAccount" runat="server" Height="30px" Width="35%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    
                </table>

            </td>
            <td style="width: 35%"  >
                <table width="100%"  >
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">เงินขอเบิก :</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txt_Amount" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 50%">ภาษีเงินได้บุคคลธรรมดา :</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txt_Vat" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" style="width: 50%">ภาษีเงินได้นิติบุคคล :</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txt_Tax" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" style="width: 50%">ค่าปรับ :</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txt_Mulct" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" style="width: 50%">เงินขอรับ :</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txt_RecAmount" runat="server" Height="30px" Width="90%" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
    </table>

  <%--  <table width="100%" >
    <tr>
        <td>
            <br /><br />
        </td>
    </tr>
    <tr align="center">
       <td>
            <asp:Button ID="bt_save" runat="server"  Height="35px" Width="11%"  Text="บันทึกฏีกา"/>
        </td>
    </tr>
     <tr>
        <td>
            <br /> 
        </td>
    </tr>
</table>--%>

</asp:Panel>

<br /><br />



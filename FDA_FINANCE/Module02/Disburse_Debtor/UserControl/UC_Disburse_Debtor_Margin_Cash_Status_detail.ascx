<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Margin_Cash_Status_detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Margin_Cash_Status_detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<br />

<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel2" runat="server" Width ="100%" GroupingText ="การอนุมัติพร้อมจ่าย" Enabled="false">
<table>
   <tr>
       <td align="right">
           สถานะเช็คพร้อมจ่าย :
       </td>
       <td>
           <asp:CheckBox ID="cb_is_check_ready" runat="server" />
       </td>
       <td align="right"> วันที่อนุมัติพร้อมจ่าย :</td>
        <td>
            <asp:TextBox ID="txt_Check_ready_date" runat="server"></asp:TextBox>
        </td>
   </tr>
</table>
</asp:Panel>
    </div>

<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel1" runat="server" Width ="100%" GroupingText ="บันทึกการจ่ายเงิน" >
<table>
    <tr>
          <td align="right">จ่าย : </td>
        <td>
            <asp:CheckBox ID="cb_pay" runat="server" />
        </td>
        <td align="right">วันที่จ่าย : </td>
        <td>
            <asp:TextBox ID="txt_PAY_DATE" runat="server"></asp:TextBox>
        </td>
         <td align="right">วันที่ครบกำหนดคืน : </td>
        <td>
            <asp:TextBox ID="txt_return_date" runat="server"></asp:TextBox>
        </td>
    </tr>

</table>
</asp:Panel>
    </div>
    <%--<asp:Panel ID="Panel2" runat="server" Width ="900px" GroupingText ="การวางเบิก" Enabled="false">
<table>
<tr>
        <td align="right">วางเบิก : </td>
        <td>
            <asp:RadioButtonList ID="rd_Rebill" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">วางเบิก</asp:ListItem>
                <asp:ListItem Value="2">ไม่วางเบิก</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="right"></td>
        <td>
            
        </td>
    </tr>
   
</table>
</asp:Panel>--%>
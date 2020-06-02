<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_MoneyType_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_MoneyType_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td align="right" style="width:160px">ประเภทเงิน : </td>
        <td>
            <asp:TextBox ID="txt_MONEY_TYPE_DESCRIPTION" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
   <%-- <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            
            <telerik:RadNumericTextBox ID="rnt_MONEY_AMOUNT" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox>
            &nbsp; บาท
        </td>
    </tr>--%>
</table>
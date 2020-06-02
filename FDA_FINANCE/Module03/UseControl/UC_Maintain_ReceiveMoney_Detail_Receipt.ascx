<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReceiveMoney_Detail_Receipt.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReceiveMoney_Detail_Receipt" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table  width="900px">
    <tr>
        <td align="right">ใบเสร็จเล่มที่ : </td>
        <td>
            <asp:TextBox ID="txt_RECEIPT_VOLUME" runat="server" class="validate[required] text-input"></asp:TextBox>
            <%--<telerik:RadNumericTextBox ID="txt_RECEIPT_VOLUME" runat="server"></telerik:RadNumericTextBox>--%>
        </td>
        <td align="right">ใบเสร็จเลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_RECEIPT_NUMBER" runat="server" class="validate[required] text-input"></asp:TextBox>
            <%--<telerik:RadNumericTextBox ID="txt_RECEIPT_NUMBER" runat="server"></telerik:RadNumericTextBox>--%>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่รับเงิน : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_MONEY_RECEIVE_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_MONEY_RECEIVE_DATE" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
</table>
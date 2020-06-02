<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_Deposit_Balance_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_Deposit_Balance_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table>
    <tr>
        <td align="right">วันที่บันทึก : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_DEPOSIT_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_date_save" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่บัญชีเงินทดรอง : </td>
        <td>
            <%--<asp:TextBox ID="txt_RECEIPT_VOLUME" runat="server"></asp:TextBox>--%>
            <asp:TextBox ID="txt_ACCOUNT_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงินคงเหลือตามบัญชีเงินฝาก : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_ACCOUNT_BALANCE_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox></td>
    </tr>
    <tr>
        <td align="right">เลขที่เช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
           
            <telerik:RadNumericTextBox ID="rnt_CHECK_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ดอกเบี้ย : </td>
        <td>
    <telerik:RadNumericTextBox ID="rnt_INTEREST_AMOUNT" Runat="server">
            </telerik:RadNumericTextBox>
        </td>
    </tr>
    
</table>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_MoneyType_Information_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_MoneyType_Information_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="500px">
    <tr>
        <td align="right">
            ประเภทเงิน : 
        </td>
        <td>
            <asp:Label ID="lb_money_type_name" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงินยอดยกมา :</td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_MONEY_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox> &nbsp;บาท
        </td>
    </tr>
</table>
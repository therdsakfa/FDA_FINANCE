<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Type_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Type_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td>ชื่อประเภทงบประมาณ : </td>
        <td>
            <asp:TextBox ID="txt_BUDGET_TYPE_NAME" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>จำนวนเงิน : </td>
        <td>
            <telerik:RadNumericTextBox ID="rnt_BUDGET_TYPE_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
            &nbsp; บาท
        </td>
    </tr>
</table>
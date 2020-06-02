<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Salary_List_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Salary_List_Detail" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table>
    <tr>
        <td align="right">รายรับ/รายจ่าย :</td>
        <td>
            <asp:DropDownList ID="ddlSALARY_PAYLIST" runat="server" DataTextField="SALARY_PAYLIST_NAME"
                DataValueField="SALARY_PAYLIST_ID"></asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน :</td>
        <td>
            <telerik:RadNumericTextBox ID="rntAmount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:RadNumericTextBox> &nbsp; บาท
        </td>
    </tr>
</table>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_CarryMoney_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_CarryMoney_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table>
<tr>
    <td align="right">หน่วยงาน :</td>
    <td>
        
    </td>
</tr>
<tr>
<td align="right">
งบประมาณ :
</td>
</tr>
<tr>
<td>จำนวนเงิน</td>
<td>
    <asp:TextBox ID="txt_OVERLAP_AMOUNT" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">วันที่ :</td>
<td>
    <telerik:RadDatePicker ID="rdp_OVERLAP_HEAD_DOC_DATE" runat="server">
    </telerik:RadDatePicker>
</td>
</tr>
</table>
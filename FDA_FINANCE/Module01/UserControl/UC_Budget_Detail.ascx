<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Detail" %>
<table>
<tr>
<td align="right">
หน่วยงาน :
</td>
<td>
    <asp:TextBox ID="txt_DEPARTMENT_DESCRIPTION" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
จำนวนเงิน : 
</td>
<td>
    <asp:TextBox ID="txt_BUDGET_DEPARTMENT_MONEY" runat="server"></asp:TextBox>
</td>
</tr>
</table>
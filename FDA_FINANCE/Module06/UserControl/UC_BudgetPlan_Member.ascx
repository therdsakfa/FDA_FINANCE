<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BudgetPlan_Member.ascx.vb" Inherits="FDA_FINANCE.UC_BudgetPlan_Member" %>
<%@ Register assembly="Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table width="450px">
<%--<tr>
<td align="right">
    <asp:Button ID="btnAdd" runat="server" Text="เพิ่มข้อมูล" />
</td>
</tr>--%>
<tr>
<td>
    <telerik:radgrid ID="rgBudgetmember" runat="server" AutoGenerateColumns="false">
    </telerik:radgrid>
</td>
</tr>
</table>
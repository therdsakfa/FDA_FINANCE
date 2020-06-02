<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget.ascx.vb" Inherits="FDA_FINANCE.UC_Budget" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table>
<tr>
<td>
    <telerik:RadTreeView ID="rtvBudgetPlan" runat="server">
    </telerik:RadTreeView>
</td>
<td>
    <table>
        <tr>
            <td>รายละเอียด</td>
            
            
        </tr>
        <tr>
        <td><asp:TextBox ID="txt_BudgetHead" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
        <td><asp:TextBox ID="txt_Child1" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
        <td><asp:TextBox ID="txt_Child2" runat="server"></asp:TextBox></td>
            
        </tr>
        <tr>
        <td>งบประมาณ : <asp:TextBox ID="txt_Amount" runat="server" /></td>
        </tr>
    </table>
</td>
</tr>
<tr>
<td></td>
<td>
    <table width="100%">
        <tr>
            <td>งบจัดสรร</td>
        </tr>
        <tr>
            <telerik:RadGrid ID="rgBudget" runat="server" AutoGenerateColumns="false">
            </telerik:RadGrid>
        </tr>
    </table>
</td>
</tr>
</table>
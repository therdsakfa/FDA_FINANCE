<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budgetplan_Detail_Type7.ascx.vb" Inherits="FDA_FINANCE.UC_Budgetplan_Detail_Type7" %>
<table>
    <tr>
        <td align="right">
            <asp:Label ID="lb_budget_code" runat="server" Visible="false" Text="รหัสโครงการ"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txt_budget_code" runat="server" Visible="false"></asp:TextBox>
        </td>
    </tr>
<tr>
    <td align="right">
        <asp:Label ID="lb_budget" runat="server"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="dd_type_7" runat="server" DataTextField="BG_DESCRIPTION" DataValueField="BG_DESCRIPTION">
        </asp:DropDownList>
    </td>
</tr>
</table>
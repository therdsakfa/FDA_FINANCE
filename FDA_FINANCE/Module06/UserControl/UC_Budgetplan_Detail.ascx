<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budgetplan_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budgetplan_Detail" %>
<table>
<%--<tr>
<td align="right">
         
    <asp:Label ID="lb_BudgetType" runat="server" Visible="false" Text="ประเภทข้อมูล :"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="dd_BUDGET_TYPE" runat="server" Visible="false" DataTextField="BUDGET_TYPE_NAME" DataValueField="BUDGET_TYPE_ID">
           
        </asp:DropDownList>
    </td>
</tr>--%>
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
        <asp:TextBox ID="txt_BUDGET_DESCRIPTION" runat="server" class="validate[required] text-input" TextMode="MultiLine" Width="400px" Height="60px"></asp:TextBox>
        <asp:DropDownList ID="dd_type_6" runat="server" style="display:none;">
            <asp:ListItem Value="1">งบดำเนินงาน</asp:ListItem>
            <asp:ListItem Value="2">งบเงินอุดหนุน</asp:ListItem>
            <asp:ListItem Value="3">งบรายจ่ายอื่น</asp:ListItem>
            <asp:ListItem Value="4">งบบุคลากร</asp:ListItem>
            <asp:ListItem Value="5">งบลงทุน</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>
<%--<tr>
    <td align="right">
        จำนวนเงินงบประมาณ : 
    </td>
    <td>
        <asp:TextBox ID="txt_BUDGET_AMOUNT" runat="server"></asp:TextBox>
    </td>
</tr>--%>
</table>
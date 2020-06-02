<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BudgetPlan_Adjust_Information.ascx.vb" Inherits="FDA_FINANCE.UC_BudgetPlan_Adjust_Information" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="">
    <table width="100%">
    <tr>
        <td colspan="2">
            <hr/>
        </td>
    </tr>
   <%-- <tr>
        <td align="right">
            จำนวนเงินงบประมาณ :
        </td>
        <td>
            &nbsp;<asp:Label ID="lb_BudgetAmount" runat="server" Text="0.0"></asp:Label> &nbsp; บาท
        </td>
    </tr>--%>
    <tr>
        <td align="right">
            จำนวนเงินที่จัดสรรไปแล้วทั้งหมด : 
        </td>
        <td>
            &nbsp;<asp:Label ID="lb_AdjustAmount" runat="server" Text="0.0"></asp:Label> &nbsp; บาท
        </td>
    </tr>
    <%-- <tr>
        <td align="right">
            จำนวนเงินงบประมาณคงเหลือ : 
        </td>
        <td>
            &nbsp;<asp:Label ID="lb_BG_Balance" runat="server" Text="0.0"></asp:Label> &nbsp; บาท
        </td>
    </tr>--%>
</table>
</asp:Panel>

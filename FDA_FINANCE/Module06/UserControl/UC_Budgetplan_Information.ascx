<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budgetplan_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Budgetplan_Information" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
<tr>
<td>

    <telerik:RadGrid ID="rgInformation" runat="server" AutoGenerateColumns="false" 
        Width="300px">
<MasterTableView>
<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
</MasterTableView>
    </telerik:RadGrid>
</td>
</tr>
</table>
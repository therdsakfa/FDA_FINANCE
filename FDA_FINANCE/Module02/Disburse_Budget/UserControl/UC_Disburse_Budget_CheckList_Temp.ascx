<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_CheckList_Temp.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_CheckList_Temp" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgAddBudgetCheck" runat="server" 
AutoGenerateColumns="False" Width="100%" AllowMultiRowSelection="True" AllowPaging="True" CellSpacing="0" GridLines="None">
    <ClientSettings>
        <Selecting AllowRowSelect="True" />
    </ClientSettings>

</telerik:RadGrid>
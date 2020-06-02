<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Overlap_Debtor.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Overlap_Debtor" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgAddOverlapDebtor" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="900px" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
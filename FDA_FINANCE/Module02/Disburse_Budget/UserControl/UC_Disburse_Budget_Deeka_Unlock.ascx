<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_Deeka_Unlock.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_Deeka_Unlock" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_Disburse_Budget" runat="server" GridLines="None" AllowPaging="true" PageSize="10" ShowFooter="true" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" FooterStyle-HorizontalAlign="Right">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

</telerik:RadGrid>
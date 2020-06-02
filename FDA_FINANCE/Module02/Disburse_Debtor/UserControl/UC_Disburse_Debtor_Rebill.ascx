<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Rebill.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Rebill" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_Disburse_Debtor_Rebill" runat="server" GridLines="None" AllowMultiRowSelection="true" 
AutoGenerateColumns="false" Width="100%">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
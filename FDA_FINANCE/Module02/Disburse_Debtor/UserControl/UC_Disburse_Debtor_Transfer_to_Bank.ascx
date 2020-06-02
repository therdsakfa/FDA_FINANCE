<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Transfer_to_Bank.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Transfer_to_Bank" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_transfer_cus" runat="server" GridLines="None" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
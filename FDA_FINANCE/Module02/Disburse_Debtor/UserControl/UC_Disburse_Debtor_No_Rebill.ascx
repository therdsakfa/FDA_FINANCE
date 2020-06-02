<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_No_Rebill.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_No_Rebill" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_Disburse_Debtor_No_Rebill" runat="server" AutoGenerateColumns="false" Width="100%" 
    AllowMultiRowSelection="true" AllowPaging="true" PageSize="15" >
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
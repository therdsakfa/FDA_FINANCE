<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Debtor_Deposit_Receipt.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Debtor_Deposit_Receipt" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rgDebtor_deposit" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
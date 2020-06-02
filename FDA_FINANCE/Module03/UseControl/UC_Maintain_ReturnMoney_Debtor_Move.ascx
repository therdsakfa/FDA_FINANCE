<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Debtor_Move.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Debtor_Move" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rgDebtor_move" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="30" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
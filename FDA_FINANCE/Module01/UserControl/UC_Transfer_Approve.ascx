<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Transfer_Approve.ascx.vb" Inherits="FDA_FINANCE.UC_Transfer_Approve" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<telerik:RadGrid ID="rgTransferApp" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
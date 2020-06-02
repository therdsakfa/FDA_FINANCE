<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RELATE_BILL_WITH_HEAD_APPROVE.ascx.vb" Inherits="FDA_FINANCE.UC_RELATE_BILL_WITH_HEAD_APPROVE" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_relate" runat="server" GridLines="None" AllowPaging="true" PageSize="10" 
    ShowFooter="true" AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
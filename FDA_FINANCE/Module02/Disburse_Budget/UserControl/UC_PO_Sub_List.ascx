<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PO_Sub_List.ascx.vb" Inherits="FDA_FINANCE.UC_PO_Sub_List" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rg_PO_Sub_List" runat="server" GridLines="None"   AllowMultiRowSelection="true" AllowPaging="true" PageSize="10"
AutoGenerateColumns="false" Width="100%" >
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

</telerik:RadGrid>
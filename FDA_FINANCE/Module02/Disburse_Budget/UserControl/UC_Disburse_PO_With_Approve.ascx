<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_PO_With_Approve.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_PO_With_Approve" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_Disburse_PO" runat="server" GridLines="None"  
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" AllowPaging="true" PageSize="15">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

</telerik:RadGrid>
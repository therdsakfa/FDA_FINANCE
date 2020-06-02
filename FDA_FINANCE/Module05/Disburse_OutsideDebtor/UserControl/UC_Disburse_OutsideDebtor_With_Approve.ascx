<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor_With_Approve.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor_With_Approve" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rgDebtorOutside" runat="server" GridLines="None" AllowPaging="true" PageSize="10"
AutoGenerateColumns="false" Width="100%"  AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
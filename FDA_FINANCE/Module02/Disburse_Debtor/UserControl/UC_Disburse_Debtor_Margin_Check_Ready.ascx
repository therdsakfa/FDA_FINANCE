<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Margin_Check_Ready.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Margin_Check_Ready" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rg_check_ready" runat="server" GridLines="None" AllowPaging="true" PageSize="15" ShowFooter="true" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" FooterStyle-HorizontalAlign="Right">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

</telerik:RadGrid>
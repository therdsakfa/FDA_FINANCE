<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_Study_Check_Pay.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_Study_Check_Pay" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rg_check_pay" runat="server" GridLines="None" AllowPaging="true" PageSize="15" ShowFooter="true" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" FooterStyle-HorizontalAlign="Right">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

</telerik:RadGrid>
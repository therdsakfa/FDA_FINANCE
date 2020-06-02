<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Welfare.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Welfare" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_Disburse_Cure_Study" runat="server" GridLines="None" AllowPaging="true" PageSize="15" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
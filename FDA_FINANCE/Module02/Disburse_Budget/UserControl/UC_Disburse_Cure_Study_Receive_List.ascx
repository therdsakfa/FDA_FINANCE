<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_Study_Receive_List.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_Study_Receive_List" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadGrid ID="rg_Cure_Study_Receive_List" runat="server" GridLines="None" MasterTableView-PageSize="10" AllowPaging="true"  
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true">
    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>

</telerik:RadGrid>
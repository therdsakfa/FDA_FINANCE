<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_Study_Boss_Approve.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_Study_Boss_Approve" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<telerik:RadGrid ID="rgApprove" runat="server" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" >
     <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
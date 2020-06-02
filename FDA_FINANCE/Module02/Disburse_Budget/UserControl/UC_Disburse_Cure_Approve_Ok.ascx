<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_Approve_Ok.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_Approve_Ok" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<telerik:RadGrid ID="rgApprove" runat="server" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" >
     <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
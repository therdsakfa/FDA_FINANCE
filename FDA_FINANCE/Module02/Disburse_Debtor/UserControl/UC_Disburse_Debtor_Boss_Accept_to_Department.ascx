<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Boss_Accept_to_Department.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Boss_Accept_to_Department" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<telerik:RadGrid ID="rgBoss_Approve" runat="server" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" >
     <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
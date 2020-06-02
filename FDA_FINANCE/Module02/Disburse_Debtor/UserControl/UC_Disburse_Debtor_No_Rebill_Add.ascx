<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_No_Rebill_Add.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_No_Rebill_Add" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgAddRebill" runat="server" GridLines="None"  AllowMultiRowSelection="true" AllowPaging="true" PageSize="15"
AutoGenerateColumns="false" Width="100%" >
    <ClientSettings EnableRowHoverStyle="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
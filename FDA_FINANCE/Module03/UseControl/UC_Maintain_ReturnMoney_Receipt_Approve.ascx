<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Receipt_Approve.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Receipt_Approve" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgApprove" runat="server" GridLines="None"
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" AllowPaging="true" PageSize="15">
     <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Overlap_Bill.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Overlap_Bill" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgAddOverlapBill" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="900px" AllowMultiRowSelection="true" AllowPaging="true" PageSize="15">
    <ClientSettings EnableRowHoverStyle="true">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
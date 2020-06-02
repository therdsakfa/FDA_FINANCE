<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfare_Cremation_Import.ascx.vb" Inherits="FDA_FINANCE.UC_Welfare_Cremation_Import" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rgCremation" runat="server" GridLines="None" AutoGenerateColumns="false" Width="700px" 
     AllowMultiRowSelection="true" ShowFooter="true">
    <ClientSettings EnableRowHoverStyle="true">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
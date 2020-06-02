<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfare_Rebill.ascx.vb" Inherits="FDA_FINANCE.UC_Welfare_Rebill" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rg_Disburse_Wellfare" runat="server" AutoGenerateColumns="false" Width="800px">
    <ClientSettings EnableRowHoverStyle="true">
                <Selecting AllowRowSelect="True"></Selecting>
    </ClientSettings>
</telerik:RadGrid>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Bill_Status.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Bill_Status" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rgBill_status" runat="server" AutoGenerateColumns="false" Width="100%">
     <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">

    </ClientSettings>
</telerik:RadGrid>

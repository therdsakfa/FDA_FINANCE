<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Debtor_Status.ascx.vb" Inherits="FDA_FINANCE.UC_Debtor_Status" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rgDebtor_status" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true" PageSize="10">
     <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true" >

    </ClientSettings>
</telerik:RadGrid>

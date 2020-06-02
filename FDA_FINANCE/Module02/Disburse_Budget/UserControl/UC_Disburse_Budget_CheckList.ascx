<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_CheckList.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_CheckList" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgAddBudgetCheck" runat="server" 
AutoGenerateColumns="false" Width="100%" AllowMultiRowSelection="true" AllowPaging="true" PageSize="10" GridLines="None">

</telerik:RadGrid>
<asp:Label ID="L_check" runat="server" Text="" Style="display:none"></asp:Label>

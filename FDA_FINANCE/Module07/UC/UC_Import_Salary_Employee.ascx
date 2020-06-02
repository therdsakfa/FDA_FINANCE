<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Import_Salary_Employee.ascx.vb" Inherits="FDA_FINANCE.UC_Import_Salary_Employee" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="rg_import" runat="server" GridLines="None" AutoGenerateColumns="false" Width="700px" 
     AllowMultiRowSelection="true" ShowFooter="true">
    <ClientSettings EnableRowHoverStyle="true">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
</telerik:RadGrid>
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Debtor_Approve_Detail.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_Approve_Detail" %>
<%@ Register src="UserControl/UC_Disburse_Debtor_Approve_Detail.ascx" tagname="UC_Disburse_Debtor_Approve_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="../../Scripts/jquery-1.8.2.js"></script>
    

    <%--<link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> --%>
    

    

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Approve_Detail1_txt_APPROVE_DATE"));
        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText ="การอนุมัติลูกหนี้เงินยืม">
        <table>
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <uc1:UC_Disburse_Debtor_Approve_Detail ID="UC_Disburse_Debtor_Approve_Detail1" runat="server" />
            </td>
        </tr>
        <tr>
            <td aling="center">
            <asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" CssClass="btn-lg"/>
                </td>
        </tr>
    </table>
    </asp:Panel>
    
    
</asp:Content>

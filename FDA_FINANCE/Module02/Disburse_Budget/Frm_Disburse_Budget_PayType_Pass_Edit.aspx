﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_PayType_Pass_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_PayType_Pass_Edit" %>
<%@ Register src="UserControl/UC_Disburse_Budget_PayType_Pass_Detail.ascx" tagname="UC_Disburse_Budget_PayType_Pass_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <%--<script src="../../Scripts/jquery-1.7.1.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>--%>

    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <%--<link href="../../Content/bootstrap.css" rel="stylesheet" />--%>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_INVOICE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_RETURN_APPROVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_TAX_RECEIPT_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_CHECK_APPROVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_CHECK_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_CHECK_RECEIVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_RETURN_BUDGET_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_PayType_Pass_Detail1_txt_Check_ready_date"));
            
        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%"> 
<tr>
<td>


    <uc1:UC_Disburse_Budget_PayType_Pass_Detail ID="UC_Disburse_Budget_PayType_Pass_Detail1" 
        runat="server" />

    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
</td>
</tr>
<tr>
<td align="center">
    <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="btn-lg" />
</td>
</tr>
</table>
</asp:Content>

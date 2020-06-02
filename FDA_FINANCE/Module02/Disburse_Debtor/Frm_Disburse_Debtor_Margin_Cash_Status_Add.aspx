<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Debtor_Margin_Cash_Status_Add.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_Margin_Cash_Status_Add" %>
<%@ Register src="UserControl/UC_Disburse_Debtor_Margin_Cash_Status_detail.ascx" tagname="UC_Disburse_Debtor_Margin_Cash_Status_detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../../Scripts/jquery-1.7.1.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>--%>
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../css/custom.css" rel="stylesheet" />
    <script src="../../js/custom.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Margin_Cash_Status_detail1_txt_return_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Margin_Cash_Status_detail1_txt_PAY_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Margin_Cash_Status_detail1_txt_Check_ready_date"));
        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table width="100%"> 
<tr>
<td>
    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />

    <uc1:UC_Disburse_Debtor_Margin_Cash_Status_detail ID="UC_Disburse_Debtor_Margin_Cash_Status_detail1" runat="server" />

</td>
</tr>
<tr>
<td align="center">
    <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="btn-lg" />
</td>
</tr>
</table>
</asp:Content>

﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Welfare_Cremation_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Welfare_Cremation_Insert" %>

<%@ Register Src="~/Module04/UseControl/UC_Welfare_Cremation_Detail.ascx" TagPrefix="uc1" TagName="UC_Welfare_Cremation_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../validate/jquery.validationEngine.js"></script>
    <script src="../validate/jquery.validationEngine-en.js"></script>
    

    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/Jsdatemain.js"></script>
    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Welfare_Cremation_Detail_txt_WELFARE_DATE"));

            jQuery("#aspnetForm").validationEngine();
            $("#ctl00_ContentPlaceHolder1_UC_Welfare_Cremation_Detail_dd_CUSTOMER").searchable();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

        });

</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <uc1:UC_Welfare_Cremation_Detail runat="server" ID="UC_Welfare_Cremation_Detail" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Save" runat="server" Text="บันทึกข้อมูล" />
            </td>
        </tr>
    </table>
</asp:Content>

﻿<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master"  CodeBehind="Frm_Disburse_Welfare_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Welfare_Insert" %>

<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Cure_Welfare_Detail.ascx" TagPrefix="uc1" TagName="UC_Disburse_Cure_Welfare_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../validate/jquery.validationEngine.js"></script>
    <script src="../../validate/jquery.validationEngine-en.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Welfare_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Welfare_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Welfare_Detail1_txt_BILL_DATE"));

            jQuery("#aspnetForm").validationEngine();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Study_Detail1_dl_User").searchable();
            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Welfare_Detail1_dd_CUSTOMER").searchable();

        });

        //function OnClientNodeClickingHandler(sender, e) {
        //    var node = e.get_node();
        //    var combo = $find("ctl00_ContentPlaceHolder1_UC_Disburse_Cure_Study_Detail1_rcb_budget");
        //    combo.set_text(node.get_text());
        //    combo.set_value(node.get_value());
        //    cancelDropDownClosing = false;
        //    combo.hideDropDown();



        //}

        //function StopPropagation(e) {
        //    //cancel bubbling
        //    e.cancelBubble = true;
        //    if (e.stopPropagation) {
        //        e.stopPropagation();
        //    }
        //}
</script> 

       <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกการเบิกค่ารักษาพยาบาล">
    <table>
    <tr>
            <td>
                
                <uc1:UC_Disburse_Cure_Welfare_Detail runat="server" ID="UC_Disburse_Cure_Welfare_Detail1" />
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btn_bill_save" runat="server" class="submit" Text="บันทึกใบเบิก" />
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
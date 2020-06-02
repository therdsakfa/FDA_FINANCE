<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Debtor_Bill_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_Bill_Insert" %>
<%@ Register src="UserControl/UC_Disburse_Debtor_Detail.ascx" tagname="UC_Disburse_Debtor_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
   
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../css/css_main.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.blockUI.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_txt_BILL_DATE"));
            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_dd_CUSTOMER").searchable();

        });
        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_rcb_budget");
            combo.set_text(node.get_text());
            combo.set_value(node.get_value());
            cancelDropDownClosing = false;
            combo.hideDropDown();



        }
        $(function () {
            $('#<%= btn_bill_save.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
</script> 

    <table width="100%">
    <tr>
            <td>
                
                <uc1:UC_Disburse_Debtor_Detail ID="UC_Disburse_Debtor_Detail1" runat="server" />
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </td>
        </tr>
        <tr>
        <td style="padding-left:10%;">
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="100px"/>
        </td>
            
        </tr>
    </table>
</asp:Content>

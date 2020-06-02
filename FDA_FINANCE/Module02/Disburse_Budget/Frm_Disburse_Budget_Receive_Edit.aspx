<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_Receive_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Receive_Edit" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_Detail.ascx"tagname="UC_Disburse_Budget_Detail" tagprefix="uc1" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_Detail_Amount.ascx" tagname="UC_Disburse_Budget_Detail_Amount" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Disburse_Budget_Multi_Bill.ascx" tagname="UC_Disburse_Budget_Multi_Bill" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../validate/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../../validate/jquery.validationEngine-en.js" type="text/javascript"></script>
    
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js" type="text/javascript"></script>
    <script src="../../Jsdate/ui.datepicker.js" type="text/javascript"></script>
    <script src="../../Jsdate/Jsdatemain.js" type="text/javascript"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_BILL_DATE"));
            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_dd_CUSTOMER").searchable();
            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_ddl_customer2").searchable();
           // jQuery("#aspnetForm").validationEngine();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");


            

        });

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_rcb_budget");
            combo.set_text(node.get_text());
            combo.set_value(node.get_value());
            cancelDropDownClosing = false;
            combo.hideDropDown();


            //}
        }

        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }

   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table width="1000px">
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <uc1:UC_Disburse_Budget_Detail ID="UC_Disburse_Budget_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
            
        </tr>
        <tr>
        <td>
            รายการใบเบิก</td>
            
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbtxt" runat="server" Text="ยอดคงเหลือ "></asp:Label>
            <asp:Label ID="lb_remain" runat="server" Text="0.0"></asp:Label> 
            <asp:Label ID="lbunit" runat="server" Text="บาท"></asp:Label>

            <uc3:UC_Disburse_Budget_Multi_Bill ID="UC_Disburse_Budget_Multi_Bill1" runat="server" />

        </td>
            
        </tr>
        <tr>
        <td>
            <asp:Button ID="btn_add" runat="server" Text="เพิ่มใบเบิก" />

        <asp:Button ID="btn_bill_save" runat="server" Text="เสร็จสิ้น" class="submit" />
        </td>
            
        </tr>
    </table>

</asp:Content>

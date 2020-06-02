<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_PO_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_PO_Edit" %>

<%@ Register src="UserControl/UC_Disburse_Budget_DetailV2.ascx" tagname="UC_Disburse_Budget_DetailV2" tagprefix="uc1" %>


<%@ Register src="UserControl/UC_Disburse_PO_Detail_Table_Edit.ascx" tagname="UC_Disburse_PO_Detail_Table_Edit" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <%--<script src="../../Scripts/jquery-1.7.1.js"></script>--%>
    <script src="../../Scripts/jquery-1.8.2.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
   <%-- <link href="../../Content/bootstrap.css" rel="stylesheet" />--%>

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_dodate"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_BILL_DATE"));

            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_dd_CUSTOMER").searchable();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

        });

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_rcb_budget");
            combo.set_text(node.get_text());
            combo.set_value(node.get_value());
            cancelDropDownClosing = false;
            combo.hideDropDown();



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
     <asp:Panel ID="Panel1" runat="server" GroupingText="แก้ไขใบจัดซื้อจัดจ้าง">
    <table width="900">
    <tr>
            <td>
                
                
                
                <uc1:UC_Disburse_Budget_DetailV2 ID="UC_Disburse_Budget_DetailV21" runat="server" />
                <uc2:UC_Disburse_PO_Detail_Table_Edit ID="UC_Disburse_PO_Detail_Table_Edit1" runat="server" />

            </td>
        </tr>
        <tr>
        <td align="center">
        <asp:Button ID="btn_bill_save" runat="server" Text="แก้ไข" CssClass="btn-lg"/>
            
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

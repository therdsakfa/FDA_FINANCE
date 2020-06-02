<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_PO_Detail_List_Insert2.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_PO_Detail_List_Insert2" %>
<%@ Register src="UserControl/UC_Disburse_Budget_DetailV2.ascx" tagname="UC_Disburse_Budget_DetailV2" tagprefix="uc1" %>


<%@ Register src="UserControl/UC_Disburse_PO_Detail_Table2.ascx" tagname="UC_Disburse_PO_Detail_Table2" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--      <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../validate/jquery.validationEngine.js"></script>
    <script src="../../validate/jquery.validationEngine-en.js"></script>--%>


    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    
    <script src="../../Scripts/jquery.blockUI.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <%--<link href="../../Content/bootstrap.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_dodate"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_DOC_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_BILL_DATE"));

            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_dd_CUSTOMER").searchable();
        });

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_rcb_budget");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกจัดซื้อจัดจ้าง">
    <table>
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />

                
                <uc1:UC_Disburse_Budget_DetailV2 ID="UC_Disburse_Budget_DetailV21" runat="server" />
                <uc2:UC_Disburse_PO_Detail_Table2 ID="UC_Disburse_PO_Detail_Table21" runat="server" />
                
                
            </td>
        </tr>
        <tr>
        <td align="center">
            
            
            
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึก"  CssClass="btn-lg"/>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>
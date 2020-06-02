<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Relate_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Relate_Insert" %>
<%@ Register src="UserControl/UC_RELATE_BILL_DETAIL.ascx" tagname="UC_RELATE_BILL_DETAIL" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <script src="../../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_henchop_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_dodate"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_travel_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_travel_date_end"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_ko_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_PO_CONTRACT_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_PO_GFMIS_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_txt_DOC_DATE"));

            jQuery("#aspnetForm").validationEngine();
            $("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_dd_CUSTOMER").searchable();
            $("#ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL21_ddl_GL").searchable();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

        });

        $(function () {
            $('#<%= btn_bill_save.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

        function clickclose() {
            $("#ctl00_ContentPlaceHolder1_btn_bill_save").hide();

        }

        function clickopen() {
            $("#ctl00_ContentPlaceHolder1_btn_bill_save").show();

        }

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("ctl00_ContentPlaceHolder1_UC_RELATE_BILL_DETAIL1_rcb_budget");
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
    
   <script type="text/javascript">
       
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกผูกพันเงินงบประมาณ">
    <table width="100%">
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                
             
                <uc1:UC_RELATE_BILL_DETAIL ID="UC_RELATE_BILL_DETAIL1" runat="server" />
                
             
            </td>
        </tr>
        <tr>
        <td align="center">
            <table>
                <tr>
                    <td><asp:Button ID="btn_confirm" runat="server" Text="บันทึก" style="width: 132px" /></td>
                    <td><asp:Button ID="btn_bill_save" runat="server" Text="บันทึก" style="display:none;"/></td>
                    <td><asp:Button ID="btn_cancel" runat="server" Text="ย้อนกลับ" style="display:none;" /></td>
                </tr>
            </table>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
    </asp:Content>
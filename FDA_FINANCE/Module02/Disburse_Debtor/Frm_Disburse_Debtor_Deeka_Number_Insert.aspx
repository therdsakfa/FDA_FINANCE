<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Debtor_Deeka_Number_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor_Deeka_Number_Insert" %>
<%@ Register src="../Disburse_Budget/UserControl/UC_Disburse_Budget_Deeka_Number_Detail.ascx" tagname="UC_Disburse_Budget_Deeka_Number_Detail" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Disburse_Debtor_Deeka_Number_Detail.ascx" tagname="UC_Disburse_Debtor_Deeka_Number_Detail" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Deeka_Number_Detail1_txt_Deeka_DATE"));
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
            var combo = $find("ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_rcb_budget");
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
    <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกเลขฎีกา">
    <table>
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                
                <uc2:UC_Disburse_Debtor_Deeka_Number_Detail ID="UC_Disburse_Debtor_Deeka_Number_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
        <td align="center"> <br />
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึก" class="submit"  style="width: 132px" CssClass="btn-lg"/>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

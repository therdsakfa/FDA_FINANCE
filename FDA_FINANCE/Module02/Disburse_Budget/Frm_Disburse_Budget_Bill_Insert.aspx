<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_Bill_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Bill_Insert1" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_Detail.ascx"tagname="UC_Disburse_Budget_Detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.7.1.js"></script>
    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_BILL_DATE"));
            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_dd_CUSTOMER").searchable();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_ddl_customer2").searchable();
            //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

        });

        $(function () {
            $('#<%= btn_bill_save.ClientID%>').click(function () {
                 $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
             });
         });

        function clickclose()
        {
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

   <script type="text/javascript">
       
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกการเบิกจ่ายงบประมาณ">
    <table>
    <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <uc1:UC_Disburse_Budget_Detail ID="UC_Disburse_Budget_Detail1" runat="server" />
            </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึกใบเบิกจ่าย" class="submit" OnClientClick="clickclose()" CssClass="btn-lg"/>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
    </asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_add_withdraw.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_add_withdraw" %>
<%--<%@ Register src="UserControl/UC_Disburse_Budget_DetailV2.ascx" tagname="UC_Disburse_Budget_DetailV2" tagprefix="uc1" %>--%>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_add.ascx" TagName="UC_Disburse_Budget_withdraw_add" TagPrefix="uc1" %>
<%--<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_add_table.ascx" TagName="UC_Disburse_Budget_withdraw_add_table" TagPrefix="uc4" %>--%>
<%@ Register src="UserControl/UC_Disburse_Budget_DetailV2_Table.ascx" tagname="UC_Disburse_Budget_DetailV2_Table" tagprefix="uc2" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_DetailV3_Table.ascx" TagPrefix="uc3" TagName="UC_Disburse_Budget_DetailV3_Table" %>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_add_Part2.ascx" TagPrefix="uc1" TagName="UC_Disburse_Budget_withdraw_add_Part2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.2.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {;
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_dodate"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV21_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_add1_txt_wd_date"));
            $("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV2_Table1_dd_CUSTOMER").searchable();
        });

        function clickclose() {
            $("#ctl00_ContentPlaceHolder1_btn_bill_save").hide();

        }

        function clickopen() {
            $("#ctl00_ContentPlaceHolder1_btn_bill_save").show();

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

    <%--    <asp:Panel ID="Panel1" runat="server">--%>
    <table width="100%">
        <tr>
            <td style="margin-left: 40px">
                <uc1:UC_Disburse_Budget_withdraw_add ID="UC_Disburse_Budget_withdraw_add1" runat="server" />

            </td>
        </tr>
    </table>


<table width="80%" >
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr align="center">
       <td>
            <asp:Button ID="bt_save" runat="server"  Height="35px" Width="12%"  Text="บันทึก"/>
        </td>
    </tr>
<tr>
        <td>
            <br /> <br /><br />
        </td>
    </tr>
</table>


    <asp:Panel ID="Panel2" runat="server" Style="display: none;">

        <table width="80%">
            <tr>
                <td>
                    <uc1:UC_Disburse_Budget_withdraw_add_Part2 runat="server" ID="UC_Disburse_Budget_withdraw_add_Part21" />

                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>

        </table>

    </asp:Panel>

</asp:Content>

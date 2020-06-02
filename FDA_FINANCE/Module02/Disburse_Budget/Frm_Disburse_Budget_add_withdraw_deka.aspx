<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Budget_add_withdraw_deka.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_add_withdraw_deka" %>

<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_deka_add_insert.ascx" TagPrefix="uc1" TagName="UC_Disburse_Budget_withdraw_deka_add_insert" %>


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
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_withdraw_deka_add1_txt_deka_date"));

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

    <br />

    <asp:Panel ID="Panel1" runat="server">
          <div class="panel panel-body" style="width: 100%;">

        <table width="100%">
            <tr>
                <td>
                    <uc1:UC_Disburse_Budget_withdraw_deka_add_insert runat="server" id="UC_Disburse_Budget_withdraw_deka_add_insert1" />
                </td>
            </tr>
            <tr align="center">
       <td>
            <asp:Button ID="bt_save" runat="server"  Height="35px" Width="11%"  Text="บันทึกฏีกา"/>
        </td>
    </tr>
        </table>
    </div>
    </asp:Panel>

    <br />
    <br />

    
</asp:Content>


<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_Outside_Budget_Checker_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Outside_Budget_Checker_Insert" %>
<%@ Register src="../UserControl/UC_OutsideBudget_Checker_Detail.ascx" tagname="UC_OutsideBudget_Checker_Detail" tagprefix="uc1" %>
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
            showdate($("#ctl00_ContentPlaceHolder1_UC_OutsideBudget_Checker_Detail1_txt_date"));
        });

</script> 
        <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกการตรวจสอบ">
    <table>
    <tr>
            <td>
               <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
               
                <uc1:UC_OutsideBudget_Checker_Detail ID="UC_OutsideBudget_Checker_Detail1" runat="server" />
               
            </td>
        </tr>
        <tr>
        <td align="center">
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึก" class="submit" />
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_OutsideDebtor_Bill_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideDebtor_Bill_Edit" %>
<%@ Register src="~/Module02/Disburse_Debtor/UserControl/UC_Disburse_Debtor_Detail.ascx" tagname="UC_Disburse_Debtor_Detail" tagprefix="uc1" %>
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
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_txt_Bill_RECIEVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Disburse_Debtor_Detail1_txt_BILL_DATE"));
            jQuery("#aspnetForm").validationEngine();
        });
</script>   
      <asp:Panel ID="Panel1" runat="server" GroupingText="แก้ไขใบเบิกจ่ายงบประมาณ">
    <table>
    <tr>
            <td>
               
               
               
                <uc1:UC_Disburse_Debtor_Detail ID="UC_Disburse_Debtor_Detail1" runat="server" />
               
               <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
               
            </td>
        </tr>
        <tr>
        <td>
        <asp:Button ID="btn_bill_edit" runat="server" Text="แก้ไขใบเบิกจ่าย" class="submit"/>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

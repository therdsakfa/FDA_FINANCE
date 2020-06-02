<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Edit" %>

<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReturnMoney_OutsideBudget_Detail.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReturnMoney_OutsideBudget_Detail" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information.ascx" tagname="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="/css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.7.1.js"></script>
    <script src="/validate/jquery.validationEngine.js"></script>
    <script src="/validate/jquery.validationEngine-en.js"></script> 

    <link href="/css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="/css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="/Jsdate/ui.datepicker-th.js"></script>
    <script src="/Jsdate/ui.datepicker.js"></script>
    <script src="/Jsdate/Jsdatemain.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_OutsideBudget_Detail_txt_return_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_OutsideBudget_Detail_txt_DOC_DATE"));
            jQuery("#aspnetForm").validationEngine();
        });
</script> 
    <table>
        <tr>
            <td>
                <uc2:UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information ID="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>แก้ไขข้อมูลการคืนเงิน ลูกหนี้เงินยืม นอกงบประมาณ</td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_ReturnMoney_OutsideBudget_Detail runat="server" ID="UC_Maintain_ReturnMoney_OutsideBudget_Detail" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Edit" runat="server" Text="แก้ไข" class="submit"/>
                <asp:Button ID="btn_Cancel" runat="server" Text="ยกเลิก" />
            </td>
        </tr>
    </table>
</asp:Content>

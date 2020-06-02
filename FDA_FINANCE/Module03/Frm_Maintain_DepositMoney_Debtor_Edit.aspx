<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_DepositMoney_Debtor_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_DepositMoney_Debtor_Edit" %>
<%@ Register src="UseControl/UC_Maintain_DepositMoney_Debtor_Detail.ascx" tagname="UC_Maintain_DepositMoney_Debtor_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../validate/jquery.validationEngine.js"></script>
    <script src="../validate/jquery.validationEngine-en.js"></script>

     <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_DepositMoney_Debtor_Detail1_txt_DEPOSIT_DATE"));
            jQuery("#aspnetForm").validationEngine();
        });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>แก้ไขข้อมูล การฝากเงิน/ส่งคลัง</td>
        </tr>
        <tr>
            <td>
                
                <uc1:UC_Maintain_DepositMoney_Debtor_Detail ID="UC_Maintain_DepositMoney_Debtor_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Save" runat="server" Text="แก้ไข" class="submit" Width="90px" Height="50px"/>
            </td>
        </tr>
    </table>
</asp:Content>

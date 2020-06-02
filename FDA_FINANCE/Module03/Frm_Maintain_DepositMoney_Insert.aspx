<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_DepositMoney_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_DepositMoney_Insert" %>

<%@ Register Src="~/Module03/UseControl/UC_Maintain_DepositMoney_Detail.ascx" TagPrefix="uc1" TagName="UC_Maintain_DepositMoney_Detail" %>

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
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_DepositMoney_Detail_txt_DEPOSIT_DATE"));
            jQuery("#aspnetForm").validationEngine();
        });
</script> 
    <table>
        <tr>
            <td>บันทึกข้อมูล การฝากเงิน/ส่งคลัง</td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_DepositMoney_Detail runat="server" ID="UC_Maintain_DepositMoney_Detail" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Save" runat="server" Text="บันทึก" class="submit" Width="90px" Height="50px"/>
            </td>
        </tr>
    </table>
</asp:Content>

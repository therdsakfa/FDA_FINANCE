<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_Insert_Detail.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_Insert_Detail" %>
<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReturnMoney_Detail.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReturnMoney_Detail" %>
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
    <script src="../Jsdate/Jsdatemain.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_return_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date"));
            //if document.getElementById("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date") {

            //}

            jQuery("#aspnetForm").validationEngine();
        });

        function setDisableDate() {
            //$("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date").datepicker("hide");
            //$("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date").removeClass("ui-datepicker-trigger");
            //document.getElementsByClassName("ui-datepicker-trigger");

            hideIMG($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date"));
        }


        function hideIMG(targetobject) {
            $(targetobject).datepicker({
                //showOn: "button",
                // showAnim: "hidden",
                buttonImage: "",
                // buttonImageOnly: true
            });

        }
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
         <tr>
            <td>เพิ่มข้อมูลการคืนเงิน ลูกหนี้เงินยืม</td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_ReturnMoney_Detail runat="server" ID="UC_Maintain_ReturnMoney_Detail" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Save" runat="server" Text="บันทึก" class="submit"/>
                <%--<asp:Button ID="btn_Cancel" runat="server" Text="ยกเลิก" />--%>
            </td>
        </tr>
    </table>
</asp:Content>

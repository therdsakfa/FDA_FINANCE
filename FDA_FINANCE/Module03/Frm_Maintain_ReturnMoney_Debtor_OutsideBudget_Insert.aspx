<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Insert" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReturnMoney_OutsideBudget_Detail.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReturnMoney_OutsideBudget_Detail" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information.ascx" tagname="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information" tagprefix="uc2" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor_Show_Grid.ascx" tagname="UC_Maintain_ReturnMoney_Debtor_Show_Grid" tagprefix="uc3" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Detail.ascx" tagname="UC_Maintain_ReturnMoney_Detail" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />

    <script src="../Jsdate/ui.datepicker.js" type="text/javascript"></script>
    <script src="../Jsdate/ui.datepicker-th.js" type="text/javascript"></script>
    <script src="../Jsdate/Jsdatemain.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_return_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_today_date"));
            //if document.getElementById("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date") {

            //}

            //jQuery("#aspnetForm").validationEngine();
        });

        $(function () {
            $('#<%= btn_save.ClientID%>').click(function () {
                 $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
             });
         });

        function insert_k(url) {
            var d_edit = $("#dialog_insert");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 600,
                width: 800,
                modal: true
            });
            openform(url, "#if1");
            return false;
        }

        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 600,
                width: 800,
                modal: true
            });
            openform(url, "#1234");
            return false;
        }

        // function เปิด form | รับ url, ID iframe เข้ามา
        function openform(urls, idiframe) {
            $.blockUI({ message: msg() });
            function msg() {
                return 'กรุณารอสักครู่ระบบกำลังทำงาน';
            }
            $.ajax({
                type: 'POST',
                data: { submit: true },
                success: function (result) {
                    var i = $(idiframe); // ID ของ iframe
                    i.attr("src", urls); //  url ของ form ที่จะเปิด
                    $.unblockUI();
                }
            });
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Button" Style="display:none;" />
                <asp:RadioButtonList ID="rdl_Paytype_main" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">เงินนอกงบประมาณ</asp:ListItem>
                    <asp:ListItem Value="2">เงินทดรอง</asp:ListItem>
                    <asp:ListItem Value="3">เงินรายได้แผ่นดิน</asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <uc2:UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information ID="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information1" runat="server" />
            </td>
        </tr>
       <%-- <tr>
            <td>เพิ่มข้อมูลการคืนเงิน ลูกหนี้เงินยืม นอกงบประมาณ</td>
        </tr>--%>
        <tr>
            <td >
                <uc4:UC_Maintain_ReturnMoney_Detail ID="UC_Maintain_ReturnMoney_Detail1" runat="server" />
            </td>
        </tr>
         <tr>
            <td align="center">
                <asp:Button ID="btn_previous" runat="server" Text="ย้อนกลับ" />
                <%--<asp:Button ID="btn_Add" runat="server" Text="บันทึกข้อมูล" />--%>
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" />
            </td>
        </tr>
        <tr>
            <td>

                <uc3:UC_Maintain_ReturnMoney_Debtor_Show_Grid ID="UC_Maintain_ReturnMoney_Debtor_Show_Grid1" runat="server" />

            </td>
        </tr>
    </table>
     <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="800px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="800px" height="600px" ></iframe>
    </div>
</asp:Content>

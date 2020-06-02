<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_Other_Pay.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Other_Pay" %>
<%@ Register src="UseControl/UC_Maintain_Other_Pay.ascx" tagname="UC_Maintain_Other_Pay" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                //X เพิ่มนะ
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                //
                d_insert.dialog("open");
                openform("../Module03/Frm_Maintain_Other_Pay_Insert.aspx?bgyear=" + bgYear, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

        function k(id) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });

            openform("../Module03/Frm_Maintain_Other_Pay_Edit.aspx?id=" + id, "#1234");
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
    <table width="100%">
        <tr>
            <td>บันทึกการเบิกจ่ายเงินอื่นๆ</td>
        </tr>
   
   
        <tr>
            <td>
            
            <table width="100%">
                <tr><td>
                    &nbsp;</td><td align="right"><asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" /></td></tr>
            <tr><td colspan="2">
                 <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                 <uc1:UC_Maintain_Other_Pay ID="UC_Maintain_Other_Pay1" runat="server" />
            </td></tr>
            
            </table>
               
            </td>
        </tr>
    </table>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>


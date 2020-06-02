<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MAIN_NODE.Master" CodeBehind="Frm_User_Debtor.aspx.vb" Inherits="FDA_FINANCE.Frm_User_Debtor" %>
<%@ Register src="UserControl/UC_User_Debtor.ascx" tagname="UC_User_Debtor" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Search_User_Debtor.ascx" tagname="UC_Search_User_Debtor" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btnAdd').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                //X เพิ่มนะ
                d_insert.dialog("open");
                openform("Frm_User_Debtor_Insert.aspx", "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 600,
                width: 1000,
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
                <uc2:UC_Search_User_Debtor ID="UC_Search_User_Debtor1" runat="server" />
                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" Width="70px" />
            </td>
        </tr>
<tr>
<td>
รายชื่อลูกหนี้
    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
</td>
</tr>
<tr>
<td align="right">
    <asp:Button ID="btnAdd" runat="server" Text="เพิ่มข้อมูล" />
</td>
</tr>
        <tr>
            <td>
               
                <uc1:UC_User_Debtor ID="UC_User_Debtor1" runat="server" />
               
        </tr>
    </table>
     <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Study_Approve_OK.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Study_Approve_OK" %>

<%@ Register src="UserControl/UC_Disburse_Cure_Approve_Ok.ascx" tagname="UC_Disburse_Cure_Approve_Ok" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Search_From_Cure_Study.ascx" tagname="UC_Search_From_Cure_Study" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../../css/css_main.css" rel="stylesheet" />
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
                //var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetAdjust");
                //var selectVal = e.options[e.selectedIndex].value;
                //var dd = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetAdjust");
                //var selectVal = dd.options[dd.selectedIndex].value;
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                //
                d_insert.dialog("open");
                openform("Frm_Disburse_Study_Insert.aspx?bgyear=" + bgYear, "#if1"); //ใส่ url, ID iframe
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
    <div class="panel panel-body"  style="width:100%;">
        การอนุมัติการเบิกค่าเล่าเรียนบุตร
        </div>

    <div class="panel panel-body"  style="width:100%;">

        <table width="100%"><tr><td>  
            <uc3:UC_Search_From_Cure_Study ID="UC_Search_From_Cure_Study1" runat="server" />
            </td>
        
        <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" 
                Height="59px" /></td></tr></table>
          
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />


</div>

    <div class="panel panel-body"  style="width:100%;">
    <table width="100%">
          <tr>
            <td align="right">
                <asp:Button ID="btn_no_approve" runat="server" Text="ยกเลิกอนุมัติ" />
                <asp:Button ID="btn_approve" runat="server" Text="อนุมัติ" Width="80px" />
             </td>
        </tr>
        <tr>
            <td>
                
                <uc2:UC_Disburse_Cure_Approve_Ok ID="UC_Disburse_Cure_Approve_Ok1" runat="server" />
                
            </td>
        </tr>
    </table>
        </div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>
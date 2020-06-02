<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Relate_Overview_withdraw_v2.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Relate_Overview_withdraw_v2" %>
<%--<%@ Register src="UserControl/UC_Disburse_Budget_Bill.ascx" tagname="UC_Disburse_Budget_Bill" tagprefix="uc1" %>--%>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_Bill_withdraw.ascx" TagName="UC_Disburse_Budget_Bill_withdraw" TagPrefix="uc1" %>
<%@ Register src="UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>

    <link href="../../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }

            function getQuerystring(key, default_) {
                if (default_ == null) default_ = "";
                key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
                var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
                var qs = regex.exec(window.location.href);
                if (qs == null)
                    return default_;
                else
                    return qs[1];
            }

        });
        function Popups(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f2'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }

        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }

        //function refresh() {
        //    document.getElementById("ContentPlaceHolder1_btnRedirect").click();
        //}
        function refresh() {
            //document.getElementById("ContentPlaceHolder1_btnRedirect").click();
            $('#ctl00_ContentPlaceHolder1_btnRedirect').click();
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--      <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    
    <script type="text/javascript">

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
                success: function(result) {
                var i = $(idiframe); // ID ของ iframe
                i.attr("src", urls); //  url ของ form ที่จะเปิด
                $.unblockUI();
                }
            });  
        }
    </script>--%>
    <div class="panel panel-body" style="width: 100%;">
        <h3>รับเรื่องเบิกเงินงบประมาณ</h3>
    </div>

    <%--    <div class="panel panel-body"  style="width:100%;">
        <table width="100%">
            <tr><td>   
            <uc3:UC_Search_Form ID="UC_Search_Form1" runat="server" />

                                </td>
        <td> <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg"/></td>

                            </tr>

        </table>
         <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
</div>--%>
    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">

            <tr>
                <td>
                    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" />
                    <uc1:UC_Disburse_Budget_Bill_withdraw ID="UC_Disburse_Budget_Bill_withdraw1" runat="server" />
                    <%--<uc1:uc_disburse_budget_bill ID="UC_Disburse_Budget_Bill1" runat="server" />--%>
               
                </td>
            </tr>
        </table>
    </div>
    <div id="dialog_edit" title="บันทึกเลข ขบ." style="display: none">
        <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกรับเรื่องเบิก
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกฏีกาเบิกเงินงบประมาณ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


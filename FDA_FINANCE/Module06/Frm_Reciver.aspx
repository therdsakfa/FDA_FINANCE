﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Reciver.aspx.vb" Inherits="FDA_FINANCE.Frm_Reciver" %>

<%@ Register src="~/Module06/UserControl/UC_Recivers.ascx" tagname="UC_Recivers" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ctl00_ContentPlaceHolder1_btnAdd').click(function () {
                Popups('Frm_Reciver_Insert.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
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

        function refresh() {
            document.getElementById("ContentPlaceHolder1_btnRedirect").click();
        }
        </script>

     <%-- <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
                //var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetAdjust");
                //var selectVal = e.options[e.selectedIndex].value;
                //var e = document.getElementById("ctl00_dd_BudgetYear");
                //var bgYear = e.options[e.selectedIndex].value;
                //
                d_insert.dialog("open");
                openform("Frm_Reciver_Insert.aspx", "#if1"); //ใส่ url, ID iframe
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


    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;">
                <h3><font color="black">หน่วยงาน</font></h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
</div>

<div class="panel panel-body"  style="width:100%;">
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />

            </td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Recivers ID="UC_Recivers1" runat="server" />
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
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกรายการผู้รับเงิน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    แก้ไขรายการผู้รับเงิน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

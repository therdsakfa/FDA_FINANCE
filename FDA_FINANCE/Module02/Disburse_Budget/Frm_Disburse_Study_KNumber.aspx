﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Study_KNumber.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Study_KNumber" %>

<%@ Register src="UserControl/UC_Disburse_Study_GF.ascx" tagname="UC_Disburse_Study_GF" tagprefix="uc1" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_From_Cure_Study.ascx" tagname="UC_Search_From_Cure_Study" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                //$('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                //    var bgid = getQuerystring('bgid');
                //    var bgYear = getQuerystring('myear');
                //    var select_dept = getQuerystring('dept');
                //    Popups('Frm_Disburse_Cure_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString());
                //    return false;
                //});

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

    <%--<link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
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
        บันทึกเลข ขบ.
        </div>
    <div class="panel panel-body"  style="width:100%;">
         <table width="100%"><tr><td>   
            <uc2:UC_Search_From_Cure_Study ID="UC_Search_From_Cure_Study1" runat="server" />
            </td>
        <td> <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" 
                Height="60px" /></td></tr></table>
         <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
    

        </div>
    <div class="panel panel-body"  style="width:100%;">
    <table width="100%">
        <tr>
            <td>
               
                <uc1:UC_Disburse_Study_GF ID="UC_Disburse_Study_GF1" runat="server" />
               
            </td>
        </tr>
    </table>
    </div>
       <div id="dialog_edit" title="บันทึกเลข ขบ." style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>
    <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกเลข ขบ.
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

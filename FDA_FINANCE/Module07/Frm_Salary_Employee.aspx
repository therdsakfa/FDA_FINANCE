﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Salary_Employee.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_Employee" %>

<%@ Register src="UC/UC_Search_Salary.ascx" tagname="UC_Search_Salary" tagprefix="uc2" %>

<%@ Register src="UC/UC_Salary_Employee.ascx" tagname="UC_Salary_Employee" tagprefix="uc3" %>

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

              $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                  var bgid = getQuerystring('bgid');
                  var bgYear = getQuerystring('myear');
                  var select_dept = getQuerystring('dept');
                  Popups('Frm_Salary_Personal_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&t=4');
                  return false;
              });

              $('#ctl00_ContentPlaceHolder1_btn_copy').click(function () {

                  var bgYear = getQuerystring('myear');
                  Popups4('Frm_Import_Salary_EMP.aspx?bgYear=' + bgYear.toString());

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

          function Popups3(url) { // สำหรับทำ Div Popup

              $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f3'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups4(url) { // สำหรับทำ Div Popup

              $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f4'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function spin_space() { // คำสั่งสั่งปิด PopUp
              //    alert('123456');
              $('#spinner').toggle('slow');
              //$('#myModal').modal('hide');
              //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

          }

          function refresh() {
              //document.getElementById("ContentPlaceHolder1_btnRedirect").click();
              $('#ctl00_ContentPlaceHolder1_btnRedirect').click();
          }
        </script> 
    <%--<script type="text/javascript">
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
                //var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = 2558//e.options[e.selectedIndex].value;
                //+ "&bgid=" + selectVal
                d_insert.dialog("open");
                openform("Frm_Salary_Personal_Insert.aspx?bgyear=" + bgYear + "&t=4", "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_copy').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                d_insert.dialog("open");
                openform("Frm_Import_Salary_EMP.aspx?bgYear=" + bgYear , "#if1"); //ใส่ url, ID iframe
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
    <div class="panel panel-body" style="width: 100%;">
        <h3>รายการจ่ายค่าตอบแทนลูกจ้างเหมา</h3>
    </div>

    <div class="panel panel-body" style="width: 100%;">
        <table width="70%" align="center">
            <tr>
                <td>
                    <uc2:UC_Search_Salary ID="UC_Search_Salary1" runat="server" />
                </td>
                <td valign="bottom">&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" Height="40px" /></td>
            </tr>
        </table>
        <asp:Button ID="btn_del" runat="server" Text="Button" Style="display: none;" />
        <asp:TextBox ID="txt_id" runat="server" Style="display: none;"></asp:TextBox>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" />
    </div>


    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">

            <tr>
                <td>

                    <table width="100%">
                        <tr>
                            <td>&nbsp;</td>
                            <td align="right">เดือน &nbsp;<asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true" Height="30px" Width="15%">
                                <%-- <asp:ListItem Value="">---เลือกเดือน---</asp:ListItem>--%>
                                <asp:ListItem Value="1">มกราคม</asp:ListItem>
                                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                                <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                            </asp:DropDownList>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btn_copy" runat="server" Text="คัดลอกข้อมูล" Height="40px" Width="120px" />
                                &nbsp;
                    <asp:Button ID="btn_export" runat="server" Text="Export" Height="40px" Width="120px" />
                                &nbsp;
                    <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" Height="40px" Width="120px" /></td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">

                                <uc3:UC_Salary_Employee ID="UC_Salary_Employee1" runat="server" />

                            </td>
                        </tr>

                    </table>

                </td>
            </tr>
        </table>
    </div>
    <%--<div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>--%>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกลูกจ้างเหมาผู้รับเงินเดือน
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
                    แก้ไขลูกจ้างเหมาผู้รับเงินเดือน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal3">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายรับรายจ่าย
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f3" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal4">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    คัดลอกข้อมูลเงินเดือน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f4" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
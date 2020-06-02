<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_BudgetPlan.aspx.vb" Inherits="FDA_FINANCE.Frm_BudgetPlan" %>

<%@ Register src="UserControl/UC_BudgetPlan.ascx" tagname="UC_BudgetPlan" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Budgetplan_Information.ascx" tagname="UC_Budgetplan_Information" tagprefix="uc3" %>

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

                $('#ctl00_ContentPlaceHolder1_lbt_new_bg').click(function () {
                    var bgid = getQuerystring('bgid');
                    var bgYear = getQuerystring('myear');
                    var select_dept = getQuerystring('dept');
                    Popups('Frm_BudgetPlan_Insert.aspx?typeid=1&bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString());
                    return false;
                });
                //openform("../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" + id + "&dept=" + dept + "&bgid=" + bgid +"&bguse=1", "#1234");
                function Popups(url) { // สำหรับทำ Div Popup
                    //alert('555');
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

    <%--<script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_lbt_new_bg').click(function () {
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
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                //
                d_insert.dialog("open");
                openform("Frm_BudgetPlan_Insert.aspx?typeid=1&bgyear=" + bgYear, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });
        //เพิ่มโหนดลูกๆ
        function insert_sub(url) {
            var d_insert = $("#dialog_insert");
            d_insert.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });

            d_insert.dialog("open");
            openform(url, "#if1"); //ใส่ url, ID iframe
            return false;

        }



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
    <asp:Panel ID="Panel1" runat="server" >
  

        <table width="100%"><tr><td style="width:50%">รายการงบประมาณ
            </td><td style="width:50%">ข้อมูลงบประมาณ</td></tr>
            <tr><td>
                <img src="../images/plus_icon.png" />
                <asp:LinkButton ID="lbt_new_bg" runat="server">เพิ่มหัวข้องบประมาณ</asp:LinkButton>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                </td><td rowspan="2" valign="top">
                    <hr />
                    <uc3:UC_Budgetplan_Information ID="UC_Budgetplan_Information1" runat="server" />
                    <asp:Label ID="lbHide" runat="server" Text="Label" Style="display:none;"></asp:Label>
                    <asp:TextBox ID="txt_hide" runat="server" Style="display:none;"></asp:TextBox>
                </td></tr>
            <tr><td>
                <uc1:UC_BudgetPlan ID="UC_BudgetPlan1" runat="server" />
                </td></tr>
        </table>
        <br />
  <table border="1" style="border-style:solid" cellspacing="0" cellpadding="0">
      <tr>
          <td colspan="2">
              ความหมายของสัญลักษณ์
          </td>
      </tr>
      <tr>
          <td>
              <img src="../images/n1.png" />
          </td>
          <td>
              หัวข้องบประมาณ
          </td>
      </tr>
      <tr>
          <td>
              <img src="../images/n2.png" />
          </td>
          <td>
              แผนงาน</td>
      </tr>
      <tr>
          <td>
              <img src="../images/n3.png" />
          </td>
          <td>
              ผลผลิต</td>
      </tr>
      <tr>
          <td>
              <img src="../images/n4.png" />
          </td>
          <td>
              กิจกรรม</td>
      </tr>
      <tr>
          <td>
              <img src="../images/n5.png" />
          </td>
          <td>
              โครงการ</td>
      </tr>
      <tr>
          <td>
              <img src="../images/n6.png" />
          </td>
          <td>
              ประเภทงบรายจ่าย</td>
      </tr>
       <tr>
          <td>
              <img src="../images/n7.png" />
          </td>
          <td>
              งบรายจ่าย</td>
      </tr>
       <tr>
          <td>
              <img src="../images/n8.png" />
          </td>
          <td>
              งบรายจ่ายย่อย</td>
      </tr>
  </table>
      </asp:Panel>

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
                    บันทึกข้อมูลงบประมาณ
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
                    บันทึกข้อมูลงบประมาณ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

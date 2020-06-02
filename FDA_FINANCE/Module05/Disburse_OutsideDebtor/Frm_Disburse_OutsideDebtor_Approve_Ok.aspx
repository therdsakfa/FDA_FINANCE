<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_OutsideDebtor_Approve_Ok.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideDebtor_Approve_Ok" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form_Approve.ascx" tagname="uc_search_form_approve" tagprefix="uc1" %>
<%@ Register src="~/Module02/Disburse_Debtor/UserControl/UC_Disburse_Debtor_Approve_Ok.ascx" tagname="UC_Disburse_Debtor_Approve_Ok" tagprefix="uc2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
                    Popups('../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString());
                    return false;
                });
                //openform("../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" + id + "&dept=" + dept + "&bgid=" + bgid +"&bguse=1", "#1234");



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

            function refresh() {
                document.getElementById("ContentPlaceHolder1_btnRedirect").click();
            }
        </script> 
    
    <%--<script type="text/javascript">

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

        function k_edit(url) {
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
     <div class="panel panel-body"  style="width:100%;padding-left:5%;">
                <h3>&nbsp;</h3>
</div>
<div class="panel panel-body"  style="width:100%;">
        <table><tr><td>  
            <%--<uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" />--%>


            <uc1:uc_search_form_approve ID="UC_Search_Form_Approve1" runat="server" />


            </td>
        
        <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg"/></td></tr></table>
          <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
  </div>          

       <%--<tr><td colspan="2" bgcolor="#FFFFCC" style="border: thin ridge #000000">
     หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" Font-Names="TH SarabunPSK" Font-Size="14" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList> <br/>

งบประมาณที่ได้รับการจัดสรร&nbsp;
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" AutoPostBack="true" 
                    DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Font-Names="TH SarabunPSK" Font-Size="14">
                </asp:DropDownList>
                </td></tr>--%>

    <div class="panel panel-body"  style="width:100%;">
    <table width="100%">
         <tr>
            <td>&nbsp;</td>

        </tr>
         <tr>
             <td align="right">
                <%--<asp:Button ID="btn_approve" runat="server" Text="อนุมัติ" Width="80px" />--%>
             </td>
         </tr>
        <tr>
            <td>
                
                <uc2:uc_disburse_debtor_approve_ok ID="UC_Disburse_Debtor_Approve_Ok1" runat="server" />
                
            </td>
        </tr>
    </table>
        </div>
    <div id="dialog_edit" title="การอนุมัติ" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เลือกประเภทการจ่าย<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    แก้ไขลูกหนี้เงินยืม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
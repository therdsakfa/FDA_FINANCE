﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Relate_Overview_withdraw.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Relate_Overview_withdraw" %>
<%--<%@ Register src="UserControl/UC_Disburse_Budget_Receive_List.ascx" tagname="UC_Disburse_Budget_Receive_List" tagprefix="uc1" %>--%>
<%@ Register Src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget_withdraw_detail.ascx" TagName="UC_Disburse_Budget_withdraw_detail" TagPrefix="uc1" %>
<%@ Register src="UserControl/UC_Search_Form_Receive_List.ascx" tagname="UC_Search_Form_Receive_List" tagprefix="uc2" %>
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
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f3'); // ID ของ iframe   
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
 <%--   <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../../css/css_main.css" rel="stylesheet" />--%>
    <%--<script type="text/javascript">


        function k(id, bg_id, bgYear) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1100,
                modal: true
            });
            openform("Frm_Disburse_Budget_Receive_Edit.aspx?bid=" + id + "&bgid=" + bg_id + "&bgYear=" + bgYear, "#1234");
            return false;
        }

        function k_edit(id, bg_id, bgYear) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1100,
                modal: true
            });
            openform("Frm_Disburse_Budget_Receive_Edit_Bill.aspx?bid=" + id + "&bgid=" + bg_id + "&bgYear=" + bgYear, "#1234");
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
    <style type="text/css">
.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.rdfd_{position:absolute}.rdfd_{position:absolute}.rdfd_{position:absolute}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadInput .riTextBox{height:17px}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker .rcCalPopup{display:block;overflow:hidden;width:22px;height:22px;background-color:transparent;background-repeat:no-repeat;text-indent:-2222px;text-align:center}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}.RadPicker td a{position:relative;outline:0;z-index:2;margin:0 2px;text-decoration:none}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="panel panel-body"  style="width:100%;">
       <h3>รายการรับเรื่องเบิกค่าใช้จ่าย</h3>
       </div> 
    
  <div class="panel panel-body"  style="width:100%;">   
     <table width="100%">
        <tr>
            <td colspan="2">
                <uc2:UC_Search_Form_Receive_List ID="UC_Search_Form_Receive_List1" runat="server" /> 
            </td>
            <td>
                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />
            </td>
        </tr>
         </table>
</div>

    <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
    <%--<tr>
                    <td>
                        
                    </td>
                    <td align="right">
 <table>
                            <tr>
                                <td>วันที่ &nbsp;</td>
                                <td>
                                    <telerik:RadDatePicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH" Skin="Office2010Blue">
                                        <Calendar skin="Office2010Blue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                            <EmptyMessageStyle Resize="None" />
                                            <ReadOnlyStyle Resize="None" />
                                            <FocusedStyle Resize="None" />
                                            <DisabledStyle Resize="None" />
                                            <InvalidStyle Resize="None" />
                                            <HoveredStyle Resize="None" />
                                            <EnabledStyle Resize="None" />
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>การอนุมัติ </td>
                                <td>
                                    <asp:DropDownList ID="ddl_approve" runat="server">
                                        <asp:ListItem Value="1">ผ่าน</asp:ListItem>
                                        <asp:ListItem Value="2">ไม่ผ่าน(กรอกเหตุผล)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="ตรวจสอบ"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>
   
        <tr>
            <td colspan="2">
            
            <table width="100%">
                <%--<tr><td>&nbsp;</td><td align="right">&nbsp;</td></tr>--%>
            <tr><td>
                <%--<uc1:uc_disburse_budget_receive_list ID="UC_Disburse_Budget_Receive_List1" runat="server" />--%>
                <uc1:UC_Disburse_Budget_withdraw_detail ID="UC_Disburse_Budget_withdraw_detail1" runat="server" />
                </td></tr>
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </table>
               
            </td>
        </tr>
    </table>
    </div>
    <div id="dialog_edit" title="เพิ่มเลขบ." style="display:none">  
    <iframe id="1234" width="1100px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1100px" height="700px" ></iframe>
    </div>

    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เพิ่มรายละเอียดเบิกรับเรื่อง
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
                    เพิ่มรายระเอียดเบิกฏีกา
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    กรอกเหตุผล การไม่อนุมัติ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f3" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
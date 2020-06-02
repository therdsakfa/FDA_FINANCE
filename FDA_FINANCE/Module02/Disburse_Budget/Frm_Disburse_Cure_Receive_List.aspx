<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Cure_Receive_List.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Cure_Receive_List" %>
<%@ Register src="UserControl/UC_Search_Form_Receive_List.ascx" tagname="UC_Search_Form_Receive_List" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Disburse_Cure_Study_Receive_List.ascx" tagname="UC_Disburse_Cure_Study_Receive_List" tagprefix="uc1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
    <link href="../../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        function k(id, bgYear) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            openform("Frm_Disburse_Cure_Receive_List_Edit.aspx?bid=" + id + "&bgyear=" + bgYear, "#1234");
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
        ตรวจสอบรับเรื่อง
        </div>
     <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
        <tr>
            <td>
                <uc2:UC_Search_Form_Receive_List ID="UC_Search_Form_Receive_List1" runat="server" /> <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
            </td>
        </tr>
        </table>
         </div>
     <div class="panel panel-body"  style="width:100%;"> 
        <table width="100%">
            <tr>
                <td></td>
                <td align="right">
                    <table>
                        <tr>
                            <td>วันที่ &nbsp;</td>
                            <td>
                                <telerik:RadDatePicker ID="rd_APPROVE_DATE" runat="server" Culture="th-TH" Skin="Office2010Blue">
                                    <Calendar Skin="Office2010Blue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="ตรวจสอบ" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td colspan="2">

                    <table width="100%">

                        <tr>
                            <td>
                                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
    <uc1:UC_Disburse_Cure_Study_Receive_List ID="UC_Disburse_Cure_Study_Receive_List1" runat="server" />
                            </td>
                        </tr>
  
                    </table>

                </td>
            </tr>
        </table>
    </div>    
    
    <div id="dialog_edit" title="เพิ่มเลขบ." style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>

    <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    ตรวจสอบรับเรื่อง
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

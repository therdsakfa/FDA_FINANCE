<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Print_E_Receipt.aspx.vb" Inherits="FDA_FINANCE.Frm_Print_E_Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    <%--<link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> --%>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jquery.blockUI.js"></script>
    
<%--
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>--%>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ctl00_ContentPlaceHolder1_btn_Insert').click(function () {
                var bgid = getQuerystring('bgid');
                var bgYear = getQuerystring('myear');
                var select_dept = getQuerystring('dept');
                Popups('Frm_Maintain_ReceiveMoney_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&t=2');
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

            showdate($("#txt_date"));
        });
        $(function () {
            $('#<%= btn_search.ClientID%>').click(function () {
                $.blockUI({ message: 'กรุณารอสักครู่....' });
            });
        });

        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f3'); // ID ของ iframe   
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
    

    <div class="panel panel-body"  style="width:100%;"> 
        <h3>รายการตรวจสอบการชำระเงินผ่านธนาคาร</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>
    <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
        <tr>
            <td align="center">
                <asp:CheckBox ID="cb_type" runat="server" Text="ใบเสร็จ ม.44" />
                &nbsp;&nbsp;
                วันที่ตรวจสอบ
                <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" AllowMultiRowSelection="true" AllowFilteringByColumn="true">
                    <MasterTableView>
                        <Columns>
                            
                            <telerik:GridClientSelectColumn UniqueName="chk_col" ></telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn UniqueName="RECEIVE_MONEY_ID" Display="false" HeaderText="RECEIVE_MONEY_ID" DataField="RECEIVE_MONEY_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="feeno_format" HeaderText="เลขใบสั่งชำระ" DataField="feeno_format">
                            </telerik:GridBoundColumn>
                          <%--  <telerik:GridBoundColumn UniqueName="MONEY_RECEIVE_DATE" HeaderText="วันที่ชำระเงิน" DataField="MONEY_RECEIVE_DATE" DataType="System.DateTime" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="ref01" HeaderText="REF01" DataField="ref01">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ref02" HeaderText="REF02" DataField="ref02">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MONEY_RECEIVE_DATE" HeaderText="วันที่ตรวจสอบ" DataField="MONEY_RECEIVE_DATE" DataType="System.DateTime" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="STATUS_FEE" HeaderText="สถานะ" DataField="STATUS_FEE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="amount_scb" HeaderText="จำนวนเงิน" DataField="amount_scb" DataType="System.Double" DataFormatString="{0:###,###.##}">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_receipt" CommandName="_receipt" Text="พิมพ์ใบเสร็จ">

                            </telerik:GridButtonColumn>
                            <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_cancel" CommandName="_cancel" Text="ยกเลิก" ConfirmText="คุณต้องการยกเลิกรายการนี้ รวมถึงใบเสร็จ?">

                            </telerik:GridButtonColumn>--%>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings Selecting-AllowRowSelect="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    </div>
    <%--<div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกการรับเงิน<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    แก้ไขการรับเงิน
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
                    ใบเสร็จรับเงิน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f3" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>--%>
    <%--<div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>--%>

    </form>
</body>
</html>

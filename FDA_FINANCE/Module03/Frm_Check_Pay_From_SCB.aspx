<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node_E.Master" CodeBehind="Frm_Check_Pay_From_SCB.aspx.vb" Inherits="FDA_FINANCE.Frm_Check_Pay_From_SCB" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

           // showdate($("#ctl00_ContentPlaceHolder1_txt_date"));
        });
        $(function () {
            $('#<%= btn_check.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
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
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;"> 
        <h3>รายการตรวจสอบการชำระเงินผ่านธนาคาร</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>
    <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
        <tr>
            <td></td>
            <td align="right">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:FileUpload ID="FileUpload1" runat="server"/>
                        </td>
                        <td>
                            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลด"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                
                
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                วันที่ตรวจสอบ
                <asp:TextBox ID="txt_date" runat="server" Enabled="false"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                ผู้ตรวจสอบ
               <%-- <asp:DropDownList ID="ddl_receiver" runat="server" style="display:none;">
                </asp:DropDownList>--%>

                <asp:Label ID="lbl_receiver" runat="server" Text="-"></asp:Label>
                <asp:Button ID="btn_check" runat="server" Text="ตรวจสอบข้อมูลและออกใบเสร็จ" />
<asp:Button ID="btn_insert" runat="server" Text="ดึงข้อมูลใบเสร็จ" />
            </td>
            
        </tr>
        <tr>
            <td colspan="2" align="right">
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" AllowMultiRowSelection="true" AllowFilteringByColumn="true">
                    <MasterTableView>
                        <Columns>
                            
                            <telerik:GridClientSelectColumn UniqueName="chk_col" ></telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn UniqueName="IDA" Display="false" HeaderText="IDA" DataField="IDA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="feeno_format" HeaderText="เลขใบสั่งชำระ" DataField="feeno_format">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DATA_DATE" HeaderText="วันที่ชำระเงิน" DataField="DATA_DATE" DataType="System.DateTime" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ref01" HeaderText="REF01" DataField="ref01">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ref02" HeaderText="REF02" DataField="ref02">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CHECK_DATE" HeaderText="วันที่ตรวจสอบ" DataField="CHECK_DATE" DataType="System.DateTime" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="STATUS_FEE" HeaderText="สถานะ" DataField="STATUS_FEE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Print_stat" HeaderText="สถานะพิมพ์" DataField="Print_stat">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="amount_scb" HeaderText="จำนวนเงิน" DataField="amount_scb" DataType="System.Double" DataFormatString="{0:###,###.##}">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_receipt" CommandName="_receipt" Text="พิมพ์ใบเสร็จ">

                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_cancel" CommandName="_cancel" Text="ยกเลิก" ConfirmText="คุณต้องการยกเลิกรายการนี้ รวมถึงใบเสร็จ?">

                            </telerik:GridButtonColumn>
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
</asp:Content>
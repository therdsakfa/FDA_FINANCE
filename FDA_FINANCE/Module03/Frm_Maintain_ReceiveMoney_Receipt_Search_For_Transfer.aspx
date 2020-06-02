<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_ReceiveMoney_Receipt_Search_For_Transfer.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReceiveMoney_Receipt_Search_For_Transfer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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

            $('#ctl00_ContentPlaceHolder1_btn_Insert').click(function () {
                var bgid = getQuerystring('bgid');
                var bgYear = getQuerystring('myear');
                var select_dept = getQuerystring('dept');
                Popups('Frm_Maintain_ReceiveMoney_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&t=2');
                return false;
            });

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
    <div class="panel panel-body" style="width: 100%;">
        <h3>ดึงข้อมูลใบสั่งชำระระบบ Privus ไปออกใบเสร็จรับเงินในระบบโลจิสติกส์ (ฝ่ายการคลัง)</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" />
    </div>
    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">เลขที่ใบสั่งชำระ : 
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY1" runat="server" Width="90px" style="display:none;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY2" runat="server" Width="90px"></asp:TextBox>
                            </td>
                            <td align="right">หน่วยงาน</td>
                            <td>
                                <asp:DropDownList ID="ddl_department" runat="server" DataTextField="DEPARTMENT_NAME" DataValueField="DVCD" Width="200px">
                    </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btn_Search" runat="server" Text="ค้นหาใบสั่งชำระ" CssClass="btn-lg" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="right">ได้รับเงินจาก :</td>
                            <td>
                                <asp:DropDownList ID="ddl_lcn" runat="server" DataTextField="thanm" DataValueField="lctnmcd" Width="200px">
                    </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
              
            </tr>
        </table>
    </div>
    <div class="panel panel-body" style="width: 100%;">
 <telerik:radgrid ID="rg_receive" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" Width="100%">
                    </telerik:radgrid>
        </div>
   <%-- <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    ใบเสร็จรับเงิน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
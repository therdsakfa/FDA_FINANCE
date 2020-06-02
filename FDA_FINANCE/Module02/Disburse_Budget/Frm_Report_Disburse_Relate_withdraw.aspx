<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Report_Disburse_Relate_withdraw.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_Disburse_Relate_withdraw" %>

<%@ Register Src="~/Module02/Disburse_Budget/UserControl/Uc_Report_Disburse_Relate_withdraw.ascx" TagPrefix="uc1" TagName="Uc_Report_Disburse_Relate_withdraw" %>



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

        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }

        //function refresh() {
        //    document.getElementById("ContentPlaceHolder1_btnRedirect").click();
        //}
        function refresh() {
            //document.getElementById("ContentPlaceHolder1_btnRedirect").click();
            $('#ctl00_ContentPlaceHolder1_btnRedirect').click();
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-body" style="width: 100%;">
        <h3>รายงานหักภาษี ณ ที่จ่าย</h3>
    </div>

  
    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">

            <tr>
                <td>
                    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" />
                    <uc1:Uc_Report_Disburse_Relate_withdraw runat="server" id="Uc_Report_Disburse_Relate_withdraw1" />
               
                </td>
            </tr>
        </table>
    </div>
    <div id="dialog_edit" title="บันทึกเลข ขบ." style="display: none">
        <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกรับเรื่องเบิก
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
                    บันทึกฏีกาเบิกเงินงบประมาณ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


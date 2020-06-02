<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_Insert" MaintainScrollPositionOnPostback="true" %>


<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor_Information.ascx" tagname="UC_Maintain_ReturnMoney_Debtor_Information" tagprefix="uc2" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor_Show_Grid.ascx" tagname="UC_Maintain_ReturnMoney_Debtor_Show_Grid" tagprefix="uc3" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Detail.ascx" tagname="UC_Maintain_ReturnMoney_Detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Jsdate/ui.datepicker.js" type="text/javascript"></script>
    <script src="../Jsdate/ui.datepicker-th.js" type="text/javascript"></script>
    <script src="../Jsdate/Jsdatemain.js" type="text/javascript"></script>

    <link href="../css/css_main.css" rel="stylesheet" />
    
        <script type="text/javascript" >
            $(document).ready(function () {
                function CloseSpin() {
                    $('#spinner').toggle('slow');
                }
                function Popups(url) { // สำหรับทำ Div Popup

                    $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                    var i = $('#f1'); // ID ของ iframe   
                    i.attr("src", url); //  url ของ form ที่จะเปิด
                }
                showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_return_date"));
                showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_DOC_DATE"));
                showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_today_date"));

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
    <%--<script src="../Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />

    <script src="../Jsdate/ui.datepicker.js" type="text/javascript"></script>
    <script src="../Jsdate/ui.datepicker-th.js" type="text/javascript"></script>
    <script src="../Jsdate/Jsdatemain.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_return_date"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_DOC_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail1_txt_today_date"));
            //if document.getElementById("#ctl00_ContentPlaceHolder1_UC_Maintain_ReturnMoney_Detail_txt_today_date") {

            //}

            //jQuery("#aspnetForm").validationEngine();
        });
        
        $(function () {
            $('#<%= btn_save.ClientID%>').click(function () {
                 $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
             });
         });

        function insert_k(url) {
            var d_insert = $("#dialog_insert");
            d_insert.dialog({
                autoOpen: true,
                height: 700,
                width: 800,
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
                width: 800,
                modal: true
            });
            openform(url, "#1234");
            return false;
        }


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
    
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <asp:RadioButtonList ID="rdl_Paytype_main" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Value="1">เงินงบประมาณ</asp:ListItem>
                    <asp:ListItem Value="2">เงินทดรอง</asp:ListItem>
                    <asp:ListItem Value="3">เงินรายได้แผ่นดิน</asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr>
            <td>
                <div class="panel panel-body"  style="width:100%;">
                <uc2:UC_Maintain_ReturnMoney_Debtor_Information ID="UC_Maintain_ReturnMoney_Debtor_Information1" runat="server" />
                    </div>
            </td>
        </tr>
       </table>
    <div class="panel panel-body"  style="width:100%;">
    <table width="100%">
        <tr>
            <td >
                
                <uc1:UC_Maintain_ReturnMoney_Detail ID="UC_Maintain_ReturnMoney_Detail1" runat="server" />
                    
            </td>
        </tr>
         <tr>
            <td align="center">
                <asp:Button ID="btn_previous" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"/>
                <%--<asp:Button ID="btn_Add" runat="server" Text="บันทึกข้อมูล" />--%>
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="btn-lg" />
            </td>
        </tr>
        </table>
        </div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%">
        <tr>
            <td>

                <uc3:UC_Maintain_ReturnMoney_Debtor_Show_Grid ID="UC_Maintain_ReturnMoney_Debtor_Show_Grid1" runat="server" />

            </td>
        </tr>
    </table>
        </div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="800px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="800px" height="600px" ></iframe>
    </div>
     <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึก
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
                    แก้ไข
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

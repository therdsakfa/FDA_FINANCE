<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor" %>

<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReturnMoney_Information.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReturnMoney_Information" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Search.ascx" tagname="UC_Maintain_ReturnMoney_Search" tagprefix="uc2" %>


<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor.ascx" tagname="UC_Maintain_ReturnMoney_Debtor" tagprefix="uc3" %>


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

<%--<link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link href="../css/css_main.css" rel="stylesheet" />

    <script type="text/javascript">
        function insert_return(url) {
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

    <style type="text/css">
        .auto-style1
        {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;"> 
        <h3>รายการบันทึกการรับเงินรับคืนเงิน</h3>
        <asp:Button ID="Button1" runat="server" Text="Button" Style="display:none;" />
        </div>
    <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
        <tr>
            <td colspan="2"><asp:RadioButtonList ID="rbl_MoneyType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                <asp:ListItem Value="0" Selected="True">ทั้งหมด</asp:ListItem>
                <asp:ListItem Value="2">เงินงบประมาณ</asp:ListItem>
                <asp:ListItem Value="1">เงินทดรอง</asp:ListItem>
                <asp:ListItem Value="3">เงินรายได้แผ่นดิน</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <table>
                    <tr>
                        <td colspan="2">ค้นหาลูกหนี้เงินยืม</td>
                    </tr>
                    <tr>
                        <td>
                            <uc2:UC_Maintain_ReturnMoney_Search ID="UC_Maintain_ReturnMoney_Search1" runat="server" />
                        </td>
                        <td> &nbsp;
                            <asp:Button ID="btn_Search" runat="server" Text="ค้นหา" Width="90px" CssClass="btn-lg"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        </table>
        </div>
    <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
        <tr>
            <td class="auto-style1">รายชื่อลูกหนี้เงินยืม</td>
            <td class="auto-style1">สถานะการคืนเงิน : 
                <asp:DropDownList ID="dl_MoneyReturnStatus" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">ทั้งหมด</asp:ListItem>
                    <asp:ListItem Value="ยังไม่คืนเงิน">ยังไม่คืนเงิน</asp:ListItem>
                    <asp:ListItem Value="คืนเงินยังไม่ครบ">คืนเงินยังไม่ครบ</asp:ListItem>
                    <asp:ListItem Value="คืนเงินครบแล้ว">คืนเงินครบแล้ว</asp:ListItem>
                    <asp:ListItem Value="คืนเงินเกิน">คืนเงินเกิน</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc3:UC_Maintain_ReturnMoney_Debtor ID="UC_Maintain_ReturnMoney_Debtor1" runat="server" />
            </td>
        </tr>
    </table>
        </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกการรับเงิน
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
                    แก้ไขการรับเงิน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
      <%--<div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>--%>
</asp:Content>

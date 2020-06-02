<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_History.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_History" %>
<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReturnMoney_Information.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReturnMoney_Information" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Search.ascx" tagname="UC_Maintain_ReturnMoney_Search" tagprefix="uc2" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor.ascx" tagname="UC_Maintain_ReturnMoney_Debtor" tagprefix="uc3" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Debtor_History.ascx" tagname="UC_Maintain_ReturnMoney_Debtor_History" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
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


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;"> 
  
    <table width="100%">
        <tr>
                        <td colspan="2">ค้นหาลูกหนี้เงินยืม</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                            <uc2:UC_Maintain_ReturnMoney_Search ID="UC_Maintain_ReturnMoney_Search1" runat="server" />
                        </td>
                        <td>
                            <asp:Button ID="btn_Search" runat="server" Text="ค้นหา" CssClass="btn-lg" />
                        </td>
        </tr>
        </table>
        </div>
    <div class="panel panel-body"  style="width:100%;"> 
    <table width="100%">
       <tr>
            <td colspan="2">
                
                <uc4:UC_Maintain_ReturnMoney_Debtor_History ID="UC_Maintain_ReturnMoney_Debtor_History1" runat="server" />
                
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
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>--%>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_OutsideDebtor.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideDebtor" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>

<%@ Register src="~/Module02/Disburse_Debtor/UserControl/UC_Disburse_Debtor.ascx" tagname="UC_Disburse_Debtor" tagprefix="uc2" %>

<%@ Register src="~/Module05/Disburse_OutsideBudget/UserControl/UC_OutsideBudget_Amount_Detail.ascx" tagname="UC_OutsideBudget_Amount_Detail" tagprefix="uc3" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                var bgYear = getQuerystring('myear');
                var dept = getQuerystring('dept');

                    //Popups("Frm_Disburse_OutsideDebtor_Bill_Insert.aspx?bguse=3&bgid=" + selectVal.toString() + "&bgYear=" + bgYear + "&dept=" + dept); //ใส่ url, ID iframe
                    Popups("../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Insert_V2.aspx?bguse=3&bgid=0&bgYear=" + bgYear + "&dept=" + dept);
                    return false;
            });
                
        });
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
        function k(id, dept) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
           
            var selectVal = combo.get_value();
            openform("../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" + id + "&dept=" + dept + "&bguse=3" + "&bgid=" + selectVal, "#1234");

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
        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("<%= rcb_Moneytype.ClientID%>");
            combo.set_text(node.get_text());
            combo.set_value(node.get_value());
            cancelDropDownClosing = false;
            combo.hideDropDown();


            //}
        }

        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;">
        บันทึกสัญญาลูกหนี้เงินยืมนอกงบประมาณ
        </div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%"><tr> <td> 
            <uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" />
            </td>
        <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg" /></td></tr></table>
          
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
       </div>
     <div class="panel panel-body"  style="width:100%;">
         <telerik:radcombobox ID="rcb_Moneytype" Runat="server" Width="300px" Height="300px" style="display:none;" 
                    EmptyMessage="เลือกประเภทเงิน" AutoPostBack="true" AllowCustomText="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="" />
                        </Items>
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView ID="rtv_money_type" runat="server" 
                                 OnClientNodeClicking="OnClientNodeClickingHandler">
                             </telerik:RadTreeView>
                        </div>
                    </ItemTemplate>
                </telerik:radcombobox>
         </div>

     <div class="panel panel-body"  style="width:100%;">
              
                <uc3:UC_OutsideBudget_Amount_Detail ID="UC_OutsideBudget_Amount_Detail1" runat="server" />
         </div>

     <div class="panel panel-body"  style="width:100%;">
   <table width="100%">
        <tr>
            <td colspan="2">
            
            <table width="100%">
                <tr><td>บันทึกสัญญาลูกหนี้เงินยืมนอกงบประมาณ</td><td align="right">
                    
                    <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" /></td></tr>
            <tr><td colspan="2">
                <uc2:UC_Disburse_Debtor ID="UC_Disburse_Debtor1" runat="server" />
            </td></tr>
            
            </table>
               
            </td>
        </tr>
    </table>
         </div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกเบิกจ่าย
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
                    แก้ไขเบิกจ่าย
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
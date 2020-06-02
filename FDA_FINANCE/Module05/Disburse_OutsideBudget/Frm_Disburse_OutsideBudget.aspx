<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_OutsideBudget.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideBudget" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>

<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Disburse_Budget.ascx" tagname="UC_Disburse_Budget" tagprefix="uc2" %>

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
    <%--<script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe

                //X เพิ่มนะ
                //var e = document.getElementById("ctl00_ContentPlaceHolder1_rcb_Moneytype");
                //var selectVal = e.options[e.selectedIndex].value;
                var combo = $find("<%= rcb_Moneytype.ClientID%>");
                var selectVal = combo.get_value();
                var bg = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = bg.options[bg.selectedIndex].value;
                var d = document.getElementById("ctl00_ContentPlaceHolder1_dd_Department");
                var select_dept = d.options[d.selectedIndex].value;
                //
                if (selectVal != '') {
                    d_insert.dialog({
                        autoOpen: true,
                        height: 700,
                        width: 1000,
                        modal: true
                    });
                    d_insert.dialog("open");
                    openform("../../Module05/Disburse_OutsideBudget/Frm_Disburse_OutsideBudget_Bill_Insert.aspx?bguse=3&bgid=" + selectVal + "&bgYear=" + bgYear + "&dept=" + select_dept, "#if1"); //ใส่ url, ID iframe
                }
                else {
                    alert('กรุณาเลือกประเภทเงินนอก'); return false;
                }

                return false;
            });
        });

        function k(id, bg_id, bgYear) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            openform("Frm_Disburse_OutsideBudget_Bill_Edit.aspx?bguse=3&bid=" + id + "&bgid=" + bg_id + "&bgYear=" + bgYear, "#1234");
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
    </script>--%>
    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                var bgid = getQuerystring('bgid');
                var bgYear = getQuerystring('myear');
                //var select_dept = getQuerystring('dept');


                var combo = $find("<%= rcb_Moneytype.ClientID%>");
                var selectVal = combo.get_value();
                //var d = document.getElementById("ctl00_ContentPlaceHolder1_dd_Department");
                //var select_dept = d.options[d.selectedIndex].value;

                //if (selectVal != '') {
                //Popups('Frm_Disburse_OutsideBudget_Bill_Insert.aspx?bgid=' + selectVal + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&bguse=3');
                Popups('../../Module02/Disburse_Budget/Frm_Disburse_Budget_Bill_Insert_V2.aspx?bgid=' + selectVal.toString() + '&bgYear=' + bgYear.toString() + '&bguse=3');
                //Popups('Frm_Disburse_OutsideBudget_Bill_Insert.aspx?bgid=' + selectVal + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&bguse=3');

                //}
                //else {
                //    alert('กรุณาเลือกประเภทเงินนอก'); return false;
                //}

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
            function refresh() {
                //document.getElementById("ContentPlaceHolder1_btnRedirect").click();
                $('#ctl00_ContentPlaceHolder1_btnRedirect').click();
                //$('#ctl00_ContentPlaceHolder1_btnRedirect').click();
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
            document.getElementById("ctl00_ContentPlaceHolder1_btnRedirect").click();
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
    <div class="panel panel-body"  style="width:100%;padding-left:5%;">
                <h3><font color="black">การเบิกจ่ายนอกงบประมาณ</font></h3>
</div>
     <div class="panel panel-body"  style="width:100%;">
        <table><tr> <td>  <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            <uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" />
            </td>
        <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg" /></td></tr></table>
      </div>
    <div class="panel panel-body"  style="width:100%;">    
<table>
<tr>
    <td colspan="2">
        <br/>
        บัญชี&nbsp;
                <%--<asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID">
                </asp:DropDownList>--%>

   <telerik:RadComboBox ID="rcb_Moneytype" Runat="server" Width="300px" Height="300px" 
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
                </telerik:RadComboBox>
   </td>
    </tr>
    </table>
        </div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%">
        <tr>
            <td colspan="2">
                <asp:UpdatePanel runat="server" id="UpdatePanel" updatemode="Conditional">
            <ContentTemplate>
                <uc3:UC_OutsideBudget_Amount_Detail ID="UC_OutsideBudget_Amount_Detail1" runat="server" />
                </ContentTemplate>
        </asp:UpdatePanel>
            </td>
        </tr>
            </table>
        </div>

    <div class="panel panel-body"  style="width:100%;">
    <table width="100%">
        <tr>
            <td colspan="2">
            
            <table width="100%">
                <tr>
                    <td>บันทึกการเบิกจ่ายนอกงบประมาณ</td><td align="right" colspan="2">
                            <table>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />
                                    </td>
                                </tr>
                            </table>


                            <asp:Button ID="Button1" runat="server" Style="display: none;" Text="Button" />

                        </td>


                </tr>
            <tr><td colspan="2">
 
                <uc2:UC_Disburse_Budget ID="UC_Disburse_Budget1" runat="server" />
 
                </td></tr>
            
            </table>
               
            </td>
        </tr>
    </table>
        </div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกเบิกจ่าย<button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
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
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
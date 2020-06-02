<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_OutsideDebtor_Overview.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideDebtor_Overview" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>
<%@ Register src="~/Module05/Disburse_OutsideBudget/UserControl/UC_OutsideBudget_Amount_Detail.ascx" tagname="UC_OutsideBudget_Amount_Detail" tagprefix="uc3" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="UserControl/UC_Disburse_OutsideDebtor_With_Approve.ascx" tagname="UC_Disburse_OutsideDebtor_With_Approve" tagprefix="uc4" %>
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
            
                //var selectVal = combo.get_value();
                //if (selectVal != '') {
                    //Popups("Frm_Disburse_OutsideDebtor_Bill_Insert.aspx?bguse=3&bgid=" + selectVal.toString() + "&bgYear=" + bgYear + "&dept=" + dept); //ใส่ url, ID iframe
                    Popups("../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Insert_V2.aspx?bguse=3&bgid=0&bgYear=" + bgYear + "&dept=" + dept);
                    
                //}
                //else {
                //    alert('กรุณาเลือกประเภทเงินนอก'); return false;
                //}
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
           
            //var selectVal = combo.get_value();
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
    <table width="100%">
         <tr>
    <td colspan="2">
        หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true" Font-Names="TH SarabunPSK" Font-Size="14">

            </asp:DropDownList> <br/>
       <%-- ประเภทเงิน&nbsp;

   <telerik:radcombobox ID="rcb_Moneytype" Runat="server" Width="300px" Height="300px" 
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
                </telerik:radcombobox>--%>
   </td>
    </tr>
        </table>
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
                    <table>
                            <tr>
                                <td>วันที่ &nbsp;</td>
                                <td>
                                    <telerik:RadDatePicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH" Skin="Office2010Blue">
                                        <Calendar skin="Office2010Blue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                        <asp:ListItem Value="1">อนุมัติ</asp:ListItem>
                                        <asp:ListItem Value="2">ไม่อนุมัติ(กรอกเหตุผล)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="การอนุมัติ"/>
                                    <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล"   CssClass="btn-lg"/>
                                </td>
                            </tr>
                        </table></td></tr>
            <tr><td colspan="2">
                <uc4:UC_Disburse_OutsideDebtor_With_Approve ID="UC_Disburse_OutsideDebtor_With_Approve1" runat="server" />
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
                    บันทึกข้อมูลลูกหนี้เงินนอก
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
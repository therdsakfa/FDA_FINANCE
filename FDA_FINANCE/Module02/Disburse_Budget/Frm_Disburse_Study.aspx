<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Study.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Study" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="UserControl/UC_Disburse_Cure_Study.ascx" tagname="UC_Disburse_Cure_Study" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Search_From_Cure_Study.ascx" tagname="UC_Search_From_Cure_Study" tagprefix="uc1" %>
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

                $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                    var bgid = getQuerystring('bgid');
                    var bgYear = getQuerystring('myear');
                    var select_dept = getQuerystring('dept');
                    Popups('Frm_Disburse_Cure_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + "&g=8&stat=1");
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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;padding-left:5%;">
        การเบิกจ่ายค่าเล่าเรียนบุตร</div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%">
            <tr>
                <td>

                    <uc1:UC_Search_From_Cure_Study ID="UC_Search_From_Cure_Study1" runat="server" />

                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px"
                        Height="55px" /></td>
            </tr>
        </table>
        <asp:Button ID="btn_del" runat="server" Text="Button" Style="display: none;" />
            <asp:TextBox ID="txt_id" runat="server" Style="display:none;" ></asp:TextBox>
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>

<div class="panel panel-body"  style="width:100%;">            
            <table width="100%">
                <tr><td>บันทึกเบิกจ่ายค่าเล่าเรียนบุตร</td><td align="right">
                    <table>
                        <tr>
                            <td>วันที่ &nbsp;</td>
                            <td>
                                
                                <telerik:RadDatePicker ID="rd_APPROVE_DATE" runat="server" Culture="th-TH" Skin="Office2010Blue">
                                    <Calendar Skin="Office2010Blue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
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
                                <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="การอนุมัติ" />
                                <asp:Button ID="btn_Add" runat="server" CssClass="btn-lg" Text="เพิ่มข้อมูล" />
                            </td>
                        </tr>
                    </table>
                    </td></tr>
            <tr><td colspan="2">
                <uc2:UC_Disburse_Cure_Study ID="UC_Disburse_Cure_Study1" runat="server" />
            </td></tr>
            
            </table>
  </div>             
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกค่าเล่าเรียนบุตร
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
                    แก้ไขค่าเล่าเรียนบุตร
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>

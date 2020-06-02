<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_PO_Overview.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_PO_Overview" %>
<%@ Register src="UserControl/UC_Disburse_PO.ascx" tagname="UC_Disburse_PO" tagprefix="uc1" %>

<%@ Register src="UserControl/UC_Budget_Amount_Detail.ascx" tagname="UC_Budget_Amount_Detail" tagprefix="uc2" %>

<%@ Register src="UserControl/UC_Search_Form_with_description.ascx" tagname="UC_Search_Form_with_description" tagprefix="uc4" %>

<%@ Register src="UserControl/UC_Disburse_PO_With_Approve.ascx" tagname="UC_Disburse_PO_With_Approve" tagprefix="uc3" %>
<%@ Register src="../../UC/UC_Project_Information.ascx" tagname="UC_Project_Information" tagprefix="uc5" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--        function k(id, bgid, bgYear) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });

            //var e = document.getElementById("ctl00_dd_BudgetYear");
            //var bgYear = e.options[e.selectedIndex].value;
            openform("Frm_Disburse_PO_edit.aspx?bid=" + id + "&bgid=" + bgid + "&bgYear=" + bgYear, "#1234");
            return false;
        }--%>
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

                $('#ctl00_ContentPlaceHolder1_btn_insert').click(function () {
                    var bgid = getQuerystring('bgid');
                    var bgYear = getQuerystring('myear');
                    var select_dept = getQuerystring('dept');
                    Popups('Frm_Disburse_PO_Offline_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString());
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
                <h3><font color="black">จัดซื้อจัดจ้าง</font></h3>
</div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%"><tr> <td> 
            <uc4:UC_Search_Form_with_description ID="UC_Search_Form_with_description1" runat="server" />
            

                    </td>
        <td><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px"  CssClass="btn-lg"/></td></tr></table>

        </div>
 <div class="panel panel-body"  style="width:100%;display:none;">
                <uc5:uc_project_information ID="UC_Project_Information1" runat="server" />
                <uc2:UC_Budget_Amount_Detail ID="UC_Budget_Amount_Detail1" runat="server" />
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </div>
     <div class="panel panel-body"  style="width:100%;">
    <table width="100%">
                <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            

                            หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" AutoPostBack="true" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID">
                            </asp:DropDownList>

                        </td>
                    </tr>
                <tr>
                        <td>
                            <asp:RadioButtonList ID="rdl_approve" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="" Selected="True">ทั้งหมด</asp:ListItem>
                                <asp:ListItem Value="1">อนุมัติ</asp:ListItem>
                                <asp:ListItem Value="2">ยังไม่อนุมัติ</asp:ListItem>
                            </asp:RadioButtonList>

                        </td>
                        <td align="right">
                            

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
                                        <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" style="display:none;" />
                                    </td>
                                </tr>
                            </table>


                            <asp:Button ID="Button1" runat="server" Style="display: none;" Text="Button" />

                        </td>
                    </tr>
            <tr>
                <td colspan="2">
                <uc3:UC_Disburse_PO_With_Approve ID="UC_Disburse_PO_With_Approve1" runat="server" />
                </td></tr>
            
            </table>
</div>
    
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกจัดซื้อจัดจ้าง<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    แก้ไขจัดซื้อจัดจ้าง
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

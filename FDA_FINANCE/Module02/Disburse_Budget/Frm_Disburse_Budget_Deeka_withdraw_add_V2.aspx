<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Budget_Deeka_withdraw_add_V2.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Deeka_withdraw_add_V2" %>

<%@ Register src="UserControl/UC_deeka_withdraw_add_Show_v2.ascx" tagname="UC_deeka_withdraw_add_Show_v2" tagprefix="uc1" %>

<%--<%@ Register src="../../UC/UC_Project_Information.ascx" tagname="UC_Project_Information" tagprefix="uc5" %>--%>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc2" %>

<%@ Register src="UserControl/UC_Budget_Amount_Detail.ascx" tagname="UC_Budget_Amount_Detail" tagprefix="uc2" %>

<%--<%@ Register src="UserControl/UC_Disburse_Budget_With_Approve.ascx" tagname="UC_Disburse_Budget_With_Approve" tagprefix="uc3" %>--%>

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
                    //var bgid = getQuerystring('bgid');
                    //var bgYear = getQuerystring('myear');
                    //var select_dept = getQuerystring('dept');
                    //var dd = document.getElementById("ctl00_ContentPlaceHolder1_dd_Department");
                    //var select_dept = dd.options[dd.selectedIndex].value;
                    //Popups('Frm_Disburse_Budget_Deeka_withdraw_Insert.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&own=1&bguse=1');
                    Popups('Frm_Disburse_Budget_Deeka_withdraw_Insert_v2.aspx');

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
      <div class="panel panel-body"  style="width:100%;padding-left:5%;">
                <h3><font color="black">เบิกเงินฏีกา</font></h3>
</div>
           <div class="panel panel-body"  style="width:100%;">
        <table><tr> <td> </td>
        <td valign="middle">
            
            </td></tr></table>
          </div>
            
        <div class="panel panel-body"  style="width:100%;display:none;">
            <%--<uc5:uc_project_information ID="UC_Project_Information1" runat="server" />         
            <uc2:uc_budget_amount_detail ID="UC_Budget_Amount_Detail1" runat="server" />--%>

</div>
            <div class="panel panel-body"  style="width:100%;">
                <table width="100%">
                   <tr>
                       <td>
                           <uc2:uc_search_form ID="UC_Search_Form1" runat="server" />
                       </td>
                       <td>
                                        <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg"
                Height="55px" />
                                        <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />
                       </td>
                   </tr>
                    <tr>
                        <td>
                            
                            <%--<uc3:UC_Disburse_Budget_With_Approve ID="UC_Disburse_Budget_With_Approve1" runat="server" />--%>
                            <uc1:UC_deeka_withdraw_add_Show_v2 ID="UC_deeka_withdraw_add_Show_v21" runat="server" />
                        </td>
                    </tr>
                            </table>


                            <asp:Button ID="btnRedirect" runat="server" Style="display: none;" Text="Button" />

                       
</div>
    
    <div id="dialog_edit" title="แก้ไขข้อมูลผูกพัน" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="บันทึกข้อมูลผูกพัน" style="display:none">  
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
    <div class="modal fade" id="myModal3">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    กรอกเหตุผล การไม่อนุมัติ
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f3" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

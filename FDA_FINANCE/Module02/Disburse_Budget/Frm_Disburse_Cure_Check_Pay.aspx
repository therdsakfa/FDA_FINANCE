﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Cure_Check_Pay.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Cure_Check_Pay" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc3" %>
<%@ Register src="UserControl/UC_Disburse_Cure_Study_Check_Pay.ascx" tagname="UC_Disburse_Cure_Study_Check_Pay" tagprefix="uc1" %>
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

        function refresh() {
            document.getElementById("ContentPlaceHolder1_btnRedirect").click();
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel panel-body"  style="width:100%;">
       <h3>เสนอเซ็นเช็ค</h3>
       </div> 
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%"><tr><td>   <uc3:UC_Search_Form ID="UC_Search_Form1" runat="server" /></td>
        <td> 
            <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" />
            <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg" /></td></tr></table>
    </div>     

<div class="panel panel-body"  style="width:100%;">           
<table width="100%">
    <tr>
        <td>
            
            <table width="100%">
                <tr>
                    <td align="right">
                        <table>
                        <tr>
                            <td align="right">วันที่ &nbsp;</td>
                            <td>
                                <telerik:raddatepicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH" Skin="Office2010Blue">
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
                                </telerik:raddatepicker>
                            </td>
                            <td>
                                <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="จ่ายเช็ค" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
                <tr>
                    <td>                            
     
                        <uc1:UC_Disburse_Cure_Study_Check_Pay ID="UC_Disburse_Cure_Study_Check_Pay1" runat="server" />
     
                    </td>
                </tr>
             
            </table>

        </td>
    </tr>

        </table>

  
    </div>

    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกใบหักภาษี<button class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    บันทึกใบหักภาษี
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

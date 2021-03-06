﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Debtor.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Debtor" EnableEventValidation="false" %>
<%@ Register src="../Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>
<%@ Register src="../Disburse_Budget/UserControl/UC_Budget_Amount_Detail.ascx" tagname="UC_Budget_Amount_Detail" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Disburse_Debtor.ascx" tagname="UC_Disburse_Debtor" tagprefix="uc3" %>
<%@ Register src="../../UC/UC_Project_Information.ascx" tagname="UC_Project_Information" tagprefix="uc4" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
                Popups('../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Insert_V2.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString() + '&bguse=1');
                return false;
            });
            //openform("../../Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill_Edit.aspx?bid=" + id + "&dept=" + dept + "&bgid=" + bgid +"&bguse=1", "#1234");
            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
               // $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                $('#ContentPlaceHolder1_btnRedirect').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
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
            //document.getElementById("ContentPlaceHolder1_btnRedirect").click();
            $('#ctl00_ContentPlaceHolder1_btnRedirect').click();
        }
        </script> 
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;padding-left:5%;">
                <h3><font color="black">ลูกหนี้เงินยืม</font></h3>
</div>
    <div class="panel panel-body"  style="width:100%;">
        <table><tr> <td> <uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" /></td>
        <td valign="middle">
            
            <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg"
                Height="55px" /></td></tr></table>
          </div>
            
        <div class="panel panel-body"  style="width:100%;display:none;">
            <uc4:UC_Project_Information ID="UC_Project_Information1" runat="server" />
          

            <uc2:UC_Budget_Amount_Detail ID="UC_Budget_Amount_Detail1" runat="server" />

</div>
        
<div class="panel panel-body"  style="width:100%;">
            <table width="100%">
                <tr><td>บันทบันทึกสัญญาลูกหนี้เงินยืม<asp:Button ID="btnRedirect" runat="server" Style="display: none;" Text="Button" />
                    </td><td align="right" class="auto-style1"></td></tr>
                <tr><td>
                    <asp:RadioButtonList ID="rdl_approve" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="">ทั้งหมด</asp:ListItem>
                        <asp:ListItem Value="1">อนุมัติ</asp:ListItem>
                        <asp:ListItem Value="2">ยังไม่อนุมัติ</asp:ListItem>
                    </asp:RadioButtonList>
                    </td><td align="right">
                        
                        <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดสัญญา" CssClass="btn-lg" style="display:none;"   />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดสัญญา" CssClass="btn-lg"  style="display:none;" /> &nbsp;&nbsp;
                        <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />


                         </td></tr>
            <tr><td colspan="2">
                <uc3:UC_Disburse_Debtor ID="UC_Disburse_Debtor1" runat="server" />
            </td></tr>
            
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
                    บันทึกลูกหนี้เงินยืม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
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
                    แก้ไขลูกหนี้เงินยืม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

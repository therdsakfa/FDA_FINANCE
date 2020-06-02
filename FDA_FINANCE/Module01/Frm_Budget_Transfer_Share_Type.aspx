<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Budget_Transfer_Share_Type.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Transfer_Share_Type" %>

<%@ Register src="UserControl/UC_Budget_Transfer_Share_Type.ascx" tagname="UC_Budget_Transfer_Share_Type" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                //X เพิ่มนะ
                //var dd = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetAdjust");
                //var selectVal = dd.options[dd.selectedIndex].value;
                //var e = document.getElementById("ctl00_dd_BudgetYear");
                //var bgYear = e.options[e.selectedIndex].value;
                //var tid = qsParm(1)
                var tid = getQuerystring('tid');
                //
                d_insert.dialog("open");
                openform("Frm_Budget_Transfer_Share_Type_Insert.aspx?tid=" + tid, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

        //ฟังชั่นดึงคิวรี่สตริง
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


        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 900,
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
        <table width="900px">
<tr>
<td>
    แจกแจงโอนเบิกแทน</td>
</tr>
<%--<tr>
<td>

ชื่องบประมาณจัดสรร &nbsp;
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
                </asp:DropDownList>
                </td>
</tr>--%>
<tr>
<td align="right">
    <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" />
    <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" />
</td>
</tr>
        <tr>
            <td>
              
               <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
              
               
              
                <uc1:UC_Budget_Transfer_Share_Type ID="UC_Budget_Transfer_Share_Type1" runat="server" />
              
               
              
            </td>
        </tr>
    </table>
     <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>
</asp:Content>

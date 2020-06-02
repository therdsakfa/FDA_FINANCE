<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Budget_Add_Project.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Add_Project" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>

  <%--  <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>--%>
    <link href="../../css/css_main.css" rel="stylesheet" />
  
    <script type="text/javascript" >
        $(document).ready(function () {
            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
                var bgid = getQuerystring('bgid');
                var bgYear = getQuerystring('myear');
                //var select_dept = getQuerystring('dept');
                var dd = document.getElementById("ctl00_ContentPlaceHolder1_dd_Department");
                var select_dept = dd.options[dd.selectedIndex].value;
                //alert('55555555555');
                //Popups('Frm_Disburse_Relate_Insert2.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString());
                Popups('Frm_Disburse_Relate_InsertV2.aspx?bgid=' + bgid.toString() + '&bgYear=' + bgYear.toString() + '&dept=' + select_dept.toString());
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
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
            //$('#ctl00_ContentPlaceHolder1_btnRedirect').click();
        }
        </script> 
<style type="text/css">
    .auto-style1 {
        height: 23px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body" style="width: 100%;">
        <h3>เพิ่มโครงการ/กิจกรรม</h3>
    </div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%">
            <tr>
                <td align="right">งบประมาณปี </td>
                <td>
                    <asp:DropDownList ID="dd_BudgetYear" runat="server" Width="100px" AutoPostBack="true">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    แผนงาน 
                </td>
                <td>
                   <asp:DropDownList ID="ddl_plan" runat="server" Width="200px" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ผลผลิต</td>
                <td>
                    <asp:DropDownList ID="ddl_product" runat="server" Width="200px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    กิจกรรมหลัก</td>
                <td>
                    <asp:DropDownList ID="ddl_act" runat="server" Width="200px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table>
    </div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%">
            <tr>
                <td align="right">
                    รหัสโครงการ/กิจกรรม
                </td>
                <td>
                    <asp:TextBox ID="txt_bg_code" runat="server"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td align="right">
                    ชื่อโครงการ/กิจกรรม</td>
                <td>
                    <asp:TextBox ID="txt_proj_name" runat="server" Width="500px"></asp:TextBox>
                </td>
                </tr>
            <tr>
                <td align="right" class="auto-style1">
                    หมวดงบ</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>งบดำเนินงาน</asp:ListItem>
                        <asp:ListItem>งบเงินอุดหนุน</asp:ListItem>
                        <asp:ListItem>งบบุคลากร</asp:ListItem>
                        <asp:ListItem>งบรายจ่ายอื่น</asp:ListItem>
                        <asp:ListItem>งบลงทุน</asp:ListItem>
                    </asp:DropDownList>
                </td>
                </tr>
            <tr>
                <td align="right">
                    หน่วยงาน</td>
                <td>
                    <asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID">
                    </asp:DropDownList>
                </td>
                </tr>
            <tr>
        <td align="right">เลขที่เอกสาร </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server" Text="-"></asp:TextBox>
        </td>
    </tr>
            <tr>
        <td align="right">วันที่เอกสาร&nbsp;</td>
        <td>
            <asp:TextBox ID="txt_doc_date" runat="server"></asp:TextBox>
        </td>
    </tr>
            <tr>
                <td align="right">
                    จำนวนเงินงบประมาณ</td>
                <td>
                    <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
                    </telerik:RadNumericTextBox>
                </td>
                </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_save" runat="server" Text="เพิ่มโครงการ/กิจกรรม" />
                </td>
                </tr>
            <tr>
                <td align="right" colspan="2">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10">
                    </telerik:RadGrid>
                </td>
                </tr>
        </table>
    </div>

    <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    กิจกรรมย่อย<button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="refresh()">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

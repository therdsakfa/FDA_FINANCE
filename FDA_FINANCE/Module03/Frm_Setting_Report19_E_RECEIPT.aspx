<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node_E.Master" CodeBehind="Frm_Setting_Report19_E_RECEIPT.aspx.vb" Inherits="FDA_FINANCE.Frm_Setting_Report19_E_RECEIPT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> --%>
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js" type="text/javascript"></script>
    <script src="../Jsdate/ui.datepicker.js" type="text/javascript"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_txt_MONEY_RECEIVE_DATE"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReceiveMoney_Detail_Bank_txt_CHECK_DATE"));
            $("#ctl00_ContentPlaceHolder1_dd_CUSTOMER").searchable();
            $("#ctl00_ContentPlaceHolder1_ddl_abbr_type").searchable();

            $('#ctl00_ContentPlaceHolder1_btn_add').click(function () {
                var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                Popups('Frm_Setting_Report19_Insert.aspx?myear=' + bgYear.toString() + '&e=1');
                return false;
            });

            //$('#ctl00_ContentPlaceHolder1_btn_add2').click(function () {
            //    //var bgYear = getQuerystring('myear');
            //    var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetYear");
            //    var bgYear = e.options[e.selectedIndex].value;
            //    Popups('Frm_Maintain_Receive_Money_V3_Insert.aspx?myear=' + bgYear.toString());
            //    return false;
            //});
            //$('#ctl00_ContentPlaceHolder1_btn_add3').click(function () {
            //    //var bgYear = getQuerystring('myear');
            //    var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetYear");
            //    var bgYear = e.options[e.selectedIndex].value;
            //    Popups('Frm_Maintain_Receive_Money_V3_2_Insert.aspx?myear=' + bgYear.toString());
            //    return false;
            //});

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
            document.getElementById("ContentPlaceHolder1_btn_refresh").click();
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
        <h3>บันทึกนำส่งเงิน</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>

    <div class="panel panel-body" style="width: 100%;">
        <table class="table">
           
            <tr>
                <td align="right">
                    <table style="height:40px;">
                        <tr>
                            <td align="right" style="font-weight:bold;font-size:small;">ปีงบประมาณ :</td>
                            <td>
                                <asp:DropDownList ID="dd_BudgetYear" runat="server" AutoPostBack="true" DataTextField="byear" DataValueField="byear" Width="70px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right">

                    

                    <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูลใบนำส่ง" CssClass="btn-lg"/>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="rg_sending" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" Width="100%">
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    ออกรายงานนำส่งเงิน<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

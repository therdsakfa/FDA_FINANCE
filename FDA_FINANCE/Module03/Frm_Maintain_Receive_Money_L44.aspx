<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node3.Master" CodeBehind="Frm_Maintain_Receive_Money_L44.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_Receive_Money_L44" %>
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
            showdate($("#ctl00_ContentPlaceHolder1_txt_check_date"));
            //showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReceiveMoney_Detail_Bank_txt_CHECK_DATE"));
            $("#ctl00_ContentPlaceHolder1_dd_CUSTOMER").searchable();
            $("#ctl00_ContentPlaceHolder1_ddl_abbr_type").searchable();

            $('#ctl00_ContentPlaceHolder1_btn_add').click(function () {
                var bgYear = getQuerystring('myear');

                Popups('Frm_Maintain_Receive_Money_V2_Insert.aspx?myear=' + bgYear.toString());
                return false;
            });

            $('#ctl00_ContentPlaceHolder1_btn_add2').click(function () {
                //var bgYear = getQuerystring('myear');
                var dd = document.getElementById("ctl00_ContentPlaceHolder1_ddl_receiver");
                var selectVal = dd.options[dd.selectedIndex].value;

                var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetYear");
                var cb = document.getElementById("ctl00_ContentPlaceHolder1_cb_previous").checked;
                var bgYear = e.options[e.selectedIndex].value;
                var c_date = document.getElementById("ctl00_ContentPlaceHolder1_txt_check_date").value;
                if (cb == true) {
                    Popups('Frm_Maintain_Receive_Money_V3_Insert.aspx?myear=' + bgYear.toString() + '&pre=1&date=' + c_date + '&r=' + selectVal + '&law=1');
                } else {
                    Popups('Frm_Maintain_Receive_Money_V3_Insert.aspx?myear=' + bgYear.toString() + '&date=' + c_date + '&r=' + selectVal + '&law=1');
                }



                return false;
            });
            $('#ctl00_ContentPlaceHolder1_btn_add3').click(function () {
                //var bgYear = getQuerystring('myear');
                var dd = document.getElementById("ctl00_ContentPlaceHolder1_ddl_receiver");
                var selectVal = dd.options[dd.selectedIndex].value;

                var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                var c_date = document.getElementById("ctl00_ContentPlaceHolder1_txt_check_date").value;
                var cb = document.getElementById("ctl00_ContentPlaceHolder1_cb_previous").checked;


                if (cb == true) {
                    Popups('Frm_Maintain_Receive_Money_V3_2_Insert.aspx?myear=' + bgYear.toString() + '&pre=1&date=' + c_date + '&r=' + selectVal + '&law=1');
                } else {
                    Popups('Frm_Maintain_Receive_Money_V3_2_Insert.aspx?myear=' + bgYear.toString() + '&date=' + c_date + '&r=' + selectVal + '&law=1');
                }


                //Popups('Frm_Maintain_Receive_Money_V3_2_Insert.aspx?myear=' + bgYear.toString() + '&date=' + c_date);
                return false;
            });

        });
        function alerta() {
            //var cb = document.getElementById("ctl00_ContentPlaceHolder1_cb_previous").checked;
            var aa = document.getElementById("ctl00_ContentPlaceHolder1_txt_check_date").value;
            alert(aa);

            //if (cb == true) {
            //    alert('555');
            //} else {
            //    alert('666');
            //} 


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
        function Popups4(url) { // สำหรับทำ Div Popup

            $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f4'); // ID ของ iframe   
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
        <h3>บันทึกใบเสร็จรับเงิน (ม.44)</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>

    <div class="panel panel-body" style="width: 100%;">
        <table class="table">
            <%--<tr>
                <td align="right" width="12%">วันที่ใบเสร็จ :
                </td>
                <td>
                    <asp:TextBox ID="txt_MONEY_RECEIVE_DATE" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td align="right">เลขที่ใบสั่งชำระ :
                </td>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY1" runat="server" Width="90px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_ORDER_PAY2" runat="server" Width="90px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="right">เลขที่ใบเสร็จ :
                </td>
                <td>

                    <asp:TextBox ID="txt_FULL_RECEIVE_NUMBER" runat="server" Width="120px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td align="right">ประเภทบัญชี :</td>
                <td>
                    <asp:DropDownList ID="ddl_money_type" runat="server" Width="200px" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID">
                    </asp:DropDownList>
                </td>
                <td align="right">ประเภทรายได้ :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddl_Income" runat="server" DataValueField="IDA" DataTextField="INCOME_NAME">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:CheckBox ID="cb_sinbon" runat="server" Text="เงินสินบน" />
                </td>
                <td>
                    <asp:DropDownList runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">ได้รับเงินจาก :</td>
                <td >
                    <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="lcnsid" DataTextField="fullname" Width="200px" CssClass="input-sm">
                    </asp:DropDownList>
                </td>
                <td align="right">ประเภทรับ :</td>
                <td colspan="3">
                    <asp:RadioButtonList ID="rbl_RECEIVE_MONEY_TYPE" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">เงินสด</asp:ListItem>
                <asp:ListItem Value="2">เช็ค</asp:ListItem>
                <asp:ListItem Value="3">โอน</asp:ListItem>
            </asp:RadioButtonList>
                </td>
                <td>
                    <asp:CheckBox ID="cb_IS_CHECK_OUT_PROVINCE" runat="server" Text="เช็คต่างจังหวัด" />
                </td>
            </tr>
            <tr>
                <td align="right">หมายเหตุ :</td>
                <td colspan="5">
    
                    <asp:DropDownList ID="ddl_abbr_type" runat="server" DataTextField ="receipt_type" DataValueField="feeabbr" Width="300px" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td>
                    <asp:CheckBox ID="cb_IS_SEND_TO_BANK" runat="server" Text="นำส่งเข้าธนาคาร" />
                </td>
            </tr>
            <tr>
                <td align="right">สถานะใบเสร็จ :</td>
                <td>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="txt_stat" runat="server" Text="รับเงิน" Width="60px" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2" align="right">
                    เงินสินบนรอการจ่าย :</td>
                <td>
                    <telerik:RadNumericTextBox ID="txt_SINBON_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>
                </td>
                <td align="right">จำนวนเงิน :</td>
                <td>

                    <telerik:RadNumericTextBox ID="txt_RECEIVE_AMOUNT" runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px"></telerik:RadNumericTextBox>

                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_refresh" runat="server" Text="Button"  style="display:none;"/>
                </td>
                <td colspan="2" align="right">
                    <asp:Button ID="btn_save" runat="server" Text="บันทึกใบเสร็จ"  />
                </td>
                <td>
                    <asp:Button ID="btn_print" runat="server" Text="พิมพ์ใบเสร็จ" style="display:none;" />
                </td>
                <td align="right">&nbsp;</td>
                <td>

                    &nbsp;</td>
            </tr>--%>
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
                    <table>
                        <tr>
                            
                            <td>
                                วันที่ใบเสร็จ <asp:TextBox ID="txt_check_date" runat="server" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td>
                    <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" style="display:none;" />
                    <asp:Button ID="btn_add3" runat="server" Text="เพิ่มข้อมูลใบเสร็จ (Manual)" CssClass="btn-sm"  style="width:170px"/>
                    <asp:Button ID="btn_add2" runat="server" Text="เพิ่มข้อมูลใบเสร็จ" CssClass="btn-sm" style="width:120px"/>
                            </td>
                        </tr>
                        <tr>
                            
                            <td>
                               <%-- ผู้รับเงิน--%>
                                <asp:DropDownList ID="ddl_receiver" runat="server" Width="90px" style="display:none;"></asp:DropDownList>
                                <asp:CheckBox ID="cb_previous" runat="server" Text="คีย์ย้อนหลัง"/>
                            </td>
                            <td align="left">
                                
                                <asp:Button ID="btn_refresh" runat="server" Text="Button" style="display:none;" />
                                
                            </td>
                        </tr>
                    </table>
                    

                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">หน้าค้นหาใบเสร็จทั้งหมด</asp:HyperLink>
                    <telerik:RadGrid ID="rg_receive" runat="server" AutoGenerateColumns="false" AllowPaging="true" MasterTableView-AllowFilteringByColumn="true"
                         PageSize="15" Width="100%">
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    ใบเสร็จรับเงิน<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal4">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    แก้ไขใบเสร็จ<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f4" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
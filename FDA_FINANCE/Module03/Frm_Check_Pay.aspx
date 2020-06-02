<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Check_Pay.aspx.vb" Inherits="FDA_FINANCE.Frm_Check_Pay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Content/bootstrap.css" rel="stylesheet" />
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
                    Popups('Frm_Maintain_Receive_Money_V3_Insert.aspx?myear=' + bgYear.toString() + '&pre=1&date=' + c_date + '&r=' + selectVal);
                } else {
                    Popups('Frm_Maintain_Receive_Money_V3_Insert.aspx?myear=' + bgYear.toString() + '&date=' + c_date + '&r=' + selectVal);
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
                    Popups('Frm_Maintain_Receive_Money_V3_2_Insert.aspx?myear=' + bgYear.toString() + '&pre=1&date=' + c_date + '&r=' + selectVal);
                } else {
                    Popups('Frm_Maintain_Receive_Money_V3_2_Insert.aspx?myear=' + bgYear.toString() + '&date=' + c_date + '&r=' + selectVal);
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
</head>
<body>
    <form id="form1" runat="server">
       <div class="panel panel-body"  style="width:100%;"> 
        <h3>รายการตรวจสอบการชำระเงิน</h3>
        <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </div>
    <table width="100%">
        <tr>
            <td align="right">
                เลขสั่งชำระ
            </td>
            <td>
                <asp:TextBox ID="txt_feeabbr" runat="server" CssClass="input-sm"></asp:TextBox> &nbsp; &nbsp;&nbsp; (ตัวอย่าง 9005 )</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:TextBox ID="txt_feeno" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
            &nbsp;(ตัวอย่าง 10000/2560)</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <p>
                    ผลการค้นหา <br />
                    <b><asp:Label ID="lbl_result" runat="server" Text="-" style="font-size:x-large;"></asp:Label></b>
                </p></td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td width="30%">
               
                
                
                
               
            </td>
        </tr>
    </table>
    
    </form>
</body>
</html>

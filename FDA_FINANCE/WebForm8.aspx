<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm8.aspx.vb" Inherits="FDA_FINANCE.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../validate/jquery.validationEngine.js"></script>
    <script src="../validate/jquery.validationEngine-en.js"></script>
    

    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/Jsdatemain.js"></script>

    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        //$(function () {
            //$('#<%= Button1.ClientID%>').click(function () {
               // $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            //});
       // });

        //function enterToTab(e) {
            //var intKey = window.Event ? e.which : e.KeyCode;
            //If the key that is pushed is the enter key we will not submit.
            //if (intKey == 13) {
                //e.KeyCode = 9;
                //e.returnValue = false;
            //}
        //}

        $(document).ready(function() {
            $('input : text : first').focus();
            $('input:text').bind('keydown', function(e) {
                if (e.which == 13) {   //Enter key
                    e.preventDefault(); //ไม่สนใจ default behaviour ของ enter key
                    var nextIndex = $('input:text').index(this) + 1;
                    $('input:text')[nextIndex].focus();
                }
            }); $('#Button1').click(
            function() {
                $('form')[0].reset();
            });});

        //onkeydown="enterToTab(event);"
</script>
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Button1" runat="server" Text="gen_dh" />
        <br />
        <br />
        <br />
        mail
        <asp:TextBox ID="txt_mail" runat="server"></asp:TextBox>
        <br />
        ref1
        
        <asp:TextBox ID="txt_ref1" runat="server"></asp:TextBox>
        <br />
        ref2<asp:TextBox ID="txt_ref2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_runmail" runat="server" Text="RUN MAIL"  />
        <asp:Button ID="btn_RUN_MAIN_ONLY" runat="server" Text="RUN_MAIN_ONLY" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btn_runfee" runat="server" Text="Run Stamp จ่ายเงิน" />
        <asp:Button ID="btn_run_ref" runat="server" Text="ย้ำใบสั่ง" />
        <br />
    </div>
    </form>
</body>
</html>

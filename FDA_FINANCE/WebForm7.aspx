<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm7.aspx.vb" Inherits="FDA_FINANCE.WebForm7" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
        <script type ="text/javascript" >


             function CallPrint() {
                 var prtContent = document.getElementById('main');
                 var WinPrint = window.open('', '', 'width=800,height=650,scrollbars=1,menuBar=1');
                 var str = prtContent.innerHTML;
                 debugger;
                 WinPrint.document.write(str);
                 WinPrint.document.close();
                 WinPrint.print();
                 return false;
             }

        jQuery.fn.highlight = function (str, className) {
            var regex = new RegExp(str, "gi");
            return this.each(function () {
                $(this).contents().filter(function () {
                    return this.nodeType == 3;
                }).replaceWith(function () {

                    return (this.nodeValue || "").replace(regex, function (match) {

                        return "<span class=\"" + className + "\">" + match + "</span>";
                    });
                });
            });
        };

        $(document).ready(function () {
            $('#Submit2').click(function (e) {
                e.preventDefault();
                //   $('#Button2').click();

                ClearHighlight();
                var txt = $("#TextBox1").val();
                //var txt = 'ล้าน';
                $("#body *").highlight(txt, "highlightWord");


                $('html, body').animate({
                    scrollTop: $('.highlightWord').offset().top

                }, 2000);

            });

            function ClearHighlight() {
                $(".highlightWord").replaceWith(function () { return $(this).contents(); });
                //$(this).toggle();
                //$('#hl').toggle();

            }

        });

    </script>

    <style type="text/css">
        .highlightWord { background-color: #ff2; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <telerik:RadMenu ID="RadMenu1" runat="server"></telerik:RadMenu>
        
        <br />
        <telerik:RadComboBox ID="RcbCategory" Runat="server" AllowCustomText="True"  DataTextField="CategoryName" 
            DataValueField="CategoryKey" EmptyMessage="กรุณาเลือก" MarkFirstMatch="True" Width="200px">
        </telerik:RadComboBox>
    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        5555
    <input id="Submit2" type="submit" value="ค้นหา" /><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        </p>
</body>
</html>

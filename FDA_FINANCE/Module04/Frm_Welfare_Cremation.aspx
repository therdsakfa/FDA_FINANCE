<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Welfare_Cremation.aspx.vb" Inherits="FDA_FINANCE.Frm_Welfare_Cremation" %>

<%@ Register Src="~/Module04/UseControl/UC_Welfare_Cremation.ascx" TagPrefix="uc1" TagName="UC_Welfare_Cremation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Insert').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                d_insert.dialog("open");
                openform("Frm_Welfare_Cremation_Insert.aspx?BUDGET_YEAR=" + bgYear, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Import').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                d_insert.dialog("open");
                openform("Frm_Welfare_Cremation_Import.aspx?bgYear=" + bgYear, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });
        function k(id) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            openform("Frm_Welfare_Cremation_Edit.aspx?ALL_WELFARE_ID=" + id , "#1234");
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
   <script type="text/javascript">
       function set_id_txtbox(id) {
           var txt
           txt = document.getElementById("ctl00_ContentPlaceHolder1_txt_id");
           txt.value = id;

           document.getElementById("ctl00_ContentPlaceHolder1_btn_del").click();
       }

       function confirmDelete() {
           var agree = confirm("คุณต้องการลบหรือไม่?");
           if (agree)
               return true;
           else
               return false;
       }

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td align="right">
                <asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="">---เลือกเดือน---</asp:ListItem>
                    <asp:ListItem Value="มกราคม">มกราคม</asp:ListItem>
                    <asp:ListItem Value="กุมภาพันธ์">กุมภาพันธ์</asp:ListItem>
                    <asp:ListItem Value="มีนาคม">มีนาคม</asp:ListItem>
                    <asp:ListItem Value="เมษายน">เมษายน</asp:ListItem>
                    <asp:ListItem Value="พฤษภาคม">พฤษภาคม</asp:ListItem>
                    <asp:ListItem Value="มิถุนายน">มิถุนายน</asp:ListItem>
                    <asp:ListItem Value="กรกฎาคม">กรกฎาคม</asp:ListItem>
                    <asp:ListItem Value="สิงหาคม">สิงหาคม</asp:ListItem>
                    <asp:ListItem Value="กันยายน">กันยายน</asp:ListItem>
                    <asp:ListItem Value="ตุลาคม">ตุลาคม</asp:ListItem>
                    <asp:ListItem Value="พฤศจิกายน">พฤศจิกายน</asp:ListItem>
                    <asp:ListItem Value="ธันวาคม">ธันวาคม</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btn_Export" runat="server" Text="Export" />
                <asp:Button ID="btn_Insert" runat="server" Text="เพิ่มข้อมูล" />
                <asp:Button ID="btn_Import" runat="server" Text="ดึงข้อมูลเดือนเก่า" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <uc1:UC_Welfare_Cremation runat="server" id="UC_Welfare_Cremation" />
            </td>
        </tr>
    </table>

      <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>

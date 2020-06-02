<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Salary_List_Employee.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_List_Employee" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="UC/UC_Salary_Paylist_Employee.ascx" tagname="UC_Salary_Paylist_Employee" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />

    <script type="text/javascript">
       
        function insert_k(url) {
            var d_edit = $("#dialog_insert");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            openform(url, "#if1");
            return false;
        }


        //function k(id, bg_id, bgYear) {
        //    var d_edit = $("#dialog_edit");
        //    //กำหนดขนาด iframe
        //    d_edit.dialog({
        //        autoOpen: true,
        //        height: 700,
        //        width: 800,
        //        modal: true
        //    });
        //    openform("Frm_Disburse_Budget_Bill_edit.aspx?bid=" + id + "&bgid=" + bg_id + "&bgYear=" + bgYear, "#1234");
        //    return false;
        //}

        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });

            //var e = document.getElementById("ctl00_dd_BudgetYear");
            //var bgYear = e.options[e.selectedIndex].value;
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

    
    <table>
        <tr>
            <td>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
            </td>
        </tr>
        <tr>
            <td align="right">
                               <table>
    <tr>
        <td align="right">รายรับ/รายจ่าย :</td>
        <td>
            <asp:DropDownList ID="ddlSALARY_PAYLIST" runat="server" DataTextField="SALARY_PAYLIST_NAME"
                DataValueField="SALARY_PAYLIST_ID"></asp:DropDownList></td>

        <td align="right">จำนวนเงิน :</td>
        <td>
            <telerik:radnumerictextbox ID="rntAmount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
            </telerik:radnumerictextbox> &nbsp; บาท
        </td>
        <td>
<asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" />
        </td>
        <td>
 <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" />
        </td>
    </tr>   
</table>
                <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" style="display:none;" />
                
               
            </td>
        </tr>
        <tr>
            <td>


                <uc1:UC_Salary_Paylist_Employee ID="UC_Salary_Paylist_Employee1" runat="server" />


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
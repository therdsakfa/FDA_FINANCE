<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Budget_Overlap.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Overlap" %>
<%@ Register src="../Module02/Disburse_Budget/UserControl/UC_Budget_Amount_Detail.ascx" tagname="uc_budget_amount_detail" tagprefix="uc2" %>

<%@ Register src="UserControl/UC_Budget_Overlap.ascx" tagname="UC_Budget_Overlap" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Add_bill').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                //X เพิ่มนะ
                var dd = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetAdjust");
                var selectVal = dd.options[dd.selectedIndex].value;
                var e = document.getElementById("ctl00_dd_BudgetYear");
                var bgYear = e.options[e.selectedIndex].value;
                var d = document.getElementById("ctl00_ContentPlaceHolder1_dd_Department");
                var select_dept = d.options[d.selectedIndex].value;
                //
                d_insert.dialog("open");
                openform("Frm_Budget_Overlap_Bill.aspx?bgyear=" + String(bgYear) + "&dept=" + String(select_dept) + "&bgid=" & String(selectVal), "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

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

    <table width="100%">
        <tr>
            <td>เงินกันไว้เหลื่อมปี</td>
        </tr>
        <tr>
            <td bgcolor="#FFFFCC" style="border: thin ridge #000000">
                หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" Font-Names="TH SarabunPSK" Font-Size="14" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true">

            </asp:DropDownList> <br/>
                งบประมาณที่ได้รับการจัดสรร&nbsp;
                <asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr bgcolor="#CCFFCC">
            <td>
                <asp:Panel ID="Panel1" runat="server" Enabled="true">
                    <uc2:UC_Budget_Amount_Detail ID="UC_Budget_Amount_Detail1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td>บันทึกเงินกันไว้เหลื่อมปี</td>
                        <td align="right">
                            <asp:Button ID="btn_Add" runat="server" Text="กรอกข้อมูล" style="display:none;" />
                        <asp:Button ID="btn_Add_bill" runat="server" Text="ดึงข้อมูลจากใบเบิก" />
                        <asp:Button ID="btn_Add_debtor" runat="server" Text="ดึงข้อมูลจากลูกหนี้" Visible="false" style="display:none;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <uc1:UC_Budget_Overlap ID="UC_Budget_Overlap1" runat="server" />
                        </td>
                    </tr>
                </table>
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

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_BudgetPlan_Adjust.aspx.vb" Inherits="FDA_FINANCE.Frm_BudgetPlan_Adjust" MaintainScrollPositionOnPostback="true" %>
<%@ Register src="UserControl/UC_BudgetPlan.ascx" tagname="UC_BudgetPlan" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Budgetplan_Information.ascx" tagname="UC_Budgetplan_Information" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_BudgetPlan_Adjust.ascx" tagname="UC_BudgetPlan_Adjust" tagprefix="uc3" %>
<%@ Register src="UserControl/UC_BudgetPlan_Adjust_Information.ascx" tagname="UC_BudgetPlan_Adjust_Information" tagprefix="uc4" %>
<%@ Register src="UserControl/UC_BudgetPlan_For_Adjust.ascx" tagname="UC_BudgetPlan_For_Adjust" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btnAdd').click(function () {
                var d_insert = $("#dialog_insert"); // ชื่อ iframe      
                //กำหนดขนาด iframe
                d_insert.dialog({
                    autoOpen: true,
                    height: 700,
                    width: 1000,
                    modal: true
                });
                //X เพิ่มนะ
                var d = document.getElementById("ctl00_ContentPlaceHolder1_txt_hide");
                var val1 = d.value;
                //var e = document.getElementById("ctl00_ContentPlaceHolder1_dd_Department");
                //var dept = e.options[e.selectedIndex].value;
                // + "&dept=" + dept
                d_insert.dialog("open");
                openform("Frm_BudgetPlan_Adjust_Insert.aspx?bgid=" + val1, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 600,
                width: 1000,
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
    <asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลงบประมาณจัดสรรตามกอง">

        <table style="width:100%"><tr><td style="width:50%">จัดสรรงบประมาณ</td><td style="width:50%">รายละเอียดงบประมาณ</td></tr>
            <tr><td valign="top">
                <%--<uc1:UC_BudgetPlan ID="UC_BudgetPlan1" runat="server" />--%>

                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <uc5:UC_BudgetPlan_For_Adjust ID="UC_BudgetPlan_For_Adjust1" runat="server" />
                </td>
                
                <td valign="top">

                <table style="width:100%"><tr><td colspan="2">
                    <uc4:UC_BudgetPlan_Adjust_Information ID="UC_BudgetPlan_Adjust_Information1" runat="server" Visible="false" />
                    </td></tr>
                    <tr><td colspan="2">หน่วยงานที่ได้รับการจัดสรร</td></tr>
                   <%-- <tr><td>หน่วยงาน</td><td>
                        <asp:DropDownList ID="dd_Department" runat="server" AutoPostBack="true" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID">
                        </asp:DropDownList>
                        </td></tr>--%>
                    <tr><td colspan="2">
                            <asp:Label ID="lbHide" runat="server" Style="display:none;"></asp:Label>
                        <asp:TextBox ID="txt_hide" runat="server" Style="display:none;"></asp:TextBox>
                            <asp:Button ID="btnAdd" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg"/>
                           
                        </td></tr>
                    <tr><td colspan="2">
                        <uc3:UC_BudgetPlan_Adjust ID="UC_BudgetPlan_Adjust1" runat="server" />
                        </td></tr>

                </table>

                         </td></tr>

        </table>
 </asp:Panel>
      <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>

<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Budget_Overview.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Overview" %>
<%@ Register src="UserControl/UC_Budget_Amount_Detail.ascx" tagname="UC_Budget_Amount_Detail" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc3" %>
<%@ Register src="UserControl/UC_Disburse_Budget.ascx" tagname="UC_Disburse_Budget" tagprefix="uc1" %>
<%@ Register src="UserControl/UC_Disburse_Budget_With_Approve.ascx" tagname="UC_Disburse_Budget_With_Approve" tagprefix="uc4" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="../../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            // ชื่อ iframe
            $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
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
                openform("Frm_Disburse_Budget_Bill_Insert.aspx?bgid=" + selectVal + "&bgYear=" + bgYear + "&dept=" + select_dept, "#if1"); //ใส่ url, ID iframe
                return false;
            });
        });

        function k(id, bg_id, bgYear) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            openform("Frm_Disburse_Budget_Bill_edit.aspx?bid=" + id + "&bgid=" + bg_id + "&bgYear=" + bgYear, "#1234");
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
            <td colspan="2">
<h4>เบิกจ่ายงบประมาณ</h4>
                <asp:Button ID="btn_del" runat="server" Text="Button" Style="display:none;" OnClientClick="confirmDelete();"/>
                <asp:TextBox ID="txt_id" runat="server" Style="display:none;" ></asp:TextBox>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />

            </td>
        </tr>
        <tr>
        <td  colspan="2" >
        <table><tr> <td> <uc3:UC_Search_Form ID="UC_Search_Form1" runat="server" /></td>
        <td valign="middle"><asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg"
                Height="55px" /></td></tr></table>
          
            
        </td>
        </tr>
<tr><td colspan="2" bgcolor="#ffffc0" style="border: thin ridge #000000">
     <table width="100%">
        <tr>
            <td align="right">
                หน่วยงาน :
            </td>
            <td>
<asp:DropDownList ID="dd_Department" runat="server" Font-Names="TH SarabunPSK"
          DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true" Width="200px">

            </asp:DropDownList>
            </td>

            <td align="right">
                งบประมาณที่ได้รับการจัดสรร :
            </td>
            <td>
<asp:DropDownList ID="dd_BudgetAdjust" runat="server" class="ddl" AutoPostBack="true" 
                    DataTextField="BUDGET_DESCRIPTION" DataValueField="BUDGET_PLAN_ID" Font-Names="TH SarabunPSK" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
    </table> 
                </td></tr>
        <tr bgcolor="#ffffff">
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" Enabled="true">
                
                <uc2:UC_Budget_Amount_Detail ID="UC_Budget_Amount_Detail1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
   
   
        <tr>
            <td colspan="2">
            
            <table width="100%">
                <tr><td>รายการเบิกจ่ายงบประมาณ</td><td>&nbsp;</td><td align="right">&nbsp;</td></tr>
                <tr><td>
                    <asp:RadioButtonList ID="rdl_approve" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                        <asp:ListItem Value="" Selected="True">ทั้งหมด</asp:ListItem>
                        <asp:ListItem Value="1">อนุมัติ</asp:ListItem>
                        <asp:ListItem Value="2">ยังไม่อนุมัติ</asp:ListItem>
                    </asp:RadioButtonList>
                    </td><td align="right">
                        &nbsp;</td><td align="right">
                        <telerik:RadDatePicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH"  Skin="Office2010Blue" style="display:none;">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" skin="Office2010Blue"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" >
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
</DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                <asp:Button ID="btn_no_approve" runat="server" Text="ยกเลิกอนุมัติ" style="display:none;" />
                <asp:Button ID="btn_approve" runat="server" Text="อนุมัติ" Width="78px" style="display:none;" />

                         <asp:Button ID="btn_Add" runat="server" Text="เพิ่มข้อมูล" style="display:none;" />
                             <asp:Button ID="btn_download" runat="server" CssClass="btn-lg" Text="ดาวน์โหลดคำขอ" Width="170px" />

                    <asp:Button ID="btn_upload" runat="server" CssClass="btn-lg " Text="อัพโหลดคำขอ" Width="170px" />


                                   </td></tr>
            <tr><td colspan="3">
                <uc4:UC_Disburse_Budget_With_Approve ID="UC_Disburse_Budget_With_Approve1" runat="server" />
                </td></tr>
            
            </table>
               
            </td>
        </tr>
    </table>
    
    <div id="dialog_edit" title="แก้ไขข้อมูลผูกพัน" style="display:none">  
    <iframe id="1234" width="1000px" height="600px"></iframe>
    </div>

    <div id="dialog_insert" title="บันทึกข้อมูลผูกพัน" style="display:none">  
    <iframe id="if1" width="1000px" height="600px" ></iframe>
    </div>
</asp:Content>

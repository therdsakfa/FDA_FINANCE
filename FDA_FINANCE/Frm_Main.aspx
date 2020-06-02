<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Main.aspx.vb" Inherits="FDA_FINANCE.WebForm3" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="Module02/Disburse_Debtor/UserControl/UC_Debtor_Status.ascx" tagname="UC_Debtor_Status" tagprefix="uc1" %>
<%@ Register src="Module02/Disburse_Budget/UserControl/UC_Disburse_Bill_Status.ascx" tagname="UC_Disburse_Bill_Status" tagprefix="uc2" %>
<%@ Register src="Module02/Disburse_Budget/UserControl/UC_Disburse_PO_Bill_Status.ascx" tagname="UC_Disburse_PO_Bill_Status" tagprefix="uc3" %>
<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReturnMoney_Status.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReturnMoney_Status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
     <link href="Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <link href="css/css_main.css" rel="stylesheet" />
    <script type="text/javascript">
        //$(document).ready(function () {
        //    // ชื่อ iframe
        //    $('#ctl00_ContentPlaceHolder1_btn_Add').click(function () {
        //        var d_insert = $("#dialog_insert"); // ชื่อ iframe      
        //        //กำหนดขนาด iframe
        //        d_insert.dialog({
        //            autoOpen: true,
        //            height: 700,
        //            width: 800,
        //            modal: true
        //        });
        //        //X เพิ่มนะ
        //        var dd = document.getElementById("ctl00_ContentPlaceHolder1_dd_BudgetAdjust");
        //        var selectVal = dd.options[dd.selectedIndex].value;
        //        var e = document.getElementById("ctl00_dd_BudgetYear");
        //        var bgYear = e.options[e.selectedIndex].value;
        //        //
        //        d_insert.dialog("open");
        //        openform("Frm_Disburse_Budget_Bill_Insert.aspx?bgid=" + selectVal + "&bgYear=" + bgYear, "#if1"); //ใส่ url, ID iframe
        //        return false;
        //    });
        //});

        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            openform(url, "#1234");
            return false;
        }
        function k_int(url) {
            var d_insert = $("#dialog_insert");
            //กำหนดขนาด iframe
            d_insert.dialog({
                autoOpen: true,
                height: 700,
                width: 1000,
                modal: true
            });
            d_insert.dialog("open");
            openform(url, "#if1");
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
    <style type="text/css">
     /* unvisited link */
           #ct_content a:link {
                color: blue;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-control" style="height:500px;">
    <h3>
        &nbsp;</h3>
    <div class="panel-heading panel-title" style="text-align:center;color:black; font-size:x-large;">ประกาศ</div>
    <div style="margin: 20px; height:400px;">
        <asp:Label ID="lbl_news" runat="server" Text=""></asp:Label>
        <br />
        &nbsp;
        <div style="color:black;font-size:larger;" id="ct_content"> 
            รองรับการทำงานบนเบราเซอร์ Mozilla Firefox&nbsp;ดาวน์โหลด <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FILE_DOWNLOAD/Firefox_Setup_42.0.zip" >ที่นี้</asp:HyperLink>
            <br />
            รองรับการทำงานบนโปรแกรม Adobe Acrobat Reader DC&nbsp;ดาวน์โหลด <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/FILE_DOWNLOAD/AcroRdrDC_MUI.zip" >ที่นี้</asp:HyperLink>
            <br />
            รองรับการทำงานด้วย FontPack ดาวน์โหลด <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/FILE_DOWNLOAD/FontPack_DC.zip" >ที่นี้</asp:HyperLink>
        </div>
       
        <br />
&nbsp;
        <%--- อ่านวิธีตั้งค่าเพื่อรองรับการเปิดไฟล์ PDF บนเว็บเบราเซอร์ <asp:HyperLink ID="HyperLink2" runat="server">ที่นี้</asp:HyperLink>--%>

    </div>
         
</div>
    <table width="100%" style="display:none;">
        <tr>
            <td valign="top">
                 <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                 <asp:Panel ID="Panel1" GroupingText="สถานะการดำเนินงานของกองคลัง" runat="server" style="display:none"  BorderColor="Black" BorderStyle="Ridge" BorderWidth="1">
  <table>
    <tr><td>การขอเบิกงบประมาณ
        <asp:HyperLink ID="h_dis_bg" runat="server" Target="_blank"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
    <tr><td>อนุมัติการเบิกไปแล้ว
        <asp:HyperLink ID="h_dis_app_bg" runat="server" Target="_blank"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
      <tr><td>ยังไม่อนุมัติการเบิก
        <asp:HyperLink ID="h_dis_no_app_bg" runat="server" Target="_blank"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
        <tr>
            <td>
                ออกเลข ขบ. ใบเบิกแล้ว
                <asp:HyperLink ID="h_add_k" runat="server" Target="_blank"></asp:HyperLink>
                &nbsp;รายการ</td>
        </tr>

      <tr><td>จำนวนการขอยืมเงินของลูกหนี้
        <asp:HyperLink ID="h_debtor" runat="server" Target="_blank"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
    <tr><td>อนุมัติการยืมไปแล้ว
        <asp:HyperLink ID="h_app_debtor" runat="server"  Target="_blank"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
      <tr><td>ยังไม่อนุมัติการยืม
        <asp:HyperLink ID="h_no_app_debtor" runat="server" Target="_blank"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
        <tr>
            <td>
                ออกเลข ขบ. ลูกหนี้เงินยืมแล้ว
                <asp:HyperLink ID="h_add_k_debtor" runat="server" Target="_blank" ></asp:HyperLink>
                &nbsp;รายการ</td>
        </tr>
       <tr>
            <td>
                
                จำนวนลูกหนี้เงินยืมครบกำหนด
                <asp:HyperLink ID="h_debtor_deadline" runat="server" Target="_blank" NavigateUrl="~/Frm_MainPage_Debtor_Deadline.aspx"></asp:HyperLink>
                &nbsp;ราย</td>
        </tr>
    </table>


    </asp:Panel>
      <asp:Panel ID="Panel2" GroupingText="สถานะการดำเนินงานของกอง" runat="server"  BorderColor="Black" BorderStyle="Ridge" BorderWidth="1" style="display:none">
          <table width="250px">
    <tr><td>การขอเบิกงบประมาณ <asp:HyperLink ID="hl_dept_bill_request" runat="server" 
            NavigateUrl="~/Module02/Disburse_Budget/Frm_Disburse_Budget.aspx"></asp:HyperLink>
        &nbsp; รายการ</td></tr>
    <tr><td>อนุมัติการเบิกไปแล้ว
        <asp:HyperLink ID="hl_dept_approve" runat="server" 
            NavigateUrl="~/Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Cancel.aspx"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
              <tr><td>ยังไม่อนุมัติการเบิก
        <asp:HyperLink ID="hl_dept_no_approve" runat="server" 
            NavigateUrl="~/Module02/Disburse_Budget/Frm_Disburse_Budget_Approve_Ok.aspx"></asp:HyperLink>
        &nbsp;รายการ</td></tr>

              <tr>
            <td>
                ออกเลข ขบ. ใบเบิกแล้ว
                <asp:HyperLink ID="hl_dept_K_add" runat="server" 
                    NavigateUrl="~/Module02/Disburse_Budget/Frm_Disburse_Budget_Bill.aspx"></asp:HyperLink>
                &nbsp;รายการ</td>
        </tr>
               <tr><td>จำนวนการขอยืมเงินของลูกหนี้
        <asp:HyperLink ID="hl_dept_debtor" runat="server" 
            NavigateUrl="~/Module02/Disburse_Debtor/Frm_Disburse_Debtor.aspx"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
    <tr><td>อนุมัติการยืมไปแล้ว
        <asp:HyperLink ID="hl_approve_debtor" runat="server" 
            NavigateUrl="~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_Cancel.aspx"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
      <tr><td>ยังไม่อนุมัติการยืม
        <asp:HyperLink ID="hl_no_approve_debtor" runat="server" 
            NavigateUrl="~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Approve_OK.aspx"></asp:HyperLink>
        &nbsp;รายการ</td></tr>
        <tr>
            <td>
                จำนวนลูกหนี้เงินยืมครบกำหนด
                <asp:HyperLink ID="hl_deadline_dept" runat="server" 
                    NavigateUrl="~/Module02/Disburse_Debtor/Frm_Disburse_Debtor_Bill.aspx"></asp:HyperLink>
                &nbsp;ราย</td>
        </tr>
    </table>
    </asp:Panel>

            </td>
            <td valign="top">

                 <asp:Panel ID="Panel3" GroupingText="ค้นหาด่วน" runat="server" Width="100%"  BorderColor="Black" BorderStyle="Ridge" BorderWidth="1" style="display:none"> 
                    <table width="100%">
                    <tr>
                        <td colspan="3">
                            <table>
                                <tr>
                                    <td align="right" > 
                            ประเภทการค้นหา:</td>
                        <td colspan="2">
                            <asp:RadioButtonList ID="rdl_bill_type" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">เบิกจ่าย</asp:ListItem>
                                <asp:ListItem Value="2">ลูกหนี้เงินยืม</asp:ListItem>
                                <asp:ListItem Value="3">PO</asp:ListItem>
                                <asp:ListItem Value="4">ลูกหนี้คืนเงิน/โอนคืน</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                                </tr>
                            </table>
                        </td>
                                              
                    </tr>
                    <tr>
                        <td >
                           <%-- <asp:DropDownList ID="dd_search_type" runat="server">
                                <asp:ListItem Value="1" Text="เลขบ."></asp:ListItem>
                                <asp:ListItem Value="2">เลขหนังสือ</asp:ListItem>
                                <asp:ListItem Value="3">ชื่อเจ้าหนี้/ลูกหนี้</asp:ListItem>
                                <asp:ListItem Value="4">จำนวนเงิน</asp:ListItem>
                                <asp:ListItem Value="5">เลบขบ.</asp:ListItem>
                                <asp:ListItem Value="6">เลขเช็ค</asp:ListItem>
                            </asp:DropDownList>--%>
                           <b>ค้นหาโดย</b>  <asp:RadioButtonList ID="rd_search_type" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Width="500px" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="1">เลขบ.</asp:ListItem>
                                <asp:ListItem Value="2">เลขหนังสือ</asp:ListItem>
                                <asp:ListItem Value="3">ชื่อเจ้าหนี้/ลูกหนี้</asp:ListItem>
                                <asp:ListItem Value="4">จำนวนเงิน</asp:ListItem>
                                <asp:ListItem Value="5">เลบขบ.</asp:ListItem>
                                <asp:ListItem Value="6">เลขเช็ค</asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_equal" runat="server" style="display:none;">
                                <asp:ListItem>=</asp:ListItem>
                                <asp:ListItem>&gt;</asp:ListItem>
                                <asp:ListItem>&lt;</asp:ListItem>
                            </asp:DropDownList>
                           </td>
                        <td>
                           
                        </td>
                    </tr>
                        <tr>
                            <td colspan="3">
                                 <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" Width="70px" />
                            </td>
                        </tr>
                   <%-- <tr>
                        <td align="right">เลขที่หนังสือ :</td>
                        <td>
                            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                   
                        <td colspan="3">
                            <asp:Panel ID="pn_debtor" runat="server">
                                <uc1:UC_Debtor_Status ID="UC_Debtor_Status1" runat="server" />
                            </asp:Panel>

                            <asp:Panel ID="pn_bill" runat="server">

                                

                                <uc2:UC_Disburse_Bill_Status ID="UC_Disburse_Bill_Status1" runat="server" />

                            </asp:Panel>
                            <asp:Panel ID="pn_PO" runat="server">
                                <uc3:UC_Disburse_PO_Bill_Status ID="UC_Disburse_PO_Bill_Status1" runat="server" />
                            </asp:Panel>
                             <asp:Panel ID="pn_return" runat="server">
                                <uc1:UC_Maintain_ReturnMoney_Status runat="server" ID="UC_Maintain_ReturnMoney_Status" />
                            </asp:Panel>
                        </td>
                   
                </table>
                 </asp:Panel>

            </td>

        </tr>

    </table>
     

     <div id="dialog_edit" title="บันทึกข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="บันทึกข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rd_search_type">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dd_equal">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
           
        </AjaxSettings>
    </telerik:RadAjaxManager>

    
 </asp:Content>

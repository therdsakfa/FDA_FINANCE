<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" MaintainScrollPositionOnPostback="true" CodeBehind="Frm_Disburse_Budget_Print_Check.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Budget_Print_Check"%>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UserControl/UC_Disburse_Budget_CheckList.ascx" tagname="UC_Disburse_Budget_CheckList" tagprefix="uc1" %>

<%@ Register src="UserControl/UC_Disburse_Budget_CheckList_Temp.ascx" tagname="UC_Disburse_Budget_CheckList_Temp" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <link href="../../css/css_main.css" rel="stylesheet" />



     <script type="text/javascript">
         $(document).ready(function () {
             showdate($("#ctl00_ContentPlaceHolder1_txt_date"));
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
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                <div class="panel panel-body"  style="width:100%;">
            <table width="100%">
                <%--<tr><td>บันทึกครั้งที่พิมพ์เช็ค</td><td align="right">&nbsp;</td></tr>--%>
                <tr><td colspan="2" align="center">
                    <asp:RadioButtonList ID="rdl_search_type" runat="server" RepeatDirection="Horizontal" Style="display:none;">
                        <asp:ListItem Value="1" Selected="True">เลขที่เช็ค</asp:ListItem>
                        <asp:ListItem Value="2">ชื่อ - นามสกุล</asp:ListItem>
                        <asp:ListItem Value="3">จำนวนเงิน</asp:ListItem>
                        <asp:ListItem Value="4">บ./บย.</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                    </tr>
                <tr><td colspan="2" align="center">
                    
                    <asp:TextBox ID="txt_search_chk" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" Width="80px"  CssClass="btn-lg"/>
                    <asp:Button ID="Button1" runat="server" Text="เลือกเช็ค" CssClass="btn-lg" /> 
                  
                    </td></tr>
                </table>
</div>
<div class="panel panel-body"  style="width:100%;">
    รายการค้นหาเช็ค
                <uc2:UC_Disburse_Budget_CheckList_Temp ID="UC_Disburse_Budget_CheckList_Temp1" runat="server" />
    </div>
<div class="panel panel-body"  style="width:100%;">
รายการเช็คที่เลือก
                <uc1:UC_Disburse_Budget_CheckList ID="UC_Disburse_Budget_CheckList1" runat="server" />
    </div>
<div class="panel panel-body"  style="width:100%;">
                <table width="100%">
            <tr><td>
                
                <%--<asp:Button ID="btn_Add" runat="server" Text="เพิ่มเลขเช็ค" />--%>
                วันที่พิมพ์ &nbsp;<asp:TextBox ID="txt_date" runat="server" AutoPostBack="True"></asp:TextBox>
                &nbsp;&nbsp;
                
                    ครั้งที่พิมพ์ &nbsp;<asp:DropDownList ID="ddl_count" runat="server" AutoPostBack="True">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:HyperLink ID="hpPrintCheck" runat="server" Target="_blank">พิมพ์เช็ค</asp:HyperLink>
                </td><td align="left">
                    <table>
                        <tr>
                            <td> <asp:Label ID="lb_chk_type" runat="server" Text="ประเภทเช็ค" style="display:none;"></asp:Label></td>
                            <td>
                                 <asp:DropDownList ID="dd_check_type" runat="server" style="display:none;" AutoPostBack="true" >
                        <asp:ListItem Selected="True" Value="1">เช็คกรุงไทย</asp:ListItem>
                        <asp:ListItem Value="2">เช็ค ธกส.</asp:ListItem>
                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                     </td></tr>
            
            <tr><td colspan="2">
                
               <%-- 
                   <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">พิมพ์เช็ค2</asp:HyperLink>
                   <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="ID" HeaderText="ลำดับ" DataField="ID" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="id_table" HeaderText="id_table" DataField="id_table" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BILL_NUMBER" HeaderText="เลขบย." DataField="BILL_NUMBER" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CHECK_NUMBER" HeaderText="เลขที่เช็ค" DataField="CHECK_NUMBER" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="bill_type" HeaderText="bill_type" DataField="bill_type" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="PRINT_DATE" HeaderText="PRINT_DATE" Display="false" DataFormatString="{0:dd/MM/yyyy tt:mm:ss}">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>--%>
                 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None">
                    <MasterTableView>
                        <Columns>
                            <%--<telerik:GridBoundColumn UniqueName="ID_g" HeaderText="ลำดับ" DataField="ID_g" >
                            </telerik:GridBoundColumn>--%>
                            <%--<telerik:GridBoundColumn UniqueName="id_table" HeaderText="id_table" DataField="id_table" Display="false">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="ID" HeaderText="ID" DataField="ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BILL_NUMBER" HeaderText="เลขบ." DataField="BILL_NUMBER" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DOC_NUMBER" HeaderText="เลขหนังสือ" DataField="DOC_NUMBER" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CHECK_NUMBER" HeaderText="เลขที่เช็ค" DataField="CHECK_NUMBER" >
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="CUSTOMER_NAME" HeaderText="เจ้าหนี้" DataField="CUSTOMER_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="PAYLIST_DESCRIPTION" HeaderText="ค่าใช้จ่าย" DataField="PAYLIST_DESCRIPTION">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงิน" DataField="AMOUNT" DataFormatString="{0:###,###.##}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="bill_type" HeaderText="bill_type" DataField="bill_type" Display="false">
                            </telerik:GridBoundColumn>
                            
                           <%-- <telerik:GridBoundColumn UniqueName="PRINT_DATE" HeaderText="PRINT_DATE" Display="false" DataFormatString="{0:dd/MM/yyyy tt:mm:ss}">
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td></tr>
            
            <tr><td colspan="2">
                
                &nbsp;</td></tr>
            
            </table>
</div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="900px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="900px" height="700px" ></iframe>
    </div>
                <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกจัดซื้อจัดจ้าง
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
     <div class="modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    แก้ไขจัดซื้อจัดจ้าง
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

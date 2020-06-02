<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Maintain_ReceiveMoney_Receipt_Approve.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReceiveMoney_Receipt_Approve" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register src="UseControl/UC_Maintain_ReturnMoney_Receipt_Approve.ascx" tagname="UC_Maintain_ReturnMoney_Receipt_Approve" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Html5/html5shiv.min.js"></script>
    <script src="../../Html5/respond.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>

  <%--  <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>--%>
    <link href="../../css/css_main.css" rel="stylesheet" />
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <table width="100%" style="margin-bottom: 0px">
        <tr>

            <td colspan="2"> 
                <div class="panel panel-body"  style="width:100%;padding-left:5%;">
                <h3>หัวหน้าการคลังตรวจสอบและอนุมัติ</h3>
</div>
            </td>
        </tr>
</table>        
    
    <div class="panel panel-body"  style="width:100%;padding-left:5%;">
            <table width="100%">
               <%-- <tr><td>&nbsp;</td><td>เลขใบสั่ง
                    <asp:TextBox ID="txt_feeno" runat="server"></asp:TextBox>
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                    </td><td align="right">&nbsp;</td></tr>--%>
                <tr><td colspan="3" align="right">
                    <asp:Button ID="btnRedirect" runat="server" Style="display:none;" Text="Button" />
          <%--          <asp:Button ID="btn_download" runat="server" CssClass="btn-lg " Text="ดาวน์โหลดคำขอ" Width="170px" />

                    <asp:Button ID="btn_upload" runat="server" CssClass="btn-lg " Text="อัพโหลดคำขอ" Width="170px" />--%>

                    <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
                    <table>
                        <tr>
                            <td align="right">วันที่ &nbsp;</td>
                            <td>
                                <telerik:RadDatePicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH" Skin="Office2010Blue">
                                    <Calendar skin="Office2010Blue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                    </Calendar>
                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                        <EmptyMessageStyle Resize="None" />
                                        <ReadOnlyStyle Resize="None" />
                                        <FocusedStyle Resize="None" />
                                        <DisabledStyle Resize="None" />
                                        <InvalidStyle Resize="None" />
                                        <HoveredStyle Resize="None" />
                                        <EnabledStyle Resize="None" />
                                    </DateInput>
                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                </telerik:RadDatePicker>
                            </td>
                            <td>
                                <asp:Button ID="btn_approve" runat="server" CssClass="btn-lg" Text="อนุมัติ" Width="100px" />
                            </td>
                        </tr>
                    </table>
                    </td></tr>
            <tr><td colspan="3">
              
                
              
                <uc1:UC_Maintain_ReturnMoney_Receipt_Approve ID="UC_Maintain_ReturnMoney_Receipt_Approve1" runat="server" />
              
                
              
                </td></tr>
            
            </table>
        </div>

    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกผูกพันเงินclass="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    แก้ไขผูกพันเงิน
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

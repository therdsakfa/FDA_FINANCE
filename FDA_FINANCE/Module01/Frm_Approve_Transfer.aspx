<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Approve_Transfer.aspx.vb" Inherits="FDA_FINANCE.Frm_Approve_Transfer" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="UserControl/UC_Budget_Search_Form.ascx" tagname="UC_Budget_Search_Form" tagprefix="uc2" %>
<%@ Register src="UserControl/UC_Transfer_Approve.ascx" tagname="UC_Transfer_Approve" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" /> 
    <script src="../Scripts/jquery-1.8.2.js"></script>
    <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <link href="../../css/css_main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;">
    <h3>โอนภายในกรม</h3>

</div>
    <div class="panel panel-body"  style="width:100%;">
        <table>
            <tr>
                <td>
                    <uc2:UC_Budget_Search_Form ID="UC_Budget_Search_Form1" runat="server" />
                </td>
                <td valign="bottom">
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg" />
                </td>
            </tr>
        </table>
</div>
    <div class="panel panel-body" style="width: 100%;">
        <table width="100%">
            <tr>
                <td align="right">
                    <telerik:RadDatePicker ID="rd_APPROVE_DATE" Runat="server" Culture="th-TH"  Skin="Office2010Blue">
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
                <asp:Button ID="btn_no_approve" runat="server" Text="ยกเลิกอนุมัติ" Width="140px"  CssClass="btn-lg"/>
                <asp:Button ID="btn_approve" runat="server" Text="อนุมัติ"  Width="100px"  CssClass="btn-lg"/>

                             <asp:Button ID="Button1" runat="server" Style="display: none;" Text="Button" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display: none;" />

                    <uc1:UC_Transfer_Approve ID="UC_Transfer_Approve1" runat="server" />

                </td>
            </tr>
        </table>
    </div>
    <div id="dialog_edit" title="แก้ไขข้อมูล" style="display:none">  
    <iframe id="1234" width="1000px" height="700px"></iframe>
    </div>

    <div id="dialog_insert" title="เพิ่มข้อมูล" style="display:none">  
    <iframe id="if1" width="1000px" height="700px" ></iframe>
    </div>
    <div class="modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    บันทึกการโอนงบประมาณภายในกรม<button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
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
                    แก้ไขการโอนงบประมาณภายในกรม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้าต่าง</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>

</asp:Content>

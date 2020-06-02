<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Setting_Report19_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Setting_Report19_Insert" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.2.js"></script>

    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>

    <script src="../../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/jquery.blockUI.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             showdate($("#ctl00_ContentPlaceHolder1_txt_SEND_DATE"));
             showdate($("#ctl00_ContentPlaceHolder1_txt_find_date"));
         });

        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body" style="width: 100%;">
        <table class="table">
            <tr>
                <td align="right">
                    เลขที่นำส่ง :
                </td>
                <td>
                    <asp:Label ID="lb_runno" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    วันที่นำส่ง :</td>
                <td>
                    <asp:TextBox ID="txt_SEND_DATE" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ประเภทการนำส่ง :</td>
                <td>
                    <asp:DropDownList ID="ddl_type" runat="server">
                        <asp:ListItem Value="1">เงินสด</asp:ListItem>
                        <asp:ListItem Value="2">เช็คธนาคารแห่งประเทศไทย</asp:ListItem>
                        <asp:ListItem Value="3">เช็คธนาคารอื่น</asp:ListItem>
                        <asp:ListItem Value="4">ดราฟท์</asp:ListItem>
                        <asp:ListItem Value="5">เงินฝากธนาคาร</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ผู้รับเงิน</td>
                <td>
                    
                    <asp:DropDownList ID="ddl_receiver" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />
                    <asp:Button ID="btn_edit" runat="server" Text="แก้ไข" CssClass="btn-lg" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel1" runat="server">
            <table width="100%">
                <tr>
                    <td>

                        จำนวนเงินตามประเภทรายได้</td>
                </tr>
                 <tr>
                     <td>หักจำนวนเงิน
                         <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="160px">
                         </telerik:RadNumericTextBox>
                         &nbsp;<asp:Button ID="btn_decrease" runat="server" Text="หักจำนวนเงิน" />
                     </td>
                </tr>
                 <tr>
                    <td>

                        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" ShowFooter="true">
                            <ClientSettings Selecting-AllowRowSelect="true"></ClientSettings> 
                        </telerik:RadGrid>

                    </td>
                </tr>
            </table>
            <br />
            <br />
<table width="100%">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td align="right">
                        ประเภทรายได้ :
                    </td>
                    <td>

                        <asp:DropDownList ID="ddl_Income" runat="server" AutoPostBack="True" DataTextField="INCOME_NAME" DataValueField="IDA" Width="150px">
                        </asp:DropDownList>

                        <asp:DropDownList ID="ddl_receive_type" runat="server">
                            <asp:ListItem Value="1">เงินสด</asp:ListItem>
                            <asp:ListItem Value="2">เช็ค</asp:ListItem>
                            <asp:ListItem Value="3">ดราฟ</asp:ListItem>
                            <asp:ListItem Value="4">แคชเชียร์เช็ค</asp:ListItem>
                            <asp:ListItem Value="5">เงินฝากธนาคาร</asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>
                        วันที่ดึงข้อมูล :
                    </td>
                    <td>
                        <asp:TextBox ID="txt_find_date" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                        <asp:Button ID="btn_insert" runat="server" Text="ดึงข้อมูล" />
                        <asp:Button ID="btn_print" runat="server" Text="พิมพ์ใบนำส่งเงิน" />
                    </td>
                </tr>
            </table>


        </td>
    </tr>
     <tr>
        <td>

            <asp:CheckBox ID="CheckBox1" runat="server" Text="เลือกทั้งหมด" Checked="true"/>

            </td>
         </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">
                <%--<ClientSettings Selecting-AllowRowSelect="true"></ClientSettings> 
                <ClientSettings EnableRowHoverStyle="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>--%>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
        </asp:Panel>
    </div>
</asp:Content>

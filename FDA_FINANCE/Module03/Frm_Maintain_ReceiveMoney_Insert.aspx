<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_ReceiveMoney_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReceiveMoney_Insert" %>

<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReceiveMoney_Detail_MoneyType.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReceiveMoney_Detail_MoneyType" %>
<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReceiveMoney_Detail_Receipt.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReceiveMoney_Detail_Receipt" %>
<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReceiveMoney_Detail_Money.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReceiveMoney_Detail_Money" %>
<%@ Register Src="~/Module03/UseControl/UC_Maintain_ReceiveMoney_Detail_Bank.ascx" TagPrefix="uc1" TagName="UC_Maintain_ReceiveMoney_Detail_Bank" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../Scripts/jquery-1.8.2.js"></script>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
 <script src="../Html5/html5shiv.min.js"></script>
    <script src="../Html5/respond.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReceiveMoney_Detail_Receipt_txt_MONEY_RECEIVE_DATE"));
            showdate($("#ctl00_ContentPlaceHolder1_UC_Maintain_ReceiveMoney_Detail_Bank_txt_CHECK_DATE"));
            $("#ctl00_ContentPlaceHolder1_UC_Maintain_ReceiveMoney_Detail_Money_dd_CUSTOMER").searchable();
        });


        $(function () {
            $('#<%= btn_save.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

        function OnClientNodeClickingHandler(sender, e) {
            var node = e.get_node();
            var combo = $find("<%= rcb_Moneytype.ClientID%>");
                combo.set_text(node.get_text());
                combo.set_value(node.get_value());
                cancelDropDownClosing = false;
                combo.hideDropDown();

         
            //}
        }

        function StopPropagation(e) {
            //cancel bubbling
            e.cancelBubble = true;
            if (e.stopPropagation) {
                e.stopPropagation();
            }
        }
</script> 
    <div class="panel panel-body"  style="width:100%;"> 
        <h3>บันทึกการรับเงิน</h3>
        </div>
    <div class="panel panel-body"  style="width:100%;">
    <table>
        <tr>
            <td>
                ประเภทเงิน : &nbsp;
                <telerik:RadComboBox ID="rcb_Moneytype" Runat="server" Width="300px" Height="300px" 
                    EmptyMessage="เลือกประเภทเงิน" AutoPostBack="true" AllowCustomText="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="" />
                        </Items>
                    <ItemTemplate>
                        <div id="div1" onclick="StopPropagation(event)">
                            <telerik:RadTreeView ID="rtv_money_type" runat="server" 
                                 OnClientNodeClicking="OnClientNodeClickingHandler">
                             </telerik:RadTreeView>
                        </div>
                    </ItemTemplate>
                </telerik:RadComboBox>

            </td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_ReceiveMoney_Detail_MoneyType runat="server" id="UC_Maintain_ReceiveMoney_Detail_MoneyType" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_ReceiveMoney_Detail_Receipt runat="server" id="UC_Maintain_ReceiveMoney_Detail_Receipt" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_ReceiveMoney_Detail_Money runat="server" id="UC_Maintain_ReceiveMoney_Detail_Money" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:UC_Maintain_ReceiveMoney_Detail_Bank runat="server" id="UC_Maintain_ReceiveMoney_Detail_Bank" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_Save" runat="server" Text="บันทึก" CssClass="btn-lg" />
                <asp:Button ID="btn_Cancel" runat="server" Text="ยกเลิก" style="display:none;"/>
                <asp:Button ID="btn_print" runat="server" Text="พิมพ์ใบเสร็จ" style="display:none;"/>
                
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

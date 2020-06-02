<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_OutsideDebtor_Approve_Cancel.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideDebtor_Approve_Cancel" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>

<%@ Register src="../Disburse_OutsideBudget/UserControl/UC_OutsideBudget_Amount_Detail.ascx" tagname="UC_OutsideBudget_Amount_Detail" tagprefix="uc3" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../../Module02/Disburse_Debtor/UserControl/UC_Disburse_Debtor_Approve_Cancel.ascx" tagname="UC_Disburse_Debtor_Approve_Cancel" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        function k(url) {
            var d_edit = $("#dialog_edit");
            //กำหนดขนาด iframe
            d_edit.dialog({
                autoOpen: true,
                height: 600,
                width: 800,
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        
         <tr>
        <td>
        <table><tr><td>
            <uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" />
            </td>
        
        <td> <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" 
                Height="63px" /></td></tr></table>
            
            <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
        </td>
        </tr>

         <tr>
    <td colspan="2" bgcolor="#FFFFCC" style="border: thin ridge #000000">
         <%--หน่วยงาน &nbsp;<asp:DropDownList ID="dd_Department" runat="server" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID" AutoPostBack="true" Font-Names="TH SarabunPSK" Font-Size="14">

            </asp:DropDownList> <br/>--%>
        ประเภทเงิน&nbsp;
                <%--<asp:DropDownList ID="dd_BudgetAdjust" runat="server" AutoPostBack="true" DataTextField="MONEY_TYPE_DESCRIPTION" DataValueField="MONEY_TYPE_ID">
                </asp:DropDownList>--%>
        <telerik:radcombobox ID="rcb_Moneytype" Runat="server" Width="300px" Height="300px" 
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
                </telerik:radcombobox>
   
   </td>
    </tr>
       
        
        <tr bgcolor="#CCFFCC">
            <td>
                <uc3:UC_OutsideBudget_Amount_Detail ID="UC_OutsideBudget_Amount_Detail1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>ยกเลิกการอนุมัติลูกหนี้เงินยืมนอกงบประมาณ</td>
        </tr>
        <tr>
            <td>

                
                <uc2:UC_Disburse_Debtor_Approve_Cancel ID="UC_Disburse_Debtor_Approve_Cancel1" runat="server" />

                
            </td>
        </tr>
    </table>
     <div id="dialog_edit" title="เพิ่มสถานะ" style="display:none">  
    <iframe id="1234" width="700px" height="600px"></iframe>
    </div>
</asp:Content>

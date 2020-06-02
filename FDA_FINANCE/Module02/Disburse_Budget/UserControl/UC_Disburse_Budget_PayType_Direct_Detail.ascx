<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_PayType_Direct_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_Pay_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<br />
<div class="panel panel-body"  style="width:80%;padding-left:5%;">
       
<asp:Panel ID="Panel5" runat="server" Width ="100%" GroupingText="รายละเอียด">
<table width="100%">
    <tr>
        <td align="right">เลขเอกสาร :</td>
        <td>
            <asp:Label ID="lb_DOC_NUMBER" runat="server"></asp:Label>
        </td>
        <td align="right">เลขที่เบิก :</td>
        <td>
            <asp:Label ID="lb_BILL_NUMBER" runat="server"></asp:Label>
        </td>
        <td align="right">เลขขบ. :</td>
        <td>
            <asp:Label ID="lb_GFMIS_NUMBER" runat="server"></asp:Label>
        </td>
        <td align="right">เลขฎีกา :</td>
        <td>
            <asp:Label ID="lb_deeka" runat="server"></asp:Label>
        </td>
    </tr>
</table>
    </asp:Panel>
</div>

<div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel1" runat="server" Width ="100%" GroupingText="บันทึกเลขปลดจ่าย" Enabled="false">
<table width="100%">
       
    <tr>
        <td align="right">เลขปลดจ่าย : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_APPROVE_NUMBER" runat="server"></asp:TextBox>
            (*)
        </td>
        <td align="right">วันที่บันทึกเลขปลดจ่าย : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_RETURN_APPROVE_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_RETURN_APPROVE_DATE" runat="server"></asp:TextBox>

        </td>
    </tr>
    
    
</table>
</asp:Panel>
</div>

    <div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel2" runat="server" Width ="100%" GroupingText ="บันทึกใบแจ้งหนี้" Enabled="false">
<table width="100%">
<tr>
        <td align="right">ใบแจ้งหนี้เลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_INVOICE_NUMBER" runat="server"></asp:TextBox>(*)
        </td>
        <td align="right">ใบแจ้งหนี้ลงวันที่ : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_INVOICE_DATE" runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_INVOICE_DATE" runat="server"></asp:TextBox>
        </td>
    <td>วันที่ทำใบแจ้งหนี้ : </td>
    <td>
        <asp:TextBox ID="txt_INVOICES_DATE_SAVE" runat="server"></asp:TextBox>
    </td>
    </tr>
   
</table>
</asp:Panel>
        </div>

    <div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel3" runat="server" Width ="100%" GroupingText ="บันทึกเลขที่ใบกำกับภาษี" Enabled="false">
<table width="100%">
 <tr>
    <td align="right">ใบกำกับภาษีเลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_TAX_RECEIPT_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ใบกำกับภาษีเลขที่  : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_TAX_RECEIPT_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_TAX_RECEIPT_DATE" runat="server"></asp:TextBox>

        </td>
    </tr>
</table>
</asp:Panel>
</div>

    <div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel4" runat="server" Width ="100%" GroupingText ="บันทึกเลขที่ใบเสร็จ" Enabled="false" style="display:none;">
<table width="100%">
 <tr>
    <td align="right">ใบเสร็จเลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_RECEIPT_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ใบเสร็จ  : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_TAX_RECEIPT_DATE" Runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_RECEIPT_DATE" runat="server"></asp:TextBox>

        </td>
    </tr>
</table>
</asp:Panel>
        </div>

    <div class="panel panel-body"  style="width:80%;padding-left:5%;">
<asp:Panel ID="Panel6" runat="server" Width ="100%" GroupingText ="บันทึกการรับใบหักภาษี" Enabled="false">
<table width="100%">
 <tr>
    <td align="right">การรับใบหักภาษี : </td>
        <td>
            <asp:CheckBox ID="cb_IS_RECEIVE_TAX" runat="server" />
        </td>
        <td align="right">ชื่อผู้มารับใบหักภาษี : </td>
     <td>
            <asp:TextBox ID="txt_RECEIVER_TAX_NAME" runat="server"></asp:TextBox>
        </td>
     <td align="right">
         วันที่มารับใบหักภาษี :
     </td>
        <td>
            <asp:TextBox ID="txt_RECEIVE_TAX_DATE" runat="server"></asp:TextBox>

        </td>
    </tr>
</table>
</asp:Panel>
        </div>
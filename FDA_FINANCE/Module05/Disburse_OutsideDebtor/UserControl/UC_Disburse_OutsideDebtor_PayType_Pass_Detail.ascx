<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor_PayType_Pass_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor_PayType_Pass_Detail" %>
<%@ Register Assembly="Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4"
    Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
<table>
    <tr>
        <td align="right">เลขที่ ขบ. : </td>
        <td>
            <asp:TextBox ID="txt_GF_NUMBER" runat="server"></asp:TextBox>
        </td>
      <td align="right">โอนสิทธ์ : </td>
        <td>
            <asp:TextBox ID="txt_TRANSFER_DESCRIPTION" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่โอน : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_TRANSFER_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
        <td align="right">เลขที่สัญญา : </td>
        <td>
            <asp:TextBox ID="txt_CONTACT_NUMBER" runat="server"></asp:TextBox>
        </td>
    </tr>
   
    <tr>
        <td align="right">บก. อนุมัติ : </td>
        <td>
            <asp:TextBox ID="txt_RETURN_APPROVE_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ บก. อนุมัติ : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_RETURN_APPROVE_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
    
    <tr>
        <td align="right">เลขบค.บจ. : </td>
        <td>
            <asp:TextBox ID="txt_REFERENCE_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ออกเลขบค.บจ. : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_REFERENCE_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
        <td align="right">ใบแจ้งหนี้เลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_INVOICE_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">ใบแจ้งหนี้ลงวันที่ : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_INVOICE_DATE" runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
    <tr>
    <td align="right">ใบกำกับภาษีเลขที่ : </td>
        <td>
            <asp:TextBox ID="txt_TAX_RECEIPT_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">วันที่ใบกำกับภาษีเลขที่  : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_TAX_RECEIPT_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
</table>
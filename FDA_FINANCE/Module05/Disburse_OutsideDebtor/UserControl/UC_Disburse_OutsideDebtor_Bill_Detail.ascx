<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor_Bill_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor_Bill_Detail" %>
<%@ Register Assembly="Telerik.Web.UI, Version=2009.2.701.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4"
    Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
<table>
    <tr>
        <td align="right">เลข ขบ. : </td>
        <td><asp:TextBox ID="txt_GFMIS" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่บันทึกเลข ขบ. : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_GFMIS_DATE" runat="server">
            </telerik:RadDatePicker>
        </td>
    </tr>
</table>
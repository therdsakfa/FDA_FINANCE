<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Search_From_Cure_Study.ascx.vb" Inherits="FDA_FINANCE.UC_Search_From_Cure_Study" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
ค้นหาข้อมูล
<table>
    <tr>
        <td align="right">วันที่เอกสาร : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_DOC_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
        <td align="right">เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">ชื่อ-นาสกุล : </td>
        <td>
            <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่เบิก : </td>
        <td>
            <telerik:RadDatePicker ID="rdp_BILL_DATE" Runat="server">
            </telerik:RadDatePicker>
        </td>
        <td align="right">เลขที่เบิก : </td>
        <td>
            <asp:TextBox ID="txt_BILL_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">เลข ขบ. : </td>
        <td>
            <asp:TextBox ID="txt_GFMIS" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
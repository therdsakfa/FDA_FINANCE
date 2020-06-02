<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Debtor_Bill_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Debtor_Bill_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="800px">
<tr>
        <td align="right">ประเภทขบ.  : </td>
        <td>
           <asp:DropDownList ID="dd_KType" runat="server" DataTextField="K_TYPE_NAME" DataValueField="K_TYPE_ID" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เลข ขบ. : </td>
        <td>
            <asp:Label ID="lb_K" runat="server"></asp:Label> &nbsp; <asp:TextBox ID="txt_GFMIS" runat="server" MaxLength="10"></asp:TextBox>(10 ตัวอักษร)</td>
    </tr>
    <tr>
        <td align="right">วันที่บันทึกเลข ขบ. : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_GFMIS_DATE" runat="server">
            </telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_GFMIS_DATE" runat="server" class="validate[required] text-input"></asp:TextBox>
        </td>
    </tr>
</table>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_Bill_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_Bill_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style type="text/css">
    .auto-style1
    {
        height: 26px;
    }
</style>

<table width="800px">
<tr>
        <td align="right" class="auto-style1">ประเภทเลข GFMIS.  : </td>
        <td class="auto-style1">
            <asp:DropDownList ID="dd_KType" runat="server" DataTextField="K_TYPE_NAME" DataValueField="K_TYPE_ID" AutoPostBack="True">
            </asp:DropDownList>
           
        </td>
    </tr>
    <tr>
        <td align="right">เลข GFMIS : </td>
        <td>
            <asp:Label ID="lb_K" runat="server"></asp:Label> &nbsp; 
            <asp:TextBox ID="txt_GFMIS" runat="server" MaxLength="10" ></asp:TextBox>(10 ตัวอักษร)</td>
    </tr>
    <tr>
        <td align="right">วันที่บันทึกเลข GFMIS. : </td>
        <td>
            <asp:TextBox ID="rdp_GFMIS_DATE" runat="server" ></asp:TextBox>
        </td>
    </tr>
    </table>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReceiveMoney_Detail_Bank.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReceiveMoney_Detail_Bank" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="900px">
    <tr>
        <td align="right">ชื่อธนาคาร : </td>
        <td>
           <%-- <asp:DropDownList ID="dl_BANK_NAME" runat="server"></asp:DropDownList>--%>
            <asp:TextBox ID="txt_BANK_NAME" runat="server"></asp:TextBox>
        </td>
        <td align="right">สาขา : </td>
        <td>
            <asp:TextBox ID="txt_BANK_BRANCH_NAME" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่เช็ค : </td>
        <td>
            <asp:TextBox ID="txt_CHECK_NUMBER" runat="server" ></asp:TextBox>
        </td>
        <td align="right">วันที่เช็ค : </td>
        <td>
            <%--<telerik:RadDatePicker ID="rdp_CHECK_DATE" runat="server"></telerik:RadDatePicker>--%>
            <asp:TextBox ID="txt_CHECK_DATE" runat="server" ></asp:TextBox>
        </td>
    </tr>
</table>
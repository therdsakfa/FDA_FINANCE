<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_OutsideBudget_Checker_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_OutsideBudget_Checker_Detail" %>
<table width="100%">
    <tr>
        <td align="right">
            วันที่ :
        </td>
        <td>
            <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            ผล :</td>
        <td>
            <asp:RadioButtonList ID="rdl_result" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">ผ่านการตรวจสอบ</asp:ListItem>
                <asp:ListItem Value="2">ไม่ผ่านการตรวจสอบ</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
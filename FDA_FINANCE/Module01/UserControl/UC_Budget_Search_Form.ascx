<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Search_Form.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Search_Form" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    #tb_search {
        font-size: 12px;
    }
</style>
<h3>ค้นหาข้อมูล</h3>
<table id="tb_search">
    <tr>
        <td align="right">
            เลขที่เอกสาร :
        </td>
        <td>
            <asp:TextBox ID="txt_Doc_number" runat="server"></asp:TextBox>
        </td>
        <td align="right">จำนวนเงิน :</td>
        <td style="width:40px;">
            <asp:DropDownList ID="dd_eual" runat="server">
                <asp:ListItem>=</asp:ListItem>
                <asp:ListItem>&gt;</asp:ListItem>
                <asp:ListItem>&lt;</asp:ListItem>
            </asp:DropDownList></td>
        <td>
            <asp:TextBox ID="txt_Money" runat="server"></asp:TextBox>
        </td>
        <td align="right">
            ครั้งที่ :
        </td>
        <td>
            <asp:TextBox ID="txt_count" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
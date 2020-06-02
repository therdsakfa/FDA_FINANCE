<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Search_Form_with_description.ascx.vb" Inherits="FDA_FINANCE.UC_Search_Form_with_description" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    #tb_search {
        font-size: 12px;
    }
</style>
ค้นหาข้อมูล
<table id="tb_search" >
    <tr>
        <td align="right">เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
        <td align="right">เลขที่เบิก : </td>
        <td>
            <asp:TextBox ID="txt_BILL_NUMBER" runat="server"></asp:TextBox>
        </td>
        <%--<td>
            เลข ขบ. :</td>
        <td>
            <asp:TextBox ID="txt_GFMIS" runat="server"></asp:TextBox>
        </td>--%>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
        </td>
        <td align="right">รายละเอียด :</td>
        <td>
            <asp:TextBox ID="txt_des" runat="server"></asp:TextBox>
        </td>
       <%-- <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>--%>
    </tr>
</table>
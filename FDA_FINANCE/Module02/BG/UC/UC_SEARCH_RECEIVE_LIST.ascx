<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_SEARCH_RECEIVE_LIST.ascx.vb" Inherits="FDA_FINANCE.UC_SEARCH_RECEIVE_LIST" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
ค้นหาข้อมูล
<table width="100%" id="tb_search">
    <tr>
        
        <td align="right">เลขที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_DOC_NUMBER" runat="server"></asp:TextBox>
        </td>
       <td align="right">วันที่เอกสาร : </td>
        <td>
            <asp:TextBox ID="txt_Doc_Date" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            วันที่รับเอกสาร :</td>
        <td>
            <asp:TextBox ID="txt_receive_date" runat="server"></asp:TextBox>
        </td>
        <td align="right">ปีงบประมาณ</td>
        <td>
            <asp:DropDownList ID="ddl_budget_year" runat="server">
                
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            งาน/โครงการ :</td>
        <td colspan="3" >
            <asp:DropDownList ID="ddl_product" runat="server" width="100%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            หมวดรายจ่าย :</td>
        <td colspan="3">
            <asp:DropDownList ID="ddl_operation_bg" runat="server" width="100%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            กอง :</td>
        <td colspan="3">
            <asp:DropDownList ID="ddl_department" runat="server" width="100%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            ประเภทเงิน :</td>
        <td colspan="3">
            <asp:RadioButtonList ID="rdl_budget_type" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">เงินงบประมาณ</asp:ListItem>
                <asp:ListItem Value="2">เงินกันเบิกเหลื่อมปี</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
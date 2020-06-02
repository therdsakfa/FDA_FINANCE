<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Show.aspx.vb" Inherits="FDA_FINANCE.Frm_Maintain_ReturnMoney_Debtor_OutsideBudget_Show" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information.ascx" tagname="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information" tagprefix="uc1" %>
<%@ Register src="UseControl/UC_Maintain_ReturnMoney_OutsideBudget.ascx" tagname="UC_Maintain_ReturnMoney_OutsideBudget" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="3">
                <uc1:UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information ID="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>รายการการคืนเงิน</td>
            <td>สถานะการคืนเงิน : 
                <asp:DropDownList ID="dl_MoneyReturnStatus" runat="server">
                    <asp:ListItem Value="1">ยังไม่คืนเงิน</asp:ListItem>
                    <asp:ListItem Value="2">คืนเงินแล้วยังไม่ครบ</asp:ListItem>
                    <asp:ListItem Value="2">คืนเงินครบแล้ว</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Button ID="btn_Insert" runat="server" Text="เพิ่มข้อมูล" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <uc2:UC_Maintain_ReturnMoney_OutsideBudget ID="UC_Maintain_ReturnMoney_OutsideBudget1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

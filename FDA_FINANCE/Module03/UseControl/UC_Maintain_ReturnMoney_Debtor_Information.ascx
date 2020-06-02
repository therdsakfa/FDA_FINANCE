<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_Debtor_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_Debtor_Information" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
รายละเอียดลูกหนี้เงินยืม
<table style="border:1px solid black;" width="100%">
    <tr>
        <td>เลขที่สัญญา : </td>
        <td>
            <asp:Label ID="lbl_ContractNumber" runat="server" Text=""></asp:Label>
        </td>
        <td>ประเภทเงิน : </td>
        <td>
            <asp:Label ID="lbl_MoneyType" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>ชื่อผู้ยืม : </td>
        <td>
            <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
        </td>
        <td>รายละเอียดการยืม</td>
        <td>
            <asp:Label ID="lbl_DebtorDescription" runat="server" Text=""></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td>จำนวนเงินที่ยืม : </td>
        <td>
            <asp:Label ID="lbl_Amount" runat="server" Text="0.00"></asp:Label>
        &nbsp;บาท</td>
        <td>วันครบกำหนดชำระเงินคืน : </td>
        <td>
            <asp:Label ID="lbl_DeathlineDate" runat="server" Text=""></asp:Label>
        </td>
    </tr>
   <%-- <tr>
        
        <td>เลขที่เอกสารส่งใช้หนี้ : </td>
        <td>
            <asp:Label ID="lbl_DocNumber" runat="server" Text=""></asp:Label>
        </td>
        <td>วันที่เอกสารส่งใช้หนี้ : </td>
        <td>
            <asp:Label ID="lbl_DocDate" runat="server" Text=""></asp:Label>
        </td>
    </tr>--%>
</table>
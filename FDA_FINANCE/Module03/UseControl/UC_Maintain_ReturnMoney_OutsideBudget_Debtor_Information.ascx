<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReturnMoney_OutsideBudget_Debtor_Information" %>
รายละเอียดลูกหนี้เงินยืม นอกงบประมาณ
<table style="border:1px solid black;" width="900px">
    <tr>
        <td>เลขที่สัญญา : </td>
        <td colspan="5">
            <asp:Label ID="lbl_ContractNumber" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>ประเภทเงิน : </td>
        <td colspan="2">
            <asp:Label ID="lb_level1" runat="server" Text=""></asp:Label>
        </td>
        <td>รายการย่อย : </td>
        <td colspan="2">
            <asp:Label ID="lb_level2" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>ย่อย 1 : </td>
        <td colspan="2">
            <asp:Label ID="lb_level3" runat="server" Text=""></asp:Label>
        </td>
        <td>ย่อย 2 : </td>
        <td colspan="2">
            <asp:Label ID="lb_level4" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>ชื่อผู้ยืม : </td>
        <td>
            <asp:Label ID="lbl_Name" runat="server" Text=""></asp:Label>
        </td>
        <td>รายละเอียดการยืม : </td>
        <td>
            <asp:Label ID="lbl_DebtorDescription" runat="server" Text=""></asp:Label>
        </td>
       <td>

       </td>
        <td>

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
       
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
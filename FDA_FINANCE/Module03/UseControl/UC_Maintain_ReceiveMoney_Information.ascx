<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_ReceiveMoney_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_ReceiveMoney_Information" %>
รายละเอียด บันทึกการรับเงิน
<table style="border:1px solid black;" width="300px">
    <tr>
        <td>จำนวนเงินที่รับทั้งหมด : </td>
        <td>
            <asp:Label ID="lbl_ShowMoneyReceiveAll" runat="server" Text="0.00"></asp:Label>
        </td>
        <td>  บาท</td>
    </tr>
    <tr>
        <td>จำนวนเงิน (เงินสด) : </td>
        <td>
            <asp:Label ID="lbl_ShowMoneyReceiveCash" runat="server" Text="0.00"></asp:Label>
        </td>
        <td>  บาท</td>
    </tr>
    <tr>
        <td>จำนวนเงิน (เช็ค) : </td>
        <td>
            <asp:Label ID="lbl_ShowMoneyReceiveCheck" runat="server" Text="0.00"></asp:Label>
        </td>
        <td>  บาท</td>
    </tr>
    <tr>
        <td>จำนวนเงิน (โอน) : </td>
        <td>
            <asp:Label ID="lbl_ShowMoneyReceiveTransfer" runat="server" Text="0.00"></asp:Label>
        </td>
        <td>  บาท</td>
    </tr>
    <tr>
        <td>จำนวนเงิน (ยกเลิก) : </td>
        <td>
            <asp:Label ID="lbl_ShowMoneyReceiveCancel" runat="server" Text="0.00"></asp:Label>
        </td>
        <td>  บาท</td>
    </tr>
</table>
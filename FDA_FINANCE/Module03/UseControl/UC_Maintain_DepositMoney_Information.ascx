<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Maintain_DepositMoney_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Maintain_Deposit_Money_Information" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
รายละเอียดการบันทึกฝากเงิน/ส่งคลัง
<table>
    <tr>
        <td valign="top">
            <table style="border:1px solid black;">
                <tr>
                    <td colspan="3">จำนวนเงินที่มี</td>
                </tr>
                <tr>
                    <td>เงินสด : </td>
                    <td>
                        <asp:Label ID="lbl_CashHave" runat="server" Text="0.00"></asp:Label>
                    </td>
                    <td align="left"> บาท</td>
                </tr>
                <tr>
                    <td>เช็ค : </td>
                    <td>
                        <asp:Label ID="lbl_CheckHave" runat="server" Text="0.00"></asp:Label>
                    </td>
                    <td align="left"> บาท</td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <table style="border:1px solid black;">
                <tr>
                    <td colspan="3">จำนวนเงินที่ส่งคลัง</td>
                </tr>
                <tr>
                    <td>เงินสด : </td>
                    <td>
                        <asp:Label ID="lbl_CashDeposit" runat="server" Text="0.00"></asp:Label>
                    </td>
                    <td align="left"> บาท</td>
                </tr>
                <tr>
                    <td>เช็ค : </td>
                    <td>
                        <asp:Label ID="lbl_CheckDeposit" runat="server" Text="0.00"></asp:Label>
                    </td>
                    <td align="left"> บาท</td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <table style="border:1px solid black;">
                <tr>
                    <td colspan="3">เงินคงเหลือธนาคาร</td>
                </tr>
                <tr>
                    <td>เงินสด : </td>
                    <td>
                        <asp:Label ID="lbl_CashBank" runat="server" Text="0.00"></asp:Label>
                    </td>
                    <td align="left"> บาท</td>
                </tr>
                <tr>
                    <td>เช็ค : </td>
                    <td>
                        <asp:Label ID="lbl_CheckBank" runat="server" Text="0.00"></asp:Label>
                    </td>
                    <td align="left"> บาท</td>
                </tr>
            </table>
        </td>
        <td  valign="top">
            <table style="border:1px solid black;">
                <tr>
                    <td>ประเภทเงิน : </td>
                    <td>
                        <asp:Label ID="lb_level1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>รายการย่อย : </td>
                    <td>
                        <asp:Label ID="lb_level2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>รายการย่อย 1 : </td>
                    <td>
                        <asp:Label ID="lb_level3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>รายการย่อย 2 : </td>
                    <td>
                        <asp:Label ID="lb_level4" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>เลขที่บัญชี : </td>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="เลขที่บัญชี"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
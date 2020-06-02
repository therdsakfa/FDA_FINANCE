<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Reciver_Details.ascx.vb" Inherits="FDA_FINANCE.UC_Reciver_Details" %>
<table>
    <tr>
        <td align="center">ชื่อ-นามสกุล : </td>
        <td>
            <asp:TextBox ID="txt_RECEIVER_NAME" runat="server" class="validate[required] text-input" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center">ตำแหน่ง : </td>
        <td>
            <asp:TextBox ID="txt_POSITION_NAME" runat="server" class="validate[required] text-input" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
    <td align="center">
    สถานะผู้รับเงิน : 
    </td>
    <td>
        <asp:CheckBox ID="cb_IS_RECEIVER" runat="server" Text="เป็นผู้รับเงิน" />
    </td>
    </tr>
</table>
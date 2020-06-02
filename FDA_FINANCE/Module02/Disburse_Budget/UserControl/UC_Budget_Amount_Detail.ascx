<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Budget_Amount_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Budget_Amount_Detail" %>
<style type="text/css">
    #tb_amount {
        font-size: 14px;
    }

    .auto-style1 {
        text-align:right;
    }
</style>
<b>รายละเอียดงบประมาณ</b>

<table width="100%" id="tb_amount">
    <tr>
        <td align="right"><b>งบประมาณที่ได้รับ : </b></td>
        <td class="auto-style1" >
            &nbsp;
            <asp:Label ID="txt_Amount" runat="server"  Text="0.00"></asp:Label>&nbsp;
            บาท</td>
        <td colspan="4">

        </td>
    </tr>
    <tr>
        <td align="right" ><b>เพิ่ม/ลด : </b></td>
        <td class="auto-style1" >&nbsp;
            <asp:Label ID="txt_transfer_diff" runat="server"  Text="0.00"></asp:Label>&nbsp;
            บาท</td>
        <td align="right" ><b>ยอดเบิกก่อนอนุมัติ : </b></td>
        <td class="auto-style1" >&nbsp;
            <asp:Label ID="txt_disburse_before_app" runat="server"  Text="0.00"></asp:Label>&nbsp;
            บาท</td>
        <td align="right" ><b>ยอดเบิกหลังอนุมัติ : </b></td>
        <td class="auto-style1" >&nbsp;
            <asp:Label ID="txt_disburse_app" runat="server"  Text="0.00"  ></asp:Label>
            &nbsp;บาท</td>
    </tr>
    <tr>
        <td align="right"><b>โอนเบิกแทน : </b></td>
        <td class="auto-style1"  >&nbsp;
            <asp:Label ID="txt_transfer_out" runat="server"  Text="0.00"></asp:Label>&nbsp;
            บาท</td>
        <td align="right"><b>เงินคงเหลือก่อนอนุมัติ : </b></td>
        <td class="auto-style1">&nbsp;
             <asp:Label ID="txt_balance_before_app" runat="server"  Text="0.00"></asp:Label>&nbsp;
            บาท</td>
        <td align="right"><b>เงินคงเหลือหลังอนุมัติ : </b></td>
        <td class="auto-style1">&nbsp;
            <asp:Label ID="txt_balance_app" runat="server"  Text="0.00"  ></asp:Label>&nbsp;
           
            
            บาท</td>
    </tr>
</table>
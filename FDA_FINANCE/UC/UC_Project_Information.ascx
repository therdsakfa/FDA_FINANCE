<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Project_Information.ascx.vb" Inherits="FDA_FINANCE.UC_Project_Information" %>
<table style="width:auto;">
    <tr>
        <td >
            <b>ชื่อโครงการ/กิจกรรม :</b>
        </td>
        <td>&nbsp;
            <asp:Label ID="lb_proj_name" runat="server" ></asp:Label>
        </td>
        <td>
            &nbsp;<b>ปีงบประมาณ :</b>
        </td>
        <td>
            &nbsp;
            <asp:Label ID="lb_year" runat="server"></asp:Label>
        </td>
    </tr>

    <tr>
        <td align="right">
            <b>รหัสกิจกรรม : </b></td>
        <td>&nbsp;
            <asp:Label ID="lb_code" runat="server"></asp:Label>
        </td>
        <td>
            </td>
        <td>
            &nbsp;</td>
    </tr>

</table>
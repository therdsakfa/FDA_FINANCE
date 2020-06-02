<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Study_GF_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Study_GF_Detail" %>
<table width="800px">
  
    <tr>
        <td align="right">เลข ขบ. : </td>
        <td>
            <asp:Label ID="lb_K" runat="server" Text="KL"></asp:Label> &nbsp; 
            <asp:TextBox ID="txt_GFMIS" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่บันทึกเลข ขบ. : </td>
        <td>
            <asp:TextBox ID="rdp_GFMIS_DATE" runat="server" ></asp:TextBox>
        </td>
    </tr>
</table>
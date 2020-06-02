<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Cure_GF_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Cure_GF_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table width="800px">
    <tr>
        <td align="right">ประเภทการจ่าย :</td>
        <td>
            <asp:RadioButtonList ID="rd_pay_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Value="1">เข้าสวัสดิการ</asp:ListItem>
                <asp:ListItem Value="2">ไม่เข้าสวัสดิการ</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
<tr>
        <td align="right">ประเภทขบ.  : </td>
        <td>
            <asp:DropDownList ID="dd_KType" runat="server" DataTextField="K_TYPE_NAME" 
                DataValueField="K_TYPE_ID" AutoPostBack="True" Enabled="false">
            </asp:DropDownList>
           
        </td>
    </tr>
    <tr>
        <td align="right">เลข ขบ. : </td>
        <td>
            <asp:Label ID="lb_K" runat="server"></asp:Label> &nbsp; 
            <asp:TextBox ID="txt_GFMIS" runat="server" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่บันทึกเลข ขบ. : </td>
        <td>
            <asp:TextBox ID="rdp_GFMIS_DATE" runat="server" Enabled="false"></asp:TextBox>
        </td>
    </tr>
</table>
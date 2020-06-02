<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfare_Home_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Welfare_Home_Detail" %>
<table>
    <tr>
        <td align="right">วันที่เบิก : </td>
        <td>
            <asp:TextBox ID="txt_WELFARE_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รายละเอียดการเบิก : </td>
        <td>
            <asp:TextBox ID="txt_DESCRIPTION" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เดือนที่อยู่ : </td>
        <td>
            <asp:DropDownList ID="dd_month_live" runat="server">
                <asp:ListItem Value="1">มกราคม</asp:ListItem>
                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
            </asp:DropDownList>
           </td>
    </tr>
    <tr>
            <td align="right">เดือนที่เบิก : </td>
            <td>
                <asp:DropDownList ID="dd_month_dis" runat="server">
                    <asp:ListItem Value="1">มกราคม</asp:ListItem>
                <asp:ListItem Value="2">กุมภาพันธ์</asp:ListItem>
                <asp:ListItem Value="3">มีนาคม</asp:ListItem>
                <asp:ListItem Value="4">เมษายน</asp:ListItem>
                <asp:ListItem Value="5">พฤษภาคม</asp:ListItem>
                <asp:ListItem Value="6">มิถุนายน</asp:ListItem>
                <asp:ListItem Value="7">กรกฎาคม</asp:ListItem>
                <asp:ListItem Value="8">สิงหาคม</asp:ListItem>
                <asp:ListItem Value="9">กันยายน</asp:ListItem>
                <asp:ListItem Value="10">ตุลาคม</asp:ListItem>
                <asp:ListItem Value="11">พฤศจิกายน</asp:ListItem>
                <asp:ListItem Value="12">ธันวาคม</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
 
        <tr>
        <td align="right" >ผู้เบิก : </td>
        <td >
        
            <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="CUSTOMER_ID" DataTextField="CUSTOMER_NAME" AutoPostBack="true">
                
            </asp:DropDownList>
        
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <asp:TextBox ID="txt_AMOUNT" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:CheckBox ID="cb_IS_PAY_HOME" runat="server"  Text="ไม่จ่ายค่าเช่าบ้าน" />
        </td>
    </tr>
</table>
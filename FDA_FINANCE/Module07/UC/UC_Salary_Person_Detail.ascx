<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Salary_Person_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Salary_Person_Detail" %>
<table width="80%" align="center">
    <tr>
        <td align="right"  style="width: 30%">
            ชื่อ-นามสกุล :
        </td>
        <td style="width: 70%">
            <asp:DropDownList ID="ddlName" runat="server"  Height="30px" Width="70%" DataTextField="fullname" DataValueField="IDRUN"></asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td align="right"  style="width: 30%">
            เดือนที่ทำรายการ :</td>
        <td style="width: 70%">
            <asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true"  Height="30px" Width="40%">
                
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

</table>
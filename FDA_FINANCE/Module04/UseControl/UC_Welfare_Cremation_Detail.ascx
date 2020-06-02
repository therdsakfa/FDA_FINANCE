<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfare_Cremation_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Welfare_Cremation_Detail" %>
<table>
    <tr>
        <td align="right">วันที่เบิก : </td>
        <td>
            <asp:TextBox ID="txt_WELFARE_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
   <%-- <tr>
        <td align="right">เลขบัตรประชาชน : </td>
        <td>
            <asp:TextBox ID="txt_PERSONAL_ID" runat="server"></asp:TextBox>
        </td>
    </tr>--%>
    <tr>
        <td align="right">ชื่อ-นามสกุล : </td>
        <td>
            <%--<asp:TextBox ID="txt_NAME" runat="server"></asp:TextBox>--%>
             <asp:DropDownList ID="dd_CUSTOMER" runat="server" DataValueField="CUSTOMER_ID" DataTextField="CUSTOMER_NAME" AutoPostBack="true">
             </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เลขบัตรประชาชน :</td>
        <td>
            <asp:Label ID="lb_Personal_id" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">จำนวนเงิน : </td>
        <td>
            <asp:TextBox ID="txt_AMOUNT" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หน่วยงาน : </td>
        <td>
            <asp:DropDownList ID="dl_Department" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เดือนที่เบิก : </td>
        <td>
                <asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true">
                    <%--<asp:ListItem Value="">---เลือกเดือน---</asp:ListItem>--%>
                    <asp:ListItem Value="มกราคม">มกราคม</asp:ListItem>
                    <asp:ListItem Value="กุมภาพันธ์">กุมภาพันธ์</asp:ListItem>
                    <asp:ListItem Value="มีนาคม">มีนาคม</asp:ListItem>
                    <asp:ListItem Value="เมษายน">เมษายน</asp:ListItem>
                    <asp:ListItem Value="พฤษภาคม">พฤษภาคม</asp:ListItem>
                    <asp:ListItem Value="มิถุนายน">มิถุนายน</asp:ListItem>
                    <asp:ListItem Value="กรกฎาคม">กรกฎาคม</asp:ListItem>
                    <asp:ListItem Value="สิงหาคม">สิงหาคม</asp:ListItem>
                    <asp:ListItem Value="กันยายน">กันยายน</asp:ListItem>
                    <asp:ListItem Value="ตุลาคม">ตุลาคม</asp:ListItem>
                    <asp:ListItem Value="พฤศจิกายน">พฤศจิกายน</asp:ListItem>
                    <asp:ListItem Value="ธันวาคม">ธันวาคม</asp:ListItem>
                </asp:DropDownList>
        </td>
    </tr>
</table>
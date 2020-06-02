<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Welfare_Cremation_Import.aspx.vb" Inherits="FDA_FINANCE.Frm_Welfare_Cremation_Import" %>

<%@ Register src="UseControl/UC_Welfare_Cremation_Import.ascx" tagname="UC_Welfare_Cremation_Import" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            
            <td align="right">
                ปีที่เบิก
                <asp:DropDownList ID="dd_BudgetYear" runat="server" AutoPostBack="true" DataTextField="byear" DataValueField="byear" Width="100px">
                </asp:DropDownList>
                <asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="">---เดือนที่ดึงข้อมูล---</asp:ListItem>
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
                <asp:DropDownList ID="dd_month_dis" runat="server">
                    <asp:ListItem Value="">---เดือนที่เบิก---</asp:ListItem>
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
                <asp:Button ID="btn_Save" runat="server" Text="ดึงข้อมูล" />
            </td>
        </tr>
        <tr>
            <td>
                
                <uc1:UC_Welfare_Cremation_Import ID="UC_Welfare_Cremation_Import1" runat="server" />
                
            </td>
        </tr>
    </table>
</asp:Content>

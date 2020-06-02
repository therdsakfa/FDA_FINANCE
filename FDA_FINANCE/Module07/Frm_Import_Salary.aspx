<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Import_Salary.aspx.vb" Inherits="FDA_FINANCE.Frm_Import_Salary" %>
<%@ Register src="UC/UC_Import_Salary.ascx" tagname="UC_Import_Salary" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/css_validate/customMessages.css" rel="stylesheet" />
    <link href="../css/css_validate/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#<%= btn_Save.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
            
            <td align="right">
                ปีที่เบิก
                <asp:DropDownList ID="dd_BudgetYear" runat="server" AutoPostBack="true" DataTextField="byear" DataValueField="byear" Width="100px">
                </asp:DropDownList>
                <asp:DropDownList ID="dd_month" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="0">---เดือนที่ดึงข้อมูล---</asp:ListItem>
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
                <asp:DropDownList ID="dd_month_dis" runat="server">
                    <asp:ListItem Value="0">---เดือนที่เบิก---</asp:ListItem>
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
                <asp:Button ID="btn_Save" runat="server" Text="ดึงข้อมูล" />
            </td>
        </tr>
        <tr>
            <td>
                
                <uc1:UC_Import_Salary ID="UC_Import_Salary1" runat="server" />
                
            </td>
        </tr>
    </table>
</asp:Content>
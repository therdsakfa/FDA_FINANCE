<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Person_In_Report_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Person_In_Report_Edit" %>
<%@ Register src="UserControl/UC_Person_In_Report_Detail.ascx" tagname="UC_Person_In_Report_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>แก้ไขผู้ตรวจสอบในรายงานทะเบียนคุมเช็ค</td>
        </tr>
        
        <tr>
            <td>

                <uc1:UC_Person_In_Report_Detail ID="UC_Person_In_Report_Detail1" runat="server" />

            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="แก้ไขข้อมูล" class="submit" />
                &nbsp;
                </td>
        </tr>
    </table>
</asp:Content>

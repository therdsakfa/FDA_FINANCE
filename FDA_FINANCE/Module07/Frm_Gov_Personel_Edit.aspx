<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Gov_Personel_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Gov_Personel_Edit" %>

<%@ Register src="UC/UC_Gov_Personel_Detail.ascx" tagname="UC_Gov_Personel_Detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script src="../../Scripts/jquery-1.8.2.js"></script>
       <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
<%--        <tr>
            <td>แก้ไขข้อมูลพนักงานราชการ</td>
        </tr>--%>
        
        <tr>
            <td>
           
                <uc1:UC_Gov_Personel_Detail ID="UC_Gov_Personel_Detail1" runat="server" />

            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="แก้ไขข้อมูล" class="submit"  Height="36px" Width="108px"/>
                &nbsp;
                </td>
        </tr>
          <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
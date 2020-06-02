<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Salary_Personal_Edit.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_Personal_Edit" %>
<%@ Register src="UC/UC_Salary_Person_Detail.ascx" tagname="UC_Salary_Person_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.1.js"></script>
    <script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#ctl00_ContentPlaceHolder1_UC_Salary_Person_Detail1_ddlName").searchable();

         });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <asp:Panel ID="Panel1" runat="server" GroupingText="แก้ไขผู้รับเงินเดือน">
    <table>
    <tr>
            <td>
                
                <uc1:UC_Salary_Person_Detail ID="UC_Salary_Person_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
        <td align="center">
        <asp:Button ID="btn_bill_save" runat="server" Text="แก้ไขรายการ" class="submit" style="width: 132px"/>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

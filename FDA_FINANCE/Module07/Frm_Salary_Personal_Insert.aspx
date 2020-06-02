<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Salary_Personal_Insert.aspx.vb" Inherits="FDA_FINANCE.Frm_Salary_Personal_Insert" %>
<%@ Register src="UC/UC_Salary_Person_Detail.ascx" tagname="UC_Salary_Person_Detail" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../Scripts/jquery-1.7.1.js"></script>
<script src="../Scripts/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#ctl00_ContentPlaceHolder1_UC_Salary_Person_Detail1_ddlName").searchable();

         });
       
    </script>
     <style type="text/css">
         .auto-style1 {
             height: 64px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <asp:Panel ID="Panel1" runat="server" GroupingText="บันทึกผู้รับเงินเดือน">
    <table width="100%">
    <tr>
            <td class="auto-style1">
                
                <uc1:UC_Salary_Person_Detail ID="UC_Salary_Person_Detail1" runat="server" />
                
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
        <td align="center" class="auto-style1">
        <asp:Button ID="btn_bill_save" runat="server" Text="บันทึกรายการ" class="submit" Height="39px" Width="114px"/>
        </td>
            
        </tr>
    </table>
    </asp:Panel>
</asp:Content>

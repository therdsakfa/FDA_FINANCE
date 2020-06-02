<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Budget_Overlap_Bill.aspx.vb" Inherits="FDA_FINANCE.Frm_Budget_Overlap_Bill" %>
<%@ Register src="UserControl/UC_Budget_Overlap_Bill.ascx" tagname="UC_Budget_Overlap_Bill" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
    <tr>
            <td>
                วันสิ้นสุดเงินกัน&nbsp;<asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
                <asp:Button ID="btn_bill_save" runat="server" Text="บันทึกข้อมูล" /> &nbsp;
              <asp:Button ID="btnRedirect" runat="server" Text="Button" Style="display:none;" />
                
                <uc1:UC_Budget_Overlap_Bill ID="UC_Budget_Overlap_Bill1" runat="server" />
                
            </td>
        </tr>
        <tr>
        <td>
        
        </td>
            
        </tr>
    </table>
</asp:Content>

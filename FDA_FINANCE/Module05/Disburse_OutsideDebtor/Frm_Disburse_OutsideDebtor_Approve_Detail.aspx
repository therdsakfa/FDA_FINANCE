<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Disburse_OutsideDebtor_Approve_Detail.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_OutsideDebtor_Approve_Detail" %>

<%@ Register src="UserControl/UC_Disburse_OutsideDebtor_Approve_Detail.ascx" tagname="UC_Disburse_OutsideDebtor_Approve_Detail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" GroupingText ="เลือกประเภทการจ่าย">
        <table>
        <tr>
            <td>

                <uc1:UC_Disburse_OutsideDebtor_Approve_Detail ID="UC_Disburse_OutsideDebtor_Approve_Detail1" runat="server" />

            </td>
        </tr>
        <tr>
            <td>
            <asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" />
                </td>
        </tr>
    </table>
    </asp:Panel>
    
</asp:Content>

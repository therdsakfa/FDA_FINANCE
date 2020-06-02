<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Node.Master" CodeBehind="Frm_Disburse_Outside_Budget_Checker.aspx.vb" Inherits="FDA_FINANCE.Frm_Disburse_Outside_Budget_Checker" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/Module02/Disburse_Budget/UserControl/UC_Search_Form.ascx" tagname="UC_Search_Form" tagprefix="uc1" %>

<%@ Register src="../UserControl/UC_OutsideBudget_Checker.ascx" tagname="UC_OutsideBudget_Checker" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-body"  style="width:100%;">
                <h3><font color="black">ตรวจสอบ</font></h3>
</div>
    <div class="panel panel-body"  style="width:100%;">
        <table width="100%"><tr> <td> <uc1:UC_Search_Form ID="UC_Search_Form1" runat="server" /></td>
        <td valign="middle">
            
            <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" Width="80px" CssClass="btn-lg"
                Height="55px" /></td></tr></table>
          </div>
<div class="panel panel-body"  style="width:100%;">
    <table width="100%">
        <tr>
            <td>

                <uc2:UC_OutsideBudget_Checker ID="UC_OutsideBudget_Checker1" runat="server" />

            </td>
        </tr>
    </table>
    </div>
</asp:Content>

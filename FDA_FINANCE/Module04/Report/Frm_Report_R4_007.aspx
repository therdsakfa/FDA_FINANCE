<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R4_007.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R4_007" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="~/Module09/UserControl/UC_Report_SelectDate_Between.ascx" TagPrefix="uc1" TagName="UC_Report_SelectDate_Between" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <uc1:UC_Report_SelectDate_Between runat="server" ID="UC_Report_SelectDate_Between" />
            </td>
            <td>
                <asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>

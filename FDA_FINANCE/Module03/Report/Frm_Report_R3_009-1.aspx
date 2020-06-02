<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/BG_Master2.Master" CodeBehind="Frm_Report_R3_009-1.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R3_009_1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Module03/UseControl/UC_Report_R3_0009-1.ascx" TagPrefix="uc1" TagName="UC_Report_R3_00091" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>รายงานเงินคงเหลือประจำวัน</td>
        </tr>
        <tr>
            <td style="margin-left: 40px">
                <%--<telerik:RadDatePicker ID="rdp_dateReportSelect" runat="server"></telerik:RadDatePicker>--%>
                <asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
    <table>
        <tr>
            <td>
                <uc1:UC_Report_R3_00091 runat="server" id="UC_Report_R3_00091" />
            </td>
        </tr>
    </table>
    </asp:Panel>
    <table>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>

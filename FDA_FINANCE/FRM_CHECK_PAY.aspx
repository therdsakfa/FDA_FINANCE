<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main_Empty.Master" CodeBehind="FRM_CHECK_PAY.aspx.vb" Inherits="FDA_FINANCE.FRM_CHECK_PAY1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td>ref1
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                        <td>ref2
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>

                <telerik:RadGrid ID="rg_log" runat="server" AllowPaging="true" AutoGenerateColumns="false" MasterTableView-AllowFilteringByColumn="true" PageSize="15" Width="100%">
                </telerik:RadGrid>

            </td>
        </tr>
        </table>
</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_SEARCH_REF.aspx.vb" Inherits="FDA_FINANCE.FRM_SEARCH_REF" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
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
    </form>
</body>
</html>

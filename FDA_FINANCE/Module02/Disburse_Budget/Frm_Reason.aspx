<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Reason.aspx.vb" Inherits="FDA_FINANCE.Frm_Reason" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="UserControl/UC_Reason_Reject.ascx" tagname="UC_Reason_Reject" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../css/css_main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td align="center">
                <table>
                    <tr>
                        
                        <td align="right">
                            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                คำอธิบาย :
            </td>
            <td>
                <asp:TextBox ID="txt_Reason" runat="server" Width="300px"></asp:TextBox>
                <asp:Button ID="btnRedirect" runat="server" Text="Button" style="display:none;" />
                        </td>
            <td>
                <asp:Button ID="btn_add" runat="server" Text="บันทึก" CssClass="btn-lg" />
            </td>
                    </tr>
                </table>
            </td>
            
        </tr>
        <tr>
            <td align="right" >
                <uc1:UC_Reason_Reject ID="UC_Reason_Reject1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_Budget_Deeka_Number_Detail.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_Budget_Deeka_Number_Detail" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table width="800px">
    <tr>
        <td align="right">เลขฎีกา : </td>
        <td>
            <asp:TextBox ID="txt_Deeka_number" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td align="right">วันที่บันทึกเลขฎีกา : </td>
        <td>
            <asp:TextBox ID="txt_Deeka_DATE" runat="server" ></asp:TextBox>
        </td>
    </tr>
    </table>
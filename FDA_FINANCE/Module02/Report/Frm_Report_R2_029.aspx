﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Frm_Report_R2_029.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_R2_029" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="700px"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
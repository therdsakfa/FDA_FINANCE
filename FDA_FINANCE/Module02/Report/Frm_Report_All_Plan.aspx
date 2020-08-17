<%@ Page Language="vb" AutoEventWireup="false"  CodeBehind="Frm_Report_All_Plan.aspx.vb" Inherits="FDA_FINANCE.Frm_Report_All_Plan" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
     <table width="100%">
        <tr>
          <td>
              <br />
          </td>
        </tr>
        <tr>
            <td>รายงานแผนปฏิบัติการ

            </td>
        </tr>
            <tr>
          <td>
              <br />
          </td>
        </tr>
         <tr>
            <td>ปีงบประมาณ <asp:DropDownList ID="dd_BudgetYear" runat="server" Width="10%" Height="35%" AutoPostBack="true" DataTextField="byear" DataValueField="byear"></asp:DropDownList> 

            </td>
        </tr>
            <tr>
          <td>
              <br/>
          </td>
        </tr>
        <tr>
            <td>
                หน่วยงาน&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dd_department" runat="server" Width="40%" Height="35%" AutoPostBack="true" DataTextField="DEPARTMENT_DESCRIPTION" DataValueField="DEPARTMENT_ID"></asp:DropDownList>
            </td>
            <td>
                <%--<asp:Button ID="btn_ShowReport" runat="server" Text="ดูรายงาน" />--%>
            </td>
        </tr>
        <tr>
          <td>
              <br />
          </td>
        </tr>
    </table>

    <table width="100%">
        <tr>
            <td>
                
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"></rsweb:ReportViewer>
                
            </td>
        </tr>
    </table>

    </form>
</body>
</html>

   


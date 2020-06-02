<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="FDA_FINANCE.WebForm2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="Module02/Disburse_Budget/UserControl/UC_RELATE_BILL_USER_BERG.ascx" tagname="UC_RELATE_BILL_USER_BERG" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="Button" />
        <asp:Button ID="Button4" runat="server" Text="BANK" />
        <uc1:UC_RELATE_BILL_USER_BERG ID="UC_RELATE_BILL_USER_BERG1" runat="server" />
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" style="display:none;">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="BUDGET_DISBURSE_BILL_ID" HeaderText="BUDGET_DISBURSE_BILL_ID" DataField="BUDGET_DISBURSE_BILL_ID" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DOC_NUMBER" HeaderText="เลขหนังสือ" DataField="DOC_NUMBER" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DOC_DATE" HeaderText="วันที่" DataField="DOC_DATE" DataFormatString="{0:dd/MM/yyyy}">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="CUSTOMER_NAME" HeaderText="ผู้รับเงิน/เจ้าหนี้" DataField="CUSTOMER_NAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AMOUNT" HeaderText="จำนวนเงิน" DataField="AMOUNT" DataFormatString="{0:###,###.##}">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Culture="th-TH">
                                        <DateInput runat="server" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Culture="th-TH"></DateInput>
                                        <Calendar runat="server" CultureInfo="th-TH"></Calendar>
                                    </telerik:RadDatePicker>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                           <%-- <telerik:GridBoundColumn UniqueName="PRINT_DATE" HeaderText="PRINT_DATE" Display="false" DataFormatString="{0:dd/MM/yyyy tt:mm:ss}">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>--%>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
    </div>
    </form>
</body>
</html>

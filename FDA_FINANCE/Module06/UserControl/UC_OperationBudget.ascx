<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_OperationBudget.ascx.vb" Inherits="DTAM.UC_OperationBudget" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="500px">
<MasterTableView >
    <Columns>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" >
        <ItemStyle Width="10%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="รหัส">
        <ItemStyle Width="10%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ชื่อรายละเอียดงบดำเนินงาน">
        <ItemStyle Width="80%" />
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
</telerik:RadGrid>

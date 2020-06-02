<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PayLists.ascx.vb" Inherits="FDA_FINANCE.UC_PayLists" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:radgrid ID="rgPayList" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="500px">
<%--<MasterTableView >
    <Columns>
       <telerik:GridBoundColumn DataField="PATLIST_ID" DataType="System.Int32" HeaderText="PATLIST_ID" 
            ReadOnly="True" SortExpression="PATLIST_ID" UniqueName="PATLIST_ID" Display="false">
         </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" DataField="id">
        <ItemStyle Width="15%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="PAYLIST_DESCRIPTION" HeaderText="ค่าใช้จ่าย" SortExpression="PAYLIST_DESCRIPTION" UniqueName="PAYLIST_DESCRIPTION">
            <ItemStyle Width="55%" />
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn  ButtonType="LinkButton" CommandName="E" Text="แก้ไขข้อมูล" UniqueName="E">
        <ItemStyle Width="15%" />
        </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ConfirmText="คุณต้องการลบข้อมูลหรือไม่" ButtonType="LinkButton"
            CommandName="D" Text="ลบข้อมูล" UniqueName="E">
            <ItemStyle Width="15%" />
        </telerik:GridButtonColumn>
    </Columns>
</MasterTableView>--%>
</telerik:radgrid>
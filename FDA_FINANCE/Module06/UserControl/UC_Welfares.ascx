<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Welfares.ascx.vb" Inherits="FDA_FINANCE.UC_Welfares" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadGrid ID="rgWelfare" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="1024px">
<%--<MasterTableView >
    <Columns>
        <telerik:GridBoundColumn DataField="WELFARE_ID" DataType="System.Int32" HeaderText="WELFARE_ID" 
            ReadOnly="True" SortExpression="WELFARE_ID" UniqueName="WELFARE_ID" Display="false">
         </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" DataField="id">
        <ItemStyle Width="15%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="WELFARE_TYPE_CODE" HeaderText="รหัสสวัสดิการ" SortExpression="WELFARE_TYPE_CODE" UniqueName="WELFARE_TYPE_CODE">
            <ItemStyle Width="25%" />
        </telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="WELFARE_TYPE_DESCRIPTION" HeaderText="ชื่อสวัสดิการ" SortExpression="WELFARE_TYPE_DESCRIPTION" UniqueName="WELFARE_TYPE_DESCRIPTION">
            <ItemStyle Width="25%" />
        </telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="WELFARE_TYPE_SHORT_DESCRIPTION" HeaderText="ชื่อย่อ" SortExpression="WELFARE_TYPE_SHORT_DESCRIPTION" UniqueName="WELFARE_TYPE_SHORT_DESCRIPTION">
            <ItemStyle Width="15%" />
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
</telerik:RadGrid>
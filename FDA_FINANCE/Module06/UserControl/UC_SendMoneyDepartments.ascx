<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_SendMoneyDepartments.ascx.vb" Inherits="FDA_FINANCE.UC_SendMoneyDepartments" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<telerik:RadGrid ID="rgSendMoney" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="700px">
<%--<MasterTableView >
    <Columns>
    
       <telerik:GridBoundColumn DataField="SEND_MONEY_DEPARTMENT_ID" DataType="System.Int32" HeaderText="SEND_MONEY_DEPARTMENT_ID" 
            ReadOnly="True" SortExpression="SEND_MONEY_DEPARTMENT_ID" UniqueName="SEND_MONEY_DEPARTMENT_ID" Display="false">
         </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" DataField="id">
        <ItemStyle Width="15%" />
        </telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="BANK_ACCOUNT" HeaderText="เลขบัญชี" SortExpression="BANK_ACCOUNT" UniqueName="BANK_ACCOUNT">
            <ItemStyle Width="25%" />
        </telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="DEPARTMENT_OR_BANK_NAME" HeaderText="ชื่อธนาคาร/หน่วยงานที่นำส่งเงิน" SortExpression="DEPARTMENT_OR_BANK_NAME" UniqueName="DEPARTMENT_OR_BANK_NAME">
            <ItemStyle Width="25%" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="BRANCH_NAME" HeaderText="สาขา" SortExpression="BRANCH_NAME" UniqueName="BRANCH_NAME">
            <ItemStyle Width="20%" />
        </telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="SHORT_DEPARTMENT_NAME" HeaderText="ชื่อย่อ" SortExpression="SHORT_DEPARTMENT_NAME" UniqueName="SHORT_DEPARTMENT_NAME">
            <ItemStyle Width="10%" />
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

<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor_PayType.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor_PayType" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="800px">
<MasterTableView >
    <Columns>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" >
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ประเภทการจ่าย">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="รายละเอียด">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="เจ้าหนี้">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="เลขที่บัญชี">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="เลขที่เบิก">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="บก. อนุมัติ">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ใบแจ้งหนี้เลขที่">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ใบกำกับภาษีเลขที่">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="เลข บค.บจ.">
        
        </telerik:GridBoundColumn>
    </Columns>
</MasterTableView>
</telerik:RadGrid>
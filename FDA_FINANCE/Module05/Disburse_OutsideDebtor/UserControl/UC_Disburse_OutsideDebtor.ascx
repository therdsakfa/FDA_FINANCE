<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Disburse_OutsideDebtor.ascx.vb" Inherits="FDA_FINANCE.UC_Disburse_OutsideDebtor" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
</telerik:RadScriptManager>
<telerik:RadGrid ID="rgDebtorOutside" runat="server" GridLines="None" 
AutoGenerateColumns="false" Width="800px">
<%--<MasterTableView >
    <Columns>
        <telerik:GridBoundColumn HeaderText="ลำดับที่" >
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="วันที่รับเอกสาร">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="เลขที่เอกสาร">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="วันที่เอกสาร">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="ค่าใช้จ่าย">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="รายการ">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn HeaderText="จำนวนเงิน ง.ป.ม.">
        
        </telerik:GridBoundColumn>
        
    </Columns>
</MasterTableView>--%>
</telerik:RadGrid>
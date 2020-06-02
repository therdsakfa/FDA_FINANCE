<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Department.ascx.vb" Inherits="FDA_FINANCE.UC_Department" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table width="450px">
    
<tr>
    
<td valign="top">
    <telerik:RadTreeView ID="rtDepartment" runat="server" 
                                EnableDragAndDrop="True" EnableDragAndDropBetweenNodes="true" 
                                LoadingStatusPosition="None" 
                                
                                CheckChildNodes="true" AllowNodeEditing="true"
                                >
                            <ContextMenus>
                                <telerik:RadTreeViewContextMenu ID="rtcSubDept" runat="server">
                               
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มหน่วยงานย่อย" Enabled="true" ImageUrl="../images/n2.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        
                                    </Items>
                                 
                                </telerik:RadTreeViewContextMenu>

                                 <telerik:RadTreeViewContextMenu ID="rtcFinished" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                            </ContextMenus>
                            <DataBindings>
                                <telerik:RadTreeNodeBinding Expanded="true" />

                            </DataBindings>
                        </telerik:RadTreeView>
</td>

</table>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BudgetPlan_For_Adjust.ascx.vb" Inherits="FDA_FINANCE.UC_BudgetPlan_For_Adjust" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table width="450px">
    
<tr>
    
<td valign="top">
        

    <telerik:RadTreeView ID="rtBudgetPlan" runat="server" 
                                EnableDragAndDrop="True" EnableDragAndDropBetweenNodes="true" 
                                LoadingStatusPosition="None" 
                                
                                CheckChildNodes="true" AllowNodeEditing="true" Width="450px">
                            <ContextMenus>
                                <telerik:RadTreeViewContextMenu ID="rtcOperation" runat="server">
                               
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มแผนงาน" Enabled="true" ImageUrl="../../images/n2.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                 
                                </telerik:RadTreeViewContextMenu>

                                <telerik:RadTreeViewContextMenu ID="rtcActivity" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มผลผลิต" Enabled="true"  ImageUrl="../../images/n3.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>

                                 <telerik:RadTreeViewContextMenu ID="rtcProject" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มกิจกรรม" Enabled="true"  ImageUrl="../../images/n4.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>

                               <telerik:RadTreeViewContextMenu ID="rtcbudget" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มโครงการ" Enabled="true" ImageUrl="../../images/n5.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                               <telerik:RadTreeViewContextMenu ID="rtcbudget_last" runat="server" >
                                    <Items>
                                         <telerik:RadMenuItem  Value="insert" Text="เพิ่มประเภทงบรายจ่าย" Enabled="true" ImageUrl="../../images/n6.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                                 <telerik:RadTreeViewContextMenu ID="RadTreeViewContextMenu1" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มงบรายจ่าย" Enabled="true" ImageUrl="../../images/n7.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                                 <telerik:RadTreeViewContextMenu ID="RadTreeViewContextMenu2" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มงบรายจ่ายย่อย" Enabled="true" ImageUrl="../../images/n8.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                                 <telerik:RadTreeViewContextMenu ID="RadTreeViewContextMenu3" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="set_sup" Text="ตั้งเป็นงบสนับสนุนกรม" Enabled="true"  />
                                        <telerik:RadMenuItem Value="cancel_sup" Text="ยกเลิกเป็นงบสนับสนุนกรม" Enabled="true"  />
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                            </ContextMenus>
                            <DataBindings>
                                <telerik:RadTreeNodeBinding Expanded="true" />

                            </DataBindings>
                        </telerik:RadTreeView>

    
</td>
    </tr>
</table>
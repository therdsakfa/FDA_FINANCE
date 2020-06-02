<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_MoneyType.ascx.vb" Inherits="FDA_FINANCE.UC_MoneyType" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table width="450px">
<tr>
    
<td>
    <telerik:RadTreeView ID="rtMoneyType" runat="server"  LoadingStatusPosition="None" CheckChildNodes="true" AllowNodeEditing="true">
         <ContextMenus>
                                <telerik:RadTreeViewContextMenu ID="rtcSubList" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มรายการย่อย" Enabled="true"  ImageUrl="../../images/n2.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        
                                    </Items>
                                </telerik:RadTreeViewContextMenu>

                                 <telerik:RadTreeViewContextMenu ID="rtcSub1" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มย่อย1" Enabled="true"  ImageUrl="../../images/n3.png"/>
                                        <telerik:RadMenuItem Value="update" Text="แก้ไขข้อมูล" Enabled="true"  />
                                        <telerik:RadMenuItem Value="delete" Text="ลบข้อมูล" Enabled="true"  />
                                        
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                             <telerik:RadTreeViewContextMenu ID="rtcSub2" runat="server" >
                                    <Items>
                                        <telerik:RadMenuItem  Value="insert" Text="เพิ่มย่อย2" Enabled="true"  ImageUrl="../../images/n4.png"/>
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
</tr>
</table>
Imports Telerik.Web.UI
Public Class UC_Project_List
    Inherits System.Web.UI.UserControl
    Private _bgyear As Integer
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property

    Private _dept As Integer
    Public Property dept() As Integer
        Get
            Return _dept
        End Get
        Set(ByVal value As Integer)
            _dept = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub rg_project_list_Init(sender As Object, e As EventArgs) Handles rg_project_list.Init
        Dim Rad_Utility As New Radgrid_Utility
        Rad_Utility.Rad = rg_project_list
        Rad_Utility.addColumnBound("BUDGET_PLAN_ID", "BUDGET_PLAN_ID", False)
        Rad_Utility.addColumnBound("Project_Name", "ชื่อโครงการ/กิจกรรม", width:=500)
        Rad_Utility.addColumnBound("amount", "งบประมาณ", is_money:=True, footer_txt:="รวม : ")
        'Rad_Utility.addColumnBound("AAA", "ก่อหนี้ผูกพพัน", is_money:=True)
        'Rad_Utility.addColumnBound("BBB", "จำนวนเงินเหลือจ่าย", is_money:=True)
        'Rad_Utility.addColumnBound("amount", "คงเหลือ", is_money:=True)
        ' Rad_Utility.addColumnIMG("sel", "เลือกข้อมูล", "sel", 0, "", img:=True, type_img:="import", width:=100)
        'Rad_Utility.addColumnButton("sel", "เลือกข้อมูล", "sel", 0, "", width:=100)
    End Sub

    Private Sub rg_project_list_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles rg_project_list.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            'Dim id As Integer = 0
            'Try
            '    id = item("BUDGET_PLAN_ID").Text
            'Catch ex As Exception

            'End Try

            'Dim sel As ImageButton = DirectCast(item("sel").Controls(0), ImageButton)

            'Dim sel As LinkButton = DirectCast(item("sel").Controls(0), LinkButton)


            'Dim str_ad As String = NameUserAD()
            'Dim dao As New DAO_USER.TB_tbl_USER
            'dao.Getdata_by_AD_NAME(str_ad)
            'If dao.fields.PERMISSION_ID = 1 Then


            'sel.PostBackUrl = "../../Frm_Main.aspx?bgid=" & id & "&dept=" & dept & "&myear=" & bgyear


            'Else
            '    sel.PostBackUrl = "../../Frm_Main_User.aspx?bgid=" & id & "&dept=" & dept & "&myear=" & bgyear
            'End If

        End If
    End Sub


    Private Sub rg_project_list_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rg_project_list.NeedDataSource
        Dim bao As New BAO_BUDGET.Budget
        Dim dt As New DataTable
        Try
            dt = bao.get_project_list(dept, bgyear)
        Catch ex As Exception

        End Try


        rg_project_list.DataSource = dt
    End Sub
End Class
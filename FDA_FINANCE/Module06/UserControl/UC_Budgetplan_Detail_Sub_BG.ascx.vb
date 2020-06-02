Public Class UC_Budgetplan_Detail_Sub_BG
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
    Private _show As Boolean
    Public Property show() As Boolean
        Get
            Return _show
        End Get
        Set(ByVal value As Boolean)
            _show = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim bao As New BAO_BUDGET.MASS
            Dim dt As DataTable = bao.get_sub_budget(3)
            cb_sub_bg.DataSource = dt
            cb_sub_bg.DataTextField = "SUB_BUDGET_DESCRIPTION"
            cb_sub_bg.DataValueField = "SUB_BUDGET_ID"
            cb_sub_bg.DataBind()

            Dim dao As New DAO_MAS.TB_BUDGET_PLAN
            Dim id As Integer = 0
            If Request.QueryString("id") <> "" Then
                id = Request.QueryString("id")
            End If
            dao.Getdata_by_BUDGET_PLAN_ID(id)
            lb_head_bg.Text = dao.fields.BUDGET_DESCRIPTION
        End If
    End Sub
    Public Sub insert()

        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If

        If cb_sub_bg.Items.Count > 0 Then
            For Each ckbox In cb_sub_bg.Items
                If ckbox.Selected = True Then
                    Dim dao As New DAO_MAS.TB_BUDGET_PLAN()
                    dao.fields.BUDGET_MAIN_TYPE = 0
                    dao.fields.BUDGET_DESCRIPTION = ckbox.Text
                    dao.fields.BUDGET_AMOUNT = 0
                    dao.fields.BUDGET_CHILD_ID = Request.QueryString("id")
                    dao.fields.BUDGET_TYPE_ID = type_id
                    dao.fields.BUDGET_YEAR = bgyear
                    dao.fields.BUDGET_IS_SUPPORT_DEPT = False
                    Dim bao_max As New BAO_BUDGET.MASS
                    Dim id_max As Integer = 0
                    Try
                        id_max = bao_max.get_max_id_budget_plan()
                    Catch ex As Exception

                    End Try
                    dao.fields.BUDGET_PLAN_ID = id_max + 1
                    dao.insert()
                    Dim idinsert As Integer = dao.fields.BUDGET_PLAN_ID

                    Dim dao2 As New DAO_MAS.TB_BUDGET_PLAN_NODE()
                    dao2.fields.HEAD_ID = Request.QueryString("id")
                    dao2.fields.CHILD_ID = idinsert
                    dao2.insert()
                End If
            Next
            
        End If

        'If txt_budget_code.Text <> "" Then
        '    dao.fields.BUDGET_CODE = txt_budget_code.Text
        'Else
        '    dao.fields.BUDGET_CODE = Nothing
        'End If
    End Sub
End Class
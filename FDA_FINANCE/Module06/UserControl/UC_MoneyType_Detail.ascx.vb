Partial Public Class UC_MoneyType_Detail
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub insert_headMoney(ByRef dao As DAO_MAS.TB_MAS_MONEY_TYPE)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If
        dao.fields.MONEY_TYPE_DESCRIPTION = txt_MONEY_TYPE_DESCRIPTION.Text
        dao.fields.MONEY_AMOUNT = 0
        dao.fields.HEAD_MONEY_TYPE_ID = 0
        dao.fields.TYPE_ID = type_id
        dao.fields.BUDGET_YEAR = bgyear
        '      dao.fields.BUDGET_CODE = 
    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_MAS_MONEY_TYPE)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If


        dao.fields.MONEY_TYPE_DESCRIPTION = txt_MONEY_TYPE_DESCRIPTION.Text
        dao.fields.MONEY_AMOUNT = 0
        dao.fields.HEAD_MONEY_TYPE_ID = Request.QueryString("id")
        dao.fields.TYPE_ID = type_id
        dao.fields.BUDGET_YEAR = bgyear

    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_MAS_MONEY_TYPE)
        txt_MONEY_TYPE_DESCRIPTION.Text = dao.fields.MONEY_TYPE_DESCRIPTION
        'rnt_MONEY_AMOUNT.Value = dao.fields.MONEY_AMOUNT

    End Sub
    Public Sub update(ByRef dao As DAO_MAS.TB_MAS_MONEY_TYPE)
        Dim type_id As Integer
        If Request.QueryString("typeid") IsNot Nothing Then
            type_id = Request.QueryString("typeid")
        End If
        dao.fields.MONEY_TYPE_DESCRIPTION = txt_MONEY_TYPE_DESCRIPTION.Text
        'dao.fields.MONEY_AMOUNT = rnt_MONEY_AMOUNT.Value

    End Sub
End Class
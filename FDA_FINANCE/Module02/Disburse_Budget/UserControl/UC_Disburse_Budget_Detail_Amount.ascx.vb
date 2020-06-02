Public Partial Class UC_Disburse_Budget_Detail_Amount
    Inherits System.Web.UI.UserControl
    Dim maxid As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' เพิ่ม/ข้อมุลจำนวนเงินใส่ตาราง bill detail
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL, ByVal maxid As Integer)

        dao.fields.AMOUNT = txt_AMOUNT.Text
        dao.fields.TAX_AMOUNT = txt_TAX_AMOUNT.Text
        dao.fields.IS_ENABLE = True
        dao.fields.BUDGET_DISBURSE_BILL_ID = maxid
    End Sub
    Public Sub update(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        dao.fields.AMOUNT = txt_AMOUNT.Text
        dao.fields.TAX_AMOUNT = txt_TAX_AMOUNT.Text

    End Sub
    ''' <summary>
    ''' ดึงข้อมูลจำนวนเงินใส่ตาราง bill detail 
    ''' </summary>
    ''' <param name="dao"></param>
    ''' <remarks></remarks>
    Public Sub getdata_detail(ByRef dao As DAO_DISBURSE.TB_BUDGET_BILL_DETAIL)
        txt_AMOUNT.Text = dao.fields.AMOUNT
        txt_TAX_AMOUNT.Text = dao.fields.TAX_AMOUNT
    End Sub
End Class
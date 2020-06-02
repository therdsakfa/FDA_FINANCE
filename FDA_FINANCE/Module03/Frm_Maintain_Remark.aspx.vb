Public Class Frm_Maintain_Remark
    Inherits System.Web.UI.Page
    Private _TR_ID As Integer
    Private _IDA As Integer
    Private _CLS As New CLS_SESSION
    ' Private _type As String

    Private Sub runQuery()
        'If Session("CLS") Is Nothing Then
        '    Response.Redirect("http://privus.fda.moph.go.th/")
        'Else
        '    _TR_ID = Request.QueryString("TR_ID")
        '    _IDA = Request.QueryString("IDA")
        '    _CLS = Session("CLS")
        '    ' _type = "1"
        'End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub


    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.refresh();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dao_return_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        dao_return_money.Getdata_by_RECEIVE_MONEY_ID(Request.QueryString("IDA"))
        dao_return_money.fields.IS_CANCEL = True
        dao_return_money.fields.CANCEL_DATE = Date.Now
        dao_return_money.fields.REMARK = TextBox1.Text
        dao_return_money.fields.REMARK_RECEIVER = Request.QueryString("receive")
        Try
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.GetDataby_ref1_ref2(dao_return_money.fields.REF01, dao_fee.fields.ref02)
            dao_fee.fields.rcptst = 0
            dao_fee.update()
        Catch ex As Exception

        End Try
        dao_return_money.update()
        'System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ยกเลิกเรียบร้อยแล้ว');", True)
        alert("ยกเลิกเรียบร้อยแล้ว")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("FRM_TABEAN_CONFIRM_STAFF.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID)
    End Sub
End Class
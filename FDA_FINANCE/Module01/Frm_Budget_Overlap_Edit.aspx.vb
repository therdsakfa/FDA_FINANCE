Public Class Frm_Budget_Overlap_Edit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("dept") = 1
        Dim dept As Integer = Session("dept")
        UC_Overlap_Detail1.dept_id = dept
        If Not IsPostBack Then
            If Request.QueryString("oid") <> "" Then
                Dim dao As New DAO_MAS.TB_OVERLAP_HEAD
                dao.Getdata_by_OVERLAP_HEAD_ID(Request.QueryString("oid"))
                ' UC_Overlap_Detail1.dept_id = dao.fields.DEPARTMENT_ID
                UC_Overlap_Detail1.getdata(dao)
            End If
        End If
    End Sub

    Protected Sub btn_bill_save_Click(sender As Object, e As EventArgs) Handles btn_bill_save.Click
        If Request.QueryString("oid") <> "" Then
            Dim dao As New DAO_MAS.TB_OVERLAP_HEAD
            dao.Getdata_by_OVERLAP_HEAD_ID(Request.QueryString("oid"))
            UC_Overlap_Detail1.insert(dao)
            dao.update()
        End If
    End Sub
End Class
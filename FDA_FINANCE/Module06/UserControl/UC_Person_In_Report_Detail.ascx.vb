Public Class UC_Person_In_Report_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub bind_ddl()
        Dim bao As New BAO_BUDGET.MASS
        Dim dt As DataTable = bao.get_type_person_in_report()

        ddl_R_TYPE.DataSource = dt
        ddl_R_TYPE.DataBind()
    End Sub
    Public Sub getdata(ByRef dao As DAO_MAS.TB_TBL_PERSON_IN_REPORT)
        If dao.fields.IS_FOUNDATION IsNot Nothing Then
            If dao.fields.IS_FOUNDATION = True Then
                cb_IS_FOUNDATION.Checked = True
            Else
                cb_IS_FOUNDATION.Checked = False
            End If
        Else
            cb_IS_FOUNDATION.Checked = False
        End If
        If dao.fields.IS_NORMAL IsNot Nothing Then
            If dao.fields.IS_NORMAL = True Then
                cb_IS_NORMAL.Checked = True
            Else
                cb_IS_NORMAL.Checked = False
            End If
        Else
            cb_IS_NORMAL.Checked = False
        End If
        txt_R_NAME.Text = dao.fields.R_NAME
        ddl_R_TYPE.DropDownSelectData(dao.fields.R_TYPE)
        If dao.fields.IS_USE IsNot Nothing Then
            If dao.fields.IS_USE = True Then
                cb_IS_USE.Checked = True
            Else
                cb_IS_USE.Checked = False
            End If
        Else
            cb_IS_USE.Checked = False
        End If
        If dao.fields.IS_SPSC IsNot Nothing Then
            If dao.fields.IS_SPSC = True Then
                cb_IS_SPSC.Checked = True
            Else
                cb_IS_SPSC.Checked = False
            End If
        Else
            cb_IS_SPSC.Checked = False
        End If

        If dao.fields.IS_SSS IsNot Nothing Then
            If dao.fields.IS_SSS = True Then
                cb_IS_SSS.Checked = True
            Else
                cb_IS_SSS.Checked = False
            End If
        Else
            cb_IS_SSS.Checked = False
        End If
        If dao.fields.IS_BENEFITS IsNot Nothing Then
            If dao.fields.IS_BENEFITS = True Then
                cb_is_benefit.Checked = True
            Else
                cb_is_benefit.Checked = False
            End If
        Else
            cb_is_benefit.Checked = False
        End If
    End Sub
    Public Sub insert(ByRef dao As DAO_MAS.TB_TBL_PERSON_IN_REPORT)
        dao.fields.IS_FOUNDATION = cb_IS_FOUNDATION.Checked
        dao.fields.R_NAME = txt_R_NAME.Text
        dao.fields.R_TYPE = ddl_R_TYPE.SelectedValue
        dao.fields.IS_USE = cb_IS_USE.Checked
        dao.fields.IS_NORMAL = cb_IS_NORMAL.Checked
        dao.fields.IS_SPSC = cb_IS_SPSC.Checked
        dao.fields.IS_SSS = cb_IS_SSS.Checked
        dao.fields.IS_BENEFITS = cb_is_benefit.Checked
    End Sub
End Class
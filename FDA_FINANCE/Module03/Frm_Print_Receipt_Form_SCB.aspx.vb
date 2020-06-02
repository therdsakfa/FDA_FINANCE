Imports Telerik.Web.UI

Public Class Frm_Print_Receipt_Form_SCB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_date.Text = Date.Now.ToShortDateString()
        End If
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.Maintain
        Try
            dt = bao.Get_Report_Receipt_Scb_By_Date(CDate(txt_date.Text))
        Catch ex As Exception

        End Try
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        Dim str_ida As String = ""
        Dim int_count As Integer = 0
        For Each item As GridDataItem In RadGrid1.SelectedItems
            Dim ref01 As String = ""
            Dim ref02 As String = ""
            ref01 = item("ref01").Text
            ref02 = item("ref02").Text
            Dim dao_re As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            dao_re.Getdata_by_ref01_ref02(ref01, ref02)
            If dao_re.fields.RECEIVE_MONEY_ID <> 0 Then
                If str_ida = "" Then
                    str_ida = dao_re.fields.RECEIVE_MONEY_ID
                Else
                    str_ida &= "," & dao_re.fields.RECEIVE_MONEY_ID
                End If
            End If
            int_count += 1
        Next
        If int_count = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกอย่างน้อย 1 รายการ');", True)
        Else
            If str_ida <> "" Then
                Dim url_p As String = ""
                url_p = "../Module09/Report/Frm_Report_R9_003.aspx?rn=" & str_ida.EncodeBase64()

                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "window.open('" & url_p & "', '_blank');", True)
            Else
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ไม่พบข้อมูล');", True)
            End If
        End If
    End Sub
End Class
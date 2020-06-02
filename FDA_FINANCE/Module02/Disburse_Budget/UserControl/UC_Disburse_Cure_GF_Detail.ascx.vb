Public Class UC_Disburse_Cure_GF_Detail
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            rdp_GFMIS_DATE.Text = System.DateTime.Now.ToShortDateString()
            Dim bao As New BAO_BUDGET.Budget
            Dim dt As DataTable = bao.get_k_type_all_with_pay()

            dd_KType.DataSource = dt
            dd_KType.DataBind()

            ddl_split()

        End If
    End Sub
    Public Sub ddl_split()
        Dim strK As String = dd_KType.SelectedItem.Text
        Dim spText As String() = strK.Split(" ")
        If spText(0) <> "" Then
            lb_K.Text = spText(0)
        End If
    End Sub

    Public Sub insert(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)
        Dim pay_type As Integer
        Dim dao_type As New DAO_MAS.TB_MAS_K_TYPE
        dao_type.Getdata_by_ID(dd_KType.SelectedValue)
        pay_type = dao_type.fields.K_TYPE_CODE

        If rd_pay_type.SelectedValue <> "" Then
            If rd_pay_type.SelectedValue = "2" Then
                dao.fields.PAY_TYPE_ID = pay_type
                dao.fields.GFMIS_NUMBER = lb_K.Text & txt_GFMIS.Text
                dao.fields.GFMIS_DATE = rdp_GFMIS_DATE.Text
                dao.fields.INCLUDE_SALARY_DIGIT = rd_pay_type.SelectedValue
            ElseIf rd_pay_type.SelectedValue = "1" Then
                dao.fields.PAY_TYPE_ID = pay_type
                dao.fields.GFMIS_NUMBER = Nothing
                dao.fields.GFMIS_DATE = Nothing
                dao.fields.INCLUDE_SALARY_DIGIT = rd_pay_type.SelectedValue
            End If
        End If

    End Sub
    Public Sub insert_welfare(ByVal id As Integer)
        Dim dao As New DAO_DISBURSE.TB_CURE_STUDY
        dao.Getdata_by_CURE_STUDY_ID(id)
        If dao.fields.CURE_STUDY_ID <> 0 Then
            If dao.fields.BILL_TYPE_ID = 1 Then
                If dao.fields.INCLUDE_SALARY_DIGIT = 1 Then
                    Dim dao_welfare As New DAO_WELFARE.TB_ALL_WELFARE_BILL
                    dao_welfare.fields.AMOUNT = dao.fields.AMOUNT
                    dao_welfare.fields.BUDGET_YEAR = dao.fields.BUDGET_YEAR
                    dao_welfare.fields.DEPARTMENT_ID = dao.fields.DEPARTMENT_ID
                    dao_welfare.fields.DESCRIPTION = dao.fields.DESCRIPTION
                    dao_welfare.fields.MONTH_LIVE = getmonth_name(dao.fields.MONTH_DIGIT)

                    If dao.fields.USER_ID IsNot Nothing Then
                        Dim dao_cus As New DAO_MAS.TB_MAS_CUSTOMER
                        dao_cus.Getdata_by_CUSTOMER_ID(dao.fields.USER_ID)
                        dao_welfare.fields.NAME = dao_cus.fields.CUSTOMER_NAME
                        dao_welfare.fields.PERSONAL_ID = dao_cus.fields.PERSONAL_ID
                    End If

                    dao_welfare.fields.USER_ID = dao.fields.USER_ID
                    dao_welfare.fields.WELFARE_CODE = "30001"
                    dao_welfare.fields.WELFARE_DATE = dao.fields.DOC_DATE
                    dao_welfare.fields.WELFARE_ID = 1
                    dao_welfare.fields.CURE_STUDY_ID = id
                    dao_welfare.insert()
                End If

            End If
        End If

    End Sub
    Public Function getname() As String

    End Function


    Public Function getmonth_name(ByVal month_num As Integer) As String
        Dim str As String = ""
        Select Case month_num
            Case 1
                str = "มกราคม"
            Case 2
                str = "กุมภาพันธ์"
            Case 3
                str = "มีนาคม"
            Case 4
                str = "เมษายน"
            Case 5
                str = "พฤษภาคม"
            Case 6
                str = "มิถุนายน"
            Case 7
                str = "กรกฎาคม"
            Case 8
                str = "สิงหาคม"
            Case 9
                str = "กันยายน"
            Case 10
                str = "ตุลาคม"
            Case 11
                str = "พฤศจิกายน"
            Case 12
                str = "ธันวาคม"
        End Select

        Return str
    End Function

    Public Sub getdata(ByRef dao As DAO_DISBURSE.TB_CURE_STUDY)
        ' txt_GFMIS.Text = dao.fields.GFMIS_NUMBER
        rdp_GFMIS_DATE.Text = dao.fields.GFMIS_DATE
    End Sub
    Protected Sub dd_KType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dd_KType.SelectedIndexChanged
        ddl_split()
    End Sub

    Private Sub rd_pay_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rd_pay_type.SelectedIndexChanged
        If rd_pay_type.SelectedValue = "1" Then
            dd_KType.Enabled = False
            txt_GFMIS.Enabled = False
            rdp_GFMIS_DATE.Enabled = False
        ElseIf rd_pay_type.SelectedValue = "2" Then
            dd_KType.Enabled = True
            txt_GFMIS.Enabled = True
            rdp_GFMIS_DATE.Enabled = True
        End If
    End Sub
End Class
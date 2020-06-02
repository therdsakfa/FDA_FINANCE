Public Class Frm_Report_R3_015_3
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    ''' <summary>
    ''' Function สร้างตารางข้อมูลรายงาน แยกตามรายงาน
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getReportData()
        Dim bao As New BAO_BUDGET.Report
        UC_Report_SelectDate_Single.getDateSelect()
        Dim dvcd As Integer = 0
        Try
            dvcd = Request.QueryString("dvcd")
        Catch ex As Exception

        End Try
        Dim dt As DataTable = bao.get_Report_R3_015_3(UC_Report_SelectDate_Single.dateSelect, dvcd)
        dt.Columns.Add("stat")
        For Each dr As DataRow In dt.Rows
            Try
                Dim str As String = ""
                str = Get_Status(dr("feeno"), dr("dvcd"))
                dr("stat") = str
            Catch ex As Exception

            End Try

        Next

        Return dt
    End Function

    Private Sub btn_ShowReport_Click(sender As Object, e As EventArgs) Handles btn_ShowReport.Click
        Dim util As New Report_Utility
        util.report = ReportViewer1
        util.configWidthHeight()
        util.ShowReport(ReportViewer1, util.root & "Module03\Report_R3_015_3.rdlc", "Fields_Report_R3_015", getReportData())
    End Sub
    Public Function Get_Status(ByVal feeno As String, ByVal dvcd As Integer) As String
        Dim status_text As String = ""
        Try
            Dim dao_fee As New DAO_FEE.TB_fee
            dao_fee.Getdata_by_feeno_and_dvcd(feeno, dvcd)
            If dao_fee.fields.rcptst = 0 Then
                status_text = "ยังไม่ได้ชำระค่าธรรมเนียม"
            ElseIf dao_fee.fields.rcptst = 1 Then
                Dim dao_log As New DAO_FEE.TB_fee_log
                Dim bool As Boolean
                bool = dao_log.CountPay_by_ref1_and_ref2(dao_fee.fields.ref01, dao_fee.fields.ref02)


                If bool = True Then
                    'กรณีจ่ายผ่านธนาคาร
                    Dim dao_bg As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    Dim bool_rec As Boolean = False
                    bool_rec = dao_bg.Getdata_by_feeno(feeno)
                    If bool_rec = True Then
                        status_text = "ชำระเงินผ่านธนาคารและออกใบเสร็จแล้ว"
                    Else
                        status_text = "ชำระเงินผ่านธนาคารและรอออกใบเสร็จ"
                    End If

                Else
                    'กรณีจ่ายผ่าน ossc
                    Dim dao_bg As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    Dim bool_rec As Boolean = False
                    bool_rec = dao_bg.Getdata_by_feeno(feeno)
                    If bool_rec = True Then
                        status_text = "ชำระที่ฝ่ายคลังฯ และออกใบเสร็จแล้ว"
                    Else
                        status_text = "ชำระที่ฝ่ายคลังฯ และรอออกใบเสร็จ"
                    End If
                End If

            Else
                Dim bao As New BAO_INFORMIX.INFORMIX
                Dim bool As Boolean
                bool = bao.Count_fee(feeno, dvcd)
                If bool = True Then
                    Dim dao_bg As New DAO_MAINTAIN.TB_RECEIVE_MONEY
                    Dim bool_rec As Boolean = False
                    bool_rec = dao_bg.Getdata_by_feeno(feeno)
                    If bool_rec = True Then
                        status_text = "ชำระที่ฝ่ายคลังฯ และออกใบเสร็จแล้ว"
                    Else
                        status_text = "ชำระที่ฝ่ายคลังฯ และรอออกใบเสร็จ"
                    End If
                Else
                    status_text = "-"
                End If

            End If
        Catch ex As Exception

        End Try

        Return status_text
    End Function
End Class
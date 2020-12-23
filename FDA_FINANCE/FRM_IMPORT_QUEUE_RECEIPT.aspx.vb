Imports ClosedXML.Excel
Imports Telerik.Web.UI

Public Class FRM_IMPORT_QUEUE_RECEIPT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt As New DataTable
        Dim bao As New BAO_BUDGET.MASS
        dt = bao.Get_LOG_WAIT_RECEIPT()
        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If FileUpload1.HasFile Then
            ImportExcel()
            RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub ImportExcel()
        Dim dt As New DataTable()
        'Open the Excel file using ClosedXML.
        Using workBook As New XLWorkbook(FileUpload1.PostedFile.InputStream)
            'Read the first Sheet from Excel file.
            Dim workSheet As IXLWorksheet = workBook.Worksheet(1)

            'Create a new DataTable.


            'Loop through the Worksheet rows.
            Dim firstRow As Boolean = True
            For Each row As IXLRow In workSheet.Rows()
                'Use the first row to add columns to DataTable.
                If row.Cell(1).Value.ToString <> "" And row.Cell(2).Value.ToString <> "" Then
                    If firstRow Then
                        For Each cell As IXLCell In row.Cells()
                            If Len(cell.Value.ToString()) > 0 Then
                                dt.Columns.Add(cell.Value.ToString())
                            End If

                        Next
                        firstRow = False
                    Else
                        'Add rows to DataTable.
                        dt.Rows.Add()
                        Dim i As Integer = 0
                        For Each cell As IXLCell In row.Cells()
                            If Len(cell.Value.ToString()) > 0 Then
                                dt.Rows(dt.Rows.Count - 1)(i) = cell.Value.ToString()
                                i += 1
                            End If

                        Next
                    End If
                End If


            Next

        End Using

        For Each dr As DataRow In dt.Rows
            Dim i As Integer = 0
            Dim dao As New DAO_MAS.TB_LOG_WAIT_RECEIPT
            i = dao.CountData_by_ref01_ref02(dr("REF01"), dr("REF02"))
            If i = 0 Then
                Dim dao_wait As New DAO_MAS.TB_LOG_WAIT_RECEIPT
                dao_wait.fields.REF01 = dr("REF01")
                dao_wait.fields.REF02 = dr("REF02")
                dao_wait.fields.CREATE_DATE = Date.Now
                dao_wait.insert()
            End If
        Next
    End Sub
End Class
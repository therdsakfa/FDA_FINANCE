Public Class UC_Receive_List_Filter
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bind_dl_User()
            dl_User.Items.Insert(0, New ListItem("--ชื่อ-นามสกุล--", ""))
        End If
       
    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = " "
        Dim dl_value As String
        If dl_User.SelectedValue = "" Then
            ' dl_value = ""
            strMsg = "([status] LIKE '%" & rd_receive_type.SelectedValue & "%') and ([DOC_NUMBER] like '%" & txt_DOC_NUMBER.Text & "%') and ([BILL_NUMBER] like '%" & txt_BILL_NUMBER.Text & "%') "

            If txt_amount.Text <> "" Then
                strMsg &= " and ([AMOUNT] " & dd_equal.SelectedItem.Text & " '" & txt_amount.Text & "')"
            End If
        Else
            dl_value = dl_User.SelectedValue
            strMsg = "([status] LIKE '%" & rd_receive_type.SelectedValue & "%') and ([USER_ID] = '" & dl_value & "') and ([DOC_NUMBER] like '%" & txt_DOC_NUMBER.Text & "%') and ([BILL_NUMBER] like '%" & txt_BILL_NUMBER.Text & "%') "

            If txt_amount.Text <> "" Then
                strMsg &= " and ([AMOUNT] " & dd_equal.SelectedItem.Text & " '" & txt_amount.Text & "')"
            End If
        End If


        Return strMsg
    End Function

    Public Sub bind_dl_User()
        If Not IsPostBack Then
            'Dim bao As New BAO_BUDGET.USER
            'Dim dt As DataTable = bao.get_NAME_AD_NAME()
            ''Dim dr As DataRow = dt.NewRow
            ''dr("ID") = 0
            ''dr("NAME") = "--ชื่อ-นามสกุล--"
            ''dt.Rows.Add(dr)
            'Dim dv As DataView = dt.DefaultView
            'dv.Sort = " NAME ASC,ID ASC"
            'dt = dv.ToTable

            Dim bao As New BAO_BUDGET.MASS
            Dim dt As New DataTable
            dt = bao.get_customer_gov()
            dl_User.DataSource = dt
            dl_User.DataTextField = "CUSTOMER_NAME"
            dl_User.DataValueField = "CUSTOMER_ID"

            dl_User.DataBind()


        End If
    End Sub
End Class
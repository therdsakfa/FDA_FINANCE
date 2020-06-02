Imports Telerik.Web.UI
Public Class Frm_Maintain_ReceiveMoney_Insert
    Inherits System.Web.UI.Page
    Private _bgyear As Integer
    Private _CLS As New CLS_SESSION
    Private _process As String

    Sub RunSession()
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Public Property bgyear() As Integer
        Get
            Return _bgyear
        End Get
        Set(ByVal value As Integer)
            _bgyear = value
        End Set
    End Property

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RunSession()
        If Request.QueryString("bgYear") IsNot Nothing Then
            bgyear = Request.QueryString("bgYear")
        End If
        If Not IsPostBack Then
            UC_Maintain_ReceiveMoney_Detail_Receipt.set_date()
            UC_Maintain_ReceiveMoney_Detail_Money.bind_dl_department()
            Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
            Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
            'dao_node.Getdata_Head(0, bgyear)
            dao_node.Getdata_Head_no_Year(0)
            Dim rtv_money_type As New RadTreeView
            rtv_money_type = DirectCast(rcb_Moneytype.Items(0).FindControl("rtv_money_type"), RadTreeView)
            For Each dao_node.fields In dao_node.datas
                Dim node As New RadTreeNode
                dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
                node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
                node.Value = dao_node.fields.MONEY_TYPE_ID
                rtv_money_type.Nodes.Add(node)
                bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
            Next
        End If

    End Sub
    Public Sub bindnode(ByVal rt As RadTreeNodeCollection, Optional ByVal ParentID As Integer = 0)
        Dim dao_node As New DAO_MAS.TB_MAS_MONEY_TYPE
        Dim dao_node_name As New DAO_MAS.TB_MAS_MONEY_TYPE
        'dao_node.Getdata_Head(ParentID, bgyear)
        dao_node.Getdata_Head_no_Year(ParentID)
        For Each dao_node.fields In dao_node.datas
            dao_node_name.Getdata_by_MONEY_TYPE_ID(dao_node.fields.MONEY_TYPE_ID)
            Dim node As New RadTreeNode
            node.Text = dao_node_name.fields.MONEY_TYPE_DESCRIPTION
            node.Value = dao_node.fields.MONEY_TYPE_ID
            rt.Add(node)
            bindnode(node.Nodes, dao_node.fields.MONEY_TYPE_ID)
        Next
    End Sub

    Protected Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If rcb_Moneytype.SelectedValue <> "" Then
            Dim dao_maintain_receive_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
            'UC_Maintain_ReceiveMoney_Detail_MoneyType.insert(dao_maintain_receive_money)
            UC_Maintain_ReceiveMoney_Detail_Money.insert(dao_maintain_receive_money)
            UC_Maintain_ReceiveMoney_Detail_Receipt.insert(dao_maintain_receive_money)
            UC_Maintain_ReceiveMoney_Detail_Bank.insert(dao_maintain_receive_money)
            dao_maintain_receive_money.fields.BUDGET_YEAR = bgyear
            dao_maintain_receive_money.fields.MONEY_TYPE_ID = rcb_Moneytype.SelectedValue

            dao_maintain_receive_money.insert()
            Dim log As New log_event.log
            log.insert_log(NameUserAD(), System.IO.Path.GetFileName(Request.Path), _
                           Request.Url.AbsoluteUri.ToString(), "บันทึกรายการบันทึกการรับเงิน", _
                           "RECEIVE_MONEY", dao_maintain_receive_money.fields.RECEIVE_MONEY_ID)
            ' System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", " alert('บันทึกเรียบร้อย'); parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)

        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกประเภทเงิน');", True)
        End If
        
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "parent.$('#ctl00_ContentPlaceHolder1_btnRedirect').click();", True)
    End Sub

    Protected Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        Dim dao_maintain_receive_money As New DAO_MAINTAIN.TB_RECEIVE_MONEY
        'UC_Maintain_ReceiveMoney_Detail_MoneyType.insert(dao_maintain_receive_money)
        UC_Maintain_ReceiveMoney_Detail_Money.insert(dao_maintain_receive_money)
        UC_Maintain_ReceiveMoney_Detail_Receipt.insert(dao_maintain_receive_money)
        UC_Maintain_ReceiveMoney_Detail_Bank.insert(dao_maintain_receive_money)
        dao_maintain_receive_money.fields.BUDGET_YEAR = bgyear
        dao_maintain_receive_money.fields.MONEY_TYPE_ID = rcb_Moneytype.SelectedValue
        dao_maintain_receive_money.insert()
        Response.Redirect("../Module09/Report/Frm_Report_R9_003.aspx?ID=" & dao_maintain_receive_money.fields.RECEIVE_MONEY_ID)
    End Sub

    Private Sub rcb_Moneytype_TextChanged(sender As Object, e As EventArgs) Handles rcb_Moneytype.TextChanged
        Dim value As Integer
        If rcb_Moneytype.SelectedValue = "" Then
            value = 0
        Else
            value = rcb_Moneytype.SelectedValue
        End If
        UC_Maintain_ReceiveMoney_Detail_MoneyType.nodeID = value
        UC_Maintain_ReceiveMoney_Detail_MoneyType.bindTxtbox()
    End Sub
End Class

Public Class CLASS_CURE_STUDY
    Public CURE_STUDIEs As New CURE_STUDY
#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

#Region "DataBase"
    Private _STUDY_CHILD_DETAILs As New List(Of STUDY_CHILD_DETAIL)
    Public Property STUDY_CHILD_DETAILs() As List(Of STUDY_CHILD_DETAIL)
        Get
            Return _STUDY_CHILD_DETAILs
        End Get
        Set(ByVal value As List(Of STUDY_CHILD_DETAIL))
            _STUDY_CHILD_DETAILs = value
        End Set
    End Property

    Private _CURE_BERG_DETAIL As New List(Of CURE_BERG_DETAIL)
    Public Property CURE_BERG_DETAIL() As List(Of CURE_BERG_DETAIL)
        Get
            Return _CURE_BERG_DETAIL
        End Get
        Set(ByVal value As List(Of CURE_BERG_DETAIL))
            _CURE_BERG_DETAIL = value
        End Set
    End Property

    Private _CURE_CONDITION As New List(Of CURE_CONDITION)
    Public Property CURE_CONDITION() As List(Of CURE_CONDITION)
        Get
            Return _CURE_CONDITION
        End Get
        Set(ByVal value As List(Of CURE_CONDITION))
            _CURE_CONDITION = value
        End Set
    End Property
#End Region
End Class

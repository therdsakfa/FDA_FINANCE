﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_FDA_BG_DOC
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_FDA_BGSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_FDA_BG
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAROperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_FDA_BG_DOC_WS_FDA_BG
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompleted As WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAR", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAR(ByVal Budget_Year As Integer, ByVal Budget_Month As Integer) As System.Data.DataTable
            Dim results() As Object = Me.Invoke("WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAR", New Object() {Budget_Year, Budget_Month})
            Return CType(results(0),System.Data.DataTable)
        End Function
        
        '''<remarks/>
        Public Overloads Sub WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARAsync(ByVal Budget_Year As Integer, ByVal Budget_Month As Integer)
            Me.WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARAsync(Budget_Year, Budget_Month, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARAsync(ByVal Budget_Year As Integer, ByVal Budget_Month As Integer, ByVal userState As Object)
            If (Me.WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAROperationCompleted Is Nothing) Then
                Me.WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAROperationCompleted = AddressOf Me.OnWS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAROperationCompleted
            End If
            Me.InvokeAsync("WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAR", New Object() {Budget_Year, Budget_Month}, Me.WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAROperationCompleted, userState)
        End Sub
        
        Private Sub OnWS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEAROperationCompleted(ByVal arg As Object)
            If (Not (Me.WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompleted(Me, New WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompletedEventHandler(ByVal sender As Object, ByVal e As WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class WS_GET_DISBURSE_BY_MONTH_AND_BUDGET_YEARCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Data.DataTable
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Data.DataTable)
            End Get
        End Property
    End Class
End Namespace
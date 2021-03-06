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
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_UPDATE_DATE_MDC
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="SV_UPDATE_DATESoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class SV_UPDATE_DATE
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private SERVICE_CAL_DATEOperationCompleted As System.Threading.SendOrPostCallback
        
        Private WS_UPDATE_STATUSOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_FINANCE.My.MySettings.Default.FDA_FINANCE_WS_UPDATE_DATE_MDC_SV_UPDATE_DATE
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
        Public Event SERVICE_CAL_DATECompleted As SERVICE_CAL_DATECompletedEventHandler
        
        '''<remarks/>
        Public Event WS_UPDATE_STATUSCompleted As WS_UPDATE_STATUSCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SERVICE_CAL_DATE", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub SERVICE_CAL_DATE(ByVal IDA As Integer, ByVal payment As Integer, ByVal type As Integer)
            Me.Invoke("SERVICE_CAL_DATE", New Object() {IDA, payment, type})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SERVICE_CAL_DATEAsync(ByVal IDA As Integer, ByVal payment As Integer, ByVal type As Integer)
            Me.SERVICE_CAL_DATEAsync(IDA, payment, type, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub SERVICE_CAL_DATEAsync(ByVal IDA As Integer, ByVal payment As Integer, ByVal type As Integer, ByVal userState As Object)
            If (Me.SERVICE_CAL_DATEOperationCompleted Is Nothing) Then
                Me.SERVICE_CAL_DATEOperationCompleted = AddressOf Me.OnSERVICE_CAL_DATEOperationCompleted
            End If
            Me.InvokeAsync("SERVICE_CAL_DATE", New Object() {IDA, payment, type}, Me.SERVICE_CAL_DATEOperationCompleted, userState)
        End Sub
        
        Private Sub OnSERVICE_CAL_DATEOperationCompleted(ByVal arg As Object)
            If (Not (Me.SERVICE_CAL_DATECompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent SERVICE_CAL_DATECompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WS_UPDATE_STATUS", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub WS_UPDATE_STATUS(ByVal ida As Integer, ByVal status_id As Integer, ByVal process As String)
            Me.Invoke("WS_UPDATE_STATUS", New Object() {ida, status_id, process})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub WS_UPDATE_STATUSAsync(ByVal ida As Integer, ByVal status_id As Integer, ByVal process As String)
            Me.WS_UPDATE_STATUSAsync(ida, status_id, process, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub WS_UPDATE_STATUSAsync(ByVal ida As Integer, ByVal status_id As Integer, ByVal process As String, ByVal userState As Object)
            If (Me.WS_UPDATE_STATUSOperationCompleted Is Nothing) Then
                Me.WS_UPDATE_STATUSOperationCompleted = AddressOf Me.OnWS_UPDATE_STATUSOperationCompleted
            End If
            Me.InvokeAsync("WS_UPDATE_STATUS", New Object() {ida, status_id, process}, Me.WS_UPDATE_STATUSOperationCompleted, userState)
        End Sub
        
        Private Sub OnWS_UPDATE_STATUSOperationCompleted(ByVal arg As Object)
            If (Not (Me.WS_UPDATE_STATUSCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent WS_UPDATE_STATUSCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    Public Delegate Sub SERVICE_CAL_DATECompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub WS_UPDATE_STATUSCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
End Namespace

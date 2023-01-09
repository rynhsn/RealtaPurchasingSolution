Imports VBPurchasingDbLib.Base
Imports VBPurchasingDbLib.Context

Public Class PurchasingDbLib
    Implements IPurchasingDbLib

    Private Property _repoManager As IRepositoryManager
    Private ReadOnly _repositoryContext As IRepositoryContext

    Public Sub New(ByVal connString As String)
        'Console.WriteLine($"Connection : {connString}")
        If _repositoryContext Is Nothing Then
            _repositoryContext = New RepositoryContext(connString)
        End If
    End Sub

    Public ReadOnly Property RepositoryManager As IRepositoryManager Implements IPurchasingDbLib.RepositoryManager
        Get
            If _repoManager Is Nothing Then
                _repoManager = New RepositoryManager(_repositoryContext)
            End If
            Return _repoManager
        End Get
    End Property

    Public Sub SayHello() Implements IPurchasingDbLib.SayHello
        Console.WriteLine("Hello VB")
    End Sub
End Class

Imports NorthwindVbNetApi.Base
Imports NorthwindVbNetApi.Context

Public Class NorthwindVbApi
    Implements INorthwindVbApi

    Private _repoManager As IRepositoryManager
    Private ReadOnly _repositoryContext As IRepositoryContext

    Public Sub New(ByVal connString As String)
        'Console.WriteLine($"cs : {connString}")
        If _repositoryContext Is Nothing Then
            _repositoryContext = New RepositoryContext(connString)
        End If
    End Sub

    Public ReadOnly Property RepositoryManager As IRepositoryManager Implements INorthwindVbApi.RepositoryManager
        Get
            If _repoManager Is Nothing Then
                _repoManager = New RepositoryManager(_repositoryContext)
            End If
            Return _repoManager
        End Get
    End Property

    Public Sub SayHello() Implements INorthwindVbApi.SayHello
        Console.WriteLine("Hello VB.Net")
    End Sub
End Class
Imports VBPurchasingDbLib.Context
Imports VBPurchasingDbLib.Repository

Namespace Base

    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _vendorRepository As IVendorRepository
        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        ReadOnly Property Vendor As IVendorRepository Implements IRepositoryManager.Vendor
            Get
                If _vendorRepository Is Nothing Then
                    _vendorRepository = New VendorRepository(_repositoryContext)
                End If
                Return _vendorRepository
            End Get
        End Property
    End Class

End Namespace
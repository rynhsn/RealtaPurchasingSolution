Imports VBPurchasingDbLib.Repository

Namespace Base

    Public Interface IRepositoryManager
        ReadOnly Property Vendor As IVendorRepository
        ReadOnly Property Stocks As IStocksRepository
    End Interface

End Namespace
Imports VBPurchasingDbLib.Repository

Namespace Base

    Public Interface IRepositoryManager
        ReadOnly Property Vendor As IVendorRepository
        ReadOnly Property Stocks As IStocksRepository
        ReadOnly Property StockPhoto As IStockPhotoRepository
    End Interface

End Namespace
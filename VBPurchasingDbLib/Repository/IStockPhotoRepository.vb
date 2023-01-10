Imports VBPurchasingDbLib.Model

Namespace Repository

    Public Interface IStockPhotoRepository
        Function FindAll() As List(Of StockPhoto)
        Function FindAllAsync() As Task(Of List(Of StockPhoto))
        Function FindById(ByVal id As Int32) As StockPhoto
        Function Create(ByVal stockPhoto As StockPhoto) As StockPhoto
        Function UpdateBySp(id As Integer, thumbnail As String, photo As String, primary As Boolean, url As String, stockId As Integer, Optional showCommand As Boolean = False) As Boolean
        Function Delete(ByVal id As Int32) As Int32
    End Interface

End Namespace
Imports VBPurchasingDbLib.Model

Namespace Repository
    Public Interface IStocksRepository
        Function Create(ByVal stocks As Stocks) As Stocks
        Function Delete(ByVal id As Int32) As Int32
        Function FindAll() As List(Of Stocks)
        Function FindAllAsync() As Task(Of List(Of Stocks))
        Function FindById(ByVal id As Int32) As Stocks
        Function UpdateBySp(id As Integer, name As String, description As String, size As String, color As String, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
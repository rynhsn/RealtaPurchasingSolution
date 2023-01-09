Imports VBPurchasingDbLib.Model

Namespace Repository
    Public Interface IVendorRepository
        Function Create(ByVal vendor As Vendor) As Vendor
        Function Delete(ByVal id As Int32) As Int32
        Function FindAll() As List(Of Vendor)
        Function FindAllAsync() As Task(Of List(Of Vendor))
        Function FindById(ByVal id As Int32) As Vendor
        Function UpdateBySp(id As Integer, name As String, active As Boolean, priority As Boolean, webUrl As String, Optional showCommand As Boolean = False) As Boolean
    End Interface

End Namespace
Imports VBPurchasingDbLib.Base

Public Interface IPurchasingDbLib
    ReadOnly Property RepositoryManager As IRepositoryManager
    Sub SayHello()
End Interface

Imports NorthwindVbNetApi.Base

Public Interface INorthwindVbApi
    ReadOnly Property RepositoryManager As IRepositoryManager
    Sub SayHello()
End Interface

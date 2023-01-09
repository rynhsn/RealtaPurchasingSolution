Namespace Model

    Public Class Vendor
        Private _id As Integer
        Private _name As String
        Private _active As Boolean
        Private _priority As Boolean
        Private _registerDate As Date
        Private _webUrl As String
        Private _modifiedDate As Date

        Public Sub New()
        End Sub

        Public Sub New(id As Integer, name As String, active As Boolean, priority As Boolean, registerDate As Date, webUrl As String, modifiedDate As Date)
            Me.Id = id
            Me.Name = name
            Me.Active = active
            Me.Priority = priority
            Me.RegisterDate = registerDate
            Me.WebUrl = webUrl
            Me.ModifiedDate = modifiedDate
        End Sub

        Public Property Id As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property Active As Boolean
            Get
                Return _active
            End Get
            Set(value As Boolean)
                _active = value
            End Set
        End Property

        Public Property Priority As Boolean
            Get
                Return _priority
            End Get
            Set(value As Boolean)
                _priority = value
            End Set
        End Property

        Public Property RegisterDate As Date
            Get
                Return _registerDate
            End Get
            Set(value As Date)
                _registerDate = value
            End Set
        End Property

        Public Property WebUrl As String
            Get
                Return _webUrl
            End Get
            Set(value As String)
                _webUrl = value
            End Set
        End Property

        Public Property ModifiedDate As Date
            Get
                Return _modifiedDate
            End Get
            Set(value As Date)
                _modifiedDate = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim v As String = $"Vendor ID : {Id} | Name : {Name} | Active : {Active} | Priority : {Priority} | Reg. Date : {RegisterDate} | Web URL : {WebUrl} | Modified Date : {ModifiedDate}"
            Return v
        End Function
    End Class

End Namespace
Namespace Model

    Public Class StockPhoto
        Private _id As Integer
        Private _thumbnail As String
        Private _photo As String
        Private _primary As Boolean
        Private _url As String
        Private _stockId As Integer

        Public Sub New()
        End Sub

        Public Property Id As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property

        Public Property Thumbnail As String
            Get
                Return _thumbnail
            End Get
            Set(value As String)
                _thumbnail = value
            End Set
        End Property

        Public Property Photo As String
            Get
                Return _photo
            End Get
            Set(value As String)
                _photo = value
            End Set
        End Property

        Public Property Primary As Boolean
            Get
                Return _primary
            End Get
            Set(value As Boolean)
                _primary = value
            End Set
        End Property

        Public Property Url As String
            Get
                Return _url
            End Get
            Set(value As String)
                _url = value
            End Set
        End Property

        Public Property StockId As Integer
            Get
                Return _stockId
            End Get
            Set(value As Integer)
                _stockId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim v As String = $"ID : {Id} | Thumb : {Thumbnail} | Photo : {Photo} | Primary : {Primary} | Url : {Url} | Stock ID : {StockId}"
            Return v
        End Function
    End Class

End Namespace
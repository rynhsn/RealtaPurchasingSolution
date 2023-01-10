Namespace Model

    Public Class Stocks
        Private _id As Integer
        Private _name As String
        Private _description As String
        Private _quantity As Short
        Private _reorderPoint As Short
        Private _used As Short
        Private _scrap As Short
        Private _price As Double
        Private _standarCost As Double
        Private _size As String
        Private _color As String
        Private _modifiedDate As Date

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

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property Description As String
            Get
                Return _description
            End Get
            Set(value As String)
                _description = value
            End Set
        End Property

        Public Property Quantity As Short
            Get
                Return _quantity
            End Get
            Set(value As Short)
                _quantity = value
            End Set
        End Property

        Public Property ReorderPoint As Short
            Get
                Return _reorderPoint
            End Get
            Set(value As Short)
                _reorderPoint = value
            End Set
        End Property

        Public Property Used As Short
            Get
                Return _used
            End Get
            Set(value As Short)
                _used = value
            End Set
        End Property

        Public Property Scrap As Short
            Get
                Return _scrap
            End Get
            Set(value As Short)
                _scrap = value
            End Set
        End Property

        Public Property Price As Double
            Get
                Return _price
            End Get
            Set(value As Double)
                _price = value
            End Set
        End Property

        Public Property StandarCost As Double
            Get
                Return _standarCost
            End Get
            Set(value As Double)
                _standarCost = value
            End Set
        End Property

        Public Property Size As String
            Get
                Return _size
            End Get
            Set(value As String)
                _size = value
            End Set
        End Property

        Public Property Color As String
            Get
                Return _color
            End Get
            Set(value As String)
                _color = value
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
            Dim v As String = $"ID : {Id} | Name : {Name} | Desc : {Description} | Qty : {Quantity} | Reorder Point : {ReorderPoint} | Used : {Used} | Scrap : {Scrap} | Price : {Price} | Standar Cost : {StandarCost} | Size : {Size} | Color : {Color} | Modified Date : {ModifiedDate}"
            Return v
        End Function
    End Class

End Namespace
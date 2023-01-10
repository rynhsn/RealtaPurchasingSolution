Imports System.Data.SqlClient
Imports VBPurchasingDbLib.Context
Imports VBPurchasingDbLib.Model

Namespace Repository

    Public Class StocksRepository
        Implements IStocksRepository

        'Dependency Injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function Create(stocks As Stocks) As Stocks Implements IStocksRepository.Create
            Dim newStock As New Stocks()

            'declare statement primary key using identity integer
            Dim sqlIdentity As String = "
                                         INSERT INTO purchasing.stocks(stock_name, stock_description, stock_size, stock_color) 
                                         VALUES (@name, @description, @size, @color) SELECT CAST(scope_identity() as int)
                                        "
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlIdentity}

                    cmd.Parameters.AddWithValue("@name", stocks.Name)
                    cmd.Parameters.AddWithValue("@description", stocks.Description)
                    cmd.Parameters.AddWithValue("@size", stocks.Size)
                    cmd.Parameters.AddWithValue("@color", stocks.Color)
                    Try
                        conn.Open()
                        'executescalar return 1 row & get first column
                        Dim stockId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newStock = FindById(stockId)
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newStock
        End Function

        Public Function Delete(id As Integer) As Integer Implements IStocksRepository.Delete
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim sql As String = "DELETE FROM purchasing.stocks WHERE stock_id = @id;"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@id", id)

                    Try
                        conn.Open()
                        rowEffect = cmd.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return rowEffect
        End Function

        Public Function FindAll() As List(Of Stocks) Implements IStocksRepository.FindAll
            Dim stockList As New List(Of Stocks)
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.stocks " &
                                "ORDER BY stock_id ASC;"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            stockList.Add(New Stocks() With {
                            .Id = reader.GetInt32(0),
                            .Name = reader.GetString(1),
                            .Description = reader.GetString(2),
                            .Quantity = reader.GetInt16(3),
                            .ReorderPoint = reader.GetInt16(4),
                            .Used = reader.GetInt16(5),
                            .Scrap = reader.GetInt16(6),
                            .Price = reader.GetDecimal(7),
                            .StandarCost = reader.GetDecimal(8),
                            .Size = reader.GetString(9),
                            .Color = reader.GetString(10),
                            .ModifiedDate = reader.GetDateTime(11)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return stockList
        End Function

        Public Async Function FindAllAsync() As Task(Of List(Of Stocks)) Implements IStocksRepository.FindAllAsync
            Dim stockList As New List(Of Stocks)
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.stocks " &
                                "ORDER BY stock_id ASC;"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            stockList.Add(New Stocks() With {
                            .Id = reader.GetInt32(0),
                            .Name = reader.GetString(1),
                            .Description = reader.GetString(2),
                            .Quantity = reader.GetInt16(3),
                            .ReorderPoint = reader.GetInt16(4),
                            .Used = reader.GetInt16(5),
                            .Scrap = reader.GetInt16(6),
                            .Price = reader.GetDecimal(7),
                            .StandarCost = reader.GetDecimal(8),
                            .Size = reader.GetString(9),
                            .Color = reader.GetString(10),
                            .ModifiedDate = reader.GetDateTime(11)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return stockList
        End Function

        Public Function FindById(id As Integer) As Stocks Implements IStocksRepository.FindById
            Dim stocks As New Stocks With {.Id = id}
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.stocks WHERE stock_id = @id"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@id", id)
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            stocks.Id = reader.GetInt32(0)
                            Stocks.Name = reader.GetString(1)
                            Stocks.Description = reader.GetString(2)
                            Stocks.Quantity = reader.GetInt16(3)
                            Stocks.ReorderPoint = reader.GetInt16(4)
                            Stocks.Used = reader.GetInt16(5)
                            Stocks.Scrap = reader.GetInt16(6)
                            Stocks.Price = reader.GetDecimal(7)
                            Stocks.StandarCost = reader.GetDecimal(8)
                            Stocks.Size = reader.GetString(9)
                            Stocks.Color = reader.GetString(10)
                            Stocks.ModifiedDate = reader.GetDateTime(11)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return stocks
        End Function

        Public Function UpdateBySp(id As Integer, name As String, description As String, size As String, color As String, Optional showCommand As Boolean = False) As Boolean Implements IStocksRepository.UpdateBySp
            Dim updateStock As New Stocks()

            'declare statement
            Dim sql As String = "purchasing.spUpdateStocks"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@size", size)
                    cmd.Parameters.AddWithValue("@color", color)

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return True
        End Function
    End Class

End Namespace
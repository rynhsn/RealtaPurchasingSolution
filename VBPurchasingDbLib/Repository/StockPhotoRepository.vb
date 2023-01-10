Imports System.Data.SqlClient
Imports VBPurchasingDbLib.Context
Imports VBPurchasingDbLib.Model

Namespace Repository

    Public Class StockPhotoRepository
        Implements IStockPhotoRepository

        'Dependency Injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAll() As List(Of StockPhoto) Implements IStockPhotoRepository.FindAll
            Dim result As New List(Of StockPhoto)
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.stock_photo " &
                                "ORDER BY spho_id ASC;"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            result.Add(New StockPhoto() With {
                            .Id = reader.GetInt32(0),
                            .Thumbnail = reader.GetString(1),
                            .Photo = reader.GetString(2),
                            .Primary = reader.GetBoolean(3),
                            .Url = reader.GetString(4),
                            .StockId = reader.GetInt32(5)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return result
        End Function

        Public Async Function FindAllAsync() As Task(Of List(Of StockPhoto)) Implements IStockPhotoRepository.FindAllAsync
            Dim result As New List(Of StockPhoto)
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.stock_photo " &
                                "ORDER BY spho_id ASC;"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            result.Add(New StockPhoto() With {
                            .Id = reader.GetInt32(0),
                            .Thumbnail = reader.GetString(1),
                            .Photo = reader.GetString(2),
                            .Primary = reader.GetBoolean(3),
                            .Url = reader.GetString(4),
                            .StockId = reader.GetInt32(5)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return result
        End Function

        Public Function FindById(id As Integer) As StockPhoto Implements IStockPhotoRepository.FindById
            Dim result As New StockPhoto With {.Id = id}
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.stock_photo WHERE spho_id = @id"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@id", id)
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            reader.Read()
                            result.Id = reader.GetInt32(0)
                            result.Thumbnail = reader.GetString(1)
                            result.Photo = reader.GetString(2)
                            result.Primary = reader.GetBoolean(3)
                            result.Url = reader.GetString(4)
                            result.StockId = reader.GetInt32(5)
                        End If

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return result
        End Function

        Public Function Create(stockPhoto As StockPhoto) As StockPhoto Implements IStockPhotoRepository.Create
            Dim result As New StockPhoto()

            'declare statement primary key using identity integer
            Dim sqlIdentity As String = "
                                         INSERT INTO purchasing.stock_photo(spho_thumbnail_filename, spho_photo_filename, spho_primary, spho_url, spho_stock_id) 
                                         VALUES (@thumbnail, @photo, @primary, @url, @stockId) SELECT CAST(scope_identity() as int)
                                        "
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlIdentity}
                    cmd.Parameters.AddWithValue("@thumbnail", stockPhoto.Thumbnail)
                    cmd.Parameters.AddWithValue("@photo", stockPhoto.Photo)
                    cmd.Parameters.AddWithValue("@primary", stockPhoto.Primary)
                    cmd.Parameters.AddWithValue("@url", stockPhoto.Url)
                    cmd.Parameters.AddWithValue("@stockId", stockPhoto.StockId)
                    Try
                        conn.Open()
                        'executescalar return 1 row & get first column
                        Dim id As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        result = FindById(id)
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return result
        End Function

        Public Function UpdateBySp(id As Integer, thumbnail As String, photo As String, primary As Boolean, url As String, stockId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IStockPhotoRepository.UpdateBySp
            Dim result As New StockPhoto()

            'declare statement primary key using identity integer
            Dim sqlIdentity As String = "purchasing.spUpdateStockPhoto"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlIdentity, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@thumbnail", thumbnail)
                    cmd.Parameters.AddWithValue("@photo", photo)
                    cmd.Parameters.AddWithValue("@primary", primary)
                    cmd.Parameters.AddWithValue("@url", url)
                    cmd.Parameters.AddWithValue("@stockId", stockId)

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

        Public Function Delete(id As Integer) As Integer Implements IStockPhotoRepository.Delete
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim sql As String = "DELETE FROM purchasing.stock_photo WHERE spho_id = @id;"

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
    End Class

End Namespace
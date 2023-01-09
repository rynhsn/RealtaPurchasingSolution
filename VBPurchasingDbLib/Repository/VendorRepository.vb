
Imports System.Data.SqlClient
Imports VBPurchasingDbLib.Context
Imports VBPurchasingDbLib.Model

Namespace Repository

    Public Class VendorRepository
        Implements IVendorRepository

        'Dependency Injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function Create(vendor As Vendor) As Vendor Implements IVendorRepository.Create
            Dim newVendor As New Vendor()

            'declare statement
            'primary key using identity integer
            Dim sqlIdentity As String = "INSERT INTO purchasing.vendor(vendor_name, vendor_active, vendor_priority, vendor_weburl) values (@name, @active, @priority, @weburl) SELECT CAST(scope_identity() as int)"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sqlIdentity}
                    Dim webChecker = If(String.IsNullOrEmpty(vendor.WebUrl), DBNull.Value, vendor.WebUrl)

                    cmd.Parameters.AddWithValue("@name", vendor.Name)
                    cmd.Parameters.AddWithValue("@active", vendor.Active)
                    cmd.Parameters.AddWithValue("@priority", vendor.Priority)
                    cmd.Parameters.AddWithValue("@weburl", webChecker)
                    Try
                        conn.Open()
                        'executescalar return 1 row & get first column
                        Dim vendorId As Int32 = Convert.ToInt32(cmd.ExecuteScalar())
                        newVendor = FindById(vendorId)
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newVendor
        End Function

        Public Function Delete(id As Integer) As Integer Implements IVendorRepository.Delete
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim sql As String = "DELETE FROM purchasing.vendor " &
                                "WHERE vendor_id = @id;"

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

        Public Function FindAll() As List(Of Vendor) Implements IVendorRepository.FindAll
            Dim vendorList As New List(Of Vendor)
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.vendor " &
                                "ORDER BY vendor_id ASC;"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            vendorList.Add(New Vendor() With {
                            .Id = reader.GetInt32(0),
                            .Name = reader.GetString(1),
                            .Active = reader.GetBoolean(2),
                            .Priority = reader.GetBoolean(3),
                            .RegisterDate = reader.GetDateTime(4),
                            .WebUrl = If(reader.IsDBNull(5), "", reader.GetString(5)),
                            .ModifiedDate = reader.GetDateTime(6)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return vendorList
        End Function

        Public Async Function FindAllAsync() As Task(Of List(Of Vendor)) Implements IVendorRepository.FindAllAsync
            Dim vendorList As New List(Of Vendor)
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.vendor " &
                                "ORDER BY vendor_id ASC;"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    Try
                        conn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()
                        While reader.Read()
                            vendorList.Add(New Vendor() With {
                            .Id = reader.GetInt32(0),
                            .Name = reader.GetString(1),
                            .Active = reader.GetBoolean(2),
                            .Priority = reader.GetBoolean(3),
                            .RegisterDate = reader.GetDateTime(4),
                            .WebUrl = If(reader.IsDBNull(5), "", reader.GetString(5)),
                            .ModifiedDate = reader.GetDateTime(6)
                            })
                        End While

                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return vendorList
        End Function

        Public Function FindById(id As Integer) As Vendor Implements IVendorRepository.FindById
            Dim vendor As New Vendor() With {.Id = id}
            'declare statement
            Dim sql As String = "SELECT * FROM purchasing.vendor WHERE vendor_id = @id"
            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}

                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@id", id)
                    Try
                        conn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            vendor.Name = reader.GetString(1)
                            vendor.Active = reader.GetBoolean(2)
                            vendor.Priority = reader.GetBoolean(3)
                            vendor.RegisterDate = reader.GetDateTime(4)
                            vendor.WebUrl = If(reader.IsDBNull(5), "", reader.GetString(5))
                            vendor.ModifiedDate = reader.GetDateTime(6)
                        End If
                        reader.Close()
                        conn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return vendor
        End Function

        Public Function UpdateBySp(id As Integer, name As String, active As Boolean, priority As Boolean, webUrl As String, Optional showCommand As Boolean = False) As Boolean Implements IVendorRepository.UpdateBySp
            Dim updateVendor As New Vendor()
            Dim webUrlChecker = If(String.IsNullOrEmpty(webUrl), DBNull.Value, webUrl)

            'declare statement
            Dim sql As String = "purchasing.spUpdateVendor"

            'try to connect
            Using conn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = conn, .CommandText = sql, .CommandType = Data.CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@active", active)
                    cmd.Parameters.AddWithValue("@priority", priority)
                    cmd.Parameters.AddWithValue("@weburl", webUrlChecker)

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
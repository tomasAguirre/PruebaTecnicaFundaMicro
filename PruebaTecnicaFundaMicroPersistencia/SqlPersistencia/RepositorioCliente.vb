Imports System.Data
Imports Dominio
Imports Microsoft.Data.SqlClient
Imports PruebaTecnicaFundaMicro.Aplicacion

Namespace PruebaTecnicaFundaMicroPersistencia.SqlPersistencia
    Public Class RepositorioCliente
        Inherits ConexionHelper
        Implements IRepositorioCliente


        Public Sub Eliminar(id As Integer) Implements IRepositorioCliente.Eliminar
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()

                Dim query As String = "DELETE FROM Cliente WHERE Id = @Id"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Actualizar(cliente As Cliente) Implements IRepositorioCliente.Actualizar
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()

                Dim query As String = "UPDATE Cliente 
                                   SET Nombre = @Nombre, Telefono = @Telefono, Direccion = @Direccion 
                                   WHERE Id = @Id"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = cliente.Id
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = cliente.Nombre
                    cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = cliente.Telefono
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = cliente.Direccion

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Insertar(cliente As Cliente) Implements IRepositorioCliente.Insertar
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()

                Dim query As String = "INSERT INTO Cliente (Nombre, Telefono, Direccion) 
                                   VALUES (@Nombre, @Telefono, @Direccion)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = cliente.Nombre
                    cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = cliente.Telefono
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = cliente.Direccion

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function ObtenerTodos() As List(Of Cliente) Implements IRepositorioCliente.ObtenerTodos
            Dim clientes As New List(Of Cliente)

            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()

                Dim query As String = "SELECT Id, Nombre, Telefono, Direccion FROM Cliente"

                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            clientes.Add(New Cliente(
                            CInt(reader("Id")),
                            reader("Nombre").ToString(),
                            reader("Telefono").ToString(),
                            reader("Direccion").ToString()
                        ))
                        End While
                    End Using
                End Using
            End Using

            Return clientes
        End Function
    End Class
End Namespace
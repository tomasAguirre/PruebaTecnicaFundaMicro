Imports Dominio
Imports Microsoft.Data.SqlClient
Imports PruebaTecnicaFundaMicro.Aplicacion
Imports System.Data

Public Class RepositorioBitacora
    Inherits ConexionHelper
    Implements IRepositorioBitacora

    Public Sub Insertar(bitacora As Bitacora) Implements IRepositorioBitacora.Insertar
        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Dim query As String = "INSERT INTO Bitacora (AccionRealizada, IdCliente, Fecha, NombreUsuario) 
                                   VALUES (@AccionRealizada, @IdCliente, @Fecha, @NombreUsuario)"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.Add("@AccionRealizada", SqlDbType.NVarChar, 200).Value = bitacora.AccionRealizada
                cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = bitacora.IdCliente
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = bitacora.Fecha
                cmd.Parameters.Add("@NombreUsuario", SqlDbType.NVarChar, 100).Value = bitacora.NombreUsuario

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function ObtenerTodas() As List(Of Bitacora) Implements IRepositorioBitacora.ObtenerTodas
        Dim lista As New List(Of Bitacora)

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Dim query As String = "SELECT Id, AccionRealizada, IdCliente, Fecha, NombreUsuario FROM Bitacora"

            Using cmd As New SqlCommand(query, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        lista.Add(New Bitacora(
                            CInt(reader("Id")),
                            reader("AccionRealizada").ToString(),
                            CInt(reader("IdCliente")),
                            CDate(reader("Fecha")),
                            reader("NombreUsuario").ToString()
                        ))
                    End While
                End Using
            End Using
        End Using

        Return lista
    End Function
End Class

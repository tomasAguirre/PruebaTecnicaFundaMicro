Imports Dominio
Imports Microsoft.Data.SqlClient
Imports PruebaTecnicaFundaMicro.Aplicacion

Public Class RepositorioUsuario
    Inherits ConexionHelper
    Implements IRepositorioUsuario

    Public Function ObtenerUsuarioPorCredenciales(password As String, correo As String) As Usuario Implements IRepositorioUsuario.ObtenerUsuarioPorCredenciales
        Dim usuarioEncontrado As Usuario = Nothing

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Dim query As String = "SELECT Id, Nombre, Password, Correo 
                                   FROM Usuario 
                                   WHERE Password = @Password AND Correo = @Correo"

            Using cmd As New SqlCommand(query, conn)
                ' Parámetros para evitar SQL Injection
                cmd.Parameters.AddWithValue("@Password", password)
                cmd.Parameters.AddWithValue("@Correo", correo)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        usuarioEncontrado = New Usuario(
                            CInt(reader("Id")),
                            reader("Nombre").ToString(),
                            reader("Password").ToString(),
                            reader("Correo").ToString()
                        )
                    End If
                End Using
            End Using
        End Using

        Return usuarioEncontrado
    End Function
    ' Función para obtener un usuario por Password y Correo


End Class

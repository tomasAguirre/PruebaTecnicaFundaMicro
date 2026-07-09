Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports Dominio
Imports Microsoft.Data.SqlClient
Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Dominio

Public Class RepositorioUsuario
    Inherits ConexionHelper
    Implements IRepositorioUsuario

    Public Function HashPassword(password As String) As Byte()
        Using sha256 As SHA256 = sha256.Create()
            Return sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
        End Using
    End Function

    Public Function ObtenerUsuarioPorCredenciales(password As String, correo As String) As Usuario Implements IRepositorioUsuario.ObtenerUsuarioPorCredenciales
        Dim usuarioEncontrado As Usuario = Nothing

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Dim query As String = "SELECT Id, Nombre, Password, Correo 
                               FROM Usuario 
                               WHERE Correo = @Correo 
                                 AND Password = @Password"

            Using cmd As New SqlCommand(query, conn)
                ' Generar el hash en VB.NET
                Dim passwordHash As Byte() = HashPassword(password)

                ' Parámetros
                cmd.Parameters.AddWithValue("@Correo", correo)
                cmd.Parameters.Add("@Password", SqlDbType.VarBinary, 32).Value = passwordHash

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        usuarioEncontrado = New Usuario(
                        CInt(reader("Id")),
                        reader("Nombre").ToString(),
                        reader("Correo").ToString()
                    )
                    End If
                End Using
            End Using
        End Using

        Return usuarioEncontrado
    End Function

    Public Function InsertarUsuario(usuario As Usuario) As Integer Implements IRepositorioUsuario.InsertarUsuario
        Dim nuevoId As Integer
        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Dim query As String = "INSERT INTO Usuario (Nombre, Password, Correo) 
                               VALUES (@Nombre, @Password, @Correo);
                               SELECT SCOPE_IDENTITY();"

            Using cmd As New SqlCommand(query, conn)
                ' Generar el hash SHA256 de la contraseña
                Dim passwordHash As Byte() = HashPassword(usuario.Password)

                ' Parámetros
                cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = usuario.Nombre
                cmd.Parameters.Add("@Correo", SqlDbType.NVarChar, 100).Value = usuario.Correo
                cmd.Parameters.Add("@Password", SqlDbType.VarBinary, 32).Value = passwordHash

                ' Ejecutar y obtener el Id generado
                nuevoId = Convert.ToInt32(cmd.ExecuteScalar())

                ' Asignar el Id al objeto usuario
                usuario.Id = nuevoId
            End Using
        End Using
        Return nuevoId
    End Function

End Class

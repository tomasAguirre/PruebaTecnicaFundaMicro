Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.Data.SqlClient
Public MustInherit Class ConexionHelper
    Protected ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("PruebaTecnicaDb").ConnectionString
    End Sub

    Protected Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(_connectionString)
    End Function
End Class

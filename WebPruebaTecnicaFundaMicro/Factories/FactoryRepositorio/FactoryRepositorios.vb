Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Persistencia
Imports PruebaTecnicaFundaMicro_Persistencia.PruebaTecnicaFundaMicroPersistencia.SqlPersistencia

Public Class FactoryRepositorios
    Public Function ObtenerRepositorioCliente() As RepositorioCliente
        Return New RepositorioCliente()
    End Function

    Public Function ObtenerRepositorioUsuario() As RepositorioUsuario
        Return New RepositorioUsuario()
    End Function

    Public Function ObtenerRepositorioBitacora() As RepositorioBitacora
        Return New RepositorioBitacora()
    End Function
End Class

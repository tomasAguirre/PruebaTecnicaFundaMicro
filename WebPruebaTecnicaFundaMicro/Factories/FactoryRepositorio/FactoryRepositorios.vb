Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Persistencia.PruebaTecnicaFundaMicroPersistencia.SqlPersistencia

Public Class FactoryRepositorios
    Public Function ObtenerRepositorioCliente() As RepositorioCliente
        Return New RepositorioCliente()
    End Function
End Class

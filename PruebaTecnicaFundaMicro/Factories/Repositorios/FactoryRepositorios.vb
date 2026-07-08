Public Class FactoryRepositorios
    Public Function ObtenerRepositorioCliente() As RepositorioCliente
        Return New RepositorioCliente()
    End Function
End Class

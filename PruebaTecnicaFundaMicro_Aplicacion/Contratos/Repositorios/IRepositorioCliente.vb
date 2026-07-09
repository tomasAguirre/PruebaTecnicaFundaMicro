Imports Dominio
Imports PruebaTecnicaFundaMicro_Dominio

Public Interface IRepositorioCliente
    Function ObtenerTodos() As List(Of Cliente)
    Function Insertar(cliente As Cliente) As Integer
    Sub Actualizar(cliente As Cliente)
    Sub Eliminar(id As Integer)

    Function ObtenerClientePorId(id As Integer) As Cliente
End Interface

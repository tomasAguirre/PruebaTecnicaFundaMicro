Imports Dominio

Public Interface IRepositorioCliente
    Function ObtenerTodos() As List(Of Cliente)
    Sub Insertar(cliente As Cliente)
    Sub Actualizar(cliente As Cliente)
    Sub Eliminar(id As Integer)
End Interface

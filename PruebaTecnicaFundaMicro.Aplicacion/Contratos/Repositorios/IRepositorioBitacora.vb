Imports Dominio

Public Interface IRepositorioBitacora
    Sub Insertar(bitacora As Bitacora)
    Function ObtenerTodas() As List(Of Bitacora)
End Interface

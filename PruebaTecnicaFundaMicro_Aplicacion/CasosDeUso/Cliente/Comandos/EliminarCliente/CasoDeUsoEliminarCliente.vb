Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador

Public Class CasoDeUsoEliminarCliente
    Implements IRequestHandler(Of ComandoEliminarCliente, Boolean)

    Private ReadOnly repositorio As IRepositorioCliente


    Public Sub New(repositorio As IRepositorioCliente)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ComandoEliminarCliente) As Task(Of Boolean) Implements IRequestHandler(Of ComandoEliminarCliente, Boolean).Handle
        Try
            repositorio.Eliminar(request.Id)

        Catch ex As Exception
            Throw New Exception("Error al eliminar el cliente: " & ex.Message)
        End Try
    End Function
End Class

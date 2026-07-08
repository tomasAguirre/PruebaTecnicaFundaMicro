Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoActualizarCliente
    Implements IRequestHandler(Of ComandoActualizarCliente, Boolean)
    Private ReadOnly repositorio As IRepositorioCliente
    Public Sub New(repositorio As IRepositorioCliente)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ComandoActualizarCliente) As Task(Of Boolean) Implements IRequestHandler(Of ComandoActualizarCliente, Boolean).Handle
        Dim cliente As New Cliente(request.Id, request.Nombre, request.Telefono, request.Direccion)
        Try
            Me.repositorio.Actualizar(cliente)
        Catch ex As Exception

        End Try
        Return Task.FromResult(True)
    End Function
End Class

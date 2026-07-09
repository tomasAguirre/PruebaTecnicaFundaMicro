Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoCrearBitacora
    Implements IRequestHandler(Of ComandoCrearBitacora, Integer)

    Private ReadOnly repositorio As IRepositorioBitacora

    Public Sub New(repositorio As IRepositorioBitacora)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ComandoCrearBitacora) As Task(Of Integer) Implements IRequestHandler(Of ComandoCrearBitacora, Integer).Handle
        Try
            Dim bitacora As New Bitacora()
            bitacora.NombreUsuario = request.NombreUsuario
            bitacora.IdCliente = request.IdCliente
            bitacora.AccionRealizada = request.AccionRealizada
            bitacora.Fecha = request.Fecha
            Me.repositorio.Insertar(bitacora)

            Return Task.FromResult(bitacora.Id)
        Catch ex As Exception
            Throw New Exception("Error al crear bitacora: " & ex.Message)
        End Try
    End Function
End Class

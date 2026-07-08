Imports System.Windows.Forms.VisualStyles
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoObtenerClientePorId
    Implements IRequestHandler(Of ConsultaObtenerClientePorId, Cliente)

    Private ReadOnly repositorio As IRepositorioCliente


    Public Sub New(repositorio As IRepositorioCliente)
        Me.repositorio = repositorio
    End Sub


    Public Function Handle(request As ConsultaObtenerClientePorId) As Task(Of Cliente) Implements IRequestHandler(Of ConsultaObtenerClientePorId, Cliente).Handle
        Dim cliente1 As Cliente
        Try
            cliente1 = Me.repositorio.ObtenerClientePorId(request.Id)
        Catch ex As Exception

        End Try
        Return Task.FromResult(cliente1)
    End Function
End Class

Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoObtenerBitacoras
    Implements IRequestHandler(Of ConsultaObtenerBitacoras, List(Of Bitacora))

    Private ReadOnly repositorio As IRepositorioBitacora


    Public Sub New(repositorio As IRepositorioBitacora)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ConsultaObtenerBitacoras) As Task(Of List(Of Bitacora)) Implements IRequestHandler(Of ConsultaObtenerBitacoras, List(Of Bitacora)).Handle
        Try
            Dim bitacoras = Me.repositorio.ObtenerTodas()
            Return Task.FromResult(bitacoras)
        Catch ex As Exception

        End Try
    End Function
End Class

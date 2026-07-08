Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoBuscarPorPasswordYCorreo
    Implements IRequestHandler(Of ConsultaBuscarPorPasswordYCorreo, Usuario)
    Private ReadOnly repositorio As IRepositorioUsuario

    Public Sub New(repositorio As IRepositorioUsuario)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ConsultaBuscarPorPasswordYCorreo) As Task(Of Usuario) Implements IRequestHandler(Of ConsultaBuscarPorPasswordYCorreo, Usuario).Handle
        Try
            Dim usuario As Usuario = Me.repositorio.ObtenerUsuarioPorCredenciales(request.Password, request.Correo)
            Return Task.FromResult(usuario)
        Catch ex As Exception
            Throw New Exception("Error al buscar el usuario: " & ex.Message)
        End Try
    End Function
End Class

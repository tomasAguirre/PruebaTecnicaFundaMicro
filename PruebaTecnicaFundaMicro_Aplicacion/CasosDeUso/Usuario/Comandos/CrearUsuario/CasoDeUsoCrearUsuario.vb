Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoCrearUsuario
    Implements IRequestHandler(Of ComandoCrearUsuario, Integer)
    Private ReadOnly repositorio As IRepositorioUsuario

    Public Sub New(repositorio As IRepositorioUsuario)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ComandoCrearUsuario) As Task(Of Integer) Implements IRequestHandler(Of ComandoCrearUsuario, Integer).Handle
        Try
            Dim usuario As New Usuario()
            usuario.Correo = request.Correo
            usuario.Nombre = request.Nombre
            usuario.Password = request.Password
            Me.repositorio.InsertarUsuario(usuario)
        Catch ex As Exception
            Throw New Exception("Error al crear el usuario: " & ex.Message)
        End Try
    End Function
End Class

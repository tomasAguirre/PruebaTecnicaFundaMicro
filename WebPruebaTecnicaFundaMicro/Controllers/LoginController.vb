Imports System.Web.Mvc
Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio
Imports PruebaTecnicaFundaMicro_Persistencia.PruebaTecnicaFundaMicroPersistencia.SqlPersistencia

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        Private ReadOnly _mediador As MediadorSimple
        Private ReadOnly _repositorioUsuario As IRepositorioUsuario

        Public Sub New()
            Dim FactoryMediator = New FactoryMediator()
            Dim _FactoryRepositorio = New FactoryRepositorios()
            _mediador = FactoryMediator.ObtenerMediatorSimple()
            _repositorioUsuario = _FactoryRepositorio.ObtenerRepositorioUsuario()
        End Sub

        ' GET: Login
        Function Login() As ActionResult
            Return View()
        End Function


        ' POST: Login/Create
        <HttpPost()>
        Function Logear(ByVal collection As FormCollection) As ActionResult
            Try
                Dim Password As String = collection("Password")
                Dim Correo As String = collection("Correo")
                _mediador.RegistrarHandler(New CasoDeUsoBuscarPorPasswordYCorreo(_repositorioUsuario))
                Dim usuario As Usuario = _mediador.Send(New ConsultaBuscarPorPasswordYCorreo(Password, Correo)).Result

                If usuario IsNot Nothing Then
                    Session("UsuarioLogeado") = usuario
                    Return RedirectToAction("Index", "Home")
                Else
                    ' Usuario no encontrado → mostrar error en la misma vista
                    ModelState.AddModelError("", "Correo o contraseña incorrectos")
                    Return View("Login")
                End If


            Catch
                Return View()
            End Try
        End Function

    End Class
End Namespace
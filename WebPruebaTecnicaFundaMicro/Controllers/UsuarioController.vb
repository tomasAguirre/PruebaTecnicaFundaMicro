Imports System.Web.Mvc
Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Namespace Controllers
    Public Class UsuarioController
        Inherits Controller

        Private ReadOnly _mediador As MediadorSimple
        Private ReadOnly _FactoryRepositorio As FactoryRepositorios
        Private ReadOnly _repositorioUsuarios As IRepositorioUsuario

        ' Constructor 
        Public Sub New()
            Dim FactoryMediator = New FactoryMediator()
            _FactoryRepositorio = New FactoryRepositorios()
            _mediador = FactoryMediator.ObtenerMediatorSimple()
            _repositorioUsuarios = _FactoryRepositorio.ObtenerRepositorioUsuario()


            _mediador.RegistrarHandler(New CasoDeUsoCrearUsuario(_repositorioUsuarios))

        End Sub

        ' GET: Usuario
        Function Index() As ActionResult
            Return View()
        End Function

        Function create(fc As FormCollection) As ActionResult
            Dim comandoCrearUsuario = New ComandoCrearUsuario()
            comandoCrearUsuario.Nombre = fc("Nombre")
            comandoCrearUsuario.Correo = fc("Correo")
            comandoCrearUsuario.Password = fc("Password")
            _mediador.Send(comandoCrearUsuario)

            Return RedirectToAction("Login", "Login")
        End Function
    End Class
End Namespace
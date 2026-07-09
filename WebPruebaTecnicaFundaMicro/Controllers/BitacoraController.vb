Imports System.Web.Mvc
Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador

Namespace Controllers
    Public Class BitacoraController
        Inherits Controller

        Private ReadOnly _mediator As MediadorSimple
        Private ReadOnly _repositorioBitacora As IRepositorioBitacora
        Private ReadOnly factory As FactoryRepositorios
        Private ReadOnly factoryMediator As FactoryMediator

        Public Sub New()
            factory = New FactoryRepositorios
            factoryMediator = New FactoryMediator
            _mediator = factoryMediator.ObtenerMediatorSimple()
            _repositorioBitacora = factory.ObtenerRepositorioBitacora()
            _mediator.RegistrarHandler(New CasoDeUsoObtenerBitacoras(_repositorioBitacora))
        End Sub

        ' GET: Bitacora
        Function Index() As ActionResult
            If Session("UsuarioLogeado") Is Nothing Then
                Return RedirectToAction("Login", "Login")
            End If

            Dim bitacoras = _mediator.Send(New ConsultaObtenerBitacoras).Result
            Return View(bitacoras)
        End Function

    End Class
End Namespace
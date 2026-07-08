Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _mediador As MediadorSimple
    Private ReadOnly _FactoryRepositorio As FactoryRepositorios
    Private ReadOnly _repositorioCliente As IRepositorioCliente

    ' Constructor con inyección de dependencia
    Public Sub New()
        Dim FactoryMediator = New FactoryMediator()
        _FactoryRepositorio = New FactoryRepositorios()
        _mediador = FactoryMediator.ObtenerMediatorSimple()
        _repositorioCliente = _FactoryRepositorio.ObtenerRepositorioCliente()
    End Sub

    Function Index() As ActionResult
        _mediador.RegistrarHandler(New CasoDeUsoObtenerClientes(_repositorioCliente))
        Dim resultado = _mediador.Send(New ConsultaObtenerClientes).Result
        Return View(resultado)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function recieveData(fc As FormCollection) As ActionResult
        Dim nombre As String = fc("nombre")
        Dim telefono As String = fc("telefono")
        Dim direccion As String = fc("direccion")
        Dim comandoCrearCliente As ComandoCrearCliente = New ComandoCrearCliente(nombre, telefono, direccion)
        _mediador.RegistrarHandler(New CasoDeUsoCrearCliente(_repositorioCliente))
        _mediador.Send(comandoCrearCliente).Wait()

        Return RedirectToAction("Index")
    End Function

    <HttpPost>
    Function Eliminar(id As Integer) As ActionResult
        Dim comandoEliminarCliente As ComandoEliminarCliente = New ComandoEliminarCliente(id)
        _mediador.RegistrarHandler(New CasoDeUsoEliminarCliente(_repositorioCliente))
        _mediador.Send(comandoEliminarCliente)
        Return RedirectToAction("Index")
    End Function

    Function Edit(id As Integer) As ActionResult
        _mediador.RegistrarHandler(New CasoDeUsoObtenerClientePorId(_repositorioCliente))
        Dim cliente = _mediador.Send(New ConsultaObtenerClientePorId(id)).Result
        If cliente Is Nothing Then
            Return HttpNotFound()
        End If
        Dim clienteDTO As New ClientesDetalleDTO()
        clienteDTO.Id = cliente.Id
        clienteDTO.Nombre = cliente.Nombre
        clienteDTO.Telefono = cliente.Telefono
        clienteDTO.Direccion = cliente.Direccion

        Return View(clienteDTO)
    End Function

    <HttpPost>
    Function Edit(cliente As ClientesDetalleDTO) As ActionResult
        If ModelState.IsValid Then
            _mediador.RegistrarHandler(New CasoDeUsoActualizarCliente(_repositorioCliente))
            _mediador.Send(New ComandoActualizarCliente(cliente.Id, cliente.Nombre, cliente.Telefono, cliente.Direccion))
            Return RedirectToAction("Index")
        End If
        Return View(cliente)
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class

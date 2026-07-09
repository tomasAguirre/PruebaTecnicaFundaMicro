Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly _mediador As MediadorSimple
    Private ReadOnly _FactoryRepositorio As FactoryRepositorios
    Private ReadOnly _repositorioCliente As IRepositorioCliente
    Private ReadOnly _repositorioBitacora As IRepositorioBitacora
    Private ReadOnly usuario As Usuario
    Private ReadOnly accion As Accion

    ' Constructor 
    Public Sub New()
        Dim FactoryMediator = New FactoryMediator()
        _FactoryRepositorio = New FactoryRepositorios()
        _mediador = FactoryMediator.ObtenerMediatorSimple()
        _repositorioCliente = _FactoryRepositorio.ObtenerRepositorioCliente()
        _repositorioBitacora = _FactoryRepositorio.ObtenerRepositorioBitacora()

        _mediador.RegistrarHandler(New CasoDeUsoObtenerClientes(_repositorioCliente))
        _mediador.RegistrarHandler(New CasoDeUsoCrearCliente(_repositorioCliente))
        _mediador.RegistrarHandler(New CasoDeUsoEliminarCliente(_repositorioCliente))
        _mediador.RegistrarHandler(New CasoDeUsoObtenerClientePorId(_repositorioCliente))
        _mediador.RegistrarHandler(New CasoDeUsoActualizarCliente(_repositorioCliente))
        _mediador.RegistrarHandler(New CasoDeUsoCrearBitacora(_repositorioBitacora))

    End Sub

    Function Index() As ActionResult
        If Session("UsuarioLogeado") Is Nothing Then
            Return RedirectToAction("Login", "Login")
        End If

        Dim resultado = _mediador.Send(New ConsultaObtenerClientes).Result
        Return View(resultado)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "app de prueba de fundamicro."

        Return View()
    End Function

    Function CrearCliente(fc As FormCollection) As ActionResult
        Dim nombre As String = fc("nombre")
        Dim telefono As String = fc("telefono")
        Dim direccion As String = fc("direccion")
        Dim comandoCrearCliente As ComandoCrearCliente = New ComandoCrearCliente(nombre, telefono, direccion)

        Dim id = _mediador.Send(comandoCrearCliente).Result
        Dim usuario As Usuario = DirectCast(Session("UsuarioLogeado"), Usuario)
        Dim comandoCrearBitacora As New ComandoCrearBitacora(Accion.Agregar.ToString(), id, DateTime.UtcNow, usuario.Nombre)
        _mediador.Send(comandoCrearBitacora)
        Return RedirectToAction("Index")
    End Function

    <HttpPost>
    Function Eliminar(id As Integer) As ActionResult
        Dim comandoEliminarCliente As ComandoEliminarCliente = New ComandoEliminarCliente(id)
        _mediador.Send(comandoEliminarCliente)

        Dim usuario As Usuario = DirectCast(Session("UsuarioLogeado"), Usuario)
        Dim comandoCrearBitacora As New ComandoCrearBitacora(Accion.Eliminar.ToString(), id, DateTime.UtcNow, usuario.Nombre)
        _mediador.Send(comandoCrearBitacora)
        Return RedirectToAction("Index")
    End Function

    Function Edit(id As Integer) As ActionResult
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
            _mediador.Send(New ComandoActualizarCliente(cliente.Id, cliente.Nombre, cliente.Telefono, cliente.Direccion))

            Dim usuario As Usuario = DirectCast(Session("UsuarioLogeado"), Usuario)
            Dim comandoCrearBitacora As New ComandoCrearBitacora(Accion.Editar.ToString(), cliente.Id, DateTime.UtcNow, usuario.Nombre)
            _mediador.Send(comandoCrearBitacora)
            Return RedirectToAction("Index")
        End If
        Return View(cliente)
    End Function

End Class

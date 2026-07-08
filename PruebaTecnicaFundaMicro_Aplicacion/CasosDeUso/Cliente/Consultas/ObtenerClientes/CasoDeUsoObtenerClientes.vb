Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoObtenerClientes
    Implements IRequestHandler(Of ConsultaObtenerClientes, List(Of ClientesDetalleDTO))

    Private ReadOnly repositorio As IRepositorioCliente


    Public Sub New(repositorio As IRepositorioCliente)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ConsultaObtenerClientes) As Task(Of List(Of ClientesDetalleDTO)) Implements IRequestHandler(Of ConsultaObtenerClientes, List(Of ClientesDetalleDTO)).Handle
        Dim clientes As List(Of Cliente) = Me.repositorio.ObtenerTodos()
        Dim lista As New List(Of ClientesDetalleDTO)()

        For Each c As Cliente In clientes
            Dim clienteDto As New ClientesDetalleDTO(
                c.Id,
                c.Nombre,
                c.Telefono,
                c.Direccion
            )
            lista.Add(clienteDto)
        Next

        Return Task.FromResult(lista)
    End Function
End Class

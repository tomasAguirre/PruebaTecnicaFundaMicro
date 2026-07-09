Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class CasoDeUsoCrearCliente
    Implements IRequestHandler(Of ComandoCrearCliente, Integer)

    Private ReadOnly repositorio As IRepositorioCliente


    Public Sub New(repositorio As IRepositorioCliente)
        Me.repositorio = repositorio
    End Sub

    Public Function Handle(request As ComandoCrearCliente) As Task(Of Integer) Implements IRequestHandler(Of ComandoCrearCliente, Integer).Handle
        Dim id As Integer
        Try
            Dim cliente As New Cliente()
            cliente.Nombre = request.Nombre
            cliente.Telefono = request.Telefono
            cliente.Direccion = request.Direccion
            id = repositorio.Insertar(cliente)
            Return Task.FromResult(id)
        Catch ex As Exception
            Throw New Exception("Error al crear el cliente: " & ex.Message)
        End Try
    End Function
End Class

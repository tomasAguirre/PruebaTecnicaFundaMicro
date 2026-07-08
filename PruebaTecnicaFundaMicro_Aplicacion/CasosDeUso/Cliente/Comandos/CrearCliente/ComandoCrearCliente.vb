Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador

Public Class ComandoCrearCliente
    Implements IRequest(Of Integer)

    Private _nombre As String
    Private _telefono As String
    Private _direccion As String

    ' Constructor opcional
    Public Sub New(nombre As String, telefono As String, direccion As String)
        _nombre = nombre
        _telefono = telefono
        _direccion = direccion
    End Sub

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
End Class

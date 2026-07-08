Public Class ClientesDetalleDTO
    ' Campos privados
    Private _id As Integer
    Private _nombre As String
    Private _telefono As String
    Private _direccion As String

    ' Constructor opcional
    Public Sub New(id As Integer, nombre As String, telefono As String, direccion As String)
        _id = id
        _nombre = nombre
        _telefono = telefono
        _direccion = direccion
    End Sub

    ' Propiedades con Get y Set
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

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

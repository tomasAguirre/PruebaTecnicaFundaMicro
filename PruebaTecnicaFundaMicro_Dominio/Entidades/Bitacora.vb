Public Class Bitacora
    ' Campos privados
    Private _id As Integer
    Private _accionRealizada As String
    Private _idCliente As Integer
    Private _fecha As DateTime
    Private _nombreUsuario As String

    ' Constructor opcional
    Public Sub New(id As Integer, accionRealizada As String, idCliente As Integer, fecha As DateTime, nombreUsuario As String)
        _id = id
        _accionRealizada = accionRealizada
        _idCliente = idCliente
        _fecha = fecha
        _nombreUsuario = nombreUsuario
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

    Public Property AccionRealizada As String
        Get
            Return _accionRealizada
        End Get
        Set(value As String)
            _accionRealizada = value
        End Set
    End Property

    Public Property IdCliente As Integer
        Get
            Return _idCliente
        End Get
        Set(value As Integer)
            _idCliente = value
        End Set
    End Property

    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get
        Set(value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Property NombreUsuario As String
        Get
            Return _nombreUsuario
        End Get
        Set(value As String)
            _nombreUsuario = value
        End Set
    End Property
End Class


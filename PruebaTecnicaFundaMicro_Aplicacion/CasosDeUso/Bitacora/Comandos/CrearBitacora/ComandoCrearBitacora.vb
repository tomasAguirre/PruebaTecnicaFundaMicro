Imports System.Security.Cryptography
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador

Public Class ComandoCrearBitacora
    Implements IRequest(Of Integer)

    Private _accionRealizada As String
    Private _idCliente As Integer
    Private _fecha As DateTime
    Private _nombreUsuario As String

    Public Sub New(accionRealizada As String, idCliente As Integer, fecha As DateTime, nombreUsuario As String)
        _accionRealizada = accionRealizada
        _idCliente = idCliente
        _fecha = fecha
        _nombreUsuario = nombreUsuario
    End Sub

    Public Sub New()

    End Sub

    ' Propiedades con Get y Set

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

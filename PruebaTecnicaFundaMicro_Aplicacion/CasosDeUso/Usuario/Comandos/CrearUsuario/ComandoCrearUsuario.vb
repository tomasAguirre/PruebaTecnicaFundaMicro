Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador

Public Class ComandoCrearUsuario
    Implements IRequest(Of Integer)

    Private _nombre As String
    Private _password As String
    Private _correo As String

    Public Sub New(nombre As String, password As String, correo As String)
        _nombre = nombre
        _password = password
        _correo = correo
    End Sub

    Public Sub New()

    End Sub

    ' Propiedades con Get y Set

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
        End Set
    End Property
End Class

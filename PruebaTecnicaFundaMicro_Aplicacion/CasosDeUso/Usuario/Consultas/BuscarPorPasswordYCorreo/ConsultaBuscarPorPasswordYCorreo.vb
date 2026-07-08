Imports System.Security.Cryptography
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports PruebaTecnicaFundaMicro_Dominio

Public Class ConsultaBuscarPorPasswordYCorreo
    Implements IRequest(Of Usuario)

    Private _password As String
    Private _correo As String

    Public Sub New(password As String, correo As String)
        _password = password
        _correo = correo
    End Sub

    Public Sub New()

    End Sub

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

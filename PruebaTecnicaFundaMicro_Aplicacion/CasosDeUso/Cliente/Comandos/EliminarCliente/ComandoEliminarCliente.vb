Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador

Public Class ComandoEliminarCliente
    Implements IRequest(Of Boolean)
    Private _id As Integer

    Public Sub New(id As Integer)
        _id = id
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

End Class

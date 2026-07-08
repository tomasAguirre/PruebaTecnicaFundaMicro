Imports System

Namespace PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador

    Public Class ExcepcionDeMediador
        Inherits Exception

        Public Sub New(mensaje As String)
            MyBase.New(mensaje)
        End Sub

    End Class

End Namespace

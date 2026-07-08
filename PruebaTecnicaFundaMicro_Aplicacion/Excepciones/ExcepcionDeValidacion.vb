Imports System
Imports System.Collections.Generic
Imports FluentValidation.Results

Namespace PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador

    Public Class ExcepcionDeValidacion
        Inherits Exception

        Public Property ErroresDeValidacion As List(Of String)

        Public Sub New(mensajeError As String)
            MyBase.New(mensajeError)
            ErroresDeValidacion = New List(Of String)()
            Me.ErroresDeValidacion.Add(mensajeError)
        End Sub

        'Public Sub New(validationResult As ValidationResult)
        '    MyBase.New("Errores de validación encontrados")
        '    ErroresDeValidacion = New List(Of String)()

        '    For Each errorDeValidacion In validationResult.Errors
        '        Me.ErroresDeValidacion.Add(errorDeValidacion.ErrorMessage)
        '    Next
        'End Sub

    End Class

End Namespace

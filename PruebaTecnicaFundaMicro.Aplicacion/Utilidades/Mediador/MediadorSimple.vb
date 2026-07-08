Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Threading
Imports System.Threading.Tasks
Imports FluentValidation
Imports FluentValidation.Results
Imports ValidationResult = FluentValidation.Results.ValidationResult




Namespace PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador

    Public Class MediadorSimple
        Implements IMediator

        Public ReadOnly ServiceProvider As IServiceProvider

        Public Sub New(serviceProvider As IServiceProvider)
            Me.ServiceProvider = serviceProvider
        End Sub

        Public Async Function Send(Of TResponse)(request As IRequest(Of TResponse)) As Task(Of TResponse) _
            Implements IMediator.Send

            Await Me.RealizarValidaciones(request)

            Dim tipoCasoDeUso = GetType(IRequestHandler(Of ,)).MakeGenericType(request.GetType(), GetType(TResponse))
            Dim casoDeUso = Me.ServiceProvider.GetService(tipoCasoDeUso)

            If casoDeUso Is Nothing Then
                Throw New ExcepcionDeMediador($"No se encuentra un handler para {request.GetType().Name}")
            End If

            Dim metodo = tipoCasoDeUso.GetMethod("Handle")
            Return Await DirectCast(metodo.Invoke(casoDeUso, New Object() {request}), Task(Of TResponse))
        End Function

        Public Async Function Send(request As IRequest) As Task _
            Implements IMediator.Send

            Await Me.RealizarValidaciones(request)

            Dim tipoCasoDeUso = GetType(IRequestHandler(Of )).MakeGenericType(request.GetType())
            Dim casoDeUso = Me.ServiceProvider.GetService(tipoCasoDeUso)

            If casoDeUso Is Nothing Then
                Throw New ExcepcionDeMediador($"No se encontró un handler para {request.GetType().Name}")
            End If

            Dim metodo = tipoCasoDeUso.GetMethod("Handle")
            Await DirectCast(metodo.Invoke(casoDeUso, New Object() {request}), Task)
        End Function

        Private Async Function RealizarValidaciones(request As Object) As Task
            Dim tipoValidador = GetType(IValidator(Of )).MakeGenericType(request.GetType())
            Dim validador = Me.ServiceProvider.GetService(tipoValidador)

            If validador IsNot Nothing Then
                Dim metodoValidar = tipoValidador.GetMethod("ValidateAsync")
                Dim tareaValidar = DirectCast(metodoValidar.Invoke(validador, New Object() {request, CancellationToken.None}), Task)

                Await tareaValidar.ConfigureAwait(False)

                Dim resultadoProp = tareaValidar.GetType().GetProperty("Result")
                Dim validationResult = DirectCast(resultadoProp.GetValue(tareaValidar), ValidationResult)

                If Not validationResult.IsValid Then
                    Throw New ExcepcionDeValidacion(validationResult)
                End If
            End If
        End Function

    End Class

End Namespace

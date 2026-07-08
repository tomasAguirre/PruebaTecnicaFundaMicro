Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Threading
Imports System.Threading.Tasks
Imports FluentValidation
Imports FluentValidation.Results
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador
Imports ValidationResult = FluentValidation.Results.ValidationResult




Namespace PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador

    Public Class MediadorSimple
        Implements IMediator

        Private ReadOnly _handlers As New Dictionary(Of Type, Object)

        ' Registrar un handler manualmente
        Public Sub RegistrarHandler(Of TRequest, TResponse)(handler As IRequestHandler(Of TRequest, TResponse))
            _handlers(GetType(TRequest)) = handler
        End Sub

        ' no retorna nada 
        Public Async Function Send(request As IRequest) As Task Implements IMediator.Send
            Dim handlerObj As Object = Nothing
            If Not _handlers.TryGetValue(request.GetType(), handlerObj) Then
                Throw New ExcepcionDeMediador($"No se encontró un handler para {request.GetType().Name}")
            End If

            ' Obtener el método Handle desde el tipo real del handler
            Dim metodo = handlerObj.GetType().GetMethod("Handle")

            ' Invocar Handle sobre la instancia real
            Dim task = DirectCast(metodo.Invoke(handlerObj, New Object() {request}), Task)
            Await task
        End Function

        Public Function Send(Of TResponse)(request As IRequest(Of TResponse)) As Task(Of TResponse) Implements IMediator.Send
            ' Await RealizarValidaciones(request)

            Dim handlerObj As Object = Nothing
            If Not _handlers.TryGetValue(request.GetType(), handlerObj) Then
                Throw New ExcepcionDeMediador($"No se encontró handler para {request.GetType().Name}")
            End If

            ' Construir el tipo IRequestHandler<ConsultaObtenerClientes, List(Of ClientesDetalleDTO)>
            Dim tipoHandler = GetType(IRequestHandler(Of ,)).MakeGenericType(request.GetType(), GetType(TResponse))

            ' Buscar el método Handle
            Dim metodo = tipoHandler.GetMethod("Handle")

            ' Invocar Handle dinámicamente
            Dim resultado = metodo.Invoke(handlerObj, New Object() {request})

            Return DirectCast(resultado, Task(Of TResponse))
        End Function
    End Class
End Namespace

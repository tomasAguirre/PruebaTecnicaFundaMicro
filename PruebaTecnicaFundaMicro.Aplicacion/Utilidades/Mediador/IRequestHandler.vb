Imports System.Threading.Tasks

Namespace PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador

    ''' <summary>
    ''' Interfaz <c>IRequestHandler(Of TRequest, TResponse)</c> para casos de uso que retornan un valor
    ''' </summary>
    Public Interface IRequestHandler(Of TRequest, TResponse)
        Function Handle(request As TRequest) As Task(Of TResponse)
    End Interface

    ''' <summary>
    ''' Interfaz <c>IRequestHandler(Of TRequest)</c> para casos de uso que no retornan nada
    ''' </summary>
    Public Interface IRequestHandler(Of TRequest)
        Function Handle(request As TRequest) As Task
    End Interface

End Namespace
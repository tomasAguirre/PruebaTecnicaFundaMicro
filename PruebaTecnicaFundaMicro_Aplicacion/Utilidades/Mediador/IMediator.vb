Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro_Aplicacion.Utilidades.Mediador

Public Interface IMediator
    Function Send(Of TResponse)(request As IRequest(Of TResponse)) As Task(Of TResponse)
    Function Send(request As IRequest) As Task
End Interface

Imports PruebaTecnicaFundaMicro_Aplicacion
Imports PruebaTecnicaFundaMicro_Aplicacion.PruebaTecnicaFundaMicro.Aplicacion.Utilidades.Mediador
Public Class FactoryMediator
    Public Function ObtenerMediatorSimple() As MediadorSimple
        Return New MediadorSimple()
    End Function
End Class

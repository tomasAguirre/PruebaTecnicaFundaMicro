Imports PruebaTecnicaFundaMicro_Dominio

Public Interface IRepositorioUsuario
    Function ObtenerUsuarioPorCredenciales(password As String, correo As String) As Usuario
End Interface

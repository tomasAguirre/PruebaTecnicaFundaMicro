Imports PruebaTecnicaFundaMicro_Dominio

Public Interface IRepositorioUsuario
    Function ObtenerUsuarioPorCredenciales(password As String, correo As String) As Usuario

    Function InsertarUsuario(usuario As Usuario) As Integer
End Interface

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

@ModelType IEnumerable(Of PruebaTecnicaFundaMicro_Dominio.Bitacora)

<h2>Registro de Bitácoras</h2>

<table class="table table-striped">
    <thead>
        <tr>
            <th>Acción Realizada</th>
            <th>Id Cliente</th>
            <th>Fecha</th>
            <th>Nombre Usuario</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model
            @<tr>
                <td>@item.AccionRealizada</td>
                <td>@item.IdCliente</td>
                <td>@item.Fecha.ToString("dd/MM/yyyy HH:mm")</td>
                <td>@item.NombreUsuario</td>
            </tr>
        Next
    </tbody>
</table>

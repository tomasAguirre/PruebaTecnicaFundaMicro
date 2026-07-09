@Code
    ViewData("Title") = "Home Page"
End Code

<main>
    <div>
        @ModelType List(Of PruebaTecnicaFundaMicro_Aplicacion.ClientesDetalleDTO)

        <h2>Lista de Clientes</h2>

        <table class="table table-striped">
            <thead>
                <tr>
                    <th hidden>Id</th>
                    <th>Nombre</th>
                    <th>Email</th>
                    <th>Teléfono</th>
                </tr>
            </thead>
            <tbody>
                @For Each cliente In Model
                    @<tr>
    <td hidden>@cliente.Id</td>
    <td>@cliente.Nombre</td>
    <td>@cliente.Direccion</td>
    <td>@cliente.Telefono</td>
    <td>
        @Using Html.BeginForm("Eliminar", "Home", New With {.id = cliente.Id}, FormMethod.Post)
            @<text>
                <button type="submit" class="btn btn-danger" onclick="return confirm('¿Seguro que deseas eliminar este cliente?');">Eliminar</button>
            </text>
        End Using
    </td>

    <td>
        @Html.ActionLink("Editar", "Edit", New With {.id = cliente.Id}, New With {.class = "btn btn-warning"})
    </td>

</tr>
                Next
            </tbody>
        </table>

        <div>

            <h2>Crear Cliente</h2>
            <form method="post" id="myform" action="/Home/CrearCliente">
                <div class="form-group">
                    <label for="Nombre">Nombre del Cliente:</label>
                    <input type="text" id="Nombre" name="Nombre" class="form-control" required />
                </div>

                <div class="form-group">
                    <label for="Direccion">Dirección:</label>
                    <input type="text" id="Direccion" name="Direccion" class="form-control" required />
                </div>

                <div class="form-group">
                    <label for="Telefono">Teléfono:</label>
                    <input type="text" id="Telefono" name="Telefono" class="form-control" required />
                </div>

                <br />
                <button type="submit" class="btn btn-primary">Enviar y Guardar</button>
            </form>

        </div>
    </div>
    
</main>

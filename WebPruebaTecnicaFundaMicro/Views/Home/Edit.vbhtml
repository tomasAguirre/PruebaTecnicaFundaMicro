@ModelType PruebaTecnicaFundaMicro_Aplicacion.ClientesDetalleDTO

<h2>Editar Cliente</h2>

@Using Html.BeginForm("Edit", "Home", FormMethod.Post)
    @Html.HiddenFor(Function(m) m.Id)

    @<text>
        <div hidden class="form-group">
            @Html.LabelFor(Function(m) m.Id)
            @Html.TextBoxFor(Function(m) m.Id, New With {.class = "form-control"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Nombre)
            @Html.TextBoxFor(Function(m) m.Nombre, New With {.class = "form-control"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Direccion)
            @Html.TextBoxFor(Function(m) m.Direccion, New With {.class = "form-control"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Telefono)
            @Html.TextBoxFor(Function(m) m.Telefono, New With {.class = "form-control"})
        </div>

        <button type="submit" class="btn btn-primary">Actualizar</button>
    </text> End Using

<script type="text/javascript">
    window.onunload = function () {
        var idInput = document.getElementById("Id");
        if (idInput) {
            idInput.value = "";
        }
    };
</script>

@ModelType PruebaTecnicaFundaMicro_Dominio.Usuario

<h2>Crear Nuevo Usuario</h2>

@Using Html.BeginForm("Create", "Usuario", FormMethod.Post)
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

    @<text>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Nombre, "Nombre")
            @Html.TextBoxFor(Function(m) m.Nombre, New With {.class = "form-control", .required = "required", .maxlength = "100"})
            @Html.ValidationMessageFor(Function(m) m.Nombre, "", New With {.class = "text-danger"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Password, "Contraseña")
            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .required = "required", .minlength = "6"})
            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Correo, "Correo")
            @Html.TextBoxFor(Function(m) m.Correo, New With {.class = "form-control", .required = "required", .type = "email"})
            @Html.ValidationMessageFor(Function(m) m.Correo, "", New With {.class = "text-danger"})
        </div>

        <button type="submit" class="btn btn-primary">Guardar Usuario</button>
    </text> End Using

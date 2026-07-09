@ModelType PruebaTecnicaFundaMicro_Dominio.Usuario


@Code
    ViewData("Title") = "Login"
End Code

<h2>Login</h2>

@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

@Using Html.BeginForm("Logear", "Login", FormMethod.Post)
    @Html.AntiForgeryToken()

    @<text>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Correo)
            @Html.TextBoxFor(Function(m) m.Correo, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Correo)
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Password)
            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Password)
        </div>

        <div class="form-group">
            <button type="submit" class="btn btn-primary">Ingresar</button>
        </div>
    </text>
End Using

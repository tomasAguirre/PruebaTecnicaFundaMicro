Imports System.Web.Mvc

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        ' GET: Login
        Function Login() As ActionResult
            Return View()
        End Function


        ' POST: Login/Create
        <HttpPost()>
        Function Logear(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index", "Home")

            Catch
                Return View()
            End Try
        End Function

    End Class
End Namespace
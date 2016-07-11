Imports System.Data
Imports System
Imports DataConsulting.Scop.Security

Partial Class Login_frmLogin
    Inherits MyCustomPageClass  'System.Web.UI.Page

#Region "EVENTOS"
    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIngresar.Click
        Try
            DataConsulting.Scop.Security.DbContext.ProfileName = "ConnectionString"
            If Not CamposValidos() Then Exit Sub
            If DataConsulting.Scop.Security.Context.Login(txtUsuario.Text.Trim(), txtPassword.Text.Trim()) Then
                Session("UserInfo") = DataConsulting.Scop.Security.Context.User
                Response.Redirect("~/ModuleSecurity/frmPrincipal.aspx")
            Else
                Response.Write("<script language='javascript'>alert('" + "- Usted no es usuario del sistema" + "\n" + "o ingresó datos incorrectos." + "');</script>")
                'Page.ClientScript.RegisterStartupScript(Me.GetType(), "click", "alert('Login Successful');")
                'mjeInformacion.Text = "Usted no es usuario del sistema" + Environment.NewLine & "o ingresó datos incorrectos."
                'MsgBox("Usted no es usuario del sistema" + Environment.NewLine & "o ingresó datos incorrectos.")
                'MsgBox("Usted no es usuario del sistema" + Environment.NewLine & "o ingresó datos incorrectos.", Me.Page, Me)
                'myPageUtilities.Mensaje("Usted no es usuario del sistema" + Environment.NewLine & "o ingresó datos incorrectos.")
                'Response.Write("Usted no es usuario del sistema" + Environment.NewLine & "o ingresó datos incorrectos.")
            End If

        Catch ex As Exception
            'Response.Write("<script language='javascript'>alert('" + "Ha ocurrido un Problema\n\n" + "No se pudo Conectar correctamente con el servidor" + "');</script>")
            Response.Write("<script language='javascript'>alert('" + "Ha ocurrido un Problema\n\n" + ex.Message.ToString + "');</script>")
            'Response.Write("<script language='javascript'>alert('" + "- Usted no es usuario del sistema" + "\n" + "o ingresó datos incorrectos." + "');</script>")
            'Response.Write(ex.Message)
            'Session("msjError") = ex.Message.ToString()
            'Response.Redirect("frmError.aspx")
        End Try
    End Sub

    Private Function CamposValidos() As Boolean
        Dim mensaje As String = String.Empty
        If txtUsuario.Text = String.Empty Then
            mensaje += "- Ingrese su Usuario"
        End If

        If mensaje <> String.Empty Then
            'Dim hola As String = "<script>alert('" + "Ingrese su Usuario" + "');</script>"
            Response.Write("<script>alert('" + mensaje + "');</script>")
            Return False
        End If
        Return True
    End Function

#End Region
End Class

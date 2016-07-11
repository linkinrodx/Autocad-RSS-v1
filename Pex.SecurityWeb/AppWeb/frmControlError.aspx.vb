Imports System.Data
Imports System
Imports DataConsulting.Scop.Security

Partial Class frmControlError
    Inherits MyCustomPageClass

#Region "EVENTOS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'msjError.Text = CStr(Session("msjError"))
            msjError.Text = "Puede que la página solicitada ya no exista, haya cambiado de nombre o no esté disponible temporalmente."
        End If
    End Sub
#End Region

    Protected Sub lnkVolver_Click(sender As Object, e As EventArgs) Handles lnkVolver.Click
        Try
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()

            Dim sRutaPagina As String = Request.AppRelativeCurrentExecutionFilePath
            Dim sArregloRutaPagina As String() = sRutaPagina.Split("/")
            Dim nNroSlashPag As Integer = sArregloRutaPagina.Length - 1

            Dim nContadorx As Integer
            Dim sRutaAlert As String = ""
            For nContadorx = 1 To nNroSlashPag - 1 Step 1
                sRutaAlert = sRutaAlert & "../"
            Next nContadorx
            Response.Redirect(sRutaAlert & "frmLogin.aspx")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class

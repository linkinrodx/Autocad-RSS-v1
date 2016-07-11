
Partial Class SECGEN_RJF_wucTab
    Inherits System.Web.UI.UserControl

    Private booActivado As Boolean = False
    Private strTexto As String = ""
    Private strPagina As String = ""

    Public Property activado() As Boolean
        Get
            Return booActivado
        End Get
        Set(ByVal Value As Boolean)
            booActivado = Value
        End Set
    End Property

    Public Property texto() As String
        Get
            Return strTexto
        End Get
        Set(ByVal Value As String)
            strTexto = Value
        End Set
    End Property

    Public Property pagina() As String
        Get
            Return strPagina
        End Get
        Set(ByVal Value As String)
            strPagina = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If booActivado Then
            TabActivado.Visible = True
            TabDesactivado.Visible = False

            LblTexto.Text = strTexto
        Else
            TabActivado.Visible = False
            TabDesactivado.Visible = True

            HlnkPagina.Text = strTexto
            HlnkPagina.NavigateUrl = strPagina + ".aspx"
        End If

    End Sub

End Class

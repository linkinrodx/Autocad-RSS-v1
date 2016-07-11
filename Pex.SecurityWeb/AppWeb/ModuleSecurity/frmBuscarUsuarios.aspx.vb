Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Forms
Imports DataConsulting.Scop.Security
Imports System.Diagnostics
Partial Class SECGEN_TD_frmBuscarUsuarios
    Inherits MyCustomPageClass 'System.Web.UI.Page

#Region "Variables del Formulario"
    Dim moEntity As New UserBE
    Dim moPrincipals As IList(Of PrincipalBE)
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not Page.IsPostBack Then
            'Configuracion del grid del Formulario
            gvwDocsReferenciados.AllowPaging = True
            gvwDocsReferenciados.PageSize = 10
            gvwDocsReferenciados.PagerSettings.Mode = PagerButtons.Numeric
            gvwDocsReferenciados.PagerStyle.Font.Bold = True

            Session("TrabajadorTrama") = Nothing
            Try
                Dim NumRegs As Integer
                gvwDocsReferenciados.PageIndex = 0
                Dim dtResult = PrincipalBR.SelectByCriterio(String.Empty, 1)
                Dim td = ConvertToDataTable(dtResult)
                gvwDocsReferenciados.DataSource = td
                gvwDocsReferenciados.DataBind()

                NumRegs = CInt(dtResult.Count)
                LblCountReg.Text = "Se encontraron : " + CStr(NumRegs) + " Registros"
                Me.LblPagina.Text = "Nro de Pagina Actual : " + (Me.gvwDocsReferenciados.PageIndex + 1).ToString '<--
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Protected Sub btnNuevoServicio_Click(sender As Object, e As EventArgs) Handles btnNuevoServicio.Click
        Try
            Session("PrincipalId") = Nothing
            Session("MasterPage") = "~/Master/MasterPage.master"
            Response.Redirect("frmRegistrarUsuarios.aspx")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnBuscarTrabajadorBus_Click(sender As Object, e As ImageClickEventArgs) Handles btnBuscarTrabajadorBus.Click
        Buscar()
    End Sub

    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim td As New DataTable
        Dim entityType As Type = GetType(T)
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(entityType)
        For Each prop As PropertyDescriptor In properties
            td.Columns.Add(prop.Name)
        Next
        For Each item As T In list
            Dim row As DataRow = td.NewRow()

            For Each prop As PropertyDescriptor In properties
                row(prop.Name) = prop.GetValue(item)
            Next

            td.Rows.Add(row)
        Next
        Return td
    End Function
#End Region

#Region "Metodos"
    Private Sub Buscar()
        Try
            Dim NumRegs As Integer
            Dim Name = txtTrabajadorBus.Text.Trim
            Dim list = PrincipalBR.SelectByCriterio(Name, 1)
            Dim dt = ConvertToDataTable(list)
            gvwDocsReferenciados.DataSource = dt
            gvwDocsReferenciados.DataBind()
            NumRegs = CInt(list.Count)
            LblCountReg.Text = "Se encontraron : " + CStr(NumRegs) + " Registros"
            'Me.LblPagina.Text = "Nro de Pagina Actual : " + (Me.gvwDocsReferenciados.PageIndex + 1).ToString '<--
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitializeData()
        btnBuscarTrabajadorBus.Attributes.Add("onclick", "AbreModal('" & "PopUpBuscarGrupo.aspx" & "','600px','350px');")

        'Configuracion del grid del formulario
        gvwDocsReferenciados.AllowPaging = True
        gvwDocsReferenciados.PageSize = 10
        gvwDocsReferenciados.PagerSettings.Mode = PagerButtons.Numeric
        gvwDocsReferenciados.PagerStyle.Font.Bold = True

        Try
            Dim dtResult = PrincipalBR.SelectByCriterio(String.Empty, 1)
            Dim td = ConvertToDataTable(dtResult)
            gvwDocsReferenciados.DataSource = td
            gvwDocsReferenciados.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Grilla"
    Protected Sub gvwDocsReferenciados_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.gvwDocsReferenciados.PageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Protected Sub gvwDocsReferenciados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.LblPagina.Text = "Nro de Pagina Actual : " + (e.NewPageIndex + 1).ToString '<--
    End Sub

    Protected Sub gvwDocsReferenciados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvwDocsReferenciados.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim btnSel As ImageButton = DirectCast(e.Row.FindControl("btnSeleccionar"), ImageButton)
            btnSel.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub

    Protected Sub gvwDocsReferenciados_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwDocsReferenciados.RowCommand
        Try
            If e.CommandName = "Seleccionar" Then
                Dim fila As Integer = CType(e.CommandArgument, Integer)
                Dim NroDocumento = gvwDocsReferenciados.Rows.Item(fila).Cells(1).Text.Split("-")
                Session("PrincipalId") = NroDocumento(0)
                Session("MasterPage") = "~/Master/MasterPage.master"
                Response.Redirect("frmRegistrarUsuarios.aspx")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class

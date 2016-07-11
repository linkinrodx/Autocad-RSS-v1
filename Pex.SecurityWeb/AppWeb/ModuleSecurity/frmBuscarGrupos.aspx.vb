Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Forms
Imports DataConsulting.Scop.Security
Imports System.Diagnostics
Partial Class SECGEN_TD_frmBuscarGrupos
    Inherits MyCustomPageClass 'System.Web.UI.Page

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not Page.IsPostBack Then
            Session.Add("Name", String.Empty)
            Session.Add("OrganizationalUnitId", 0)

            'Configuracion del grid del formulario
            gvwDocsReferenciados.AllowPaging = True
            gvwDocsReferenciados.PageSize = 10
            gvwDocsReferenciados.PagerSettings.Mode = PagerButtons.Numeric
            gvwDocsReferenciados.PagerStyle.Font.Bold = True
            Try
                Dim dtResult = OrganizationalUnitBR.Select()
                Dim td = ConvertToDataTable(dtResult)
                gvwDocsReferenciados.DataSource = td
                gvwDocsReferenciados.DataBind()
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub


    Protected Sub btnNuevoServicio_Click(sender As Object, e As EventArgs) Handles btnNuevoServicio.Click
        Try
            Session("OrganizationalUnitId") = Nothing
            Session("MasterPage") = "~/Master/MasterPage.master"
            Response.Redirect("frmRegistrarGrupos.aspx")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub gvwDocsReferenciados_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.gvwDocsReferenciados.PageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Protected Sub gvwDocsReferenciados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.LblPagina.Text = "Nro de Página Actual : " + (e.NewPageIndex + 1).ToString '<--
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
                Session("OrganizationalUnitId") = NroDocumento(0)
                Session("MasterPage") = "~/Master/MasterPage.master"
                Response.Redirect("frmRegistrarGrupos.aspx")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnBuscarTrabajadorBus_Click(sender As Object, e As ImageClickEventArgs) Handles btnBuscarTrabajadorBus.Click
        Buscar()
    End Sub
#End Region

#Region "Métodos"
    Private Sub Buscar()
        Try
            Dim NumRegs As Integer
            'gvwDocsReferenciados.PageIndex = 0
            Dim Name = txtTrabajadorBus.Text.Trim
            Dim list = OrganizationalUnitBR.SelectByName(Name)

            If txtTrabajadorBus.Text = String.Empty Then
                gvwDocsReferenciados.DataSource = list
                gvwDocsReferenciados.DataBind()
            Else
                Dim dt = ConvertToDataTable(List)
                gvwDocsReferenciados.DataSource = dt
                gvwDocsReferenciados.DataBind()
            End If
            NumRegs = CInt(list.Count)
            LblCountReg.Text = "Se encontraron : " + CStr(NumRegs) + " Registros"
            Me.LblPagina.Text = "Nro de Pagina Actual : " + (Me.gvwDocsReferenciados.PageIndex + 1).ToString '<--
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CamposValidos() As Boolean
        Dim errMsg As String = String.Empty
        Dim OrganizationUnitName = txtTrabajadorBus.Text.Trim

        If errMsg <> String.Empty Then
            ClientScript.RegisterStartupScript(Me.GetType(), "Message", "alert('" & errMsg & "');", True)
        End If

        Return errMsg = String.Empty
    End Function

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
End Class

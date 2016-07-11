Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports DataConsulting.Scop.Security
Imports System.Diagnostics
Imports System.IO

Partial Class SECGEN_TD_frmRegistrarRoles
    Inherits MyCustomPageClass

#Region "Declarar Variabble"
    'Dim moEntity As New RoleBE
    Dim moEntity = New RoleBE
    'Dim moPrincipals As IList(Of PrincipalBE)
    'Dim moRoles As IDictionary(Of Integer, RoleSelection1)
    'Dim moRoleList As IList(Of RoleSelection1)
    Dim moPoliticList As IList(Of PoliticSelection1)
    'Dim InsUpdPoliticGrant = New List(Of PoliticBE)
#End Region

#Region "Propiedades"
    Private ReadOnly Property IsFormOnInserting() As Boolean
        Get
            Return Session("PrincipalId") Is Nothing
        End Get
    End Property

    Private ReadOnly Property IsFormOnUpdating() As Boolean
        Get
            Return Session("PrincipalId") IsNot Nothing
        End Get
    End Property

    Private Sub HabilitarAtencion(ByVal enabled As Boolean)
        txtNombreRol.Enabled = enabled
        txtDescripcion.Enabled = enabled
        cboGrupos.Enabled = enabled
        chkEnabled.Enabled = enabled
        GrillaEnabled(Not enabled)
        HabilitarBotones(enabled)
    End Sub

    Private Sub HabilitarBotones(ByVal flagEdit As Boolean)
        btnModificar.Visible = Not flagEdit AndAlso IsFormOnUpdating
        btnGrabar.Visible = flagEdit OrElse IsFormOnInserting
        btnCancelar.Visible = flagEdit
        btnBuscar.Visible = Not flagEdit
        btnGrabarPoliticas.Visible = Not flagEdit
        rbtGranted.Enabled = Not flagEdit
        rbtNoGranted.Enabled = Not flagEdit
    End Sub

    Private Sub GrillaEnabled(ByVal flagEdit As Boolean)
        gvwDocsReferenciados.Enabled = flagEdit AndAlso IsFormOnUpdating
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

    Private Sub UpdatePolitics(principal As PrincipalBE)
        Dim politics As IList(Of PoliticBE) = If(rbtGranted.Checked, principal.PoliticGrants, principal.PoliticPendingGrants)
        moPoliticList = New List(Of PoliticSelection1)(politics.Count)
        For Each politic As PoliticBE In politics
            moPoliticList.Add(New PoliticSelection1(politic, rbtGranted.Checked))
        Next
        Dim td = ConvertToDataTable(moPoliticList)
        gvwDocsReferenciados.DataSource = td
        gvwDocsReferenciados.DataBind()
    End Sub

    Private Sub UpdateDetail(Principal As RoleBE)
        'txtNombreRol.Text = Principal.Name
        'cboGrupos.SelectedValue = Principal.OrganizationalUnitId
        'chkEnabled.Enabled = Principal.Enabled
        'UpdatePolitics(Principal)
    End Sub

    Private Sub CargarAtencion(moEntity As RoleBE)
        'Try
        '    Session("PrincipalId") = moEntity.PrincipalId
        '    txtNombreRol.Text = moEntity.Name
        '    txtDescripcion.Text = moEntity.Description
        '    cboGrupos.SelectedValue = moEntity.OrganizationalUnitId
        '    chkEnabled.Checked = moEntity.Enabled
        '    gvwDocsReferenciados.DataSource = moEntity.PoliticGrants
        '    gvwDocsReferenciados.DataBind()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
#End Region

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Configuracion del grid del Formulario
            gvwDocsReferenciados.AllowPaging = True
            gvwDocsReferenciados.PageSize = 50
            gvwDocsReferenciados.PagerSettings.Mode = PagerButtons.Numeric
            gvwDocsReferenciados.PagerStyle.Font.Bold = True
            gvwDocsReferenciados.PageIndex = 0
            'Oculta/Muestra las otras fichas del documento.
            If Not Page.IsPostBack Then
                InitializeData()
                'Valida si existe documento para ser cargado
                If Session("PrincipalId") IsNot Nothing Then
                    ''''''''''''''''Carga de Datos Inicial''''''''''''''''''''
                    CargarRoles(Session("PrincipalId"))
                    HabilitarAtencion(False)
                Else 'NUEVO
                    'Se trata de nuevo ingreso. Carga datos en variable de Sesion principal "Documento"
                    HabilitarAtencion(True)
                End If
            End If
            'Limpiamos mensajes
            'mjeExito.Text = String.Empty
            'mjeInformacion.Text = String.Empty
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs)
        Grabar()
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        HabilitarAtencion(True)
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("frmBuscarRoles.aspx")
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If IsFormOnInserting Then
            LimpiarFormulario()
        ElseIf IsFormOnUpdating Then
            CargarRoles(Session("PrincipalId"))
            HabilitarAtencion(False)
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If IsFormOnUpdating Then moEntity = PrincipalBR.SelectByRole(Session("PrincipalId"))

        Dim principal = TryCast(moEntity, RoleBE)
        UpdatePolitics(principal)
    End Sub
#End Region

#Region "Métodos"
    Private Sub InitializeData()
        Try
            CargarCboGrupo()
            LimpiarFormulario()
            rbtGranted.Checked = True
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarFormulario()
        Try
            moEntity = New RoleBE
            txtNombreRol.Text = String.Empty
            txtDescripcion.Text = String.Empty
            cboGrupos.SelectedIndex = -1
            chkEnabled.Checked = True
        Catch ex As Exception
            'UIFunctions.ShowErrorMessage("Se presentó problemas al limpiar el formulario.", ex)
        End Try
    End Sub

    Private Function CargarRoles(ByVal PrincipalId As Integer) As Boolean
        Try
            moEntity = PrincipalBR.SelectByRole(PrincipalId)
            Dim principal = TryCast(moEntity, RoleBE)
            txtNombreRol.Text = principal.Name
            txtDescripcion.Text = principal.Description
            cboGrupos.SelectedValue = principal.OrganizationalUnitId
            chkEnabled.Checked = principal.Enabled
            Session("PrincipalId") = principal.PrincipalId
            UpdatePolitics(principal)
            Return True
        Catch ex As Exception
            LimpiarFormulario()
            Return False
        End Try
    End Function

    Private Sub CargarCboGrupo()
        Try
            Dim groups As IList(Of OrganizationalUnitBE) = OrganizationalUnitBR.Select()
            cboGrupos.DataSource = groups
            cboGrupos.DataValueField = "OrganizationalUnitId"
            cboGrupos.DataTextField = "Name"
            cboGrupos.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub Grabar() 'falta
        Try
            If CamposValidos() Then
                LlenarEntidad()
                If IsFormOnInserting Then
                    PrincipalBR.Insert(DirectCast(moEntity, PrincipalBE))
                    UpdatePolitics(DirectCast(moEntity, PrincipalBE))
                ElseIf IsFormOnUpdating Then
                    PrincipalBR.Update(DirectCast(moEntity, PrincipalBE))
                End If
                'PrincipalBR.UpdateGrants(DirectCast(moEntity, PrincipalBE), DirectCast(moEntity, PrincipalBE).InsUpdPoliticGrant, Not rbtGranted.Checked)
                Session("PrincipalId") = moEntity.PrincipalId
                Response.Write("<script language='javascript'>alert('" + "Operaci\u00f3n Exitosa" + "');</script>")
                CargarRoles(moEntity.PrincipalId)
                HabilitarAtencion(False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CamposValidos() As Boolean
        Dim errMsg As String = String.Empty

        If txtNombreRol.Text = String.Empty Then
            errMsg += "- No ha colocado el Nombre del Rol\n"
        End If

        If cboGrupos.SelectedIndex = -1 Then
            errMsg += "- No ha seleccionado un Grupo\n"
        End If

        If errMsg <> String.Empty Then
            'Response.Write(errMsg)
            Response.Write("<script>alert('" + errMsg + "');</script>")
        End If

        Return errMsg = String.Empty
    End Function

    Private Sub LlenarEntidad() 'falta
        Try
            If IsFormOnInserting Then
                Dim principal = TryCast(moEntity, RoleBE)
                principal.Name = txtNombreRol.Text
                Dim grupos As New OrganizationalUnitBE
                grupos.OrganizationalUnitId = CInt(cboGrupos.SelectedValue)
                principal.OrganizationalUnit = grupos
                principal.Enabled = chkEnabled.Checked
                principal.Description = txtDescripcion.Text

            ElseIf IsFormOnUpdating Then
                moEntity = PrincipalBR.SelectByRole(Session("PrincipalId"))
                Dim principal = TryCast(moEntity, RoleBE)
                principal.Name = txtNombreRol.Text
                Dim grupos As New OrganizationalUnitBE
                grupos.OrganizationalUnitId = CInt(cboGrupos.SelectedValue)
                principal.OrganizationalUnit = grupos
                principal.Enabled = chkEnabled.Checked
                principal.Description = txtDescripcion.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnGrabarPoliticas_Click(sender As Object, e As EventArgs) Handles btnGrabarPoliticas.Click
        LlenarDetalle()
        Dim selectedPolitics As IList(Of PoliticBE) = (From politic In moPoliticList Where (rbtGranted.Checked AndAlso Not politic.Selected) OrElse (Not rbtGranted.Checked AndAlso politic.Selected) Select politic.Politic).ToList()
        If selectedPolitics.Count > 0 Then
            PrincipalBR.UpdateGrants(DirectCast(moEntity, PrincipalBE), selectedPolitics, Not rbtGranted.Checked)
        Else
            'MessageBox.Show("No ha realizado cambios en las asignaciones de políticas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        moEntity = PrincipalBR.SelectByRole(Session("PrincipalId"))
        Dim principal = TryCast(moEntity, RoleBE)
        UpdatePolitics(principal)
    End Sub

    Private Sub LlenarDetalle()
        Try
            If IsFormOnUpdating Then moEntity = PrincipalBR.SelectByRole(Session("PrincipalId"))

            Dim principal = TryCast(moEntity, RoleBE)
            Dim politics As IList(Of PoliticBE) = If(rbtGranted.Checked, principal.PoliticGrants, principal.PoliticPendingGrants)
            moPoliticList = New List(Of PoliticSelection1)(politics.Count)
            For Each politic As PoliticBE In politics
                moPoliticList.Add(New PoliticSelection1(politic, rbtGranted.Checked))
            Next
            'Llenando campos seleccionados de la grilla
            Dim EsActivo = True
            Dim IdPol As Integer
            For Each row As GridViewRow In gvwDocsReferenciados.Rows
                IdPol = CInt(row.Cells(1).Text)
                EsActivo = CType(row.FindControl("chkEsActivo"), CheckBox).Checked
                Dim politic = moPoliticList.Where(Function(o) o.PoliticId = IdPol).FirstOrDefault()
                politic.Selected = EsActivo
            Next
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Private Sub BuscarGrilla()
        Try
            Dim NumRegs As Integer

            'moEntity = PrincipalBR.SelectByRole(Session("PrincipalId"))
            'Dim principal = TryCast(moEntity, RoleBE)
            UpdatePolitics(moEntity)
            NumRegs = CInt(moPoliticList.Count)

            'Me.LblPagina.Text = "Nro de Pagina Actual : " + (Me.gvwDocsReferenciados.PageIndex + 1).ToString '<--
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Grilla"
    Protected Sub gvwDocsReferenciados_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.gvwDocsReferenciados.PageIndex = e.NewPageIndex
        BuscarGrilla()
    End Sub

    Protected Sub gvwDocsReferenciados_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.LblPagina.Text = "Nro de Pagina Actual : " + (e.NewPageIndex + 1).ToString '<--
    End Sub

    Protected Sub gvwDocsReferenciados_DataBound(sender As Object, ex As EventArgs) Handles gvwDocsReferenciados.DataBound
        For Each e As GridViewRow In gvwDocsReferenciados.Rows
            If (e.RowType = DataControlRowType.DataRow) Then
                Dim NroDocumento = gvwDocsReferenciados.Rows.Item(e.RowIndex).Cells(1).Text.Split("-")
                Dim Poli = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticId = Convert.ToInt32(NroDocumento(0))).FirstOrDefault()

                If Poli IsNot Nothing AndAlso Poli.PoliticParentId = 0 Then
                    e.Font.Size = 9
                    e.Font.Bold = True
                End If
            End If
        Next
    End Sub

    Protected Sub gvwDocsReferenciados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvwDocsReferenciados.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim chkSel As CheckBox = DirectCast(e.Row.FindControl("chkEsActivo"), CheckBox)
            chkSel.ToolTip = e.Row.RowIndex.ToString
        End If
    End Sub

    Protected Sub chkEnabled_CheckedChanged(sender As Object, e As EventArgs)
        Dim check As CheckBox = CType(sender, CheckBox)
        Dim NroDocumento = gvwDocsReferenciados.Rows.Item(CInt(check.ToolTip)).Cells(1).Text.Split("-")

        'Busca la política seleccionada
        Dim PoliSelected = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticId = Convert.ToInt32(NroDocumento(0))).FirstOrDefault()

        If PoliSelected.PoliticParentId = 0 Then
            'Busca las politicas hijas
            Dim Hijas = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticParentId = PoliSelected.PoliticId AndAlso o.Enabled = True)

            If Hijas IsNot Nothing AndAlso Hijas.ToList().Count > 0 Then
                For Each x As GridViewRow In gvwDocsReferenciados.Rows
                    Dim respuesta = Hijas.Where(Function(o) o.PoliticId = CInt(gvwDocsReferenciados.Rows.Item(x.RowIndex).Cells(1).Text.Split("-").FirstOrDefault())).FirstOrDefault

                    If respuesta IsNot Nothing Then
                        CType(x.FindControl("chkEsActivo"), CheckBox).Checked = check.Checked
                    End If
                Next
            End If
        ElseIf check.Checked = True Then
            'Busca la politica padre
            Dim Padre = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticId = PoliSelected.PoliticParentId AndAlso o.Enabled = True).FirstOrDefault()

            If Padre IsNot Nothing Then
                For Each x As GridViewRow In gvwDocsReferenciados.Rows
                    'Buscamos la fila
                    Dim i = CInt(gvwDocsReferenciados.Rows.Item(x.RowIndex).Cells(1).Text.Split("-").FirstOrDefault())

                    If Padre.PoliticId = i Then
                        CType(x.FindControl("chkEsActivo"), CheckBox).Checked = True
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub
#End Region
End Class
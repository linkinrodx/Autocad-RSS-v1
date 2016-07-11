Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports DataConsulting.Scop.Security
Imports System.Diagnostics

Partial Class SECGEN_TD_frmRegistroUsuarios
    Inherits MyCustomPageClass

#Region "Declarar Variables"
    Dim moEntityRoles As New UserBE
    Dim moEntityPolitics As New RoleBE
    Dim moPrincipals As IList(Of PrincipalBE)
    Dim moRoles As IDictionary(Of Integer, RoleSelection1)
    Dim moRoleList As IList(Of RoleSelection1)
    Dim moPoliticList As IList(Of PoliticSelection1)
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
#End Region

#Region "Iniciar"
    Private Sub InitializeData()
        Try
            CargarCboGrupo()
            CargarCboTrabajado()
            'Dim id = CInt(Session("PrincipalId"))
            moPrincipals = PrincipalBR.Select()
            Dim roles = (From principal In moPrincipals Where principal.PrincipalType = EPrincipalType.Role Select principal)
            moRoles = New Dictionary(Of Integer, RoleSelection1)()
            For Each role As PrincipalBE In roles
                moRoles.Add(role.PrincipalId, New RoleSelection1(role))
            Next
            rbtAsignado.Checked = True
            chkEnabled.Checked = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

    Private Sub CargarCboTrabajado()
        Try
            Dim Trabajador As DataTable
            Trabajador = TrabajadorReferenceBR.GetTrabajadorReference(0, String.Empty)

            cboReference.DataSource = Trabajador
            cboReference.DataValueField = "IdTrabajador"
            cboReference.DataTextField = "Nombres"
            cboReference.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HabilitarAtencion(ByVal enabled As Boolean)
        txtNombreRol.Enabled = enabled
        cboGrupos.Enabled = enabled
        chkEnabled.Enabled = enabled
        cboReference.Enabled = enabled
        txtPassword.Enabled = enabled
        txtPassword2.Enabled = enabled
        gvwDocsReferenciados.Enabled = Not enabled AndAlso IsFormOnUpdating
        gvwDocsReferenciados2.Enabled = Not enabled AndAlso IsFormOnUpdating
        HabilitarBotones(enabled)
    End Sub

    Private Sub HabilitarBotones(ByVal flagEdit As Boolean)
        btnModificar.Visible = Not flagEdit AndAlso IsFormOnUpdating
        btnGrabar.Visible = flagEdit OrElse IsFormOnInserting
        btnCancelar.Visible = flagEdit
        btnAsignarRoles.Visible = Not flagEdit
        btnBuscarPoliticas.Visible = Not flagEdit
        btnGrabarPoliticas.Visible = Not flagEdit
        rbtAsignado.Visible = Not flagEdit
        rbtNoAsignado.Visible = Not flagEdit
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

    Private Function CamposValidos() As Boolean
        Dim errMsg As String = String.Empty

        If txtNombreRol.Text = String.Empty Then
            errMsg &= "- No ha colocado el Nombre del Usuario\n"
        End If

        If cboReference.SelectedIndex = -1 Then
            errMsg &= "- No ha seleccionado un Trabajador\n"
        End If

        If cboGrupos.SelectedIndex = -1 Then
            errMsg &= "- No ha seleccionado un Grupo\n"
        End If

        If txtPassword.Text = String.Empty Then
            errMsg &= "- Ingrese una contrase\u00f1a para el Usuario\n"
        End If

        If txtPassword2.Text = String.Empty Then
            errMsg &= "- Ingrese la contrase\u00f1a de confirmaci\u00f3n para el Usuario\n"
        Else
            If txtPassword.Text <> txtPassword2.Text Then
                errMsg &= "- La contrase\u00f1a de confirmaci\u00f3n debe de coincidir la contrase\u00f1a principal\n"
            End If
        End If

        If errMsg <> String.Empty Then
            'Response.Write(errMsg)
            Response.Write("<script language='javascript'>alert('" + errMsg + "');</script>")
        End If

        Return errMsg = String.Empty
    End Function

    Private Sub Grabar()
        Try
            If CamposValidos() Then
                LlenarEntidad()
                If IsFormOnInserting Then
                    PrincipalBR.Insert(DirectCast(moEntityRoles, PrincipalBE))
                    'PrincipalBR.Insert(DirectCast(moEntityPolitics, PrincipalBE))
                    'UpdateRolesNew(DirectCast(moEntityRoles, PrincipalBE))
                    'UpdatePolitics(DirectCast(moEntityPolitics, PrincipalBE))
                ElseIf IsFormOnUpdating Then
                    'LlenarEntidad()
                    PrincipalBR.Update(DirectCast(moEntityRoles, PrincipalBE))
                End If
                Session("PrincipalId") = moEntityRoles.PrincipalId
                Response.Write("<script language='javascript'>alert('" + "Operaci\u00f3n Exitosa" + "');</script>")
                CargarUsuario(moEntityRoles.PrincipalId)
                HabilitarAtencion(False)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LlenarEntidad()
        Try
            If IsFormOnInserting Then
                'Dim principalpolitic = TryCast(moEntityPolitics, RoleBE)
                'principalpolitic.Name = txtNombreRol.Text

                Dim principal = TryCast(moEntityRoles, UserBE)
                principal.Name = txtNombreRol.Text
                Dim grupos As New OrganizationalUnitBE
                grupos.OrganizationalUnitId = CInt(cboGrupos.SelectedValue)
                principal.OrganizationalUnit = grupos
                principal.ReferenceId = CInt(cboReference.SelectedValue)
                principal.Enabled = chkEnabled.Checked
                principal.Password = txtPassword.Text
            ElseIf IsFormOnUpdating Then
                moEntityRoles = PrincipalBR.SelectByUser(Session("PrincipalId"))
                Dim principal = TryCast(moEntityRoles, UserBE)
                principal.Name = txtNombreRol.Text
                Dim grupos As New OrganizationalUnitBE
                grupos.OrganizationalUnitId = CInt(cboGrupos.SelectedValue)
                principal.OrganizationalUnit = grupos
                principal.ReferenceId = CInt(cboReference.SelectedValue)
                principal.Enabled = chkEnabled.Checked
                principal.Password = txtPassword.Text
            End If
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Private Sub CargarAtencion(moEntityRoles As UserBE)
        ''Session("OrganizationalUnitId") = moEntity.OrganizationalUnitId
        'txtNombreRol.Text = moEntityRoles.Name
        'cboGrupos.SelectedValue = moEntityRoles.OrganizationalUnitId
        'cboReference.SelectedValue = moEntityRoles.ReferenceId
        'chkEnabled.Enabled = moEntityRoles.Enabled
        'txtPassword.Text = moEntityRoles.Password
        'txtPassword2.Text = moEntityRoles.Password
        ''CargarTrabajadores(atencion)
    End Sub

    Private Function CargarRoles(ByVal PrincipalId As Integer) As Boolean
        'Try
        '    Dim moEntityRoles = PrincipalBR.GetPrincipalAll(PrincipalId)
        '    Dim principal = TryCast(moEntityRoles, UserBE)
        '    'Dim entityrole As Object
        '    'entityrole = PrincipalBR.SelectLinkByUser(Session("PrincipalId"))

        '    txtNombreRol.Text = principal.Name
        '    txtPassword.Text = principal.Password
        '    txtPassword2.Text = principal.Password
        '    cboGrupos.SelectedValue = principal.OrganizationalUnitId
        '    cboReference.SelectedValue = principal.ReferenceId
        '    chkEnabled.Checked = principal.Enabled
        '    UpdateRolesNew(principal)
        '    Return True
        'Catch ex As Exception
        '    Throw ex
        '    'Msg(ex.CargarRoles)
        'End Try
    End Function

    Private Function CargarPoliticas(ByVal PrincipalId As Integer) As Boolean
        'Try
        '    moEntityPolitics = PrincipalBR.SelectByRole(PrincipalId)
        '    Dim principal = TryCast(moEntityPolitics, RoleBE)
        '    'Session("PrincipalId") = principal.PrincipalId
        '    rbtAsignado.Checked = True
        '    'UpdatePolitics(principal)

        '    Return True
        'Catch ex As Exception
        '    Throw ex
        '    'Msg(ex.CargarPoliticas)
        'End Try
    End Function

    Private Sub UpdateDetail(Principal As UserBE)
        'txtNombreRol.Text = Principal.Name
        'cboGrupos.SelectedValue = Principal.OrganizationalUnitId
        'chkEnabled.Enabled = Principal.Enabled
        'cboReference.SelectedValue = Principal.ReferenceId
        'txtPassword.Text = DirectCast(Principal, UserBE).PasswordDecrypt
        'txtPassword2.Text = Principal.Password
        ''UpdatePolitics(Principal)
        'UpdateRoles(Principal)
    End Sub

    Private Sub UpdateRoles(User As UserBE)
        ''Dim roles = PrincipalBR.SelectLinkByUser(Session("PrincipalId"))
        'For Each role As RoleSelection In moRoles.Values
        '    role.Selected = False
        'Next
        'For Each role As PrincipalBE In User.Principals
        '    moRoles(role.PrincipalId).Selected = True
        'Next
        'moRoleList = (From role In moRoles.Values Order By role.Selected Descending, If(role.Principal.OrganizationalUnitId = User.OrganizationalUnitId, 0, 1), role.OrganizationalUnit, role.PrincipalName Select role).ToList()
        'Dim td = ConvertToDataTable(moRoleList)
        'gvwDocsReferenciados.DataSource = td
        'gvwDocsReferenciados.DataBind()
        'rbtAsignado.Enabled = False
    End Sub

    Private Sub LimpiarFormulario()
        Try
            moEntityRoles = New UserBE
            txtNombreRol.Text = String.Empty
            cboReference.SelectedIndex = -1
            cboGrupos.SelectedIndex = -1
            txtPassword.Text = String.Empty
            txtPassword2.Text = String.Empty
            'HabilitarBotones(True)
        Catch ex As Exception
            'UIFunctions.ShowErrorMessage("Se presentó problemas al limpiar el formulario.", ex)
        End Try
    End Sub

    Private Sub CargarUsuario(ByVal PrincipalId As Integer)
        Try
            moEntityRoles = PrincipalBR.GetPrincipalAll(PrincipalId)
            Dim principal = TryCast(moEntityRoles, UserBE)

            txtNombreRol.Text = principal.Name
            txtPassword.Text = principal.Password
            txtPassword2.Text = principal.Password
            cboGrupos.SelectedValue = principal.OrganizationalUnitId
            cboReference.SelectedValue = principal.ReferenceId
            chkEnabled.Checked = principal.Enabled
            UpdateRolesNew(principal)
            UpdatePolitics(principal)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdatePolitics(principal As PrincipalBE)
        Try
            Dim politics As IList(Of PoliticBE) = If(rbtAsignado.Checked, principal.PoliticLink, principal.PoliticPendingLink)
            moPoliticList = New List(Of PoliticSelection1)(politics.Count)
            For Each politic As PoliticBE In politics
                moPoliticList.Add(New PoliticSelection1(politic, rbtAsignado.Checked))
            Next
            Dim td = ConvertToDataTable(moPoliticList)
            gvwDocsReferenciados2.DataSource = td
            gvwDocsReferenciados2.DataBind()

            'btnAsignarRoles.Enabled = True
        Catch ex As Exception
            Throw ex
            'Msg(ex.UpdatePolitics)
        End Try
    End Sub

    Private Sub UpdateRolesNew(User As UserBE)
        moPrincipals = PrincipalBR.Select()
        Dim roles = (From principal In moPrincipals Where principal.PrincipalType = EPrincipalType.Role Select principal)
        moRoles = New Dictionary(Of Integer, RoleSelection1)()
        For Each role As PrincipalBE In roles
            moRoles.Add(role.PrincipalId, New RoleSelection1(role))
        Next

        'Dim roles = PrincipalBR.SelectLinkByUser(Session("PrincipalId"))
        For Each role As RoleSelection1 In moRoles.Values
            role.Selected = False
        Next

        For Each role As PrincipalBE In User.Principals
            moRoles(role.PrincipalId).Selected = True
        Next
        moRoleList = (From role In moRoles.Values Order By role.Selected Descending, If(role.Principal.OrganizationalUnitId = User.OrganizationalUnitId, 0, 1), role.OrganizationalUnit, role.PrincipalName Select role).ToList()

        Dim td = ConvertToDataTable(moRoleList)
        gvwDocsReferenciados.DataSource = td
        gvwDocsReferenciados.DataBind()

        'rbtAsignado.Enabled = False
    End Sub

    Private Sub LlenarDetalle()
        Try
            moPrincipals = PrincipalBR.Select()
            Dim roles = (From principal In moPrincipals Where principal.PrincipalType = EPrincipalType.Role Select principal)
            moRoles = New Dictionary(Of Integer, RoleSelection1)()
            For Each role As PrincipalBE In roles
                moRoles.Add(role.PrincipalId, New RoleSelection1(role))
            Next

            moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
            Dim User = TryCast(moEntityRoles, UserBE)
            For Each role As RoleSelection1 In moRoles.Values
                role.Selected = False
            Next
            For Each role As PrincipalBE In User.Principals
                moRoles(role.PrincipalId).Selected = True
            Next

            Dim EsActivo = True
            Dim id As Integer

            For Each row As GridViewRow In gvwDocsReferenciados.Rows
                id = CInt(row.Cells(1).Text)
                EsActivo = CType(row.FindControl("chkEsActivo"), CheckBox).Checked
                Dim role = moRoles.Values.Where(Function(o) o.PrincipalId = id).FirstOrDefault()
                role.Selected = EsActivo
            Next
            moRoleList = (From role In moRoles.Values Order By role.Selected Descending, If(role.Principal.OrganizationalUnitId = User.OrganizationalUnitId, 0, 1), role.OrganizationalUnit, role.PrincipalName Select role).ToList()
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Private Sub Buscar()
        Try
            Dim NumRegs As Integer
            'moEntityPolitics = PrincipalBR.SelectByRole(Session("PrincipalId"))
            moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
            Dim principal = DirectCast(moEntityRoles, UserBE)
            UpdatePolitics(principal)
            NumRegs = CInt(moPoliticList.Count)

            'Me.LblPagina.Text = "Nro de Pagina Actual : " + (Me.gvwDocsReferenciados.PageIndex + 1).ToString '<--
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LlenarDetallePoliticas()
        Try
            moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
            Dim principal = TryCast(moEntityRoles, UserBE)

            Dim politics As IList(Of PoliticBE) = If(rbtAsignado.Checked, principal.PoliticLink, principal.PoliticPendingLink)
            moPoliticList = New List(Of PoliticSelection1)(politics.Count)
            For Each politic As PoliticBE In politics
                moPoliticList.Add(New PoliticSelection1(politic, rbtAsignado.Checked))
            Next
            'Llenando campos seleccionados de la grilla
            Dim EsActivo = True
            Dim id As Integer
            For Each row As GridViewRow In gvwDocsReferenciados2.Rows
                id = CInt(row.Cells(1).Text)
                EsActivo = CType(row.FindControl("chkEsActivo"), CheckBox).Checked
                Dim politic = moPoliticList.Where(Function(o) o.PoliticId = id).FirstOrDefault()
                politic.Selected = EsActivo
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Configuracion del grid para Roles
            gvwDocsReferenciados.AllowPaging = True
            gvwDocsReferenciados.PageSize = 100
            gvwDocsReferenciados.PagerSettings.Mode = PagerButtons.Numeric
            gvwDocsReferenciados.PagerStyle.Font.Bold = True
            gvwDocsReferenciados.PageIndex = 0

            'Configuración del grid para politicas
            gvwDocsReferenciados2.AllowPaging = True
            gvwDocsReferenciados2.PageSize = 100
            gvwDocsReferenciados2.PagerSettings.Mode = PagerButtons.Numeric
            gvwDocsReferenciados2.PagerStyle.Font.Bold = True
            gvwDocsReferenciados2.PageIndex = 0

            'Oculta/Muestra las otras fichas del documento.
            If Not Page.IsPostBack Then
                InitializeData()
                'Valida si existe documento para ser cargado
                If Session("PrincipalId") IsNot Nothing Then
                    'Carga de Datos Inicial
                    CargarUsuario(Session("PrincipalId"))
                    HabilitarAtencion(False)
                Else 'NUEVO
                    'Se trata de nuevo ingreso. Carga datos en variable de Sesion principal "Documento"
                    LimpiarFormulario()
                    HabilitarAtencion(True)
                End If
            End If

            'mjeExito.Text = String.Empty
            'mjeInformacion.Text = String.Empty
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        If IsFormOnInserting Then
            LimpiarFormulario()
        ElseIf IsFormOnUpdating Then
            'moEntityRoles = PrincipalBR.SelectByUser(Session("PrincipalId"))
            'Dim Principal = TryCast(moEntityRoles, UserBE)
            'UpdateDetail(Principal)
            CargarUsuario(Session("PrincipalId"))
            HabilitarAtencion(False)
        End If

    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs)
        Grabar()
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        HabilitarAtencion(True)
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("frmBuscarUsuarios.aspx")
    End Sub

    Protected Sub btnGrabarPoliticas_Click(sender As Object, e As EventArgs) Handles btnGrabarPoliticas.Click
        LlenarDetallePoliticas()
        Dim selectedPolitics As IList(Of PoliticBE) = (From politic In moPoliticList Where (rbtAsignado.Checked AndAlso Not politic.Selected) OrElse (Not rbtAsignado.Checked AndAlso politic.Selected) Select politic.Politic).ToList()

        If selectedPolitics.Count > 0 Then
            moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
            Dim principal = TryCast(moEntityRoles, UserBE)

            PrincipalBR.UpdatePoliticLink(DirectCast(principal, PrincipalBE), selectedPolitics, Not rbtAsignado.Checked)
        End If

        'moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
        'Dim principal1 = TryCast(moEntityRoles, UserBE)

        'UpdatePolitics(principal1)

        CargarUsuario(Session("PrincipalId"))
    End Sub

    Protected Sub btnAsignarRoles_Click(sender As Object, e As EventArgs) Handles btnAsignarRoles.Click
        LlenarDetalle()
        Dim selectedRoles As IList(Of PrincipalBE) = (From role In moRoleList Where role.Selected Select role.Principal).ToList()

        moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
        Dim principaluser = TryCast(moEntityRoles, UserBE)

        PrincipalBR.UpdateLinks(DirectCast(principaluser, PrincipalBE), selectedRoles)

        CargarUsuario(Session("PrincipalId"))
    End Sub

    Protected Sub btnBuscarPoliticas_Click(sender As Object, e As EventArgs) Handles btnBuscarPoliticas.Click
        Dim moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
        Dim principal = TryCast(moEntityRoles, UserBE)

        UpdatePolitics(principal)
        'If rbtAsignado.Checked = True Then
        '    moEntityPolitics = TryCast(PrincipalBR.SelectByRole(Session("PrincipalId")), RoleBE)
        '    Dim principal = TryCast(moEntityPolitics, RoleBE)
        '    UpdatePolitics(DirectCast(moEntityPolitics, PrincipalBE))
        'Else
        '    'rbtAsignado.Checked = False

        '    moEntityPolitics = TryCast(PrincipalBR.SelectByRole(Session("PrincipalId")), RoleBE)
        '    Dim principal = TryCast(moEntityPolitics, RoleBE)
        '    UpdatePolitics(DirectCast(moEntityPolitics, PrincipalBE))
        'End If
    End Sub
#End Region

#Region "Grillas"
    Protected Sub gvwDocsReferenciados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvwDocsReferenciados.RowCommand
        Try
            If e.CommandName.Equals("Seleccionar") Then
                Dim fila As Integer = CType(e.CommandArgument, Integer)
                Dim NroDocumento = gvwDocsReferenciados.Rows.Item(fila).Cells(1).Text.Split("-")

                moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
                Dim principal = TryCast(moEntityRoles, UserBE)
                Dim Role = moEntityRoles.Principals.Where(Function(o) o.PrincipalId = Convert.ToInt32(NroDocumento(0))).ToList()

                If Role IsNot Nothing AndAlso Role.Count > 0 AndAlso Role.FirstOrDefault().Enabled = True Then
                    Session("Name") = txtNombreRol.Text
                    Session("NombreRol") = Role.FirstOrDefault().Name
                    Session("PrincipalId") = moEntityRoles.PrincipalId
                    Session("MasterPage") = "~/Master/MasterPage.master"
                    Session("LinkedPrincipalId") = NroDocumento(0)
                    Session("LinkType") = 1
                    ClientScript.RegisterStartupScript(Me.GetType(), "Message", "window.open('PopIntervaloFechas.aspx','','top=20,left=30,width=670,height=580,menubar=no,toolbar=no,scrollbars=yes,status=yes,resizable=yes');", True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub gvwDocsReferenciados2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvwDocsReferenciados2.RowCommand
        Try
            If e.CommandName.Equals("Seleccionar") Then
                Dim fila As Integer = CType(e.CommandArgument, Integer)
                Dim NroDocumento = gvwDocsReferenciados2.Rows.Item(fila).Cells(1).Text.Split("-")

                moEntityRoles = PrincipalBR.GetPrincipalAll(Session("PrincipalId"))
                Dim principal = TryCast(moEntityRoles, UserBE)
                Dim Poli = moEntityRoles.PoliticLink.Where(Function(o) o.PoliticId = Convert.ToInt32(NroDocumento(0))).ToList()

                If Poli IsNot Nothing AndAlso Poli.Count > 0 AndAlso Poli.FirstOrDefault().Enabled = True Then
                    Session("Name") = txtNombreRol.Text
                    Session("NombrePol") = Poli.FirstOrDefault().Name
                    Session("PrincipalId") = moEntityRoles.PrincipalId
                    Session("MasterPage") = "~/Master/MasterPage.master"
                    Session("PoliticId") = NroDocumento(0)
                    Session("LinkType") = 2
                    ClientScript.RegisterStartupScript(Me.GetType(), "Message", "window.open('PopIntervaloFechas.aspx','','top=20,left=30,width=670,height=580,menubar=no,toolbar=no,scrollbars=yes,status=yes,resizable=yes');", True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub gvwDocsReferenciados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvwDocsReferenciados.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim btnSel As ImageButton = DirectCast(e.Row.FindControl("btnSeleccionar"), ImageButton)
            btnSel.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub

    Protected Sub gvwDocsReferenciados2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvwDocsReferenciados2.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim btnSel As ImageButton = DirectCast(e.Row.FindControl("btnSeleccionar"), ImageButton)
            Dim chkSel As CheckBox = DirectCast(e.Row.FindControl("chkEsActivo"), CheckBox)
            btnSel.CommandArgument = e.Row.RowIndex.ToString()
            chkSel.ToolTip = e.Row.RowIndex.ToString
        End If
    End Sub

    Protected Sub gvwDocsReferenciados2_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvwDocsReferenciados2.PageIndexChanging
        Me.LblPagina.Text = "Nro de Pagina Actual : " + (e.NewPageIndex + 1).ToString '<--
    End Sub

    Protected Sub gvwDocsReferenciados2_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados2.PageIndexChanging
        Me.gvwDocsReferenciados2.PageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Protected Sub gvwDocsReferenciados_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwDocsReferenciados.PageIndexChanging
        Me.gvwDocsReferenciados.PageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Protected Sub gvwDocsReferenciados2_DataBound(sender As Object, ex As EventArgs) Handles gvwDocsReferenciados2.DataBound
        For Each e As GridViewRow In gvwDocsReferenciados2.Rows
            If (e.RowType = DataControlRowType.DataRow) Then
                Dim NroDocumento = gvwDocsReferenciados2.Rows.Item(e.RowIndex).Cells(1).Text.Split("-")
                Dim Poli = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticId = Convert.ToInt32(NroDocumento(0))).FirstOrDefault()

                If Poli IsNot Nothing AndAlso Poli.PoliticParentId = 0 Then
                    e.Font.Size = 9
                    e.Font.Bold = True
                End If
            End If
        Next
    End Sub

    Protected Sub chkEnabled_CheckedChanged(sender As Object, ex As EventArgs)
        Dim check As CheckBox = CType(sender, CheckBox)
        Dim NroDocumento = gvwDocsReferenciados2.Rows.Item(CInt(check.ToolTip)).Cells(1).Text.Split("-")

        'Busca la política seleccionada
        Dim PoliSelected = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticId = Convert.ToInt32(NroDocumento(0))).FirstOrDefault()

        If PoliSelected.PoliticParentId = 0 Then
            'Busca las politicas hijas
            Dim Hijas = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticParentId = PoliSelected.PoliticId AndAlso o.Enabled = True)

            If Hijas IsNot Nothing AndAlso Hijas.ToList().Count > 0 Then
                For Each x As GridViewRow In gvwDocsReferenciados2.Rows
                    Dim respuesta = Hijas.Where(Function(o) o.PoliticId = CInt(gvwDocsReferenciados2.Rows.Item(x.RowIndex).Cells(1).Text.Split("-").FirstOrDefault())).FirstOrDefault

                    If respuesta IsNot Nothing Then
                        CType(x.FindControl("chkEsActivo"), CheckBox).Checked = check.Checked
                    End If
                Next
            End If
        ElseIf check.Checked = True Then
            'Busca la politica padre
            Dim Padre = DataConsulting.Scop.Security.Context.Politics.Values.ToList().Where(Function(o) o.PoliticId = PoliSelected.PoliticParentId AndAlso o.Enabled = True).FirstOrDefault()

            If Padre IsNot Nothing Then
                For Each x As GridViewRow In gvwDocsReferenciados2.Rows
                    'Buscamos la fila
                    Dim i = CInt(gvwDocsReferenciados2.Rows.Item(x.RowIndex).Cells(1).Text.Split("-").FirstOrDefault())

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
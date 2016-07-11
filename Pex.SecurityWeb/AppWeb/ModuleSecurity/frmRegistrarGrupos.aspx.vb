Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Forms
Imports DataConsulting.Scop.Security
Imports System.Diagnostics

Partial Class SECGEN_TD_frmRegistrarGrupo
    Inherits MyCustomPageClass

#Region "Declarar Variabble"
    Dim moEntity As New OrganizationalUnitBE
#End Region

#Region "Propiedades"
    Private ReadOnly Property IsFormOnInserting() As Boolean
        Get
            Return Session("OrganizationalUnitId") Is Nothing
        End Get
    End Property
    Private ReadOnly Property IsFormOnUpdating() As Boolean
        Get
            Return Session("OrganizationalUnitId") IsNot Nothing
        End Get
    End Property
#End Region

#Region "Métodos"
    Private Sub HabilitarAtencion(ByVal enabled As Boolean)
        txtNombreGrupo.Enabled = enabled
        txtDescripcion.Enabled = enabled
        HabilitarBotones(enabled)
    End Sub

    Private Sub HabilitarBotones(ByVal flagEdit As Boolean)
        btnModificar.Visible = Not flagEdit AndAlso IsFormOnUpdating
        btnGrabar.Visible = flagEdit OrElse IsFormOnInserting
        btnCancelar.Visible = flagEdit
    End Sub
#End Region

    Private Sub Grabar()
        Try
            If CamposValidos() Then
                    LlenarEntidad()
                    If IsFormOnInserting Then
                        OrganizationalUnitBR.Insert(moEntity)
                    ElseIf IsFormOnUpdating Then
                        OrganizationalUnitBR.Update(moEntity)
                    End If
                    HabilitarAtencion(False)
                    'Session("OrganizationalUnit") = moEntity
                    Session("OrganizationalUnitId") = moEntity.OrganizationalUnitId
                    Response.Write("<script language='javascript'>alert('" + "Operaci\u00f3n Exitosa" + "');</script>")
                    CargarAtencion(moEntity)
                    HabilitarAtencion(False)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LlenarEntidad()
        Try
            moEntity.OrganizationalUnitId = Session("OrganizationalUnitId")
            moEntity.Name = txtNombreGrupo.Text
            moEntity.Description = txtDescripcion.Text
        Catch ex As Exception
            Throw ex
            'Msg(ex.Message)
        End Try
    End Sub

    Private Function CamposValidos() As Boolean
        Dim errMsg As String = String.Empty

        If txtNombreGrupo.Text = String.Empty Then
            errMsg &= "- No ha colocado el Nombre del Grupo\n"
        End If

        If errMsg <> String.Empty Then
            Response.Write("<script>alert('" + errMsg + "');</script>")
            'Response.Write(errMsg)
        End If

        Return errMsg = String.Empty
    End Function

    Private Function CargarGrupos(ByVal OrganizationaUnitId As Integer) As Boolean
        Try
            LimpiarFormulario()
            moEntity = OrganizationalUnitBR.GetOrganizationalUnitByCryterio(OrganizationaUnitId)
            'Carga de la información del Control de Calidad
            txtDescripcion.Text = moEntity.Description
            txtNombreGrupo.Text = moEntity.Name
            Session("OrganizationalUnitId") = moEntity.OrganizationalUnitId
            Return True
        Catch ex As Exception
            LimpiarFormulario()
            Return False
        End Try
    End Function

    Private Sub LimpiarFormulario()
        Try
            moEntity = New OrganizationalUnitBE
            txtNombreGrupo.Text = String.Empty
            txtDescripcion.Text = String.Empty
        Catch ex As Exception
            'UIFunctions.ShowErrorMessage("Se presentó problemas al limpiar el formulario.", ex)
        End Try
    End Sub

    Private Sub CargarAtencion(ByVal atencion As OrganizationalUnitBE)
        Try
            txtNombreGrupo.Text = atencion.Name
            txtDescripcion.Text = atencion.Description
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Eventos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Oculta/Muestra las otras fichas del documento.
            If Not Page.IsPostBack Then
                'Valida si existe documento para ser cargado
                If Session("OrganizationalUnitId") IsNot Nothing Then
                    Dim a As Integer = Session("OrganizationalUnitId")
                    CargarGrupos(a)
                    HabilitarAtencion(False)
                Else 'NUEVO
                    'Se trata de nuevo ingreso. Carga datos en variable de Sesion principal "Documento"
                    HabilitarAtencion(True)
                End If
                'Limpiamos mensajes
                'mjeExito.Text = String.Empty
                'mjeInformacion.Text = String.Empty
            End If
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
        Response.Redirect("frmBuscarGrupos.aspx")
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        If IsFormOnInserting Then
            LimpiarFormulario()
        ElseIf IsFormOnUpdating Then
            moEntity = OrganizationalUnitBR.GetOrganizationalUnitByCryterio(Session("OrganizationalUnitId"))
            Dim Principal = TryCast(moEntity, OrganizationalUnitBE)
            txtNombreGrupo.Text = Principal.Name
            txtDescripcion.Text = Principal.Description
            HabilitarAtencion(False)
        End If
    End Sub
#End Region
End Class
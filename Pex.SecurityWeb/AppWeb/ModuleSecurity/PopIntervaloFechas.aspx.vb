Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Forms
Imports DataConsulting.Scop.Security
Imports System.Diagnostics

Partial Class PopUpBuscarUsuarios
    Inherits MyCustomPageClass

#Region "Métodos del Formulario"
    Private oPoliticLinkFr As PoliticLinkFrequencyBE
    Private oPrincipalLinkFr As PrincipalLinkFrequencyBE
    Private moLista As Object

    Public Sub InicializarData()
        LlenarCombo(cboHoraInicio)
        LlenarCombo(cboHoraFin)
        Buscar()
    End Sub

    Private Sub Buscar()
        Try
            Dim td As DataTable
            Dim dtResult As Object = New Object()
            Dim prueba As BoundField = DirectCast(gvwLista.Columns.Item(1), BoundField)
            Select Case Session("LinkType")
                Case 1
                    lblCabeza.Text = "Rol:"
                    txtRol.Text = Session("NombreRol")
                    dtResult = PrincipalLinkFrequencyBR.GetPrincipalLinkFrequency(Session("PrincipalId"), Session("LinkedPrincipalId"))
                    'prueba.DataField = "PrincipalId"
                Case 2
                    lblCabeza.Text = "Politica:"
                    txtRol.Text = Session("NombrePol")
                    dtResult = PoliticLinkFrequencyBR.GetPoliticLinkFrequency(Session("PrincipalId"), Session("PoliticId"))
                    'prueba.DataField = "PoliticId"
            End Select

            td = ConvertToDataTable(dtResult)

            gvwLista.DataSource = td
            gvwLista.DataBind()
        Catch ex As Exception
            Throw ex
            'Session("msjError") = ex.Message.ToString
            'Response.Redirect("../frmError.aspx")
        End Try
    End Sub

    Public Shared Function ConvertToDataTable(Of T)(list As IList(Of T)) As DataTable
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

    Private Sub LlenarPrincipal()
        oPrincipalLinkFr = New PrincipalLinkFrequencyBE
        oPrincipalLinkFr.PrincipalId = Session("PrincipalId")
        oPrincipalLinkFr.LinkedPrincipalId = Session("LinkedPrincipalId")
        oPrincipalLinkFr.StartDate = GenerarFecha(calFechaInicio.SelectedDate.Date, cboHoraInicio.SelectedItem.Text)
        oPrincipalLinkFr.StartTime = DateTime.MinValue
        oPrincipalLinkFr.EndDate = If(calFechaFin.SelectedDate = DateTime.MinValue, DateTime.MinValue, GenerarFecha(calFechaFin.SelectedDate.Date, cboHoraFin.SelectedItem.Text))
        oPrincipalLinkFr.EndTime = DateTime.MinValue
        oPrincipalLinkFr.Observation = txtObservaciones.Text
    End Sub

    Private Sub LlenarPolitic()
        oPoliticLinkFr = New PoliticLinkFrequencyBE
        oPoliticLinkFr.PrincipalId = Session("PrincipalId")
        oPoliticLinkFr.PoliticId = Session("PoliticId")
        oPoliticLinkFr.StartDate = GenerarFecha(calFechaInicio.SelectedDate, cboHoraInicio.SelectedItem.Text)
        oPoliticLinkFr.StartTime = DateTime.MinValue
        oPoliticLinkFr.EndDate = If(calFechaFin.SelectedDate = DateTime.MinValue, DateTime.MinValue, GenerarFecha(calFechaFin.SelectedDate, cboHoraFin.SelectedItem.Text))
        oPoliticLinkFr.EndTime = DateTime.MinValue
        oPoliticLinkFr.Observation = txtObservaciones.Text
    End Sub

    Private Function GenerarFecha(fecha As DateTime, texto As String) As DateTime
        Dim hora As Double = CInt(texto.Substring(0, 2))
        Dim minuto As Double = CInt(texto.Substring(3, 2))

        Return fecha.AddHours(hora).AddMinutes(minuto)
    End Function

    Private Sub Grabar()
        Try
            If CamposValidos() Then
                Select Case Session("LinkType")
                    Case 1
                        LlenarPrincipal()
                        PrincipalLinkFrequencyBR.InsPrincipalLinkFrequency(oPrincipalLinkFr)
                    Case 2
                        LlenarPolitic()
                        PoliticLinkFrequencyBR.InsPoliticLinkFrequency(oPoliticLinkFr)
                    Case Else
                End Select
                Response.Write("<script language='javascript'>alert('" + "Operaci\u00f3n Exitosa" + "');</script>")
                'Response.Write("Operación Exitosa")
                Buscar()
                btnGrabar.Visible = False
            End If
        Catch ex As Exception
            Throw ex
            'Session("msjError") = ex.Message.ToString
            'Response.Redirect("../frmError.aspx")
        End Try
    End Sub

    Private Function CamposValidos() As Boolean
        Dim errMsg As String = String.Empty

        'If rbtList1.SelectedIndex = -1 Then
        '    errMsg &= "- No ha seleccionado el tipo de Intervalo" & Environment.NewLine
        'End If

        If calFechaInicio.SelectedDate = DateTime.MinValue Then
            errMsg &= "- No ha seleccionado la Fecha de Inicio\n"
        End If

        If cboHoraInicio.SelectedValue = 0 Then
            errMsg &= "- No ha seleccionado la Hora de Inicio\n"
        End If

        If Not calFechaFin.SelectedDate = DateTime.MinValue Then
            If calFechaInicio.SelectedDate.Date > calFechaFin.SelectedDate.Date Then
                errMsg &= "- La Fecha de Inicio no puede ser menor a la Fecha de Fin\n"
            End If

            If cboHoraFin.SelectedValue = 0 Then
                errMsg &= "- No ha seleccionado la Hora de Fin\n"
            End If
        End If

        'If calFechaFin.SelectedDate = DateTime.MinValue Then
        '    errMsg &= "- No ha seleccionado la Hora de Inicio" & Environment.NewLine
        'End If        

        If errMsg <> String.Empty Then
            Response.Write("<script language='javascript'>alert('" + errMsg + "');</script>")
            'Response.Write(errMsg)
        End If

        Return errMsg = String.Empty
    End Function

    Private Sub LlenarCombo(combo As DropDownList)
        combo.Items.Insert(0, New ListItem("23:45", 96))
        combo.Items.Insert(0, New ListItem("23:30", 95))
        combo.Items.Insert(0, New ListItem("23:15", 94))
        combo.Items.Insert(0, New ListItem("23:00", 93))
        combo.Items.Insert(0, New ListItem("22:45", 92))
        combo.Items.Insert(0, New ListItem("22:30", 91))
        combo.Items.Insert(0, New ListItem("22:15", 90))
        combo.Items.Insert(0, New ListItem("22:00", 89))
        combo.Items.Insert(0, New ListItem("21:45", 88))
        combo.Items.Insert(0, New ListItem("21:30", 87))
        combo.Items.Insert(0, New ListItem("21:15", 86))
        combo.Items.Insert(0, New ListItem("21:00", 85))
        combo.Items.Insert(0, New ListItem("20:45", 84))
        combo.Items.Insert(0, New ListItem("20:30", 83))
        combo.Items.Insert(0, New ListItem("20:15", 82))
        combo.Items.Insert(0, New ListItem("20:00", 81))
        combo.Items.Insert(0, New ListItem("19:45", 80))
        combo.Items.Insert(0, New ListItem("19:30", 79))
        combo.Items.Insert(0, New ListItem("19:15", 78))
        combo.Items.Insert(0, New ListItem("19:00", 77))
        combo.Items.Insert(0, New ListItem("18:45", 76))
        combo.Items.Insert(0, New ListItem("18:30", 75))
        combo.Items.Insert(0, New ListItem("18:15", 74))
        combo.Items.Insert(0, New ListItem("18:00", 73))
        combo.Items.Insert(0, New ListItem("17:45", 72))
        combo.Items.Insert(0, New ListItem("17:30", 71))
        combo.Items.Insert(0, New ListItem("17:15", 70))
        combo.Items.Insert(0, New ListItem("17:00", 69))
        combo.Items.Insert(0, New ListItem("16:45", 68))
        combo.Items.Insert(0, New ListItem("16:30", 67))
        combo.Items.Insert(0, New ListItem("16:15", 66))
        combo.Items.Insert(0, New ListItem("16:00", 65))
        combo.Items.Insert(0, New ListItem("15:45", 64))
        combo.Items.Insert(0, New ListItem("15:30", 63))
        combo.Items.Insert(0, New ListItem("15:15", 62))
        combo.Items.Insert(0, New ListItem("15:00", 61))
        combo.Items.Insert(0, New ListItem("14:45", 60))
        combo.Items.Insert(0, New ListItem("14:30", 59))
        combo.Items.Insert(0, New ListItem("14:15", 58))
        combo.Items.Insert(0, New ListItem("14:00", 57))
        combo.Items.Insert(0, New ListItem("13:45", 56))
        combo.Items.Insert(0, New ListItem("13:30", 55))
        combo.Items.Insert(0, New ListItem("13:15", 54))
        combo.Items.Insert(0, New ListItem("13:00", 53))
        combo.Items.Insert(0, New ListItem("12:45", 52))
        combo.Items.Insert(0, New ListItem("12:30", 51))
        combo.Items.Insert(0, New ListItem("12:15", 50))
        combo.Items.Insert(0, New ListItem("12:00", 49))
        combo.Items.Insert(0, New ListItem("11:45", 48))
        combo.Items.Insert(0, New ListItem("11:30", 47))
        combo.Items.Insert(0, New ListItem("11:15", 46))
        combo.Items.Insert(0, New ListItem("11:00", 45))
        combo.Items.Insert(0, New ListItem("10:45", 44))
        combo.Items.Insert(0, New ListItem("10:30", 43))
        combo.Items.Insert(0, New ListItem("10:15", 42))
        combo.Items.Insert(0, New ListItem("10:00", 41))
        combo.Items.Insert(0, New ListItem("09:45", 40))
        combo.Items.Insert(0, New ListItem("09:30", 39))
        combo.Items.Insert(0, New ListItem("09:15", 38))
        combo.Items.Insert(0, New ListItem("09:00", 37))
        combo.Items.Insert(0, New ListItem("08:45", 36))
        combo.Items.Insert(0, New ListItem("08:30", 35))
        combo.Items.Insert(0, New ListItem("08:15", 34))
        combo.Items.Insert(0, New ListItem("08:00", 33))
        combo.Items.Insert(0, New ListItem("07:45", 32))
        combo.Items.Insert(0, New ListItem("07:30", 31))
        combo.Items.Insert(0, New ListItem("07:15", 30))
        combo.Items.Insert(0, New ListItem("07:00", 29))
        combo.Items.Insert(0, New ListItem("06:45", 28))
        combo.Items.Insert(0, New ListItem("06:30", 27))
        combo.Items.Insert(0, New ListItem("06:15", 26))
        combo.Items.Insert(0, New ListItem("06:00", 25))
        combo.Items.Insert(0, New ListItem("05:45", 24))
        combo.Items.Insert(0, New ListItem("05:30", 23))
        combo.Items.Insert(0, New ListItem("05:15", 22))
        combo.Items.Insert(0, New ListItem("05:00", 21))
        combo.Items.Insert(0, New ListItem("04:45", 20))
        combo.Items.Insert(0, New ListItem("04:30", 19))
        combo.Items.Insert(0, New ListItem("04:15", 18))
        combo.Items.Insert(0, New ListItem("04:00", 17))
        combo.Items.Insert(0, New ListItem("03:45", 16))
        combo.Items.Insert(0, New ListItem("03:30", 15))
        combo.Items.Insert(0, New ListItem("03:15", 14))
        combo.Items.Insert(0, New ListItem("03:00", 13))
        combo.Items.Insert(0, New ListItem("02:45", 12))
        combo.Items.Insert(0, New ListItem("02:30", 11))
        combo.Items.Insert(0, New ListItem("02:15", 10))
        combo.Items.Insert(0, New ListItem("02:00", 9))
        combo.Items.Insert(0, New ListItem("01:45", 8))
        combo.Items.Insert(0, New ListItem("01:30", 7))
        combo.Items.Insert(0, New ListItem("01:15", 6))
        combo.Items.Insert(0, New ListItem("01:00", 5))
        combo.Items.Insert(0, New ListItem("00:45", 4))
        combo.Items.Insert(0, New ListItem("00:30", 3))
        combo.Items.Insert(0, New ListItem("00:15", 2))
        combo.Items.Insert(0, New ListItem("00:00", 1))
        combo.Items.Insert(0, New ListItem("Elija una opcion", 0))
    End Sub

    Private Sub CargarIntervalo()
        'calFechaInicio.SelectedDate = 
    End Sub
#End Region

#Region "Eventos del Formulario"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btnCancelar.Attributes.Add("OnClick", "window.close()")

            'Configuracion del grid del Formulario
            gvwLista.AllowPaging = True
            gvwLista.PageSize = 10
            gvwLista.PagerSettings.Mode = PagerButtons.Numeric
            gvwLista.PagerStyle.Font.Bold = True

            Session("TrabajadorTrama") = Nothing

            InicializarData()
        End If
    End Sub

    Protected Sub gvwLista_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvwLista.RowDataBound
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    Dim btnSel As ImageButton = DirectCast(e.Row.Cells(0).FindControl("btnSeleccionar"), ImageButton)
        '    btnSel.CommandArgument = e.Row.RowIndex.ToString()
        'End If
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim chkSel As System.Web.UI.WebControls.CheckBox = DirectCast(e.Row.FindControl("chkEsActivo"), System.Web.UI.WebControls.CheckBox)
            chkSel.ToolTip = e.Row.RowIndex.ToString
        End If
    End Sub

    Protected Sub gvwLista_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvwLista.RowCommand
        'If e.CommandName = "Seleccionar" Then
        '    Dim fila As Integer = CType(e.CommandArgument, Integer)
        '    Dim NroDocumento = gvwLista.Rows.Item(fila).Cells(1).Text.Split("-")

        '    Select Case Session("LinkType")
        '        Case 1
        '            'dtResult = PrincipalLinkFrequencyBR.GetPrincipalLinkFrequency(Session("PrincipalId"), Session("LinkedPrincipalId"))
        '        Case 2
        '            lblCabeza.Text = "Politica:"
        '            txtRol.Text = Session("NombrePol")
        '            'dtResult = PoliticLinkFrequencyBR.GetPoliticLinkFrequency(Session("PrincipalId"), Session("PoliticId"))
        '    End Select


        '    Response.Write("<script>window.opener.__doPostBack('BuscarTrabajador','');window.close();</script>")
        'End If
    End Sub

    Protected Sub gvwLista_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvwLista.PageIndexChanging
        gvwLista.PageIndex = e.NewPageIndex
        Buscar()
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs)
        Grabar()
    End Sub

    Protected Sub btnGrabarIntervalos_Click(sender As Object, e As EventArgs) Handles btnGrabarIntervalos.Click
        Try
            LlenarDetalle()
            Select Case Session("LinkType")
                Case 1
                    For Each x In moLista
                        PrincipalLinkFrequencyBR.UpdPrincipalLinkFrequency(x)
                    Next
                Case 2
                    For Each x In moLista
                        PoliticLinkFrequencyBR.UpdPoliticLinkFrequency(x)
                    Next
                Case Else
            End Select
            'Response.Write("Operación Exitosa")
            Response.Write("<script language='javascript'>alert('" + "Operaci\u00f3n Exitosa" + "');</script>")
            Buscar()
        Catch ex As Exception
            Throw ex
            'Session("msjError") = ex.Message.ToString
            'Response.Redirect("../frmError.aspx")
        End Try
    End Sub

    Private Sub LlenarDetalle()
        Try
            Dim Lista As Object
            Select Case Session("LinkType")
                Case 1
                    Lista = PrincipalLinkFrequencyBR.GetPrincipalLinkFrequency(Session("PrincipalId"), Session("LinkedPrincipalId"))
                    moLista = DirectCast(Lista, List(Of PrincipalLinkFrequencyBE))
                Case 2
                    Lista = PoliticLinkFrequencyBR.GetPoliticLinkFrequency(Session("PrincipalId"), Session("PoliticId"))
                    moLista = DirectCast(Lista, List(Of PoliticLinkFrequencyBE))
            End Select

            Dim EsActivo = True
            Dim Correlative As Integer
            For Each row As GridViewRow In gvwLista.Rows
                Correlative = CInt(row.Cells(1).Text)
                EsActivo = CType(row.FindControl("chkEsActivo"), System.Web.UI.WebControls.CheckBox).Checked
                'Dim politic
                Select Case Session("LinkType")
                    Case 1
                        Dim politic = DirectCast(moLista, List(Of PrincipalLinkFrequencyBE)).Where(Function(o) o.Correlative = Correlative).FirstOrDefault()
                        politic.Enabled = If(EsActivo, 1, 0)
                    Case 2
                        Dim politic = DirectCast(moLista, List(Of PoliticLinkFrequencyBE)).Where(Function(o) o.Correlative = Correlative).FirstOrDefault()
                        politic.Enabled = If(EsActivo, 1, 0)
                End Select
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class
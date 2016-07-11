Imports System.Data
Imports System.Collections.Generic
Imports DataConsulting.Scop.Security

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim Usuario = CType(Session("UserInfo"), DataConsulting.Scop.Security.UserBE)
            If (Usuario Is Nothing) Then
                Dim sRutaPagina As String = Request.AppRelativeCurrentExecutionFilePath
                Dim sArregloRutaPagina As String() = sRutaPagina.Split("/")
                Dim nNroSlashPag As Integer = sArregloRutaPagina.Length - 1

                Dim nContadorx As Integer
                Dim sRutaAlert As String = String.Empty
                For nContadorx = 1 To nNroSlashPag - 1 Step 1
                    sRutaAlert = sRutaAlert & "../"
                Next nContadorx
                Response.Redirect(sRutaAlert & "frmLogin.aspx")
            Else
                If Not Page.IsPostBack Then
                    Dim oGrantedMenuItems As New SortedList(Of String, Integer)
                    Dim dtMenuList As DataTable
                    Try
                        dtMenuList = PoliticBR.GetGrantedMenuPolitic(Usuario.UserName, 2000)
                        For Each oRow As Data.DataRow In dtMenuList.Rows
                            If oRow.Item("NombreMenu").ToString() <> String.Empty Then
                                oGrantedMenuItems.Add(oRow.Item("NombreMenu").ToString(), 0)
                            End If
                        Next
                        DeactivateMenuItems(mnMenuPrincipal.Items, oGrantedMenuItems) '  mnuScopSeguridad.Items
                    Catch ex As Exception
                    End Try

                    lblUsuario.Text = Usuario.UserName
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    'Procedimiento que permite Inhabilitar solo los menus que son asignados al usuario en Session actual
    Private Function DeactivateMenuItems(ByVal oMenuItemCol As MenuItemCollection, ByVal oEnabledItems As SortedList(Of String, Integer)) As Integer
        Try
            Dim listOfChildrenToDelete = New List(Of MenuItem)()
            Dim Parent = New MenuItem()

            'Marcamos los que vamos a inactivar
            For Each oMenuItem As MenuItem In oMenuItemCol
                If TypeOf oMenuItem Is MenuItem Then
                    If oMenuItem.ChildItems.Count > 0 Then
                        DeactivateMenuItems(oMenuItem.ChildItems, oEnabledItems)
                    Else
                        If Not oEnabledItems.ContainsKey(oMenuItem.Value) Then
                            listOfChildrenToDelete.Add(oMenuItem)
                            Parent = oMenuItem.Parent
                        End If
                    End If
                End If
            Next

            'Eliminamos los marcados
            For Each childToDelete As MenuItem In listOfChildrenToDelete
                Parent.ChildItems.Remove(childToDelete)
            Next

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Function

    Protected Sub lnkbCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbCerrar.Click
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

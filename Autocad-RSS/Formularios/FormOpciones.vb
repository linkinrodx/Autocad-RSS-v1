Public Class FormOpciones

    Public Sub New()
        InitializeComponent()
        InicializarData()
    End Sub

    Private Sub InicializarData()
        OpcionesBE.LlenarComboLinea(cboAlgoLinea) : OpcionesBE.LlenarComboCirculo(cboAlgoCirculo) : OpcionesBE.LlenarComboElipse(cboAlgoElipse)
        OpcionesBE.LlenarComboGrosor1(cboGrosorLinea) : OpcionesBE.LlenarComboGrosor2(cboGrosorCirculo) : OpcionesBE.LlenarComboGrosor3(cboGrosorElipse) : OpcionesBE.LlenarComboGrosor4(cboGrosorPincel)
        OpcionesBE.LlenarComboColor1(cboColorLinea) : OpcionesBE.LlenarComboColor2(cboColorCirculo) : OpcionesBE.LlenarComboColor3(cboColorElipse) : OpcionesBE.LlenarComboColor4(cboColorPincel)
        TextBox1.Text = LineaBE.Tamaño : TextBox2.Text = CirculoBE.Tamaño : TextBox3.Text = ElipseBE.Tamaño : TextBox4.Text = PincelBE.Tamaño
    End Sub

    Private Sub FormOpciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMain.Enabled = True
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "0" Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#Region "Linea"
    Private Sub cboColorLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboColorLinea.SelectedIndexChanged
        Select Case cboColorLinea.SelectedIndex
            Case 0
                LineaBE.Color = Color.Red
            Case 1
                LineaBE.Color = Color.Blue
            Case 2
                LineaBE.Color = Color.Green
            Case 3
                LineaBE.Color = Color.Black
            Case 4
                LineaBE.Color = Color.Yellow
        End Select
    End Sub

    Private Sub cboAlgoLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlgoLinea.SelectedIndexChanged
        Select Case cboAlgoLinea.SelectedIndex
            Case 0
                LineaBE.Algoritmo = OpcionesBE.AlgoritmoLinea.Directo
            Case 1
                LineaBE.Algoritmo = OpcionesBE.AlgoritmoLinea.ADDSimple
            Case 2
                LineaBE.Algoritmo = OpcionesBE.AlgoritmoLinea.ADDEntero
            Case 3
                LineaBE.Algoritmo = OpcionesBE.AlgoritmoLinea.Bresenham
        End Select
    End Sub

    Private Sub cboGrosorLinea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrosorLinea.SelectedIndexChanged
        Select Case cboGrosorLinea.SelectedIndex
            Case 0
                LineaBE.Grosor = OpcionesBE.AlgoritmoGrosor.Discontinua
            Case 1
                LineaBE.Grosor = OpcionesBE.AlgoritmoGrosor.Extensiones
            Case 2
                LineaBE.Grosor = OpcionesBE.AlgoritmoGrosor.Arcos
            Case 3
                LineaBE.Grosor = OpcionesBE.AlgoritmoGrosor.Pincel
        End Select
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = String.Empty Then
            LineaBE.Tamaño = 1
        Else
            LineaBE.Tamaño = CInt(TextBox1.Text)
        End If
    End Sub
#End Region

#Region "Circulo"
    Private Sub cboColorCirculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboColorCirculo.SelectedIndexChanged
        Select Case cboColorCirculo.SelectedIndex
            Case 0
                CirculoBE.Color = Color.Red
            Case 1
                CirculoBE.Color = Color.Blue
            Case 2
                CirculoBE.Color = Color.Green
            Case 3
                CirculoBE.Color = Color.Black
            Case 4
                CirculoBE.Color = Color.Yellow
        End Select
    End Sub

    Private Sub cboAlgoCirculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlgoCirculo.SelectedIndexChanged
        Select Case cboAlgoCirculo.SelectedIndex
            Case 0
                CirculoBE.Algoritmo = OpcionesBE.AlgoritmoCirculo.Implicito
            Case 1
                CirculoBE.Algoritmo = OpcionesBE.AlgoritmoCirculo.Incremental
            Case 2
                CirculoBE.Algoritmo = OpcionesBE.AlgoritmoCirculo.Bresenham
            Case 3
                CirculoBE.Algoritmo = OpcionesBE.AlgoritmoCirculo.Polar
        End Select
    End Sub

    Private Sub cboGrosorCirculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrosorCirculo.SelectedIndexChanged
        Select Case cboGrosorCirculo.SelectedIndex
            Case 0
                CirculoBE.Grosor = OpcionesBE.AlgoritmoGrosor.Discontinua
            Case 1
                CirculoBE.Grosor = OpcionesBE.AlgoritmoGrosor.Extensiones
            Case 2
                CirculoBE.Grosor = OpcionesBE.AlgoritmoGrosor.Arcos
            Case 3
                CirculoBE.Grosor = OpcionesBE.AlgoritmoGrosor.Pincel
        End Select
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox1.Text = String.Empty Then
            CirculoBE.Tamaño = 1
        Else
            CirculoBE.Tamaño = CInt(TextBox2.Text)
        End If
    End Sub
#End Region

#Region "Elipse"
    Private Sub cboColorElipse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboColorElipse.SelectedIndexChanged
        Select Case cboColorElipse.SelectedIndex
            Case 0
                ElipseBE.Color = Color.Red
            Case 1
                ElipseBE.Color = Color.Blue
            Case 2
                ElipseBE.Color = Color.Green
            Case 3
                ElipseBE.Color = Color.Black
            Case 4
                ElipseBE.Color = Color.Yellow
        End Select
    End Sub

    Private Sub cboAlgoElipse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlgoElipse.SelectedIndexChanged
        Select Case cboAlgoElipse.SelectedIndex
            Case 0
                ElipseBE.Algoritmo = OpcionesBE.AlgoritmoElipse.Bresenham
        End Select
    End Sub

    Private Sub cboGrosorElipse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrosorElipse.SelectedIndexChanged
        Select Case cboGrosorCirculo.SelectedIndex
            Case 0
                ElipseBE.Grosor = OpcionesBE.AlgoritmoGrosor.Discontinua
            Case 1
                ElipseBE.Grosor = OpcionesBE.AlgoritmoGrosor.Extensiones
            Case 2
                ElipseBE.Grosor = OpcionesBE.AlgoritmoGrosor.Arcos
            Case 3
                ElipseBE.Grosor = OpcionesBE.AlgoritmoGrosor.Pincel
        End Select
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox1.Text = String.Empty Then
            ElipseBE.Tamaño = 1
        Else
            ElipseBE.Tamaño = CInt(TextBox3.Text)
        End If
    End Sub
#End Region

#Region "Pincel"
    Private Sub cboColorPincel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboColorPincel.SelectedIndexChanged
        Select Case cboColorPincel.SelectedIndex
            Case 0
                PincelBE.Color = Color.Red
            Case 1
                PincelBE.Color = Color.Blue
            Case 2
                PincelBE.Color = Color.Green
            Case 3
                PincelBE.Color = Color.Black
            Case 4
                PincelBE.Color = Color.Yellow
        End Select
    End Sub

    Private Sub cboGrosorPincel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrosorPincel.SelectedIndexChanged
        Select Case cboGrosorPincel.SelectedIndex
            Case 0
                PincelBE.Grosor = OpcionesBE.AlgoritmoGrosor.Discontinua
            Case 1
                PincelBE.Grosor = OpcionesBE.AlgoritmoGrosor.Extensiones
            Case 2
                PincelBE.Grosor = OpcionesBE.AlgoritmoGrosor.Arcos
            Case 3
                PincelBE.Grosor = OpcionesBE.AlgoritmoGrosor.Pincel
        End Select
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox1.Text = String.Empty Then
            PincelBE.Tamaño = 1
        Else
            PincelBE.Tamaño = CInt(TextBox4.Text)
        End If
    End Sub
#End Region
End Class
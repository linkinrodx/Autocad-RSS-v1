Public Class FuncionesBE
    Public Shared Function ValidarCoordenadas(x, y, xmax, ymax) As Boolean
        If x >= xmax Then Return False
        If x < 0 Then Return False

        If y >= ymax Then Return False
        If y < 0 Then Return False
        Return True
    End Function

    Public Shared Function MarcarCoordenadas(x As Integer, y As Integer) As Bitmap
        Dim plano As Bitmap = New Bitmap(x, y)
        Dim a = 0
        While (a < x)
            plano.SetPixel(a, y / 2, Color.Red)
            a = a + 1
        End While
        a = 0
        While (a < y)
            plano.SetPixel(x / 2, a, Color.Red)
            a = a + 1
        End While
        Return plano
    End Function

    Public Shared Function cuadro() As Bitmap
        Dim plano As Bitmap = New Bitmap(600, 500)
        'x
        Dim x = 150
        While (x < 450)
            plano.SetPixel(x, 125, Color.Blue)
            x = x + 1
        End While

        x = 150
        While (x < 450)
            plano.SetPixel(x, 375, Color.Blue)
            x = x + 1
        End While
        '''''''''''''''''''''''''''''''
        'y
        Dim y = 125
        While (y < 375)
            plano.SetPixel(150, y, Color.Blue)
            y = y + 1
        End While

        y = 125
        While (y < 375)
            plano.SetPixel(450, y, Color.Blue)
            y = y + 1
        End While
        Return plano
    End Function

    'Public Function CalcularTiempo()
    '    Dim tiempo2 As DateTime = DateTime.Now
    '    Dim total As TimeSpan = New TimeSpan(tiempo2.Ticks - tiempo1.Ticks)
    '    label5.Text = "El programa termino " + total.ToString()
    '    label6.Text = ((xf - xi) / (yf - yi)).ToString()
    'End Function

    Public Shared Function Distancia_entre_2_puntos(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Decimal
        Dim distancia As Decimal = Math.Sqrt((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1))
        Return distancia
    End Function

    Public Shared Function MatrizTraslacion(h, v) As Integer()()
        Dim a(3)() As Integer

        a(0)(0) = 1
        a(1)(0) = 0
        a(2)(0) = 0
        a(0)(1) = 0
        a(1)(1) = 1
        a(2)(1) = 0
        a(0)(2) = h
        a(1)(2) = v
        a(2)(2) = 1

        Return a
    End Function

    Public Shared Function GenerarArray(oLista As List(Of Integer)) As Integer()()
        Dim o(oLista.Count / 2)() As Integer
        Dim i = 0 : Dim j = 0

        For Each k In oLista
            If i <> 2 Then
                o(i)(j) = k
                i = i + 1
            Else
                o(i)(j) = 1
                i = 0 : j = j + 1
            End If
        Next

        Return o
    End Function

    Public Shared Function MultiplicacionMatriz(o1 As Integer()(), o2 As Integer()()) As Integer()()
        Dim o3(o1.Length)() As Integer

        For k = 0 To o1.Length
            For i = 0 To 3
                For j = 0 To 3
                    o3(i)(k) += o1(j)(i) * o2(i)(j)
                Next
            Next
        Next

        Return o3
    End Function



    Public Shared Function ListaTraslacion(h, v) As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(h)
        oLista.Add(v)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaEscalamiento(EX, EY) As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(EX)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(EY)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaAfilamientoY(AF) As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(1)
        oLista.Add(AF)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaAfilamientoX(AF) As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(AF)
        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaReflexionX() As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(-1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaReflexionY() As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(-1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaReflexionXY() As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)

        oLista.Add(-1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(-1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function ListaRotacion(angulo As Integer) As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)
        Dim alfa As Double = (Math.PI * angulo / 180)

        oLista.Add(Math.Cos(alfa))
        oLista.Add(Math.Sin(alfa))
        oLista.Add(0)
        oLista.Add(-Math.Sin(alfa))
        oLista.Add(Math.Cos(alfa))
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function NuevaListaRotacion(sen As Decimal, cos As Decimal) As List(Of Decimal)
        Dim oLista As List(Of Decimal) = New List(Of Decimal)
        'Dim alfa As Double = (Math.PI * angulo / 180)

        oLista.Add(cos)
        oLista.Add(sen)
        oLista.Add(0)
        oLista.Add(-sen)
        oLista.Add(cos)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)

        Return oLista
    End Function

    Public Shared Function GenerarLista(oLista As List(Of Decimal)) As List(Of Decimal)
        Dim o As List(Of Decimal) = New List(Of Decimal)
        Dim i = 0 : Dim j = 0

        For k = 0 To oLista.Count - 1
            If i <> 2 Then
                o.Add(oLista.Item(k))
                i = i + 1
            Else
                o.Add(1) : o.Add(oLista.Item(k))
                i = 1
            End If
        Next
        o.Add(1)

        Return o
    End Function

    Public Shared Function MultiplicacionLista(o1 As List(Of Decimal), o2 As List(Of Decimal), Optional s As Integer = 3) As List(Of Decimal)
        Dim o3 As List(Of Decimal) = New List(Of Decimal)
        Dim a As Decimal
        Dim p = 0 : Dim q = 0

        For k = 0 To o1.Count - 1 Step s
            For i = 0 + k To s - 1 + k
                For j = 0 To s - 1
                    'o3.Item(i) += o1(j)(i) * o2(i)(j)
                    a += o1.Item(j + k) * o2.Item(i - k + q) : q += s
                Next
                q = 0 : o3.Add(a) : a = 0
            Next
        Next

        Return o3
    End Function

    Public Shared Function MultiplicacionLista2(o1 As List(Of Double), o2 As List(Of Double), Optional s As Integer = 3) As List(Of Double)
        Dim o3 As List(Of Double) = New List(Of Double)
        Dim a As Double
        Dim p = 0 : Dim q = 0

        For k = 0 To o1.Count - 1 Step s
            For i = 0 + k To s - 1 + k
                For j = 0 To s - 1
                    'o3.Item(i) += o1(j)(i) * o2(i)(j)
                    a += o1.Item(j + k) * o2.Item(i - k + q) : q += s
                Next
                q = 0 : o3.Add(a) : a = 0
            Next
        Next

        Return o3
    End Function

    Public Shared Function DegenerarLista(oLista As List(Of Decimal)) As List(Of Decimal)
        Dim o As List(Of Decimal) = New List(Of Decimal)
        Dim i = 0 : Dim j = 0

        For k = 0 To oLista.Count - 1
            If i <> 2 Then
                o.Add(oLista.Item(k))
                i = i + 1
            Else
                'o.Add(1)
                'o.Add(oLista.Item(k))
                i = 0
            End If
        Next
        'o.Add(1)

        Return o
    End Function

    Public Shared Function ListaEjemplo1x() As List(Of Double)
        Dim oLista As List(Of Double) = New List(Of Double)

        oLista.Add(40)
        oLista.Add(110)
        oLista.Add(180)
        oLista.Add(240)
        oLista.Add(30)
        oLista.Add(40)
        oLista.Add(100)
        oLista.Add(230)
        oLista.Add(20)
        oLista.Add(30)
        oLista.Add(90)
        oLista.Add(220)
        oLista.Add(10)
        oLista.Add(80)
        oLista.Add(150)
        oLista.Add(200)

        Return oLista
    End Function

    Public Shared Function ListaEjemplo1y() As List(Of Double)
        Dim oLista As List(Of Double) = New List(Of Double)

        oLista.Add(90)
        oLista.Add(90)
        oLista.Add(90)
        oLista.Add(90)
        oLista.Add(80)
        oLista.Add(190)
        oLista.Add(180)
        oLista.Add(80)
        oLista.Add(50)
        oLista.Add(150)
        oLista.Add(120)
        oLista.Add(50)
        oLista.Add(10)
        oLista.Add(10)
        oLista.Add(10)
        oLista.Add(10)

        Return oLista
    End Function

    Public Shared Function MatrizBezier() As List(Of Double)
        Dim oLista As List(Of Double) = New List(Of Double)

        oLista.Add(-1)
        oLista.Add(3)
        oLista.Add(-3)
        oLista.Add(1)
        oLista.Add(3)
        oLista.Add(-6)
        oLista.Add(3)
        oLista.Add(0)
        oLista.Add(-3)
        oLista.Add(3)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(1)
        oLista.Add(0)
        oLista.Add(0)
        oLista.Add(0)

        Return oLista
    End Function

    Public Shared Function MatrizS(i, Optional j = 0) As List(Of Double)
        Dim oLista As List(Of Double) = New List(Of Double)

        Dim x0 = 0, x1 = 0.2, x2 = 0.4, x3 = 0.6, x4 = 0.8, x5 = 1

        Select Case i
            Case 1
                oLista.Add(Math.Pow(x0, 3))
                oLista.Add(Math.Pow(x0, 2))
                oLista.Add(Math.Pow(x0, 1))
                oLista.Add(Math.Pow(x0, 0))
            Case 2
                oLista.Add(Math.Pow(x1, 3))
                oLista.Add(Math.Pow(x1, 2))
                oLista.Add(Math.Pow(x1, 1))
                oLista.Add(Math.Pow(x1, 0))
            Case 3
                oLista.Add(Math.Pow(x2, 3))
                oLista.Add(Math.Pow(x2, 2))
                oLista.Add(Math.Pow(x2, 1))
                oLista.Add(Math.Pow(x2, 0))
            Case 4
                oLista.Add(Math.Pow(x3, 3))
                oLista.Add(Math.Pow(x3, 2))
                oLista.Add(Math.Pow(x3, 1))
                oLista.Add(Math.Pow(x3, 0))
            Case 5
                oLista.Add(Math.Pow(x4, 3))
                oLista.Add(Math.Pow(x4, 2))
                oLista.Add(Math.Pow(x4, 1))
                oLista.Add(Math.Pow(x4, 0))
            Case 6
                oLista.Add(Math.Pow(x5, 3))
                oLista.Add(Math.Pow(x5, 2))
                oLista.Add(Math.Pow(x5, 1))
                oLista.Add(Math.Pow(x5, 0))
        End Select

        If j <> 0 Then
            Dim nueva = New List(Of Double)
            For Each x In oLista
                nueva.Add(x)
                For l = 1 To j - 1
                    nueva.Add(0)
                Next
            Next
            oLista = nueva
        End If

        Return oLista
    End Function
End Class

Public Class Circulo
    Public Shared Function Generar_Circulo(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap)
        Select Case CirculoBE.Algoritmo
            Case OpcionesBE.AlgoritmoCirculo.Implicito
                Return CirculoImplicito_Libre(xi, yi, xf, yf, plano)
            Case OpcionesBE.AlgoritmoCirculo.Incremental
                Return CirculoIncremental_Libre(xi, yi, xf, yf, plano)
            Case OpcionesBE.AlgoritmoCirculo.Bresenham
                Return CirculoBresenham_Libre(xi, yi, xf, yf, plano)
            Case OpcionesBE.AlgoritmoCirculo.Polar
                Return CirculoPolar_Libre(xi, yi, xf, yf, plano)
                'Select Case grosor
                '    Case OpcionesBE.AlgoritmoGrosor.Discontinua
                '    Case OpcionesBE.AlgoritmoGrosor.Extensiones
                '    Case OpcionesBE.AlgoritmoGrosor.Arcos
                '    Case OpcionesBE.AlgoritmoGrosor.Pincel
                'End Select
            Case Else
                Return Nothing
        End Select
    End Function

    Public Shared Function CirculoBresenham_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer

        Dim r As Integer = FuncionesBE.Distancia_entre_2_puntos(xi, yi, xf, yf)

        p = 1 - r
        x = 0
        y = r

        PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If
            PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)
        End While
        Return plano1
    End Function

    Public Shared Function CirculoIncremental_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim dalfa, sa, ca, aux, x, y As Double

        Dim r As Integer = FuncionesBE.Distancia_entre_2_puntos(xi, yi, xf, yf)

        dalfa = 1 / r
        sa = Math.Sin(dalfa)
        ca = Math.Cos(dalfa)
        x = 0
        y = r

        While y >= x
            PintarSimetricamente(CInt(x), CInt(y), CInt(xi), CInt(yi), CirculoBE.Color, plano1)

            aux = x
            x = ((x * ca) - (y * sa))
            y = ((y * ca) + (aux * sa))
        End While
        Return plano1
    End Function

    Public Shared Function CirculoImplicito_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim y, y1 As Double

        Dim r As Integer = FuncionesBE.Distancia_entre_2_puntos(xi, yi, xf, yf)

        Dim a = xi - r, n = xi + r

        For i = a To n
            y = yi + Math.Sqrt(r * r - Math.Pow(i - xi, 2))
            y1 = yi - Math.Sqrt(r * r - Math.Pow(i - xi, 2))

            PintarxUno(i, CInt(y), CirculoBE.Color, plano1)
            PintarxUno(i, CInt(y1), CirculoBE.Color, plano1)
        Next
       
        Return plano1
    End Function

    Public Shared Function CirculoPolar_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim alfa As Double = 0, radian As Double
        Dim dx, dy As Double

        Dim r As Integer = FuncionesBE.Distancia_entre_2_puntos(xi, yi, xf, yf)

        radian = 2 * Math.PI / 360
        Dim x = r, y = 0

        While alfa <= 2 * Math.PI
            PintarxUno(x + xi, y + yi, CirculoBE.Color, plano1)
            alfa += radian

            dx = r * Math.Cos(alfa)
            dy = r * Math.Sin(alfa)

            x = CInt(dx)
            y = CInt(dy)
        End While
        Return plano1
    End Function

    Public Shared Function CirculoBresenham_Coordenadas(xi As Integer, yi As Integer, r As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer

        p = 1 - r
        x = 0
        y = r

        PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If
            PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)
        End While
        Return plano1
    End Function

    Public Shared Function CirculoBresenham_Coordenadas_Espaciado(xi As Integer, yi As Integer, r As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer
        Dim i As Integer

        p = 1 - r
        x = 0
        y = r

        

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If
            If i < 3 Then
                PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)
                i = i + 1
            Else : i = 0
            End If
        End While
        Return plano1
    End Function

    Public Shared Function CirculoBresenham_Coordenadas_Extensiones(xi As Integer, yi As Integer, r As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer

        p = 1 - r
        x = 0
        y = r

        For i = 1 To 4
            PintarSimetricamente(x, y + i - 3, xi, yi, CirculoBE.Color, plano1)
        Next

        PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If

            For i = 1 To 4
                PintarSimetricamente(x, y + i - 3, xi, yi, CirculoBE.Color, plano1)
            Next

            PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)
        End While
        Return plano1
    End Function

    Public Shared Function CirculoBresenham_Coordenadas_Arcos(xi As Integer, yi As Integer, r As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer

        p = 1 - r
        x = 0
        y = r
        '''''''
        PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)

        Dim nuevo As Color
        For i = 1 To 5
            nuevo = plano1.GetPixel(xi + x, yi + y - i)
            If nuevo.A = CirculoBE.Color.A AndAlso nuevo.R = CirculoBE.Color.R AndAlso nuevo.G = CirculoBE.Color.G AndAlso nuevo.B = CirculoBE.Color.B Then
                Exit For
            End If
            PintarSimetricamente(x, y - i, xi, yi, Color.Blue, plano1)
        Next

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If
            PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)
            For i = 1 To 5
                nuevo = plano1.GetPixel(xi + x, yi + y - i)
                If nuevo.A = CirculoBE.Color.A AndAlso nuevo.R = CirculoBE.Color.R AndAlso nuevo.G = CirculoBE.Color.G AndAlso nuevo.B = CirculoBE.Color.B Then
                    Exit For
                End If
                PintarSimetricamente(x, y - i, xi, yi, CirculoBE.Color, plano1)
            Next
        End While
        Return plano1
    End Function

    Public Shared Function CirculoBresenham_Coordenadas_Pluma(xi As Integer, yi As Integer, r As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer

        p = 1 - r
        x = 0
        y = r

        'For i = -1 To 1
        '    For j = -1 To 1
        '        PintarSimetricamente(x + j, y + i, xi, yi, Color.Blue, plano1)
        '    Next
        'Next

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If

            For i = -1 To 1
                For j = -1 To 1
                    PintarSimetricamente(x + j, y + i, xi, yi, CirculoBE.Color, plano1)
                Next
            Next
        End While
        Return plano1
    End Function

    Public Shared Function CirculoBresenham_Coordenadas_Pluma2(xi As Integer, yi As Integer, r As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer

        p = 1 - r
        x = 0
        y = r

        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If
            PintarSimetricamente(x, y, xi, yi, CirculoBE.Color, plano1)
        End While
        Return plano1
    End Function

    Public Shared Sub PintarSimetricamente_Pincel(x As Integer, y As Integer, xc As Integer, yc As Integer, oColor As Color, plano1 As Bitmap)
        'If ValidarCoordenadas(xc + x, yc + y) Then plano1.SetPixel(xc + x, yc + y, oColor)
        'If ValidarCoordenadas(xc - x, yc + y) Then plano1.SetPixel(xc - x, yc + y, oColor) 'iz
        If FuncionesBE.ValidarCoordenadas(xc + x, yc - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xc + x, yc - y, oColor) 'sd
        'If ValidarCoordenadas(xc - x, yc - y) Then plano1.SetPixel(xc - x, yc - y, oColor)

        'If ValidarCoordenadas(xc + y, yc + x) Then plano1.SetPixel(xc + y, yc + x, oColor)
        'If ValidarCoordenadas(xc - y, yc + x) Then plano1.SetPixel(xc - y, yc + x, oColor) 'ii
        If FuncionesBE.ValidarCoordenadas(xc + y, yc - x, plano1.Width, plano1.Height) Then plano1.SetPixel(xc + y, yc - x, oColor) 'ds
        'If ValidarCoordenadas(xc - y, yc - x) Then plano1.SetPixel(xc - y, yc - uuuuuux, oColor)
    End Sub

    Public Shared Sub PintarSimetricamente(x As Integer, y As Integer, xc As Integer, yc As Integer, oColor As Color, plano1 As Bitmap)
        If FuncionesBE.ValidarCoordenadas(xc + x, yc + y, plano1.Width, plano1.Height) Then plano1.SetPixel(xc + x, yc + y, oColor)
        If FuncionesBE.ValidarCoordenadas(xc - x, yc + y, plano1.Width, plano1.Height) Then plano1.SetPixel(xc - x, yc + y, oColor) 'iz
        If FuncionesBE.ValidarCoordenadas(xc + x, yc - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xc + x, yc - y, oColor) 'sd
        If FuncionesBE.ValidarCoordenadas(xc - x, yc - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xc - x, yc - y, oColor)

        If FuncionesBE.ValidarCoordenadas(xc + y, yc + x, plano1.Width, plano1.Height) Then plano1.SetPixel(xc + y, yc + x, oColor)
        If FuncionesBE.ValidarCoordenadas(xc - y, yc + x, plano1.Width, plano1.Height) Then plano1.SetPixel(xc - y, yc + x, oColor) 'ii
        If FuncionesBE.ValidarCoordenadas(xc + y, yc - x, plano1.Width, plano1.Height) Then plano1.SetPixel(xc + y, yc - x, oColor) 'ds
        If FuncionesBE.ValidarCoordenadas(xc - y, yc - x, plano1.Width, plano1.Height) Then plano1.SetPixel(xc - y, yc - x, oColor)
    End Sub

    Public Shared Sub PintarxUno(x As Integer, y As Integer, oColor As Color, plano1 As Bitmap)
        If FuncionesBE.ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, oColor)
    End Sub

    Public Shared Function CirculoBresenham_Libre_Nuevo(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap, tipogrosor As Integer) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, p As Integer : Dim j As Integer

        Dim r As Integer = FuncionesBE.Distancia_entre_2_puntos(xi, yi, xf, yf)

        p = 1 - r
        x = 0
        y = r
        ''''''''''''''''
        Select Case tipogrosor
            Case OpcionesBE.AlgoritmoGrosor.Discontinua
            Case OpcionesBE.AlgoritmoGrosor.Extensiones
                For i = 1 To 4
                    PintarSimetricamente(x, y + i - 3, xi, yi, Color.Blue, plano1)
                Next
                PintarSimetricamente(x, y, xi, yi, Color.Black, plano1)
            Case OpcionesBE.AlgoritmoGrosor.Arcos
                PintarSimetricamente(x, y, xi, yi, Color.Black, plano1)
                Dim nuevo As Color
                For i = 1 To 5
                    nuevo = plano1.GetPixel(xi + x, yi + y - i)
                    If nuevo.A = Color.Black.A AndAlso nuevo.R = Color.Black.R AndAlso nuevo.G = Color.Black.G AndAlso nuevo.B = Color.Black.B Then
                        Exit For
                    End If
                    PintarSimetricamente(x, y - i, xi, yi, Color.Blue, plano1)
                Next
            Case OpcionesBE.AlgoritmoGrosor.Pincel
        End Select


        While x < y
            x = x + 1
            If p < 0 Then
                p = p + 2 * x + 1
            Else
                y = y - 1
                p = p + 2 * (x - y) + 1
            End If

            Select Case tipogrosor
                Case OpcionesBE.AlgoritmoGrosor.Discontinua
                    If j < 3 Then
                        PintarSimetricamente(x, y, xi, yi, Color.Black, plano1)
                        j = j + 1
                    Else : j = 0
                    End If
                Case OpcionesBE.AlgoritmoGrosor.Extensiones
                    For i = 1 To 4
                        PintarSimetricamente(x, y + i - 3, xi, yi, Color.Blue, plano1)
                    Next
                    PintarSimetricamente(x, y, xi, yi, Color.Black, plano1)
                Case OpcionesBE.AlgoritmoGrosor.Arcos
                    Dim nuevo As Color
                    PintarSimetricamente(x, y, xi, yi, Color.Black, plano1)
                    For i = 1 To 5
                        nuevo = plano1.GetPixel(xi + x, yi + y - i)
                        If nuevo.A = Color.Black.A AndAlso nuevo.R = Color.Black.R AndAlso nuevo.G = Color.Black.G AndAlso nuevo.B = Color.Black.B Then
                            Exit For
                        End If
                        PintarSimetricamente(x, y - i, xi, yi, Color.Blue, plano1)
                    Next
                Case OpcionesBE.AlgoritmoGrosor.Pincel
                    For i = -1 To 1
                        For j = -1 To 1
                            PintarSimetricamente_Pincel(x + j, y + i, xi, yi, Color.Blue, plano1)
                        Next
                    Next
            End Select

        End While
        Return plano1
    End Function
End Class

Public Class Elipse
    Public Shared Function Elipse(Rx As Int32, Ry As Int32, oColor As Color, Panel1 As Bitmap)
        Dim plano = New Bitmap(Panel1)

        Dim p, px, py, x, y As Integer
        Dim Ry2, Rx2, twoRx2, twoRy2 As Integer

        Ry2 = Ry * Ry
        Rx2 = Rx * Rx

        twoRx2 = 2 * Rx2
        twoRy2 = 2 * Ry2

        x = 0
        y = Ry

        PintarSimetricamente(x, y, oColor, plano)
        p = Math.Round(Ry2 - (Rx2 * Ry) + (0.25 * Rx2))
        px = 0
        py = twoRx2 * y

        While px < py
            x = x + 1
            px = px + twoRy2
            If p >= 0 Then
                y = y - 1
                py = py - twoRx2
            End If

            If p < 0 Then
                p = p + Ry2 + px
            Else
                p = p + Ry2 + px - py
            End If

            PintarSimetricamente(x, y, oColor, plano)
        End While

        p = Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2)

        While y > 0
            y = y - 1
            py = py - twoRx2
            If p <= 0 Then
                x = x + 1
                px = px + twoRy2
            End If

            If p > 0 Then
                p = p + Rx2 - py
            Else
                p = p + Rx2 - py + px
            End If
            PintarSimetricamente(x, y, oColor, plano)
        End While

        Return plano
    End Function

    Public Shared Sub PintarSimetricamente(x As Integer, y As Integer, oColor As Color, plano1 As Bitmap)
        Dim xn As Integer = plano1.Width / 2 : Dim yn As Integer = plano1.Height / 2

        If FuncionesBE.ValidarCoordenadas(xn + x, yn + y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn + x, yn + y, oColor)
        If FuncionesBE.ValidarCoordenadas(xn - x, yn + y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn - x, yn + y, oColor)
        If FuncionesBE.ValidarCoordenadas(xn + x, yn - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn + x, yn - y, oColor)
        If FuncionesBE.ValidarCoordenadas(xn - x, yn - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn - x, yn - y, oColor)
    End Sub

    Public Shared Sub PintarSimetricamente1(x As Integer, y As Integer, xn As Integer, yn As Integer, oColor As Color, plano1 As Bitmap)
        If FuncionesBE.ValidarCoordenadas(xn + x, yn + y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn + x, yn + y, oColor)
        If FuncionesBE.ValidarCoordenadas(xn - x, yn + y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn - x, yn + y, oColor)
        If FuncionesBE.ValidarCoordenadas(xn + x, yn - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn + x, yn - y, oColor)
        If FuncionesBE.ValidarCoordenadas(xn - x, yn - y, plano1.Width, plano1.Height) Then plano1.SetPixel(xn - x, yn - y, oColor)
    End Sub

    Public Shared Function Elipse_Libre(xn As Integer, yn As Integer, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, oColor As Color, Panel1 As Bitmap)
        Dim plano = New Bitmap(Panel1)

        Dim p, px, py, x, y As Double
        Dim Ry2, Rx2, twoRx2, twoRy2 As Double
        Dim Rx, Ry As Integer
        If xn < x1 Then
            Rx = FuncionesBE.Distancia_entre_2_puntos(xn, yn, x1, y1)
            Ry = FuncionesBE.Distancia_entre_2_puntos(xn, yn, x2, y2)
        ElseIf yn < y1 Then
            Ry = FuncionesBE.Distancia_entre_2_puntos(xn, yn, x1, y1)
            Rx = FuncionesBE.Distancia_entre_2_puntos(xn, yn, x2, y2)
        End If

        'Dim Ry = FuncionesBE.Distancia_entre_2_puntos(x1, y1, xn, yn)
        'Dim Rx = FuncionesBE.Distancia_entre_2_puntos(x2, y2, xn, yn)

       

        Ry2 = Ry * Ry
        Rx2 = Rx * Rx

        twoRx2 = 2 * Rx2
        twoRy2 = 2 * Ry2

        x = 0
        y = Ry

        PintarSimetricamente1(CInt(x), CInt(y), CInt(xn), CInt(yn), oColor, plano)
        p = Math.Round(Ry2 - (Rx2 * Ry) + (0.25 * Rx2))
        px = 0
        py = twoRx2 * y

        While px < py
            x = x + 1
            px = px + twoRy2
            If p >= 0 Then
                y = y - 1
                py = py - twoRx2
            End If

            If p < 0 Then
                p = p + Ry2 + px
            Else
                p = p + Ry2 + px - py
            End If
            
            PintarSimetricamente1(CInt(x), CInt(y), CInt(xn), CInt(yn), oColor, plano)
        End While

        p = Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2)

        While y > 0
            y = y - 1
            py = py - twoRx2
            If p <= 0 Then
                x = x + 1
                px = px + twoRy2
            End If

            If p > 0 Then
                p = p + Rx2 - py
            Else
                p = p + Rx2 - py + px
            End If
            PintarSimetricamente1(CInt(x), CInt(y), CInt(xn), CInt(yn), oColor, plano)
        End While

        Return plano
    End Function
End Class

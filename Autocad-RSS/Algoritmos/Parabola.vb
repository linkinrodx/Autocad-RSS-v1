Public Class Parabola

    Public Shared Function GenerarParabola(xi As Integer, yi As Integer, plano As Bitmap)
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim x = 0, y = 0, p = 1
        Dim d As Integer

        While x < 150
            x = x + 1
            If p > 0 Then
                y = y + 1
                p = p - 2 * y + 1
            Else
                p = p + 1
                d = y

                If FuncionesBE.ValidarCoordenadas(x + xi, y + yi, plano1.Width, plano1.Height) Then plano1.SetPixel(x + xi, y + yi, CirculoBE.Color)
                If FuncionesBE.ValidarCoordenadas(x + xi, y + yi - (2 * d), plano1.Width, plano1.Height) Then plano1.SetPixel(x + xi, y + yi - (2 * d), CirculoBE.Color)
            End If
        End While
        Return plano1
    End Function


    Public Shared Function GenerarHiperbole(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap)
        Dim plano1 As Bitmap = New Bitmap(plano)

        Dim x, y As Integer
        Dim xc = xi, yc = yi
        Dim a = xf, b = yf
        Dim d, fx, fy As Double

        d = Math.Pow(b, 2) * Math.Pow(a + 0.5, 2) - Math.Pow(a, 2) - (Math.Pow(a, 2) * Math.Pow(b, 2))
        x = a : y = 0
        fx = 2 * Math.Pow(b, 2) * a
        fy = 0

        While Math.Abs(fy) < fx
            If d >= 0 Then
                d = d - Math.Pow(a, 2) * (2 * y + 3)
            Else
                d = d - Math.Pow(a, 2) * (2 * y + 3) + Math.Pow(b, 2) * (2 * x + 2)
                x = x + 1
                fx = fx + 2 * Math.Pow(b, 2)
            End If
            y = y + 1
            fy = fy + 2 * Math.Pow(a, 2)

            PintarSimetri(x, y, xc, yc, plano1)
        End While
        Return plano1
    End Function

    Private Shared Sub PintarSimetri(x As Integer, y As Integer, xc As Integer, yc As Integer, plano1 As Bitmap)
        If FuncionesBE.ValidarCoordenadas(x + xc, -y + yc, plano1.Width, plano1.Height) Then plano1.SetPixel(x + xc, -y + yc, CirculoBE.Color)
        If FuncionesBE.ValidarCoordenadas(x + xc, y + yc, plano1.Width, plano1.Height) Then plano1.SetPixel(x + xc, y + yc, CirculoBE.Color)
        If FuncionesBE.ValidarCoordenadas(-x + xc, -y + yc, plano1.Width, plano1.Height) Then plano1.SetPixel(-x + xc, -y + yc, CirculoBE.Color)
        If FuncionesBE.ValidarCoordenadas(-x + xc, y + yc, plano1.Width, plano1.Height) Then plano1.SetPixel(-x + xc, y + yc, CirculoBE.Color)
    End Sub
    
End Class

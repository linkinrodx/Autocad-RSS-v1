Public Class Linea
    Public Shared Function Generar_Linea(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap)
        Select Case LineaBE.Algoritmo
            Case OpcionesBE.AlgoritmoLinea.Directo
                Return LineaDirecto_Libre(xi, yi, xf, yf, plano)
            Case OpcionesBE.AlgoritmoLinea.ADDSimple
                Return LineaADDSimple_Libre(xi, yi, xf, yf, plano)
            Case OpcionesBE.AlgoritmoLinea.ADDEntero
                Return LineaADDEntero_Libre(xi, yi, xf, yf, plano)
            Case OpcionesBE.AlgoritmoLinea.Bresenham
                Return LineaBresenham_Libre(xi, yi, xf, yf, plano)
            Case Else
                Return Nothing
        End Select
    End Function

    Public Shared Function LineaBresenham_Coordenadas(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano, 600, 500)
        Dim x, y, dx, dy, p, xend As Integer

        dx = Math.Abs(xf - xi)
        dy = Math.Abs(yf - yi)
        p = 2 * dy - dx

        If (xi > xf) Then
            x = xf
            y = yf
            xend = xi
        Else
            x = xi
            y = yi
            xend = xf
        End If
        plano1.SetPixel(x + 300, 250 - y, LineaBE.Color)
        While (x < xend)
            x = x + 1
            If (p < 0) Then
                p = p + 2 * dy
            Else
                y = y + 1
                p = p + 2 * (dy - dx)
            End If
            plano1.SetPixel(x + 300, 250 - y, LineaBE.Color)
        End While
        Return plano1
    End Function

    Public Shared Function LineaDirecto_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        'xi -= 300 : yi = (yi - 250) * -1
        'xf -= 300 : yf = (yf - 250) * -1
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim x, y, dx, dy As Integer
        Dim m, b, x1, y1 As Double

        dx = xf - xi
        dy = yf - yi
        m = dy / dx

        If ((Math.Abs(m) < 1) AndAlso (xi > xf)) OrElse ((Math.Abs(m) > 1) AndAlso (yi > yf)) Then
            Dim aux As Integer
            aux = xi
            xi = xf
            xf = aux
            aux = yi
            yi = yf
            yf = aux
        End If

        If ValidarCoordenadas(xi, yi, plano1.Width, plano1.Height) Then plano1.SetPixel(xi, yi, LineaBE.Color)

        If Math.Abs(m) < 1 Then
            b = CDbl(yi) - (m * CDbl(xi))
            x = xi
            Dim i = 1
            While x + i <= xf
                y1 = m * (CDbl(x) + CDbl(i)) + b
                y = Convert.ToInt32(Math.Round(y1))
                If ValidarCoordenadas(x + i, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x + i, y, LineaBE.Color)
                i = i + 1
            End While
        Else
            b = CDbl(yi) - (m * CDbl(xi))
            y = yi
            Dim i = 1
            While (y + i) <= yf
                x1 = (CDbl(y) + CDbl(i) - b) / m
                x = Convert.ToInt32(Math.Round(x1))
                If ValidarCoordenadas(x, (y + i), plano1.Width, plano1.Height) Then plano1.SetPixel(x, (y + i), LineaBE.Color)
                i = i + 1
            End While
        End If
        Return plano1
    End Function

    Public Shared Function LineaADDSimple_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim x, y, dx, dy As Integer
        Dim m, x1, y1 As Double

        dx = xf - xi
        dy = yf - yi
        m = dy / dx

        If ((Math.Abs(m) < 1) AndAlso (xi > xf)) OrElse ((Math.Abs(m) > 1) AndAlso (yi > yf)) Then
            Dim aux As Integer
            aux = xi
            xi = xf
            xf = aux
            aux = yi
            yi = yf
            yf = aux
        End If

        If ValidarCoordenadas(xi, yi, plano1.Width, plano1.Height) Then plano1.SetPixel(xi, yi, LineaBE.Color)

        If Math.Abs(m) < 1 Then
            y1 = yi
            For x = xi + 1 To xf
                y1 = y1 + m
                y = Convert.ToInt32(Math.Round(y1))
                If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
            Next
        Else
            Dim m1 As Double
            m1 = 1 / m
            x1 = xi
            For y = yi + 1 To yf
                x1 = x1 + m1
                x = Convert.ToInt32(Math.Round(x1))
                If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
            Next
        End If
        Return plano1
    End Function

    Public Shared Function LineaADDEntero_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim x, y, dx, dy As Integer
        Dim m As Double

        If yi > yf Then
            Dim aux
            aux = xi
            xi = xf
            xf = aux
            aux = yi
            yi = yf
            yf = aux
        End If
        Dim error1 = 0

        dx = xf - xi
        dy = yf - yi
        m = dy / dx
        x = xi
        y = yi

        If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)

        If dx > 0 AndAlso dy > 0 AndAlso dx > dy Then
            While x <= xf
                If error1 < 0 Then
                    x = x + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + dy
                Else
                    x = x + 1
                    y = y + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + (dy - dx)
                End If
            End While

        ElseIf dx > 0 AndAlso dy > 0 AndAlso dx < dy Then
            While y <= yf
                If error1 < 0 Then
                    x = x + 1
                    y = y + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + (dy - dx)
                Else
                    y = y + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 - dx
                End If
            End While

        ElseIf dx < 0 AndAlso dy > 0 AndAlso dy < -dx Then
            While x > xf
                If error1 < 0 Then
                    x = x - 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + dy
                Else
                    x = x - 1
                    y = y + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + (dy + dx)
                End If
            End While

        ElseIf dx < 0 AndAlso dy > 0 AndAlso -dx < dy Then
            While y < yf
                If error1 < 0 Then
                    x = x - 1
                    y = y + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + (dy + dx)
                Else
                    y = y + 1
                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                    error1 = error1 + (dx)
                End If
            End While
        End If


        Return plano1
    End Function

    Public Shared Function LineaBresenham_Libre(xi As Integer, yi As Integer, xf As Integer, yf As Integer, plano As Bitmap) As Bitmap
        Dim plano1 As Bitmap = New Bitmap(plano)
        Dim x, y, dx, dy, p, xend, yend As Integer

        dx = Math.Abs(xf - xi)
        dy = Math.Abs(yf - yi)
        Dim m = dy / dx

        p = 2 * dy - dx

        If xi > xf Then
            x = xf
            y = yf
            xend = xi
            yend = yi
        Else
            x = xi
            y = yi
            xend = xf
            yend = yf
        End If

        If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)

        If m < 1 Then
            While (x < xend)
                x = x + 1
                If y < yend Then
                    If (p < 0) Then
                        p = p + 2 * dy
                    Else
                        y = y + 1
                        p = p + 2 * (dy - dx)
                    End If
                Else
                    If (p < 0) Then
                        p = p + 2 * dy
                    Else
                        y = y - 1
                        p = p + 2 * (dy - dx)
                    End If
                End If
                If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
            End While
        Else
            If y > yend Then
                While (y > yend)
                    y = y - 1
                    If x < xend Then
                        If (p < 0) Then
                            p = p + 2 * dx
                        Else
                            x = x + 1
                            p = p + 2 * (dx - dy)
                        End If
                    Else
                        If (p < 0) Then
                            p = p + 2 * dx
                        Else
                            x = x - 1
                            p = p + 2 * (dx - dy)
                        End If
                    End If

                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                End While
            Else
                While (y < yend)
                    y = y + 1
                    If x < xend Then
                        If (p < 0) Then
                            p = p + 2 * dx
                        Else
                            x = x + 1
                            p = p + 2 * (dx - dy)
                        End If
                    Else
                        If (p < 0) Then
                            p = p + 2 * dx
                        Else
                            x = x - 1
                            p = p + 2 * (dx - dy)
                        End If
                    End If

                    If ValidarCoordenadas(x, y, plano1.Width, plano1.Height) Then plano1.SetPixel(x, y, LineaBE.Color)
                End While
            End If
        End If

        Return plano1
    End Function

    Public Shared Function ValidarCoordenadas(x, y, xmax, ymax) As Boolean
        If x >= xmax Then Return False
        If x < 0 Then Return False

        If y >= ymax Then Return False
        If y < 0 Then Return False
        Return True
    End Function
End Class

Public Class Bezier

    Public Shared Function GenerarCurva(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, x3 As Integer, y3 As Integer, x4 As Integer, y4 As Integer, fondo As Bitmap)
        Dim xt, yt As Integer
        Dim fondo2 = New Bitmap(fondo)
        Dim d As Double = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)) + Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2)) + Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2))

        For t = 0 To 1 Step 1 / d
            xt = CInt(Math.Pow(1 - t, 3) * x1 + 3 * t * Math.Pow(1 - t, 2) * x2 + 3 * Math.Pow(t, 2) * (1 - t) * x3 + Math.Pow(t, 3) * x4)
            yt = CInt(Math.Pow(1 - t, 3) * y1 + 3 * t * Math.Pow(1 - t, 2) * y2 + 3 * Math.Pow(t, 2) * (1 - t) * y3 + Math.Pow(t, 3) * y4)

            If FuncionesBE.ValidarCoordenadas(xt, yt, fondo2.Width, fondo2.Height) Then fondo2.SetPixel(xt, yt, CirculoBE.Color)
        Next
        Return fondo2
    End Function

    Public Shared Function GenerarCurva1(x1 As Double, y1 As Double, x2 As Double, y2 As Double, x3 As Double, y3 As Double, x4 As Double, y4 As Double, fondo As Bitmap)
        x1 += 300 : y1 = (y1 - 250) * -1
        x2 += 300 : y2 = (y2 - 250) * -1
        x3 += 300 : y3 = (y3 - 250) * -1
        x4 += 300 : y4 = (y4 - 250) * -1

        Dim xt, yt As Integer
        Dim fondo2 = New Bitmap(fondo)
        Dim d As Double = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)) + Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2)) + Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2))

        For t = 0 To 1 Step 1 / d
            xt = CInt(Math.Pow(1 - t, 3) * x1 + 3 * t * Math.Pow(1 - t, 2) * x2 + 3 * Math.Pow(t, 2) * (1 - t) * x3 + Math.Pow(t, 3) * x4)
            yt = CInt(Math.Pow(1 - t, 3) * y1 + 3 * t * Math.Pow(1 - t, 2) * y2 + 3 * Math.Pow(t, 2) * (1 - t) * y3 + Math.Pow(t, 3) * y4)

            If FuncionesBE.ValidarCoordenadas(xt, yt, fondo2.Width, fondo2.Height) Then fondo2.SetPixel(xt, yt, CirculoBE.Color)
        Next
        Return fondo2
    End Function

    Public Shared Function GenerarBicubica(fondo As Bitmap) As List(Of Integer)
        Dim listaX As List(Of List(Of Double)) = New List(Of List(Of Double))
        Dim ResX As List(Of Double) = New List(Of Double)

        Dim M = FuncionesBE.MatrizBezier ' M
        Dim o1 = FuncionesBE.ListaEjemplo1x ' Bx

        Dim o2 = FuncionesBE.MultiplicacionLista2(M, o1, 4) ' M * Bx
        Dim o4 = FuncionesBE.MultiplicacionLista2(o2, M, 4) ' M*Bx*M(T)

        For i = 1 To 6 ' S*M*Bx*M(T)
            Dim s = FuncionesBE.MatrizS(i)
            Dim o5 = FuncionesBE.MultiplicacionLista2(s, o4, 4)
            listaX.Add(o5)
        Next
        For Each x In listaX ' S*M*Bx*M(T)*t
            For j = 1 To 6
                Dim t = FuncionesBE.MatrizS(j, 4)
                Dim o6 = FuncionesBE.MultiplicacionLista2(x, t, 4)
                ResX.Add(o6.Item(0))
            Next
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim listaY As List(Of List(Of Double)) = New List(Of List(Of Double))
        Dim ResY As List(Of Double) = New List(Of Double)
        Dim u1 = FuncionesBE.ListaEjemplo1y

        Dim u2 = FuncionesBE.MultiplicacionLista2(M, u1, 4)
        Dim u4 = FuncionesBE.MultiplicacionLista2(u2, M, 4)

        For i = 1 To 6
            Dim s = FuncionesBE.MatrizS(i)
            Dim u5 = FuncionesBE.MultiplicacionLista2(s, u4, 4)
            listaY.Add(u5)
        Next
        For Each y In listaY
            For k = 1 To 6
                Dim t = FuncionesBE.MatrizS(k, 4)
                Dim u6 = FuncionesBE.MultiplicacionLista2(y, t, 4)
                ResY.Add(u6.Item(0))
            Next
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim ultimalista = New List(Of Integer)
        For s = 0 To ResX.Count - 1
            ultimalista.Add(ResX.Item(s))
            ultimalista.Add(ResY.Item(s))
        Next

        Return ultimalista
    End Function
End Class

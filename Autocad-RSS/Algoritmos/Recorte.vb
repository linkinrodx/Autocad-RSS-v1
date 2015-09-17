Public Class Recorte

    Public Shared Function Evalua_Punto(x As Integer, y As Integer, xmin As Integer, ymin As Integer, xmax As Integer, ymax As Integer)
        Dim resultado = New List(Of Boolean)

        If x < xmax Then
            If x > xmin Then
                If y < ymax Then
                    If y > ymin Then
                        resultado(0) = False
                        resultado(1) = False
                        resultado(2) = False
                        resultado(3) = False
                    Else
                        resultado(0) = False
                        resultado(1) = True
                        resultado(2) = False
                        resultado(3) = False
                    End If
                Else
                    resultado(0) = True
                    resultado(1) = False
                    resultado(2) = False
                    resultado(3) = False
                End If
            Else
                If y < ymax Then
                    If y > ymin Then
                        resultado(0) = False
                        resultado(1) = False
                        resultado(2) = False
                        resultado(3) = True
                    Else
                        resultado(0) = False
                        resultado(1) = True
                        resultado(2) = False
                        resultado(3) = True
                    End If
                Else
                    resultado(0) = True
                    resultado(1) = False
                    resultado(2) = False
                    resultado(3) = True
                End If
            End If
        Else
            If y < ymax Then
                If y > ymin Then
                    resultado(0) = False
                    resultado(1) = False
                    resultado(2) = True
                    resultado(3) = False
                Else
                    resultado(0) = False
                    resultado(1) = True
                    resultado(2) = True
                    resultado(3) = False
                End If
            Else
                resultado(0) = True
                resultado(1) = False
                resultado(2) = True
                resultado(3) = False
            End If
        End If
        Return resultado
    End Function

    Public Shared Function Recorte_Punto(x As Integer, y As Integer, xmin As Integer, ymin As Integer, xmax As Integer, ymax As Integer, m As Double)
        Dim resultado = New List(Of Double)

        If x < xmax Then
            If x > xmin Then
                If y < ymax Then
                    If y > ymin Then
                        resultado(0) = x
                        resultado(1) = y
                    Else
                        resultado(0) = (1 / m) * (ymin - y) + x
                        resultado(1) = ymin
                        If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                            resultado(2) = 1
                        End If
                    End If
                Else
                    resultado(0) = (1 / m) * (ymax - y) + x
                    resultado(1) = ymax
                    If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                        resultado(2) = 1
                    End If
                End If
            Else
                If y < ymax Then
                    If y > ymin Then
                        resultado(0) = xmin
                        resultado(1) = m * (xmin - x) + y
                        If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                            resultado(2) = 1
                        End If
                    Else
                        resultado(0) = (1 / m) * (ymin - y) + x
                        resultado(1) = ymin
                        If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                            resultado(0) = xmin
                            resultado(1) = m * (xmin - x) + y
                            If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                                resultado(2) = 1
                            End If
                        End If
                    End If
                Else
                    resultado(0) = (1 / m) * (ymax - y) + x
                    resultado(1) = ymax
                    If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                        resultado(0) = xmin
                        resultado(1) = m * (xmin - x) + y
                        If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                            resultado(2) = 1
                        End If
                    End If
                End If
            End If
        Else
            If y < ymax Then
                If y > ymin Then
                    resultado(0) = xmax
                    resultado(1) = m * (xmax - x) + y
                    If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                        resultado(2) = 1
                    End If
                Else
                    resultado(0) = (1 / m) * (ymin - y) + x
                    resultado(1) = ymin
                    If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                        resultado(0) = xmax
                        resultado(1) = m * (xmax - x) + y
                        If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                            resultado(2) = 1
                        End If
                    End If
                End If
            Else
                resultado(0) = (1 / m) * (ymax - y) + x
                resultado(1) = ymax
                If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                    resultado(0) = xmax
                    resultado(1) = m * (xmax - x) + y
                    If resultado(0) > xmax OrElse resultado(0) < xmin OrElse resultado(1) > ymax OrElse resultado(1) < ymin Then
                        resultado(2) = 1
                    End If
                End If
            End If
        End If
        Return resultado
    End Function
End Class

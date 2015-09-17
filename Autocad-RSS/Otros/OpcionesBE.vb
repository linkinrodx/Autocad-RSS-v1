Public Class OpcionesBE
    Public Enum TipoDibujo
        Nada = 0
        Linea = 1
        PoliLinea = 2
        Circulo = 3
        Arco = 4
        Elipse = 5
        Pincel = 6
        Cuadrado = 7
        Triangulo = 8
        Ventaneo = 11
        Traslacion = 12
        Rotacion = 13
        Bezier = 14
        Parabola = 15
        Hiperbole = 16
        Bicubica = 17
        RecorteLineas = 18
        Reflexion = 19
        Dibujo = 20
    End Enum

    Public Enum AlgoritmoLinea
        Directo = 0
        ADDSimple = 1
        ADDEntero = 2
        Bresenham = 3
    End Enum

    Public Enum AlgoritmoCirculo
        Implicito = 0
        Incremental = 1
        Bresenham = 2
        Polar = 3
    End Enum

    Public Enum AlgoritmoElipse
        Bresenham = 0
    End Enum

    Public Enum AlgoritmoGrosor
        Discontinua = 0
        Extensiones = 1
        Arcos = 2
        Pincel = 3
    End Enum

    Public Shared Sub LlenarComboLinea(combo As ComboBox)
        combo.Items.Insert(0, "Metodo Directo")
        combo.Items.Insert(1, "ADD Simple")
        combo.Items.Insert(2, "ADD Entero")
        combo.Items.Insert(3, "Bresenham")
        combo.SelectedIndex = LineaBE.Algoritmo
    End Sub

    Public Shared Sub LlenarComboCirculo(combo As ComboBox)
        combo.Items.Insert(0, "Metodo Implicito")
        combo.Items.Insert(1, "Metodo Incremental")
        combo.Items.Insert(2, "Bresenham")
        combo.Items.Insert(3, "Polar")
        combo.SelectedIndex = CirculoBE.Algoritmo
    End Sub

    Public Shared Sub LlenarComboElipse(combo As ComboBox)
        combo.Items.Insert(0, "Bresenham")
        combo.SelectedIndex = ElipseBE.Algoritmo
    End Sub

    Public Shared Sub LlenarComboGrosor1(combo As ComboBox)
        combo.Items.Insert(0, "Discontinua")
        combo.Items.Insert(1, "Extensiones")
        combo.Items.Insert(2, "Arcos")
        combo.Items.Insert(3, "Pincel")
        combo.SelectedIndex = LineaBE.Grosor
    End Sub

    Public Shared Sub LlenarComboGrosor2(combo As ComboBox)
        combo.Items.Insert(0, "Discontinua")
        combo.Items.Insert(1, "Extensiones")
        combo.Items.Insert(2, "Arcos")
        combo.Items.Insert(3, "Pincel")
        combo.SelectedIndex = CirculoBE.Grosor
    End Sub

    Public Shared Sub LlenarComboGrosor3(combo As ComboBox)
        combo.Items.Insert(0, "Discontinua")
        combo.Items.Insert(1, "Extensiones")
        combo.Items.Insert(2, "Arcos")
        combo.Items.Insert(3, "Pincel")
        combo.SelectedIndex = ElipseBE.Grosor
    End Sub

    Public Shared Sub LlenarComboGrosor4(combo As ComboBox)
        combo.Items.Insert(0, "Discontinua")
        combo.Items.Insert(1, "Extensiones")
        combo.Items.Insert(2, "Arcos")
        combo.Items.Insert(3, "Pincel")
        combo.SelectedIndex = PincelBE.Grosor
    End Sub

    Public Shared Sub LlenarComboColor1(combo As ComboBox)
        combo.Items.Insert(0, "Rojo")
        combo.Items.Insert(1, "Azul")
        combo.Items.Insert(2, "Verde")
        combo.Items.Insert(3, "Negro")
        combo.Items.Insert(4, "Amarillo")
        combo.SelectedIndex = LineaBE.IntColor
    End Sub

    Public Shared Sub LlenarComboColor2(combo As ComboBox)
        combo.Items.Insert(0, "Rojo")
        combo.Items.Insert(1, "Azul")
        combo.Items.Insert(2, "Verde")
        combo.Items.Insert(3, "Negro")
        combo.Items.Insert(4, "Amarillo")
        combo.SelectedIndex = CirculoBE.IntColor
    End Sub

    Public Shared Sub LlenarComboColor3(combo As ComboBox)
        combo.Items.Insert(0, "Rojo")
        combo.Items.Insert(1, "Azul")
        combo.Items.Insert(2, "Verde")
        combo.Items.Insert(3, "Negro")
        combo.Items.Insert(4, "Amarillo")
        combo.SelectedIndex = ElipseBE.IntColor
    End Sub

    Public Shared Sub LlenarComboColor4(combo As ComboBox)
        combo.Items.Insert(0, "Rojo")
        combo.Items.Insert(1, "Azul")
        combo.Items.Insert(2, "Verde")
        combo.Items.Insert(3, "Negro")
        combo.Items.Insert(4, "Amarillo")
        combo.SelectedIndex = PincelBE.IntColor
    End Sub
End Class

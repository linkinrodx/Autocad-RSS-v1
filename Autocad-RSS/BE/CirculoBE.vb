Public MustInherit Class CirculoBE
    Private Shared oColor As Color = Drawing.Color.Blue
    Private Shared oIntColor As Integer
    Private Shared oAlgoritmo As Integer
    Private Shared oGrosor As Integer
    Private Shared oTamaño As Integer = 1
    Private Shared oListaPuntos As List(Of Integer)

    Public Shared Property Color As Color
        Get
            Return oColor
        End Get
        Set(ByVal value As Color)
            oColor = value
        End Set
    End Property

    Public Shared Property ListaPuntos As List(Of Integer)
        Get
            Return oListaPuntos
        End Get
        Set(ByVal value As List(Of Integer))
            oListaPuntos = value
        End Set
    End Property

    Public Shared Property Algoritmo As Integer
        Get
            Return oAlgoritmo
        End Get
        Set(ByVal value As Integer)
            oAlgoritmo = value
        End Set
    End Property

    Public Shared Property Grosor As Integer
        Get
            Return oGrosor
        End Get
        Set(ByVal value As Integer)
            oGrosor = value
        End Set
    End Property

    Public Shared Property Tamaño As Integer
        Get
            Return oTamaño
        End Get
        Set(ByVal value As Integer)
            oTamaño = value
        End Set
    End Property

    Public Shared Property IntColor As Integer
        Get
            If Color = Drawing.Color.Red Then
                oIntColor = 0
            ElseIf Color = Drawing.Color.Blue Then
                oIntColor = 1
            ElseIf Color = Drawing.Color.Green Then
                oIntColor = 2
            ElseIf Color = Drawing.Color.Black Then
                oIntColor = 3
            ElseIf Color = Drawing.Color.Yellow Then
                oIntColor = 4
            End If

            Return oIntColor
        End Get
        Set(ByVal value As Integer)
            oIntColor = value
        End Set
    End Property
End Class

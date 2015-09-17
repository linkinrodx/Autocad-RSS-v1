Public Class FormMain
    Dim oCoordenadasPuntos As List(Of Decimal) = New List(Of Decimal)
    Dim oNuevaCoordenadasPuntos As List(Of Integer) = New List(Of Integer)
    Dim oListaCoordenadas As List(Of Integer) = New List(Of Integer)
    Dim oListaRecta As List(Of Integer) = New List(Of Integer)
    Dim oListaAnimacion As List(Of Decimal) = New List(Of Decimal)
    Dim oListaAnimacion1 As List(Of Decimal) = New List(Of Decimal)

    Dim oDibujoSelect As Integer = OpcionesBE.TipoDibujo.Nada
    Dim eventoclick As Boolean = False
    Dim Panel3 As Bitmap = FuncionesBE.MarcarCoordenadas(600, 500)
    Dim Panel4 As Bitmap = FuncionesBE.MarcarCoordenadas(300, 250)

    Public Sub New()
        InitializeComponent()
        InicializarData()
    End Sub

    Private Sub InicializarData()
        Panel1.BackgroundImage = FuncionesBE.MarcarCoordenadas(Panel1.Width, Panel1.Height)
        Panel2.BackgroundImage = FuncionesBE.MarcarCoordenadas(Panel2.Width, Panel2.Height)
    End Sub

    Private Sub GenerarLinea()
        Dim xi = CInt(TextBox1.Text) : Dim yi = CInt(TextBox2.Text)
        Dim xf = CInt(TextBox3.Text) : Dim yf = CInt(TextBox4.Text)

        Panel1.BackgroundImage = Linea.LineaBresenham_Coordenadas(xi, yi, xf, yf, Panel1.BackgroundImage)
    End Sub

    Private Sub GenerarCirculo()
        Dim r = CInt(TextBox5.Text)
        If RadioButton1.Checked = True Then
            Panel1.BackgroundImage = Circulo.CirculoBresenham_Coordenadas_Extensiones(300, 250, r, Panel1.BackgroundImage)
        ElseIf RadioButton2.Checked = True Then
            Panel1.BackgroundImage = Circulo.CirculoBresenham_Coordenadas(300, 250, r - 2, Panel1.BackgroundImage)
            Panel1.BackgroundImage = Circulo.CirculoBresenham_Coordenadas_Arcos(300, 250, r + 2, Panel1.BackgroundImage)
        ElseIf RadioButton3.Checked = True Then
            Panel1.BackgroundImage = Circulo.CirculoBresenham_Coordenadas_Pluma(300, 250, r, Panel1.BackgroundImage)
            Panel1.BackgroundImage = Circulo.CirculoBresenham_Coordenadas_Pluma2(300, 250, r, Panel1.BackgroundImage)
        ElseIf RadioButton7.Checked = True Then
            Panel1.BackgroundImage = Circulo.CirculoBresenham_Coordenadas_Espaciado(300, 250, r, Panel1.BackgroundImage)
        End If
    End Sub

    Private Sub GenerarElipse()
        If TextBox7.Text <> String.Empty AndAlso TextBox8.Text <> String.Empty Then
            Dim rx = CInt(TextBox7.Text) : Dim ry = CInt(TextBox8.Text)

            Panel1.BackgroundImage = Elipse.Elipse(rx, ry, ElipseBE.Color, Panel1.BackgroundImage)
        End If
    End Sub

#Region "Eventos"
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If eventoclick Then
            Dim plano As Bitmap = New Bitmap(Panel1.BackgroundImage)
            Dim k = 10
            For i = -k To k
                For j = -k To k
                    plano.SetPixel(e.X + i, e.Y + j, PincelBE.Color)
                Next
            Next

            Panel1.BackgroundImage = plano
        End If

        If oDibujoSelect = OpcionesBE.TipoDibujo.Dibujo Then
            Dim list = New List(Of Decimal) : Dim x = 0, y = 0
            If e.X > 300 AndAlso e.Y > 250 Then
                x = CInt(TextBox18.Text) : y = CInt(TextBox18.Text)
            ElseIf e.X > 300 AndAlso e.Y < 250 Then
                x = CInt(TextBox18.Text) : y = -CInt(TextBox18.Text)
            ElseIf e.X < 300 AndAlso e.Y < 250 Then
                x = -CInt(TextBox18.Text) : y = -CInt(TextBox18.Text)
            ElseIf e.X < 300 AndAlso e.Y > 250 Then
                x = -CInt(TextBox18.Text) : y = CInt(TextBox18.Text)
            End If

            Dim a = FuncionesBE.GenerarLista(oListaAnimacion)
            Dim o = FuncionesBE.ListaTraslacion(x, y)
            Dim n = FuncionesBE.MultiplicacionLista(a, o)
            Dim m = FuncionesBE.DegenerarLista(n)

            oListaAnimacion = m
            Panel1.BackgroundImage = Panel3

            For i = 0 To m.Count - 3 Step 2
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
            Next
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If oDibujoSelect = OpcionesBE.TipoDibujo.Pincel Then
            oDibujoSelect = OpcionesBE.TipoDibujo.Nada
        End If

        eventoclick = False
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        Select Case oDibujoSelect
            Case OpcionesBE.TipoDibujo.Linea
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 4 Then Exit Sub
                Panel1.BackgroundImage = Linea.Generar_Linea(oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), oListaCoordenadas.Item(2), oListaCoordenadas.Item(3), Panel1.BackgroundImage)
                oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada
            Case OpcionesBE.TipoDibujo.PoliLinea
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 4 Then Exit Sub
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), oListaCoordenadas.Item(2), oListaCoordenadas.Item(3), Panel1.BackgroundImage)
                oListaCoordenadas.RemoveAt(0) : oListaCoordenadas.RemoveAt(0)
                'oDibujoSelect = Funciones.TipoDibujo.Nada
            Case OpcionesBE.TipoDibujo.Circulo
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 4 Then Exit Sub
                Panel1.BackgroundImage = Circulo.Generar_Circulo(oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), oListaCoordenadas.Item(2), oListaCoordenadas.Item(3), Panel1.BackgroundImage)
                oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada
            Case OpcionesBE.TipoDibujo.Arco
            Case OpcionesBE.TipoDibujo.Pincel
                eventoclick = True

            Case OpcionesBE.TipoDibujo.Cuadrado
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 8 Then Exit Sub
                For i = 0 To 5 Step 2
                    Panel1.BackgroundImage = Linea.LineaBresenham_Libre(oListaCoordenadas.Item(i), oListaCoordenadas.Item(i + 1), oListaCoordenadas.Item(i + 2), oListaCoordenadas.Item(i + 3), Panel1.BackgroundImage)
                Next
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(oListaCoordenadas.Item(6), oListaCoordenadas.Item(7), oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), Panel1.BackgroundImage)

                For Each o In oListaCoordenadas
                    oCoordenadasPuntos.Add(o)
                Next

                oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Triangulo
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 6 Then Exit Sub
                For i = 0 To 3 Step 2
                    Panel1.BackgroundImage = Linea.LineaBresenham_Libre(oListaCoordenadas.Item(i), oListaCoordenadas.Item(i + 1), oListaCoordenadas.Item(i + 2), oListaCoordenadas.Item(i + 3), Panel1.BackgroundImage)
                Next
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(oListaCoordenadas.Item(4), oListaCoordenadas.Item(5), oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), Panel1.BackgroundImage)

                For Each o In oListaCoordenadas
                    oCoordenadasPuntos.Add(o)
                Next

                oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Ventaneo
                If oCoordenadasPuntos.Count = 0 Then Exit Sub

                Dim av = Panel1.Width : Dim hv = Panel1.Height
                Dim am = Panel2.Width : Dim hm = Panel2.Height

                For i = 0 To oCoordenadasPuntos.Count - 1 Step 2
                    Dim xn = am / av * (oCoordenadasPuntos.Item(i) - 0) + 0
                    Dim yn = hm / hv * (av - oCoordenadasPuntos.Item(i + 1) - 0) + 0

                    oNuevaCoordenadasPuntos.Add(Math.Round(xn, 0)) : oNuevaCoordenadasPuntos.Add(Math.Round(am - yn, 0))
                Next

                For i = 0 To oNuevaCoordenadasPuntos.Count - 3 Step 2
                    Panel2.BackgroundImage = Linea.LineaBresenham_Libre(oNuevaCoordenadasPuntos.Item(i), oNuevaCoordenadasPuntos.Item(i + 1), oNuevaCoordenadasPuntos.Item(i + 2), oNuevaCoordenadasPuntos.Item(i + 3), Panel2.BackgroundImage)
                Next
                Panel2.BackgroundImage = Linea.LineaBresenham_Libre(oNuevaCoordenadasPuntos.Item(oNuevaCoordenadasPuntos.Count - 2), oNuevaCoordenadasPuntos.Item(oNuevaCoordenadasPuntos.Count - 1), oNuevaCoordenadasPuntos.Item(0), oNuevaCoordenadasPuntos.Item(1), Panel2.BackgroundImage)

                'oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Traslacion
                If oCoordenadasPuntos.Count > 0 Then
                    Dim x = -10 : Dim y = -10 : Dim list = New List(Of Decimal)

                    ''Dim a = FuncionesBE.GenerarArray(oCoordenadasPuntos)
                    ''Dim o = FuncionesBE.MatrizTraslacion(h, v)
                    ''Dim n = FuncionesBE.MultiplicacionMatriz(a, o)

                    Dim a = FuncionesBE.GenerarLista(oCoordenadasPuntos)
                    Dim o = FuncionesBE.ListaTraslacion(x, y)
                    Dim n = FuncionesBE.MultiplicacionLista(a, o)
                    Dim m = FuncionesBE.DegenerarLista(n)

                    For i = 0 To m.Count - 3 Step 2
                        Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
                    Next
                    Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)

                End If

            Case OpcionesBE.TipoDibujo.Rotacion
                If oCoordenadasPuntos.Count > 0 Then
                    Dim alfa = Math.PI : Dim list = New List(Of Decimal) : Dim j = 1

                    For Each x In oCoordenadasPuntos
                        If j Mod 2 <> 0 Then
                            list.Add(x - 300)
                        Else
                            list.Add(250 - x)
                        End If
                        j += 1
                    Next

                    Dim a = FuncionesBE.GenerarLista(list)
                    'Dim o1 = FuncionesBE.ListaTraslacion(-300, -250) : Dim o2 = FuncionesBE.ListaRotacion(alfa) : Dim o3 = FuncionesBE.ListaTraslacion(300, 250)
                    'Dim n1 = FuncionesBE.MultiplicacionLista(o1, o2) : Dim n2 = FuncionesBE.MultiplicacionLista(n1, o3)

                    'Dim n = FuncionesBE.MultiplicacionLista(a, n2)

                    Dim o2 = FuncionesBE.ListaRotacion(alfa)
                    Dim n = FuncionesBE.MultiplicacionLista(a, o2)
                    Dim m = FuncionesBE.DegenerarLista(n)

                    list.Clear()
                    j = 1
                    For Each x In m
                        If j Mod 2 <> 0 Then
                            list.Add(300 + x)
                        Else
                            list.Add(250 - x)
                        End If
                        j += 1
                    Next

                    m = list

                    For i = 0 To m.Count - 3 Step 2
                        Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
                    Next
                    Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)

                End If
            Case OpcionesBE.TipoDibujo.Bezier
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 8 Then Exit Sub
                Panel1.BackgroundImage = Bezier.GenerarCurva(oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), oListaCoordenadas.Item(2), oListaCoordenadas.Item(3), oListaCoordenadas.Item(4), oListaCoordenadas.Item(5), oListaCoordenadas.Item(6), oListaCoordenadas.Item(7), Panel1.BackgroundImage)

                oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Parabola
                Panel1.BackgroundImage = Parabola.GenerarParabola(e.X, e.Y, Panel1.BackgroundImage)

                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Hiperbole
                Panel1.BackgroundImage = Parabola.GenerarHiperbole(e.X, e.Y, 10, 10, Panel1.BackgroundImage)

                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Bicubica
                Dim oLista = Bezier.GenerarBicubica(Panel1.BackgroundImage)

                For i = 0 To oLista.Count - 7 Step 6
                    Panel1.BackgroundImage = Bezier.GenerarCurva1(oLista.Item(i), oLista.Item(i + 1), oLista.Item(i + 2), oLista.Item(i + 3), oLista.Item(i + 4), oLista.Item(i + 5), oLista.Item(i + 6), oLista.Item(i + 7), Panel1.BackgroundImage)
                Next
                'Panel1.BackgroundImage = Bezier.GenerarCurva1(40, 90, 81.92, 90, 123.4, 90, 163.8, 90, Panel1.BackgroundImage)
                'Panel1.BackgroundImage = Bezier.GenerarCurva1(40, 90, 81.92, 90, 123.4, 90, 163.8, 90, Panel1.BackgroundImage)
                'Panel1.BackgroundImage = Bezier.GenerarCurva1(40, 90, 81.92, 90, 123.4, 90, 163.8, 90, Panel1.BackgroundImage)

                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

                'Panel1.BackgroundImage = Bezier.GenerarCurva1(oLista.Item(0), oLista.Item(1), oLista.Item(2), oLista.Item(3), oLista.Item(4), oLista.Item(5), oLista.Item(6), oLista.Item(7), Panel1.BackgroundImage)
                'Dim ox = FuncionesBE.ListaEjemplo1x
                'Dim oy = FuncionesBE.ListaEjemplo1y
                'For i = 0 To 15 Step 4
                '    Panel1.BackgroundImage = Bezier.GenerarCurva1(ox.Item(i), oy.Item(i), ox.Item(i + 1), oy.Item(i + 1), ox.Item(i + 2), oy.Item(i + 2), ox.Item(i + 3), oy.Item(i + 3), Panel1.BackgroundImage)
                'Next
            Case OpcionesBE.TipoDibujo.RecorteLineas
                '    Bitmap recorte = new Bitmap(bitmaps.bitm.limpiar,800,800);
                '    bool[] punto_ini = new bool[4];
                '    bool[] punto_fin = new bool[4];
                '    int[,] punto_inicial = new int[2,1000];
                '    int[,] punto_final = new int[2,1000];
                '    double[] auxiliar = new double[3];
                '    recorte_de_lineas recorte_linea = new recorte_de_lineas();
                '    double m; bool bandera=false

                '    For index = 1 To 10

                '    Next

                '    for (int i = 0; i < cuenta_rectas; i++)
                '    {
                '        punto_ini = recorte_linea.evalua_punto(guarda_puntos_rectas[0, i], guarda_puntos_rectas[1, i], x_min, y_min, x_max, y_max);
                '        punto_fin = recorte_linea.evalua_punto(guarda_puntos_rectas[2, i], guarda_puntos_rectas[3, i], x_min, y_min, x_max, y_max);
                '        //MessageBox.Show(punto_ini[0] + " " + punto_ini[1] + " " + punto_ini[2] + " " + punto_ini[3] + "   " + punto_fin[0] + " " + punto_fin[1] + " " + punto_fin[2] + " " + punto_fin[3]);
                '        if (punto_ini[0] == true && punto_fin[0] == true || punto_ini[1] == true && punto_fin[1] == true || punto_ini[2] == true && punto_fin[2] == true || punto_ini[3] == true && punto_fin[3] == true)
                '        {
                '            //borra linea
                '            //bitmaps.bitm.auxiliar = RECTA.lineab(guarda_puntos_rectas[0, i], guarda_puntos_rectas[1, i], guarda_puntos_rectas[2, i], guarda_puntos_rectas[3, i], guarda_puntos_rectas[4, i], fondo, Color.Empty);
                '            //fondo = bitmaps.bitm.auxiliar;
                '            //this.panel1.BackgroundImage = fondo;
                '        }
                '        Else
                '        {
                '            //recortar las lineas
                '            m = (Convert.ToDouble(guarda_puntos_rectas[3, i]) - Convert.ToDouble(guarda_puntos_rectas[1, i])) / (Convert.ToDouble(guarda_puntos_rectas[2, i]) - Convert.ToDouble(guarda_puntos_rectas[0, i]));
                '            //MessageBox.Show(Convert.ToString(m));
                '            auxiliar = recorte_linea.recorta_punto(guarda_puntos_rectas[0, i], guarda_puntos_rectas[1, i], x_min, y_min, x_max, y_max, m);
                '            if (auxiliar[2] == (double)1)
                '            {
                '                bandera = true;
                '            }
                '            punto_inicial[0, i] = (int)Math.Round(auxiliar[0], 0);
                '            punto_inicial[1, i] = (int)Math.Round(auxiliar[1], 0);
                '            auxiliar = recorte_linea.recorta_punto(guarda_puntos_rectas[2, i], guarda_puntos_rectas[3, i], x_min, y_min, x_max, y_max, m);
                '            if (auxiliar[2] == (double)1)
                '            {
                '                bandera = true;
                '            }
                '            punto_final[0, i] = (int)Math.Round(auxiliar[0], 0);
                '            punto_final[1, i] = (int)Math.Round(auxiliar[1], 0);

                '            if (bandera == true)
                '            {
                '                //bitmaps.bitm.auxiliar = RECTA.lineab(guarda_puntos_rectas[0, i], guarda_puntos_rectas[1, i], guarda_puntos_rectas[2, i], guarda_puntos_rectas[3, i], guarda_puntos_rectas[4, i], recorte, Color.Empty);
                '                //recorte = bitmaps.bitm.auxiliar;
                '                //fondo = recorte;
                '                //this.panel1.BackgroundImage = fondo;
                '            }
                '                    Else
                '            {
                '                bitmaps.bitm.auxiliar = RECTA.lineab(punto_inicial[0, i], punto_inicial[1, i], punto_final[0, i], punto_final[1, i], guarda_puntos_rectas[4, i], recorte, Globales.color);
                '                recorte = bitmaps.bitm.auxiliar;
                '                fondo = recorte;
                '                this.panel1.BackgroundImage = fondo;
                '            }
                '            bandera = false;
                '        }
                '    }
                '}
            Case OpcionesBE.TipoDibujo.Elipse
                oListaCoordenadas.Add(e.X) : oListaCoordenadas.Add(e.Y)
                If oListaCoordenadas.Count <> 6 Then Exit Sub
                Panel1.BackgroundImage = Elipse.Elipse_Libre(oListaCoordenadas.Item(0), oListaCoordenadas.Item(1), oListaCoordenadas.Item(2), oListaCoordenadas.Item(3), oListaCoordenadas.Item(4), oListaCoordenadas.Item(5), ElipseBE.Color, Panel1.BackgroundImage)
                oListaCoordenadas.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada
            Case OpcionesBE.TipoDibujo.Reflexion
                oListaRecta.Add(e.X) : oListaRecta.Add(e.Y)
                If oListaRecta.Count <> 4 Then Exit Sub
                Panel1.BackgroundImage = Linea.Generar_Linea(oListaRecta.Item(0), oListaRecta.Item(1), oListaRecta.Item(2), oListaRecta.Item(3), Panel1.BackgroundImage)
                If oCoordenadasPuntos.Count > 0 Then
                    Dim m = New List(Of Decimal)
                    Dim lista = New List(Of Decimal)
                    For i = 0 To oCoordenadasPuntos.Count - 1
                        If i Mod 2 = 0 Then
                            lista.Add(oCoordenadasPuntos.Item(i) - 300)
                        Else
                            lista.Add((oCoordenadasPuntos.Item(i) - 250) * -1)
                        End If
                    Next

                    Dim listanueva = New List(Of Decimal)
                    For i = 0 To oListaRecta.Count - 1
                        If i Mod 2 = 0 Then
                            listanueva.Add(oListaRecta.Item(i) - 300)
                        Else
                            listanueva.Add((oListaRecta.Item(i) - 250) * -1)
                        End If
                    Next

                    Dim a = FuncionesBE.GenerarLista(lista)

                    Dim o1 = FuncionesBE.ListaTraslacion(-listanueva.Item(0), -listanueva.Item(1))
                    Dim n1 = FuncionesBE.MultiplicacionLista(a, o1)

                    Dim hipo As Integer = FuncionesBE.Distancia_entre_2_puntos(oListaRecta.Item(0), oListaRecta(1), oListaRecta.Item(2), oListaRecta(3))
                    'Dim s = FuncionesBE.ListaAfilamientoY(hipo)
                    'Dim o5 = FuncionesBE.ListaRotacion(45)
                    Dim o5 = FuncionesBE.NuevaListaRotacion((listanueva.Item(2) - listanueva.Item(0)) / hipo, (listanueva.Item(3) - listanueva.Item(1)) / hipo)

                    Dim n2 = FuncionesBE.MultiplicacionLista(n1, o5)
                    Dim o3
                    If listanueva.Item(2) < listanueva.Item(1) Then
                        o3 = FuncionesBE.ListaReflexionX()
                    Else
                        o3 = FuncionesBE.ListaReflexionY()
                    End If

                    Dim n3 = FuncionesBE.MultiplicacionLista(n2, o3)
                    
                    Dim o6 = FuncionesBE.NuevaListaRotacion((listanueva.Item(2) - listanueva.Item(0)) / hipo, (listanueva.Item(3) - listanueva.Item(1)) / hipo)
                    Dim n4 = FuncionesBE.MultiplicacionLista(n3, o6)
                    n4 = FuncionesBE.MultiplicacionLista(n4, o6)
                    n4 = FuncionesBE.MultiplicacionLista(n4, o6)
                    n4 = FuncionesBE.MultiplicacionLista(n4, o6)
                    n4 = FuncionesBE.MultiplicacionLista(n4, o6)
                    n4 = FuncionesBE.MultiplicacionLista(n4, o6)

                    Dim o7 = FuncionesBE.ListaTraslacion(listanueva.Item(0), listanueva.Item(1))
                    Dim n5 = FuncionesBE.MultiplicacionLista(n4, o7)

                    m = FuncionesBE.DegenerarLista(n5)

                    Dim lista1 = New List(Of Decimal)
                    For i = 0 To m.Count - 1
                        If i Mod 2 = 0 Then
                            lista1.Add(m.Item(i) + 300)
                        Else
                            lista1.Add(250 - m.Item(i))
                        End If
                    Next
                    m = lista1

                    For i = 0 To m.Count - 3 Step 2
                        Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
                    Next
                    Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)
                End If


                oListaCoordenadas.Clear()
                oListaRecta.Clear()
                oDibujoSelect = OpcionesBE.TipoDibujo.Nada

            Case OpcionesBE.TipoDibujo.Dibujo
                'Dim list = New List(Of Decimal) : Dim x = 0, y = 0
                'If e.X > 300 AndAlso e.Y > 250 Then
                '    x = CInt(TextBox18.Text) : y = CInt(TextBox18.Text)
                'ElseIf e.X > 300 AndAlso e.Y < 250 Then
                '    x = CInt(TextBox18.Text) : y = -CInt(TextBox18.Text)
                'ElseIf e.X < 300 AndAlso e.Y < 250 Then
                '    x = -CInt(TextBox18.Text) : y = -CInt(TextBox18.Text)
                'ElseIf e.X < 300 AndAlso e.Y > 250 Then
                '    x = -CInt(TextBox18.Text) : y = CInt(TextBox18.Text)
                'End If

                'Dim a = FuncionesBE.GenerarLista(oListaAnimacion)
                'Dim o = FuncionesBE.ListaTraslacion(x, y)
                'Dim n = FuncionesBE.MultiplicacionLista(a, o)
                'Dim m = FuncionesBE.DegenerarLista(n)

                'oListaAnimacion = m
                'Panel1.BackgroundImage = Panel3

                'For i = 0 To m.Count - 3 Step 2
                '    Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
                'Next
                'Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)

        End Select
    End Sub
#End Region

#Region "Barra 1"
    Private Sub ToolOpcionesClick(sender As Object, e As EventArgs) Handles OpcionesToolStripMenuItem.Click
        Me.Enabled = False
        FormOpciones.Show()
    End Sub
#End Region

#Region "Barra 2"
    Private Sub ToolCancelarClick(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Nada
        eventoclick = False
        oListaCoordenadas.Clear()
        oCoordenadasPuntos.Clear()
    End Sub

    Private Sub ToolLineaClick(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Linea
    End Sub

    Private Sub ToolPoliLineaClick(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.PoliLinea
    End Sub

    Private Sub ToolCentroYRadioClick(sender As Object, e As EventArgs) Handles CentroYRadioToolStripMenuItem.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Circulo
    End Sub

    Private Sub ToolTresPuntosClick(sender As Object, e As EventArgs) Handles TresPuntosToolStripMenuItem.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Arco
    End Sub

    Private Sub ToolPincelClick(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Pincel
    End Sub

    Private Sub ToolLimpiarClick(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        'Panel1.BackgroundImage = FuncionesBE.MarcarCoordenadas(Panel1.Width, Panel1.Height)
        'Panel2.BackgroundImage = FuncionesBE.MarcarCoordenadas(Panel2.Width, Panel2.Height)
        Panel1.BackgroundImage = Panel3
        Panel2.BackgroundImage = Panel4
        oNuevaCoordenadasPuntos.Clear()
        oCoordenadasPuntos.Clear()
        oListaAnimacion.Clear()
    End Sub

    Private Sub ToolCuadrado(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Cuadrado
    End Sub

    Private Sub ToolTriangulo(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Triangulo
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Bezier
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Parabola
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Hiperbole
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Bicubica
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.RecorteLineas
    End Sub
#End Region

#Region "Barra 3"
    Private Sub ToolVentaneo(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Ventaneo
    End Sub

    Private Sub ToolTraslacion(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Traslacion
    End Sub

    Private Sub ToolRotacion(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Rotacion
    End Sub
#End Region


#Region "Coordenadas"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GenerarLinea()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenerarCirculo()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GenerarElipse()
    End Sub
#End Region

    
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button6.Click
        If oCoordenadasPuntos.Count > 0 Then
            Dim alfa = CInt(TextBox13.Text) : Dim list = New List(Of Decimal) : Dim j = 1

            For Each x In oCoordenadasPuntos
                If j Mod 2 <> 0 Then
                    list.Add(x - 300)
                Else
                    list.Add(250 - x)
                End If
                j += 1
            Next

            Dim a = FuncionesBE.GenerarLista(list)
            'Dim o1 = FuncionesBE.ListaTraslacion(-300, -250) : Dim o2 = FuncionesBE.ListaRotacion(alfa) : Dim o3 = FuncionesBE.ListaTraslacion(300, 250)
            'Dim n1 = FuncionesBE.MultiplicacionLista(o1, o2) : Dim n2 = FuncionesBE.MultiplicacionLista(n1, o3)

            'Dim n = FuncionesBE.MultiplicacionLista(a, n2)

            Dim o2 = FuncionesBE.ListaRotacion(alfa)
            Dim n = FuncionesBE.MultiplicacionLista(a, o2)
            Dim m = FuncionesBE.DegenerarLista(n)

            list.Clear()
            j = 1
            For Each x In m
                If j Mod 2 <> 0 Then
                    list.Add(300 + x)
                Else
                    list.Add(250 - x)
                End If
                j += 1
            Next

            m = list

            For i = 0 To m.Count - 3 Step 2
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
            Next
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If oCoordenadasPuntos.Count > 0 Then
            Dim x = CInt(TextBox11.Text) : Dim y = CInt(TextBox10.Text) : Dim list = New List(Of Decimal)

            Dim a = FuncionesBE.GenerarLista(oCoordenadasPuntos)
            Dim o = FuncionesBE.ListaTraslacion(x, y)
            Dim n = FuncionesBE.MultiplicacionLista(a, o)
            Dim m = FuncionesBE.DegenerarLista(n)

            For i = 0 To m.Count - 3 Step 2
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
            Next
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If oCoordenadasPuntos.Count > 0 Then
            Dim x = CDbl(TextBox15.Text) : Dim y = CDbl(TextBox14.Text) : Dim list = New List(Of Decimal)

            Dim a = FuncionesBE.GenerarLista(oCoordenadasPuntos)
            Dim o = FuncionesBE.ListaEscalamiento(x, y)
            Dim n = FuncionesBE.MultiplicacionLista(a, o)
            Dim m = FuncionesBE.DegenerarLista(n)

            For i = 0 To m.Count - 3 Step 2
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
            Next
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim x = CDbl(TextBox17.Text) : Dim y = CDbl(TextBox16.Text) : Dim list = New List(Of Decimal)

        Dim a = FuncionesBE.GenerarLista(oCoordenadasPuntos)
        Dim o = FuncionesBE.ListaAfilamientoX(x)
        Dim o1 = FuncionesBE.ListaAfilamientoY(y)

        Dim n = FuncionesBE.MultiplicacionLista(a, o)
        Dim n1 = FuncionesBE.MultiplicacionLista(n, o1)
        Dim m = FuncionesBE.DegenerarLista(n1)

        For i = 0 To m.Count - 3 Step 2
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
        Next
        Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If oCoordenadasPuntos.Count > 0 Then
            Dim m = New List(Of Decimal)
            Dim lista = New List(Of Decimal)
            For i = 0 To oCoordenadasPuntos.Count - 1
                If i Mod 2 = 0 Then
                    lista.Add(oCoordenadasPuntos.Item(i) - 300)
                Else
                    lista.Add((oCoordenadasPuntos.Item(i) - 250) * -1)
                End If
            Next
            Dim a = FuncionesBE.GenerarLista(lista)

            If RadioButton8.Checked Then
                Dim o = FuncionesBE.ListaReflexionX()
                Dim n = FuncionesBE.MultiplicacionLista(a, o)
                m = FuncionesBE.DegenerarLista(n)
            ElseIf RadioButton9.Checked Then
                Dim o = FuncionesBE.ListaReflexionY()
                Dim n = FuncionesBE.MultiplicacionLista(a, o)
                m = FuncionesBE.DegenerarLista(n)
            ElseIf RadioButton10.Checked Then
                Dim o = FuncionesBE.ListaReflexionXY()
                Dim n = FuncionesBE.MultiplicacionLista(a, o)
                m = FuncionesBE.DegenerarLista(n)
            End If

            Dim lista1 = New List(Of Decimal)
            For i = 0 To m.Count - 1
                If i Mod 2 = 0 Then
                    lista1.Add(m.Item(i) + 300)
                Else
                    lista1.Add(250 - m.Item(i))
                End If
            Next
            m = lista1

            For i = 0 To m.Count - 3 Step 2
                Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
            Next
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Elipse
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Reflexion
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        oDibujoSelect = OpcionesBE.TipoDibujo.Dibujo
        dibujar()
    End Sub

    Private Sub dibujar()
        oListaAnimacion.Add(10)
        oListaAnimacion.Add(0)
        oListaAnimacion.Add(40)
        oListaAnimacion.Add(0)
        oListaAnimacion.Add(40)
        oListaAnimacion.Add(20)
        oListaAnimacion.Add(10)
        oListaAnimacion.Add(20)

        oListaAnimacion1.Add(15)
        oListaAnimacion1.Add(10)
        oListaAnimacion1.Add(20)
        oListaAnimacion1.Add(10)
        oListaAnimacion1.Add(15)
        oListaAnimacion1.Add(30)
        oListaAnimacion1.Add(20)
        oListaAnimacion1.Add(30)

        Dim lista1 = New List(Of Decimal)
        For i = 0 To oListaAnimacion.Count - 1
            If i Mod 2 = 0 Then
                lista1.Add(oListaAnimacion.Item(i) + 300)
            Else
                lista1.Add(250 - oListaAnimacion.Item(i))
            End If
        Next
        Dim m = lista1
        oListaAnimacion = m

        Panel1.BackgroundImage = Panel3

        For i = 0 To m.Count - 3 Step 2
            Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(i), m.Item(i + 1), m.Item(i + 2), m.Item(i + 3), Panel1.BackgroundImage)
        Next
        Panel1.BackgroundImage = Linea.LineaBresenham_Libre(m.Item(m.Count - 2), m.Item(m.Count - 1), m.Item(0), m.Item(1), Panel1.BackgroundImage)

        'lista1 = New List(Of Decimal)
        'For i = 0 To oListaAnimacion1.Count - 1
        '    If i Mod 2 = 0 Then
        '        lista1.Add(oListaAnimacion1.Item(i) + 300)
        '    Else
        '        lista1.Add(250 - oListaAnimacion1.Item(i))
        '    End If
        'Next
    End Sub

End Class

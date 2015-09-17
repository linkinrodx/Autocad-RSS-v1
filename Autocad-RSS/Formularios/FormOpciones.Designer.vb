<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOpciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboColorLinea = New System.Windows.Forms.ComboBox()
        Me.cboAlgoLinea = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboGrosorLinea = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboColorCirculo = New System.Windows.Forms.ComboBox()
        Me.cboAlgoCirculo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboGrosorCirculo = New System.Windows.Forms.ComboBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboColorElipse = New System.Windows.Forms.ComboBox()
        Me.cboAlgoElipse = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboGrosorElipse = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cboColorPincel = New System.Windows.Forms.ComboBox()
        Me.cboGrosorPincel = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(394, 283)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(386, 257)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Linea"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.cboColorLinea)
        Me.GroupBox1.Controls.Add(Me.cboAlgoLinea)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboGrosorLinea)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 245)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(292, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Tamaño "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(297, 105)
        Me.TextBox1.MaxLength = 1
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(35, 20)
        Me.TextBox1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Color:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(105, 151)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 74)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'cboColorLinea
        '
        Me.cboColorLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColorLinea.FormattingEnabled = True
        Me.cboColorLinea.Location = New System.Drawing.Point(105, 29)
        Me.cboColorLinea.Name = "cboColorLinea"
        Me.cboColorLinea.Size = New System.Drawing.Size(186, 21)
        Me.cboColorLinea.TabIndex = 1
        '
        'cboAlgoLinea
        '
        Me.cboAlgoLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlgoLinea.FormattingEnabled = True
        Me.cboAlgoLinea.Location = New System.Drawing.Point(105, 65)
        Me.cboAlgoLinea.Name = "cboAlgoLinea"
        Me.cboAlgoLinea.Size = New System.Drawing.Size(186, 21)
        Me.cboAlgoLinea.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grosor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Linea:"
        '
        'cboGrosorLinea
        '
        Me.cboGrosorLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrosorLinea.FormattingEnabled = True
        Me.cboGrosorLinea.Location = New System.Drawing.Point(105, 104)
        Me.cboGrosorLinea.Name = "cboGrosorLinea"
        Me.cboGrosorLinea.Size = New System.Drawing.Size(186, 21)
        Me.cboGrosorLinea.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(386, 257)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Circulo"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox2.Controls.Add(Me.cboColorCirculo)
        Me.GroupBox2.Controls.Add(Me.cboAlgoCirculo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cboGrosorCirculo)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(377, 245)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(292, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Tamaño "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(297, 105)
        Me.TextBox2.MaxLength = 1
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(35, 20)
        Me.TextBox2.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Color:"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(105, 151)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(187, 74)
        Me.FlowLayoutPanel2.TabIndex = 12
        '
        'cboColorCirculo
        '
        Me.cboColorCirculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColorCirculo.FormattingEnabled = True
        Me.cboColorCirculo.Location = New System.Drawing.Point(105, 29)
        Me.cboColorCirculo.Name = "cboColorCirculo"
        Me.cboColorCirculo.Size = New System.Drawing.Size(186, 21)
        Me.cboColorCirculo.TabIndex = 7
        '
        'cboAlgoCirculo
        '
        Me.cboAlgoCirculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlgoCirculo.FormattingEnabled = True
        Me.cboAlgoCirculo.Location = New System.Drawing.Point(105, 65)
        Me.cboAlgoCirculo.Name = "cboAlgoCirculo"
        Me.cboAlgoCirculo.Size = New System.Drawing.Size(186, 21)
        Me.cboAlgoCirculo.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 26)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grosor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 26)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Circulo:"
        '
        'cboGrosorCirculo
        '
        Me.cboGrosorCirculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrosorCirculo.FormattingEnabled = True
        Me.cboGrosorCirculo.Location = New System.Drawing.Point(105, 104)
        Me.cboGrosorCirculo.Name = "cboGrosorCirculo"
        Me.cboGrosorCirculo.Size = New System.Drawing.Size(186, 21)
        Me.cboGrosorCirculo.TabIndex = 9
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(386, 257)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Elipse"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.FlowLayoutPanel3)
        Me.GroupBox3.Controls.Add(Me.cboColorElipse)
        Me.GroupBox3.Controls.Add(Me.cboAlgoElipse)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cboGrosorElipse)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(380, 251)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(292, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Tamaño "
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(297, 105)
        Me.TextBox3.MaxLength = 1
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(35, 20)
        Me.TextBox3.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Color:"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(105, 150)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(186, 74)
        Me.FlowLayoutPanel3.TabIndex = 12
        '
        'cboColorElipse
        '
        Me.cboColorElipse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColorElipse.FormattingEnabled = True
        Me.cboColorElipse.Location = New System.Drawing.Point(105, 29)
        Me.cboColorElipse.Name = "cboColorElipse"
        Me.cboColorElipse.Size = New System.Drawing.Size(186, 21)
        Me.cboColorElipse.TabIndex = 7
        '
        'cboAlgoElipse
        '
        Me.cboAlgoElipse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlgoElipse.FormattingEnabled = True
        Me.cboAlgoElipse.Location = New System.Drawing.Point(105, 65)
        Me.cboAlgoElipse.Name = "cboAlgoElipse"
        Me.cboAlgoElipse.Size = New System.Drawing.Size(186, 21)
        Me.cboAlgoElipse.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(36, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 26)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grosor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 26)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Elipse:"
        '
        'cboGrosorElipse
        '
        Me.cboGrosorElipse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrosorElipse.FormattingEnabled = True
        Me.cboGrosorElipse.Location = New System.Drawing.Point(105, 104)
        Me.cboGrosorElipse.Name = "cboGrosorElipse"
        Me.cboGrosorElipse.Size = New System.Drawing.Size(186, 21)
        Me.cboGrosorElipse.TabIndex = 9
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(386, 257)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Pincel"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.FlowLayoutPanel4)
        Me.GroupBox4.Controls.Add(Me.cboColorPincel)
        Me.GroupBox4.Controls.Add(Me.cboGrosorPincel)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(380, 251)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(292, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Tamaño "
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(297, 67)
        Me.TextBox4.MaxLength = 1
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(35, 20)
        Me.TextBox4.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(36, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Color:"
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(105, 139)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(186, 74)
        Me.FlowLayoutPanel4.TabIndex = 10
        '
        'cboColorPincel
        '
        Me.cboColorPincel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColorPincel.FormattingEnabled = True
        Me.cboColorPincel.Location = New System.Drawing.Point(105, 29)
        Me.cboColorPincel.Name = "cboColorPincel"
        Me.cboColorPincel.Size = New System.Drawing.Size(186, 21)
        Me.cboColorPincel.TabIndex = 7
        '
        'cboGrosorPincel
        '
        Me.cboGrosorPincel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrosorPincel.FormattingEnabled = True
        Me.cboGrosorPincel.Location = New System.Drawing.Point(105, 66)
        Me.cboGrosorPincel.Name = "cboGrosorPincel"
        Me.cboGrosorPincel.Size = New System.Drawing.Size(186, 21)
        Me.cboGrosorPincel.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(36, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 26)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Algoritmo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grosor:"
        '
        'FormOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 307)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormOpciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cboColorLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cboGrosorLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAlgoLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cboColorCirculo As System.Windows.Forms.ComboBox
    Friend WithEvents cboAlgoCirculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGrosorCirculo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cboColorElipse As System.Windows.Forms.ComboBox
    Friend WithEvents cboAlgoElipse As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboGrosorElipse As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cboColorPincel As System.Windows.Forms.ComboBox
    Friend WithEvents cboGrosorPincel As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class

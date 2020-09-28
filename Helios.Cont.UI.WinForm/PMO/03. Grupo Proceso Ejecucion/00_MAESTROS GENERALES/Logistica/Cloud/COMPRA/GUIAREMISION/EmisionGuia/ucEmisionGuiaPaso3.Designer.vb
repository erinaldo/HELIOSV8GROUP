<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEmisionGuiaPaso3
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucEmisionGuiaPaso3))
        Me.label18 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboDepartamento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.comboProvincia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.comboDistrito = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextDireccionPartida = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextDireccionLlegada = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.comboDistritoLlegada = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.comboProvinciaLlegada = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.comboDepartamentoLlegada = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.SfButton3 = New Syncfusion.WinForms.Controls.SfButton()
        Me.SfButton2 = New Syncfusion.WinForms.Controls.SfButton()
        Me.sfButton1 = New Syncfusion.WinForms.Controls.SfButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.comboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboProvincia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDireccionPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDireccionLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboDistritoLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboProvinciaLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboDepartamentoLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label18
        '
        Me.label18.BackColor = System.Drawing.Color.SeaGreen
        Me.label18.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.ForeColor = System.Drawing.Color.White
        Me.label18.Location = New System.Drawing.Point(3, 28)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(120, 17)
        Me.label18.TabIndex = 823
        Me.label18.Text = "PUNTO DE PARTIDA"
        Me.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 824
        Me.Label1.Text = "PUNTO DE LLEGADA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboDepartamento
        '
        Me.comboDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboDepartamento.BeforeTouchSize = New System.Drawing.Size(168, 21)
        Me.comboDepartamento.CaseSensitiveAutocomplete = True
        Me.comboDepartamento.Location = New System.Drawing.Point(50, 87)
        Me.comboDepartamento.MaxLength = 50
        Me.comboDepartamento.Name = "comboDepartamento"
        Me.comboDepartamento.Size = New System.Drawing.Size(168, 21)
        Me.comboDepartamento.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboDepartamento.TabIndex = 850
        '
        'comboProvincia
        '
        Me.comboProvincia.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboProvincia.BeforeTouchSize = New System.Drawing.Size(168, 21)
        Me.comboProvincia.CaseSensitiveAutocomplete = True
        Me.comboProvincia.Location = New System.Drawing.Point(238, 87)
        Me.comboProvincia.MaxLength = 50
        Me.comboProvincia.Name = "comboProvincia"
        Me.comboProvincia.Size = New System.Drawing.Size(168, 21)
        Me.comboProvincia.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboProvincia.TabIndex = 851
        '
        'comboDistrito
        '
        Me.comboDistrito.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboDistrito.BeforeTouchSize = New System.Drawing.Size(168, 21)
        Me.comboDistrito.CaseSensitiveAutocomplete = True
        Me.comboDistrito.Location = New System.Drawing.Point(422, 87)
        Me.comboDistrito.MaxLength = 50
        Me.comboDistrito.Name = "comboDistrito"
        Me.comboDistrito.Size = New System.Drawing.Size(168, 21)
        Me.comboDistrito.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboDistrito.TabIndex = 852
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(47, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 853
        Me.Label8.Text = "DEPARTAMENTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(235, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 854
        Me.Label2.Text = "PROVINCIA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(419, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 855
        Me.Label3.Text = "DISTRITO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(47, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(189, 13)
        Me.Label4.TabIndex = 856
        Me.Label4.Text = "DIRECCION DEL PUNTO DE PARTIDA"
        '
        'TextDireccionPartida
        '
        Me.TextDireccionPartida.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextDireccionPartida.BeforeTouchSize = New System.Drawing.Size(368, 48)
        Me.TextDireccionPartida.BorderColor = System.Drawing.Color.DimGray
        Me.TextDireccionPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDireccionPartida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDireccionPartida.CornerRadius = 4
        Me.TextDireccionPartida.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDireccionPartida.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDireccionPartida.ForeColor = System.Drawing.Color.White
        Me.TextDireccionPartida.Location = New System.Drawing.Point(50, 143)
        Me.TextDireccionPartida.MaxLength = 180
        Me.TextDireccionPartida.Metrocolor = System.Drawing.Color.LightGray
        Me.TextDireccionPartida.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDireccionPartida.Name = "TextDireccionPartida"
        Me.TextDireccionPartida.NearImage = CType(resources.GetObject("TextDireccionPartida.NearImage"), System.Drawing.Image)
        Me.TextDireccionPartida.Size = New System.Drawing.Size(540, 22)
        Me.TextDireccionPartida.TabIndex = 857
        '
        'TextDireccionLlegada
        '
        Me.TextDireccionLlegada.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextDireccionLlegada.BeforeTouchSize = New System.Drawing.Size(368, 48)
        Me.TextDireccionLlegada.BorderColor = System.Drawing.Color.DimGray
        Me.TextDireccionLlegada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDireccionLlegada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDireccionLlegada.CornerRadius = 4
        Me.TextDireccionLlegada.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDireccionLlegada.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDireccionLlegada.ForeColor = System.Drawing.Color.White
        Me.TextDireccionLlegada.Location = New System.Drawing.Point(50, 308)
        Me.TextDireccionLlegada.MaxLength = 180
        Me.TextDireccionLlegada.Metrocolor = System.Drawing.Color.LightGray
        Me.TextDireccionLlegada.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDireccionLlegada.Name = "TextDireccionLlegada"
        Me.TextDireccionLlegada.NearImage = CType(resources.GetObject("TextDireccionLlegada.NearImage"), System.Drawing.Image)
        Me.TextDireccionLlegada.Size = New System.Drawing.Size(540, 22)
        Me.TextDireccionLlegada.TabIndex = 865
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(47, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 13)
        Me.Label5.TabIndex = 864
        Me.Label5.Text = "DIRECCION DEL PUNTO DE LLEGADA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(419, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 863
        Me.Label6.Text = "DISTRITO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(235, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 862
        Me.Label7.Text = "PROVINCIA"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(47, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 861
        Me.Label9.Text = "DEPARTAMENTO"
        '
        'comboDistritoLlegada
        '
        Me.comboDistritoLlegada.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboDistritoLlegada.BeforeTouchSize = New System.Drawing.Size(168, 21)
        Me.comboDistritoLlegada.CaseSensitiveAutocomplete = True
        Me.comboDistritoLlegada.Location = New System.Drawing.Point(422, 252)
        Me.comboDistritoLlegada.MaxLength = 50
        Me.comboDistritoLlegada.Name = "comboDistritoLlegada"
        Me.comboDistritoLlegada.Size = New System.Drawing.Size(168, 21)
        Me.comboDistritoLlegada.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboDistritoLlegada.TabIndex = 860
        '
        'comboProvinciaLlegada
        '
        Me.comboProvinciaLlegada.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboProvinciaLlegada.BeforeTouchSize = New System.Drawing.Size(168, 21)
        Me.comboProvinciaLlegada.CaseSensitiveAutocomplete = True
        Me.comboProvinciaLlegada.Location = New System.Drawing.Point(238, 252)
        Me.comboProvinciaLlegada.MaxLength = 50
        Me.comboProvinciaLlegada.Name = "comboProvinciaLlegada"
        Me.comboProvinciaLlegada.Size = New System.Drawing.Size(168, 21)
        Me.comboProvinciaLlegada.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboProvinciaLlegada.TabIndex = 859
        '
        'comboDepartamentoLlegada
        '
        Me.comboDepartamentoLlegada.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboDepartamentoLlegada.BeforeTouchSize = New System.Drawing.Size(168, 21)
        Me.comboDepartamentoLlegada.CaseSensitiveAutocomplete = True
        Me.comboDepartamentoLlegada.Location = New System.Drawing.Point(50, 252)
        Me.comboDepartamentoLlegada.MaxLength = 50
        Me.comboDepartamentoLlegada.Name = "comboDepartamentoLlegada"
        Me.comboDepartamentoLlegada.Size = New System.Drawing.Size(168, 21)
        Me.comboDepartamentoLlegada.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboDepartamentoLlegada.TabIndex = 858
        '
        'SfButton3
        '
        Me.SfButton3.AccessibleName = "Button"
        Me.SfButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.SfButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.SfButton3.Location = New System.Drawing.Point(269, 452)
        Me.SfButton3.Name = "SfButton3"
        Me.SfButton3.Size = New System.Drawing.Size(127, 31)
        Me.SfButton3.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton3.Style.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton3.Style.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton3.Style.FocusedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton3.Style.FocusedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SfButton3.Style.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.SfButton3.Style.HoverBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton3.Style.PressedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton3.Style.PressedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SfButton3.TabIndex = 869
        Me.SfButton3.Text = "REGRESAR"
        '
        'SfButton2
        '
        Me.SfButton2.AccessibleName = "Button"
        Me.SfButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.SfButton2.ForeColor = System.Drawing.Color.LightCoral
        Me.SfButton2.Location = New System.Drawing.Point(535, 452)
        Me.SfButton2.Name = "SfButton2"
        Me.SfButton2.Size = New System.Drawing.Size(127, 31)
        Me.SfButton2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.FocusedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.FocusedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SfButton2.Style.ForeColor = System.Drawing.Color.LightCoral
        Me.SfButton2.Style.HoverBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.PressedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.PressedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SfButton2.TabIndex = 868
        Me.SfButton2.Text = "CANCELAR"
        '
        'sfButton1
        '
        Me.sfButton1.AccessibleName = "Button"
        Me.sfButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.sfButton1.Location = New System.Drawing.Point(402, 452)
        Me.sfButton1.Name = "sfButton1"
        Me.sfButton1.Size = New System.Drawing.Size(127, 31)
        Me.sfButton1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.FocusedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.FocusedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sfButton1.Style.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sfButton1.Style.HoverBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.PressedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.PressedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sfButton1.TabIndex = 867
        Me.sfButton1.Text = "CONTINUAR"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ucEmisionGuiaPaso3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Controls.Add(Me.SfButton3)
        Me.Controls.Add(Me.SfButton2)
        Me.Controls.Add(Me.sfButton1)
        Me.Controls.Add(Me.TextDireccionLlegada)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.comboDistritoLlegada)
        Me.Controls.Add(Me.comboProvinciaLlegada)
        Me.Controls.Add(Me.comboDepartamentoLlegada)
        Me.Controls.Add(Me.TextDireccionPartida)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.comboDistrito)
        Me.Controls.Add(Me.comboProvincia)
        Me.Controls.Add(Me.comboDepartamento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label18)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucEmisionGuiaPaso3"
        Me.Size = New System.Drawing.Size(911, 497)
        CType(Me.comboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboProvincia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDireccionPartida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDireccionLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboDistritoLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboProvinciaLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboDepartamentoLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents label18 As Label
    Private WithEvents Label1 As Label
    Public WithEvents comboDepartamento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents comboProvincia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents comboDistrito As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextDireccionPartida As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextDireccionLlegada As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Public WithEvents comboDistritoLlegada As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents comboProvinciaLlegada As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents comboDepartamentoLlegada As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Private WithEvents SfButton3 As Syncfusion.WinForms.Controls.SfButton
    Private WithEvents SfButton2 As Syncfusion.WinForms.Controls.SfButton
    Private WithEvents sfButton1 As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class

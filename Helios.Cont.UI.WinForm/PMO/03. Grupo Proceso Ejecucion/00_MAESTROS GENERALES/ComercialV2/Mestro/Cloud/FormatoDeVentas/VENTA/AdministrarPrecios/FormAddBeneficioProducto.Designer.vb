Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddBeneficioProducto
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddBeneficioProducto))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBeneficioFinal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboTipobeneficio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextEvaluacion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.dETALLE = New System.Windows.Forms.Label()
        Me.ComboAtributoAfectado = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboConversion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboModalidadVenta = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.comboMotivo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.ComboAplica = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.TextBeneficioFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTipobeneficio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEvaluacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAtributoAfectado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboConversion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboModalidadVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAplica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(27, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'TextBeneficioFinal
        '
        Me.TextBeneficioFinal.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextBeneficioFinal.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextBeneficioFinal.BorderColor = System.Drawing.Color.Yellow
        Me.TextBeneficioFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBeneficioFinal.CornerRadius = 5
        Me.TextBeneficioFinal.CurrencySymbol = ""
        Me.TextBeneficioFinal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBeneficioFinal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextBeneficioFinal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBeneficioFinal.ForeColor = System.Drawing.Color.Yellow
        Me.TextBeneficioFinal.Location = New System.Drawing.Point(26, 232)
        Me.TextBeneficioFinal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextBeneficioFinal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBeneficioFinal.Name = "TextBeneficioFinal"
        Me.TextBeneficioFinal.NearImage = CType(resources.GetObject("TextBeneficioFinal.NearImage"), System.Drawing.Image)
        Me.TextBeneficioFinal.NullString = ""
        Me.TextBeneficioFinal.PositiveColor = System.Drawing.Color.Yellow
        Me.TextBeneficioFinal.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBeneficioFinal.Size = New System.Drawing.Size(156, 27)
        Me.TextBeneficioFinal.TabIndex = 641
        Me.TextBeneficioFinal.Text = "0.00"
        Me.TextBeneficioFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(27, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(155, 18)
        Me.Label4.TabIndex = 642
        Me.Label4.Text = "Agregar Beneficio"
        '
        'ComboTipobeneficio
        '
        Me.ComboTipobeneficio.AutoComplete = False
        Me.ComboTipobeneficio.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboTipobeneficio.BeforeTouchSize = New System.Drawing.Size(176, 21)
        Me.ComboTipobeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipobeneficio.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboTipobeneficio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipobeneficio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboTipobeneficio.Items.AddRange(New Object() {"DESCUENTO", "BONIFICACION", "OFERTA", "REGALO"})
        Me.ComboTipobeneficio.Location = New System.Drawing.Point(26, 62)
        Me.ComboTipobeneficio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboTipobeneficio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboTipobeneficio.Name = "ComboTipobeneficio"
        Me.ComboTipobeneficio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboTipobeneficio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboTipobeneficio.Size = New System.Drawing.Size(176, 21)
        Me.ComboTipobeneficio.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboTipobeneficio.TabIndex = 670
        Me.ComboTipobeneficio.Text = "DESCUENTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(187, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 545
        Me.Label2.Text = "Afectado a:"
        '
        'TextEvaluacion
        '
        Me.TextEvaluacion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextEvaluacion.BeforeTouchSize = New System.Drawing.Size(303, 22)
        Me.TextEvaluacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.TextEvaluacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEvaluacion.CornerRadius = 5
        Me.TextEvaluacion.CurrencySymbol = ""
        Me.TextEvaluacion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextEvaluacion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextEvaluacion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEvaluacion.ForeColor = System.Drawing.Color.LimeGreen
        Me.TextEvaluacion.Location = New System.Drawing.Point(349, 157)
        Me.TextEvaluacion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextEvaluacion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextEvaluacion.Name = "TextEvaluacion"
        Me.TextEvaluacion.NullString = ""
        Me.TextEvaluacion.PositiveColor = System.Drawing.Color.LimeGreen
        Me.TextEvaluacion.ReadOnlyBackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextEvaluacion.Size = New System.Drawing.Size(156, 27)
        Me.TextEvaluacion.TabIndex = 676
        Me.TextEvaluacion.Text = "0.00"
        Me.TextEvaluacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "GUARDAR"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(200, 272)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(129, 40)
        Me.BunifuThinButton21.TabIndex = 667
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dETALLE
        '
        Me.dETALLE.AutoSize = True
        Me.dETALLE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dETALLE.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.dETALLE.Location = New System.Drawing.Point(25, 91)
        Me.dETALLE.Name = "dETALLE"
        Me.dETALLE.Size = New System.Drawing.Size(39, 13)
        Me.dETALLE.TabIndex = 679
        Me.dETALLE.Text = "Motivo"
        '
        'ComboAtributoAfectado
        '
        Me.ComboAtributoAfectado.AutoComplete = False
        Me.ComboAtributoAfectado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboAtributoAfectado.BeforeTouchSize = New System.Drawing.Size(156, 21)
        Me.ComboAtributoAfectado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAtributoAfectado.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboAtributoAfectado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAtributoAfectado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboAtributoAfectado.Items.AddRange(New Object() {"IMPORTE", "CANTIDAD"})
        Me.ComboAtributoAfectado.Location = New System.Drawing.Point(188, 162)
        Me.ComboAtributoAfectado.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboAtributoAfectado.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboAtributoAfectado.Name = "ComboAtributoAfectado"
        Me.ComboAtributoAfectado.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboAtributoAfectado.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboAtributoAfectado.Size = New System.Drawing.Size(156, 21)
        Me.ComboAtributoAfectado.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboAtributoAfectado.TabIndex = 680
        Me.ComboAtributoAfectado.Text = "IMPORTE"
        Me.ComboAtributoAfectado.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(27, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(256, 13)
        Me.Label5.TabIndex = 682
        Me.Label5.Text = "Resultado del beneficio: Valor (s/.) | porcentual(%) "
        '
        'ComboConversion
        '
        Me.ComboConversion.AutoComplete = False
        Me.ComboConversion.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboConversion.BeforeTouchSize = New System.Drawing.Size(156, 21)
        Me.ComboConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboConversion.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboConversion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboConversion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboConversion.Items.AddRange(New Object() {"PORCENTAJE", "VALOR UNICO"})
        Me.ComboConversion.Location = New System.Drawing.Point(188, 238)
        Me.ComboConversion.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboConversion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboConversion.Name = "ComboConversion"
        Me.ComboConversion.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboConversion.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboConversion.Size = New System.Drawing.Size(156, 21)
        Me.ComboConversion.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboConversion.TabIndex = 684
        Me.ComboConversion.Text = "PORCENTAJE"
        '
        'ComboModalidadVenta
        '
        Me.ComboModalidadVenta.AutoComplete = False
        Me.ComboModalidadVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboModalidadVenta.BeforeTouchSize = New System.Drawing.Size(155, 21)
        Me.ComboModalidadVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboModalidadVenta.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboModalidadVenta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboModalidadVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboModalidadVenta.Items.AddRange(New Object() {"TIENDA", "VIRTUAL"})
        Me.ComboModalidadVenta.Location = New System.Drawing.Point(350, 111)
        Me.ComboModalidadVenta.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboModalidadVenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboModalidadVenta.Name = "ComboModalidadVenta"
        Me.ComboModalidadVenta.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboModalidadVenta.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboModalidadVenta.Size = New System.Drawing.Size(155, 21)
        Me.ComboModalidadVenta.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboModalidadVenta.TabIndex = 686
        Me.ComboModalidadVenta.Text = "TIENDA"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(346, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 685
        Me.Label7.Text = "Modalidad de venta"
        '
        'comboMotivo
        '
        Me.comboMotivo.AutoComplete = False
        Me.comboMotivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboMotivo.BeforeTouchSize = New System.Drawing.Size(318, 21)
        Me.comboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMotivo.FlatBorderColor = System.Drawing.Color.DimGray
        Me.comboMotivo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboMotivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.comboMotivo.Items.AddRange(New Object() {"Por importe de consumo", "Por volumen de compras", "Dscto por lanzamiento", "Dscto por aniversario del establecimiento", "Compras ecommerce (compras on line)", "Cambio de temporada", "Flash (solo por hoy)", "Descuento por amarres"})
        Me.comboMotivo.Location = New System.Drawing.Point(26, 111)
        Me.comboMotivo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.comboMotivo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.comboMotivo.Name = "comboMotivo"
        Me.comboMotivo.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.comboMotivo.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.comboMotivo.Size = New System.Drawing.Size(318, 21)
        Me.comboMotivo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboMotivo.TabIndex = 687
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.Yellow
        Me.Line21.Location = New System.Drawing.Point(28, 197)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(479, 1)
        Me.Line21.TabIndex = 688
        Me.Line21.Text = "Line21"
        '
        'ComboAplica
        '
        Me.ComboAplica.AutoComplete = False
        Me.ComboAplica.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboAplica.BeforeTouchSize = New System.Drawing.Size(156, 21)
        Me.ComboAplica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAplica.FlatBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.ComboAplica.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAplica.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboAplica.Items.AddRange(New Object() {"Por cada", "Superior a..."})
        Me.ComboAplica.Location = New System.Drawing.Point(26, 162)
        Me.ComboAplica.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboAplica.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboAplica.Name = "ComboAplica"
        Me.ComboAplica.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.ComboAplica.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.ComboAplica.Size = New System.Drawing.Size(156, 21)
        Me.ComboAplica.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboAplica.TabIndex = 690
        Me.ComboAplica.Text = "Por cada"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label8.Location = New System.Drawing.Point(23, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 691
        Me.Label8.Text = "Aplica"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(346, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 692
        Me.Label3.Text = "Apartir de:"
        '
        'FormAddBeneficioProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.Yellow
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(529, 326)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboAplica)
        Me.Controls.Add(Me.Line21)
        Me.Controls.Add(Me.comboMotivo)
        Me.Controls.Add(Me.ComboModalidadVenta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboConversion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextEvaluacion)
        Me.Controls.Add(Me.ComboAtributoAfectado)
        Me.Controls.Add(Me.dETALLE)
        Me.Controls.Add(Me.ComboTipobeneficio)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBeneficioFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddBeneficioProducto"
        Me.ShowIcon = False
        Me.Text = "Beneficio Equivalencia"
        CType(Me.TextBeneficioFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTipobeneficio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEvaluacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAtributoAfectado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboConversion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboModalidadVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAplica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBeneficioFinal As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ComboTipobeneficio As Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents TextEvaluacion As Tools.CurrencyTextBox
    Friend WithEvents dETALLE As Label
    Friend WithEvents ComboAtributoAfectado As Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboConversion As Tools.ComboBoxAdv
    Friend WithEvents ComboModalidadVenta As Tools.ComboBoxAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents comboMotivo As Tools.ComboBoxAdv
    Friend WithEvents Line21 As Line2
    Friend WithEvents ComboAplica As Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
End Class

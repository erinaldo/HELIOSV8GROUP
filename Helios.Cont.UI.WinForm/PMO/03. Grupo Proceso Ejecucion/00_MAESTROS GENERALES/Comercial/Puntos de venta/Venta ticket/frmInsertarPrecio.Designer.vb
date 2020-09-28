<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertarPrecio
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtid = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtalmacen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtxmenor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtxmayor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtxgranmayor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtxmenorme = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtxmayorme = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtxgranmayorme = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtalmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxmenor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxmayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxgranmayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxmenorme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxmayorme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxgranmayorme, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CornerRadius = 5
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(27, 37)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(385, 20)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 404
        Me.txtDescripcion.Tag = "01"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(27, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 12)
        Me.Label7.TabIndex = 403
        Me.Label7.Text = "PRODUCTO"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(308, 231)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 408
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(405, 231)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 409
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.Color.White
        Me.txtid.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtid.CornerRadius = 5
        Me.txtid.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtid.Enabled = False
        Me.txtid.Location = New System.Drawing.Point(498, 24)
        Me.txtid.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtid.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(41, 20)
        Me.txtid.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtid.TabIndex = 413
        Me.txtid.Tag = "01"
        Me.txtid.Visible = False
        '
        'txtalmacen
        '
        Me.txtalmacen.BackColor = System.Drawing.Color.White
        Me.txtalmacen.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtalmacen.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtalmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtalmacen.CornerRadius = 5
        Me.txtalmacen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtalmacen.Enabled = False
        Me.txtalmacen.Location = New System.Drawing.Point(557, 24)
        Me.txtalmacen.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtalmacen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtalmacen.Name = "txtalmacen"
        Me.txtalmacen.ReadOnly = True
        Me.txtalmacen.Size = New System.Drawing.Size(41, 20)
        Me.txtalmacen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtalmacen.TabIndex = 417
        Me.txtalmacen.Tag = "01"
        Me.txtalmacen.Visible = False
        '
        'txtxmenor
        '
        Me.txtxmenor.BackGroundColor = System.Drawing.Color.White
        Me.txtxmenor.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtxmenor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmenor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtxmenor.CornerRadius = 5
        Me.txtxmenor.CurrencySymbol = ""
        Me.txtxmenor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtxmenor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtxmenor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtxmenor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmenor.Location = New System.Drawing.Point(9, 25)
        Me.txtxmenor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmenor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtxmenor.Name = "txtxmenor"
        Me.txtxmenor.NullString = ""
        Me.txtxmenor.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmenor.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtxmenor.Size = New System.Drawing.Size(97, 16)
        Me.txtxmenor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtxmenor.TabIndex = 496
        Me.txtxmenor.Text = "0.00"
        Me.txtxmenor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(26, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 12)
        Me.Label11.TabIndex = 495
        Me.Label11.Text = "PREC. X MENOR"
        '
        'txtxmayor
        '
        Me.txtxmayor.BackGroundColor = System.Drawing.Color.White
        Me.txtxmayor.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtxmayor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmayor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtxmayor.CornerRadius = 5
        Me.txtxmayor.CurrencySymbol = ""
        Me.txtxmayor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtxmayor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtxmayor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtxmayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmayor.Location = New System.Drawing.Point(177, 25)
        Me.txtxmayor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmayor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtxmayor.Name = "txtxmayor"
        Me.txtxmayor.NullString = ""
        Me.txtxmayor.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmayor.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtxmayor.Size = New System.Drawing.Size(97, 16)
        Me.txtxmayor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtxmayor.TabIndex = 497
        Me.txtxmayor.Text = "0.00"
        Me.txtxmayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtxgranmayor
        '
        Me.txtxgranmayor.BackGroundColor = System.Drawing.Color.White
        Me.txtxgranmayor.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtxgranmayor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxgranmayor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtxgranmayor.CornerRadius = 5
        Me.txtxgranmayor.CurrencySymbol = ""
        Me.txtxgranmayor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtxgranmayor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtxgranmayor.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtxgranmayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxgranmayor.Location = New System.Drawing.Point(352, 25)
        Me.txtxgranmayor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxgranmayor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtxgranmayor.Name = "txtxgranmayor"
        Me.txtxgranmayor.NullString = ""
        Me.txtxgranmayor.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxgranmayor.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtxgranmayor.Size = New System.Drawing.Size(97, 16)
        Me.txtxgranmayor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtxgranmayor.TabIndex = 498
        Me.txtxgranmayor.Text = "0.00"
        Me.txtxgranmayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtxmenorme
        '
        Me.txtxmenorme.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.txtxmenorme.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtxmenorme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmenorme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtxmenorme.CornerRadius = 5
        Me.txtxmenorme.CurrencySymbol = ""
        Me.txtxmenorme.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtxmenorme.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtxmenorme.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtxmenorme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmenorme.Location = New System.Drawing.Point(9, 24)
        Me.txtxmenorme.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmenorme.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtxmenorme.Name = "txtxmenorme"
        Me.txtxmenorme.NullString = ""
        Me.txtxmenorme.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmenorme.ReadOnly = True
        Me.txtxmenorme.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtxmenorme.Size = New System.Drawing.Size(97, 16)
        Me.txtxmenorme.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtxmenorme.TabIndex = 501
        Me.txtxmenorme.Text = "0.00"
        Me.txtxmenorme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtxmayorme
        '
        Me.txtxmayorme.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.txtxmayorme.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtxmayorme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmayorme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtxmayorme.CornerRadius = 5
        Me.txtxmayorme.CurrencySymbol = ""
        Me.txtxmayorme.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtxmayorme.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtxmayorme.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtxmayorme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmayorme.Location = New System.Drawing.Point(177, 24)
        Me.txtxmayorme.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxmayorme.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtxmayorme.Name = "txtxmayorme"
        Me.txtxmayorme.NullString = ""
        Me.txtxmayorme.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxmayorme.ReadOnly = True
        Me.txtxmayorme.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtxmayorme.Size = New System.Drawing.Size(97, 16)
        Me.txtxmayorme.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtxmayorme.TabIndex = 502
        Me.txtxmayorme.Text = "0.00"
        Me.txtxmayorme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtxgranmayorme
        '
        Me.txtxgranmayorme.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.txtxgranmayorme.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtxgranmayorme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxgranmayorme.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtxgranmayorme.CornerRadius = 5
        Me.txtxgranmayorme.CurrencySymbol = ""
        Me.txtxgranmayorme.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtxgranmayorme.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtxgranmayorme.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtxgranmayorme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxgranmayorme.Location = New System.Drawing.Point(352, 24)
        Me.txtxgranmayorme.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtxgranmayorme.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtxgranmayorme.Name = "txtxgranmayorme"
        Me.txtxgranmayorme.NullString = ""
        Me.txtxgranmayorme.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtxgranmayorme.ReadOnly = True
        Me.txtxgranmayorme.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtxgranmayorme.Size = New System.Drawing.Size(97, 16)
        Me.txtxgranmayorme.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtxgranmayorme.TabIndex = 503
        Me.txtxgranmayorme.Text = "0.00"
        Me.txtxgranmayorme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtxmenor)
        Me.GroupBox1.Controls.Add(Me.txtxmayor)
        Me.GroupBox1.Controls.Add(Me.txtxgranmayor)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 49)
        Me.GroupBox1.TabIndex = 504
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importe Nacional"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtxmenorme)
        Me.GroupBox2.Controls.Add(Me.txtxmayorme)
        Me.GroupBox2.Controls.Add(Me.txtxgranmayorme)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(469, 47)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Importe Extranjero"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(141, 16)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CornerRadius = 5
        Me.txtTipoCambio.CurrencySymbol = ""
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DecimalValue = New Decimal(New Integer() {300, 0, 0, 131072})
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.Location = New System.Drawing.Point(418, 37)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTipoCambio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTipoCambio.Size = New System.Drawing.Size(62, 20)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoCambio.TabIndex = 507
        Me.txtTipoCambio.Text = "3.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(436, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 12)
        Me.Label9.TabIndex = 506
        Me.Label9.Text = "T/c"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(199, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 12)
        Me.Label1.TabIndex = 508
        Me.Label1.Text = "PREC. X MAYOR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(342, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 12)
        Me.Label2.TabIndex = 509
        Me.Label2.Text = "PREC. X GRAN MAYOR"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel8.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Location = New System.Drawing.Point(11, 97)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(469, 13)
        Me.GradientPanel8.TabIndex = 510
        '
        'frmInsertarPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.DarkRed
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Configurar nuevo precio."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(487, 259)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtalmacen)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInsertarPrecio"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtalmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxmenor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxmayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxgranmayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxmenorme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxmayorme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxgranmayorme, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtid As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtalmacen As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtxmenor As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtxmayor As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtxgranmayor As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtxmenorme As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtxmayorme As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtxgranmayorme As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
End Class

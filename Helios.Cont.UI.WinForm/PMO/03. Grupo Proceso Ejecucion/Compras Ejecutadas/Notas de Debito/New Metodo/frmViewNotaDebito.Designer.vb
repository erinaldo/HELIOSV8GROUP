<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewNotaDebito
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
        Me.lblFecCompra = New System.Windows.Forms.Label()
        Me.lblNumCompra = New System.Windows.Forms.Label()
        Me.lblDocCompra = New System.Windows.Forms.Label()
        Me.lblRucEntidad = New System.Windows.Forms.Label()
        Me.lblEntidad = New System.Windows.Forms.Label()
        Me.lblFecNota = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TXTiVA = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.colCan = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lblRucEmpresa = New System.Windows.Forms.Label()
        Me.lblNumeroNota = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTiVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFecCompra
        '
        Me.lblFecCompra.AutoSize = True
        Me.lblFecCompra.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecCompra.ForeColor = System.Drawing.Color.Black
        Me.lblFecCompra.Location = New System.Drawing.Point(632, 169)
        Me.lblFecCompra.Name = "lblFecCompra"
        Me.lblFecCompra.Size = New System.Drawing.Size(62, 13)
        Me.lblFecCompra.TabIndex = 31
        Me.lblFecCompra.Text = "10/10/2016"
        '
        'lblNumCompra
        '
        Me.lblNumCompra.AutoSize = True
        Me.lblNumCompra.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCompra.ForeColor = System.Drawing.Color.Black
        Me.lblNumCompra.Location = New System.Drawing.Point(333, 169)
        Me.lblNumCompra.Name = "lblNumCompra"
        Me.lblNumCompra.Size = New System.Drawing.Size(111, 13)
        Me.lblNumCompra.TabIndex = 30
        Me.lblNumCompra.Text = "000004-00000000015"
        '
        'lblDocCompra
        '
        Me.lblDocCompra.AutoSize = True
        Me.lblDocCompra.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocCompra.ForeColor = System.Drawing.Color.Black
        Me.lblDocCompra.Location = New System.Drawing.Point(134, 169)
        Me.lblDocCompra.Name = "lblDocCompra"
        Me.lblDocCompra.Size = New System.Drawing.Size(55, 13)
        Me.lblDocCompra.TabIndex = 29
        Me.lblDocCompra.Text = "FACTURA"
        '
        'lblRucEntidad
        '
        Me.lblRucEntidad.AutoSize = True
        Me.lblRucEntidad.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRucEntidad.ForeColor = System.Drawing.Color.Black
        Me.lblRucEntidad.Location = New System.Drawing.Point(577, 116)
        Me.lblRucEntidad.Name = "lblRucEntidad"
        Me.lblRucEntidad.Size = New System.Drawing.Size(82, 13)
        Me.lblRucEntidad.TabIndex = 28
        Me.lblRucEntidad.Text = "2044924569101"
        '
        'lblEntidad
        '
        Me.lblEntidad.AutoSize = True
        Me.lblEntidad.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntidad.ForeColor = System.Drawing.Color.Black
        Me.lblEntidad.Location = New System.Drawing.Point(106, 116)
        Me.lblEntidad.Name = "lblEntidad"
        Me.lblEntidad.Size = New System.Drawing.Size(132, 13)
        Me.lblEntidad.TabIndex = 27
        Me.lblEntidad.Text = "PALACIOS SANTOS JIUNI"
        '
        'lblFecNota
        '
        Me.lblFecNota.AutoSize = True
        Me.lblFecNota.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecNota.ForeColor = System.Drawing.Color.Black
        Me.lblFecNota.Location = New System.Drawing.Point(106, 91)
        Me.lblFecNota.Name = "lblFecNota"
        Me.lblFecNota.Size = New System.Drawing.Size(62, 13)
        Me.lblFecNota.TabIndex = 26
        Me.lblFecNota.Text = "10/10/2016"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.txtTotal)
        Me.GradientPanel2.Controls.Add(Me.TXTiVA)
        Me.GradientPanel2.Controls.Add(Me.txtTotalBase)
        Me.GradientPanel2.Controls.Add(Me.Label13)
        Me.GradientPanel2.Controls.Add(Me.Label12)
        Me.GradientPanel2.Controls.Add(Me.Label11)
        Me.GradientPanel2.Location = New System.Drawing.Point(551, 324)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(204, 65)
        Me.GradientPanel2.TabIndex = 25
        '
        'txtTotal
        '
        Me.txtTotal.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotal.BeforeTouchSize = New System.Drawing.Size(141, 15)
        Me.txtTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotal.CornerRadius = 5
        Me.txtTotal.CurrencySymbol = ""
        Me.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotal.Location = New System.Drawing.Point(59, 43)
        Me.txtTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.NullString = ""
        Me.txtTotal.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotal.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotal.Size = New System.Drawing.Size(141, 15)
        Me.txtTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotal.TabIndex = 497
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTiVA
        '
        Me.TXTiVA.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TXTiVA.BeforeTouchSize = New System.Drawing.Size(141, 15)
        Me.TXTiVA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TXTiVA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXTiVA.CornerRadius = 5
        Me.TXTiVA.CurrencySymbol = ""
        Me.TXTiVA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTiVA.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TXTiVA.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTiVA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTiVA.Location = New System.Drawing.Point(59, 22)
        Me.TXTiVA.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TXTiVA.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTiVA.Name = "TXTiVA"
        Me.TXTiVA.NullString = ""
        Me.TXTiVA.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTiVA.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TXTiVA.Size = New System.Drawing.Size(141, 15)
        Me.TXTiVA.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TXTiVA.TabIndex = 496
        Me.TXTiVA.Text = "0.00"
        Me.TXTiVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(141, 15)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase.Location = New System.Drawing.Point(59, 1)
        Me.txtTotalBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase.Name = "txtTotalBase"
        Me.txtTotalBase.NullString = ""
        Me.txtTotalBase.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalBase.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase.TabIndex = 495
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(3, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "TOTAL"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(3, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "I.V.A."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Sub Total"
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCan, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader4})
        Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(18, 194)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(737, 129)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'colCan
        '
        Me.colCan.Text = "CANT."
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "D E S C R I P C I O N"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 278
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "MOTIVO"
        Me.ColumnHeader3.Width = 194
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "PRECIO UNIT."
        Me.ColumnHeader1.Width = 84
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "TOTAL"
        Me.ColumnHeader4.Width = 68
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(548, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Fecha emisión:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(247, 169)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Serie - número:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(21, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Tipo Comprobante:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Documento que modifica:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(514, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "R.U.C. N°:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(21, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Señor (es):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(21, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Fecha:"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.lblRucEmpresa)
        Me.GradientPanel1.Controls.Add(Me.lblNumeroNota)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(559, 12)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(196, 78)
        Me.GradientPanel1.TabIndex = 16
        '
        'lblRucEmpresa
        '
        Me.lblRucEmpresa.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRucEmpresa.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRucEmpresa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblRucEmpresa.Location = New System.Drawing.Point(0, 0)
        Me.lblRucEmpresa.Name = "lblRucEmpresa"
        Me.lblRucEmpresa.Size = New System.Drawing.Size(194, 30)
        Me.lblRucEmpresa.TabIndex = 2
        Me.lblRucEmpresa.Text = "R.U.C. N° 20774499101"
        Me.lblRucEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumeroNota
        '
        Me.lblNumeroNota.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNumeroNota.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroNota.ForeColor = System.Drawing.Color.Gray
        Me.lblNumeroNota.Location = New System.Drawing.Point(0, 53)
        Me.lblNumeroNota.Name = "lblNumeroNota"
        Me.lblNumeroNota.Size = New System.Drawing.Size(194, 23)
        Me.lblNumeroNota.TabIndex = 1
        Me.lblNumeroNota.Text = "00000-00001"
        Me.lblNumeroNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(-2, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOTA DE DEBITO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmViewNotaDebito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Gainsboro
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Opción Visualizar"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(773, 393)
        Me.Controls.Add(Me.lblFecCompra)
        Me.Controls.Add(Me.lblNumCompra)
        Me.Controls.Add(Me.lblDocCompra)
        Me.Controls.Add(Me.lblRucEntidad)
        Me.Controls.Add(Me.lblEntidad)
        Me.Controls.Add(Me.lblFecNota)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewNotaDebito"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTiVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFecCompra As System.Windows.Forms.Label
    Friend WithEvents lblNumCompra As System.Windows.Forms.Label
    Friend WithEvents lblDocCompra As System.Windows.Forms.Label
    Friend WithEvents lblRucEntidad As System.Windows.Forms.Label
    Friend WithEvents lblEntidad As System.Windows.Forms.Label
    Friend WithEvents lblFecNota As System.Windows.Forms.Label
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TXTiVA As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents colCan As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lblRucEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblNumeroNota As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

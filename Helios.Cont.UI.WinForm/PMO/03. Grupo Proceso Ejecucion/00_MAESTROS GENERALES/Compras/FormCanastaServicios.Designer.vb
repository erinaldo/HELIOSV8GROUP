Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCanastaServicios
    Inherits MetroForm

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
        Me.components = New System.ComponentModel.Container()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtServicio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.lsvServicios = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboDestino = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboServicio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtServicio
        '
        Me.txtServicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.txtServicio.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtServicio.BorderColor = System.Drawing.Color.Green
        Me.txtServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServicio.CornerRadius = 5
        Me.txtServicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServicio.Location = New System.Drawing.Point(25, 97)
        Me.txtServicio.Metrocolor = System.Drawing.Color.Green
        Me.txtServicio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtServicio.Multiline = True
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtServicio.Size = New System.Drawing.Size(352, 49)
        Me.txtServicio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtServicio.TabIndex = 459
        Me.txtServicio.TabStop = False
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(297, 21)
        Me.ComboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Items.AddRange(New Object() {"", "SERVICIOS & GASTOS", "ACTIVO INMOVILIZADO"})
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, ""))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "SERVICIOS & GASTOS"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "ACTIVO INMOVILIZADO"))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(77, 258)
        Me.ComboBoxAdv1.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(297, 21)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 458
        Me.ComboBoxAdv1.Visible = False
        '
        'lsvServicios
        '
        Me.lsvServicios.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lsvServicios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lsvServicios.FullRowSelect = True
        Me.lsvServicios.GridLines = True
        Me.lsvServicios.HideSelection = False
        Me.lsvServicios.Location = New System.Drawing.Point(22, 290)
        Me.lsvServicios.Name = "lsvServicios"
        Me.lsvServicios.Size = New System.Drawing.Size(352, 171)
        Me.lsvServicios.TabIndex = 457
        Me.lsvServicios.UseCompatibleStateImageBehavior = False
        Me.lsvServicios.View = System.Windows.Forms.View.Details
        Me.lsvServicios.Visible = False
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cuenta"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Descripcion"
        Me.ColumnHeader6.Width = 288
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(22, 24)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 14)
        Me.Label29.TabIndex = 456
        Me.Label29.Text = "Destino Grav."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(22, 77)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(100, 14)
        Me.Label28.TabIndex = 455
        Me.Label28.Text = "Detalle del servicio"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(381, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 14)
        Me.Label27.TabIndex = 454
        Me.Label27.Text = "Cuenta"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(437, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(95, 14)
        Me.Label26.TabIndex = 453
        Me.Label26.Text = "Servicio Especifico"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(34, 264)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 12)
        Me.Label24.TabIndex = 452
        Me.Label24.Text = "ELEGIR"
        Me.Label24.Visible = False
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCuenta.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta.CornerRadius = 1
        Me.txtCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuenta.Location = New System.Drawing.Point(384, 45)
        Me.txtCuenta.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCuenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuenta.Multiline = True
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(51, 21)
        Me.txtCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuenta.TabIndex = 451
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv15.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(276, 160)
        Me.ButtonAdv15.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv15.TabIndex = 450
        Me.ButtonAdv15.Text = "Agregar"
        Me.ButtonAdv15.UseVisualStyle = True
        Me.ButtonAdv15.UseVisualStyleBackColor = False
        '
        'cboDestino
        '
        Me.cboDestino.BackColor = System.Drawing.Color.White
        Me.cboDestino.BeforeTouchSize = New System.Drawing.Size(148, 21)
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDestino.Items.AddRange(New Object() {"1-Gravado", "2-Exonerado"})
        Me.cboDestino.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboDestino, "1-Gravado"))
        Me.cboDestino.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboDestino, "2-Exonerado"))
        Me.cboDestino.Location = New System.Drawing.Point(25, 44)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(148, 21)
        Me.cboDestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboDestino.TabIndex = 449
        Me.cboDestino.Text = "1-Gravado"
        '
        'cboServicio
        '
        Me.cboServicio.BackColor = System.Drawing.Color.White
        Me.cboServicio.BeforeTouchSize = New System.Drawing.Size(297, 21)
        Me.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboServicio.Location = New System.Drawing.Point(439, 45)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(297, 21)
        Me.cboServicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboServicio.TabIndex = 448
        '
        'FormCanastaServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.CaptionFont = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Servicios"
        CaptionLabel2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.Green
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Seleccionar item"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(380, 201)
        Me.Controls.Add(Me.txtServicio)
        Me.Controls.Add(Me.ComboBoxAdv1)
        Me.Controls.Add(Me.lsvServicios)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.ButtonAdv15)
        Me.Controls.Add(Me.cboDestino)
        Me.Controls.Add(Me.cboServicio)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCanastaServicios"
        Me.ShowIcon = False
        CType(Me.txtServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtServicio As Tools.TextBoxExt
    Friend WithEvents ComboBoxAdv1 As Tools.ComboBoxAdv
    Friend WithEvents lsvServicios As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtCuenta As Tools.TextBoxExt
    Friend WithEvents ButtonAdv15 As ButtonAdv
    Friend WithEvents cboDestino As Tools.ComboBoxAdv
    Friend WithEvents cboServicio As Tools.ComboBoxAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSeleccionCuentaFinanciera
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionCuentaFinanciera))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.idEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cuenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idEstado, Me.Cuenta, Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 48)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(476, 212)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'idEstado
        '
        Me.idEstado.Text = "ID"
        Me.idEstado.Width = 0
        '
        'Cuenta
        '
        Me.Cuenta.Text = "Cuenta Financiera"
        Me.Cuenta.Width = 247
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Moneda"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Saldo"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 104
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(148, 21)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cboTipo.Font = New System.Drawing.Font("Corbel", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.Black
        Me.cboTipo.Items.AddRange(New Object() {"CUENTAS EN EFECTIVO", "CUENTAS EN EFECTIVO CAJERO", "CUENTAS EN BANCO", "TARJETA DE CREDITO"})
        Me.cboTipo.Location = New System.Drawing.Point(12, 18)
        Me.cboTipo.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(148, 21)
        Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipo.TabIndex = 554
        Me.cboTipo.Text = "CUENTAS EN EFECTIVO"
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(86, 23)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(319, 16)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAdv6.TabIndex = 555
        Me.ButtonAdv6.Text = "Consultar"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.White
        Me.GradientPanel11.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel11.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel11.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(476, 10)
        Me.GradientPanel11.TabIndex = 556
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.Enabled = False
        Me.txtPeriodo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(163, 19)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 557
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'frmSeleccionCuentaFinanciera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 13)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Cuentas Financieras"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Saldos disponibles"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(476, 260)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Controls.Add(Me.ButtonAdv6)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionCuentaFinanciera"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents idEstado As ColumnHeader
    Friend WithEvents Cuenta As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
End Class

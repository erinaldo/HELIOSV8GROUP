Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFiltroPeriodoVendedor
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.TExtAnio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoOperacion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboVendedores = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnAceptar = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.cboTipoBusqueda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.lblTipoBusqueda = New System.Windows.Forms.Label()
        Me.datetimeFecha = New System.Windows.Forms.DateTimePicker()
        CType(Me.TExtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 10
        Me.BunifuElipse1.TargetControl = Me
        '
        'TExtAnio
        '
        Me.TExtAnio.BackGroundColor = System.Drawing.Color.White
        Me.TExtAnio.BeforeTouchSize = New System.Drawing.Size(63, 27)
        Me.TExtAnio.BorderColor = System.Drawing.Color.Silver
        Me.TExtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TExtAnio.CurrencyDecimalDigits = 0
        Me.TExtAnio.CurrencyGroupSeparator = ""
        Me.TExtAnio.CurrencySymbol = ""
        Me.TExtAnio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TExtAnio.DecimalValue = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.TExtAnio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TExtAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TExtAnio.Location = New System.Drawing.Point(325, 26)
        Me.TExtAnio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TExtAnio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TExtAnio.Name = "TExtAnio"
        Me.TExtAnio.NullString = ""
        Me.TExtAnio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TExtAnio.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TExtAnio.Size = New System.Drawing.Size(63, 27)
        Me.TExtAnio.TabIndex = 595
        Me.TExtAnio.Text = "2019"
        Me.TExtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 594
        Me.Label1.Text = "Busqueda Por:"
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(174, 24)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(145, 29)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(174, 24)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 593
        '
        'cboTipoOperacion
        '
        Me.cboTipoOperacion.BackColor = System.Drawing.Color.White
        Me.cboTipoOperacion.BeforeTouchSize = New System.Drawing.Size(116, 24)
        Me.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoOperacion.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoOperacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoOperacion.Items.AddRange(New Object() {"VENTAS", "PEDIDOS"})
        Me.cboTipoOperacion.Location = New System.Drawing.Point(14, 83)
        Me.cboTipoOperacion.Name = "cboTipoOperacion"
        Me.cboTipoOperacion.Size = New System.Drawing.Size(116, 24)
        Me.cboTipoOperacion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoOperacion.TabIndex = 597
        Me.cboTipoOperacion.Text = "VENTAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 19)
        Me.Label2.TabIndex = 596
        Me.Label2.Text = "Tipo Operacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(141, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 19)
        Me.Label3.TabIndex = 598
        Me.Label3.Text = "Vendedor"
        '
        'cboVendedores
        '
        Me.cboVendedores.BackColor = System.Drawing.Color.White
        Me.cboVendedores.BeforeTouchSize = New System.Drawing.Size(243, 24)
        Me.cboVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendedores.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendedores.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboVendedores.Location = New System.Drawing.Point(145, 85)
        Me.cboVendedores.Name = "cboVendedores"
        Me.cboVendedores.Size = New System.Drawing.Size(243, 24)
        Me.cboVendedores.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboVendedores.TabIndex = 599
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnAceptar.BeforeTouchSize = New System.Drawing.Size(102, 31)
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.IsBackStageButton = False
        Me.btnAceptar.Location = New System.Drawing.Point(145, 125)
        Me.btnAceptar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(102, 31)
        Me.btnAceptar.TabIndex = 600
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyle = True
        '
        'cboTipoBusqueda
        '
        Me.cboTipoBusqueda.BackColor = System.Drawing.Color.White
        Me.cboTipoBusqueda.BeforeTouchSize = New System.Drawing.Size(116, 24)
        Me.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBusqueda.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBusqueda.Items.AddRange(New Object() {"PERIODO", "DIA"})
        Me.cboTipoBusqueda.Location = New System.Drawing.Point(14, 29)
        Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
        Me.cboTipoBusqueda.Size = New System.Drawing.Size(116, 24)
        Me.cboTipoBusqueda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoBusqueda.TabIndex = 601
        Me.cboTipoBusqueda.Text = "PERIODO"
        '
        'lblTipoBusqueda
        '
        Me.lblTipoBusqueda.AutoSize = True
        Me.lblTipoBusqueda.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoBusqueda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.lblTipoBusqueda.Location = New System.Drawing.Point(141, 7)
        Me.lblTipoBusqueda.Name = "lblTipoBusqueda"
        Me.lblTipoBusqueda.Size = New System.Drawing.Size(142, 19)
        Me.lblTipoBusqueda.TabIndex = 602
        Me.lblTipoBusqueda.Text = "Seleccione Periodo:"
        '
        'datetimeFecha
        '
        Me.datetimeFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimeFecha.Location = New System.Drawing.Point(145, 29)
        Me.datetimeFecha.Name = "datetimeFecha"
        Me.datetimeFecha.Size = New System.Drawing.Size(108, 20)
        Me.datetimeFecha.TabIndex = 603
        Me.datetimeFecha.Visible = False
        '
        'FormFiltroPeriodoVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BorderThickness = 4
        Me.CaptionButtonColor = System.Drawing.Color.Black
        Me.CaptionButtonHoverColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(400, 162)
        Me.Controls.Add(Me.cboMesCompra)
        Me.Controls.Add(Me.datetimeFecha)
        Me.Controls.Add(Me.lblTipoBusqueda)
        Me.Controls.Add(Me.cboTipoBusqueda)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cboVendedores)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoOperacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TExtAnio)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormFiltroPeriodoVendedor"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        CType(Me.TExtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents TExtAnio As Tools.CurrencyTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboMesCompra As Tools.ComboBoxAdv
    Friend WithEvents cboVendedores As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents cboTipoOperacion As Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAceptar As RoundButton2
    Friend WithEvents lblTipoBusqueda As Label
    Friend WithEvents cboTipoBusqueda As Tools.ComboBoxAdv
    Friend WithEvents datetimeFecha As DateTimePicker
End Class

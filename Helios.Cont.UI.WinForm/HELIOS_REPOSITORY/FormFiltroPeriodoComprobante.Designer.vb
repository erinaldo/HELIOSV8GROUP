Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFiltroPeriodoComprobante
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
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.TExtAnio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboComprobantes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TExtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(174, 24)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(21, 20)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(174, 24)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccione Periodo:"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(102, 31)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(93, 119)
        Me.RoundButton21.MetroColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(102, 31)
        Me.RoundButton21.TabIndex = 5
        Me.RoundButton21.Text = "Aceptar"
        Me.RoundButton21.UseVisualStyle = True
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
        Me.TExtAnio.Location = New System.Drawing.Point(201, 18)
        Me.TExtAnio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TExtAnio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TExtAnio.Name = "TExtAnio"
        Me.TExtAnio.NullString = ""
        Me.TExtAnio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.TExtAnio.ReadOnlyBackColor = System.Drawing.Color.White
        Me.TExtAnio.Size = New System.Drawing.Size(63, 27)
        Me.TExtAnio.TabIndex = 592
        Me.TExtAnio.Text = "2019"
        Me.TExtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(18, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 19)
        Me.Label2.TabIndex = 593
        Me.Label2.Text = "Tipo de Comprobantes"
        '
        'cboComprobantes
        '
        Me.cboComprobantes.BackColor = System.Drawing.Color.White
        Me.cboComprobantes.BeforeTouchSize = New System.Drawing.Size(244, 24)
        Me.cboComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComprobantes.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComprobantes.Items.AddRange(New Object() {"VENTAS ELECTRONICAS", "VENTAS FISICAS", "TODAS LAS VENTAS", "NOTAS DE VENTA"})
        Me.cboComprobantes.Location = New System.Drawing.Point(20, 85)
        Me.cboComprobantes.Name = "cboComprobantes"
        Me.cboComprobantes.Size = New System.Drawing.Size(244, 24)
        Me.cboComprobantes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboComprobantes.TabIndex = 594
        Me.cboComprobantes.Text = "VENTAS ELECTRONICAS"
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 10
        Me.BunifuElipse1.TargetControl = Me
        '
        'FormFiltroPeriodoComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BorderThickness = 4
        Me.CaptionButtonColor = System.Drawing.Color.Black
        Me.CaptionButtonHoverColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(290, 158)
        Me.Controls.Add(Me.cboComprobantes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TExtAnio)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMesCompra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MetroColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.MinimizeBox = False
        Me.Name = "FormFiltroPeriodoComprobante"
        Me.ShowIcon = False
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TExtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboMesCompra As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents TExtAnio As Tools.CurrencyTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboComprobantes As Tools.ComboBoxAdv
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAgregarBienes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAgregarBienes))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtCodAgreBien = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtdescAgreBien = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.cbUniMediAgre = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtCantAgregBien = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        CType(Me.txtCodAgreBien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdescAgreBien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cbUniMediAgre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantAgregBien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodAgreBien
        '
        Me.txtCodAgreBien.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCodAgreBien.BeforeTouchSize = New System.Drawing.Size(186, 23)
        Me.txtCodAgreBien.BorderColor = System.Drawing.Color.Silver
        Me.txtCodAgreBien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodAgreBien.CornerRadius = 4
        Me.txtCodAgreBien.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCodAgreBien.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodAgreBien.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodAgreBien.Location = New System.Drawing.Point(12, 64)
        Me.txtCodAgreBien.MaxLength = 180
        Me.txtCodAgreBien.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCodAgreBien.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCodAgreBien.Name = "txtCodAgreBien"
        Me.txtCodAgreBien.Size = New System.Drawing.Size(186, 23)
        Me.txtCodAgreBien.TabIndex = 686
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 685
        Me.Label6.Text = "Código del bien"
        '
        'txtdescAgreBien
        '
        Me.txtdescAgreBien.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdescAgreBien.BeforeTouchSize = New System.Drawing.Size(186, 23)
        Me.txtdescAgreBien.BorderColor = System.Drawing.Color.Silver
        Me.txtdescAgreBien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdescAgreBien.CornerRadius = 4
        Me.txtdescAgreBien.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdescAgreBien.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescAgreBien.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdescAgreBien.Location = New System.Drawing.Point(12, 112)
        Me.txtdescAgreBien.MaxLength = 180
        Me.txtdescAgreBien.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdescAgreBien.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdescAgreBien.Name = "txtdescAgreBien"
        Me.txtdescAgreBien.Size = New System.Drawing.Size(370, 23)
        Me.txtdescAgreBien.TabIndex = 688
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 687
        Me.Label1.Text = "Descripción del bien"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 689
        Me.Label2.Text = "Unidad de medida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 691
        Me.Label3.Text = "Cantidad"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(401, 45)
        Me.ToolStrip1.TabIndex = 693
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(42, 42)
        Me.btnGuardar.Text = "ToolStripButton1"
        '
        'cbUniMediAgre
        '
        Me.cbUniMediAgre.BackColor = System.Drawing.Color.White
        Me.cbUniMediAgre.BeforeTouchSize = New System.Drawing.Size(183, 21)
        Me.cbUniMediAgre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUniMediAgre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUniMediAgre.Location = New System.Drawing.Point(12, 162)
        Me.cbUniMediAgre.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbUniMediAgre.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbUniMediAgre.Name = "cbUniMediAgre"
        Me.cbUniMediAgre.Size = New System.Drawing.Size(183, 21)
        Me.cbUniMediAgre.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbUniMediAgre.TabIndex = 694
        '
        'txtCantAgregBien
        '
        Me.txtCantAgregBien.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCantAgregBien.BeforeTouchSize = New System.Drawing.Size(94, 21)
        Me.txtCantAgregBien.BorderColor = System.Drawing.Color.Silver
        Me.txtCantAgregBien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantAgregBien.DecimalPlaces = 3
        Me.txtCantAgregBien.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantAgregBien.Location = New System.Drawing.Point(12, 210)
        Me.txtCantAgregBien.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtCantAgregBien.MetroColor = System.Drawing.Color.Silver
        Me.txtCantAgregBien.Name = "txtCantAgregBien"
        Me.txtCantAgregBien.Size = New System.Drawing.Size(94, 21)
        Me.txtCantAgregBien.TabIndex = 695
        Me.txtCantAgregBien.TabStop = False
        Me.txtCantAgregBien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCantAgregBien.ThousandsSeparator = True
        Me.txtCantAgregBien.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'FormAgregarBienes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.MenuHighlight
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "AGREGAR BIENES"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(401, 243)
        Me.Controls.Add(Me.txtCantAgregBien)
        Me.Controls.Add(Me.cbUniMediAgre)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtdescAgreBien)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodAgreBien)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormAgregarBienes"
        Me.ShowIcon = False
        CType(Me.txtCodAgreBien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdescAgreBien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cbUniMediAgre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantAgregBien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCodAgreBien As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents txtdescAgreBien As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents cbUniMediAgre As Tools.ComboBoxAdv
    Friend WithEvents txtCantAgregBien As Tools.NumericUpDownExt
End Class

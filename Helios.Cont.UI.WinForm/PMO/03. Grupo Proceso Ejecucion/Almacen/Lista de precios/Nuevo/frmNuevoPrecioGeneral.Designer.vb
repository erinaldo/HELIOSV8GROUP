<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoPrecioGeneral
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrecio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPorcemtaje = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPorcemtaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv15.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(209, 135)
        Me.ButtonAdv15.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv15.TabIndex = 434
        Me.ButtonAdv15.Text = "GRABAR"
        Me.ButtonAdv15.UseVisualStyle = True
        Me.ButtonAdv15.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 12)
        Me.Label2.TabIndex = 427
        Me.Label2.Text = "TASA %"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 12)
        Me.Label1.TabIndex = 425
        Me.Label1.Text = "DESCRIPCIÓN DE PRECIO"
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.White
        Me.txtPrecio.BeforeTouchSize = New System.Drawing.Size(299, 22)
        Me.txtPrecio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecio.Location = New System.Drawing.Point(11, 35)
        Me.txtPrecio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(299, 22)
        Me.txtPrecio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPrecio.TabIndex = 435
        '
        'txtPorcemtaje
        '
        Me.txtPorcemtaje.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtPorcemtaje.BeforeTouchSize = New System.Drawing.Size(299, 22)
        Me.txtPorcemtaje.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtPorcemtaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcemtaje.CurrencySymbol = ""
        Me.txtPorcemtaje.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPorcemtaje.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.txtPorcemtaje.Location = New System.Drawing.Point(11, 91)
        Me.txtPorcemtaje.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtPorcemtaje.Name = "txtPorcemtaje"
        Me.txtPorcemtaje.NullString = ""
        Me.txtPorcemtaje.Size = New System.Drawing.Size(100, 22)
        Me.txtPorcemtaje.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPorcemtaje.TabIndex = 436
        Me.txtPorcemtaje.Text = "1.00"
        '
        'frmNuevoPrecioGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(15, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Nuevo Precio General "
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(322, 175)
        Me.Controls.Add(Me.txtPorcemtaje)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.ButtonAdv15)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoPrecioGeneral"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPorcemtaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAdv15 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPorcemtaje As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class

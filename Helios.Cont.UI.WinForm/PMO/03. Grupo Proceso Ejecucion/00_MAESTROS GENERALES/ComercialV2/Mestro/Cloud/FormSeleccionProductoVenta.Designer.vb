Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSeleccionProductoVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSeleccionProductoVenta))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChMenor = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ChMayor = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChGranMayor = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCantidad = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextArticulo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChGranMayor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ChMayor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ChMenor)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 65)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Indicar Precio"
        '
        'ChMenor
        '
        Me.ChMenor.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ChMenor.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMenor.Checked = True
        Me.ChMenor.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChMenor.ForeColor = System.Drawing.Color.White
        Me.ChMenor.Location = New System.Drawing.Point(48, 32)
        Me.ChMenor.Name = "ChMenor"
        Me.ChMenor.Size = New System.Drawing.Size(20, 20)
        Me.ChMenor.TabIndex = 516
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(69, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 14)
        Me.Label7.TabIndex = 515
        Me.Label7.Text = "Menor"
        '
        'ChMayor
        '
        Me.ChMayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMayor.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMayor.Checked = False
        Me.ChMayor.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.ChMayor.ForeColor = System.Drawing.Color.White
        Me.ChMayor.Location = New System.Drawing.Point(124, 32)
        Me.ChMayor.Name = "ChMayor"
        Me.ChMayor.Size = New System.Drawing.Size(20, 20)
        Me.ChMayor.TabIndex = 518
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(147, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 517
        Me.Label1.Text = "Mayor"
        '
        'ChGranMayor
        '
        Me.ChGranMayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChGranMayor.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChGranMayor.Checked = False
        Me.ChGranMayor.CheckedOnColor = System.Drawing.Color.Goldenrod
        Me.ChGranMayor.ForeColor = System.Drawing.Color.White
        Me.ChGranMayor.Location = New System.Drawing.Point(196, 32)
        Me.ChGranMayor.Name = "ChGranMayor"
        Me.ChGranMayor.Size = New System.Drawing.Size(20, 20)
        Me.ChGranMayor.TabIndex = 520
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(219, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 519
        Me.Label2.Text = "Gran Mayor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(120, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 14)
        Me.Label3.TabIndex = 516
        Me.Label3.Text = "Indícar cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtCantidad.BeforeTouchSize = New System.Drawing.Size(338, 45)
        Me.txtCantidad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.CurrencySymbol = ""
        Me.txtCantidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCantidad.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.txtCantidad.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Black
        Me.txtCantidad.Location = New System.Drawing.Point(209, 157)
        Me.txtCantidad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCantidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.NullString = ""
        Me.txtCantidad.PositiveColor = System.Drawing.Color.Black
        Me.txtCantidad.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtCantidad.Size = New System.Drawing.Size(141, 24)
        Me.txtCantidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCantidad.TabIndex = 517
        Me.txtCantidad.Text = "1.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(109, 30)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(130, 199)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(109, 30)
        Me.RoundButton21.TabIndex = 518
        Me.RoundButton21.Text = "Vender"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 14)
        Me.Label4.TabIndex = 519
        Me.Label4.Text = "Artículo elegido"
        '
        'TextArticulo
        '
        Me.TextArticulo.BackColor = System.Drawing.Color.White
        Me.TextArticulo.BeforeTouchSize = New System.Drawing.Size(338, 45)
        Me.TextArticulo.BorderColor = System.Drawing.Color.DarkGray
        Me.TextArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextArticulo.CornerRadius = 5
        Me.TextArticulo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextArticulo.Enabled = False
        Me.TextArticulo.Location = New System.Drawing.Point(12, 100)
        Me.TextArticulo.Metrocolor = System.Drawing.Color.DarkGray
        Me.TextArticulo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextArticulo.Multiline = True
        Me.TextArticulo.Name = "TextArticulo"
        Me.TextArticulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextArticulo.Size = New System.Drawing.Size(338, 45)
        Me.TextArticulo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextArticulo.TabIndex = 520
        Me.TextArticulo.Visible = False
        '
        'FormSeleccionProductoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(150, 24)
        CaptionLabel1.Text = "Artículo elegido"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(368, 233)
        Me.Controls.Add(Me.TextArticulo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSeleccionProductoVenta"
        Me.ShowIcon = False
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ChGranMayor As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label2 As Label
    Friend WithEvents ChMayor As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChMenor As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCantidad As Tools.CurrencyTextBox
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Label4 As Label
    Friend WithEvents TextArticulo As Tools.TextBoxExt
End Class

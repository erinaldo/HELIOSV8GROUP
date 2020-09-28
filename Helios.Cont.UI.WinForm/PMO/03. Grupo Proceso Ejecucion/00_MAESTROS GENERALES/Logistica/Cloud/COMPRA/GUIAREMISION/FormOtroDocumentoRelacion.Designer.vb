Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOtroDocumentoRelacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOtroDocumentoRelacion))
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbOtroDocRelac = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtotroDocNum = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuarOtroDoc = New System.Windows.Forms.ToolStripButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.cbOtroDocRelac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtotroDocNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 49)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(109, 13)
        Me.Label25.TabIndex = 682
        Me.Label25.Text = "Tipo de documento"
        '
        'cbOtroDocRelac
        '
        Me.cbOtroDocRelac.BackColor = System.Drawing.Color.White
        Me.cbOtroDocRelac.BeforeTouchSize = New System.Drawing.Size(331, 21)
        Me.cbOtroDocRelac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOtroDocRelac.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOtroDocRelac.Location = New System.Drawing.Point(12, 67)
        Me.cbOtroDocRelac.Name = "cbOtroDocRelac"
        Me.cbOtroDocRelac.Size = New System.Drawing.Size(331, 21)
        Me.cbOtroDocRelac.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbOtroDocRelac.TabIndex = 683
        '
        'txtotroDocNum
        '
        Me.txtotroDocNum.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtotroDocNum.BeforeTouchSize = New System.Drawing.Size(195, 23)
        Me.txtotroDocNum.BorderColor = System.Drawing.Color.Silver
        Me.txtotroDocNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtotroDocNum.CornerRadius = 4
        Me.txtotroDocNum.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtotroDocNum.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotroDocNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtotroDocNum.Location = New System.Drawing.Point(12, 111)
        Me.txtotroDocNum.MaxLength = 180
        Me.txtotroDocNum.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtotroDocNum.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtotroDocNum.Name = "txtotroDocNum"
        Me.txtotroDocNum.Size = New System.Drawing.Size(195, 23)
        Me.txtotroDocNum.TabIndex = 685
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(13, 92)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(130, 13)
        Me.Label26.TabIndex = 684
        Me.Label26.Text = "Número de Documento"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuarOtroDoc})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(383, 42)
        Me.ToolStrip1.TabIndex = 782
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuarOtroDoc
        '
        Me.btnGuarOtroDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuarOtroDoc.Image = CType(resources.GetObject("btnGuarOtroDoc.Image"), System.Drawing.Image)
        Me.btnGuarOtroDoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuarOtroDoc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuarOtroDoc.Name = "btnGuarOtroDoc"
        Me.btnGuarOtroDoc.Size = New System.Drawing.Size(39, 39)
        Me.btnGuarOtroDoc.Text = "ToolStripButton1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormOtroDocumentoRelacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaption
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(383, 137)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtotroDocNum)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cbOtroDocRelac)
        Me.Name = "FormOtroDocumentoRelacion"
        Me.ShowIcon = False
        Me.Text = "Agregar Documento Relacionado"
        CType(Me.cbOtroDocRelac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtotroDocNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label25 As Label
    Friend WithEvents cbOtroDocRelac As Tools.ComboBoxAdv
    Friend WithEvents txtotroDocNum As Tools.TextBoxExt
    Friend WithEvents Label26 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuarOtroDoc As ToolStripButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class

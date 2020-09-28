<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOrganigramaEmpresa
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOrganigramaEmpresa))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.trOrganigrama = New System.Windows.Forms.TreeView()
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.model1 = New Syncfusion.Windows.Forms.Diagram.Model(Me.components)
        CType(Me.model1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trOrganigrama
        '
        Me.trOrganigrama.FullRowSelect = True
        Me.trOrganigrama.Location = New System.Drawing.Point(0, 0)
        Me.trOrganigrama.Name = "trOrganigrama"
        Me.trOrganigrama.Size = New System.Drawing.Size(432, 419)
        Me.trOrganigrama.TabIndex = 622
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.DimGray
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(110, 25)
        Me.ButtonAdv15.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv15.Image = CType(resources.GetObject("ButtonAdv15.Image"), System.Drawing.Image)
        Me.ButtonAdv15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(322, 425)
        Me.ButtonAdv15.MetroColor = System.Drawing.Color.DimGray
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(110, 25)
        Me.ButtonAdv15.TabIndex = 623
        Me.ButtonAdv15.Text = "Cerrar"
        Me.ButtonAdv15.UseVisualStyle = True
        '
        'model1
        '
        Me.model1.AlignmentType = AlignmentType.SelectedNode
        Me.model1.BackgroundStyle.PathBrushStyle = Syncfusion.Windows.Forms.Diagram.PathGradientBrushStyle.RectangleCenter
        Me.model1.DocumentScale.DisplayName = "No Scale"
        Me.model1.DocumentScale.Height = 1.0!
        Me.model1.DocumentScale.Width = 1.0!
        Me.model1.DocumentSize.Height = 1000.0!
        Me.model1.DocumentSize.Width = 1000.0!
        Me.model1.LineStyle.DashPattern = Nothing
        Me.model1.LineStyle.LineColor = System.Drawing.Color.Black
        Me.model1.LineStyle.LineWidth = 0!
        Me.model1.LogicalSize = New System.Drawing.SizeF(1000.0!, 1000.0!)
        Me.model1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        '
        'FormOrganigramaEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CaptionBarHeight = 40
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.ForeColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(20, 7)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(28, 28)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(50, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Organigrama - Empresa"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(434, 451)
        Me.Controls.Add(Me.ButtonAdv15)
        Me.Controls.Add(Me.trOrganigrama)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOrganigramaEmpresa"
        Me.ShowIcon = False
        CType(Me.model1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents trOrganigrama As TreeView
    Friend WithEvents ButtonAdv15 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents model1 As Syncfusion.Windows.Forms.Diagram.Model
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrabajadorBusqueda
    Inherits frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrabajadorBusqueda))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.lsvListadoTrab = New System.Windows.Forms.ListView()
        Me.idEntidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTrabajador = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lsvListadoTrab
        '
        Me.lsvListadoTrab.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvListadoTrab.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idEntidad, Me.ColumnHeader3, Me.ColumnHeader1})
        Me.lsvListadoTrab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsvListadoTrab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lsvListadoTrab.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lsvListadoTrab.FullRowSelect = True
        Me.lsvListadoTrab.HideSelection = False
        Me.lsvListadoTrab.Location = New System.Drawing.Point(0, 61)
        Me.lsvListadoTrab.MultiSelect = False
        Me.lsvListadoTrab.Name = "lsvListadoTrab"
        Me.lsvListadoTrab.Size = New System.Drawing.Size(414, 322)
        Me.lsvListadoTrab.TabIndex = 503
        Me.lsvListadoTrab.UseCompatibleStateImageBehavior = False
        Me.lsvListadoTrab.View = System.Windows.Forms.View.Details
        '
        'idEntidad
        '
        Me.idEntidad.Text = "ID"
        Me.idEntidad.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Número"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 250
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(238, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt1.Location = New System.Drawing.Point(12, 30)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.NearImage = CType(resources.GetObject("TextBoxExt1.NearImage"), System.Drawing.Image)
        Me.TextBoxExt1.Size = New System.Drawing.Size(119, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 502
        '
        'txtTrabajador
        '
        Me.txtTrabajador.BackColor = System.Drawing.Color.White
        Me.txtTrabajador.BeforeTouchSize = New System.Drawing.Size(238, 22)
        Me.txtTrabajador.BorderColor = System.Drawing.Color.Silver
        Me.txtTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrabajador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTrabajador.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrabajador.Enabled = False
        Me.txtTrabajador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTrabajador.Location = New System.Drawing.Point(137, 30)
        Me.txtTrabajador.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtTrabajador.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTrabajador.Name = "txtTrabajador"
        Me.txtTrabajador.NearImage = CType(resources.GetObject("txtTrabajador.NearImage"), System.Drawing.Image)
        Me.txtTrabajador.Size = New System.Drawing.Size(238, 22)
        Me.txtTrabajador.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTrabajador.TabIndex = 501
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BackColor = System.Drawing.Color.White
        Me.GradientPanel17.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GradientPanel17.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel17.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(414, 10)
        Me.GradientPanel17.TabIndex = 504
        '
        'PictureBox5
        '
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(377, 27)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 509
        Me.PictureBox5.TabStop = False
        '
        'frmTrabajadorBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Trabajadores"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Búsqueda avanzada"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(414, 383)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.GradientPanel17)
        Me.Controls.Add(Me.lsvListadoTrab)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.txtTrabajador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTrabajadorBusqueda"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lsvListadoTrab As ListView
    Friend WithEvents idEntidad As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtTrabajador As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel17 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PictureBox5 As PictureBox
End Class

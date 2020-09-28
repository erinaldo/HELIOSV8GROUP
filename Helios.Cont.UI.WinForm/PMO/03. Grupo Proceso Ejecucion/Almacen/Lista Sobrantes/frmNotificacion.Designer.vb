<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotificacion
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotificacion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtEstablecimiento = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dropDownBtn = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtEmpresa = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.lstTipoExistencia = New System.Windows.Forms.ListBox()
        Me.lstEstables = New System.Windows.Forms.ListBox()
        Me.PopupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(657, 72)
        Me.Panel1.TabIndex = 293
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Controls.Add(Me.txtEstablecimiento)
        Me.GradientPanel2.Location = New System.Drawing.Point(7, 27)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(264, 41)
        Me.GradientPanel2.TabIndex = 204
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(234, 14)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.TabIndex = 207
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtEstablecimiento
        '
        Me.txtEstablecimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstablecimiento.Location = New System.Drawing.Point(14, 14)
        Me.txtEstablecimiento.Name = "txtEstablecimiento"
        Me.txtEstablecimiento.ReadOnly = True
        Me.txtEstablecimiento.Size = New System.Drawing.Size(216, 19)
        Me.txtEstablecimiento.TabIndex = 206
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(7, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(264, 24)
        Me.Panel4.TabIndex = 203
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(10, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(194, 19)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Establecimiento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.dropDownBtn)
        Me.GradientPanel1.Controls.Add(Me.txtEmpresa)
        Me.GradientPanel1.Location = New System.Drawing.Point(277, 27)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(243, 41)
        Me.GradientPanel1.TabIndex = 202
        '
        'dropDownBtn
        '
        Me.dropDownBtn.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dropDownBtn.BackColor = System.Drawing.SystemColors.Highlight
        Me.dropDownBtn.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.ForeColor = System.Drawing.Color.White
        Me.dropDownBtn.Image = CType(resources.GetObject("dropDownBtn.Image"), System.Drawing.Image)
        Me.dropDownBtn.IsBackStageButton = False
        Me.dropDownBtn.Location = New System.Drawing.Point(207, 14)
        Me.dropDownBtn.Name = "dropDownBtn"
        Me.dropDownBtn.Size = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.TabIndex = 207
        Me.dropDownBtn.UseVisualStyle = True
        '
        'txtEmpresa
        '
        Me.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpresa.Location = New System.Drawing.Point(3, 14)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(200, 19)
        Me.txtEmpresa.TabIndex = 206
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(277, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(243, 24)
        Me.Panel3.TabIndex = 201
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(10, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(194, 19)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Empresa"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.lblDescripcion, Me.lblTitulo, Me.lblPerido})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(657, 25)
        Me.ToolStrip5.TabIndex = 292
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        Me.ToolStripButton7.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(179, 22)
        Me.lblDescripcion.Text = "STOCK: PRODUCTOS EN TRANSITO"
        Me.lblDescripcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lstTipoExistencia
        '
        Me.lstTipoExistencia.FormattingEnabled = True
        Me.lstTipoExistencia.Location = New System.Drawing.Point(156, 133)
        Me.lstTipoExistencia.Name = "lstTipoExistencia"
        Me.lstTipoExistencia.Size = New System.Drawing.Size(103, 134)
        Me.lstTipoExistencia.TabIndex = 294
        '
        'lstEstables
        '
        Me.lstEstables.FormattingEnabled = True
        Me.lstEstables.Location = New System.Drawing.Point(340, 133)
        Me.lstEstables.Name = "lstEstables"
        Me.lstEstables.Size = New System.Drawing.Size(131, 147)
        Me.lstEstables.TabIndex = 295
        '
        'PopupControlContainer1
        '
        Me.PopupControlContainer1.Location = New System.Drawing.Point(38, 270)
        Me.PopupControlContainer1.Name = "PopupControlContainer1"
        Me.PopupControlContainer1.Size = New System.Drawing.Size(200, 100)
        Me.PopupControlContainer1.TabIndex = 296
        '
        'frmNotificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 388)
        Me.Controls.Add(Me.PopupControlContainer1)
        Me.Controls.Add(Me.lstEstables)
        Me.Controls.Add(Me.lstTipoExistencia)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip5)
        Me.Name = "frmNotificacion"
        Me.Text = "frmNotificacion"
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtEstablecimiento As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents dropDownBtn As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtEmpresa As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lstTipoExistencia As System.Windows.Forms.ListBox
    Friend WithEvents lstEstables As System.Windows.Forms.ListBox
    Friend WithEvents PopupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCPrincipalSistema
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalSistema))
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnCierreMensual = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnInventarioInicial = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnImpresion = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnConfiguracionFinanciera = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.btnCierreMensual)
        Me.PanelTop.Controls.Add(Me.btnInventarioInicial)
        Me.PanelTop.Controls.Add(Me.btnImpresion)
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.btnConfiguracionFinanciera)
        Me.PanelTop.Controls.Add(Me.sliderTop)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 45)
        Me.PanelTop.TabIndex = 3
        '
        'btnCierreMensual
        '
        Me.btnCierreMensual.Activecolor = System.Drawing.Color.SandyBrown
        Me.btnCierreMensual.BackColor = System.Drawing.Color.SandyBrown
        Me.btnCierreMensual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCierreMensual.BorderRadius = 5
        Me.btnCierreMensual.ButtonText = "Cierre Mensual"
        Me.btnCierreMensual.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCierreMensual.DisabledColor = System.Drawing.Color.Gray
        Me.btnCierreMensual.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCierreMensual.Iconimage = CType(resources.GetObject("btnCierreMensual.Iconimage"), System.Drawing.Image)
        Me.btnCierreMensual.Iconimage_right = Nothing
        Me.btnCierreMensual.Iconimage_right_Selected = Nothing
        Me.btnCierreMensual.Iconimage_Selected = Nothing
        Me.btnCierreMensual.IconMarginLeft = 0
        Me.btnCierreMensual.IconMarginRight = 0
        Me.btnCierreMensual.IconRightVisible = True
        Me.btnCierreMensual.IconRightZoom = 0R
        Me.btnCierreMensual.IconVisible = True
        Me.btnCierreMensual.IconZoom = 40.0R
        Me.btnCierreMensual.IsTab = False
        Me.btnCierreMensual.Location = New System.Drawing.Point(625, 10)
        Me.btnCierreMensual.Name = "btnCierreMensual"
        Me.btnCierreMensual.Normalcolor = System.Drawing.Color.SandyBrown
        Me.btnCierreMensual.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnCierreMensual.OnHoverTextColor = System.Drawing.Color.White
        Me.btnCierreMensual.selected = False
        Me.btnCierreMensual.Size = New System.Drawing.Size(127, 25)
        Me.btnCierreMensual.TabIndex = 776
        Me.btnCierreMensual.Text = "Cierre Mensual"
        Me.btnCierreMensual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCierreMensual.Textcolor = System.Drawing.Color.White
        Me.btnCierreMensual.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnInventarioInicial
        '
        Me.btnInventarioInicial.Activecolor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnInventarioInicial.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnInventarioInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInventarioInicial.BorderRadius = 0
        Me.btnInventarioInicial.ButtonText = "INVENTARIO INICIAL"
        Me.btnInventarioInicial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInventarioInicial.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnInventarioInicial.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventarioInicial.Iconcolor = System.Drawing.Color.Transparent
        Me.btnInventarioInicial.Iconimage = Nothing
        Me.btnInventarioInicial.Iconimage_right = Nothing
        Me.btnInventarioInicial.Iconimage_right_Selected = Nothing
        Me.btnInventarioInicial.Iconimage_Selected = Nothing
        Me.btnInventarioInicial.IconMarginLeft = 0
        Me.btnInventarioInicial.IconMarginRight = 0
        Me.btnInventarioInicial.IconRightVisible = True
        Me.btnInventarioInicial.IconRightZoom = 0R
        Me.btnInventarioInicial.IconVisible = True
        Me.btnInventarioInicial.IconZoom = 90.0R
        Me.btnInventarioInicial.IsTab = False
        Me.btnInventarioInicial.Location = New System.Drawing.Point(194, 15)
        Me.btnInventarioInicial.Margin = New System.Windows.Forms.Padding(2)
        Me.btnInventarioInicial.Name = "btnInventarioInicial"
        Me.btnInventarioInicial.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnInventarioInicial.OnHovercolor = System.Drawing.Color.SeaGreen
        Me.btnInventarioInicial.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnInventarioInicial.selected = False
        Me.btnInventarioInicial.Size = New System.Drawing.Size(145, 18)
        Me.btnInventarioInicial.TabIndex = 775
        Me.btnInventarioInicial.Text = "INVENTARIO INICIAL"
        Me.btnInventarioInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnInventarioInicial.Textcolor = System.Drawing.Color.White
        Me.btnInventarioInicial.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnImpresion
        '
        Me.btnImpresion.Activecolor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnImpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnImpresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImpresion.BorderRadius = 0
        Me.btnImpresion.ButtonText = "IMPRESION"
        Me.btnImpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImpresion.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnImpresion.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpresion.Iconcolor = System.Drawing.Color.Transparent
        Me.btnImpresion.Iconimage = Nothing
        Me.btnImpresion.Iconimage_right = Nothing
        Me.btnImpresion.Iconimage_right_Selected = Nothing
        Me.btnImpresion.Iconimage_Selected = Nothing
        Me.btnImpresion.IconMarginLeft = 0
        Me.btnImpresion.IconMarginRight = 0
        Me.btnImpresion.IconRightVisible = True
        Me.btnImpresion.IconRightZoom = 0R
        Me.btnImpresion.IconVisible = True
        Me.btnImpresion.IconZoom = 90.0R
        Me.btnImpresion.IsTab = False
        Me.btnImpresion.Location = New System.Drawing.Point(346, 15)
        Me.btnImpresion.Margin = New System.Windows.Forms.Padding(2)
        Me.btnImpresion.Name = "btnImpresion"
        Me.btnImpresion.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnImpresion.OnHovercolor = System.Drawing.Color.SeaGreen
        Me.btnImpresion.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnImpresion.selected = False
        Me.btnImpresion.Size = New System.Drawing.Size(88, 18)
        Me.btnImpresion.TabIndex = 774
        Me.btnImpresion.Text = "IMPRESION"
        Me.btnImpresion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImpresion.Textcolor = System.Drawing.Color.White
        Me.btnImpresion.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = ""
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Enabled = False
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = CType(resources.GetObject("BunifuFlatButton2.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 60.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(3, 6)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(35, 29)
        Me.BunifuFlatButton2.TabIndex = 773
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnConfiguracionFinanciera
        '
        Me.btnConfiguracionFinanciera.Activecolor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnConfiguracionFinanciera.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnConfiguracionFinanciera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConfiguracionFinanciera.BorderRadius = 0
        Me.btnConfiguracionFinanciera.ButtonText = "CONFIG. FINANCIERA"
        Me.btnConfiguracionFinanciera.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfiguracionFinanciera.DisabledColor = System.Drawing.Color.Gray
        Me.btnConfiguracionFinanciera.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfiguracionFinanciera.Iconcolor = System.Drawing.Color.Transparent
        Me.btnConfiguracionFinanciera.Iconimage = Nothing
        Me.btnConfiguracionFinanciera.Iconimage_right = Nothing
        Me.btnConfiguracionFinanciera.Iconimage_right_Selected = Nothing
        Me.btnConfiguracionFinanciera.Iconimage_Selected = Nothing
        Me.btnConfiguracionFinanciera.IconMarginLeft = 0
        Me.btnConfiguracionFinanciera.IconMarginRight = 0
        Me.btnConfiguracionFinanciera.IconRightVisible = True
        Me.btnConfiguracionFinanciera.IconRightZoom = 0R
        Me.btnConfiguracionFinanciera.IconVisible = True
        Me.btnConfiguracionFinanciera.IconZoom = 90.0R
        Me.btnConfiguracionFinanciera.IsTab = False
        Me.btnConfiguracionFinanciera.Location = New System.Drawing.Point(37, 15)
        Me.btnConfiguracionFinanciera.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConfiguracionFinanciera.Name = "btnConfiguracionFinanciera"
        Me.btnConfiguracionFinanciera.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.btnConfiguracionFinanciera.OnHovercolor = System.Drawing.Color.SeaGreen
        Me.btnConfiguracionFinanciera.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnConfiguracionFinanciera.selected = False
        Me.btnConfiguracionFinanciera.Size = New System.Drawing.Size(148, 18)
        Me.btnConfiguracionFinanciera.TabIndex = 771
        Me.btnConfiguracionFinanciera.Text = "CONFIG. FINANCIERA"
        Me.btnConfiguracionFinanciera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnConfiguracionFinanciera.Textcolor = System.Drawing.Color.White
        Me.btnConfiguracionFinanciera.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(37, 38)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(150, 6)
        Me.sliderTop.TabIndex = 770
        Me.sliderTop.TabStop = False
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 45)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 526)
        Me.PanelBody.TabIndex = 4
        '
        'UCPrincipalSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalSistema"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents btnConfiguracionFinanciera As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents PanelBody As Panel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnImpresion As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnInventarioInicial As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnCierreMensual As Bunifu.Framework.UI.BunifuFlatButton
End Class

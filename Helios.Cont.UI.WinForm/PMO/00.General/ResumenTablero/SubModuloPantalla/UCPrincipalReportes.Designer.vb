<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCPrincipalReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalReportes))
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnReporteFinanzas = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnReporteCompras = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnReporteVentas = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.btnReporteFinanzas)
        Me.PanelTop.Controls.Add(Me.btnReporteCompras)
        Me.PanelTop.Controls.Add(Me.btnReporteVentas)
        Me.PanelTop.Controls.Add(Me.sliderTop)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 45)
        Me.PanelTop.TabIndex = 4
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(6, 7)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(35, 29)
        Me.BunifuFlatButton2.TabIndex = 776
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnReporteFinanzas
        '
        Me.btnReporteFinanzas.Activecolor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteFinanzas.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteFinanzas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReporteFinanzas.BorderRadius = 0
        Me.btnReporteFinanzas.ButtonText = "FINANZAS"
        Me.btnReporteFinanzas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporteFinanzas.DisabledColor = System.Drawing.Color.Gray
        Me.btnReporteFinanzas.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteFinanzas.Iconcolor = System.Drawing.Color.Transparent
        Me.btnReporteFinanzas.Iconimage = Nothing
        Me.btnReporteFinanzas.Iconimage_right = Nothing
        Me.btnReporteFinanzas.Iconimage_right_Selected = Nothing
        Me.btnReporteFinanzas.Iconimage_Selected = Nothing
        Me.btnReporteFinanzas.IconMarginLeft = 0
        Me.btnReporteFinanzas.IconMarginRight = 0
        Me.btnReporteFinanzas.IconRightVisible = True
        Me.btnReporteFinanzas.IconRightZoom = 0R
        Me.btnReporteFinanzas.IconVisible = True
        Me.btnReporteFinanzas.IconZoom = 90.0R
        Me.btnReporteFinanzas.IsTab = False
        Me.btnReporteFinanzas.Location = New System.Drawing.Point(222, 15)
        Me.btnReporteFinanzas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReporteFinanzas.Name = "btnReporteFinanzas"
        Me.btnReporteFinanzas.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteFinanzas.OnHovercolor = System.Drawing.Color.SlateGray
        Me.btnReporteFinanzas.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnReporteFinanzas.selected = False
        Me.btnReporteFinanzas.Size = New System.Drawing.Size(87, 18)
        Me.btnReporteFinanzas.TabIndex = 773
        Me.btnReporteFinanzas.Text = "FINANZAS"
        Me.btnReporteFinanzas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnReporteFinanzas.Textcolor = System.Drawing.Color.White
        Me.btnReporteFinanzas.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnReporteCompras
        '
        Me.btnReporteCompras.Activecolor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteCompras.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReporteCompras.BorderRadius = 0
        Me.btnReporteCompras.ButtonText = "COMPRAS"
        Me.btnReporteCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporteCompras.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnReporteCompras.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteCompras.Iconcolor = System.Drawing.Color.Transparent
        Me.btnReporteCompras.Iconimage = Nothing
        Me.btnReporteCompras.Iconimage_right = Nothing
        Me.btnReporteCompras.Iconimage_right_Selected = Nothing
        Me.btnReporteCompras.Iconimage_Selected = Nothing
        Me.btnReporteCompras.IconMarginLeft = 0
        Me.btnReporteCompras.IconMarginRight = 0
        Me.btnReporteCompras.IconRightVisible = True
        Me.btnReporteCompras.IconRightZoom = 0R
        Me.btnReporteCompras.IconVisible = True
        Me.btnReporteCompras.IconZoom = 90.0R
        Me.btnReporteCompras.IsTab = False
        Me.btnReporteCompras.Location = New System.Drawing.Point(126, 15)
        Me.btnReporteCompras.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReporteCompras.Name = "btnReporteCompras"
        Me.btnReporteCompras.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteCompras.OnHovercolor = System.Drawing.Color.SlateGray
        Me.btnReporteCompras.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnReporteCompras.selected = False
        Me.btnReporteCompras.Size = New System.Drawing.Size(89, 18)
        Me.btnReporteCompras.TabIndex = 772
        Me.btnReporteCompras.Text = "COMPRAS"
        Me.btnReporteCompras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnReporteCompras.Textcolor = System.Drawing.Color.White
        Me.btnReporteCompras.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnReporteVentas
        '
        Me.btnReporteVentas.Activecolor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteVentas.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReporteVentas.BorderRadius = 0
        Me.btnReporteVentas.ButtonText = "VENTAS"
        Me.btnReporteVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporteVentas.DisabledColor = System.Drawing.Color.Gray
        Me.btnReporteVentas.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteVentas.Iconcolor = System.Drawing.Color.Transparent
        Me.btnReporteVentas.Iconimage = Nothing
        Me.btnReporteVentas.Iconimage_right = Nothing
        Me.btnReporteVentas.Iconimage_right_Selected = Nothing
        Me.btnReporteVentas.Iconimage_Selected = Nothing
        Me.btnReporteVentas.IconMarginLeft = 0
        Me.btnReporteVentas.IconMarginRight = 0
        Me.btnReporteVentas.IconRightVisible = True
        Me.btnReporteVentas.IconRightZoom = 0R
        Me.btnReporteVentas.IconVisible = True
        Me.btnReporteVentas.IconZoom = 90.0R
        Me.btnReporteVentas.IsTab = False
        Me.btnReporteVentas.Location = New System.Drawing.Point(44, 15)
        Me.btnReporteVentas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReporteVentas.Name = "btnReporteVentas"
        Me.btnReporteVentas.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnReporteVentas.OnHovercolor = System.Drawing.Color.SlateGray
        Me.btnReporteVentas.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnReporteVentas.selected = False
        Me.btnReporteVentas.Size = New System.Drawing.Size(74, 18)
        Me.btnReporteVentas.TabIndex = 771
        Me.btnReporteVentas.Text = "VENTAS"
        Me.btnReporteVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnReporteVentas.Textcolor = System.Drawing.Color.White
        Me.btnReporteVentas.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(47, 36)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(70, 6)
        Me.sliderTop.TabIndex = 770
        Me.sliderTop.TabStop = False
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.White
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 45)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 526)
        Me.PanelBody.TabIndex = 305
        '
        'UCPrincipalReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalReportes"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnReporteFinanzas As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnReporteCompras As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnReporteVentas As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents PanelBody As Panel
End Class

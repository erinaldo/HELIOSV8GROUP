<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCPrincipalAlmacenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalAlmacenes))
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnOtrasSalidas = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnOtrasEntradas = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnCuentasPorPagar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnCuentasPorCobrar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.btnOtrasSalidas)
        Me.PanelTop.Controls.Add(Me.btnOtrasEntradas)
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.btnCuentasPorPagar)
        Me.PanelTop.Controls.Add(Me.btnCuentasPorCobrar)
        Me.PanelTop.Controls.Add(Me.sliderTop)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 45)
        Me.PanelTop.TabIndex = 3
        '
        'btnOtrasSalidas
        '
        Me.btnOtrasSalidas.Activecolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnOtrasSalidas.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnOtrasSalidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOtrasSalidas.BorderRadius = 0
        Me.btnOtrasSalidas.ButtonText = "OTRAS SALIDAS"
        Me.btnOtrasSalidas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOtrasSalidas.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnOtrasSalidas.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOtrasSalidas.Iconcolor = System.Drawing.Color.Transparent
        Me.btnOtrasSalidas.Iconimage = Nothing
        Me.btnOtrasSalidas.Iconimage_right = Nothing
        Me.btnOtrasSalidas.Iconimage_right_Selected = Nothing
        Me.btnOtrasSalidas.Iconimage_Selected = Nothing
        Me.btnOtrasSalidas.IconMarginLeft = 0
        Me.btnOtrasSalidas.IconMarginRight = 0
        Me.btnOtrasSalidas.IconRightVisible = True
        Me.btnOtrasSalidas.IconRightZoom = 0R
        Me.btnOtrasSalidas.IconVisible = True
        Me.btnOtrasSalidas.IconZoom = 90.0R
        Me.btnOtrasSalidas.IsTab = False
        Me.btnOtrasSalidas.Location = New System.Drawing.Point(306, 15)
        Me.btnOtrasSalidas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOtrasSalidas.Name = "btnOtrasSalidas"
        Me.btnOtrasSalidas.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnOtrasSalidas.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnOtrasSalidas.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnOtrasSalidas.selected = False
        Me.btnOtrasSalidas.Size = New System.Drawing.Size(119, 18)
        Me.btnOtrasSalidas.TabIndex = 778
        Me.btnOtrasSalidas.Text = "OTRAS SALIDAS"
        Me.btnOtrasSalidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOtrasSalidas.Textcolor = System.Drawing.Color.White
        Me.btnOtrasSalidas.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnOtrasEntradas
        '
        Me.btnOtrasEntradas.Activecolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnOtrasEntradas.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnOtrasEntradas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOtrasEntradas.BorderRadius = 0
        Me.btnOtrasEntradas.ButtonText = "OTRAS ENTRADAS"
        Me.btnOtrasEntradas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOtrasEntradas.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnOtrasEntradas.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOtrasEntradas.Iconcolor = System.Drawing.Color.Transparent
        Me.btnOtrasEntradas.Iconimage = Nothing
        Me.btnOtrasEntradas.Iconimage_right = Nothing
        Me.btnOtrasEntradas.Iconimage_right_Selected = Nothing
        Me.btnOtrasEntradas.Iconimage_Selected = Nothing
        Me.btnOtrasEntradas.IconMarginLeft = 0
        Me.btnOtrasEntradas.IconMarginRight = 0
        Me.btnOtrasEntradas.IconRightVisible = True
        Me.btnOtrasEntradas.IconRightZoom = 0R
        Me.btnOtrasEntradas.IconVisible = True
        Me.btnOtrasEntradas.IconZoom = 90.0R
        Me.btnOtrasEntradas.IsTab = False
        Me.btnOtrasEntradas.Location = New System.Drawing.Point(169, 15)
        Me.btnOtrasEntradas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOtrasEntradas.Name = "btnOtrasEntradas"
        Me.btnOtrasEntradas.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnOtrasEntradas.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnOtrasEntradas.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnOtrasEntradas.selected = False
        Me.btnOtrasEntradas.Size = New System.Drawing.Size(130, 18)
        Me.btnOtrasEntradas.TabIndex = 777
        Me.btnOtrasEntradas.Text = "OTRAS ENTRADAS"
        Me.btnOtrasEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOtrasEntradas.Textcolor = System.Drawing.Color.White
        Me.btnOtrasEntradas.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(8, 7)
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
        'btnCuentasPorPagar
        '
        Me.btnCuentasPorPagar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnCuentasPorPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnCuentasPorPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCuentasPorPagar.BorderRadius = 0
        Me.btnCuentasPorPagar.ButtonText = "TRANFERENCIAS"
        Me.btnCuentasPorPagar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCuentasPorPagar.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnCuentasPorPagar.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuentasPorPagar.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCuentasPorPagar.Iconimage = Nothing
        Me.btnCuentasPorPagar.Iconimage_right = Nothing
        Me.btnCuentasPorPagar.Iconimage_right_Selected = Nothing
        Me.btnCuentasPorPagar.Iconimage_Selected = Nothing
        Me.btnCuentasPorPagar.IconMarginLeft = 0
        Me.btnCuentasPorPagar.IconMarginRight = 0
        Me.btnCuentasPorPagar.IconRightVisible = True
        Me.btnCuentasPorPagar.IconRightZoom = 0R
        Me.btnCuentasPorPagar.IconVisible = True
        Me.btnCuentasPorPagar.IconZoom = 90.0R
        Me.btnCuentasPorPagar.IsTab = False
        Me.btnCuentasPorPagar.Location = New System.Drawing.Point(48, 13)
        Me.btnCuentasPorPagar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCuentasPorPagar.Name = "btnCuentasPorPagar"
        Me.btnCuentasPorPagar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnCuentasPorPagar.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnCuentasPorPagar.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCuentasPorPagar.selected = False
        Me.btnCuentasPorPagar.Size = New System.Drawing.Size(119, 18)
        Me.btnCuentasPorPagar.TabIndex = 772
        Me.btnCuentasPorPagar.Text = "TRANFERENCIAS"
        Me.btnCuentasPorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCuentasPorPagar.Textcolor = System.Drawing.Color.White
        Me.btnCuentasPorPagar.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnCuentasPorCobrar
        '
        Me.btnCuentasPorCobrar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnCuentasPorCobrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnCuentasPorCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCuentasPorCobrar.BorderRadius = 0
        Me.btnCuentasPorCobrar.ButtonText = "ALMACENES"
        Me.btnCuentasPorCobrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCuentasPorCobrar.DisabledColor = System.Drawing.Color.Gray
        Me.btnCuentasPorCobrar.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuentasPorCobrar.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCuentasPorCobrar.Iconimage = Nothing
        Me.btnCuentasPorCobrar.Iconimage_right = Nothing
        Me.btnCuentasPorCobrar.Iconimage_right_Selected = Nothing
        Me.btnCuentasPorCobrar.Iconimage_Selected = Nothing
        Me.btnCuentasPorCobrar.IconMarginLeft = 0
        Me.btnCuentasPorCobrar.IconMarginRight = 0
        Me.btnCuentasPorCobrar.IconRightVisible = True
        Me.btnCuentasPorCobrar.IconRightZoom = 0R
        Me.btnCuentasPorCobrar.IconVisible = True
        Me.btnCuentasPorCobrar.IconZoom = 90.0R
        Me.btnCuentasPorCobrar.IsTab = False
        Me.btnCuentasPorCobrar.Location = New System.Drawing.Point(429, 15)
        Me.btnCuentasPorCobrar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCuentasPorCobrar.Name = "btnCuentasPorCobrar"
        Me.btnCuentasPorCobrar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.btnCuentasPorCobrar.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnCuentasPorCobrar.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCuentasPorCobrar.selected = False
        Me.btnCuentasPorCobrar.Size = New System.Drawing.Size(98, 18)
        Me.btnCuentasPorCobrar.TabIndex = 771
        Me.btnCuentasPorCobrar.Text = "ALMACENES"
        Me.btnCuentasPorCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCuentasPorCobrar.Textcolor = System.Drawing.Color.White
        Me.btnCuentasPorCobrar.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(47, 36)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(115, 6)
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
        Me.PanelBody.TabIndex = 5
        '
        'UCPrincipalAlmacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalAlmacenes"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnCuentasPorPagar As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnCuentasPorCobrar As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Private WithEvents btnOtrasSalidas As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnOtrasEntradas As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Panel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCPrincipalFinanzas
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalFinanzas))
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnMovimientosCaja = New Bunifu.Framework.UI.BunifuFlatButton()
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
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.btnMovimientosCaja)
        Me.PanelTop.Controls.Add(Me.btnCuentasPorPagar)
        Me.PanelTop.Controls.Add(Me.btnCuentasPorCobrar)
        Me.PanelTop.Controls.Add(Me.sliderTop)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 45)
        Me.PanelTop.TabIndex = 2
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
        'btnMovimientosCaja
        '
        Me.btnMovimientosCaja.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnMovimientosCaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnMovimientosCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMovimientosCaja.BorderRadius = 0
        Me.btnMovimientosCaja.ButtonText = "MOVIMIENTOS"
        Me.btnMovimientosCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMovimientosCaja.DisabledColor = System.Drawing.Color.Gray
        Me.btnMovimientosCaja.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovimientosCaja.Iconcolor = System.Drawing.Color.Transparent
        Me.btnMovimientosCaja.Iconimage = Nothing
        Me.btnMovimientosCaja.Iconimage_right = Nothing
        Me.btnMovimientosCaja.Iconimage_right_Selected = Nothing
        Me.btnMovimientosCaja.Iconimage_Selected = Nothing
        Me.btnMovimientosCaja.IconMarginLeft = 0
        Me.btnMovimientosCaja.IconMarginRight = 0
        Me.btnMovimientosCaja.IconRightVisible = True
        Me.btnMovimientosCaja.IconRightZoom = 0R
        Me.btnMovimientosCaja.IconVisible = True
        Me.btnMovimientosCaja.IconZoom = 90.0R
        Me.btnMovimientosCaja.IsTab = False
        Me.btnMovimientosCaja.Location = New System.Drawing.Point(47, 13)
        Me.btnMovimientosCaja.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMovimientosCaja.Name = "btnMovimientosCaja"
        Me.btnMovimientosCaja.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnMovimientosCaja.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnMovimientosCaja.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnMovimientosCaja.selected = False
        Me.btnMovimientosCaja.Size = New System.Drawing.Size(110, 18)
        Me.btnMovimientosCaja.TabIndex = 773
        Me.btnMovimientosCaja.Text = "MOVIMIENTOS"
        Me.btnMovimientosCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnMovimientosCaja.Textcolor = System.Drawing.Color.White
        Me.btnMovimientosCaja.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnCuentasPorPagar
        '
        Me.btnCuentasPorPagar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnCuentasPorPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnCuentasPorPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCuentasPorPagar.BorderRadius = 0
        Me.btnCuentasPorPagar.ButtonText = "CUENTAS POR PAGAR"
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
        Me.btnCuentasPorPagar.Location = New System.Drawing.Point(333, 13)
        Me.btnCuentasPorPagar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCuentasPorPagar.Name = "btnCuentasPorPagar"
        Me.btnCuentasPorPagar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnCuentasPorPagar.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnCuentasPorPagar.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCuentasPorPagar.selected = False
        Me.btnCuentasPorPagar.Size = New System.Drawing.Size(154, 18)
        Me.btnCuentasPorPagar.TabIndex = 772
        Me.btnCuentasPorPagar.Text = "CUENTAS POR PAGAR"
        Me.btnCuentasPorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCuentasPorPagar.Textcolor = System.Drawing.Color.White
        Me.btnCuentasPorPagar.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuentasPorPagar.Visible = False
        '
        'btnCuentasPorCobrar
        '
        Me.btnCuentasPorCobrar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnCuentasPorCobrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnCuentasPorCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCuentasPorCobrar.BorderRadius = 0
        Me.btnCuentasPorCobrar.ButtonText = "CUENTAS POR COBRAR"
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
        Me.btnCuentasPorCobrar.Location = New System.Drawing.Point(161, 13)
        Me.btnCuentasPorCobrar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCuentasPorCobrar.Name = "btnCuentasPorCobrar"
        Me.btnCuentasPorCobrar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnCuentasPorCobrar.OnHovercolor = System.Drawing.Color.CadetBlue
        Me.btnCuentasPorCobrar.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCuentasPorCobrar.selected = False
        Me.btnCuentasPorCobrar.Size = New System.Drawing.Size(165, 18)
        Me.btnCuentasPorCobrar.TabIndex = 771
        Me.btnCuentasPorCobrar.Text = "CUENTAS POR COBRAR"
        Me.btnCuentasPorCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCuentasPorCobrar.Textcolor = System.Drawing.Color.White
        Me.btnCuentasPorCobrar.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(47, 36)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(105, 6)
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
        Me.PanelBody.TabIndex = 3
        '
        'UCPrincipalFinanzas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalFinanzas"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents btnMovimientosCaja As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnCuentasPorPagar As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnCuentasPorCobrar As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents PanelBody As Panel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class

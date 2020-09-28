<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCSubReporteVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCSubReporteVentas))
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnImportarExcel = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnBuscarVenta = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.cboTipoBusqueda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnRanking = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnVentas = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.btnRentabilidad = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel3.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.btnImportarExcel)
        Me.GradientPanel3.Controls.Add(Me.btnBuscarVenta)
        Me.GradientPanel3.Controls.Add(Me.cboTipoBusqueda)
        Me.GradientPanel3.Controls.Add(Me.btnRanking)
        Me.GradientPanel3.Controls.Add(Me.btnVentas)
        Me.GradientPanel3.Controls.Add(Me.sliderTop)
        Me.GradientPanel3.Controls.Add(Me.btnRentabilidad)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(994, 51)
        Me.GradientPanel3.TabIndex = 1
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Activecolor = System.Drawing.Color.Black
        Me.btnImportarExcel.BackColor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImportarExcel.BorderRadius = 7
        Me.btnImportarExcel.ButtonText = "Exportar Excel"
        Me.btnImportarExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImportarExcel.DisabledColor = System.Drawing.Color.Gray
        Me.btnImportarExcel.Iconcolor = System.Drawing.Color.Transparent
        Me.btnImportarExcel.Iconimage = CType(resources.GetObject("btnImportarExcel.Iconimage"), System.Drawing.Image)
        Me.btnImportarExcel.Iconimage_right = Nothing
        Me.btnImportarExcel.Iconimage_right_Selected = Nothing
        Me.btnImportarExcel.Iconimage_Selected = Nothing
        Me.btnImportarExcel.IconMarginLeft = 0
        Me.btnImportarExcel.IconMarginRight = 0
        Me.btnImportarExcel.IconRightVisible = True
        Me.btnImportarExcel.IconRightZoom = 0R
        Me.btnImportarExcel.IconVisible = True
        Me.btnImportarExcel.IconZoom = 40.0R
        Me.btnImportarExcel.IsTab = True
        Me.btnImportarExcel.Location = New System.Drawing.Point(292, 12)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Normalcolor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnImportarExcel.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImportarExcel.selected = False
        Me.btnImportarExcel.Size = New System.Drawing.Size(25, 25)
        Me.btnImportarExcel.TabIndex = 760
        Me.btnImportarExcel.Text = "Exportar Excel"
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImportarExcel.Textcolor = System.Drawing.Color.White
        Me.btnImportarExcel.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnBuscarVenta
        '
        Me.btnBuscarVenta.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnBuscarVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnBuscarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarVenta.BorderRadius = 5
        Me.btnBuscarVenta.ButtonText = "Buscar"
        Me.btnBuscarVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarVenta.DisabledColor = System.Drawing.Color.Gray
        Me.btnBuscarVenta.Iconcolor = System.Drawing.Color.Transparent
        Me.btnBuscarVenta.Iconimage = CType(resources.GetObject("btnBuscarVenta.Iconimage"), System.Drawing.Image)
        Me.btnBuscarVenta.Iconimage_right = Nothing
        Me.btnBuscarVenta.Iconimage_right_Selected = Nothing
        Me.btnBuscarVenta.Iconimage_Selected = Nothing
        Me.btnBuscarVenta.IconMarginLeft = 0
        Me.btnBuscarVenta.IconMarginRight = 0
        Me.btnBuscarVenta.IconRightVisible = True
        Me.btnBuscarVenta.IconRightZoom = 0R
        Me.btnBuscarVenta.IconVisible = True
        Me.btnBuscarVenta.IconZoom = 40.0R
        Me.btnBuscarVenta.IsTab = False
        Me.btnBuscarVenta.Location = New System.Drawing.Point(205, 12)
        Me.btnBuscarVenta.Name = "btnBuscarVenta"
        Me.btnBuscarVenta.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnBuscarVenta.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnBuscarVenta.OnHoverTextColor = System.Drawing.Color.White
        Me.btnBuscarVenta.selected = False
        Me.btnBuscarVenta.Size = New System.Drawing.Size(81, 25)
        Me.btnBuscarVenta.TabIndex = 759
        Me.btnBuscarVenta.Text = "Buscar"
        Me.btnBuscarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarVenta.Textcolor = System.Drawing.Color.White
        Me.btnBuscarVenta.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'cboTipoBusqueda
        '
        Me.cboTipoBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboTipoBusqueda.BeforeTouchSize = New System.Drawing.Size(161, 21)
        Me.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBusqueda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBusqueda.Items.AddRange(New Object() {"VENTA POR DIA", "VENTA POR MES", "VENTA POR VENDEDOR", "VENTA POR ARTICULOS", "RENTABILIDAD"})
        Me.cboTipoBusqueda.Location = New System.Drawing.Point(29, 16)
        Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
        Me.cboTipoBusqueda.Size = New System.Drawing.Size(161, 21)
        Me.cboTipoBusqueda.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White
        Me.cboTipoBusqueda.TabIndex = 758
        Me.cboTipoBusqueda.Text = "VENTA POR DIA"
        '
        'btnRanking
        '
        Me.btnRanking.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRanking.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRanking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRanking.BorderRadius = 0
        Me.btnRanking.ButtonText = "RANKING"
        Me.btnRanking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRanking.DisabledColor = System.Drawing.Color.White
        Me.btnRanking.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRanking.ForeColor = System.Drawing.Color.Black
        Me.btnRanking.Iconcolor = System.Drawing.Color.Transparent
        Me.btnRanking.Iconimage = Nothing
        Me.btnRanking.Iconimage_right = Nothing
        Me.btnRanking.Iconimage_right_Selected = Nothing
        Me.btnRanking.Iconimage_Selected = Nothing
        Me.btnRanking.IconMarginLeft = 0
        Me.btnRanking.IconMarginRight = 0
        Me.btnRanking.IconRightVisible = True
        Me.btnRanking.IconRightZoom = 0R
        Me.btnRanking.IconVisible = True
        Me.btnRanking.IconZoom = 90.0R
        Me.btnRanking.IsTab = False
        Me.btnRanking.Location = New System.Drawing.Point(134, 89)
        Me.btnRanking.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRanking.Name = "btnRanking"
        Me.btnRanking.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRanking.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRanking.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnRanking.selected = False
        Me.btnRanking.Size = New System.Drawing.Size(66, 15)
        Me.btnRanking.TabIndex = 524
        Me.btnRanking.Text = "RANKING"
        Me.btnRanking.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRanking.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.btnRanking.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnVentas
        '
        Me.btnVentas.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnVentas.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVentas.BorderRadius = 0
        Me.btnVentas.ButtonText = "VENTAS"
        Me.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVentas.DisabledColor = System.Drawing.Color.White
        Me.btnVentas.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentas.ForeColor = System.Drawing.Color.Black
        Me.btnVentas.Iconcolor = System.Drawing.Color.Transparent
        Me.btnVentas.Iconimage = Nothing
        Me.btnVentas.Iconimage_right = Nothing
        Me.btnVentas.Iconimage_right_Selected = Nothing
        Me.btnVentas.Iconimage_Selected = Nothing
        Me.btnVentas.IconMarginLeft = 0
        Me.btnVentas.IconMarginRight = 0
        Me.btnVentas.IconRightVisible = True
        Me.btnVentas.IconRightZoom = 0R
        Me.btnVentas.IconVisible = True
        Me.btnVentas.IconZoom = 90.0R
        Me.btnVentas.IsTab = False
        Me.btnVentas.Location = New System.Drawing.Point(205, 89)
        Me.btnVentas.Margin = New System.Windows.Forms.Padding(2)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnVentas.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnVentas.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnVentas.selected = False
        Me.btnVentas.Size = New System.Drawing.Size(58, 15)
        Me.btnVentas.TabIndex = 523
        Me.btnVentas.Text = "VENTAS"
        Me.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnVentas.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.btnVentas.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.sliderTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.sliderTop.Location = New System.Drawing.Point(31, 108)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(95, 4)
        Me.sliderTop.TabIndex = 522
        Me.sliderTop.TabStop = False
        '
        'btnRentabilidad
        '
        Me.btnRentabilidad.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRentabilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRentabilidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRentabilidad.BorderRadius = 0
        Me.btnRentabilidad.ButtonText = "RENTABILIDAD"
        Me.btnRentabilidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRentabilidad.DisabledColor = System.Drawing.Color.White
        Me.btnRentabilidad.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRentabilidad.ForeColor = System.Drawing.Color.Black
        Me.btnRentabilidad.Iconcolor = System.Drawing.Color.Transparent
        Me.btnRentabilidad.Iconimage = Nothing
        Me.btnRentabilidad.Iconimage_right = Nothing
        Me.btnRentabilidad.Iconimage_right_Selected = Nothing
        Me.btnRentabilidad.Iconimage_Selected = Nothing
        Me.btnRentabilidad.IconMarginLeft = 0
        Me.btnRentabilidad.IconMarginRight = 0
        Me.btnRentabilidad.IconRightVisible = True
        Me.btnRentabilidad.IconRightZoom = 0R
        Me.btnRentabilidad.IconVisible = True
        Me.btnRentabilidad.IconZoom = 90.0R
        Me.btnRentabilidad.IsTab = False
        Me.btnRentabilidad.Location = New System.Drawing.Point(29, 89)
        Me.btnRentabilidad.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRentabilidad.Name = "btnRentabilidad"
        Me.btnRentabilidad.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRentabilidad.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnRentabilidad.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnRentabilidad.selected = False
        Me.btnRentabilidad.Size = New System.Drawing.Size(102, 15)
        Me.btnRentabilidad.TabIndex = 521
        Me.btnRentabilidad.Text = "RENTABILIDAD"
        Me.btnRentabilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRentabilidad.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.btnRentabilidad.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.White
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 51)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 475)
        Me.PanelBody.TabIndex = 304
        '
        'UCSubReporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Name = "UCSubReporteVentas"
        Me.Size = New System.Drawing.Size(994, 526)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents btnRanking As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnVentas As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Private WithEvents btnRentabilidad As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Panel
    Friend WithEvents cboTipoBusqueda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnBuscarVenta As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnImportarExcel As Bunifu.Framework.UI.BunifuFlatButton
End Class

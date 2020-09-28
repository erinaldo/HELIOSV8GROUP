Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTableroGeneralPOS
    Inherits MetroForm

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTableroGeneralPOS))
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.chartControl1 = New Syncfusion.Windows.Forms.Chart.ChartControl()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ProgressBar5 = New System.Windows.Forms.ProgressBar()
        Me.ChartControl3 = New Syncfusion.Windows.Forms.Chart.ChartControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.BunifuFlatButton15 = New Bunifu.Framework.UI.BunifuFlatButton()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ProgressBar1)
        Me.GradientPanel2.Controls.Add(Me.cboAnio)
        Me.GradientPanel2.Controls.Add(Me.chartControl1)
        Me.GradientPanel2.Controls.Add(Me.Label7)
        Me.GradientPanel2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel2.Location = New System.Drawing.Point(9, 11)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(609, 294)
        Me.GradientPanel2.TabIndex = 226
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(130, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(50, 10)
        Me.ProgressBar1.TabIndex = 511
        Me.ProgressBar1.Visible = False
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(544, 3)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010
        Me.cboAnio.TabIndex = 461
        '
        'chartControl1
        '
        Me.chartControl1.ChartArea.BackInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent)
        Me.chartControl1.ChartArea.CursorLocation = New System.Drawing.Point(0, 0)
        Me.chartControl1.ChartArea.CursorReDraw = False
        Me.chartControl1.ChartInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent)
        Me.chartControl1.DataSourceName = ""
        Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartControl1.ForeColor = System.Drawing.Color.Black
        Me.chartControl1.IsWindowLess = False
        '
        '
        '
        Me.chartControl1.Legend.Location = New System.Drawing.Point(498, 31)
        Me.chartControl1.Localize = Nothing
        Me.chartControl1.Location = New System.Drawing.Point(0, 27)
        Me.chartControl1.Name = "chartControl1"
        Me.chartControl1.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Custom
        Me.chartControl1.PrimaryXAxis.Crossing = Double.NaN
        Me.chartControl1.PrimaryXAxis.DrawGrid = False
        Me.chartControl1.PrimaryXAxis.ForeColor = System.Drawing.Color.Black
        Me.chartControl1.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.Margin = True
        Me.chartControl1.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText
        Me.chartControl1.PrimaryYAxis.Crossing = Double.NaN
        Me.chartControl1.PrimaryYAxis.ForeColor = System.Drawing.Color.Black
        Me.chartControl1.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.Margin = True
        Me.chartControl1.PrimaryYAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.TitleColor = System.Drawing.SystemColors.ControlText
        Me.chartControl1.ShowToolbarInImage = False
        Me.chartControl1.Size = New System.Drawing.Size(607, 265)
        Me.chartControl1.TabIndex = 209
        Me.chartControl1.Tilt = 10.0!
        '
        '
        '
        Me.chartControl1.Title.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chartControl1.Title.Name = "Default"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(607, 27)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "                RESUMEN ANUAL"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.White
        Me.GradientPanel5.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.ProgressBar5)
        Me.GradientPanel5.Controls.Add(Me.ChartControl3)
        Me.GradientPanel5.Controls.Add(Me.Label4)
        Me.GradientPanel5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel5.Location = New System.Drawing.Point(9, 310)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(609, 293)
        Me.GradientPanel5.TabIndex = 230
        '
        'ProgressBar5
        '
        Me.ProgressBar5.Location = New System.Drawing.Point(161, 8)
        Me.ProgressBar5.Name = "ProgressBar5"
        Me.ProgressBar5.Size = New System.Drawing.Size(50, 10)
        Me.ProgressBar5.TabIndex = 512
        Me.ProgressBar5.Visible = False
        '
        'ChartControl3
        '
        Me.ChartControl3.ChartArea.BackInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent)
        Me.ChartControl3.ChartArea.CursorLocation = New System.Drawing.Point(0, 0)
        Me.ChartControl3.ChartArea.CursorReDraw = False
        Me.ChartControl3.ChartInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent)
        Me.ChartControl3.DataSourceName = ""
        Me.ChartControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChartControl3.ForeColor = System.Drawing.Color.Black
        Me.ChartControl3.IsWindowLess = False
        '
        '
        '
        Me.ChartControl3.Legend.Location = New System.Drawing.Point(498, 31)
        Me.ChartControl3.Localize = Nothing
        Me.ChartControl3.Location = New System.Drawing.Point(0, 27)
        Me.ChartControl3.Name = "ChartControl3"
        Me.ChartControl3.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Custom
        Me.ChartControl3.PrimaryXAxis.Crossing = Double.NaN
        Me.ChartControl3.PrimaryXAxis.DrawGrid = False
        Me.ChartControl3.PrimaryXAxis.ForeColor = System.Drawing.Color.Black
        Me.ChartControl3.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.ChartControl3.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.ChartControl3.PrimaryXAxis.Margin = True
        Me.ChartControl3.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.ChartControl3.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText
        Me.ChartControl3.PrimaryYAxis.Crossing = Double.NaN
        Me.ChartControl3.PrimaryYAxis.ForeColor = System.Drawing.Color.Black
        Me.ChartControl3.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.ChartControl3.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.ChartControl3.PrimaryYAxis.Margin = True
        Me.ChartControl3.PrimaryYAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.ChartControl3.PrimaryYAxis.TitleColor = System.Drawing.SystemColors.ControlText
        Me.ChartControl3.ShowToolbarInImage = False
        Me.ChartControl3.Size = New System.Drawing.Size(607, 264)
        Me.ChartControl3.TabIndex = 7
        Me.ChartControl3.Tilt = 10.0!
        '
        '
        '
        Me.ChartControl3.Title.Name = "Def_title"
        Me.ChartControl3.Title.Text = ""
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(607, 27)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "               ANALISIS RENTABILIDAD"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.PanelBody)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel3)
        Me.GradientPanel1.Location = New System.Drawing.Point(625, 11)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(584, 591)
        Me.GradientPanel1.TabIndex = 231
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 46)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(582, 543)
        Me.PanelBody.TabIndex = 1
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel3.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel3.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel3.Controls.Add(Me.sliderTop)
        Me.GradientPanel3.Controls.Add(Me.BunifuFlatButton15)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(582, 46)
        Me.GradientPanel3.TabIndex = 0
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "RESUMEN GENERAL"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Nothing
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(308, 17)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(142, 15)
        Me.BunifuFlatButton2.TabIndex = 524
        Me.BunifuFlatButton2.Text = "RESUMEN GENERAL"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "VENTAS X VENDEDOR"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(161, 17)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(156, 15)
        Me.BunifuFlatButton1.TabIndex = 523
        Me.BunifuFlatButton1.Text = "VENTAS X VENDEDOR"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.sliderTop.BackgroundImage = CType(resources.GetObject("sliderTop.BackgroundImage"), System.Drawing.Image)
        Me.sliderTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.sliderTop.Location = New System.Drawing.Point(3, 40)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(156, 4)
        Me.sliderTop.TabIndex = 522
        Me.sliderTop.TabStop = False
        '
        'BunifuFlatButton15
        '
        Me.BunifuFlatButton15.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton15.BorderRadius = 0
        Me.BunifuFlatButton15.ButtonText = "FLUJO DE CAJA X CAJERO"
        Me.BunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton15.DisabledColor = System.Drawing.Color.White
        Me.BunifuFlatButton15.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton15.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton15.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.Iconimage = Nothing
        Me.BunifuFlatButton15.Iconimage_right = Nothing
        Me.BunifuFlatButton15.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton15.Iconimage_Selected = Nothing
        Me.BunifuFlatButton15.IconMarginLeft = 0
        Me.BunifuFlatButton15.IconMarginRight = 0
        Me.BunifuFlatButton15.IconRightVisible = True
        Me.BunifuFlatButton15.IconRightZoom = 0R
        Me.BunifuFlatButton15.IconVisible = True
        Me.BunifuFlatButton15.IconZoom = 90.0R
        Me.BunifuFlatButton15.IsTab = False
        Me.BunifuFlatButton15.Location = New System.Drawing.Point(3, 17)
        Me.BunifuFlatButton15.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton15.Name = "BunifuFlatButton15"
        Me.BunifuFlatButton15.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton15.selected = False
        Me.BunifuFlatButton15.Size = New System.Drawing.Size(156, 15)
        Me.BunifuFlatButton15.TabIndex = 521
        Me.BunifuFlatButton15.Text = "FLUJO DE CAJA X CAJERO"
        Me.BunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton15.Textcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton15.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'FormTableroGeneralPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(1215, 612)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel5)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "FormTableroGeneralPOS"
        Me.ShowIcon = False
        Me.Text = "tablero General POS"
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents cboAnio As Tools.ComboBoxAdv
    Private WithEvents chartControl1 As Chart.ChartControl
    Friend WithEvents Label7 As Label
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents ProgressBar5 As ProgressBar
    Private WithEvents ChartControl3 As Chart.ChartControl
    Friend WithEvents Label4 As Label
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Private WithEvents sliderTop As PictureBox
    Private WithEvents BunifuFlatButton15 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Panel
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class

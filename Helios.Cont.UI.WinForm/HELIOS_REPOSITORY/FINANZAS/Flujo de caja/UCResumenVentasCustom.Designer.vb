<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCResumenVentasCustom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCResumenVentasCustom))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboUnidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboReporte = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PanelProductos = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LabelTotalSinStock = New System.Windows.Forms.Label()
        Me.LabelTotalConStock = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboComprobante = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.SwitchAcumulado = New Bunifu.Framework.UI.BunifuiOSSwitch()
        Me.LabelAcumulado = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LabelAlCredito = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelAlContado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelTotalVentas = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboUsuarios = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.LabelUsuarios = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboMesPedido = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuiOSSwitch1 = New Bunifu.Framework.UI.BunifuiOSSwitch()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.ComboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.PanelProductos.SuspendLayout()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 705
        Me.Label1.Text = "UNIDAD DE NEGOCIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboUnidad
        '
        Me.ComboUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUnidad.BeforeTouchSize = New System.Drawing.Size(222, 21)
        Me.ComboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidad.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUnidad.Location = New System.Drawing.Point(14, 28)
        Me.ComboUnidad.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(222, 21)
        Me.ComboUnidad.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUnidad.TabIndex = 704
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(240, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 707
        Me.Label2.Text = "REPORTE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboReporte
        '
        Me.ComboReporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboReporte.BeforeTouchSize = New System.Drawing.Size(212, 21)
        Me.ComboReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboReporte.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboReporte.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboReporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboReporte.Items.AddRange(New Object() {"VENTA POR DIA", "VENTA POR MES", "VENTA POR VENDEDOR", "VENTA POR ARTICULOS"})
        Me.ComboReporte.Location = New System.Drawing.Point(242, 28)
        Me.ComboReporte.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboReporte.Name = "ComboReporte"
        Me.ComboReporte.Size = New System.Drawing.Size(212, 21)
        Me.ComboReporte.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboReporte.TabIndex = 706
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.PanelProductos)
        Me.GradientPanel1.Controls.Add(Me.ComboComprobante)
        Me.GradientPanel1.Controls.Add(Me.SwitchAcumulado)
        Me.GradientPanel1.Controls.Add(Me.LabelAcumulado)
        Me.GradientPanel1.Controls.Add(Me.Panel4)
        Me.GradientPanel1.Controls.Add(Me.Panel3)
        Me.GradientPanel1.Controls.Add(Me.Panel2)
        Me.GradientPanel1.Controls.Add(Me.pictureBox2)
        Me.GradientPanel1.Controls.Add(Me.pictureBox1)
        Me.GradientPanel1.Controls.Add(Me.BunifuThinButton23)
        Me.GradientPanel1.Controls.Add(Me.PictureLoad)
        Me.GradientPanel1.Controls.Add(Me.panel5)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 60)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1107, 434)
        Me.GradientPanel1.TabIndex = 708
        '
        'PanelProductos
        '
        Me.PanelProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.PanelProductos.Controls.Add(Me.Panel8)
        Me.PanelProductos.Controls.Add(Me.Panel7)
        Me.PanelProductos.Controls.Add(Me.LabelTotalSinStock)
        Me.PanelProductos.Controls.Add(Me.LabelTotalConStock)
        Me.PanelProductos.Controls.Add(Me.Label9)
        Me.PanelProductos.Controls.Add(Me.Label6)
        Me.PanelProductos.Location = New System.Drawing.Point(363, 7)
        Me.PanelProductos.Name = "PanelProductos"
        Me.PanelProductos.Size = New System.Drawing.Size(180, 61)
        Me.PanelProductos.TabIndex = 718
        Me.PanelProductos.Visible = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Panel8.Location = New System.Drawing.Point(7, 43)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(5, 5)
        Me.Panel8.TabIndex = 694
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Panel7.Location = New System.Drawing.Point(7, 19)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(5, 5)
        Me.Panel7.TabIndex = 0
        '
        'LabelTotalSinStock
        '
        Me.LabelTotalSinStock.AutoSize = True
        Me.LabelTotalSinStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSinStock.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSinStock.ForeColor = System.Drawing.Color.White
        Me.LabelTotalSinStock.Location = New System.Drawing.Point(76, 38)
        Me.LabelTotalSinStock.Name = "LabelTotalSinStock"
        Me.LabelTotalSinStock.Size = New System.Drawing.Size(38, 13)
        Me.LabelTotalSinStock.TabIndex = 693
        Me.LabelTotalSinStock.Text = "S/0.00"
        Me.LabelTotalSinStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalConStock
        '
        Me.LabelTotalConStock.AutoSize = True
        Me.LabelTotalConStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalConStock.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalConStock.ForeColor = System.Drawing.Color.White
        Me.LabelTotalConStock.Location = New System.Drawing.Point(76, 14)
        Me.LabelTotalConStock.Name = "LabelTotalConStock"
        Me.LabelTotalConStock.Size = New System.Drawing.Size(38, 13)
        Me.LabelTotalConStock.TabIndex = 56
        Me.LabelTotalConStock.Text = "S/0.00"
        Me.LabelTotalConStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(13, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 14)
        Me.Label9.TabIndex = 692
        Me.Label9.Text = "Sin stock"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 14)
        Me.Label6.TabIndex = 691
        Me.Label6.Text = "Con stock"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboComprobante
        '
        Me.ComboComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboComprobante.BeforeTouchSize = New System.Drawing.Size(99, 21)
        Me.ComboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboComprobante.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboComprobante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboComprobante.Items.AddRange(New Object() {"-TODOS-", "FACTURA", "BOLETA", "NOTA"})
        Me.ComboComprobante.Location = New System.Drawing.Point(117, 42)
        Me.ComboComprobante.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboComprobante.Name = "ComboComprobante"
        Me.ComboComprobante.Size = New System.Drawing.Size(99, 21)
        Me.ComboComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboComprobante.TabIndex = 717
        Me.ComboComprobante.Text = "-TODOS-"
        '
        'SwitchAcumulado
        '
        Me.SwitchAcumulado.BackColor = System.Drawing.Color.Transparent
        Me.SwitchAcumulado.BackgroundImage = CType(resources.GetObject("SwitchAcumulado.BackgroundImage"), System.Drawing.Image)
        Me.SwitchAcumulado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SwitchAcumulado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SwitchAcumulado.Location = New System.Drawing.Point(246, 38)
        Me.SwitchAcumulado.Name = "SwitchAcumulado"
        Me.SwitchAcumulado.OffColor = System.Drawing.Color.Gray
        Me.SwitchAcumulado.OnColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.SwitchAcumulado.Size = New System.Drawing.Size(43, 25)
        Me.SwitchAcumulado.TabIndex = 716
        Me.SwitchAcumulado.Value = False
        '
        'LabelAcumulado
        '
        Me.LabelAcumulado.AutoSize = True
        Me.LabelAcumulado.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAcumulado.ForeColor = System.Drawing.Color.Silver
        Me.LabelAcumulado.Location = New System.Drawing.Point(293, 48)
        Me.LabelAcumulado.Name = "LabelAcumulado"
        Me.LabelAcumulado.Size = New System.Drawing.Size(62, 14)
        Me.LabelAcumulado.TabIndex = 715
        Me.LabelAcumulado.Text = "Acumulado"
        Me.LabelAcumulado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel4.Controls.Add(Me.LabelAlCredito)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Location = New System.Drawing.Point(912, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(180, 61)
        Me.Panel4.TabIndex = 707
        '
        'LabelAlCredito
        '
        Me.LabelAlCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelAlCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAlCredito.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAlCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.LabelAlCredito.Location = New System.Drawing.Point(0, 0)
        Me.LabelAlCredito.Name = "LabelAlCredito"
        Me.LabelAlCredito.Size = New System.Drawing.Size(180, 35)
        Me.LabelAlCredito.TabIndex = 56
        Me.LabelAlCredito.Text = "S/0.00"
        Me.LabelAlCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label10.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(0, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(180, 26)
        Me.Label10.TabIndex = 691
        Me.Label10.Text = "Ventas al credito"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel3.Controls.Add(Me.LabelAlContado)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(729, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(180, 61)
        Me.Panel3.TabIndex = 706
        '
        'LabelAlContado
        '
        Me.LabelAlContado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelAlContado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelAlContado.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAlContado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelAlContado.Location = New System.Drawing.Point(0, 0)
        Me.LabelAlContado.Name = "LabelAlContado"
        Me.LabelAlContado.Size = New System.Drawing.Size(180, 35)
        Me.LabelAlContado.TabIndex = 56
        Me.LabelAlContado.Text = "S/0.00"
        Me.LabelAlContado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(0, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(180, 26)
        Me.Label7.TabIndex = 691
        Me.Label7.Text = "Ventas al contado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelTotalVentas)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(546, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(180, 61)
        Me.Panel2.TabIndex = 705
        '
        'LabelTotalVentas
        '
        Me.LabelTotalVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalVentas.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.LabelTotalVentas.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalVentas.Name = "LabelTotalVentas"
        Me.LabelTotalVentas.Size = New System.Drawing.Size(180, 35)
        Me.LabelTotalVentas.TabIndex = 56
        Me.LabelTotalVentas.Text = "S/0.00"
        Me.LabelTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(0, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(180, 26)
        Me.Label8.TabIndex = 691
        Me.Label8.Text = "Total ventas"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pictureBox2
        '
        Me.pictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image)
        Me.pictureBox2.Location = New System.Drawing.Point(179, 0)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(30, 30)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox2.TabIndex = 704
        Me.pictureBox2.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(146, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 703
        Me.pictureBox1.TabStop = False
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton23.BackgroundImage = CType(resources.GetObject("BunifuThinButton23.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton23.ButtonText = "CONSULTAR"
        Me.BunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton23.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton23.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleBorderThickness = 1
        Me.BunifuThinButton23.IdleCornerRadius = 20
        Me.BunifuThinButton23.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton23.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton23.Location = New System.Drawing.Point(16, 33)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(94, 35)
        Me.BunifuThinButton23.TabIndex = 702
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(218, 42)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 701
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'panel5
        '
        Me.panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.panel5.Location = New System.Drawing.Point(14, 73)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(1079, 358)
        Me.panel5.TabIndex = 700
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(11, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Reporte de ventas"
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUsuarios.BeforeTouchSize = New System.Drawing.Size(329, 21)
        Me.ComboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUsuarios.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboUsuarios.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUsuarios.Location = New System.Drawing.Point(711, 28)
        Me.ComboUsuarios.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(329, 21)
        Me.ComboUsuarios.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUsuarios.TabIndex = 710
        Me.ComboUsuarios.Visible = False
        '
        'LabelUsuarios
        '
        Me.LabelUsuarios.AutoSize = True
        Me.LabelUsuarios.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsuarios.ForeColor = System.Drawing.Color.Silver
        Me.LabelUsuarios.Location = New System.Drawing.Point(711, 10)
        Me.LabelUsuarios.Name = "LabelUsuarios"
        Me.LabelUsuarios.Size = New System.Drawing.Size(114, 13)
        Me.LabelUsuarios.TabIndex = 709
        Me.LabelUsuarios.Text = "USUARIO / VENDEDOR"
        Me.LabelUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelUsuarios.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(456, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 712
        Me.Label4.Text = "DIA/MES"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.cboAnio)
        Me.Panel1.Controls.Add(Me.cboMesPedido)
        Me.Panel1.Location = New System.Drawing.Point(514, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(191, 39)
        Me.Panel1.TabIndex = 713
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.txtFecha.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFecha.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.DimGray
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.DimGray
        Me.txtFecha.EnableNullDate = False
        Me.txtFecha.EnableNullKeys = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(3, 18)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Office2007Theme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtFecha.Office2010Theme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.Size = New System.Drawing.Size(185, 21)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.txtFecha.TabIndex = 464
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'cboAnio
        '
        Me.cboAnio.AutoComplete = False
        Me.cboAnio.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboAnio.Location = New System.Drawing.Point(128, 18)
        Me.cboAnio.MetroBorderColor = System.Drawing.Color.DimGray
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboAnio.TabIndex = 463
        '
        'cboMesPedido
        '
        Me.cboMesPedido.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboMesPedido.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMesPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesPedido.FlatBorderColor = System.Drawing.Color.DimGray
        Me.cboMesPedido.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesPedido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboMesPedido.Location = New System.Drawing.Point(3, 18)
        Me.cboMesPedido.MetroBorderColor = System.Drawing.Color.DimGray
        Me.cboMesPedido.Name = "cboMesPedido"
        Me.cboMesPedido.Size = New System.Drawing.Size(121, 21)
        Me.cboMesPedido.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboMesPedido.TabIndex = 462
        '
        'BunifuiOSSwitch1
        '
        Me.BunifuiOSSwitch1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuiOSSwitch1.BackgroundImage = CType(resources.GetObject("BunifuiOSSwitch1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuiOSSwitch1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuiOSSwitch1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuiOSSwitch1.Location = New System.Drawing.Point(460, 24)
        Me.BunifuiOSSwitch1.Name = "BunifuiOSSwitch1"
        Me.BunifuiOSSwitch1.OffColor = System.Drawing.Color.Gray
        Me.BunifuiOSSwitch1.OnColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.BunifuiOSSwitch1.Size = New System.Drawing.Size(43, 25)
        Me.BunifuiOSSwitch1.TabIndex = 714
        Me.BunifuiOSSwitch1.Value = False
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.LabelUsuarios)
        Me.GradientPanel2.Controls.Add(Me.ComboUnidad)
        Me.GradientPanel2.Controls.Add(Me.ComboUsuarios)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Controls.Add(Me.BunifuiOSSwitch1)
        Me.GradientPanel2.Controls.Add(Me.ComboReporte)
        Me.GradientPanel2.Controls.Add(Me.Panel1)
        Me.GradientPanel2.Controls.Add(Me.Label2)
        Me.GradientPanel2.Controls.Add(Me.Label4)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1107, 60)
        Me.GradientPanel2.TabIndex = 715
        '
        'UCResumenVentasCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "UCResumenVentasCustom"
        Me.Size = New System.Drawing.Size(1107, 494)
        CType(Me.ComboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.PanelProductos.ResumeLayout(False)
        Me.PanelProductos.PerformLayout()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboUnidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboReporte As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents LabelUsuarios As Label
    Friend WithEvents ComboUsuarios As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboMesPedido As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents BunifuiOSSwitch1 As Bunifu.Framework.UI.BunifuiOSSwitch
    Private WithEvents panel5 As Panel
    Private WithEvents Label5 As Label
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Private WithEvents pictureBox2 As PictureBox
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelTotalVentas As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelAlCredito As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelAlContado As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SwitchAcumulado As Bunifu.Framework.UI.BunifuiOSSwitch
    Friend WithEvents LabelAcumulado As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ComboComprobante As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents PanelProductos As Panel
    Friend WithEvents LabelTotalSinStock As Label
    Friend WithEvents LabelTotalConStock As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
End Class

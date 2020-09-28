<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCmaestroManifiestoEncomiendas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCmaestroManifiestoEncomiendas))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboPrint = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuThinButton24 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboAgenciaDestino = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboAgenciaOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListDetalle = New System.Windows.Forms.ListView()
        Me.ColID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColFechaEnvio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColChofer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColUnidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GridEncomiendas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.ComboPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GridEncomiendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GradientPanel2.BackgroundImage = CType(resources.GetObject("GradientPanel2.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel2.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Controls.Add(Me.BunifuThinButton21)
        Me.GradientPanel2.Controls.Add(Me.Label14)
        Me.GradientPanel2.Controls.Add(Me.ComboPrint)
        Me.GradientPanel2.Controls.Add(Me.BunifuThinButton24)
        Me.GradientPanel2.Controls.Add(Me.Label2)
        Me.GradientPanel2.Controls.Add(Me.ComboAgenciaDestino)
        Me.GradientPanel2.Controls.Add(Me.ComboAgenciaOrigen)
        Me.GradientPanel2.Controls.Add(Me.BunifuThinButton23)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1109, 60)
        Me.GradientPanel2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 620
        Me.Label1.Text = "Agencia de origen"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.Transparent
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Imprimir"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton21.Location = New System.Drawing.Point(776, 16)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(130, 40)
        Me.BunifuThinButton21.TabIndex = 619
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1065, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 14)
        Me.Label14.TabIndex = 618
        Me.Label14.Text = "Impresora"
        Me.Label14.Visible = False
        '
        'ComboPrint
        '
        Me.ComboPrint.BackColor = System.Drawing.Color.White
        Me.ComboPrint.BeforeTouchSize = New System.Drawing.Size(149, 19)
        Me.ComboPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPrint.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboPrint.Location = New System.Drawing.Point(1068, 31)
        Me.ComboPrint.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboPrint.Name = "ComboPrint"
        Me.ComboPrint.Size = New System.Drawing.Size(149, 19)
        Me.ComboPrint.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboPrint.TabIndex = 617
        Me.ComboPrint.Visible = False
        '
        'BunifuThinButton24
        '
        Me.BunifuThinButton24.ActiveBorderThickness = 1
        Me.BunifuThinButton24.ActiveCornerRadius = 20
        Me.BunifuThinButton24.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BunifuThinButton24.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton24.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BunifuThinButton24.BackColor = System.Drawing.Color.Transparent
        Me.BunifuThinButton24.BackgroundImage = CType(resources.GetObject("BunifuThinButton24.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton24.ButtonText = "Exportat excel"
        Me.BunifuThinButton24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton24.Font = New System.Drawing.Font("Yu Gothic", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton24.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton24.IdleBorderThickness = 1
        Me.BunifuThinButton24.IdleCornerRadius = 20
        Me.BunifuThinButton24.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BunifuThinButton24.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton24.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BunifuThinButton24.Location = New System.Drawing.Point(645, 16)
        Me.BunifuThinButton24.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BunifuThinButton24.Name = "BunifuThinButton24"
        Me.BunifuThinButton24.Size = New System.Drawing.Size(125, 40)
        Me.BunifuThinButton24.TabIndex = 591
        Me.BunifuThinButton24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(262, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 15)
        Me.Label2.TabIndex = 590
        Me.Label2.Text = "Agencia de destino"
        '
        'ComboAgenciaDestino
        '
        Me.ComboAgenciaDestino.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaDestino.BeforeTouchSize = New System.Drawing.Size(235, 21)
        Me.ComboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaDestino.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaDestino.Location = New System.Drawing.Point(265, 31)
        Me.ComboAgenciaDestino.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaDestino.Name = "ComboAgenciaDestino"
        Me.ComboAgenciaDestino.Size = New System.Drawing.Size(235, 21)
        Me.ComboAgenciaDestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaDestino.TabIndex = 589
        '
        'ComboAgenciaOrigen
        '
        Me.ComboAgenciaOrigen.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaOrigen.BeforeTouchSize = New System.Drawing.Size(235, 21)
        Me.ComboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaOrigen.Enabled = False
        Me.ComboAgenciaOrigen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaOrigen.Location = New System.Drawing.Point(15, 31)
        Me.ComboAgenciaOrigen.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaOrigen.Name = "ComboAgenciaOrigen"
        Me.ComboAgenciaOrigen.Size = New System.Drawing.Size(235, 21)
        Me.ComboAgenciaOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaOrigen.TabIndex = 587
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.Transparent
        Me.BunifuThinButton23.BackgroundImage = CType(resources.GetObject("BunifuThinButton23.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton23.ButtonText = "Consultar"
        Me.BunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton23.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton23.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleBorderThickness = 1
        Me.BunifuThinButton23.IdleCornerRadius = 20
        Me.BunifuThinButton23.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton23.IdleForecolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuThinButton23.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(92, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.BunifuThinButton23.Location = New System.Drawing.Point(512, 16)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(125, 40)
        Me.BunifuThinButton23.TabIndex = 2
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ListDetalle)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 60)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1109, 114)
        Me.GradientPanel1.TabIndex = 9
        '
        'ListDetalle
        '
        Me.ListDetalle.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColID, Me.ColFechaEnvio, Me.ColChofer, Me.ColUnidad})
        Me.ListDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListDetalle.FullRowSelect = True
        Me.ListDetalle.GridLines = True
        Me.ListDetalle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListDetalle.HideSelection = False
        Me.ListDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ListDetalle.Name = "ListDetalle"
        Me.ListDetalle.Size = New System.Drawing.Size(1107, 112)
        Me.ListDetalle.TabIndex = 0
        Me.ListDetalle.UseCompatibleStateImageBehavior = False
        Me.ListDetalle.View = System.Windows.Forms.View.Details
        '
        'ColID
        '
        Me.ColID.Text = "ID"
        Me.ColID.Width = 0
        '
        'ColFechaEnvio
        '
        Me.ColFechaEnvio.Text = "fecha envio"
        Me.ColFechaEnvio.Width = 149
        '
        'ColChofer
        '
        Me.ColChofer.Text = "Conductor"
        Me.ColChofer.Width = 231
        '
        'ColUnidad
        '
        Me.ColUnidad.Text = "Unidad-vehículo"
        Me.ColUnidad.Width = 112
        '
        'GridEncomiendas
        '
        Me.GridEncomiendas.BackColor = System.Drawing.Color.White
        Me.GridEncomiendas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridEncomiendas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEncomiendas.FreezeCaption = False
        Me.GridEncomiendas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEncomiendas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEncomiendas.Location = New System.Drawing.Point(0, 174)
        Me.GridEncomiendas.Name = "GridEncomiendas"
        Me.GridEncomiendas.Size = New System.Drawing.Size(1109, 294)
        Me.GridEncomiendas.TabIndex = 10
        Me.GridEncomiendas.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "id"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Fec. venta"
        GridColumnDescriptor2.MappingName = "fecharecepcion"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Remitente"
        GridColumnDescriptor3.MappingName = "Emisor"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 150
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Consignado"
        GridColumnDescriptor4.MappingName = "receptor"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 180
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Cantidad"
        GridColumnDescriptor5.MappingName = "cantidad"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Contenido"
        GridColumnDescriptor6.MappingName = "contenido"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 170
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Total"
        GridColumnDescriptor7.MappingName = "costo"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 75
        Me.GridEncomiendas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.GridEncomiendas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEncomiendas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridEncomiendas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("id"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecharecepcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Emisor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("receptor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("contenido"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("costo")})
        Me.GridEncomiendas.Text = "GridGroupingControl1"
        Me.GridEncomiendas.VersionInfo = "12.4400.0.24"
        '
        'UCmaestroManifiestoEncomiendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridEncomiendas)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "UCmaestroManifiestoEncomiendas"
        Me.Size = New System.Drawing.Size(1109, 468)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.ComboPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GridEncomiendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ComboAgenciaOrigen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboAgenciaDestino As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ListDetalle As ListView
    Friend WithEvents ColID As ColumnHeader
    Friend WithEvents ColFechaEnvio As ColumnHeader
    Friend WithEvents GridEncomiendas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents BunifuThinButton24 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboPrint As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ColChofer As ColumnHeader
    Friend WithEvents ColUnidad As ColumnHeader
    Friend WithEvents Label1 As Label
End Class

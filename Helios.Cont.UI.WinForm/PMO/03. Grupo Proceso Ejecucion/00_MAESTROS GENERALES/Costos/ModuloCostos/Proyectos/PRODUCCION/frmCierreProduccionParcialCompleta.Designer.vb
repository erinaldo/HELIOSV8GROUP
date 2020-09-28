<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreProduccionParcialCompleta
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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierreProduccionParcialCompleta))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvCierres = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEntregable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCant = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtUM = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCosto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlaneado = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtEntregados = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtResumenTotal = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboStatus = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCierres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEntregable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlaneado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEntregados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtResumenTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(696, 10)
        Me.GradientPanel1.TabIndex = 508
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 14)
        Me.Label2.TabIndex = 567
        Me.Label2.Text = "Listado de Entregas Parciales"
        '
        'dgvCierres
        '
        Me.dgvCierres.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCierres.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCierres.FreezeCaption = False
        Me.dgvCierres.Location = New System.Drawing.Point(0, 0)
        Me.dgvCierres.Name = "dgvCierres"
        Me.dgvCierres.Size = New System.Drawing.Size(482, 219)
        Me.dgvCierres.TabIndex = 568
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idcosto"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 15
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "fecha"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "detalle"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 161
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "cantidad"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "costo"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 119
        Me.dgvCierres.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgvCierres.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("detalle"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("costo")})
        Me.dgvCierres.Text = "GridGroupingControl1"
        Me.dgvCierres.VersionInfo = "12.4400.0.24"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 14)
        Me.Label3.TabIndex = 569
        Me.Label3.Text = "Producto terminado"
        '
        'txtEntregable
        '
        Me.txtEntregable.BackColor = System.Drawing.Color.White
        Me.txtEntregable.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtEntregable.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEntregable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntregable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEntregable.Enabled = False
        Me.txtEntregable.Location = New System.Drawing.Point(26, 34)
        Me.txtEntregable.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEntregable.Name = "txtEntregable"
        Me.txtEntregable.Size = New System.Drawing.Size(241, 22)
        Me.txtEntregable.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtEntregable.TabIndex = 570
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(270, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 14)
        Me.Label4.TabIndex = 571
        Me.Label4.Text = "cantidad"
        '
        'txtCant
        '
        Me.txtCant.BackColor = System.Drawing.Color.White
        Me.txtCant.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCant.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCant.Enabled = False
        Me.txtCant.Location = New System.Drawing.Point(273, 34)
        Me.txtCant.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCant.Name = "txtCant"
        Me.txtCant.Size = New System.Drawing.Size(75, 22)
        Me.txtCant.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCant.TabIndex = 572
        Me.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUM
        '
        Me.txtUM.BackColor = System.Drawing.Color.White
        Me.txtUM.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtUM.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtUM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUM.Enabled = False
        Me.txtUM.Location = New System.Drawing.Point(354, 34)
        Me.txtUM.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtUM.Name = "txtUM"
        Me.txtUM.Size = New System.Drawing.Size(75, 22)
        Me.txtUM.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtUM.TabIndex = 574
        Me.txtUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(351, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 14)
        Me.Label5.TabIndex = 573
        Me.Label5.Text = "U.M."
        '
        'txtCosto
        '
        Me.txtCosto.BackColor = System.Drawing.Color.White
        Me.txtCosto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCosto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCosto.Enabled = False
        Me.txtCosto.Location = New System.Drawing.Point(435, 34)
        Me.txtCosto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(75, 22)
        Me.txtCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCosto.TabIndex = 576
        Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(432, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 14)
        Me.Label6.TabIndex = 575
        Me.Label6.Text = "Costo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(545, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 577
        Me.Label1.Text = "Resúmen General"
        '
        'txtPlaneado
        '
        Me.txtPlaneado.BackColor = System.Drawing.Color.White
        Me.txtPlaneado.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtPlaneado.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPlaneado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlaneado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlaneado.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtPlaneado.Location = New System.Drawing.Point(548, 122)
        Me.txtPlaneado.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPlaneado.Name = "txtPlaneado"
        Me.txtPlaneado.ReadOnly = True
        Me.txtPlaneado.Size = New System.Drawing.Size(127, 22)
        Me.txtPlaneado.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPlaneado.TabIndex = 578
        Me.txtPlaneado.Text = "0.00"
        '
        'txtEntregados
        '
        Me.txtEntregados.BackColor = System.Drawing.Color.White
        Me.txtEntregados.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtEntregados.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEntregados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntregados.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEntregados.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtEntregados.Location = New System.Drawing.Point(548, 150)
        Me.txtEntregados.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtEntregados.Name = "txtEntregados"
        Me.txtEntregados.ReadOnly = True
        Me.txtEntregados.Size = New System.Drawing.Size(127, 22)
        Me.txtEntregados.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtEntregados.TabIndex = 579
        Me.txtEntregados.Text = "0.00"
        '
        'txtResumenTotal
        '
        Me.txtResumenTotal.BackColor = System.Drawing.Color.White
        Me.txtResumenTotal.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtResumenTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtResumenTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResumenTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtResumenTotal.ForeColor = System.Drawing.Color.SeaGreen
        Me.txtResumenTotal.Location = New System.Drawing.Point(548, 178)
        Me.txtResumenTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtResumenTotal.Name = "txtResumenTotal"
        Me.txtResumenTotal.ReadOnly = True
        Me.txtResumenTotal.Size = New System.Drawing.Size(127, 22)
        Me.txtResumenTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtResumenTotal.TabIndex = 580
        Me.txtResumenTotal.Text = "0.00"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(144, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(127, 46)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(548, 313)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(127, 46)
        Me.ButtonAdv1.TabIndex = 581
        Me.ButtonAdv1.Text = "            Cerrar producción"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.dgvCierres)
        Me.GradientPanel2.Location = New System.Drawing.Point(26, 95)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(484, 221)
        Me.GradientPanel2.TabIndex = 582
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.BeforeTouchSize = New System.Drawing.Size(190, 21)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.Location = New System.Drawing.Point(29, 344)
        Me.cboStatus.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(190, 21)
        Me.cboStatus.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboStatus.TabIndex = 584
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 14)
        Me.Label7.TabIndex = 583
        Me.Label7.Text = "Estado"
        '
        'txtInicio
        '
        Me.txtInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.Name = "monthCalendar"
        Me.txtInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtInicio.Calendar.TabIndex = 0
        Me.txtInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtInicio.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtInicio.Calendar.NoneButton.Text = "None"
        Me.txtInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtInicio.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtInicio.Calendar.TodayButton.Text = "Today"
        Me.txtInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtInicio.Checked = False
        Me.txtInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtInicio.CustomFormat = "dd/MM/yyyy"
        Me.txtInicio.DropDownImage = Nothing
        Me.txtInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtInicio.Location = New System.Drawing.Point(548, 36)
        Me.txtInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtInicio.MinValue = New Date(CType(0, Long))
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.ShowCheckBox = False
        Me.txtInicio.ShowDropButton = False
        Me.txtInicio.Size = New System.Drawing.Size(101, 20)
        Me.txtInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtInicio.TabIndex = 586
        Me.txtInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(546, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 14)
        Me.Label8.TabIndex = 585
        Me.Label8.Text = "Fecha de culminación"
        '
        'frmCierreProduccionParcialCompleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Cierre de la producción"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(144, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Producto terminado"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(696, 371)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.txtResumenTotal)
        Me.Controls.Add(Me.txtEntregados)
        Me.Controls.Add(Me.txtPlaneado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUM)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCant)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEntregable)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCierreProduccionParcialCompleta"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCierres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEntregable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlaneado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEntregados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtResumenTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvCierres As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEntregable As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCant As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtUM As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCosto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPlaneado As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtEntregados As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtResumenTotal As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents cboStatus As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label8 As Label
End Class

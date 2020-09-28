<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaAsistenciaTrabajador
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaAsistenciaTrabajador))
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtAnio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPeriodo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPersonal = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltro = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgAsistencia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ControlDeAsistenciaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgDetalle = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ControlDeAsistenciaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAsistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlDeAsistenciaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlDeAsistenciaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.DarkGray
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtAnio)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.cboPeriodo)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.txtPersonal)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.txtFiltro)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(876, 79)
        Me.GradientPanel1.TabIndex = 0
        '
        'txtAnio
        '
        Me.txtAnio.BackColor = System.Drawing.Color.White
        Me.txtAnio.BeforeTouchSize = New System.Drawing.Size(150, 22)
        Me.txtAnio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnio.Location = New System.Drawing.Point(472, 43)
        Me.txtAnio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(67, 22)
        Me.txtAnio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAnio.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(469, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Año"
        '
        'cboPeriodo
        '
        Me.cboPeriodo.BackColor = System.Drawing.Color.White
        Me.cboPeriodo.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodo.Location = New System.Drawing.Point(545, 44)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        Me.cboPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPeriodo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(542, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Período"
        '
        'txtPersonal
        '
        Me.txtPersonal.BackColor = System.Drawing.Color.White
        Me.txtPersonal.BeforeTouchSize = New System.Drawing.Size(150, 22)
        Me.txtPersonal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPersonal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPersonal.Location = New System.Drawing.Point(203, 43)
        Me.txtPersonal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPersonal.Name = "txtPersonal"
        Me.txtPersonal.ReadOnly = True
        Me.txtPersonal.Size = New System.Drawing.Size(262, 22)
        Me.txtPersonal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPersonal.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(200, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Personal"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(110, 30)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(673, 35)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(110, 30)
        Me.ButtonAdv1.TabIndex = 2
        Me.ButtonAdv1.Text = "Consultar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(42, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Consultar x Nro. documento"
        '
        'txtFiltro
        '
        Me.txtFiltro.BackColor = System.Drawing.Color.White
        Me.txtFiltro.BeforeTouchSize = New System.Drawing.Size(150, 22)
        Me.txtFiltro.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFiltro.Location = New System.Drawing.Point(44, 43)
        Me.txtFiltro.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.NearImage = CType(resources.GetObject("txtFiltro.NearImage"), System.Drawing.Image)
        Me.txtFiltro.Size = New System.Drawing.Size(150, 22)
        Me.txtFiltro.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtFiltro.TabIndex = 0
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 79)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(876, 16)
        Me.GradientPanel2.TabIndex = 1
        '
        'dgAsistencia
        '
        Me.dgAsistencia.BackColor = System.Drawing.SystemColors.Window
        Me.dgAsistencia.DataSource = Me.ControlDeAsistenciaBindingSource
        Me.dgAsistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAsistencia.FreezeCaption = False
        Me.dgAsistencia.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgAsistencia.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgAsistencia.Location = New System.Drawing.Point(0, 95)
        Me.dgAsistencia.Name = "dgAsistencia"
        Me.dgAsistencia.Size = New System.Drawing.Size(426, 295)
        Me.dgAsistencia.TabIndex = 2
        Me.dgAsistencia.TableDescriptor.AllowNew = False
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Mes"
        GridColumnDescriptor7.MappingName = "MesAsistencia"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 84
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Día"
        GridColumnDescriptor8.MappingName = "DiaAsistencia"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 74
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Total tardanzas (Hrs.)"
        GridColumnDescriptor9.MappingName = "tardanzas"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 120
        Me.dgAsistencia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.dgAsistencia.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgAsistencia.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgAsistencia.Text = "GridGroupingControl1"
        Me.dgAsistencia.VersionInfo = "12.4400.0.24"
        '
        'ControlDeAsistenciaBindingSource
        '
        Me.ControlDeAsistenciaBindingSource.DataSource = GetType(Helios.Planilla.Business.Entity.ControlDeAsistencia)
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Maroon
        Me.GradientPanel3.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.dgDetalle)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GradientPanel3.Location = New System.Drawing.Point(426, 95)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(450, 295)
        Me.GradientPanel3.TabIndex = 3
        '
        'dgDetalle
        '
        Me.dgDetalle.BackColor = System.Drawing.SystemColors.Window
        Me.dgDetalle.DataSource = Me.ControlDeAsistenciaBindingSource1
        Me.dgDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDetalle.FreezeCaption = False
        Me.dgDetalle.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgDetalle.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.Size = New System.Drawing.Size(448, 293)
        Me.dgDetalle.TabIndex = 3
        Me.dgDetalle.TableDescriptor.AllowNew = False
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "ID"
        GridColumnDescriptor10.MappingName = "IDAsistencia"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 24
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.MappingName = "TipoAcesso"
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 105
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.MappingName = "HoraIngreso"
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 118
        Me.dgDetalle.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        Me.dgDetalle.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgDetalle.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgDetalle.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgDetalle.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TipoAcesso"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HoraIngreso")})
        Me.dgDetalle.Text = "GridGroupingControl1"
        Me.dgDetalle.VersionInfo = "12.4400.0.24"
        '
        'ControlDeAsistenciaBindingSource1
        '
        Me.ControlDeAsistenciaBindingSource1.DataSource = GetType(Helios.Planilla.Business.Entity.ControlDeAsistencia)
        '
        'frmConsultaAsistenciaTrabajador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.ClientSize = New System.Drawing.Size(876, 390)
        Me.Controls.Add(Me.dgAsistencia)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "frmConsultaAsistenciaTrabajador"
        Me.ShowIcon = False
        Me.Text = "Consultar Asistencia del personal"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAsistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlDeAsistenciaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlDeAsistenciaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltro As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboPeriodo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPersonal As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents dgAsistencia As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ControlDeAsistenciaBindingSource As BindingSource
    Friend WithEvents txtAnio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents dgDetalle As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ControlDeAsistenciaBindingSource1 As BindingSource
End Class

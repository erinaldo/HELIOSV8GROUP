<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConceptoPersonal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConceptoPersonal))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtCargo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNacionalidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtStatus = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDocumentoIdent = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumDNI = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvConceptos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNacionalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocumentoIdent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumDNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv4)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv3)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel1.Controls.Add(Me.txtCargo)
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Controls.Add(Me.PictureBox1)
        Me.GradientPanel1.Controls.Add(Me.txtNombres)
        Me.GradientPanel1.Controls.Add(Me.txtNacionalidad)
        Me.GradientPanel1.Controls.Add(Me.txtStatus)
        Me.GradientPanel1.Controls.Add(Me.txtDocumentoIdent)
        Me.GradientPanel1.Controls.Add(Me.txtNumDNI)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(12, 6)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(937, 188)
        Me.GradientPanel1.TabIndex = 0
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(83, 30)
        Me.ButtonAdv4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.Image = CType(resources.GetObject("ButtonAdv4.Image"), System.Drawing.Image)
        Me.ButtonAdv4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(107, 150)
        Me.ButtonAdv4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(83, 30)
        Me.ButtonAdv4.TabIndex = 509
        Me.ButtonAdv4.Text = "         Plantilla"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(83, 30)
        Me.ButtonAdv3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.Image = CType(resources.GetObject("ButtonAdv3.Image"), System.Drawing.Image)
        Me.ButtonAdv3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(22, 150)
        Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(83, 30)
        Me.ButtonAdv3.TabIndex = 508
        Me.ButtonAdv3.Text = "         Refresh"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(83, 30)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(320, 150)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(83, 30)
        Me.ButtonAdv2.TabIndex = 507
        Me.ButtonAdv2.Text = "         Eliminar"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.Color.White
        Me.txtCargo.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCargo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCargo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCargo.Location = New System.Drawing.Point(22, 122)
        Me.txtCargo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.ReadOnly = True
        Me.txtCargo.Size = New System.Drawing.Size(376, 22)
        Me.txtCargo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCargo.TabIndex = 7
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(126, 30)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(192, 150)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(126, 30)
        Me.ButtonAdv1.TabIndex = 506
        Me.ButtonAdv1.Text = "         Add concepto"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(624, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 153)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.White
        Me.txtNombres.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNombres.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombres.Location = New System.Drawing.Point(22, 94)
        Me.txtNombres.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ReadOnly = True
        Me.txtNombres.Size = New System.Drawing.Size(376, 22)
        Me.txtNombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNombres.TabIndex = 5
        '
        'txtNacionalidad
        '
        Me.txtNacionalidad.BackColor = System.Drawing.Color.White
        Me.txtNacionalidad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNacionalidad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNacionalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNacionalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNacionalidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNacionalidad.Location = New System.Drawing.Point(146, 66)
        Me.txtNacionalidad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNacionalidad.Name = "txtNacionalidad"
        Me.txtNacionalidad.ReadOnly = True
        Me.txtNacionalidad.Size = New System.Drawing.Size(252, 22)
        Me.txtNacionalidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNacionalidad.TabIndex = 4
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.White
        Me.txtStatus.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtStatus.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStatus.Location = New System.Drawing.Point(22, 66)
        Me.txtStatus.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(118, 22)
        Me.txtStatus.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtStatus.TabIndex = 3
        '
        'txtDocumentoIdent
        '
        Me.txtDocumentoIdent.BackColor = System.Drawing.Color.White
        Me.txtDocumentoIdent.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtDocumentoIdent.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDocumentoIdent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumentoIdent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoIdent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDocumentoIdent.Location = New System.Drawing.Point(146, 38)
        Me.txtDocumentoIdent.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDocumentoIdent.Name = "txtDocumentoIdent"
        Me.txtDocumentoIdent.ReadOnly = True
        Me.txtDocumentoIdent.Size = New System.Drawing.Size(252, 22)
        Me.txtDocumentoIdent.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDocumentoIdent.TabIndex = 2
        '
        'txtNumDNI
        '
        Me.txtNumDNI.BackColor = System.Drawing.Color.White
        Me.txtNumDNI.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumDNI.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDNI.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumDNI.Location = New System.Drawing.Point(22, 38)
        Me.txtNumDNI.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumDNI.Name = "txtNumDNI"
        Me.txtNumDNI.ReadOnly = True
        Me.txtNumDNI.Size = New System.Drawing.Size(118, 22)
        Me.txtNumDNI.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumDNI.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(18, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datos del trabajador"
        '
        'dgvConceptos
        '
        Me.dgvConceptos.BackColor = System.Drawing.SystemColors.Window
        Me.dgvConceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConceptos.FreezeCaption = False
        Me.dgvConceptos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvConceptos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvConceptos.Location = New System.Drawing.Point(0, 0)
        Me.dgvConceptos.Name = "dgvConceptos"
        Me.dgvConceptos.Size = New System.Drawing.Size(937, 340)
        Me.dgvConceptos.TabIndex = 296
        Me.dgvConceptos.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 49
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "IDSunat"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 86
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(249, Byte), Integer)))
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Código formula"
        GridColumnDescriptor3.MappingName = "codigo"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 175
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.WrapText = False
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Descripción"
        GridColumnDescriptor4.MappingName = "descripcion"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 330
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(249, Byte), Integer)))
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Tipo Calculo"
        GridColumnDescriptor5.MappingName = "tipocalculo"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 81
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)))
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Valor"
        GridColumnDescriptor6.MappingName = "valorconcepto"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 88
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CheckBoxOptions.IndetermValue = "False"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Status"
        GridColumnDescriptor7.MappingName = "activo"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 65
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(197, Byte), Integer)))
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "concepto"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 75
        Me.dgvConceptos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        Me.dgvConceptos.TableDescriptor.TableOptions.CaptionRowHeight = 34
        Me.dgvConceptos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvConceptos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvConceptos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("concepto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IDSunat"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipocalculo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("valorconcepto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("activo")})
        Me.dgvConceptos.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvConceptos.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvConceptos.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvConceptos.Text = "gridGroupingControl1"
        Me.dgvConceptos.VersionInfo = "12.2400.0.20"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgvConceptos)
        Me.Panel1.Location = New System.Drawing.Point(12, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(937, 340)
        Me.Panel1.TabIndex = 297
        '
        'frmConceptoPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Mantenimiento Conceptos"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Por Trabajador"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(961, 545)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MinimizeBox = False
        Me.Name = "frmConceptoPersonal"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNacionalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocumentoIdent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumDNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtNombres As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNacionalidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtStatus As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtDocumentoIdent As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNumDNI As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCargo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents dgvConceptos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel1 As Panel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialCajas
    Inherits frmMaster

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialCajas))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtRuc2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtCliente2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.dgvUsuarioActivo = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtAnioCompra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel16.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.txtRuc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsuarioActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel16.Controls.Add(Me.Label80)
        Me.Panel16.Controls.Add(Me.Label81)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(970, 37)
        Me.Panel16.TabIndex = 414
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label80.Location = New System.Drawing.Point(251, 12)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(51, 13)
        Me.Label80.TabIndex = 1
        Me.Label80.Text = "/ Listado"
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Black
        Me.Label81.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label81.Location = New System.Drawing.Point(5, 6)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(243, 25)
        Me.Label81.TabIndex = 0
        Me.Label81.Text = "HISTORIAL DE APERTRA/CIERRE DE CAJA"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GradientPanel8)
        Me.Panel1.Controls.Add(Me.txtRuc2)
        Me.Panel1.Controls.Add(Me.Label72)
        Me.Panel1.Controls.Add(Me.txtCliente2)
        Me.Panel1.Controls.Add(Me.Label71)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 51)
        Me.Panel1.TabIndex = 415
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.ButtonAdv4)
        Me.GradientPanel8.Location = New System.Drawing.Point(448, 17)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(85, 26)
        Me.GradientPanel8.TabIndex = 512
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(83, 24)
        Me.ButtonAdv4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv4.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv4.Image = CType(resources.GetObject("ButtonAdv4.Image"), System.Drawing.Image)
        Me.ButtonAdv4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(83, 24)
        Me.ButtonAdv4.TabIndex = 53
        Me.ButtonAdv4.Text = "Buscar."
        Me.ButtonAdv4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'txtRuc2
        '
        Me.txtRuc2.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtRuc2.BeforeTouchSize = New System.Drawing.Size(325, 22)
        Me.txtRuc2.BorderColor = System.Drawing.Color.Silver
        Me.txtRuc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc2.Enabled = False
        Me.txtRuc2.Location = New System.Drawing.Point(347, 21)
        Me.txtRuc2.Metrocolor = System.Drawing.Color.Silver
        Me.txtRuc2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc2.Name = "txtRuc2"
        Me.txtRuc2.ReadOnly = True
        Me.txtRuc2.Size = New System.Drawing.Size(96, 22)
        Me.txtRuc2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRuc2.TabIndex = 511
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label72.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label72.Location = New System.Drawing.Point(15, 3)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(73, 14)
        Me.Label72.TabIndex = 508
        Me.Label72.Text = "Usuario Caja"
        '
        'txtCliente2
        '
        Me.txtCliente2.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtCliente2.BeforeTouchSize = New System.Drawing.Size(325, 22)
        Me.txtCliente2.BorderColor = System.Drawing.Color.Silver
        Me.txtCliente2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCliente2.Enabled = False
        Me.txtCliente2.Location = New System.Drawing.Point(17, 21)
        Me.txtCliente2.Metrocolor = System.Drawing.Color.Silver
        Me.txtCliente2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCliente2.Name = "txtCliente2"
        Me.txtCliente2.NearImage = CType(resources.GetObject("txtCliente2.NearImage"), System.Drawing.Image)
        Me.txtCliente2.ReadOnly = True
        Me.txtCliente2.Size = New System.Drawing.Size(325, 22)
        Me.txtCliente2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCliente2.TabIndex = 509
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label71.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label71.Location = New System.Drawing.Point(350, 3)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(29, 14)
        Me.Label71.TabIndex = 510
        Me.Label71.Text = "RUC"
        '
        'dgvUsuarioActivo
        '
        Me.dgvUsuarioActivo.BackColor = System.Drawing.SystemColors.Window
        Me.dgvUsuarioActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarioActivo.FreezeCaption = False
        Me.dgvUsuarioActivo.Location = New System.Drawing.Point(0, 125)
        Me.dgvUsuarioActivo.Name = "dgvUsuarioActivo"
        Me.dgvUsuarioActivo.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvUsuarioActivo.NestedTableGroupOptions.ShowCaption = False
        Me.dgvUsuarioActivo.Size = New System.Drawing.Size(970, 261)
        Me.dgvUsuarioActivo.TabIndex = 416
        Me.dgvUsuarioActivo.TableDescriptor.ChildGroupOptions.ShowCaption = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idPersona"
        GridColumnDescriptor1.Name = "idPersona"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "idCaja"
        GridColumnDescriptor2.Name = "idCaja"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Nombre "
        GridColumnDescriptor3.MappingName = "nombre"
        GridColumnDescriptor3.Name = "nombre"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 280
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Estado"
        GridColumnDescriptor4.MappingName = "estado"
        GridColumnDescriptor4.Name = "estado"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 90
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Apertura MN"
        GridColumnDescriptor5.MappingName = "aperturaMN"
        GridColumnDescriptor5.Name = "aperturaMN"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 110
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Ingreso MN"
        GridColumnDescriptor6.MappingName = "ingresoMN"
        GridColumnDescriptor6.Name = "ingresoMN"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 110
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Egreso MN"
        GridColumnDescriptor7.MappingName = "egresoMN"
        GridColumnDescriptor7.Name = "egresoMN"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 110
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Saldo"
        GridColumnDescriptor8.MappingName = "total"
        GridColumnDescriptor8.Name = "total"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 110
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Fecha"
        GridColumnDescriptor9.MappingName = "fecha"
        GridColumnDescriptor9.Name = "fecha"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 130
        Me.dgvUsuarioActivo.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.dgvUsuarioActivo.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("aperturaMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ingresoMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("egresoMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("total")})
        Me.dgvUsuarioActivo.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvUsuarioActivo.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvUsuarioActivo.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvUsuarioActivo.Text = "GridGroupingControl1"
        Me.dgvUsuarioActivo.VersionInfo = "12.2400.0.20"
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.GradientPanel11.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel11.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel11.Controls.Add(Me.txtAnioCompra)
        Me.GradientPanel11.Controls.Add(Me.cboMesCompra)
        Me.GradientPanel11.Controls.Add(Me.Label21)
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 88)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(970, 37)
        Me.GradientPanel11.TabIndex = 417
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(86, 23)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(253, 5)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAdv1.TabIndex = 4
        Me.ButtonAdv1.Text = "Consultar"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtAnioCompra
        '
        Me.txtAnioCompra.BackColor = System.Drawing.Color.White
        Me.txtAnioCompra.BeforeTouchSize = New System.Drawing.Size(325, 22)
        Me.txtAnioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAnioCompra.Location = New System.Drawing.Point(191, 6)
        Me.txtAnioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.Name = "txtAnioCompra"
        Me.txtAnioCompra.ReadOnly = True
        Me.txtAnioCompra.Size = New System.Drawing.Size(56, 22)
        Me.txtAnioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAnioCompra.TabIndex = 2
        Me.txtAnioCompra.Text = "2016"
        Me.txtAnioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(65, 7)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(121, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(14, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Período"
        '
        'frmHistorialCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 386)
        Me.Controls.Add(Me.dgvUsuarioActivo)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel16)
        Me.Name = "frmHistorialCajas"
        Me.ShowIcon = False
        Me.Text = "Historial de Cajas"
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.txtRuc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsuarioActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        Me.GradientPanel11.PerformLayout()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents dgvUsuarioActivo As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtAnioCompra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtRuc2 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents txtCliente2 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label71 As System.Windows.Forms.Label
End Class

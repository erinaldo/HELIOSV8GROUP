<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedoresMaestro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedoresMaestro))
        Dim GridColumnDescriptor33 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor34 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor35 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor36 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor37 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor38 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor39 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor40 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToggleButton21 = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dgvProveedor = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.MistyRose
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 90)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(906, 22)
        Me.PanelError.TabIndex = 414
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Location = New System.Drawing.Point(887, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkRed
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToggleButton21)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Controls.Add(Me.GradientPanel8)
        Me.Panel1.Controls.Add(Me.GradientPanel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(906, 53)
        Me.Panel1.TabIndex = 413
        '
        'ToggleButton21
        '
        Me.ToggleButton21.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleButton21.ActiveText = "Filtro activo"
        Me.ToggleButton21.BackColor = System.Drawing.Color.Transparent
        Me.ToggleButton21.InActiveColor = System.Drawing.Color.WhiteSmoke
        Me.ToggleButton21.InActiveText = "Sin filtros"
        Me.ToggleButton21.Location = New System.Drawing.Point(364, 15)
        Me.ToggleButton21.MaximumSize = New System.Drawing.Size(135, 51)
        Me.ToggleButton21.MinimumSize = New System.Drawing.Size(93, 30)
        Me.ToggleButton21.Name = "ToggleButton21"
        Me.ToggleButton21.Size = New System.Drawing.Size(119, 30)
        Me.ToggleButton21.SliderColor = System.Drawing.Color.Black
        Me.ToggleButton21.SlidingAngle = 5
        Me.ToggleButton21.TabIndex = 457
        Me.ToggleButton21.Text = "ToggleButton21"
        Me.ToggleButton21.TextColor = System.Drawing.Color.White
        Me.ToggleButton21.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleButton21.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Location = New System.Drawing.Point(260, 10)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(89, 36)
        Me.GradientPanel1.TabIndex = 456
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(89, 36)
        Me.ButtonAdv1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(89, 36)
        Me.ButtonAdv1.TabIndex = 1
        Me.ButtonAdv1.Text = "Actualizar"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv3)
        Me.GradientPanel2.Location = New System.Drawing.Point(177, 10)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(81, 36)
        Me.GradientPanel2.TabIndex = 454
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.IndianRed
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(81, 36)
        Me.ButtonAdv3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.Image = CType(resources.GetObject("ButtonAdv3.Image"), System.Drawing.Image)
        Me.ButtonAdv3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(81, 36)
        Me.ButtonAdv3.TabIndex = 1
        Me.ButtonAdv3.Text = "Cambiar Status"
        Me.ButtonAdv3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel8.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel8.Location = New System.Drawing.Point(21, 10)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(76, 36)
        Me.GradientPanel8.TabIndex = 452
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(76, 36)
        Me.ButtonAdv2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(76, 36)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "Nuevo"
        Me.ButtonAdv2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel5.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel5.Location = New System.Drawing.Point(100, 10)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(73, 36)
        Me.GradientPanel5.TabIndex = 451
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(73, 36)
        Me.ButtonAdv6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(73, 36)
        Me.ButtonAdv6.TabIndex = 1
        Me.ButtonAdv6.Text = "Editar"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(906, 37)
        Me.Panel4.TabIndex = 412
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(192, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "/ Listado"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
        Me.Label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label19.Location = New System.Drawing.Point(5, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(187, 25)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "REGISTRO DE PROVEEDORES"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvProveedor
        '
        Me.dgvProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.dgvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProveedor.FreezeCaption = False
        Me.dgvProveedor.Location = New System.Drawing.Point(0, 112)
        Me.dgvProveedor.Name = "dgvProveedor"
        Me.dgvProveedor.Size = New System.Drawing.Size(906, 385)
        Me.dgvProveedor.TabIndex = 415
        GridColumnDescriptor33.HeaderImage = Nothing
        GridColumnDescriptor33.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor33.HeaderText = "ID"
        GridColumnDescriptor33.MappingName = "idEntidad"
        GridColumnDescriptor33.ReadOnly = True
        GridColumnDescriptor33.SerializedImageArray = ""
        GridColumnDescriptor33.Width = 50
        GridColumnDescriptor34.HeaderImage = Nothing
        GridColumnDescriptor34.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor34.HeaderText = "Tipo Doc."
        GridColumnDescriptor34.MappingName = "tipoDoc"
        GridColumnDescriptor34.ReadOnly = True
        GridColumnDescriptor34.SerializedImageArray = ""
        GridColumnDescriptor34.Width = 80
        GridColumnDescriptor35.HeaderImage = Nothing
        GridColumnDescriptor35.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor35.HeaderText = "Nro."
        GridColumnDescriptor35.MappingName = "nroDoc"
        GridColumnDescriptor35.ReadOnly = True
        GridColumnDescriptor35.SerializedImageArray = ""
        GridColumnDescriptor35.Width = 100
        GridColumnDescriptor36.HeaderImage = Nothing
        GridColumnDescriptor36.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor36.HeaderText = "Tipo"
        GridColumnDescriptor36.MappingName = "tipo"
        GridColumnDescriptor36.ReadOnly = True
        GridColumnDescriptor36.SerializedImageArray = ""
        GridColumnDescriptor36.Width = 85
        GridColumnDescriptor37.HeaderImage = Nothing
        GridColumnDescriptor37.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor37.HeaderText = "Razón social"
        GridColumnDescriptor37.MappingName = "razon"
        GridColumnDescriptor37.ReadOnly = True
        GridColumnDescriptor37.SerializedImageArray = ""
        GridColumnDescriptor37.Width = 200
        GridColumnDescriptor38.HeaderImage = Nothing
        GridColumnDescriptor38.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor38.HeaderText = "Dirección"
        GridColumnDescriptor38.MappingName = "direc"
        GridColumnDescriptor38.ReadOnly = True
        GridColumnDescriptor38.SerializedImageArray = ""
        GridColumnDescriptor38.Width = 300
        GridColumnDescriptor39.HeaderImage = Nothing
        GridColumnDescriptor39.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor39.HeaderText = "Telefono"
        GridColumnDescriptor39.MappingName = "fono"
        GridColumnDescriptor39.ReadOnly = True
        GridColumnDescriptor39.SerializedImageArray = ""
        GridColumnDescriptor39.Width = 80
        GridColumnDescriptor40.HeaderImage = Nothing
        GridColumnDescriptor40.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor40.MappingName = "estado"
        GridColumnDescriptor40.ReadOnly = True
        GridColumnDescriptor40.SerializedImageArray = ""
        GridColumnDescriptor40.Width = 120
        Me.dgvProveedor.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor33, GridColumnDescriptor34, GridColumnDescriptor35, GridColumnDescriptor36, GridColumnDescriptor37, GridColumnDescriptor38, GridColumnDescriptor39, GridColumnDescriptor40})
        Me.dgvProveedor.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("razon"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("direc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fono"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.dgvProveedor.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvProveedor.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvProveedor.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvProveedor.Text = "gridGroupingControl1"
        Me.dgvProveedor.VersionInfo = "12.2400.0.20"
        '
        'frmProveedoresMaestro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(906, 497)
        Me.Controls.Add(Me.dgvProveedor)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmProveedoresMaestro"
        Me.ShowIcon = False
        Me.Text = "Proveedor"
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelError As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label19 As Label
    Private WithEvents dgvProveedor As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ToggleButton21 As Helios.Cont.Presentation.WinForm.ToggleButton2
End Class

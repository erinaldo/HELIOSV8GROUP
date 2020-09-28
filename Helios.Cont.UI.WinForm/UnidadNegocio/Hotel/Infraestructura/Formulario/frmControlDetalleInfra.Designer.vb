<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmControlDetalleInfra
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlDetalleInfra))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvInfraestructura = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cboTipoComposicion = New System.Windows.Forms.ComboBox()
        Me.txtClasifiacacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInfraestructura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(458, 10)
        Me.GradientPanel1.TabIndex = 414
        '
        'dgvInfraestructura
        '
        Me.dgvInfraestructura.BackColor = System.Drawing.SystemColors.Window
        Me.dgvInfraestructura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInfraestructura.FreezeCaption = False
        Me.dgvInfraestructura.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvInfraestructura.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvInfraestructura.Location = New System.Drawing.Point(0, 63)
        Me.dgvInfraestructura.Name = "dgvInfraestructura"
        Me.dgvInfraestructura.Size = New System.Drawing.Size(458, 405)
        Me.dgvInfraestructura.TabIndex = 467
        Me.dgvInfraestructura.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "Descripcion"
        GridColumnDescriptor2.Name = "Descripcion"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 250
        Me.dgvInfraestructura.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2})
        Me.dgvInfraestructura.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "Distribución Infraestructura", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("bloque"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("sector"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idPiso"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("piso")})}))
        Me.dgvInfraestructura.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgvInfraestructura.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvInfraestructura.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvInfraestructura.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Descripcion")})
        Me.dgvInfraestructura.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvInfraestructura.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.dgvInfraestructura.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvInfraestructura.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvInfraestructura.Text = "gridGroupingControl1"
        Me.dgvInfraestructura.VersionInfo = "12.2400.0.20"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 516)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(458, 0)
        Me.GradientPanel2.TabIndex = 418
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(436, 18)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv1.TabIndex = 9
        Me.ButtonAdv1.Text = "Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(321, 18)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Selecionar"
        Me.btOperacion.UseVisualStyle = True
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackColor = System.Drawing.Color.White
        Me.GradientPanel4.BackgroundImage = CType(resources.GetObject("GradientPanel4.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel4.Controls.Add(Me.BunifuFlatButton3)
        Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel4.Location = New System.Drawing.Point(0, 10)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(458, 38)
        Me.GradientPanel4.TabIndex = 545
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 5
        Me.BunifuFlatButton3.ButtonText = "DISTRIBUIR"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Nothing
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(11, 10)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton3.TabIndex = 664
        Me.BunifuFlatButton3.Text = "DISTRIBUIR"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvInfraestructura)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(458, 468)
        Me.Panel1.TabIndex = 546
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(458, 468)
        Me.Panel2.TabIndex = 547
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtClasifiacacion)
        Me.Panel4.Controls.Add(Me.cboTipoComposicion)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(458, 63)
        Me.Panel4.TabIndex = 0
        '
        'cboTipoComposicion
        '
        Me.cboTipoComposicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComposicion.FormattingEnabled = True
        Me.cboTipoComposicion.Location = New System.Drawing.Point(243, 30)
        Me.cboTipoComposicion.Name = "cboTipoComposicion"
        Me.cboTipoComposicion.Size = New System.Drawing.Size(206, 21)
        Me.cboTipoComposicion.TabIndex = 534
        '
        'txtClasifiacacion
        '
        Me.txtClasifiacacion.Location = New System.Drawing.Point(15, 29)
        Me.txtClasifiacacion.Name = "txtClasifiacacion"
        Me.txtClasifiacacion.ReadOnly = True
        Me.txtClasifiacacion.Size = New System.Drawing.Size(206, 22)
        Me.txtClasifiacacion.TabIndex = 538
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 539
        Me.Label3.Text = "Clasificación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(240, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 540
        Me.Label4.Text = "Sub Clasificación"
        '
        'frmControlDetalleInfra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.White
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 40
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._010
        CaptionImage1.Location = New System.Drawing.Point(10, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(25, 25)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel1.Location = New System.Drawing.Point(39, 2)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Control de Detalle"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        CaptionLabel2.Location = New System.Drawing.Point(39, 16)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(300, 24)
        CaptionLabel2.Text = "Infraestructura/Componente"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(458, 516)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MinimizeBox = False
        Me.Name = "frmControlDetalleInfra"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInfraestructura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents dgvInfraestructura As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtClasifiacacion As TextBox
    Friend WithEvents cboTipoComposicion As ComboBox
End Class

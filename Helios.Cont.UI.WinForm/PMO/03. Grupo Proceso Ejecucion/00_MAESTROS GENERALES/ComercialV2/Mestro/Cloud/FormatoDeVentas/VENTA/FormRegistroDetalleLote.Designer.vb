Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRegistroDetalleLote
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRegistroDetalleLote))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.pcModelo = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.lsvModelo = New System.Windows.Forms.ListBox()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtModelo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblidlote = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridProductos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pcModelo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.Color.Gold
        Me.lblDescripcion.Location = New System.Drawing.Point(214, 35)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(49, 13)
        Me.lblDescripcion.TabIndex = 715
        Me.lblDescripcion.Text = "--------------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(158, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 714
        Me.Label2.Text = "Producto:"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.ForeColor = System.Drawing.Color.Gold
        Me.lblCategoria.Location = New System.Drawing.Point(823, 8)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(13, 13)
        Me.lblCategoria.TabIndex = 713
        Me.lblCategoria.Text = "0"
        Me.lblCategoria.Visible = False
        '
        'pcModelo
        '
        Me.pcModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcModelo.Controls.Add(Me.lsvModelo)
        Me.pcModelo.Controls.Add(Me.ButtonAdv1)
        Me.pcModelo.Controls.Add(Me.ButtonAdv2)
        Me.pcModelo.Location = New System.Drawing.Point(984, 25)
        Me.pcModelo.Name = "pcModelo"
        Me.pcModelo.Size = New System.Drawing.Size(193, 80)
        Me.pcModelo.TabIndex = 712
        Me.pcModelo.Visible = False
        '
        'lsvModelo
        '
        Me.lsvModelo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvModelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvModelo.FormattingEnabled = True
        Me.lsvModelo.Location = New System.Drawing.Point(0, 0)
        Me.lsvModelo.Name = "lsvModelo"
        Me.lsvModelo.Size = New System.Drawing.Size(191, 104)
        Me.lsvModelo.TabIndex = 3
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv1.TabIndex = 2
        Me.ButtonAdv1.Text = "Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "OK"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(842, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 674
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtModelo
        '
        Me.txtModelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtModelo.BeforeTouchSize = New System.Drawing.Size(253, 22)
        Me.txtModelo.BorderColor = System.Drawing.Color.DimGray
        Me.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelo.CornerRadius = 4
        Me.txtModelo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtModelo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.ForeColor = System.Drawing.Color.White
        Me.txtModelo.Location = New System.Drawing.Point(583, 26)
        Me.txtModelo.Metrocolor = System.Drawing.Color.LightGray
        Me.txtModelo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtModelo.Size = New System.Drawing.Size(253, 22)
        Me.txtModelo.TabIndex = 673
        Me.txtModelo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(580, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 13)
        Me.Label5.TabIndex = 672
        Me.Label5.Text = "SELECCIONE UN MODELO"
        Me.Label5.Visible = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = "Guardar"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
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
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(326, 462)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(126, 35)
        Me.BunifuFlatButton1.TabIndex = 671
        Me.BunifuFlatButton1.Text = "Guardar"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(85, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(26, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cantidad:"
        '
        'lblidlote
        '
        Me.lblidlote.AutoSize = True
        Me.lblidlote.ForeColor = System.Drawing.Color.Gold
        Me.lblidlote.Location = New System.Drawing.Point(85, 9)
        Me.lblidlote.Name = "lblidlote"
        Me.lblidlote.Size = New System.Drawing.Size(13, 13)
        Me.lblidlote.TabIndex = 1
        Me.lblidlote.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(26, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lote:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridProductos)
        Me.Panel2.Location = New System.Drawing.Point(4, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(898, 377)
        Me.Panel2.TabIndex = 1
        '
        'GridProductos
        '
        Me.GridProductos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridProductos.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridProductos.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridProductos.BackColor = System.Drawing.Color.Black
        Me.GridProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProductos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridProductos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridProductos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.GridProductos.Location = New System.Drawing.Point(0, 0)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridProductos.Size = New System.Drawing.Size(898, 377)
        Me.GridProductos.TabIndex = 519
        Me.GridProductos.TableDescriptor.AllowNew = False
        Me.GridProductos.TableDescriptor.Appearance.AnyRecordFieldCell.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.GridProductos.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridProductos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridProductos.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridProductos.Text = "GridDetalle"
        Me.GridProductos.UseRightToLeftCompatibleTextBox = True
        Me.GridProductos.VersionInfo = "12.2400.0.20"
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 5
        Me.BunifuFlatButton2.ButtonText = "Cancelar"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(467, 462)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(112, 35)
        Me.BunifuFlatButton2.TabIndex = 716
        Me.BunifuFlatButton2.Text = "Cancelar"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'lblModelo
        '
        Me.lblModelo.AutoSize = True
        Me.lblModelo.ForeColor = System.Drawing.Color.Gold
        Me.lblModelo.Location = New System.Drawing.Point(214, 8)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(49, 13)
        Me.lblModelo.TabIndex = 718
        Me.lblModelo.Text = "--------------"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Gold
        Me.Label7.Location = New System.Drawing.Point(158, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 717
        Me.Label7.Text = "Modelo:"
        '
        'FormRegistroDetalleLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.Gold
        Me.CaptionBarColor = System.Drawing.Color.Black
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(350, 24)
        CaptionLabel1.Text = "Ingreso De Caracteristicas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(914, 510)
        Me.Controls.Add(Me.lblModelo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BunifuFlatButton2)
        Me.Controls.Add(Me.pcModelo)
        Me.Controls.Add(Me.BunifuFlatButton1)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblidlote)
        Me.Controls.Add(Me.txtModelo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FormRegistroDetalleLote"
        Me.ShowIcon = False
        Me.pcModelo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblidlote As Label
    Friend WithEvents Label1 As Label
    Private WithEvents GridProductos As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtModelo As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Private WithEvents pcModelo As PopupControlContainer
    Friend WithEvents lsvModelo As ListBox
    Private WithEvents ButtonAdv1 As ButtonAdv
    Private WithEvents ButtonAdv2 As ButtonAdv
    Friend WithEvents lblCategoria As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents Label2 As Label
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents lblModelo As Label
    Friend WithEvents Label7 As Label
End Class

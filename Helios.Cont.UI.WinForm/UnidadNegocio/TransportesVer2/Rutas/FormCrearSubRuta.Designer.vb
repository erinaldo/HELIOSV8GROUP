Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearSubRuta
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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearSubRuta))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.BtGrabar = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GridTotales = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboAgenciaOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ComboAgenciaDestino = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chHabilitar = New System.Windows.Forms.CheckBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtGrabar
        '
        Me.BtGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.BtGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.BtGrabar.BeforeTouchSize = New System.Drawing.Size(112, 27)
        Me.BtGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGrabar.ForeColor = System.Drawing.Color.White
        Me.BtGrabar.IsBackStageButton = False
        Me.BtGrabar.Location = New System.Drawing.Point(542, 397)
        Me.BtGrabar.Name = "BtGrabar"
        Me.BtGrabar.Size = New System.Drawing.Size(112, 27)
        Me.BtGrabar.TabIndex = 581
        Me.BtGrabar.Text = "GUARDAR"
        Me.BtGrabar.UseVisualStyle = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(105, 44)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 13)
        Me.Label34.TabIndex = 611
        Me.Label34.Text = "Ruta Origen"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GridTotales)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GroupBox7.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox7.Location = New System.Drawing.Point(30, 127)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(771, 259)
        Me.GroupBox7.TabIndex = 616
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Sub Rutas"
        '
        'GridTotales
        '
        Me.GridTotales.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.GridTotales.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridTotales.BackColor = System.Drawing.SystemColors.Window
        Me.GridTotales.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridTotales.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridTotales.Location = New System.Drawing.Point(6, 28)
        Me.GridTotales.Name = "GridTotales"
        Me.GridTotales.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridTotales.Size = New System.Drawing.Size(759, 215)
        Me.GridTotales.TabIndex = 418
        Me.GridTotales.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.CellType = "ComboBox"
        GridColumnDescriptor2.HeaderText = "ORIGEN"
        GridColumnDescriptor2.MappingName = "ORIGEN"
        GridColumnDescriptor2.Name = "ORIGEN"
        GridColumnDescriptor2.Width = 300
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "ComboBox"
        GridColumnDescriptor3.MappingName = "DESTINO"
        GridColumnDescriptor3.Name = "DESTINO"
        GridColumnDescriptor3.Width = 300
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor4.MappingName = "VER"
        GridColumnDescriptor4.Name = "VER"
        GridColumnDescriptor4.Width = 60
        Me.GridTotales.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        Me.GridTotales.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridTotales.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridTotales.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ORIGEN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DESTINO"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("VER")})
        Me.GridTotales.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.GridTotales.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.GridTotales.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridTotales.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridTotales.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.GridTotales.Text = "GridGroupingControl2"
        Me.GridTotales.TopLevelGroupOptions.IsExpandedInitialValue = True
        Me.GridTotales.TopLevelGroupOptions.RepaintCaptionWhenItemsChanged = True
        Me.GridTotales.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.GridTotales.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = True
        Me.GridTotales.TopLevelGroupOptions.ShowCaption = False
        Me.GridTotales.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.GridTotales.UseRightToLeftCompatibleTextBox = True
        Me.GridTotales.VersionInfo = "12.4400.0.24"
        Me.GridTotales.VerticalScrollTips = True
        Me.GridTotales.WantTabKey = False
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(112, 27)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(660, 397)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(112, 27)
        Me.RoundButton21.TabIndex = 618
        Me.RoundButton21.Text = "CERRAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(112, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 41)
        Me.PictureBox1.TabIndex = 619
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(661, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(43, 41)
        Me.PictureBox2.TabIndex = 620
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(649, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 621
        Me.Label1.Text = "Ruta Destino"
        '
        'ComboAgenciaOrigen
        '
        Me.ComboAgenciaOrigen.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaOrigen.BeforeTouchSize = New System.Drawing.Size(237, 24)
        Me.ComboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaOrigen.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaOrigen.Location = New System.Drawing.Point(30, 60)
        Me.ComboAgenciaOrigen.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaOrigen.Name = "ComboAgenciaOrigen"
        Me.ComboAgenciaOrigen.Size = New System.Drawing.Size(237, 24)
        Me.ComboAgenciaOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaOrigen.TabIndex = 587
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(289, 36)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(247, 48)
        Me.PictureBox3.TabIndex = 623
        Me.PictureBox3.TabStop = False
        '
        'ComboAgenciaDestino
        '
        Me.ComboAgenciaDestino.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaDestino.BeforeTouchSize = New System.Drawing.Size(239, 24)
        Me.ComboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaDestino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaDestino.Location = New System.Drawing.Point(562, 60)
        Me.ComboAgenciaDestino.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaDestino.Name = "ComboAgenciaDestino"
        Me.ComboAgenciaDestino.Size = New System.Drawing.Size(239, 24)
        Me.ComboAgenciaDestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaDestino.TabIndex = 588
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(378, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 625
        Me.Label4.Text = "VER DETALLES"
        '
        'chHabilitar
        '
        Me.chHabilitar.AutoSize = True
        Me.chHabilitar.Location = New System.Drawing.Point(30, 104)
        Me.chHabilitar.Name = "chHabilitar"
        Me.chHabilitar.Size = New System.Drawing.Size(117, 17)
        Me.chHabilitar.TabIndex = 626
        Me.chHabilitar.Text = "Habilitar Sub Rutas"
        Me.chHabilitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Cooper Black", 20.25!)
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(705, 108)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 41)
        Me.btnAgregar.TabIndex = 627
        Me.btnAgregar.Text = "+"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnQuitar
        '
        Me.btnQuitar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitar.Font = New System.Drawing.Font("Cooper Black", 20.25!)
        Me.btnQuitar.ForeColor = System.Drawing.Color.White
        Me.btnQuitar.Location = New System.Drawing.Point(753, 108)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(42, 41)
        Me.btnQuitar.TabIndex = 628
        Me.btnQuitar.Text = "-"
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnQuitar.UseVisualStyleBackColor = False
        '
        'FormCrearSubRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarHeight = 50
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.ForeColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 7)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.CornflowerBlue
        CaptionLabel1.Location = New System.Drawing.Point(70, 12)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Crear Sub Rutas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(832, 427)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.chHabilitar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ComboAgenciaOrigen)
        Me.Controls.Add(Me.ComboAgenciaDestino)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.BtGrabar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearSubRuta"
        Me.ShowIcon = False
        Me.Text = " Crear Ruta"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtGrabar As RoundButton2
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label34 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ComboAgenciaOrigen As Tools.ComboBoxAdv
    Friend WithEvents chHabilitar As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboAgenciaDestino As Tools.ComboBoxAdv
    Friend WithEvents GridTotales As Grid.Grouping.GridGroupingControl
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnAgregar As Button
End Class

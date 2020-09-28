Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabCD_HabitacionDetalle
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabCD_HabitacionDetalle))
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowHabitaciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtNumeracion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvCompras = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.txtHabitacion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTipoSubCategoria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCategoria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCapacidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Line25 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtNumeracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHabitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoSubCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCapacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1135, 590)
        Me.GradientPanel2.TabIndex = 411
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.FlowHabitaciones)
        Me.Panel1.Controls.Add(Me.txtNumeracion)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dgvCompras)
        Me.Panel1.Controls.Add(Me.txtHabitacion)
        Me.Panel1.Controls.Add(Me.txtTipoSubCategoria)
        Me.Panel1.Controls.Add(Me.txtCategoria)
        Me.Panel1.Controls.Add(Me.txtCapacidad)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Line21)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1135, 546)
        Me.Panel1.TabIndex = 413
        '
        'FlowHabitaciones
        '
        Me.FlowHabitaciones.Location = New System.Drawing.Point(18, 90)
        Me.FlowHabitaciones.Name = "FlowHabitaciones"
        Me.FlowHabitaciones.Size = New System.Drawing.Size(552, 421)
        Me.FlowHabitaciones.TabIndex = 786
        Me.FlowHabitaciones.Visible = False
        '
        'txtNumeracion
        '
        Me.txtNumeracion.BackColor = System.Drawing.Color.White
        Me.txtNumeracion.BeforeTouchSize = New System.Drawing.Size(255, 26)
        Me.txtNumeracion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumeracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeracion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeracion.CornerRadius = 8
        Me.txtNumeracion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumeracion.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtNumeracion.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.txtNumeracion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumeracion.Location = New System.Drawing.Point(18, 166)
        Me.txtNumeracion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtNumeracion.MinimumSize = New System.Drawing.Size(26, 22)
        Me.txtNumeracion.Name = "txtNumeracion"
        Me.txtNumeracion.NearImage = CType(resources.GetObject("txtNumeracion.NearImage"), System.Drawing.Image)
        Me.txtNumeracion.ReadOnly = True
        Me.txtNumeracion.Size = New System.Drawing.Size(255, 26)
        Me.txtNumeracion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumeracion.TabIndex = 785
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(15, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 784
        Me.Label4.Text = "Numeración"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(656, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 18)
        Me.Label3.TabIndex = 783
        Me.Label3.Text = "Caracteristicas de la Habitación"
        '
        'dgvCompras
        '
        Me.dgvCompras.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCompras.FreezeCaption = False
        Me.dgvCompras.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompras.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCompras.Location = New System.Drawing.Point(659, 90)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.Size = New System.Drawing.Size(453, 421)
        Me.dgvCompras.TabIndex = 782
        Me.dgvCompras.TableDescriptor.AllowNew = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "N°"
        GridColumnDescriptor3.MappingName = "numero"
        GridColumnDescriptor3.Name = "numero"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "ACTIVO"
        GridColumnDescriptor4.MappingName = "habitacion"
        GridColumnDescriptor4.Name = "habitacion"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 300
        Me.dgvCompras.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor3, GridColumnDescriptor4})
        Me.dgvCompras.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgvCompras.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompras.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCompras.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("habitacion")})
        Me.dgvCompras.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvCompras.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvCompras.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvCompras.Text = "gridGroupingControl1"
        Me.dgvCompras.VersionInfo = "12.2400.0.20"
        '
        'txtHabitacion
        '
        Me.txtHabitacion.BackColor = System.Drawing.Color.White
        Me.txtHabitacion.BeforeTouchSize = New System.Drawing.Size(255, 26)
        Me.txtHabitacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtHabitacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHabitacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHabitacion.CornerRadius = 8
        Me.txtHabitacion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHabitacion.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtHabitacion.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.txtHabitacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtHabitacion.Location = New System.Drawing.Point(18, 93)
        Me.txtHabitacion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtHabitacion.MinimumSize = New System.Drawing.Size(26, 22)
        Me.txtHabitacion.Name = "txtHabitacion"
        Me.txtHabitacion.NearImage = CType(resources.GetObject("txtHabitacion.NearImage"), System.Drawing.Image)
        Me.txtHabitacion.ReadOnly = True
        Me.txtHabitacion.Size = New System.Drawing.Size(433, 26)
        Me.txtHabitacion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtHabitacion.TabIndex = 781
        '
        'txtTipoSubCategoria
        '
        Me.txtTipoSubCategoria.BackColor = System.Drawing.Color.White
        Me.txtTipoSubCategoria.BeforeTouchSize = New System.Drawing.Size(255, 26)
        Me.txtTipoSubCategoria.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipoSubCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoSubCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoSubCategoria.CornerRadius = 8
        Me.txtTipoSubCategoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoSubCategoria.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtTipoSubCategoria.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.txtTipoSubCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoSubCategoria.Location = New System.Drawing.Point(18, 377)
        Me.txtTipoSubCategoria.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipoSubCategoria.MinimumSize = New System.Drawing.Size(26, 22)
        Me.txtTipoSubCategoria.Name = "txtTipoSubCategoria"
        Me.txtTipoSubCategoria.NearImage = CType(resources.GetObject("txtTipoSubCategoria.NearImage"), System.Drawing.Image)
        Me.txtTipoSubCategoria.ReadOnly = True
        Me.txtTipoSubCategoria.Size = New System.Drawing.Size(433, 26)
        Me.txtTipoSubCategoria.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoSubCategoria.TabIndex = 780
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.White
        Me.txtCategoria.BeforeTouchSize = New System.Drawing.Size(255, 26)
        Me.txtCategoria.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoria.CornerRadius = 8
        Me.txtCategoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoria.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtCategoria.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.txtCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCategoria.Location = New System.Drawing.Point(18, 306)
        Me.txtCategoria.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtCategoria.MinimumSize = New System.Drawing.Size(26, 22)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.NearImage = CType(resources.GetObject("txtCategoria.NearImage"), System.Drawing.Image)
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(433, 26)
        Me.txtCategoria.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCategoria.TabIndex = 779
        '
        'txtCapacidad
        '
        Me.txtCapacidad.BackColor = System.Drawing.Color.White
        Me.txtCapacidad.BeforeTouchSize = New System.Drawing.Size(255, 26)
        Me.txtCapacidad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacidad.CornerRadius = 8
        Me.txtCapacidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCapacidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtCapacidad.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.txtCapacidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCapacidad.Location = New System.Drawing.Point(18, 234)
        Me.txtCapacidad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtCapacidad.MinimumSize = New System.Drawing.Size(26, 22)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.NearImage = CType(resources.GetObject("txtCapacidad.NearImage"), System.Drawing.Image)
        Me.txtCapacidad.ReadOnly = True
        Me.txtCapacidad.Size = New System.Drawing.Size(255, 26)
        Me.txtCapacidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCapacidad.TabIndex = 778
        Me.txtCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 18)
        Me.Label2.TabIndex = 777
        Me.Label2.Text = "Capacidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Frank Ruhl Hofshi", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(13, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(338, 26)
        Me.Label5.TabIndex = 776
        Me.Label5.Text = "INFORMACION DE LA HABITACION"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(15, 356)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 18)
        Me.Label12.TabIndex = 775
        Me.Label12.Text = "Tipo Habitación"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(15, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 18)
        Me.Label11.TabIndex = 774
        Me.Label11.Text = "Categoria"
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.Gainsboro
        Me.Line21.Location = New System.Drawing.Point(614, 61)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(3, 450)
        Me.Line21.TabIndex = 771
        Me.Line21.Text = "Line21"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 18)
        Me.Label1.TabIndex = 729
        Me.Label1.Text = "Habitación"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel3.Controls.Add(Me.Line25)
        Me.GradientPanel3.Controls.Add(Me.Label10)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1135, 44)
        Me.GradientPanel3.TabIndex = 415
        '
        'Line25
        '
        Me.Line25.BackColor = System.Drawing.Color.White
        Me.Line25.LineColor = System.Drawing.Color.DodgerBlue
        Me.Line25.Location = New System.Drawing.Point(1007, 36)
        Me.Line25.Name = "Line25"
        Me.Line25.Size = New System.Drawing.Size(110, 3)
        Me.Line25.TabIndex = 777
        Me.Line25.Text = "Line25"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Franklin Gothic Medium", 12.0!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.Image = CType(resources.GetObject("Label10.Image"), System.Drawing.Image)
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(1011, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 23)
        Me.Label10.TabIndex = 776
        Me.Label10.Text = "Retornar"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8_hotel_room_key.ico")
        '
        'TabCD_HabitacionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "TabCD_HabitacionDetalle"
        Me.Size = New System.Drawing.Size(1135, 590)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtNumeracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHabitacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoSubCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCapacidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTipoSubCategoria As Tools.TextBoxExt
    Friend WithEvents txtCategoria As Tools.TextBoxExt
    Friend WithEvents txtCapacidad As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Private WithEvents Line21 As Line2
    Friend WithEvents txtHabitacion As Tools.TextBoxExt
    Friend WithEvents Line25 As Line2
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNumeracion As Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Private WithEvents dgvCompras As Grid.Grouping.GridGroupingControl
    Friend WithEvents FlowHabitaciones As FlowLayoutPanel
    Friend WithEvents ImageList1 As ImageList
End Class

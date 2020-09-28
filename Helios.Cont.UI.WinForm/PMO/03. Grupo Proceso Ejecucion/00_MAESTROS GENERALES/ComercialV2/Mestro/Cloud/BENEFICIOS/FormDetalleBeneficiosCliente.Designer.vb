Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDetalleBeneficiosCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDetalleBeneficiosCliente))
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor19 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor20 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor21 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor22 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor23 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor24 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextNroDocEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Gridbeneficios = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridCupones = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Gridbeneficios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GridCupones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextNroDocEntidad)
        Me.GroupBox4.Controls.Add(Me.TextEntidad)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(471, 68)
        Me.GroupBox4.TabIndex = 228
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Cliente"
        '
        'TextNroDocEntidad
        '
        Me.TextNroDocEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNroDocEntidad.BeforeTouchSize = New System.Drawing.Size(335, 22)
        Me.TextNroDocEntidad.BorderColor = System.Drawing.Color.Silver
        Me.TextNroDocEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNroDocEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNroDocEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNroDocEntidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNroDocEntidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNroDocEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNroDocEntidad.Location = New System.Drawing.Point(354, 27)
        Me.TextNroDocEntidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextNroDocEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNroDocEntidad.Name = "TextNroDocEntidad"
        Me.TextNroDocEntidad.ReadOnly = True
        Me.TextNroDocEntidad.Size = New System.Drawing.Size(98, 22)
        Me.TextNroDocEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNroDocEntidad.TabIndex = 225
        '
        'TextEntidad
        '
        Me.TextEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextEntidad.BeforeTouchSize = New System.Drawing.Size(335, 22)
        Me.TextEntidad.BorderColor = System.Drawing.Color.Silver
        Me.TextEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEntidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextEntidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextEntidad.Location = New System.Drawing.Point(13, 27)
        Me.TextEntidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextEntidad.Name = "TextEntidad"
        Me.TextEntidad.NearImage = CType(resources.GetObject("TextEntidad.NearImage"), System.Drawing.Image)
        Me.TextEntidad.ReadOnly = True
        Me.TextEntidad.Size = New System.Drawing.Size(335, 22)
        Me.TextEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextEntidad.TabIndex = 224
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Gridbeneficios)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(752, 322)
        Me.Panel1.TabIndex = 229
        '
        'Gridbeneficios
        '
        Me.Gridbeneficios.BackColor = System.Drawing.Color.White
        Me.Gridbeneficios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gridbeneficios.FreezeCaption = False
        Me.Gridbeneficios.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.Gridbeneficios.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.Gridbeneficios.Location = New System.Drawing.Point(0, 0)
        Me.Gridbeneficios.Name = "Gridbeneficios"
        Me.Gridbeneficios.Size = New System.Drawing.Size(750, 320)
        Me.Gridbeneficios.TabIndex = 420
        Me.Gridbeneficios.TableDescriptor.AllowNew = False
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "id"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 21
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "tipobeneficio"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 167
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.MappingName = "producto"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 234
        GridColumnDescriptor16.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.MappingName = "montobase"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor16.Width = 87
        GridColumnDescriptor17.HeaderImage = Nothing
        GridColumnDescriptor17.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor17.MappingName = "valorganado"
        GridColumnDescriptor17.SerializedImageArray = ""
        GridColumnDescriptor17.Width = 103
        GridColumnDescriptor18.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor18.HeaderImage = Nothing
        GridColumnDescriptor18.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor18.MappingName = "vigencia"
        GridColumnDescriptor18.ReadOnly = True
        GridColumnDescriptor18.SerializedImageArray = ""
        GridColumnDescriptor18.Width = 140
        Me.Gridbeneficios.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, GridColumnDescriptor18})
        Me.Gridbeneficios.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.Gridbeneficios.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.Gridbeneficios.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipobeneficio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("montobase"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("valorganado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("vigencia")})
        Me.Gridbeneficios.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.Gridbeneficios.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.Gridbeneficios.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.Gridbeneficios.Text = "gridGroupingControl1"
        Me.Gridbeneficios.VersionInfo = "12.2400.0.20"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(14, 83)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(766, 354)
        Me.TabControl1.TabIndex = 230
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(758, 328)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DESCUENTOS, REBAJAS, PROMOCIONES Y REGALOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridCupones)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(758, 328)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "CUPONES Y VALES"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GridCupones
        '
        Me.GridCupones.BackColor = System.Drawing.Color.White
        Me.GridCupones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCupones.FreezeCaption = False
        Me.GridCupones.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridCupones.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridCupones.Location = New System.Drawing.Point(3, 3)
        Me.GridCupones.Name = "GridCupones"
        Me.GridCupones.Size = New System.Drawing.Size(752, 322)
        Me.GridCupones.TabIndex = 421
        Me.GridCupones.TableDescriptor.AllowNew = False
        GridColumnDescriptor19.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor19.HeaderImage = Nothing
        GridColumnDescriptor19.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor19.MappingName = "id"
        GridColumnDescriptor19.ReadOnly = True
        GridColumnDescriptor19.SerializedImageArray = ""
        GridColumnDescriptor19.Width = 21
        GridColumnDescriptor20.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor20.HeaderImage = Nothing
        GridColumnDescriptor20.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor20.MappingName = "tipobeneficio"
        GridColumnDescriptor20.ReadOnly = True
        GridColumnDescriptor20.SerializedImageArray = ""
        GridColumnDescriptor20.Width = 167
        GridColumnDescriptor21.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor21.HeaderImage = Nothing
        GridColumnDescriptor21.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor21.MappingName = "producto"
        GridColumnDescriptor21.ReadOnly = True
        GridColumnDescriptor21.SerializedImageArray = ""
        GridColumnDescriptor21.Width = 234
        GridColumnDescriptor22.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor22.HeaderImage = Nothing
        GridColumnDescriptor22.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor22.MappingName = "montobase"
        GridColumnDescriptor22.ReadOnly = True
        GridColumnDescriptor22.SerializedImageArray = ""
        GridColumnDescriptor22.Width = 87
        GridColumnDescriptor23.HeaderImage = Nothing
        GridColumnDescriptor23.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor23.MappingName = "valorganado"
        GridColumnDescriptor23.SerializedImageArray = ""
        GridColumnDescriptor23.Width = 103
        GridColumnDescriptor24.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor24.HeaderImage = Nothing
        GridColumnDescriptor24.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor24.MappingName = "vigencia"
        GridColumnDescriptor24.ReadOnly = True
        GridColumnDescriptor24.SerializedImageArray = ""
        GridColumnDescriptor24.Width = 140
        Me.GridCupones.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor19, GridColumnDescriptor20, GridColumnDescriptor21, GridColumnDescriptor22, GridColumnDescriptor23, GridColumnDescriptor24})
        Me.GridCupones.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridCupones.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridCupones.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipobeneficio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("producto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("montobase"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("valorganado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("vigencia")})
        Me.GridCupones.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.GridCupones.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.GridCupones.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.GridCupones.Text = "gridGroupingControl1"
        Me.GridCupones.VersionInfo = "12.2400.0.20"
        '
        'FormDetalleBeneficiosCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(794, 437)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "FormDetalleBeneficiosCliente"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Gridbeneficios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.GridCupones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextNroDocEntidad As Tools.TextBoxExt
    Friend WithEvents TextEntidad As Tools.TextBoxExt
    Friend WithEvents Panel1 As Panel
    Private WithEvents Gridbeneficios As Grid.Grouping.GridGroupingControl
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Private WithEvents GridCupones As Grid.Grouping.GridGroupingControl
End Class

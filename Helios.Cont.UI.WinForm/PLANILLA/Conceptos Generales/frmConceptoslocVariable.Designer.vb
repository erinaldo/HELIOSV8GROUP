<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptoslocVariable
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
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoConcepto = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.dgvConceptos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.txtBuscar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel1.SuspendLayout()
        CType(Me.cboTipoConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboTipoConcepto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 54)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Concepto"
        '
        'cboTipoConcepto
        '
        Me.cboTipoConcepto.BackColor = System.Drawing.Color.White
        Me.cboTipoConcepto.BeforeTouchSize = New System.Drawing.Size(221, 21)
        Me.cboTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoConcepto.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoConcepto.Location = New System.Drawing.Point(12, 27)
        Me.cboTipoConcepto.Name = "cboTipoConcepto"
        Me.cboTipoConcepto.Size = New System.Drawing.Size(221, 21)
        Me.cboTipoConcepto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoConcepto.TabIndex = 73
        '
        'dgvConceptos
        '
        Me.dgvConceptos.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvConceptos.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvConceptos.BackColor = System.Drawing.SystemColors.Window
        Me.dgvConceptos.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvConceptos.FreezeCaption = False
        Me.dgvConceptos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvConceptos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvConceptos.Location = New System.Drawing.Point(0, 54)
        Me.dgvConceptos.Name = "dgvConceptos"
        Me.dgvConceptos.Size = New System.Drawing.Size(447, 319)
        Me.dgvConceptos.TabIndex = 404
        Me.dgvConceptos.TableDescriptor.AllowNew = False
        Me.dgvConceptos.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvConceptos.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvConceptos.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvConceptos.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvConceptos.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvConceptos.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvConceptos.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvConceptos.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvConceptos.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvConceptos.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvConceptos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvConceptos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvConceptos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvConceptos.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "ID"
        GridColumnDescriptor7.MappingName = "IdConcepto"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 50
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "DescripcionCorta"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 108
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "DescripcionLarga"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 243
        Me.dgvConceptos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.dgvConceptos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvConceptos.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvConceptos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IdConcepto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DescripcionCorta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DescripcionLarga")})
        Me.dgvConceptos.Text = "GridGroupingControl2"
        Me.dgvConceptos.VersionInfo = "12.4400.0.24"
        '
        'txtBuscar
        '
        Me.txtBuscar.BeforeTouchSize = New System.Drawing.Size(258, 22)
        Me.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBuscar.Location = New System.Drawing.Point(30, 389)
        Me.txtBuscar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(258, 22)
        Me.txtBuscar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBuscar.TabIndex = 407
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 31)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(294, 380)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 31)
        Me.ButtonAdv1.TabIndex = 406
        Me.ButtonAdv1.Text = "Seleccionar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(65, 31)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(370, 380)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(65, 31)
        Me.ButtonAdv2.TabIndex = 408
        Me.ButtonAdv2.Text = "Salir"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'frmConceptoslocVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(447, 416)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.dgvConceptos)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConceptoslocVariable"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboTipoConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvConceptos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Label1 As Label
    Friend WithEvents cboTipoConcepto As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtBuscar As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
End Class

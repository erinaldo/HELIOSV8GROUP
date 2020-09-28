<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCModulos
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgPermisos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.txtRol = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtRol)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(395, 48)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgPermisos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 238)
        Me.Panel2.TabIndex = 1
        '
        'dgPermisos
        '
        Me.dgPermisos.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgPermisos.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgPermisos.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgPermisos.BackColor = System.Drawing.SystemColors.Window
        Me.dgPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPermisos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgPermisos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgPermisos.Location = New System.Drawing.Point(0, 0)
        Me.dgPermisos.Name = "dgPermisos"
        Me.dgPermisos.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgPermisos.Size = New System.Drawing.Size(395, 238)
        Me.dgPermisos.TabIndex = 411
        Me.dgPermisos.TableDescriptor.AllowNew = False
        Me.dgPermisos.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgPermisos.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgPermisos.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPermisos.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPermisos.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgPermisos.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPermisos.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPermisos.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPermisos.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPermisos.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgPermisos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgPermisos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgPermisos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgPermisos.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.MappingName = "IDAsegurable"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.MappingName = "Nombre"
        GridColumnDescriptor2.Width = 180
        GridColumnDescriptor3.MappingName = "Descripcion"
        GridColumnDescriptor3.Width = 180
        Me.dgPermisos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgPermisos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgPermisos.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgPermisos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IDAsegurable"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Nombre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Descripcion")})
        Me.dgPermisos.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgPermisos.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgPermisos.Text = "GridGroupingControl2"
        Me.dgPermisos.UseRightToLeftCompatibleTextBox = True
        Me.dgPermisos.VersionInfo = "12.4400.0.24"
        '
        'txtRol
        '
        Me.txtRol.BackColor = System.Drawing.Color.White
        Me.txtRol.BeforeTouchSize = New System.Drawing.Size(187, 20)
        Me.txtRol.BorderColor = System.Drawing.Color.Silver
        Me.txtRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRol.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRol.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRol.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRol.Location = New System.Drawing.Point(68, 10)
        Me.txtRol.MaxLength = 50
        Me.txtRol.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtRol.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRol.Name = "txtRol"
        Me.txtRol.ReadOnly = True
        Me.txtRol.Size = New System.Drawing.Size(187, 20)
        Me.txtRol.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Buscar:"
        '
        'UCModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCModulos"
        Me.Size = New System.Drawing.Size(395, 286)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgPermisos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgPermisos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents txtRol As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
End Class

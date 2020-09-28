Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPersonalSinResponsable
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.lblidResponsable = New System.Windows.Forms.Label()
        Me.dgPerfilesUsuario = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCargo = New System.Windows.Forms.Label()
        Me.lblidCargo = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgPerfilesUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(491, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Jefe Responsable"
        '
        'lblResponsable
        '
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResponsable.ForeColor = System.Drawing.Color.Black
        Me.lblResponsable.Location = New System.Drawing.Point(491, 107)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(16, 21)
        Me.lblResponsable.TabIndex = 4
        Me.lblResponsable.Text = "-"
        '
        'lblidResponsable
        '
        Me.lblidResponsable.AutoSize = True
        Me.lblidResponsable.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidResponsable.ForeColor = System.Drawing.Color.Black
        Me.lblidResponsable.Location = New System.Drawing.Point(504, 150)
        Me.lblidResponsable.Name = "lblidResponsable"
        Me.lblidResponsable.Size = New System.Drawing.Size(19, 21)
        Me.lblidResponsable.TabIndex = 5
        Me.lblidResponsable.Text = "0"
        '
        'dgPerfilesUsuario
        '
        Me.dgPerfilesUsuario.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgPerfilesUsuario.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgPerfilesUsuario.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgPerfilesUsuario.BackColor = System.Drawing.SystemColors.Window
        Me.dgPerfilesUsuario.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgPerfilesUsuario.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgPerfilesUsuario.Location = New System.Drawing.Point(0, 41)
        Me.dgPerfilesUsuario.Name = "dgPerfilesUsuario"
        Me.dgPerfilesUsuario.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgPerfilesUsuario.Size = New System.Drawing.Size(365, 403)
        Me.dgPerfilesUsuario.TabIndex = 410
        Me.dgPerfilesUsuario.TableDescriptor.AllowNew = False
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.MappingName = "IDUsuario"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "Dni"
        GridColumnDescriptor2.MappingName = "Dni"
        GridColumnDescriptor2.Width = 90
        GridColumnDescriptor3.HeaderText = "Nombre "
        GridColumnDescriptor3.MappingName = "Nombre"
        GridColumnDescriptor3.Width = 250
        Me.dgPerfilesUsuario.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgPerfilesUsuario.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgPerfilesUsuario.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgPerfilesUsuario.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IDUsuario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Dni"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Nombre")})
        Me.dgPerfilesUsuario.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgPerfilesUsuario.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgPerfilesUsuario.Text = "GridGroupingControl2"
        Me.dgPerfilesUsuario.UseRightToLeftCompatibleTextBox = True
        Me.dgPerfilesUsuario.VersionInfo = "12.4400.0.24"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 21)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Cargo:"
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = True
        Me.lblCargo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargo.ForeColor = System.Drawing.Color.Black
        Me.lblCargo.Location = New System.Drawing.Point(77, 10)
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(16, 21)
        Me.lblCargo.TabIndex = 412
        Me.lblCargo.Text = "-"
        '
        'lblidCargo
        '
        Me.lblidCargo.AutoSize = True
        Me.lblidCargo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidCargo.ForeColor = System.Drawing.Color.Black
        Me.lblidCargo.Location = New System.Drawing.Point(566, 150)
        Me.lblidCargo.Name = "lblidCargo"
        Me.lblidCargo.Size = New System.Drawing.Size(19, 21)
        Me.lblidCargo.TabIndex = 413
        Me.lblidCargo.Text = "0"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(300, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 23)
        Me.Button1.TabIndex = 414
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FormPersonalSinResponsable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.CaptionBarColor = System.Drawing.SystemColors.MenuHighlight
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(450, 24)
        CaptionLabel1.Text = "Personal Sin Responsable"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(365, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblidCargo)
        Me.Controls.Add(Me.lblCargo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgPerfilesUsuario)
        Me.Controls.Add(Me.lblidResponsable)
        Me.Controls.Add(Me.lblResponsable)
        Me.Controls.Add(Me.Label3)
        Me.Name = "FormPersonalSinResponsable"
        Me.ShowIcon = False
        CType(Me.dgPerfilesUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents lblResponsable As Label
    Friend WithEvents lblidResponsable As Label
    Friend WithEvents dgPerfilesUsuario As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCargo As Label
    Friend WithEvents lblidCargo As Label
    Friend WithEvents Button1 As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCCajaEnActividad
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.DgvOpenBox = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ButtonAdv8 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.DgvOpenBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvOpenBox
        '
        Me.DgvOpenBox.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.DgvOpenBox.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.DgvOpenBox.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.DgvOpenBox.BackColor = System.Drawing.Color.Black
        Me.DgvOpenBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvOpenBox.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvOpenBox.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DgvOpenBox.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.DgvOpenBox.Location = New System.Drawing.Point(13, 39)
        Me.DgvOpenBox.Name = "DgvOpenBox"
        Me.DgvOpenBox.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DgvOpenBox.Size = New System.Drawing.Size(852, 344)
        Me.DgvOpenBox.TabIndex = 716
        Me.DgvOpenBox.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "idUser"
        GridColumnDescriptor1.MappingName = "idUser"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "USUARIO"
        GridColumnDescriptor2.MappingName = "User"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 180
        GridColumnDescriptor3.MappingName = "idBox"
        GridColumnDescriptor3.Width = 0
        GridColumnDescriptor4.HeaderText = "MAQUINA"
        GridColumnDescriptor4.MappingName = "namePc"
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderText = "FECHA"
        GridColumnDescriptor5.MappingName = "date"
        GridColumnDescriptor5.Width = 100
        GridColumnDescriptor6.HeaderText = "MONTO SOLES"
        GridColumnDescriptor6.MappingName = "importe"
        GridColumnDescriptor6.Width = 90
        GridColumnDescriptor7.HeaderText = "MONTO DOLARES"
        GridColumnDescriptor7.MappingName = "importeme"
        GridColumnDescriptor7.Width = 90
        Me.DgvOpenBox.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.DgvOpenBox.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.DgvOpenBox.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DgvOpenBox.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DgvOpenBox.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idUser"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("User"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idBox"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("namePc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("date"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeme")})
        Me.DgvOpenBox.Text = "gridGroupingControl1"
        Me.DgvOpenBox.UseRightToLeftCompatibleTextBox = True
        Me.DgvOpenBox.VersionInfo = "12.2400.0.20"
        '
        'ButtonAdv8
        '
        Me.ButtonAdv8.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv8.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ButtonAdv8.BeforeTouchSize = New System.Drawing.Size(108, 28)
        Me.ButtonAdv8.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv8.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv8.IsBackStageButton = False
        Me.ButtonAdv8.Location = New System.Drawing.Point(13, 5)
        Me.ButtonAdv8.MetroColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ButtonAdv8.Name = "ButtonAdv8"
        Me.ButtonAdv8.Size = New System.Drawing.Size(108, 28)
        Me.ButtonAdv8.TabIndex = 717
        Me.ButtonAdv8.Text = "Actualizar"
        Me.ButtonAdv8.UseVisualStyle = True
        '
        'UCCajaEnActividad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.ButtonAdv8)
        Me.Controls.Add(Me.DgvOpenBox)
        Me.Name = "UCCajaEnActividad"
        Me.Size = New System.Drawing.Size(877, 397)
        CType(Me.DgvOpenBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents DgvOpenBox As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv8 As Syncfusion.Windows.Forms.ButtonAdv
End Class

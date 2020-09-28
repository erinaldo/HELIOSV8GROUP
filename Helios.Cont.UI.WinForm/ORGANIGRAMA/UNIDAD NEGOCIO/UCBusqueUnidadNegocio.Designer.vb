<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCBusqueUnidadNegocio
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.dgUnidaNegocio = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel2.SuspendLayout()
        CType(Me.dgUnidaNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 252)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(714, 38)
        Me.Panel2.TabIndex = 529
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(17, 6)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 414
        Me.btnOK.Text = "Ocultar"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'dgUnidaNegocio
        '
        Me.dgUnidaNegocio.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgUnidaNegocio.BackColor = System.Drawing.Color.White
        Me.dgUnidaNegocio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgUnidaNegocio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgUnidaNegocio.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgUnidaNegocio.GridLineColor = System.Drawing.SystemColors.HotTrack
        Me.dgUnidaNegocio.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgUnidaNegocio.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgUnidaNegocio.Location = New System.Drawing.Point(0, 0)
        Me.dgUnidaNegocio.Name = "dgUnidaNegocio"
        Me.dgUnidaNegocio.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgUnidaNegocio.Size = New System.Drawing.Size(714, 252)
        Me.dgUnidaNegocio.TabIndex = 530
        Me.dgUnidaNegocio.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "descripcion"
        GridColumnDescriptor1.Width = 400
        Me.dgUnidaNegocio.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("idOrganigrama"), GridColumnDescriptor1, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("idPadre")})
        Me.dgUnidaNegocio.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgUnidaNegocio.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgUnidaNegocio.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idOrganigrama"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idPadre")})
        Me.dgUnidaNegocio.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgUnidaNegocio.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgUnidaNegocio.Text = "gridGroupingControl1"
        Me.dgUnidaNegocio.TopLevelGroupOptions.ShowCaption = False
        Me.dgUnidaNegocio.UseRightToLeftCompatibleTextBox = True
        Me.dgUnidaNegocio.VersionInfo = "12.2400.0.20"
        '
        'UCBusqueUnidadNegocio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgUnidaNegocio)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "UCBusqueUnidadNegocio"
        Me.Size = New System.Drawing.Size(714, 290)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgUnidaNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnOK As Button
    Public WithEvents dgUnidaNegocio As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

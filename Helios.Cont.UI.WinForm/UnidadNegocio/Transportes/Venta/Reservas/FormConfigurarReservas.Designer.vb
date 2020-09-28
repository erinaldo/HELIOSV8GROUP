<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfigurarReservas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfigurarReservas))
        Me.pnBuscardor = New System.Windows.Forms.Panel()
        Me.GridEncomiendas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.btnReserva = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.cboRutas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEdad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnBuscardor.SuspendLayout()
        CType(Me.GridEncomiendas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnBuscardor
        '
        Me.pnBuscardor.BackColor = System.Drawing.Color.White
        Me.pnBuscardor.Controls.Add(Me.GridEncomiendas)
        Me.pnBuscardor.Controls.Add(Me.btnReserva)
        Me.pnBuscardor.Controls.Add(Me.cboRutas)
        Me.pnBuscardor.Controls.Add(Me.Label14)
        Me.pnBuscardor.Controls.Add(Me.txtEdad)
        Me.pnBuscardor.Controls.Add(Me.Label5)
        Me.pnBuscardor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBuscardor.Location = New System.Drawing.Point(0, 0)
        Me.pnBuscardor.Name = "pnBuscardor"
        Me.pnBuscardor.Size = New System.Drawing.Size(706, 414)
        Me.pnBuscardor.TabIndex = 692
        Me.pnBuscardor.Visible = False
        '
        'GridEncomiendas
        '
        Me.GridEncomiendas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.GridEncomiendas.BackColor = System.Drawing.Color.White
        Me.GridEncomiendas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridEncomiendas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridEncomiendas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEncomiendas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEncomiendas.Location = New System.Drawing.Point(0, 96)
        Me.GridEncomiendas.Name = "GridEncomiendas"
        Me.GridEncomiendas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridEncomiendas.ShowGroupDropArea = True
        Me.GridEncomiendas.Size = New System.Drawing.Size(706, 318)
        Me.GridEncomiendas.TabIndex = 697
        Me.GridEncomiendas.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.MappingName = "Agencia"
        GridColumnDescriptor2.Name = "Agencia"
        GridColumnDescriptor2.Width = 150
        GridColumnDescriptor3.MappingName = "Descripcion"
        GridColumnDescriptor3.Name = "Descripcion"
        GridColumnDescriptor3.Width = 100
        GridColumnDescriptor4.MappingName = "Color"
        GridColumnDescriptor4.Name = "Color"
        GridColumnDescriptor4.Width = 80
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor5.MappingName = "eliminar"
        GridColumnDescriptor5.Name = "eliminar"
        GridColumnDescriptor5.Width = 100
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor6.MappingName = "editar"
        GridColumnDescriptor6.Name = "editar"
        GridColumnDescriptor6.Width = 100
        Me.GridEncomiendas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
        Me.GridEncomiendas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEncomiendas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridEncomiendas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Agencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Color"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("eliminar"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("editar")})
        Me.GridEncomiendas.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridEncomiendas.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridEncomiendas.Text = "GridGroupingControl1"
        Me.GridEncomiendas.UseRightToLeftCompatibleTextBox = True
        Me.GridEncomiendas.VersionInfo = "12.4400.0.24"
        '
        'btnReserva
        '
        Me.btnReserva.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnReserva.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnReserva.BeforeTouchSize = New System.Drawing.Size(153, 32)
        Me.btnReserva.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.btnReserva.ForeColor = System.Drawing.Color.White
        Me.btnReserva.IsBackStageButton = False
        Me.btnReserva.Location = New System.Drawing.Point(540, 41)
        Me.btnReserva.Name = "btnReserva"
        Me.btnReserva.Size = New System.Drawing.Size(153, 32)
        Me.btnReserva.TabIndex = 696
        Me.btnReserva.Text = "Agregar"
        Me.btnReserva.UseVisualStyle = True
        Me.btnReserva.Visible = False
        '
        'cboRutas
        '
        Me.cboRutas.BackColor = System.Drawing.Color.White
        Me.cboRutas.BeforeTouchSize = New System.Drawing.Size(273, 27)
        Me.cboRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRutas.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cboRutas.Location = New System.Drawing.Point(261, 46)
        Me.cboRutas.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboRutas.Name = "cboRutas"
        Me.cboRutas.Size = New System.Drawing.Size(273, 27)
        Me.cboRutas.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboRutas.TabIndex = 692
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(257, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 19)
        Me.Label14.TabIndex = 691
        Me.Label14.Text = "Imagen"
        '
        'txtEdad
        '
        Me.txtEdad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEdad.BeforeTouchSize = New System.Drawing.Size(212, 27)
        Me.txtEdad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEdad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEdad.CornerRadius = 3
        Me.txtEdad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtEdad.Font = New System.Drawing.Font("Calibri Light", 12.0!)
        Me.txtEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEdad.Location = New System.Drawing.Point(23, 49)
        Me.txtEdad.MaxLength = 8
        Me.txtEdad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtEdad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.NearImage = CType(resources.GetObject("txtEdad.NearImage"), System.Drawing.Image)
        Me.txtEdad.Size = New System.Drawing.Size(212, 27)
        Me.txtEdad.TabIndex = 690
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(25, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 14)
        Me.Label5.TabIndex = 689
        Me.Label5.Text = "Descipción (Maximo 3 caracteres)"
        '
        'FormConfigurarReservas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 414)
        Me.Controls.Add(Me.pnBuscardor)
        Me.Name = "FormConfigurarReservas"
        Me.Text = "Configurar Reserva"
        Me.pnBuscardor.ResumeLayout(False)
        Me.pnBuscardor.PerformLayout()
        CType(Me.GridEncomiendas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRutas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnBuscardor As Panel
    Friend WithEvents txtEdad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents cboRutas As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label14 As Label
    Friend WithEvents btnReserva As RoundButton2
    Friend WithEvents GridEncomiendas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

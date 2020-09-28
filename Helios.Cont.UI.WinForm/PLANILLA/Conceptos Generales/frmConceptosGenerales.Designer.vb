<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptosGenerales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConceptosGenerales))
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboTipoPlanilla = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lsvConceptos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgConcepto = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.cboTipoPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.dgConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.cboTipoPlanilla)
        Me.GradientPanel1.Controls.Add(Me.Label11)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel8)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel5)
        Me.GradientPanel1.Controls.Add(Me.GradientPanel6)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(814, 76)
        Me.GradientPanel1.TabIndex = 446
        '
        'cboTipoPlanilla
        '
        Me.cboTipoPlanilla.BackColor = System.Drawing.Color.White
        Me.cboTipoPlanilla.BeforeTouchSize = New System.Drawing.Size(247, 21)
        Me.cboTipoPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPlanilla.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPlanilla.Location = New System.Drawing.Point(22, 40)
        Me.cboTipoPlanilla.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoPlanilla.MetroColor = System.Drawing.Color.Silver
        Me.cboTipoPlanilla.Name = "cboTipoPlanilla"
        Me.cboTipoPlanilla.Size = New System.Drawing.Size(247, 21)
        Me.cboTipoPlanilla.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoPlanilla.TabIndex = 452
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(19, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 451
        Me.Label11.Text = "TIPO PLANILLA"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel8.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel8.Location = New System.Drawing.Point(287, 26)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(88, 35)
        Me.GradientPanel8.TabIndex = 449
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(88, 35)
        Me.ButtonAdv2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(88, 35)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "Refresh"
        Me.ButtonAdv2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel5.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel5.Location = New System.Drawing.Point(453, 25)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(73, 36)
        Me.GradientPanel5.TabIndex = 447
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(73, 36)
        Me.ButtonAdv6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(73, 36)
        Me.ButtonAdv6.TabIndex = 1
        Me.ButtonAdv6.Text = "Editar"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel6.Controls.Add(Me.ButtonAdv5)
        Me.GradientPanel6.Location = New System.Drawing.Point(377, 25)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(75, 36)
        Me.GradientPanel6.TabIndex = 446
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(75, 36)
        Me.ButtonAdv5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonAdv5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.Image = CType(resources.GetObject("ButtonAdv5.Image"), System.Drawing.Image)
        Me.ButtonAdv5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(75, 36)
        Me.ButtonAdv5.TabIndex = 1
        Me.ButtonAdv5.Text = "Nuevo"
        Me.ButtonAdv5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'lsvConceptos
        '
        Me.lsvConceptos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lsvConceptos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvConceptos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lsvConceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvConceptos.FullRowSelect = True
        Me.lsvConceptos.HideSelection = False
        Me.lsvConceptos.HoverSelection = True
        Me.lsvConceptos.Location = New System.Drawing.Point(0, 76)
        Me.lsvConceptos.Name = "lsvConceptos"
        Me.lsvConceptos.Size = New System.Drawing.Size(814, 209)
        Me.lsvConceptos.TabIndex = 447
        Me.lsvConceptos.UseCompatibleStateImageBehavior = False
        Me.lsvConceptos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ID Sunat"
        Me.ColumnHeader2.Width = 77
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Concepto"
        Me.ColumnHeader3.Width = 297
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 285)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(814, 224)
        Me.Panel1.TabIndex = 448
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GradientPanel2.BorderSides = CType((System.Windows.Forms.Border3DSide.Top Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.dgConcepto)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(814, 224)
        Me.GradientPanel2.TabIndex = 447
        '
        'dgConcepto
        '
        Me.dgConcepto.BackColor = System.Drawing.SystemColors.Window
        Me.dgConcepto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgConcepto.FreezeCaption = False
        Me.dgConcepto.Location = New System.Drawing.Point(0, 0)
        Me.dgConcepto.Name = "dgConcepto"
        Me.dgConcepto.Size = New System.Drawing.Size(812, 222)
        Me.dgConcepto.TabIndex = 1
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "ID"
        GridColumnDescriptor9.MappingName = "IDConcepto"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 50
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.MappingName = "Orden"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 50
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Código formula"
        GridColumnDescriptor11.MappingName = "DescripcionCorta"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 144
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Descripción"
        GridColumnDescriptor12.MappingName = "DescripcionLarga"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 218
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "ID Sunat"
        GridColumnDescriptor13.MappingName = "IDSunat"
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "Tipo"
        GridColumnDescriptor14.MappingName = "TipoCalculo"
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "Valor"
        GridColumnDescriptor15.MappingName = "ValorCalculo"
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor16.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor16.Appearance.AnyRecordFieldCell.CheckBoxOptions.IndetermValue = "False"
        GridColumnDescriptor16.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.MappingName = "Activo"
        GridColumnDescriptor16.SerializedImageArray = ""
        Me.dgConcepto.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16})
        Me.dgConcepto.Text = "GridGroupingControl1"
        Me.dgConcepto.VersionInfo = "12.4400.0.24"
        '
        'frmConceptosGenerales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 25
        Me.CaptionFont = New System.Drawing.Font("Ebrima", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(814, 509)
        Me.Controls.Add(Me.lsvConceptos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConceptosGenerales"
        Me.ShowIcon = False
        Me.Text = "Conceptos generales"
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.cboTipoPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.dgConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents cboTipoPlanilla As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel6 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lsvConceptos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents dgConcepto As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

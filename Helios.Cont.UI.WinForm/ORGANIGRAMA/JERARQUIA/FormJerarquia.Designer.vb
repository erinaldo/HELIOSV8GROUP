Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormJerarquia
    Inherits MetroForm


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
        Me.DGJerarquia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblUninegoc = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnActividad = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnElmi = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnNuevo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.DGJerarquia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGJerarquia
        '
        Me.DGJerarquia.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DGJerarquia.BackColor = System.Drawing.Color.White
        Me.DGJerarquia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGJerarquia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGJerarquia.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGJerarquia.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DGJerarquia.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.DGJerarquia.Location = New System.Drawing.Point(0, 0)
        Me.DGJerarquia.Name = "DGJerarquia"
        Me.DGJerarquia.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DGJerarquia.Size = New System.Drawing.Size(500, 204)
        Me.DGJerarquia.TabIndex = 840
        Me.DGJerarquia.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "idCentroCosto"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor2.MappingName = "nivel"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor3.MappingName = "descripcion"
        GridColumnDescriptor3.Width = 200
        Me.DGJerarquia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("Estado")})
        Me.DGJerarquia.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DGJerarquia.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DGJerarquia.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nivel"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion")})
        Me.DGJerarquia.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DGJerarquia.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.DGJerarquia.Text = "gridGroupingControl1"
        Me.DGJerarquia.TopLevelGroupOptions.ShowCaption = False
        Me.DGJerarquia.UseRightToLeftCompatibleTextBox = True
        Me.DGJerarquia.VersionInfo = "12.2400.0.20"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'lblUninegoc
        '
        Me.lblUninegoc.AutoSize = True
        Me.lblUninegoc.Font = New System.Drawing.Font("Book Antiqua", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUninegoc.ForeColor = System.Drawing.Color.Silver
        Me.lblUninegoc.Location = New System.Drawing.Point(155, 12)
        Me.lblUninegoc.Name = "lblUninegoc"
        Me.lblUninegoc.Size = New System.Drawing.Size(13, 19)
        Me.lblUninegoc.TabIndex = 892
        Me.lblUninegoc.Text = "."
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.lblUninegoc)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(502, 54)
        Me.GradientPanel1.TabIndex = 901
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.btnActividad)
        Me.GradientPanel2.Controls.Add(Me.btnElmi)
        Me.GradientPanel2.Controls.Add(Me.btnNuevo)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 54)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(502, 41)
        Me.GradientPanel2.TabIndex = 902
        '
        'btnActividad
        '
        Me.btnActividad.Activecolor = System.Drawing.Color.Green
        Me.btnActividad.BackColor = System.Drawing.Color.Green
        Me.btnActividad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnActividad.BorderRadius = 5
        Me.btnActividad.ButtonText = "GUARDAR"
        Me.btnActividad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActividad.DisabledColor = System.Drawing.Color.Gray
        Me.btnActividad.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActividad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnActividad.Iconcolor = System.Drawing.Color.Transparent
        Me.btnActividad.Iconimage = Nothing
        Me.btnActividad.Iconimage_right = Nothing
        Me.btnActividad.Iconimage_right_Selected = Nothing
        Me.btnActividad.Iconimage_Selected = Nothing
        Me.btnActividad.IconMarginLeft = 0
        Me.btnActividad.IconMarginRight = 0
        Me.btnActividad.IconRightVisible = True
        Me.btnActividad.IconRightZoom = 0R
        Me.btnActividad.IconVisible = True
        Me.btnActividad.IconZoom = 90.0R
        Me.btnActividad.IsTab = False
        Me.btnActividad.Location = New System.Drawing.Point(214, 6)
        Me.btnActividad.Margin = New System.Windows.Forms.Padding(2)
        Me.btnActividad.Name = "btnActividad"
        Me.btnActividad.Normalcolor = System.Drawing.Color.Green
        Me.btnActividad.OnHovercolor = System.Drawing.Color.Green
        Me.btnActividad.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnActividad.selected = False
        Me.btnActividad.Size = New System.Drawing.Size(98, 22)
        Me.btnActividad.TabIndex = 949
        Me.btnActividad.Text = "GUARDAR"
        Me.btnActividad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnActividad.Textcolor = System.Drawing.Color.White
        Me.btnActividad.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnElmi
        '
        Me.btnElmi.Activecolor = System.Drawing.Color.Red
        Me.btnElmi.BackColor = System.Drawing.Color.Red
        Me.btnElmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnElmi.BorderRadius = 5
        Me.btnElmi.ButtonText = "ELIMINAR"
        Me.btnElmi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnElmi.DisabledColor = System.Drawing.Color.Gray
        Me.btnElmi.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnElmi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnElmi.Iconcolor = System.Drawing.Color.Transparent
        Me.btnElmi.Iconimage = Nothing
        Me.btnElmi.Iconimage_right = Nothing
        Me.btnElmi.Iconimage_right_Selected = Nothing
        Me.btnElmi.Iconimage_Selected = Nothing
        Me.btnElmi.IconMarginLeft = 0
        Me.btnElmi.IconMarginRight = 0
        Me.btnElmi.IconRightVisible = True
        Me.btnElmi.IconRightZoom = 0R
        Me.btnElmi.IconVisible = True
        Me.btnElmi.IconZoom = 90.0R
        Me.btnElmi.IsTab = False
        Me.btnElmi.Location = New System.Drawing.Point(112, 6)
        Me.btnElmi.Margin = New System.Windows.Forms.Padding(2)
        Me.btnElmi.Name = "btnElmi"
        Me.btnElmi.Normalcolor = System.Drawing.Color.Red
        Me.btnElmi.OnHovercolor = System.Drawing.Color.Red
        Me.btnElmi.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnElmi.selected = False
        Me.btnElmi.Size = New System.Drawing.Size(98, 23)
        Me.btnElmi.TabIndex = 948
        Me.btnElmi.Text = "ELIMINAR"
        Me.btnElmi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnElmi.Textcolor = System.Drawing.Color.White
        Me.btnElmi.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnNuevo
        '
        Me.btnNuevo.Activecolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevo.BorderRadius = 5
        Me.btnNuevo.ButtonText = "NUEVO"
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.DisabledColor = System.Drawing.Color.Gray
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnNuevo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnNuevo.Iconimage = Nothing
        Me.btnNuevo.Iconimage_right = Nothing
        Me.btnNuevo.Iconimage_right_Selected = Nothing
        Me.btnNuevo.Iconimage_Selected = Nothing
        Me.btnNuevo.IconMarginLeft = 0
        Me.btnNuevo.IconMarginRight = 0
        Me.btnNuevo.IconRightVisible = True
        Me.btnNuevo.IconRightZoom = 0R
        Me.btnNuevo.IconVisible = True
        Me.btnNuevo.IconZoom = 90.0R
        Me.btnNuevo.IsTab = False
        Me.btnNuevo.Location = New System.Drawing.Point(10, 6)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnNuevo.selected = False
        Me.btnNuevo.Size = New System.Drawing.Size(98, 23)
        Me.btnNuevo.TabIndex = 946
        Me.btnNuevo.Text = "NUEVO"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNuevo.Textcolor = System.Drawing.Color.White
        Me.btnNuevo.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PanelBody.BorderColor = System.Drawing.Color.Gainsboro
        Me.PanelBody.BorderSides = CType((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Right), System.Windows.Forms.Border3DSide)
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBody.Controls.Add(Me.DGJerarquia)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 95)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(502, 206)
        Me.PanelBody.TabIndex = 903
        '
        'FormJerarquia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(502, 301)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "FormJerarquia"
        Me.ShowIcon = False
        Me.Text = " "
        CType(Me.DGJerarquia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents DGJerarquia As Grid.Grouping.GridGroupingControl
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents lblUninegoc As Label
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents btnElmi As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnNuevo As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents PanelBody As Tools.GradientPanel
    Private WithEvents btnActividad As Bunifu.Framework.UI.BunifuFlatButton
End Class

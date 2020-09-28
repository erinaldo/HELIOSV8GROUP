<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCOrganica_Especifica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCOrganica_Especifica))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Line22 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdUO = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtBusqUniOrgaEspeci = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNuevo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.DGUniOrEspecifica = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtIdUO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBusqUniOrgaEspeci, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody.SuspendLayout()
        CType(Me.DGUniOrEspecifica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Line22)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.txtIdUO)
        Me.GradientPanel1.Controls.Add(Me.PictureBox2)
        Me.GradientPanel1.Controls.Add(Me.txtBusqUniOrgaEspeci)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.btnNuevo)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(753, 125)
        Me.GradientPanel1.TabIndex = 904
        '
        'Line22
        '
        Me.Line22.LineColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Line22.Location = New System.Drawing.Point(11, 88)
        Me.Line22.Name = "Line22"
        Me.Line22.Size = New System.Drawing.Size(700, 1)
        Me.Line22.TabIndex = 976
        Me.Line22.Text = "Line22"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(34, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 975
        Me.Label1.Text = "Nro U.O"
        '
        'txtIdUO
        '
        Me.txtIdUO.BackColor = System.Drawing.SystemColors.Info
        Me.txtIdUO.BeforeTouchSize = New System.Drawing.Size(467, 22)
        Me.txtIdUO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtIdUO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdUO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdUO.CornerRadius = 3
        Me.txtIdUO.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIdUO.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdUO.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtIdUO.Location = New System.Drawing.Point(25, 48)
        Me.txtIdUO.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtIdUO.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtIdUO.Name = "txtIdUO"
        Me.txtIdUO.Size = New System.Drawing.Size(66, 23)
        Me.txtIdUO.TabIndex = 974
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(552, 49)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 973
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'txtBusqUniOrgaEspeci
        '
        Me.txtBusqUniOrgaEspeci.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtBusqUniOrgaEspeci.BeforeTouchSize = New System.Drawing.Size(467, 22)
        Me.txtBusqUniOrgaEspeci.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtBusqUniOrgaEspeci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBusqUniOrgaEspeci.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusqUniOrgaEspeci.CornerRadius = 3
        Me.txtBusqUniOrgaEspeci.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBusqUniOrgaEspeci.FarImage = CType(resources.GetObject("txtBusqUniOrgaEspeci.FarImage"), System.Drawing.Image)
        Me.txtBusqUniOrgaEspeci.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtBusqUniOrgaEspeci.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqUniOrgaEspeci.ForeColor = System.Drawing.Color.Black
        Me.txtBusqUniOrgaEspeci.Location = New System.Drawing.Point(108, 49)
        Me.txtBusqUniOrgaEspeci.MaxLength = 400
        Me.txtBusqUniOrgaEspeci.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtBusqUniOrgaEspeci.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBusqUniOrgaEspeci.Name = "txtBusqUniOrgaEspeci"
        Me.txtBusqUniOrgaEspeci.NearImage = CType(resources.GetObject("txtBusqUniOrgaEspeci.NearImage"), System.Drawing.Image)
        Me.txtBusqUniOrgaEspeci.Size = New System.Drawing.Size(467, 22)
        Me.txtBusqUniOrgaEspeci.TabIndex = 971
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(110, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 13)
        Me.Label2.TabIndex = 972
        Me.Label2.Text = "BUSQUEDA  UNIDAD ORGÁNICA"
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
        Me.btnNuevo.Location = New System.Drawing.Point(25, 94)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.btnNuevo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnNuevo.selected = False
        Me.btnNuevo.Size = New System.Drawing.Size(98, 23)
        Me.btnNuevo.TabIndex = 947
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
        Me.PanelBody.Controls.Add(Me.DGUniOrEspecifica)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 125)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(753, 247)
        Me.PanelBody.TabIndex = 906
        '
        'DGUniOrEspecifica
        '
        Me.DGUniOrEspecifica.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DGUniOrEspecifica.BackColor = System.Drawing.Color.White
        Me.DGUniOrEspecifica.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGUniOrEspecifica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGUniOrEspecifica.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGUniOrEspecifica.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DGUniOrEspecifica.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.DGUniOrEspecifica.Location = New System.Drawing.Point(0, 0)
        Me.DGUniOrEspecifica.Name = "DGUniOrEspecifica"
        Me.DGUniOrEspecifica.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DGUniOrEspecifica.Size = New System.Drawing.Size(751, 245)
        Me.DGUniOrEspecifica.TabIndex = 840
        Me.DGUniOrEspecifica.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "descripcion"
        GridColumnDescriptor1.Width = 450
        Me.DGUniOrEspecifica.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("NroOrganizacion"), GridColumnDescriptor1, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("Estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("tipo")})
        Me.DGUniOrEspecifica.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DGUniOrEspecifica.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DGUniOrEspecifica.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroOrganizacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion")})
        Me.DGUniOrEspecifica.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DGUniOrEspecifica.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.DGUniOrEspecifica.Text = "gridGroupingControl1"
        Me.DGUniOrEspecifica.TopLevelGroupOptions.ShowCaption = False
        Me.DGUniOrEspecifica.UseRightToLeftCompatibleTextBox = True
        Me.DGUniOrEspecifica.VersionInfo = "12.2400.0.20"
        '
        'UCOrganica_Especifica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "UCOrganica_Especifica"
        Me.Size = New System.Drawing.Size(753, 372)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtIdUO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBusqUniOrgaEspeci, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody.ResumeLayout(False)
        CType(Me.DGUniOrEspecifica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
    Public WithEvents DGUniOrEspecifica As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtBusqUniOrgaEspeci As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIdUO As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents btnNuevo As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Line22 As Line2
End Class

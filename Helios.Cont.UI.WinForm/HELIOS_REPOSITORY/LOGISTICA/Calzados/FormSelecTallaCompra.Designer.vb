Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSelecTallaCompra
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboGenero = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextDisponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.TabPageAdv2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboGenero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Categoria"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(77, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.Location = New System.Drawing.Point(29, 44)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(226, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextBoxExt1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(262, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Plantilla"
        '
        'ComboGenero
        '
        Me.ComboGenero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboGenero.BeforeTouchSize = New System.Drawing.Size(151, 21)
        Me.ComboGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboGenero.Items.AddRange(New Object() {"MUJER", "VARON"})
        Me.ComboGenero.Location = New System.Drawing.Point(261, 45)
        Me.ComboGenero.Name = "ComboGenero"
        Me.ComboGenero.Size = New System.Drawing.Size(151, 21)
        Me.ComboGenero.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful
        Me.ComboGenero.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Disponible"
        '
        'TextDisponible
        '
        Me.TextDisponible.BeforeTouchSize = New System.Drawing.Size(77, 22)
        Me.TextDisponible.CurrencySymbol = ""
        Me.TextDisponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextDisponible.Location = New System.Drawing.Point(418, 44)
        Me.TextDisponible.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextDisponible.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TextDisponible.Name = "TextDisponible"
        Me.TextDisponible.NullString = ""
        Me.TextDisponible.Size = New System.Drawing.Size(77, 22)
        Me.TextDisponible.TabIndex = 5
        Me.TextDisponible.Text = "0.00"
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridGroupingControl1.Size = New System.Drawing.Size(459, 276)
        Me.GridGroupingControl1.TabIndex = 6
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.UseRightToLeftCompatibleTextBox = True
        Me.GridGroupingControl1.VersionInfo = "16.4460.0.42"
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabFont = New System.Drawing.Font("Yu Gothic UI", 8.25!)
        Me.TabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(466, 304)
        Me.TabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv2)
        Me.TabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Location = New System.Drawing.Point(29, 72)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlAdv1.ShowSeparator = False
        Me.TabControlAdv1.Size = New System.Drawing.Size(466, 304)
        Me.TabControlAdv1.TabIndex = 7
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererOffice2016Colorful)
        Me.TabControlAdv1.ThemesEnabled = True
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.GridGroupingControl1)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(3, 24)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(459, 276)
        Me.TabPageAdv1.TabIndex = 1
        Me.TabPageAdv1.Text = "Varón"
        Me.TabPageAdv1.ThemesEnabled = True
        '
        'TabPageAdv2
        '
        Me.TabPageAdv2.Image = Nothing
        Me.TabPageAdv2.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv2.Location = New System.Drawing.Point(3, 24)
        Me.TabPageAdv2.Name = "TabPageAdv2"
        Me.TabPageAdv2.ShowCloseButton = True
        Me.TabPageAdv2.Size = New System.Drawing.Size(459, 276)
        Me.TabPageAdv2.TabIndex = 2
        Me.TabPageAdv2.Text = "Mujer"
        Me.TabPageAdv2.ThemesEnabled = True
        '
        'FormSelecTallaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 388)
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Controls.Add(Me.TextDisponible)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboGenero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormSelecTallaCompra"
        Me.ShowIcon = False
        Me.Text = "FormSelecTallaCompra"
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboGenero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxExt1 As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboGenero As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents TextDisponible As Tools.CurrencyTextBox
    Friend WithEvents GridGroupingControl1 As Grid.Grouping.GridGroupingControl
    Friend WithEvents TabControlAdv1 As Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Tools.TabPageAdv
    Friend WithEvents TabPageAdv2 As Tools.TabPageAdv
End Class

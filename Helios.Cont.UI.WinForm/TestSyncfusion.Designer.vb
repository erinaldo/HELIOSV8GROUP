<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestSyncfusion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TestSyncfusion))
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.StatusBarAdv1 = New Syncfusion.Windows.Forms.Tools.StatusBarAdv()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.PivotGridControl1 = New Syncfusion.Windows.Forms.PivotAnalysis.PivotGridControl(Me.components)
        Me.TabbedMDIManager1 = New Syncfusion.Windows.Forms.Tools.TabbedMDIManager(Me.components)
        Me.DigitalGauge1 = New Syncfusion.Windows.Forms.Gauge.DigitalGauge()
        Me.Model1 = New Syncfusion.Windows.Forms.Diagram.Model(Me.components)
        CType(Me.StatusBarAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Model1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(35, 98)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAdv1.TabIndex = 0
        Me.ButtonAdv1.Text = "ButtonAdv1"
        '
        'StatusBarAdv1
        '
        Me.StatusBarAdv1.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.StatusBarAdv1.CustomLayoutBounds = New System.Drawing.Rectangle(0, 0, 0, 0)
        Me.StatusBarAdv1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusBarAdv1.Location = New System.Drawing.Point(0, 239)
        Me.StatusBarAdv1.Name = "StatusBarAdv1"
        Me.StatusBarAdv1.Padding = New System.Windows.Forms.Padding(3)
        Me.StatusBarAdv1.Size = New System.Drawing.Size(284, 22)
        Me.StatusBarAdv1.Spacing = New System.Drawing.Size(2, 2)
        Me.StatusBarAdv1.TabIndex = 1
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(200, 100)
        Me.TabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Location = New System.Drawing.Point(23, 133)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlAdv1.ShowSeparator = False
        Me.TabControlAdv1.Size = New System.Drawing.Size(200, 100)
        Me.TabControlAdv1.TabIndex = 2
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PivotGridControl1.EditManager = Nothing
        Me.PivotGridControl1.Location = New System.Drawing.Point(147, 20)
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.Size = New System.Drawing.Size(75, 23)
        Me.PivotGridControl1.TabIndex = 4
        Me.PivotGridControl1.Text = "PivotGridControl1"
        Me.PivotGridControl1.UpdateManager = Nothing
        '
        'TabbedMDIManager1
        '
        Me.TabbedMDIManager1.AttachedTo = Me
        Me.TabbedMDIManager1.CloseButtonBackColor = System.Drawing.Color.White
        Me.TabbedMDIManager1.CloseButtonToolTip = ""
        Me.TabbedMDIManager1.DropDownButtonToolTip = ""
        Me.TabbedMDIManager1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabbedMDIManager1.NeedUpdateHostedForm = False
        '
        'DigitalGauge1
        '
        Me.DigitalGauge1.DisplayRecordIndex = 0
        Me.DigitalGauge1.Location = New System.Drawing.Point(42, 2)
        Me.DigitalGauge1.MaximumSize = New System.Drawing.Size(500, 180)
        Me.DigitalGauge1.MinimumSize = New System.Drawing.Size(90, 90)
        Me.DigitalGauge1.Name = "DigitalGauge1"
        Me.DigitalGauge1.Size = New System.Drawing.Size(180, 90)
        Me.DigitalGauge1.TabIndex = 6
        '
        'Model1
        '
        Me.Model1.DocumentScale.DisplayName = "No Scale"
        Me.Model1.DocumentScale.Height = 1.0!
        Me.Model1.DocumentScale.Width = 1.0!
        Me.Model1.DocumentSize.Height = 1169.0!
        Me.Model1.DocumentSize.Width = 827.0!
        Me.Model1.LineStyle.DashPattern = Nothing
        Me.Model1.LineStyle.LineColor = System.Drawing.Color.Black
        Me.Model1.LogicalSize = New System.Drawing.SizeF(827.0!, 1169.0!)
        Me.Model1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.Model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.Model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        '
        'TestSyncfusion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.DigitalGauge1)
        Me.Controls.Add(Me.PivotGridControl1)
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Controls.Add(Me.StatusBarAdv1)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.IsMdiContainer = True
        Me.Name = "TestSyncfusion"
        Me.Text = "TestSyncfusion"
        CType(Me.StatusBarAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Model1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents StatusBarAdv1 As Syncfusion.Windows.Forms.Tools.StatusBarAdv
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents PivotGridControl1 As Syncfusion.Windows.Forms.PivotAnalysis.PivotGridControl
    Friend WithEvents TabbedMDIManager1 As Syncfusion.Windows.Forms.Tools.TabbedMDIManager
    Friend WithEvents DigitalGauge1 As Syncfusion.Windows.Forms.Gauge.DigitalGauge
    Friend WithEvents Model1 As Syncfusion.Windows.Forms.Diagram.Model
End Class

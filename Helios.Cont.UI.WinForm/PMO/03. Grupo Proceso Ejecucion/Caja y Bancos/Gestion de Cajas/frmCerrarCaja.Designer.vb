<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCerrarCaja
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCerrarCaja))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonApplicationButton2 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.GridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'QRibbonApplicationButton2
        '
        Me.QRibbonApplicationButton2.Checked = True
        Me.QRibbonApplicationButton2.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 11, -10, -9)
        Me.QRibbonApplicationButton2.ForegroundImage = CType(resources.GetObject("QRibbonApplicationButton2.ForegroundImage"), System.Drawing.Image)
        '
        'GridGroupingControl1
        '
        Me.GridGroupingControl1.BackColor = System.Drawing.SystemColors.Window
        Me.GridGroupingControl1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridGroupingControl1.FreezeCaption = False
        Me.GridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.GridGroupingControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridGroupingControl1.Name = "GridGroupingControl1"
        Me.GridGroupingControl1.Size = New System.Drawing.Size(392, 216)
        Me.GridGroupingControl1.TabIndex = 0
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Usuario de caja"
        GridColumnDescriptor1.MappingName = "Usuario"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 190
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Ingresos MN"
        GridColumnDescriptor2.MappingName = "IngresosMN"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 90
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Ingresos ME"
        GridColumnDescriptor3.MappingName = "IngresosME"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 90
        Me.GridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.GridGroupingControl1.Text = "GridGroupingControl1"
        Me.GridGroupingControl1.VersionInfo = "12.4400.0.24"
        '
        'frmCerrarCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(392, 216)
        Me.Controls.Add(Me.GridGroupingControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCerrarCaja"
        Me.ShowIcon = False
        Me.Text = "Transacciones"
        CType(Me.GridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonApplicationButton2 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents GridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

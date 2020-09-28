<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventarioReportes
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventarioReportes))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.TabPageAdv2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        Me.TabPageAdv2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("TeamViewer10", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Image = CType(resources.GetObject("Label2.Image"), System.Drawing.Image)
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(1, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 35)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Reportes de inventario"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(707, 258)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv2)
        Me.TabControlAdv1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControlAdv1.EnableTouchMode = True
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.InactiveTabColor = System.Drawing.Color.White
        Me.TabControlAdv1.ItemSize = New System.Drawing.Size(118, 33)
        Me.TabControlAdv1.Location = New System.Drawing.Point(0, 57)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.Size = New System.Drawing.Size(652, 318)
        Me.TabControlAdv1.TabIndex = 293
        Me.TabControlAdv1.TabPanelBackColor = System.Drawing.Color.White
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererMetro)
        Me.TabControlAdv1.ThemesEnabled = True
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.LinkLabel6)
        Me.TabPageAdv1.Controls.Add(Me.LinkLabel5)
        Me.TabPageAdv1.Controls.Add(Me.LinkLabel4)
        Me.TabPageAdv1.Controls.Add(Me.LinkLabel3)
        Me.TabPageAdv1.Controls.Add(Me.LinkLabel2)
        Me.TabPageAdv1.Controls.Add(Me.LinkLabel1)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(3, 35)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(645, 279)
        Me.TabPageAdv1.TabIndex = 1
        Me.TabPageAdv1.Text = "Acumulado"
        Me.TabPageAdv1.ThemesEnabled = True
        '
        'TabPageAdv2
        '
        Me.TabPageAdv2.Controls.Add(Me.LinkLabel10)
        Me.TabPageAdv2.Controls.Add(Me.LinkLabel9)
        Me.TabPageAdv2.Controls.Add(Me.LinkLabel8)
        Me.TabPageAdv2.Controls.Add(Me.LinkLabel7)
        Me.TabPageAdv2.Image = Nothing
        Me.TabPageAdv2.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv2.Location = New System.Drawing.Point(3, 35)
        Me.TabPageAdv2.Name = "TabPageAdv2"
        Me.TabPageAdv2.ShowCloseButton = True
        Me.TabPageAdv2.Size = New System.Drawing.Size(645, 279)
        Me.TabPageAdv2.TabIndex = 2
        Me.TabPageAdv2.Text = "Productos"
        Me.TabPageAdv2.ThemesEnabled = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(28, 34)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(178, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Reporte kardex valorizado por año."
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(28, 61)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(196, 13)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Reporte kardex valorizado por período."
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(28, 117)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(233, 13)
        Me.LinkLabel3.TabIndex = 2
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Reporte kardex valorizado por rango de fecha."
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(28, 147)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(282, 13)
        Me.LinkLabel4.TabIndex = 3
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Reporte kardex valorizado por clasificación de productos."
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel5.Location = New System.Drawing.Point(28, 174)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(173, 13)
        Me.LinkLabel5.TabIndex = 4
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Listado de productos por Bind card"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel6.Location = New System.Drawing.Point(28, 90)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(174, 13)
        Me.LinkLabel6.TabIndex = 5
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "Reporte kardex valorizado por día."
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel7.Location = New System.Drawing.Point(36, 34)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(150, 13)
        Me.LinkLabel7.TabIndex = 7
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "Reporte ranking de productos"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel8.Location = New System.Drawing.Point(36, 68)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(242, 13)
        Me.LinkLabel8.TabIndex = 8
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "Reporte ranking de productos con mas entradas."
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel9.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel9.Location = New System.Drawing.Point(36, 100)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(231, 13)
        Me.LinkLabel9.TabIndex = 9
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "Reporte ranking de productos con mas sálidas."
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel10.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel10.Location = New System.Drawing.Point(36, 131)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(187, 13)
        Me.LinkLabel10.TabIndex = 10
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "Reporte inventario total por almacén."
        '
        'frmInventarioReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(652, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmInventarioReportes"
        Me.Text = ""
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        Me.TabPageAdv1.PerformLayout()
        Me.TabPageAdv2.ResumeLayout(False)
        Me.TabPageAdv2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents TabPageAdv2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
End Class

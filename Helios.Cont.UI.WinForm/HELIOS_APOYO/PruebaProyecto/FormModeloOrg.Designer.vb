Imports Microsoft.VisualBasic
Imports System
Namespace LinkTextBoxExt
    Partial Public Class FormModeloOrg
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim Binding2 As Syncfusion.Windows.Forms.Diagram.Binding = New Syncfusion.Windows.Forms.Diagram.Binding()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormModeloOrg))
            Me.diagram1 = New Syncfusion.Windows.Forms.Diagram.Controls.Diagram(Me.components)
            Me.model1 = New Syncfusion.Windows.Forms.Diagram.Model(Me.components)
            Me.panel3 = New System.Windows.Forms.Panel()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnNuevo = New Bunifu.Framework.UI.BunifuFlatButton()
            CType(Me.diagram1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.model1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panel3.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'diagram1
            '
            Me.diagram1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Binding2.DefaultConnector = Nothing
            Binding2.DefaultNode = Nothing
            Binding2.Diagram = Me.diagram1
            Binding2.Id = Nothing
            Binding2.Label = CType(resources.GetObject("Binding2.Label"), System.Collections.Generic.List(Of String))
            Binding2.ParentId = Nothing
            Me.diagram1.Binding = Binding2
            Me.diagram1.Controller.Constraint = Syncfusion.Windows.Forms.Diagram.Constraints.PageEditable
            Me.diagram1.Controller.DefaultConnectorTool = Syncfusion.Windows.Forms.Diagram.ConnectorTool.OrgLineConnectorTool
            Me.diagram1.Controller.PasteOffset = New System.Drawing.SizeF(10.0!, 10.0!)
            Me.diagram1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.diagram1.EnableTouchMode = False
            Me.diagram1.HScroll = True
            Me.diagram1.LayoutManager = Nothing
            Me.diagram1.Location = New System.Drawing.Point(0, 48)
            Me.diagram1.MetroScrollBars = True
            Me.diagram1.Model = Me.model1
            Me.diagram1.Name = "diagram1"
            Me.diagram1.ScrollVirtualBounds = CType(resources.GetObject("diagram1.ScrollVirtualBounds"), System.Drawing.RectangleF)
            Me.diagram1.Size = New System.Drawing.Size(1322, 548)
            Me.diagram1.SmartSizeBox = False
            Me.diagram1.TabIndex = 2
            Me.diagram1.Text = "diagram1"
            '
            '
            '
            Me.diagram1.View.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.diagram1.View.ClientRectangle = New System.Drawing.Rectangle(0, 0, 0, 0)
            Me.diagram1.View.Controller = Me.diagram1.Controller
            Me.diagram1.View.Grid.MinPixelSpacing = 4.0!
            Me.diagram1.View.Grid.Visible = False
            Me.diagram1.View.ScrollVirtualBounds = CType(resources.GetObject("resource.ScrollVirtualBounds"), System.Drawing.RectangleF)
            Me.diagram1.View.ZoomType = Syncfusion.Windows.Forms.Diagram.ZoomType.Center
            Me.diagram1.VScroll = True
            '
            'model1
            '
            Me.model1.AlignmentType = AlignmentType.SelectedNode
            Me.model1.BackgroundStyle.PathBrushStyle = Syncfusion.Windows.Forms.Diagram.PathGradientBrushStyle.RectangleCenter
            Me.model1.DocumentScale.DisplayName = "No Scale"
            Me.model1.DocumentScale.Height = 1.0!
            Me.model1.DocumentScale.Width = 1.0!
            Me.model1.DocumentSize.Height = 566.9291!
            Me.model1.DocumentSize.Width = 396.8504!
            Me.model1.LineStyle.DashPattern = Nothing
            Me.model1.LineStyle.LineColor = System.Drawing.Color.Black
            Me.model1.LineStyle.LineWidth = 0!
            Me.model1.LogicalSize = New System.Drawing.SizeF(396.8504!, 566.9291!)
            Me.model1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
            Me.model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.model1.SizeToContent = True
            '
            'panel3
            '
            Me.panel3.Controls.Add(Me.diagram1)
            Me.panel3.Controls.Add(Me.Panel1)
            Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panel3.Location = New System.Drawing.Point(0, 0)
            Me.panel3.Name = "panel3"
            Me.panel3.Size = New System.Drawing.Size(1322, 596)
            Me.panel3.TabIndex = 3
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnNuevo)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1322, 48)
            Me.Panel1.TabIndex = 624
            '
            'btnNuevo
            '
            Me.btnNuevo.Activecolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
            Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
            Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.btnNuevo.BorderRadius = 5
            Me.btnNuevo.ButtonText = "ACTUALIZAR"
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
            Me.btnNuevo.Location = New System.Drawing.Point(11, 11)
            Me.btnNuevo.Margin = New System.Windows.Forms.Padding(2)
            Me.btnNuevo.Name = "btnNuevo"
            Me.btnNuevo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
            Me.btnNuevo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(190, Byte), Integer))
            Me.btnNuevo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
            Me.btnNuevo.selected = False
            Me.btnNuevo.Size = New System.Drawing.Size(120, 23)
            Me.btnNuevo.TabIndex = 956
            Me.btnNuevo.Text = "ACTUALIZAR"
            Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.btnNuevo.Textcolor = System.Drawing.Color.White
            Me.btnNuevo.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '
            'FormModeloOrg
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
            Me.BorderThickness = 2
            Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
            Me.CaptionButtonColor = System.Drawing.Color.White
            Me.CaptionForeColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(1322, 596)
            Me.Controls.Add(Me.panel3)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "FormModeloOrg"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Organigrama - Empresa"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.diagram1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.model1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panel3.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents panel3 As Windows.Forms.Panel
        Private WithEvents diagram1 As Syncfusion.Windows.Forms.Diagram.Controls.Diagram
        Private WithEvents model1 As Syncfusion.Windows.Forms.Diagram.Model
        Friend WithEvents Panel1 As Panel
        Private WithEvents btnNuevo As Bunifu.Framework.UI.BunifuFlatButton
    End Class
End Namespace


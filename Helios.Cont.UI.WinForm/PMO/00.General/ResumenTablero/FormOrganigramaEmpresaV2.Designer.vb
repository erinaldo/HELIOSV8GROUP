Imports Microsoft.VisualBasic
Imports System
Namespace LinkTextBoxExt
    Partial Public Class FormOrganigramaEmpresaV2
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
            Dim Binding1 As Syncfusion.Windows.Forms.Diagram.Binding = New Syncfusion.Windows.Forms.Diagram.Binding()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOrganigramaEmpresaV2))
            Me.diagram1 = New Syncfusion.Windows.Forms.Diagram.Controls.Diagram(Me.components)
            Me.model1 = New Syncfusion.Windows.Forms.Diagram.Model(Me.components)
            Me.panel3 = New System.Windows.Forms.Panel()
            CType(Me.diagram1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.model1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'diagram1
            '
            Binding1.DefaultConnector = Nothing
            Binding1.DefaultNode = Nothing
            Binding1.Diagram = Me.diagram1
            Binding1.Id = Nothing
            Binding1.Label = CType(resources.GetObject("Binding1.Label"), System.Collections.Generic.List(Of String))
            Binding1.ParentId = Nothing
            Me.diagram1.Binding = Binding1
            Me.diagram1.Controller.Constraint = Syncfusion.Windows.Forms.Diagram.Constraints.PageEditable
            Me.diagram1.Controller.DefaultConnectorTool = Syncfusion.Windows.Forms.Diagram.ConnectorTool.OrgLineConnectorTool
            Me.diagram1.Controller.PasteOffset = New System.Drawing.SizeF(10.0!, 10.0!)
            Me.diagram1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.diagram1.EnableTouchMode = False
            Me.diagram1.HScroll = True
            Me.diagram1.LayoutManager = Nothing
            Me.diagram1.Location = New System.Drawing.Point(0, 0)
            Me.diagram1.MetroScrollBars = True
            Me.diagram1.Model = Me.model1
            Me.diagram1.Name = "diagram1"
            Me.diagram1.ScrollVirtualBounds = CType(resources.GetObject("diagram1.ScrollVirtualBounds"), System.Drawing.RectangleF)
            Me.diagram1.Size = New System.Drawing.Size(1097, 603)
            Me.diagram1.SmartSizeBox = False
            Me.diagram1.TabIndex = 2
            Me.diagram1.Text = "diagram1"
            '
            '
            '
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
            Me.model1.DocumentSize.Height = 1000.0!
            Me.model1.DocumentSize.Width = 1000.0!
            Me.model1.LineStyle.DashPattern = Nothing
            Me.model1.LineStyle.LineColor = System.Drawing.Color.Black
            Me.model1.LineStyle.LineWidth = 0!
            Me.model1.LogicalSize = New System.Drawing.SizeF(1000.0!, 1000.0!)
            Me.model1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
            Me.model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
            Me.model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
            '
            'panel3
            '
            Me.panel3.Controls.Add(Me.diagram1)
            Me.panel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panel3.Location = New System.Drawing.Point(0, 0)
            Me.panel3.Name = "panel3"
            Me.panel3.Size = New System.Drawing.Size(1097, 603)
            Me.panel3.TabIndex = 3
            '
            'FormOrganigramaEmpresaV2
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
            Me.BorderThickness = 2
            Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
            Me.CaptionButtonColor = System.Drawing.Color.White
            Me.CaptionForeColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(1097, 603)
            Me.Controls.Add(Me.panel3)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "FormOrganigramaEmpresaV2"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Organigrama - Empresa"
            CType(Me.diagram1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.model1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panel3.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private WithEvents panel3 As Windows.Forms.Panel
        Private WithEvents diagram1 As Syncfusion.Windows.Forms.Diagram.Controls.Diagram
        Private WithEvents model1 As Syncfusion.Windows.Forms.Diagram.Model
    End Class
End Namespace


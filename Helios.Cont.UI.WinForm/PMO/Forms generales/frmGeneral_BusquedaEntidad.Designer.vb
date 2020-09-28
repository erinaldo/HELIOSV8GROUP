<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneral_BusquedaEntidad
    Inherits frmMaster

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
        Me.components = New System.ComponentModel.Container()
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneral_BusquedaEntidad))
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lsvListadoItems = New System.Windows.Forms.ListView()
        Me.idEntidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Escribir indicios de nombres"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtProveedor, BannerTextInfo1)
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(277, 22)
        Me.txtProveedor.BorderColor = System.Drawing.Color.Silver
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(137, 33)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.Size = New System.Drawing.Size(277, 22)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedor.TabIndex = 497
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "Buscar x número"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextBoxExt1, BannerTextInfo2)
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(277, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt1.Location = New System.Drawing.Point(12, 33)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.NearImage = CType(resources.GetObject("TextBoxExt1.NearImage"), System.Drawing.Image)
        Me.TextBoxExt1.Size = New System.Drawing.Size(119, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 498
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BackColor = System.Drawing.Color.White
        Me.GradientPanel17.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GradientPanel17.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel17.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(414, 10)
        Me.GradientPanel17.TabIndex = 499
        '
        'lsvListadoItems
        '
        Me.lsvListadoItems.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvListadoItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idEntidad, Me.ColumnHeader3, Me.ColumnHeader1})
        Me.lsvListadoItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsvListadoItems.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lsvListadoItems.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lsvListadoItems.FullRowSelect = True
        Me.lsvListadoItems.HideSelection = False
        Me.lsvListadoItems.Location = New System.Drawing.Point(0, 61)
        Me.lsvListadoItems.MultiSelect = False
        Me.lsvListadoItems.Name = "lsvListadoItems"
        Me.lsvListadoItems.Size = New System.Drawing.Size(414, 322)
        Me.lsvListadoItems.TabIndex = 500
        Me.lsvListadoItems.UseCompatibleStateImageBehavior = False
        Me.lsvListadoItems.View = System.Windows.Forms.View.Details
        '
        'idEntidad
        '
        Me.idEntidad.Text = "ID"
        Me.idEntidad.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Número"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 250
        '
        'frmGeneral_BusquedaEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Entidad"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Búsqueda avanzada"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(414, 383)
        Me.Controls.Add(Me.lsvListadoItems)
        Me.Controls.Add(Me.GradientPanel17)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.txtProveedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGeneral_BusquedaEntidad"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel17 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lsvListadoItems As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents idEntidad As System.Windows.Forms.ColumnHeader
End Class

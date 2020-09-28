<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabRC_RecepcionHuesped
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabRC_RecepcionHuesped))
        Me.flowProductoDetalle = New System.Windows.Forms.FlowLayoutPanel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.cboFormato = New System.Windows.Forms.ComboBox()
        Me.BunifuFlatButton5 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton17 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.BGHoteles = New System.ComponentModel.BackgroundWorker()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flowProductoDetalle
        '
        Me.flowProductoDetalle.BackColor = System.Drawing.Color.White
        Me.flowProductoDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowProductoDetalle.Location = New System.Drawing.Point(0, 64)
        Me.flowProductoDetalle.Name = "flowProductoDetalle"
        Me.flowProductoDetalle.Size = New System.Drawing.Size(1024, 348)
        Me.flowProductoDetalle.TabIndex = 303
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8_hotel_room_key.ico")
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.cboCategoria)
        Me.GradientPanel1.Controls.Add(Me.lblFiltro)
        Me.GradientPanel1.Controls.Add(Me.cboFormato)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton5)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton17)
        Me.GradientPanel1.Controls.Add(Me.PictureLoad)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1024, 64)
        Me.GradientPanel1.TabIndex = 304
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(238, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 680
        Me.Label1.Text = "CLASIFICACION"
        '
        'cboCategoria
        '
        Me.cboCategoria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCategoria.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(241, 24)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(217, 25)
        Me.cboCategoria.TabIndex = 679
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.BackColor = System.Drawing.Color.Transparent
        Me.lblFiltro.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFiltro.Location = New System.Drawing.Point(14, 7)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(31, 13)
        Me.lblFiltro.TabIndex = 678
        Me.lblFiltro.Text = "PISO"
        '
        'cboFormato
        '
        Me.cboFormato.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboFormato.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.cboFormato.FormattingEnabled = True
        Me.cboFormato.Location = New System.Drawing.Point(17, 24)
        Me.cboFormato.Name = "cboFormato"
        Me.cboFormato.Size = New System.Drawing.Size(217, 25)
        Me.cboFormato.TabIndex = 677
        '
        'BunifuFlatButton5
        '
        Me.BunifuFlatButton5.Activecolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton5.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton5.BorderRadius = 5
        Me.BunifuFlatButton5.ButtonText = "ACTUALIZAR"
        Me.BunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton5.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton5.Iconimage = Nothing
        Me.BunifuFlatButton5.Iconimage_right = Nothing
        Me.BunifuFlatButton5.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton5.Iconimage_Selected = Nothing
        Me.BunifuFlatButton5.IconMarginLeft = 0
        Me.BunifuFlatButton5.IconMarginRight = 0
        Me.BunifuFlatButton5.IconRightVisible = True
        Me.BunifuFlatButton5.IconRightZoom = 0R
        Me.BunifuFlatButton5.IconVisible = True
        Me.BunifuFlatButton5.IconZoom = 90.0R
        Me.BunifuFlatButton5.IsTab = False
        Me.BunifuFlatButton5.Location = New System.Drawing.Point(879, 26)
        Me.BunifuFlatButton5.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton5.Name = "BunifuFlatButton5"
        Me.BunifuFlatButton5.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton5.selected = False
        Me.BunifuFlatButton5.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton5.TabIndex = 675
        Me.BunifuFlatButton5.Text = "ACTUALIZAR"
        Me.BunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton5.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton5.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton5.Visible = False
        '
        'BunifuFlatButton17
        '
        Me.BunifuFlatButton17.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton17.BorderRadius = 5
        Me.BunifuFlatButton17.ButtonText = "LISTA HOSPEDADOS"
        Me.BunifuFlatButton17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton17.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton17.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton17.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton17.Iconimage = Nothing
        Me.BunifuFlatButton17.Iconimage_right = Nothing
        Me.BunifuFlatButton17.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton17.Iconimage_Selected = Nothing
        Me.BunifuFlatButton17.IconMarginLeft = 0
        Me.BunifuFlatButton17.IconMarginRight = 0
        Me.BunifuFlatButton17.IconRightVisible = True
        Me.BunifuFlatButton17.IconRightZoom = 0R
        Me.BunifuFlatButton17.IconVisible = True
        Me.BunifuFlatButton17.IconZoom = 90.0R
        Me.BunifuFlatButton17.IsTab = False
        Me.BunifuFlatButton17.Location = New System.Drawing.Point(767, 26)
        Me.BunifuFlatButton17.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton17.Name = "BunifuFlatButton17"
        Me.BunifuFlatButton17.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton17.selected = False
        Me.BunifuFlatButton17.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton17.TabIndex = 673
        Me.BunifuFlatButton17.Text = "LISTA HOSPEDADOS"
        Me.BunifuFlatButton17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton17.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton17.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton17.Visible = False
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(464, 28)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 661
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'BGHoteles
        '
        '
        'TabRC_RecepcionHuesped
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.flowProductoDetalle)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TabRC_RecepcionHuesped"
        Me.Size = New System.Drawing.Size(1024, 412)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flowProductoDetalle As FlowLayoutPanel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PictureLoad As PictureBox
    Private WithEvents BunifuFlatButton5 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton17 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents lblFiltro As Label
    Friend WithEvents cboFormato As ComboBox
    Friend WithEvents BGHoteles As System.ComponentModel.BackgroundWorker
End Class

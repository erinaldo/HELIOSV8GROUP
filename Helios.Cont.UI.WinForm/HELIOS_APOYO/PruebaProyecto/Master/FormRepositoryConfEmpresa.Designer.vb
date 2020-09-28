<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRepositoryConfEmpresa
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
        Dim Animation2 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation1 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRepositoryConfEmpresa))
        Me.panelheader = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnApoyo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnNumeracion = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnTipoDoc = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnProducto = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnOrganigrama = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnCargo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.bunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.PanelAnimator = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.LogoAnimator = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.bunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.bunifuCustomLabel1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        CType(Me.panelheader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelheader.SuspendLayout()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelheader
        '
        Me.panelheader.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.panelheader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panelheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelheader.Controls.Add(Me.btnApoyo)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton3)
        Me.panelheader.Controls.Add(Me.BunifuImageButton1)
        Me.panelheader.Controls.Add(Me.bunifuImageButton2)
        Me.panelheader.Controls.Add(Me.btnNumeracion)
        Me.panelheader.Controls.Add(Me.btnTipoDoc)
        Me.panelheader.Controls.Add(Me.btnProducto)
        Me.panelheader.Controls.Add(Me.btnOrganigrama)
        Me.panelheader.Controls.Add(Me.sliderTop)
        Me.panelheader.Controls.Add(Me.btnCargo)
        Me.panelheader.Controls.Add(Me.bunifuCustomLabel1)
        Me.PanelAnimator.SetDecoration(Me.panelheader, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.panelheader, BunifuAnimatorNS.DecorationType.None)
        Me.panelheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelheader.Location = New System.Drawing.Point(0, 0)
        Me.panelheader.Name = "panelheader"
        Me.panelheader.Size = New System.Drawing.Size(1109, 77)
        Me.panelheader.TabIndex = 4
        '
        'btnApoyo
        '
        Me.btnApoyo.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnApoyo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnApoyo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnApoyo.BorderRadius = 0
        Me.btnApoyo.ButtonText = "MODULOS APOYO"
        Me.btnApoyo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.btnApoyo, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.btnApoyo, BunifuAnimatorNS.DecorationType.None)
        Me.btnApoyo.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnApoyo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApoyo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnApoyo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnApoyo.Iconimage = Nothing
        Me.btnApoyo.Iconimage_right = Nothing
        Me.btnApoyo.Iconimage_right_Selected = Nothing
        Me.btnApoyo.Iconimage_Selected = Nothing
        Me.btnApoyo.IconMarginLeft = 0
        Me.btnApoyo.IconMarginRight = 0
        Me.btnApoyo.IconRightVisible = True
        Me.btnApoyo.IconRightZoom = 0R
        Me.btnApoyo.IconVisible = True
        Me.btnApoyo.IconZoom = 90.0R
        Me.btnApoyo.IsTab = False
        Me.btnApoyo.Location = New System.Drawing.Point(332, 44)
        Me.btnApoyo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnApoyo.Name = "btnApoyo"
        Me.btnApoyo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnApoyo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnApoyo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnApoyo.selected = False
        Me.btnApoyo.Size = New System.Drawing.Size(137, 18)
        Me.btnApoyo.TabIndex = 31
        Me.btnApoyo.Text = "MODULOS APOYO"
        Me.btnApoyo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnApoyo.Textcolor = System.Drawing.Color.White
        Me.btnApoyo.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApoyo.Visible = False
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "EMPRESA"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.BunifuFlatButton3, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.BunifuFlatButton3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Nothing
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(5, 44)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(82, 18)
        Me.BunifuFlatButton3.TabIndex = 30
        Me.BunifuFlatButton3.Text = "EMPRESA"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.CornflowerBlue
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnNumeracion
        '
        Me.btnNumeracion.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnNumeracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnNumeracion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNumeracion.BorderRadius = 0
        Me.btnNumeracion.ButtonText = "NUMERACION"
        Me.btnNumeracion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.btnNumeracion, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.btnNumeracion, BunifuAnimatorNS.DecorationType.None)
        Me.btnNumeracion.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnNumeracion.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNumeracion.ForeColor = System.Drawing.Color.White
        Me.btnNumeracion.Iconcolor = System.Drawing.Color.Transparent
        Me.btnNumeracion.Iconimage = Nothing
        Me.btnNumeracion.Iconimage_right = Nothing
        Me.btnNumeracion.Iconimage_right_Selected = Nothing
        Me.btnNumeracion.Iconimage_Selected = Nothing
        Me.btnNumeracion.IconMarginLeft = 0
        Me.btnNumeracion.IconMarginRight = 0
        Me.btnNumeracion.IconRightVisible = True
        Me.btnNumeracion.IconRightZoom = 0R
        Me.btnNumeracion.IconVisible = True
        Me.btnNumeracion.IconZoom = 90.0R
        Me.btnNumeracion.IsTab = False
        Me.btnNumeracion.Location = New System.Drawing.Point(218, 44)
        Me.btnNumeracion.Margin = New System.Windows.Forms.Padding(2)
        Me.btnNumeracion.Name = "btnNumeracion"
        Me.btnNumeracion.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnNumeracion.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnNumeracion.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnNumeracion.selected = False
        Me.btnNumeracion.Size = New System.Drawing.Size(110, 18)
        Me.btnNumeracion.TabIndex = 27
        Me.btnNumeracion.Text = "NUMERACION"
        Me.btnNumeracion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnNumeracion.Textcolor = System.Drawing.Color.White
        Me.btnNumeracion.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNumeracion.Visible = False
        '
        'btnTipoDoc
        '
        Me.btnTipoDoc.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnTipoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnTipoDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTipoDoc.BorderRadius = 0
        Me.btnTipoDoc.ButtonText = "TIPO DOCUMENTO"
        Me.btnTipoDoc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.btnTipoDoc, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.btnTipoDoc, BunifuAnimatorNS.DecorationType.None)
        Me.btnTipoDoc.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnTipoDoc.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTipoDoc.Iconcolor = System.Drawing.Color.Transparent
        Me.btnTipoDoc.Iconimage = Nothing
        Me.btnTipoDoc.Iconimage_right = Nothing
        Me.btnTipoDoc.Iconimage_right_Selected = Nothing
        Me.btnTipoDoc.Iconimage_Selected = Nothing
        Me.btnTipoDoc.IconMarginLeft = 0
        Me.btnTipoDoc.IconMarginRight = 0
        Me.btnTipoDoc.IconRightVisible = True
        Me.btnTipoDoc.IconRightZoom = 0R
        Me.btnTipoDoc.IconVisible = True
        Me.btnTipoDoc.IconZoom = 90.0R
        Me.btnTipoDoc.IsTab = False
        Me.btnTipoDoc.Location = New System.Drawing.Point(714, 44)
        Me.btnTipoDoc.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTipoDoc.Name = "btnTipoDoc"
        Me.btnTipoDoc.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnTipoDoc.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnTipoDoc.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnTipoDoc.selected = False
        Me.btnTipoDoc.Size = New System.Drawing.Size(155, 18)
        Me.btnTipoDoc.TabIndex = 25
        Me.btnTipoDoc.Text = "TIPO DOCUMENTO"
        Me.btnTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnTipoDoc.Textcolor = System.Drawing.Color.Gainsboro
        Me.btnTipoDoc.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTipoDoc.Visible = False
        '
        'btnProducto
        '
        Me.btnProducto.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProducto.BorderRadius = 0
        Me.btnProducto.ButtonText = "ACCESO DE PRODUCTO"
        Me.btnProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.btnProducto, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.btnProducto, BunifuAnimatorNS.DecorationType.None)
        Me.btnProducto.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnProducto.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProducto.Iconcolor = System.Drawing.Color.Transparent
        Me.btnProducto.Iconimage = Nothing
        Me.btnProducto.Iconimage_right = Nothing
        Me.btnProducto.Iconimage_right_Selected = Nothing
        Me.btnProducto.Iconimage_Selected = Nothing
        Me.btnProducto.IconMarginLeft = 0
        Me.btnProducto.IconMarginRight = 0
        Me.btnProducto.IconRightVisible = True
        Me.btnProducto.IconRightZoom = 0R
        Me.btnProducto.IconVisible = True
        Me.btnProducto.IconZoom = 90.0R
        Me.btnProducto.IsTab = False
        Me.btnProducto.Location = New System.Drawing.Point(467, 44)
        Me.btnProducto.Margin = New System.Windows.Forms.Padding(2)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnProducto.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnProducto.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnProducto.selected = False
        Me.btnProducto.Size = New System.Drawing.Size(179, 18)
        Me.btnProducto.TabIndex = 22
        Me.btnProducto.Text = "ACCESO DE PRODUCTO"
        Me.btnProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnProducto.Textcolor = System.Drawing.Color.Gainsboro
        Me.btnProducto.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProducto.Visible = False
        '
        'btnOrganigrama
        '
        Me.btnOrganigrama.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnOrganigrama.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnOrganigrama.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOrganigrama.BorderRadius = 0
        Me.btnOrganigrama.ButtonText = "ORGANIGRAMA"
        Me.btnOrganigrama.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.btnOrganigrama, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.btnOrganigrama, BunifuAnimatorNS.DecorationType.None)
        Me.btnOrganigrama.DisabledColor = System.Drawing.Color.Gray
        Me.btnOrganigrama.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrganigrama.Iconcolor = System.Drawing.Color.Transparent
        Me.btnOrganigrama.Iconimage = Nothing
        Me.btnOrganigrama.Iconimage_right = Nothing
        Me.btnOrganigrama.Iconimage_right_Selected = Nothing
        Me.btnOrganigrama.Iconimage_Selected = Nothing
        Me.btnOrganigrama.IconMarginLeft = 0
        Me.btnOrganigrama.IconMarginRight = 0
        Me.btnOrganigrama.IconRightVisible = True
        Me.btnOrganigrama.IconRightZoom = 0R
        Me.btnOrganigrama.IconVisible = True
        Me.btnOrganigrama.IconZoom = 90.0R
        Me.btnOrganigrama.IsTab = False
        Me.btnOrganigrama.Location = New System.Drawing.Point(91, 44)
        Me.btnOrganigrama.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOrganigrama.Name = "btnOrganigrama"
        Me.btnOrganigrama.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnOrganigrama.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnOrganigrama.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnOrganigrama.selected = False
        Me.btnOrganigrama.Size = New System.Drawing.Size(123, 18)
        Me.btnOrganigrama.TabIndex = 21
        Me.btnOrganigrama.Text = "ORGANIGRAMA"
        Me.btnOrganigrama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOrganigrama.Textcolor = System.Drawing.Color.Gainsboro
        Me.btnOrganigrama.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrganigrama.Visible = False
        '
        'btnCargo
        '
        Me.btnCargo.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnCargo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargo.BorderRadius = 0
        Me.btnCargo.ButtonText = "CARGOS"
        Me.btnCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.btnCargo, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.btnCargo, BunifuAnimatorNS.DecorationType.None)
        Me.btnCargo.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnCargo.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCargo.Iconimage = Nothing
        Me.btnCargo.Iconimage_right = Nothing
        Me.btnCargo.Iconimage_right_Selected = Nothing
        Me.btnCargo.Iconimage_Selected = Nothing
        Me.btnCargo.IconMarginLeft = 0
        Me.btnCargo.IconMarginRight = 0
        Me.btnCargo.IconRightVisible = True
        Me.btnCargo.IconRightZoom = 0R
        Me.btnCargo.IconVisible = True
        Me.btnCargo.IconZoom = 90.0R
        Me.btnCargo.IsTab = False
        Me.btnCargo.Location = New System.Drawing.Point(639, 44)
        Me.btnCargo.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCargo.Name = "btnCargo"
        Me.btnCargo.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnCargo.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnCargo.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCargo.selected = False
        Me.btnCargo.Size = New System.Drawing.Size(83, 18)
        Me.btnCargo.TabIndex = 6
        Me.btnCargo.Text = "CARGOS"
        Me.btnCargo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCargo.Textcolor = System.Drawing.Color.Gainsboro
        Me.btnCargo.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargo.Visible = False
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.White
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelAnimator.SetDecoration(Me.PanelBody, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.PanelBody, BunifuAnimatorNS.DecorationType.None)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 77)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1109, 562)
        Me.PanelBody.TabIndex = 5
        '
        'bunifuDragControl1
        '
        Me.bunifuDragControl1.Fixed = True
        Me.bunifuDragControl1.Horizontal = True
        Me.bunifuDragControl1.TargetControl = Me.panelheader
        Me.bunifuDragControl1.Vertical = True
        '
        'PanelAnimator
        '
        Me.PanelAnimator.AnimationType = BunifuAnimatorNS.AnimationType.Particles
        Me.PanelAnimator.Cursor = Nothing
        Animation2.AnimateOnlyDifferences = True
        Animation2.BlindCoeff = CType(resources.GetObject("Animation2.BlindCoeff"), System.Drawing.PointF)
        Animation2.LeafCoeff = 0!
        Animation2.MaxTime = 1.0!
        Animation2.MinTime = 0!
        Animation2.MosaicCoeff = CType(resources.GetObject("Animation2.MosaicCoeff"), System.Drawing.PointF)
        Animation2.MosaicShift = CType(resources.GetObject("Animation2.MosaicShift"), System.Drawing.PointF)
        Animation2.MosaicSize = 1
        Animation2.Padding = New System.Windows.Forms.Padding(100, 50, 100, 150)
        Animation2.RotateCoeff = 0!
        Animation2.RotateLimit = 0!
        Animation2.ScaleCoeff = CType(resources.GetObject("Animation2.ScaleCoeff"), System.Drawing.PointF)
        Animation2.SlideCoeff = CType(resources.GetObject("Animation2.SlideCoeff"), System.Drawing.PointF)
        Animation2.TimeCoeff = 2.0!
        Animation2.TransparencyCoeff = 0!
        Me.PanelAnimator.DefaultAnimation = Animation2
        '
        'LogoAnimator
        '
        Me.LogoAnimator.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate
        Me.LogoAnimator.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), System.Drawing.PointF)
        Animation1.LeafCoeff = 0!
        Animation1.MaxTime = 1.0!
        Animation1.MinTime = 0!
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), System.Drawing.PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), System.Drawing.PointF)
        Animation1.MosaicSize = 0
        Animation1.Padding = New System.Windows.Forms.Padding(30)
        Animation1.RotateCoeff = 0.5!
        Animation1.RotateLimit = 0.2!
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), System.Drawing.PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), System.Drawing.PointF)
        Animation1.TimeCoeff = 0!
        Animation1.TransparencyCoeff = 0!
        Me.LogoAnimator.DefaultAnimation = Animation1
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.LogoAnimator.SetDecoration(Me.BunifuImageButton1, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.BunifuImageButton1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuImageButton1.Image = CType(resources.GetObject("BunifuImageButton1.Image"), System.Drawing.Image)
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(1057, 10)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(20, 20)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 29
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'bunifuImageButton2
        '
        Me.bunifuImageButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent
        Me.LogoAnimator.SetDecoration(Me.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None)
        Me.bunifuImageButton2.Image = CType(resources.GetObject("bunifuImageButton2.Image"), System.Drawing.Image)
        Me.bunifuImageButton2.ImageActive = Nothing
        Me.bunifuImageButton2.Location = New System.Drawing.Point(1079, 10)
        Me.bunifuImageButton2.Name = "bunifuImageButton2"
        Me.bunifuImageButton2.Size = New System.Drawing.Size(20, 20)
        Me.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.bunifuImageButton2.TabIndex = 28
        Me.bunifuImageButton2.TabStop = False
        Me.bunifuImageButton2.Zoom = 10
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelAnimator.SetDecoration(Me.sliderTop, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.sliderTop, BunifuAnimatorNS.DecorationType.None)
        Me.sliderTop.Location = New System.Drawing.Point(1, 71)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(86, 10)
        Me.sliderTop.TabIndex = 10
        Me.sliderTop.TabStop = False
        '
        'bunifuCustomLabel1
        '
        Me.PanelAnimator.SetDecoration(Me.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None)
        Me.bunifuCustomLabel1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White
        Me.bunifuCustomLabel1.Image = CType(resources.GetObject("bunifuCustomLabel1.Image"), System.Drawing.Image)
        Me.bunifuCustomLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bunifuCustomLabel1.Location = New System.Drawing.Point(11, 10)
        Me.bunifuCustomLabel1.Name = "bunifuCustomLabel1"
        Me.bunifuCustomLabel1.Size = New System.Drawing.Size(213, 21)
        Me.bunifuCustomLabel1.TabIndex = 1
        Me.bunifuCustomLabel1.Text = "Configuración Empresa"
        Me.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormRepositoryConfEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 639)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.panelheader)
        Me.PanelAnimator.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormRepositoryConfEmpresa"
        Me.Text = "Comercial"
        CType(Me.panelheader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelheader.ResumeLayout(False)
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panelheader As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Private WithEvents bunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
    Private WithEvents sliderTop As PictureBox
    Private WithEvents bunifuCustomLabel1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents LogoAnimator As BunifuAnimatorNS.BunifuTransition
    Private WithEvents PanelAnimator As BunifuAnimatorNS.BunifuTransition
    Private WithEvents bunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnNumeracion As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnTipoDoc As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnProducto As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnOrganigrama As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnCargo As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnApoyo As Bunifu.Framework.UI.BunifuFlatButton
End Class

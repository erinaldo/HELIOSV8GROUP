<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaPreciosExistencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaPreciosExistencias))
        Me.lsvListado = New System.Windows.Forms.ListView()
        Me.lsvDetalle = New System.Windows.Forms.ListView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblDetalleMenor = New System.Windows.Forms.Label()
        Me.lblDetalleMayor = New System.Windows.Forms.Label()
        Me.lblDetalleGmayor = New System.Windows.Forms.Label()
        Me.cboGravado = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblIdMenor = New System.Windows.Forms.Label()
        Me.lblIdMayor = New System.Windows.Forms.Label()
        Me.lblIdGMayor = New System.Windows.Forms.Label()
        Me.lblCanMenor = New System.Windows.Forms.Label()
        Me.lblCanMayor = New System.Windows.Forms.Label()
        Me.lblCanGmayor = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtAlmacen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFiltro = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pcAlmacen = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.lstAlmacen = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Panel3.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pcAlmacen.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvListado
        '
        Me.lsvListado.BackColor = System.Drawing.Color.White
        Me.lsvListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvListado.FullRowSelect = True
        Me.lsvListado.GridLines = True
        Me.lsvListado.HideSelection = False
        Me.lsvListado.Location = New System.Drawing.Point(0, 0)
        Me.lsvListado.MultiSelect = False
        Me.lsvListado.Name = "lsvListado"
        Me.lsvListado.Size = New System.Drawing.Size(957, 174)
        Me.lsvListado.TabIndex = 11
        Me.lsvListado.UseCompatibleStateImageBehavior = False
        Me.lsvListado.View = System.Windows.Forms.View.Details
        '
        'lsvDetalle
        '
        Me.lsvDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lsvDetalle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lsvDetalle.FullRowSelect = True
        Me.lsvDetalle.GridLines = True
        Me.lsvDetalle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvDetalle.HideSelection = False
        Me.lsvDetalle.Location = New System.Drawing.Point(8, 363)
        Me.lsvDetalle.MultiSelect = False
        Me.lsvDetalle.Name = "lsvDetalle"
        Me.lsvDetalle.ShowItemToolTips = True
        Me.lsvDetalle.Size = New System.Drawing.Size(946, 206)
        Me.lsvDetalle.TabIndex = 18
        Me.lsvDetalle.UseCompatibleStateImageBehavior = False
        Me.lsvDetalle.View = System.Windows.Forms.View.Details
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 349)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "FECHA"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(104, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 31)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Val. Compra S/IGV"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(75, 331)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 31)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "TIPO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label9.Location = New System.Drawing.Point(222, 315)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 47)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Utilidad %"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(381, 331)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 31)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "IGV"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(421, 331)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 31)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "ISC"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(459, 331)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 31)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "OTC"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label15.Location = New System.Drawing.Point(493, 331)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 31)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "PRECIO VENTA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(163, 331)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 31)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Val. Compra C/IGV"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(263, 331)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 31)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Utilidad S/IGV"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(322, 331)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 31)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Valor de venta"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(540, 331)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 15)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Dscto unit."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(540, 347)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "%"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(580, 347)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 15)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "importe"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(632, 331)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 31)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Precio Vta Final"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(768, 331)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(43, 31)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Precio Vta Final"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(716, 347)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(51, 15)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "importe"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(676, 347)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(39, 15)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "%"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(676, 331)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(91, 15)
        Me.Label23.TabIndex = 39
        Me.Label23.Text = "Dscto unit."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(904, 331)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 31)
        Me.Label24.TabIndex = 46
        Me.Label24.Text = "Precio Vta Final"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(852, 347)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 15)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "importe"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(812, 347)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(39, 15)
        Me.Label26.TabIndex = 44
        Me.Label26.Text = "%"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(812, 331)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 15)
        Me.Label27.TabIndex = 43
        Me.Label27.Text = "Dscto unit."
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(540, 315)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(135, 15)
        Me.Label28.TabIndex = 47
        Me.Label28.Text = "PRECIO X MENOR"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(676, 315)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(135, 15)
        Me.Label29.TabIndex = 48
        Me.Label29.Text = "PRECIO X MAYOR"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(812, 315)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(135, 15)
        Me.Label30.TabIndex = 49
        Me.Label30.Text = "PRECIO AL GRAN MAYOR"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(263, 315)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(276, 15)
        Me.Label31.TabIndex = 50
        Me.Label31.Text = "DATOS"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDetalleMenor
        '
        Me.lblDetalleMenor.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblDetalleMenor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblDetalleMenor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDetalleMenor.Location = New System.Drawing.Point(540, 299)
        Me.lblDetalleMenor.Name = "lblDetalleMenor"
        Me.lblDetalleMenor.Size = New System.Drawing.Size(135, 15)
        Me.lblDetalleMenor.TabIndex = 53
        Me.lblDetalleMenor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDetalleMayor
        '
        Me.lblDetalleMayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblDetalleMayor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblDetalleMayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDetalleMayor.Location = New System.Drawing.Point(676, 299)
        Me.lblDetalleMayor.Name = "lblDetalleMayor"
        Me.lblDetalleMayor.Size = New System.Drawing.Size(135, 15)
        Me.lblDetalleMayor.TabIndex = 54
        Me.lblDetalleMayor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDetalleGmayor
        '
        Me.lblDetalleGmayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblDetalleGmayor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblDetalleGmayor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDetalleGmayor.Location = New System.Drawing.Point(812, 299)
        Me.lblDetalleGmayor.Name = "lblDetalleGmayor"
        Me.lblDetalleGmayor.Size = New System.Drawing.Size(135, 15)
        Me.lblDetalleGmayor.TabIndex = 55
        Me.lblDetalleGmayor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboGravado
        '
        Me.cboGravado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGravado.FormattingEnabled = True
        Me.cboGravado.Items.AddRange(New Object() {"1", "2"})
        Me.cboGravado.Location = New System.Drawing.Point(102, 299)
        Me.cboGravado.Name = "cboGravado"
        Me.cboGravado.Size = New System.Drawing.Size(47, 21)
        Me.cboGravado.TabIndex = 56
        Me.cboGravado.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(7, 304)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 13)
        Me.Label33.TabIndex = 57
        Me.Label33.Text = "Código Gravado:"
        Me.Label33.Visible = False
        '
        'lblIdMenor
        '
        Me.lblIdMenor.AutoSize = True
        Me.lblIdMenor.Location = New System.Drawing.Point(488, 300)
        Me.lblIdMenor.Name = "lblIdMenor"
        Me.lblIdMenor.Size = New System.Drawing.Size(44, 13)
        Me.lblIdMenor.TabIndex = 58
        Me.lblIdMenor.Text = "Label34"
        Me.lblIdMenor.Visible = False
        '
        'lblIdMayor
        '
        Me.lblIdMayor.AutoSize = True
        Me.lblIdMayor.Location = New System.Drawing.Point(436, 299)
        Me.lblIdMayor.Name = "lblIdMayor"
        Me.lblIdMayor.Size = New System.Drawing.Size(44, 13)
        Me.lblIdMayor.TabIndex = 59
        Me.lblIdMayor.Text = "Label34"
        Me.lblIdMayor.Visible = False
        '
        'lblIdGMayor
        '
        Me.lblIdGMayor.AutoSize = True
        Me.lblIdGMayor.Location = New System.Drawing.Point(384, 299)
        Me.lblIdGMayor.Name = "lblIdGMayor"
        Me.lblIdGMayor.Size = New System.Drawing.Size(44, 13)
        Me.lblIdGMayor.TabIndex = 60
        Me.lblIdGMayor.Text = "Label34"
        Me.lblIdGMayor.Visible = False
        '
        'lblCanMenor
        '
        Me.lblCanMenor.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblCanMenor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblCanMenor.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCanMenor.Location = New System.Drawing.Point(644, 299)
        Me.lblCanMenor.Name = "lblCanMenor"
        Me.lblCanMenor.Size = New System.Drawing.Size(31, 15)
        Me.lblCanMenor.TabIndex = 61
        Me.lblCanMenor.Text = "0"
        Me.lblCanMenor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCanMayor
        '
        Me.lblCanMayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblCanMayor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblCanMayor.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCanMayor.Location = New System.Drawing.Point(780, 299)
        Me.lblCanMayor.Name = "lblCanMayor"
        Me.lblCanMayor.Size = New System.Drawing.Size(31, 15)
        Me.lblCanMayor.TabIndex = 62
        Me.lblCanMayor.Text = "0"
        Me.lblCanMayor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCanGmayor
        '
        Me.lblCanGmayor.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblCanGmayor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblCanGmayor.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCanGmayor.Location = New System.Drawing.Point(916, 299)
        Me.lblCanGmayor.Name = "lblCanGmayor"
        Me.lblCanGmayor.Size = New System.Drawing.Size(31, 15)
        Me.lblCanGmayor.TabIndex = 63
        Me.lblCanGmayor.Text = "0"
        Me.lblCanGmayor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.GradientPanel2)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.txtFiltro)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.ToolStrip3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(957, 88)
        Me.Panel3.TabIndex = 65
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Controls.Add(Me.txtAlmacen)
        Me.GradientPanel2.Location = New System.Drawing.Point(5, 52)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(284, 32)
        Me.GradientPanel2.TabIndex = 300
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(251, 4)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.TabIndex = 207
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtAlmacen
        '
        Me.txtAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlmacen.Location = New System.Drawing.Point(5, 5)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(243, 19)
        Me.txtAlmacen.TabIndex = 206
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(5, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 24)
        Me.Panel1.TabIndex = 299
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(10, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 19)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Almacén a consultar:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(305, 56)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(188, 19)
        Me.txtFiltro.TabIndex = 298
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(307, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 22)
        Me.Label3.TabIndex = 297
        Me.Label3.Text = "Buscar producto:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(957, 25)
        Me.ToolStrip3.TabIndex = 286
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.configuration_13194
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(116, 22)
        Me.lblEstado.Text = "Configuraciones..."
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pcAlmacen)
        Me.Panel4.Controls.Add(Me.lsvListado)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 113)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(957, 174)
        Me.Panel4.TabIndex = 66
        '
        'pcAlmacen
        '
        Me.pcAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcAlmacen.Controls.Add(Me.ButtonAdv4)
        Me.pcAlmacen.Controls.Add(Me.ButtonAdv5)
        Me.pcAlmacen.Controls.Add(Me.lstAlmacen)
        Me.pcAlmacen.Location = New System.Drawing.Point(397, 30)
        Me.pcAlmacen.Name = "pcAlmacen"
        Me.pcAlmacen.Size = New System.Drawing.Size(40, 21)
        Me.pcAlmacen.TabIndex = 292
        Me.pcAlmacen.Visible = False
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(63, 86)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.TabIndex = 209
        Me.ButtonAdv4.Text = "Cancelar"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(1, 86)
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv5.TabIndex = 208
        Me.ButtonAdv5.Text = "OK"
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'lstAlmacen
        '
        Me.lstAlmacen.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstAlmacen.FormattingEnabled = True
        Me.lstAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.lstAlmacen.Name = "lstAlmacen"
        Me.lstAlmacen.Size = New System.Drawing.Size(38, 82)
        Me.lstAlmacen.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.White
        Me.ToolStrip5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.toolStripSeparator, Me.NuevoToolStripButton1, Me.AyudaToolStripButton})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(957, 25)
        Me.ToolStrip5.TabIndex = 291
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        Me.ToolStripButton7.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton1
        '
        Me.NuevoToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.NuevoToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NuevoToolStripButton1.Image = CType(resources.GetObject("NuevoToolStripButton1.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton1.Name = "NuevoToolStripButton1"
        Me.NuevoToolStripButton1.Size = New System.Drawing.Size(60, 22)
        Me.NuevoToolStripButton1.Text = "&Nuevo"
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.AyudaToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(68, 22)
        Me.AyudaToolStripButton.Text = "Eliminar"
        '
        'frmListaPreciosExistencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(957, 573)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblCanGmayor)
        Me.Controls.Add(Me.lblCanMayor)
        Me.Controls.Add(Me.lblCanMenor)
        Me.Controls.Add(Me.lblIdGMayor)
        Me.Controls.Add(Me.lblIdMayor)
        Me.Controls.Add(Me.lblIdMenor)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.cboGravado)
        Me.Controls.Add(Me.lblDetalleGmayor)
        Me.Controls.Add(Me.lblDetalleMayor)
        Me.Controls.Add(Me.lblDetalleMenor)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lsvDetalle)
        Me.Controls.Add(Me.ToolStrip5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmListaPreciosExistencias"
        Me.Text = "Configuración del precio de venta"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pcAlmacen.ResumeLayout(False)
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsvListado As System.Windows.Forms.ListView
    Friend WithEvents lsvDetalle As System.Windows.Forms.ListView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblDetalleMenor As System.Windows.Forms.Label
    Friend WithEvents lblDetalleMayor As System.Windows.Forms.Label
    Friend WithEvents lblDetalleGmayor As System.Windows.Forms.Label
    Friend WithEvents cboGravado As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblIdMenor As System.Windows.Forms.Label
    Friend WithEvents lblIdMayor As System.Windows.Forms.Label
    Friend WithEvents lblIdGMayor As System.Windows.Forms.Label
    Friend WithEvents lblCanMenor As System.Windows.Forms.Label
    Friend WithEvents lblCanMayor As System.Windows.Forms.Label
    Friend WithEvents lblCanGmayor As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NuevoToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtAlmacen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents pcAlmacen As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lstAlmacen As System.Windows.Forms.ListBox
End Class

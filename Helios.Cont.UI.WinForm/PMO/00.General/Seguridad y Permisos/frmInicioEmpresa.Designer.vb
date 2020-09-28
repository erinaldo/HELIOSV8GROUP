<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicioEmpresa
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicioEmpresa))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1/12/2016", "3.55", "3.654"}, -1)
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel12 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblempresaNom = New System.Windows.Forms.Label()
        Me.GradientPanel14 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lsvTipoCambio = New System.Windows.Forms.ListView()
        Me.colId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colfecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colventa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbActivo = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbFinanciero = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.rbVentas = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.rbAdmin = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.rbProduccion = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.rbProyecto = New Syncfusion.Windows.Forms.Tools.CheckBoxAdv()
        Me.pcNuevoEstablecimiento = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.cboTipoEstable = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtNewEstable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboEstablecimiento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboEmpresa = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.txtRenta4 = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtIva = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtmontomaximo = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.txtFechaTC = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bgGeneral = New System.ComponentModel.BackgroundWorker()
        Me.txtFechaInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.nudTipoCambioCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.nudTipoCambioVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        CType(Me.GradientPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel12.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel14.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.rbActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.rbFinanciero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcNuevoEstablecimiento.SuspendLayout()
        CType(Me.txtNewEstable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        CType(Me.cboEstablecimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRenta4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmontomaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaTC.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambioVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel12
        '
        Me.GradientPanel12.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel12.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel12.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel12.Controls.Add(Me.PanelError)
        Me.GradientPanel12.Controls.Add(Me.lblEmpresa)
        Me.GradientPanel12.Controls.Add(Me.lblempresaNom)
        Me.GradientPanel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel12.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel12.Name = "GradientPanel12"
        Me.GradientPanel12.Size = New System.Drawing.Size(749, 24)
        Me.GradientPanel12.TabIndex = 14
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(747, 22)
        Me.PanelError.TabIndex = 412
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(728, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Gray
        Me.lblEmpresa.Location = New System.Drawing.Point(39, 21)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(144, 15)
        Me.lblEmpresa.TabIndex = 1
        Me.lblEmpresa.Text = "EMPRESA RAZON SOCIAL"
        '
        'lblempresaNom
        '
        Me.lblempresaNom.AutoSize = True
        Me.lblempresaNom.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblempresaNom.ForeColor = System.Drawing.Color.Black
        Me.lblempresaNom.Location = New System.Drawing.Point(39, 43)
        Me.lblempresaNom.Name = "lblempresaNom"
        Me.lblempresaNom.Size = New System.Drawing.Size(65, 13)
        Me.lblempresaNom.TabIndex = 12
        Me.lblempresaNom.Text = "SARIEL SRL."
        '
        'GradientPanel14
        '
        Me.GradientPanel14.BackColor = System.Drawing.Color.Transparent
        Me.GradientPanel14.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel14.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel14.Controls.Add(Me.Panel1)
        Me.GradientPanel14.Controls.Add(Me.GroupBox1)
        Me.GradientPanel14.Controls.Add(Me.pcNuevoEstablecimiento)
        Me.GradientPanel14.Controls.Add(Me.Label2)
        Me.GradientPanel14.Controls.Add(Me.cboEstablecimiento)
        Me.GradientPanel14.Controls.Add(Me.cboEmpresa)
        Me.GradientPanel14.Controls.Add(Me.Label5)
        Me.GradientPanel14.Controls.Add(Me.PictureBox18)
        Me.GradientPanel14.Controls.Add(Me.txtRenta4)
        Me.GradientPanel14.Controls.Add(Me.txtIva)
        Me.GradientPanel14.Controls.Add(Me.ButtonAdv3)
        Me.GradientPanel14.Controls.Add(Me.txtmontomaximo)
        Me.GradientPanel14.Controls.Add(Me.Label31)
        Me.GradientPanel14.Controls.Add(Me.Label1)
        Me.GradientPanel14.Controls.Add(Me.Label3)
        Me.GradientPanel14.Controls.Add(Me.CboAlmacen)
        Me.GradientPanel14.Controls.Add(Me.Label23)
        Me.GradientPanel14.Dock = System.Windows.Forms.DockStyle.Right
        Me.GradientPanel14.Location = New System.Drawing.Point(359, 24)
        Me.GradientPanel14.Name = "GradientPanel14"
        Me.GradientPanel14.Size = New System.Drawing.Size(390, 273)
        Me.GradientPanel14.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lsvTipoCambio)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 269)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(388, 2)
        Me.Panel1.TabIndex = 442
        '
        'lsvTipoCambio
        '
        Me.lsvTipoCambio.BackColor = System.Drawing.Color.White
        Me.lsvTipoCambio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colId, Me.colfecha, Me.colCompra, Me.colventa})
        Me.lsvTipoCambio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvTipoCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lsvTipoCambio.FullRowSelect = True
        Me.lsvTipoCambio.GridLines = True
        Me.lsvTipoCambio.HideSelection = False
        Me.lsvTipoCambio.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lsvTipoCambio.Location = New System.Drawing.Point(24, 0)
        Me.lsvTipoCambio.Name = "lsvTipoCambio"
        Me.lsvTipoCambio.Size = New System.Drawing.Size(347, 0)
        Me.lsvTipoCambio.TabIndex = 299
        Me.lsvTipoCambio.UseCompatibleStateImageBehavior = False
        Me.lsvTipoCambio.View = System.Windows.Forms.View.Details
        Me.lsvTipoCambio.Visible = False
        '
        'colId
        '
        Me.colId.Text = "id"
        Me.colId.Width = 0
        '
        'colfecha
        '
        Me.colfecha.Text = "Fecha"
        Me.colfecha.Width = 145
        '
        'colCompra
        '
        Me.colCompra.Text = "Compra"
        Me.colCompra.Width = 90
        '
        'colventa
        '
        Me.colventa.Text = "Venta"
        Me.colventa.Width = 84
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(24, -15)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(347, 17)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(371, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(17, 2)
        Me.Panel3.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(24, 2)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbActivo)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.rbProduccion)
        Me.GroupBox1.Controls.Add(Me.rbProyecto)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(24, 300)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 111)
        Me.GroupBox1.TabIndex = 440
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HOJA DE COSTO"
        Me.GroupBox1.Visible = False
        '
        'rbActivo
        '
        Me.rbActivo.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.rbActivo.DrawFocusRectangle = False
        Me.rbActivo.Enabled = False
        Me.rbActivo.Location = New System.Drawing.Point(20, 77)
        Me.rbActivo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbActivo.Name = "rbActivo"
        Me.rbActivo.Size = New System.Drawing.Size(150, 21)
        Me.rbActivo.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.rbActivo.TabIndex = 5
        Me.rbActivo.Text = "Activo Fijo"
        Me.rbActivo.ThemesEnabled = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbFinanciero)
        Me.GroupBox2.Controls.Add(Me.rbVentas)
        Me.GroupBox2.Controls.Add(Me.rbAdmin)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(171, 111)
        Me.GroupBox2.TabIndex = 441
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HOJA DE GASTO"
        '
        'rbFinanciero
        '
        Me.rbFinanciero.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.rbFinanciero.DrawFocusRectangle = False
        Me.rbFinanciero.Enabled = False
        Me.rbFinanciero.Location = New System.Drawing.Point(20, 77)
        Me.rbFinanciero.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbFinanciero.Name = "rbFinanciero"
        Me.rbFinanciero.Size = New System.Drawing.Size(150, 21)
        Me.rbFinanciero.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.rbFinanciero.TabIndex = 6
        Me.rbFinanciero.Text = "Gasto financiero"
        Me.rbFinanciero.ThemesEnabled = False
        '
        'rbVentas
        '
        Me.rbVentas.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.rbVentas.DrawFocusRectangle = False
        Me.rbVentas.Enabled = False
        Me.rbVentas.Location = New System.Drawing.Point(20, 50)
        Me.rbVentas.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbVentas.Name = "rbVentas"
        Me.rbVentas.Size = New System.Drawing.Size(150, 21)
        Me.rbVentas.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.rbVentas.TabIndex = 5
        Me.rbVentas.Text = "Gasto de ventas"
        Me.rbVentas.ThemesEnabled = False
        '
        'rbAdmin
        '
        Me.rbAdmin.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.rbAdmin.DrawFocusRectangle = False
        Me.rbAdmin.Enabled = False
        Me.rbAdmin.Location = New System.Drawing.Point(20, 23)
        Me.rbAdmin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbAdmin.Name = "rbAdmin"
        Me.rbAdmin.Size = New System.Drawing.Size(150, 21)
        Me.rbAdmin.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.rbAdmin.TabIndex = 4
        Me.rbAdmin.Text = "Gasto administrativo"
        Me.rbAdmin.ThemesEnabled = False
        '
        'rbProduccion
        '
        Me.rbProduccion.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.rbProduccion.DrawFocusRectangle = False
        Me.rbProduccion.Enabled = False
        Me.rbProduccion.Location = New System.Drawing.Point(20, 50)
        Me.rbProduccion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbProduccion.Name = "rbProduccion"
        Me.rbProduccion.Size = New System.Drawing.Size(150, 21)
        Me.rbProduccion.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.rbProduccion.TabIndex = 4
        Me.rbProduccion.Text = "Orden de producción"
        Me.rbProduccion.ThemesEnabled = False
        '
        'rbProyecto
        '
        Me.rbProyecto.BeforeTouchSize = New System.Drawing.Size(150, 21)
        Me.rbProyecto.DrawFocusRectangle = False
        Me.rbProyecto.Enabled = False
        Me.rbProyecto.Location = New System.Drawing.Point(20, 23)
        Me.rbProyecto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbProyecto.Name = "rbProyecto"
        Me.rbProyecto.Size = New System.Drawing.Size(150, 21)
        Me.rbProyecto.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro
        Me.rbProyecto.TabIndex = 3
        Me.rbProyecto.Text = "Proyecto"
        Me.rbProyecto.ThemesEnabled = False
        '
        'pcNuevoEstablecimiento
        '
        Me.pcNuevoEstablecimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcNuevoEstablecimiento.Controls.Add(Me.cboTipoEstable)
        Me.pcNuevoEstablecimiento.Controls.Add(Me.Label38)
        Me.pcNuevoEstablecimiento.Controls.Add(Me.txtNewEstable)
        Me.pcNuevoEstablecimiento.Controls.Add(Me.Label39)
        Me.pcNuevoEstablecimiento.Controls.Add(Me.Panel16)
        Me.pcNuevoEstablecimiento.Controls.Add(Me.ButtonAdv4)
        Me.pcNuevoEstablecimiento.Controls.Add(Me.ButtonAdv2)
        Me.pcNuevoEstablecimiento.Location = New System.Drawing.Point(296, 367)
        Me.pcNuevoEstablecimiento.Name = "pcNuevoEstablecimiento"
        Me.pcNuevoEstablecimiento.Size = New System.Drawing.Size(115, 151)
        Me.pcNuevoEstablecimiento.TabIndex = 424
        Me.pcNuevoEstablecimiento.Visible = False
        '
        'cboTipoEstable
        '
        Me.cboTipoEstable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEstable.FormattingEnabled = True
        Me.cboTipoEstable.Location = New System.Drawing.Point(7, 92)
        Me.cboTipoEstable.Name = "cboTipoEstable"
        Me.cboTipoEstable.Size = New System.Drawing.Size(304, 21)
        Me.cboTipoEstable.TabIndex = 410
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(6, 74)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(32, 13)
        Me.Label38.TabIndex = 409
        Me.Label38.Text = "Tipo:"
        '
        'txtNewEstable
        '
        Me.txtNewEstable.BackColor = System.Drawing.Color.White
        Me.txtNewEstable.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.txtNewEstable.BorderColor = System.Drawing.Color.DarkGray
        Me.txtNewEstable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewEstable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewEstable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNewEstable.Location = New System.Drawing.Point(7, 48)
        Me.txtNewEstable.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtNewEstable.Name = "txtNewEstable"
        Me.txtNewEstable.Size = New System.Drawing.Size(304, 22)
        Me.txtNewEstable.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNewEstable.TabIndex = 408
        Me.txtNewEstable.TabStop = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(6, 30)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(51, 13)
        Me.Label39.TabIndex = 407
        Me.Label39.Text = "Nombre:"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Panel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel16.Controls.Add(Me.Label40)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(113, 24)
        Me.Panel16.TabIndex = 406
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label40.Location = New System.Drawing.Point(10, 3)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(143, 19)
        Me.Label40.TabIndex = 170
        Me.Label40.Text = "Nuevo establecimiento"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(254, 123)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.TabIndex = 209
        Me.ButtonAdv4.Text = "Cancelar"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(192, 123)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv2.TabIndex = 208
        Me.ButtonAdv2.Text = "OK"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(21, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 14)
        Me.Label2.TabIndex = 464
        Me.Label2.Text = "Identificar empresa"
        '
        'cboEstablecimiento
        '
        Me.cboEstablecimiento.BackColor = System.Drawing.Color.White
        Me.cboEstablecimiento.BeforeTouchSize = New System.Drawing.Size(307, 21)
        Me.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstablecimiento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstablecimiento.Location = New System.Drawing.Point(24, 99)
        Me.cboEstablecimiento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEstablecimiento.Name = "cboEstablecimiento"
        Me.cboEstablecimiento.Size = New System.Drawing.Size(307, 21)
        Me.cboEstablecimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEstablecimiento.TabIndex = 226
        '
        'cboEmpresa
        '
        Me.cboEmpresa.BackColor = System.Drawing.Color.White
        Me.cboEmpresa.BeforeTouchSize = New System.Drawing.Size(307, 21)
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresa.Location = New System.Drawing.Point(24, 44)
        Me.cboEmpresa.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(307, 21)
        Me.cboEmpresa.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEmpresa.TabIndex = 465
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(21, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 14)
        Me.Label5.TabIndex = 466
        Me.Label5.Text = "Establecimiento"
        '
        'PictureBox18
        '
        Me.PictureBox18.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(334, 99)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox18.TabIndex = 235
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'txtRenta4
        '
        Me.txtRenta4.BackColor = System.Drawing.Color.White
        Me.txtRenta4.BeforeTouchSize = New System.Drawing.Size(111, 22)
        Me.txtRenta4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRenta4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRenta4.DecimalPlaces = 2
        Me.txtRenta4.Enabled = False
        Me.txtRenta4.ForeColor = System.Drawing.Color.Black
        Me.txtRenta4.Location = New System.Drawing.Point(108, 154)
        Me.txtRenta4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRenta4.Name = "txtRenta4"
        Me.txtRenta4.Size = New System.Drawing.Size(111, 22)
        Me.txtRenta4.TabIndex = 437
        Me.txtRenta4.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtIva
        '
        Me.txtIva.BackColor = System.Drawing.Color.White
        Me.txtIva.BeforeTouchSize = New System.Drawing.Size(69, 22)
        Me.txtIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIva.DecimalPlaces = 2
        Me.txtIva.Enabled = False
        Me.txtIva.ForeColor = System.Drawing.Color.Black
        Me.txtIva.Location = New System.Drawing.Point(24, 154)
        Me.txtIva.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(69, 22)
        Me.txtIva.TabIndex = 425
        Me.txtIva.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(79, 59)
        Me.ButtonAdv3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.Image = CType(resources.GetObject("ButtonAdv3.Image"), System.Drawing.Image)
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(277, 201)
        Me.ButtonAdv3.MetroColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(79, 59)
        Me.ButtonAdv3.TabIndex = 471
        Me.ButtonAdv3.Text = "Guardar"
        Me.ButtonAdv3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'txtmontomaximo
        '
        Me.txtmontomaximo.BackColor = System.Drawing.Color.White
        Me.txtmontomaximo.BeforeTouchSize = New System.Drawing.Size(82, 22)
        Me.txtmontomaximo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtmontomaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmontomaximo.DecimalPlaces = 2
        Me.txtmontomaximo.Enabled = False
        Me.txtmontomaximo.ForeColor = System.Drawing.Color.Black
        Me.txtmontomaximo.Location = New System.Drawing.Point(234, 154)
        Me.txtmontomaximo.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.txtmontomaximo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtmontomaximo.Name = "txtmontomaximo"
        Me.txtmontomaximo.Size = New System.Drawing.Size(82, 22)
        Me.txtmontomaximo.TabIndex = 439
        Me.txtmontomaximo.Value = New Decimal(New Integer() {700, 0, 0, 0})
        Me.txtmontomaximo.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(25, 132)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 13)
        Me.Label31.TabIndex = 467
        Me.Label31.Text = "% - I.V.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(231, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 469
        Me.Label1.Text = "IDENTIFICAR CLIENTES"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(105, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 468
        Me.Label3.Text = "RENTA 4TA. CAT."
        '
        'CboAlmacen
        '
        Me.CboAlmacen.BackColor = System.Drawing.Color.White
        Me.CboAlmacen.BeforeTouchSize = New System.Drawing.Size(140, 19)
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAlmacen.Location = New System.Drawing.Point(-151, 11)
        Me.CboAlmacen.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(140, 19)
        Me.CboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboAlmacen.TabIndex = 228
        Me.CboAlmacen.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(-162, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(151, 12)
        Me.Label23.TabIndex = 227
        Me.Label23.Text = "ALMACEN (Solo para ventas) "
        Me.Label23.Visible = False
        '
        'PictureBox19
        '
        Me.PictureBox19.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(248, 65)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox19.TabIndex = 236
        Me.PictureBox19.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox19, "Agregar Año")
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(109, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(137, 65)
        Me.cboAnio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(109, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 233
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(264, 149)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 444
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Eliminar T/C")
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 25)
        Me.PictureBox1.TabIndex = 443
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Ver Lista T/C")
        Me.PictureBox1.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.PictureBox16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(292, 149)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox16.TabIndex = 423
        Me.PictureBox16.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox16, "Obtener último tipo de cambio")
        '
        'PictureBox17
        '
        Me.PictureBox17.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.PictureBox17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(236, 149)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox17.TabIndex = 422
        Me.PictureBox17.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox17, "Nuevo Tipo de cambio")
        '
        'txtFechaTC
        '
        Me.txtFechaTC.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtFechaTC.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaTC.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaTC.Calendar.AllowMultipleSelection = False
        Me.txtFechaTC.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaTC.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaTC.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaTC.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaTC.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaTC.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaTC.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTC.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaTC.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaTC.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaTC.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaTC.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.Name = "monthCalendar"
        Me.txtFechaTC.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaTC.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaTC.Calendar.Size = New System.Drawing.Size(88, 174)
        Me.txtFechaTC.Calendar.SizeToFit = True
        Me.txtFechaTC.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaTC.Calendar.TabIndex = 0
        Me.txtFechaTC.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaTC.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaTC.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaTC.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaTC.Calendar.NoneButton.Location = New System.Drawing.Point(16, 0)
        Me.txtFechaTC.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaTC.Calendar.NoneButton.Text = "None"
        Me.txtFechaTC.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaTC.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaTC.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaTC.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaTC.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaTC.Calendar.TodayButton.Size = New System.Drawing.Size(16, 20)
        Me.txtFechaTC.Calendar.TodayButton.Text = "Today"
        Me.txtFechaTC.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaTC.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTC.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaTC.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaTC.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaTC.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaTC.DropDownImage = Nothing
        Me.txtFechaTC.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaTC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTC.ForeColor = System.Drawing.Color.White
        Me.txtFechaTC.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaTC.Location = New System.Drawing.Point(12, 152)
        Me.txtFechaTC.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.MinValue = New Date(CType(0, Long))
        Me.txtFechaTC.Name = "txtFechaTC"
        Me.txtFechaTC.ReadOnly = True
        Me.txtFechaTC.ShowCheckBox = False
        Me.txtFechaTC.ShowDropButton = False
        Me.txtFechaTC.Size = New System.Drawing.Size(90, 22)
        Me.txtFechaTC.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaTC.TabIndex = 413
        Me.txtFechaTC.Value = New Date(2015, 9, 9, 21, 37, 56, 824)
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 472
        Me.Label4.Text = "Fecha Laboral"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(221, 26)
        Me.Label8.TabIndex = 473
        Me.Label8.Text = "Datos del t/c operación"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bgGeneral
        '
        Me.bgGeneral.WorkerReportsProgress = True
        Me.bgGeneral.WorkerSupportsCancellation = True
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.BackColor = System.Drawing.SystemColors.HotTrack
        Me.txtFechaInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaInicio.Calendar.AllowMultipleSelection = False
        Me.txtFechaInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.Name = "monthCalendar"
        Me.txtFechaInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaInicio.Calendar.Size = New System.Drawing.Size(118, 174)
        Me.txtFechaInicio.Calendar.SizeToFit = True
        Me.txtFechaInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.Calendar.TabIndex = 0
        Me.txtFechaInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaInicio.Calendar.NoneButton.Location = New System.Drawing.Point(46, 0)
        Me.txtFechaInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicio.Calendar.NoneButton.Text = "None"
        Me.txtFechaInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicio.Calendar.TodayButton.Size = New System.Drawing.Size(46, 20)
        Me.txtFechaInicio.Calendar.TodayButton.Text = "Today"
        Me.txtFechaInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.CustomFormat = "dd - MMMM"
        Me.txtFechaInicio.DropDownImage = Nothing
        Me.txtFechaInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicio.Location = New System.Drawing.Point(15, 65)
        Me.txtFechaInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.ShowCheckBox = False
        Me.txtFechaInicio.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.TabIndex = 476
        Me.txtFechaInicio.Value = New Date(2017, 2, 28, 10, 17, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(12, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 15)
        Me.Label7.TabIndex = 478
        Me.Label7.Text = "Tipo de cambio del día"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.Tomato
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(117, 35)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(129, 250)
        Me.ButtonAdv1.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(117, 35)
        Me.ButtonAdv1.TabIndex = 480
        Me.ButtonAdv1.Text = "Numeración " & Global.Microsoft.VisualBasic.ChrW(10) & "comprobantes"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.Visible = False
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.Gray
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(98, 35)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.Image = CType(resources.GetObject("ButtonAdv5.Image"), System.Drawing.Image)
        Me.ButtonAdv5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(249, 250)
        Me.ButtonAdv5.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(98, 35)
        Me.ButtonAdv5.TabIndex = 481
        Me.ButtonAdv5.Text = "Aporte de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Inicio"
        Me.ButtonAdv5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.Tomato
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(90, 35)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(156, 250)
        Me.ButtonAdv6.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(90, 35)
        Me.ButtonAdv6.TabIndex = 482
        Me.ButtonAdv6.Text = "Nueva " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "empresa"
        Me.ButtonAdv6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'nudTipoCambioCompra
        '
        Me.nudTipoCambioCompra.BackGroundColor = System.Drawing.Color.White
        Me.nudTipoCambioCompra.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.nudTipoCambioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.nudTipoCambioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioCompra.CurrencyDecimalDigits = 3
        Me.nudTipoCambioCompra.CurrencySymbol = "C- "
        Me.nudTipoCambioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudTipoCambioCompra.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.nudTipoCambioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioCompra.Location = New System.Drawing.Point(104, 152)
        Me.nudTipoCambioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudTipoCambioCompra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.nudTipoCambioCompra.Name = "nudTipoCambioCompra"
        Me.nudTipoCambioCompra.NullString = ""
        Me.nudTipoCambioCompra.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioCompra.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nudTipoCambioCompra.Size = New System.Drawing.Size(62, 22)
        Me.nudTipoCambioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.nudTipoCambioCompra.TabIndex = 494
        Me.nudTipoCambioCompra.Text = "C- 0.000"
        '
        'nudTipoCambioVenta
        '
        Me.nudTipoCambioVenta.BackGroundColor = System.Drawing.Color.White
        Me.nudTipoCambioVenta.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.nudTipoCambioVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.nudTipoCambioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioVenta.CurrencyDecimalDigits = 3
        Me.nudTipoCambioVenta.CurrencySymbol = "V- "
        Me.nudTipoCambioVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudTipoCambioVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.nudTipoCambioVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioVenta.Location = New System.Drawing.Point(171, 152)
        Me.nudTipoCambioVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudTipoCambioVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.nudTipoCambioVenta.Name = "nudTipoCambioVenta"
        Me.nudTipoCambioVenta.NullString = ""
        Me.nudTipoCambioVenta.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.nudTipoCambioVenta.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nudTipoCambioVenta.Size = New System.Drawing.Size(62, 22)
        Me.nudTipoCambioVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.nudTipoCambioVenta.TabIndex = 495
        Me.nudTipoCambioVenta.Text = "V- 0.000"
        '
        'frmInicioEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.MediumSeaGreen
        CaptionLabel1.Location = New System.Drawing.Point(55, 22)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Configuración"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.Gray
        CaptionLabel2.Location = New System.Drawing.Point(55, 8)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Fecha de trabajo"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(749, 297)
        Me.ControlBox = False
        Me.Controls.Add(Me.nudTipoCambioVenta)
        Me.Controls.Add(Me.nudTipoCambioCompra)
        Me.Controls.Add(Me.ButtonAdv6)
        Me.Controls.Add(Me.ButtonAdv5)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFechaInicio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox19)
        Me.Controls.Add(Me.cboAnio)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox16)
        Me.Controls.Add(Me.PictureBox17)
        Me.Controls.Add(Me.GradientPanel14)
        Me.Controls.Add(Me.GradientPanel12)
        Me.Controls.Add(Me.txtFechaTC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicioEmpresa"
        Me.ShowIcon = False
        Me.Text = "'"
        CType(Me.GradientPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel12.ResumeLayout(False)
        Me.GradientPanel12.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel14.ResumeLayout(False)
        Me.GradientPanel14.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.rbActivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.rbFinanciero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcNuevoEstablecimiento.ResumeLayout(False)
        Me.pcNuevoEstablecimiento.PerformLayout()
        CType(Me.txtNewEstable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        CType(Me.cboEstablecimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRenta4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmontomaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaTC.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambioVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel12 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblempresaNom As System.Windows.Forms.Label
    Friend WithEvents GradientPanel14 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtIva As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents pcNuevoEstablecimiento As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents cboTipoEstable As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtNewEstable As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Private WithEvents Panel16 As System.Windows.Forms.Panel
    Private WithEvents Label40 As System.Windows.Forms.Label
    Private WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFechaTC As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents CboAlmacen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboEstablecimiento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtRenta4 As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtmontomaximo As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbActivo As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents rbProduccion As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents rbProyecto As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents rbFinanciero As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents rbVentas As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents rbAdmin As Syncfusion.Windows.Forms.Tools.CheckBoxAdv
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lsvTipoCambio As System.Windows.Forms.ListView
    Friend WithEvents colId As System.Windows.Forms.ColumnHeader
    Friend WithEvents colfecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents colventa As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboEmpresa As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bgGeneral As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtFechaInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents nudTipoCambioCompra As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents nudTipoCambioVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class

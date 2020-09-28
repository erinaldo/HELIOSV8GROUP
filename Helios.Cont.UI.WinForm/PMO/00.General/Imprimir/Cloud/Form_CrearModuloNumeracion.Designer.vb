<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_CrearModuloNumeracion
    Inherits frmMaster

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_CrearModuloNumeracion))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboCargos = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtCodigoNum = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboUnidadNegocio = New System.Windows.Forms.ComboBox()
        Me.chAfectaUN = New System.Windows.Forms.CheckBox()
        Me.cboAreaOperativa = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton6 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.txtValorInicio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtValormaximo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFormato = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvCompras = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtCodigoNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValormaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboCargos)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.txtCodigoNum)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cboUnidadNegocio)
        Me.GroupBox3.Controls.Add(Me.chAfectaUN)
        Me.GroupBox3.Controls.Add(Me.cboAreaOperativa)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.BunifuFlatButton1)
        Me.GroupBox3.Controls.Add(Me.BunifuFlatButton6)
        Me.GroupBox3.Controls.Add(Me.txtValorInicio)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtValormaximo)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtSerie)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtFormato)
        Me.GroupBox3.Controls.Add(Me.cboTipo)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(431, 442)
        Me.GroupBox3.TabIndex = 438
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NUEVA NUMERACIÓN"
        '
        'cboCargos
        '
        Me.cboCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCargos.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.cboCargos.FormattingEnabled = True
        Me.cboCargos.Location = New System.Drawing.Point(23, 100)
        Me.cboCargos.Name = "cboCargos"
        Me.cboCargos.Size = New System.Drawing.Size(365, 22)
        Me.cboCargos.TabIndex = 486
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(20, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 14)
        Me.Label8.TabIndex = 487
        Me.Label8.Text = "Cargo"
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._0021
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(393, 277)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 22)
        Me.Button3.TabIndex = 485
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._0021
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(393, 154)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 22)
        Me.Button2.TabIndex = 484
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtCodigoNum
        '
        Me.txtCodigoNum.BackColor = System.Drawing.Color.White
        Me.txtCodigoNum.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtCodigoNum.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtCodigoNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoNum.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoNum.Location = New System.Drawing.Point(136, 214)
        Me.txtCodigoNum.Metrocolor = System.Drawing.Color.Silver
        Me.txtCodigoNum.Name = "txtCodigoNum"
        Me.txtCodigoNum.ReadOnly = True
        Me.txtCodigoNum.Size = New System.Drawing.Size(77, 22)
        Me.txtCodigoNum.TabIndex = 483
        Me.txtCodigoNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(133, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 482
        Me.Label5.Text = "Codigo Num."
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._0021
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(393, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 22)
        Me.Button1.TabIndex = 481
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboUnidadNegocio
        '
        Me.cboUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidadNegocio.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.cboUnidadNegocio.FormattingEnabled = True
        Me.cboUnidadNegocio.Location = New System.Drawing.Point(23, 277)
        Me.cboUnidadNegocio.Name = "cboUnidadNegocio"
        Me.cboUnidadNegocio.Size = New System.Drawing.Size(365, 22)
        Me.cboUnidadNegocio.TabIndex = 480
        Me.cboUnidadNegocio.Visible = False
        '
        'chAfectaUN
        '
        Me.chAfectaUN.AutoSize = True
        Me.chAfectaUN.Location = New System.Drawing.Point(23, 251)
        Me.chAfectaUN.Name = "chAfectaUN"
        Me.chAfectaUN.Size = New System.Drawing.Size(140, 20)
        Me.chAfectaUN.TabIndex = 479
        Me.chAfectaUN.Text = "Unidad Negocio"
        Me.chAfectaUN.UseVisualStyleBackColor = True
        '
        'cboAreaOperativa
        '
        Me.cboAreaOperativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAreaOperativa.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.cboAreaOperativa.FormattingEnabled = True
        Me.cboAreaOperativa.Location = New System.Drawing.Point(23, 49)
        Me.cboAreaOperativa.Name = "cboAreaOperativa"
        Me.cboAreaOperativa.Size = New System.Drawing.Size(365, 22)
        Me.cboAreaOperativa.TabIndex = 477
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(20, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 14)
        Me.Label7.TabIndex = 478
        Me.Label7.Text = "Area Operativa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(60, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 14)
        Me.Label4.TabIndex = 474
        Me.Label4.Text = "(Ingrese una Serie)"
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = "CERRAR"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(298, 397)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(118, 34)
        Me.BunifuFlatButton1.TabIndex = 473
        Me.BunifuFlatButton1.Text = "CERRAR"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton6
        '
        Me.BunifuFlatButton6.Activecolor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton6.BackColor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton6.BorderRadius = 5
        Me.BunifuFlatButton6.ButtonText = "GUARDAR"
        Me.BunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton6.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.Iconimage = Nothing
        Me.BunifuFlatButton6.Iconimage_right = Nothing
        Me.BunifuFlatButton6.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton6.Iconimage_Selected = Nothing
        Me.BunifuFlatButton6.IconMarginLeft = 0
        Me.BunifuFlatButton6.IconMarginRight = 0
        Me.BunifuFlatButton6.IconRightVisible = True
        Me.BunifuFlatButton6.IconRightZoom = 0R
        Me.BunifuFlatButton6.IconVisible = True
        Me.BunifuFlatButton6.IconZoom = 90.0R
        Me.BunifuFlatButton6.IsTab = False
        Me.BunifuFlatButton6.Location = New System.Drawing.Point(157, 397)
        Me.BunifuFlatButton6.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton6.Name = "BunifuFlatButton6"
        Me.BunifuFlatButton6.Normalcolor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton6.OnHovercolor = System.Drawing.Color.DarkGreen
        Me.BunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton6.selected = False
        Me.BunifuFlatButton6.Size = New System.Drawing.Size(137, 34)
        Me.BunifuFlatButton6.TabIndex = 472
        Me.BunifuFlatButton6.Text = "GUARDAR"
        Me.BunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton6.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton6.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'txtValorInicio
        '
        Me.txtValorInicio.BackColor = System.Drawing.Color.White
        Me.txtValorInicio.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtValorInicio.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtValorInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorInicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValorInicio.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorInicio.Location = New System.Drawing.Point(177, 337)
        Me.txtValorInicio.Metrocolor = System.Drawing.Color.Silver
        Me.txtValorInicio.Name = "txtValorInicio"
        Me.txtValorInicio.ReadOnly = True
        Me.txtValorInicio.Size = New System.Drawing.Size(63, 22)
        Me.txtValorInicio.TabIndex = 471
        Me.txtValorInicio.Text = "0"
        Me.txtValorInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(174, 320)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 14)
        Me.Label3.TabIndex = 470
        Me.Label3.Text = "Valor Inicial"
        '
        'txtValormaximo
        '
        Me.txtValormaximo.BackColor = System.Drawing.Color.White
        Me.txtValormaximo.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtValormaximo.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtValormaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValormaximo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValormaximo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValormaximo.Location = New System.Drawing.Point(250, 337)
        Me.txtValormaximo.Metrocolor = System.Drawing.Color.Silver
        Me.txtValormaximo.Name = "txtValormaximo"
        Me.txtValormaximo.ReadOnly = True
        Me.txtValormaximo.Size = New System.Drawing.Size(90, 22)
        Me.txtValormaximo.TabIndex = 469
        Me.txtValormaximo.Text = "99999999"
        Me.txtValormaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(247, 320)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 468
        Me.Label1.Text = "Valor Máximo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(20, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 14)
        Me.Label2.TabIndex = 467
        Me.Label2.Text = "Tipo Documento:"
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.DarkGreen
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtSerie.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.Color.White
        Me.txtSerie.Location = New System.Drawing.Point(23, 337)
        Me.txtSerie.MaxLength = 5
        Me.txtSerie.Metrocolor = System.Drawing.Color.Silver
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(136, 22)
        Me.txtSerie.TabIndex = 466
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(20, 320)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(34, 14)
        Me.Label24.TabIndex = 465
        Me.Label24.Text = "Serie:"
        '
        'txtFormato
        '
        Me.txtFormato.BackColor = System.Drawing.Color.White
        Me.txtFormato.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtFormato.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormato.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormato.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormato.Location = New System.Drawing.Point(23, 214)
        Me.txtFormato.Metrocolor = System.Drawing.Color.Silver
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.ReadOnly = True
        Me.txtFormato.Size = New System.Drawing.Size(102, 22)
        Me.txtFormato.TabIndex = 1
        Me.txtFormato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(23, 154)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(365, 22)
        Me.cboTipo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(20, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 14)
        Me.Label6.TabIndex = 455
        Me.Label6.Text = "Tipo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvCompras)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(453, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 442)
        Me.GroupBox1.TabIndex = 439
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DETALLES DE COMPROBANTES EXISTENTES"
        '
        'dgvCompras
        '
        Me.dgvCompras.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvCompras.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompras.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompras.BackColor = System.Drawing.Color.White
        Me.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCompras.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompras.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCompras.Location = New System.Drawing.Point(3, 18)
        Me.dgvCompras.Name = "dgvCompras"
        Me.dgvCompras.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCompras.Size = New System.Drawing.Size(350, 421)
        Me.dgvCompras.TabIndex = 301
        Me.dgvCompras.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor2.HeaderText = "DESCRIPCIÓN"
        GridColumnDescriptor2.MappingName = "DESCRIPCION"
        GridColumnDescriptor2.Name = "DESCRIPCION"
        GridColumnDescriptor2.Width = 300
        Me.dgvCompras.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2})
        Me.dgvCompras.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgvCompras.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompras.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCompras.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DESCRIPCION")})
        Me.dgvCompras.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvCompras.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgvCompras.Text = "gridGroupingControl1"
        Me.dgvCompras.UseRightToLeftCompatibleTextBox = True
        Me.dgvCompras.VersionInfo = "12.2400.0.20"
        '
        'Form_CrearModuloNumeracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CaptionBarColor = System.Drawing.Color.DarkGreen
        Me.CaptionBarHeight = 45
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(12, 2)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(50, 4)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Numeración"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.White
        CaptionLabel2.Location = New System.Drawing.Point(50, 18)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(300, 24)
        CaptionLabel2.Text = "Configuración"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(818, 463)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Form_CrearModuloNumeracion"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtCodigoNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValormaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtFormato As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtValorInicio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents txtValormaximo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Private WithEvents dgvCompras As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton6 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label4 As Label
    Friend WithEvents cboAreaOperativa As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chAfectaUN As CheckBox
    Friend WithEvents cboUnidadNegocio As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtCodigoNum As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cboCargos As ComboBox
    Friend WithEvents Label8 As Label
End Class

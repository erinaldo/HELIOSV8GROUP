<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tab_FormatoImpresion
    Inherits frmMaster

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_FormatoImpresion))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboFormato = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFormato = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.rbImagenTotal = New System.Windows.Forms.RadioButton()
        Me.rbSinImagen = New System.Windows.Forms.RadioButton()
        Me.rbConImagen = New System.Windows.Forms.RadioButton()
        Me.txtNroImpresion = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnLogo = New System.Windows.Forms.Panel()
        Me.chRectangular = New System.Windows.Forms.CheckBox()
        Me.chCuadrado = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chLogoIzq = New System.Windows.Forms.CheckBox()
        Me.chLogoCentro = New System.Windows.Forms.CheckBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFormato = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pcImagen = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLogo.SuspendLayout()
        CType(Me.txtRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboFormato)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtFormato)
        Me.GroupBox3.Controls.Add(Me.rbImagenTotal)
        Me.GroupBox3.Controls.Add(Me.rbSinImagen)
        Me.GroupBox3.Controls.Add(Me.rbConImagen)
        Me.GroupBox3.Controls.Add(Me.txtNroImpresion)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.pnLogo)
        Me.GroupBox3.Controls.Add(Me.cboTipo)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblFormato)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(416, 331)
        Me.GroupBox3.TabIndex = 438
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DATOS DE FORMATO DE IMPRESIÓN"
        '
        'cboFormato
        '
        Me.cboFormato.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.cboFormato.FormattingEnabled = True
        Me.cboFormato.Location = New System.Drawing.Point(98, 122)
        Me.cboFormato.Name = "cboFormato"
        Me.cboFormato.Size = New System.Drawing.Size(71, 22)
        Me.cboFormato.TabIndex = 466
        Me.cboFormato.Text = "1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(40, 125)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 14)
        Me.Label24.TabIndex = 465
        Me.Label24.Text = "Formato:"
        '
        'txtFormato
        '
        Me.txtFormato.BackColor = System.Drawing.Color.White
        Me.txtFormato.BeforeTouchSize = New System.Drawing.Size(342, 33)
        Me.txtFormato.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormato.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormato.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormato.Location = New System.Drawing.Point(98, 57)
        Me.txtFormato.Metrocolor = System.Drawing.Color.Silver
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(125, 22)
        Me.txtFormato.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFormato.TabIndex = 1
        '
        'rbImagenTotal
        '
        Me.rbImagenTotal.AutoSize = True
        Me.rbImagenTotal.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.rbImagenTotal.ForeColor = System.Drawing.Color.Black
        Me.rbImagenTotal.Location = New System.Drawing.Point(98, 212)
        Me.rbImagenTotal.Name = "rbImagenTotal"
        Me.rbImagenTotal.Size = New System.Drawing.Size(89, 18)
        Me.rbImagenTotal.TabIndex = 5
        Me.rbImagenTotal.Text = "Imagen Total"
        Me.rbImagenTotal.UseVisualStyleBackColor = True
        Me.rbImagenTotal.Visible = False
        '
        'rbSinImagen
        '
        Me.rbSinImagen.AutoSize = True
        Me.rbSinImagen.Checked = True
        Me.rbSinImagen.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.rbSinImagen.ForeColor = System.Drawing.Color.Black
        Me.rbSinImagen.Location = New System.Drawing.Point(98, 166)
        Me.rbSinImagen.Name = "rbSinImagen"
        Me.rbSinImagen.Size = New System.Drawing.Size(79, 18)
        Me.rbSinImagen.TabIndex = 3
        Me.rbSinImagen.TabStop = True
        Me.rbSinImagen.Text = "Sin Imagen"
        Me.rbSinImagen.UseVisualStyleBackColor = True
        '
        'rbConImagen
        '
        Me.rbConImagen.AutoSize = True
        Me.rbConImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.rbConImagen.ForeColor = System.Drawing.Color.Black
        Me.rbConImagen.Location = New System.Drawing.Point(98, 189)
        Me.rbConImagen.Name = "rbConImagen"
        Me.rbConImagen.Size = New System.Drawing.Size(60, 17)
        Me.rbConImagen.TabIndex = 4
        Me.rbConImagen.Text = "Imagen"
        Me.rbConImagen.UseVisualStyleBackColor = True
        '
        'txtNroImpresion
        '
        Me.txtNroImpresion.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.txtNroImpresion.Location = New System.Drawing.Point(98, 91)
        Me.txtNroImpresion.Name = "txtNroImpresion"
        Me.txtNroImpresion.Size = New System.Drawing.Size(79, 22)
        Me.txtNroImpresion.TabIndex = 2
        Me.txtNroImpresion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtNroImpresion.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(9, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 14)
        Me.Label18.TabIndex = 464
        Me.Label18.Text = "Nro. Impresión:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(59, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 14)
        Me.Label3.TabIndex = 463
        Me.Label3.Text = "Logo:"
        '
        'pnLogo
        '
        Me.pnLogo.Controls.Add(Me.chRectangular)
        Me.pnLogo.Controls.Add(Me.chCuadrado)
        Me.pnLogo.Controls.Add(Me.Label8)
        Me.pnLogo.Controls.Add(Me.Label7)
        Me.pnLogo.Controls.Add(Me.chLogoIzq)
        Me.pnLogo.Controls.Add(Me.chLogoCentro)
        Me.pnLogo.Controls.Add(Me.Panel7)
        Me.pnLogo.Controls.Add(Me.txtRuta)
        Me.pnLogo.Controls.Add(Me.Label4)
        Me.pnLogo.Location = New System.Drawing.Point(98, 236)
        Me.pnLogo.Name = "pnLogo"
        Me.pnLogo.Size = New System.Drawing.Size(295, 89)
        Me.pnLogo.TabIndex = 457
        Me.pnLogo.Visible = False
        '
        'chRectangular
        '
        Me.chRectangular.AutoSize = True
        Me.chRectangular.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.chRectangular.ForeColor = System.Drawing.Color.Black
        Me.chRectangular.Location = New System.Drawing.Point(187, 33)
        Me.chRectangular.Name = "chRectangular"
        Me.chRectangular.Size = New System.Drawing.Size(98, 18)
        Me.chRectangular.TabIndex = 468
        Me.chRectangular.Text = "RECTANGULAR"
        Me.chRectangular.UseVisualStyleBackColor = True
        '
        'chCuadrado
        '
        Me.chCuadrado.AutoSize = True
        Me.chCuadrado.Checked = True
        Me.chCuadrado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chCuadrado.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.chCuadrado.ForeColor = System.Drawing.Color.Black
        Me.chCuadrado.Location = New System.Drawing.Point(94, 33)
        Me.chCuadrado.Name = "chCuadrado"
        Me.chCuadrado.Size = New System.Drawing.Size(82, 18)
        Me.chCuadrado.TabIndex = 467
        Me.chCuadrado.Text = "CUADRADO"
        Me.chCuadrado.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(7, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 466
        Me.Label8.Text = "Forma de logo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 465
        Me.Label7.Text = "Ubicación Logo:"
        '
        'chLogoIzq
        '
        Me.chLogoIzq.AutoSize = True
        Me.chLogoIzq.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.chLogoIzq.ForeColor = System.Drawing.Color.Black
        Me.chLogoIzq.Location = New System.Drawing.Point(164, 58)
        Me.chLogoIzq.Name = "chLogoIzq"
        Me.chLogoIzq.Size = New System.Drawing.Size(80, 18)
        Me.chLogoIzq.TabIndex = 464
        Me.chLogoIzq.Text = "IZQUIERDA"
        Me.chLogoIzq.UseVisualStyleBackColor = True
        '
        'chLogoCentro
        '
        Me.chLogoCentro.AutoSize = True
        Me.chLogoCentro.Checked = True
        Me.chLogoCentro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chLogoCentro.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.chLogoCentro.ForeColor = System.Drawing.Color.Black
        Me.chLogoCentro.Location = New System.Drawing.Point(94, 58)
        Me.chLogoCentro.Name = "chLogoCentro"
        Me.chLogoCentro.Size = New System.Drawing.Size(66, 18)
        Me.chLogoCentro.TabIndex = 463
        Me.chLogoCentro.Text = "CENTRO"
        Me.chLogoCentro.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_buscar_compra1
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel7.Location = New System.Drawing.Point(263, 6)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(22, 22)
        Me.Panel7.TabIndex = 462
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.White
        Me.txtRuta.BeforeTouchSize = New System.Drawing.Size(342, 33)
        Me.txtRuta.BorderColor = System.Drawing.Color.Gainsboro
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuta.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuta.Location = New System.Drawing.Point(94, 6)
        Me.txtRuta.Metrocolor = System.Drawing.Color.Gainsboro
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(163, 22)
        Me.txtRuta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRuta.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(55, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 460
        Me.Label4.Text = "Ruta:"
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"A4", "Ticket", "A5"})
        Me.cboTipo.Location = New System.Drawing.Point(98, 29)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(125, 22)
        Me.cboTipo.TabIndex = 0
        Me.cboTipo.Text = "A4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(9, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 14)
        Me.Label6.TabIndex = 455
        Me.Label6.Text = "Tipo Impresión:"
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFormato.Location = New System.Drawing.Point(7, 65)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(85, 14)
        Me.lblFormato.TabIndex = 404
        Me.lblFormato.Text = "Giro (Opcional):"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_buscar_compra1
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(189, 212)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(16, 21)
        Me.Panel1.TabIndex = 467
        '
        'pcImagen
        '
        Me.pcImagen.Location = New System.Drawing.Point(16, 43)
        Me.pcImagen.Name = "pcImagen"
        Me.pcImagen.Size = New System.Drawing.Size(311, 143)
        Me.pcImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcImagen.TabIndex = 438
        Me.pcImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.pcImagen)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(438, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 331)
        Me.GroupBox1.TabIndex = 439
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATOS INFORMATIVOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "Imagen"
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_buscar_compra1
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel3.Location = New System.Drawing.Point(189, 288)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(16, 21)
        Me.Panel3.TabIndex = 472
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_buscar_compra1
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel4.Location = New System.Drawing.Point(189, 262)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(16, 21)
        Me.Panel4.TabIndex = 471
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_buscar_compra1
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Location = New System.Drawing.Point(189, 238)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(16, 21)
        Me.Panel2.TabIndex = 470
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Enabled = False
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.Black
        Me.RadioButton4.Location = New System.Drawing.Point(16, 292)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(166, 17)
        Me.RadioButton4.TabIndex = 469
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Formato 4 -Impresora Matricial"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Enabled = False
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New System.Drawing.Point(16, 265)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(133, 17)
        Me.RadioButton3.TabIndex = 468
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Formato 3 - Detracción"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(16, 242)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(115, 17)
        Me.RadioButton2.TabIndex = 467
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Formato 2 - Simple "
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Enabled = False
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(16, 216)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(124, 17)
        Me.RadioButton1.TabIndex = 466
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Formato 1 - Genérico"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 13)
        Me.Label1.TabIndex = 465
        Me.Label1.Text = "Leyenda (Formatos de Impresión)"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 353)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(787, 33)
        Me.GradientPanel2.TabIndex = 440
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 24)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(668, 6)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 24)
        Me.ButtonAdv2.TabIndex = 9
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 24)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(553, 6)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 24)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Tab_FormatoImpresion
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
        CaptionLabel1.Text = "Impresión"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.White
        CaptionLabel2.Location = New System.Drawing.Point(50, 18)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(300, 24)
        CaptionLabel2.Text = "Configuración formato de impresión"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(787, 386)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "Tab_FormatoImpresion"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLogo.ResumeLayout(False)
        Me.pnLogo.PerformLayout()
        CType(Me.txtRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboFormato As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtFormato As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents rbImagenTotal As RadioButton
    Friend WithEvents rbSinImagen As RadioButton
    Friend WithEvents rbConImagen As RadioButton
    Friend WithEvents txtNroImpresion As NumericUpDown
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pnLogo As Panel
    Friend WithEvents chRectangular As CheckBox
    Friend WithEvents chCuadrado As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents chLogoIzq As CheckBox
    Friend WithEvents chLogoCentro As CheckBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtRuta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblFormato As Label
    Friend WithEvents pcImagen As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class

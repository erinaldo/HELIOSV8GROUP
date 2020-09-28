<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCAsignarRuta
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Line22 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TextCodigoRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextSeriePlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ruta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Line23 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Line1 = New Helios.Cont.Presentation.WinForm.Line(Me.components)
        Me.Line24 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.IDHorario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.TextCodigoRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Line22)
        Me.GradientPanel1.Controls.Add(Me.LinkLabel4)
        Me.GradientPanel1.Controls.Add(Me.LinkLabel2)
        Me.GradientPanel1.Controls.Add(Me.LinkLabel1)
        Me.GradientPanel1.Controls.Add(Me.TextCodigoRuta)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.TextSeriePlaca)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(820, 75)
        Me.GradientPanel1.TabIndex = 2
        '
        'Line22
        '
        Me.Line22.LineColor = System.Drawing.Color.DarkGray
        Me.Line22.Location = New System.Drawing.Point(479, 50)
        Me.Line22.Name = "Line22"
        Me.Line22.Size = New System.Drawing.Size(1, 12)
        Me.Line22.TabIndex = 586
        Me.Line22.Text = "Line22"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel4.Location = New System.Drawing.Point(486, 49)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(38, 13)
        Me.LinkLabel4.TabIndex = 584
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Añadir"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel2.Location = New System.Drawing.Point(420, 49)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabel2.TabIndex = 582
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ver todos"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel1.Location = New System.Drawing.Point(420, 16)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(53, 13)
        Me.LinkLabel1.TabIndex = 581
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ver todos"
        '
        'TextCodigoRuta
        '
        Me.TextCodigoRuta.BackColor = System.Drawing.Color.White
        Me.TextCodigoRuta.BeforeTouchSize = New System.Drawing.Size(282, 24)
        Me.TextCodigoRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoRuta.CornerRadius = 4
        Me.TextCodigoRuta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoRuta.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.TextCodigoRuta.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoRuta.ForeColor = System.Drawing.Color.Black
        Me.TextCodigoRuta.Location = New System.Drawing.Point(116, 41)
        Me.TextCodigoRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoRuta.Name = "TextCodigoRuta"
        Me.TextCodigoRuta.Size = New System.Drawing.Size(282, 24)
        Me.TextCodigoRuta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCodigoRuta.TabIndex = 580
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "2. Codigo de ruta:"
        '
        'TextSeriePlaca
        '
        Me.TextSeriePlaca.BackColor = System.Drawing.Color.White
        Me.TextSeriePlaca.BeforeTouchSize = New System.Drawing.Size(282, 24)
        Me.TextSeriePlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSeriePlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSeriePlaca.CornerRadius = 4
        Me.TextSeriePlaca.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextSeriePlaca.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.TextSeriePlaca.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSeriePlaca.ForeColor = System.Drawing.Color.Black
        Me.TextSeriePlaca.Location = New System.Drawing.Point(116, 10)
        Me.TextSeriePlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSeriePlaca.Name = "TextSeriePlaca"
        Me.TextSeriePlaca.Size = New System.Drawing.Size(282, 24)
        Me.TextSeriePlaca.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextSeriePlaca.TabIndex = 578
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "1. Nro. serie/placa:"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(114, 33)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(672, 87)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(114, 33)
        Me.RoundButton21.TabIndex = 586
        Me.RoundButton21.Text = "Confirmar rutas"
        Me.RoundButton21.UseVisualStyle = True
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel6.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel6.Location = New System.Drawing.Point(116, 105)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(11, 13)
        Me.LinkLabel6.TabIndex = 585
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "/"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel5.Location = New System.Drawing.Point(129, 106)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(269, 13)
        Me.LinkLabel5.TabIndex = 583
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Confirmar los vehiculos para iniciar la venta de pasajes"
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ID, Me.Ruta, Me.KM, Me.IDHorario})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(21, 144)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(770, 323)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID auto"
        Me.ColumnHeader1.Width = 24
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Vehiculo"
        Me.ColumnHeader2.Width = 124
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Color"
        Me.ColumnHeader3.Width = 75
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Detalle"
        Me.ColumnHeader4.Width = 124
        '
        'ID
        '
        Me.ID.Text = "ID Ruta"
        Me.ID.Width = 26
        '
        'Ruta
        '
        Me.Ruta.Text = "Ruta"
        Me.Ruta.Width = 158
        '
        'KM
        '
        Me.KM.Text = "Kms."
        '
        'Line23
        '
        Me.Line23.LineColor = System.Drawing.Color.Silver
        Me.Line23.Location = New System.Drawing.Point(22, 128)
        Me.Line23.Name = "Line23"
        Me.Line23.Size = New System.Drawing.Size(764, 1)
        Me.Line23.TabIndex = 1
        Me.Line23.Text = "Line23"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(20, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Asignar rutas"
        '
        'Line24
        '
        Me.Line24.LineColor = System.Drawing.Color.Gray
        Me.Line24.Location = New System.Drawing.Point(722, 478)
        Me.Line24.Name = "Line24"
        Me.Line24.Size = New System.Drawing.Size(1, 12)
        Me.Line24.TabIndex = 589
        Me.Line24.Text = "Line24"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel7.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel7.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel7.Location = New System.Drawing.Point(637, 477)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(76, 13)
        Me.LinkLabel7.TabIndex = 588
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "Crear vehiculo"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel8.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel8.Location = New System.Drawing.Point(734, 477)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(57, 13)
        Me.LinkLabel8.TabIndex = 587
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "Crear ruta"
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(86, 33)
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(581, 87)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(86, 33)
        Me.RoundButton22.TabIndex = 590
        Me.RoundButton22.Text = "Quitar"
        Me.RoundButton22.UseVisualStyle = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'IDHorario
        '
        Me.IDHorario.Text = "IDHorario"
        Me.IDHorario.Width = 81
        '
        'TR_AsinarRutaVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.Line24)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.LinkLabel7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel6)
        Me.Controls.Add(Me.Line23)
        Me.Controls.Add(Me.LinkLabel8)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TR_AsinarRutaVehiculo"
        Me.Size = New System.Drawing.Size(820, 511)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.TextCodigoRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextSeriePlaca As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents TextCodigoRuta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Line23 As Line2
    Friend WithEvents Line1 As Line
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel6 As LinkLabel
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Line24 As Line2
    Friend WithEvents LinkLabel7 As LinkLabel
    Friend WithEvents LinkLabel8 As LinkLabel
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents Ruta As ColumnHeader
    Friend WithEvents KM As ColumnHeader
    Friend WithEvents Line22 As Line2
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents IDHorario As ColumnHeader
End Class

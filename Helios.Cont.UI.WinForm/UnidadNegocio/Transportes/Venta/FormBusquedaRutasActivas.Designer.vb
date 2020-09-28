Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBusquedaRutasActivas
    Inherits MetroForm

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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.bunifuFlatButton7 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comboDestino = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.idRuta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColRuta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIDHorario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHorario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.comboDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idRuta, Me.ColRuta, Me.colIDHorario, Me.colHorario})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(631, 311)
        Me.ListView1.TabIndex = 590
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'bunifuFlatButton7
        '
        Me.bunifuFlatButton7.Activecolor = System.Drawing.Color.White
        Me.bunifuFlatButton7.BackColor = System.Drawing.Color.White
        Me.bunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bunifuFlatButton7.BorderRadius = 0
        Me.bunifuFlatButton7.ButtonText = "RUTAS ACTIVAS"
        Me.bunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray
        Me.bunifuFlatButton7.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent
        Me.bunifuFlatButton7.Iconimage = Nothing
        Me.bunifuFlatButton7.Iconimage_right = Nothing
        Me.bunifuFlatButton7.Iconimage_right_Selected = Nothing
        Me.bunifuFlatButton7.Iconimage_Selected = Nothing
        Me.bunifuFlatButton7.IconMarginLeft = 0
        Me.bunifuFlatButton7.IconMarginRight = 0
        Me.bunifuFlatButton7.IconRightVisible = True
        Me.bunifuFlatButton7.IconRightZoom = 0R
        Me.bunifuFlatButton7.IconVisible = True
        Me.bunifuFlatButton7.IconZoom = 90.0R
        Me.bunifuFlatButton7.IsTab = False
        Me.bunifuFlatButton7.Location = New System.Drawing.Point(20, 61)
        Me.bunifuFlatButton7.Margin = New System.Windows.Forms.Padding(2)
        Me.bunifuFlatButton7.Name = "bunifuFlatButton7"
        Me.bunifuFlatButton7.Normalcolor = System.Drawing.Color.White
        Me.bunifuFlatButton7.OnHovercolor = System.Drawing.Color.White
        Me.bunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bunifuFlatButton7.selected = False
        Me.bunifuFlatButton7.Size = New System.Drawing.Size(103, 18)
        Me.bunifuFlatButton7.TabIndex = 592
        Me.bunifuFlatButton7.Text = "RUTAS ACTIVAS"
        Me.bunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bunifuFlatButton7.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bunifuFlatButton7.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "HOY"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(136, 61)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(103, 18)
        Me.BunifuFlatButton1.TabIndex = 593
        Me.BunifuFlatButton1.Text = "HOY"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(19, 82)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(105, 6)
        Me.sliderTop.TabIndex = 594
        Me.sliderTop.TabStop = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ListView1)
        Me.GradientPanel1.Location = New System.Drawing.Point(19, 88)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(633, 313)
        Me.GradientPanel1.TabIndex = 595
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 596
        Me.Label1.Text = "Destino"
        '
        'comboDestino
        '
        Me.comboDestino.BackColor = System.Drawing.Color.White
        Me.comboDestino.BeforeTouchSize = New System.Drawing.Size(219, 21)
        Me.comboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDestino.Enabled = False
        Me.comboDestino.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboDestino.Location = New System.Drawing.Point(20, 30)
        Me.comboDestino.MetroBorderColor = System.Drawing.Color.Silver
        Me.comboDestino.Name = "comboDestino"
        Me.comboDestino.Size = New System.Drawing.Size(219, 21)
        Me.comboDestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.comboDestino.TabIndex = 597
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.SystemColors.HotTrack
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(85, 23)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(245, 28)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(85, 23)
        Me.RoundButton21.TabIndex = 598
        Me.RoundButton21.Text = "Consultar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'idRuta
        '
        Me.idRuta.Text = "idruta"
        '
        'ColRuta
        '
        Me.ColRuta.Text = "Ruta"
        Me.ColRuta.Width = 217
        '
        'colIDHorario
        '
        Me.colIDHorario.Text = "IDHora"
        '
        'colHorario
        '
        Me.colHorario.Text = "Horario"
        Me.colHorario.Width = 207
        '
        'FormBusquedaRutasActivas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 426)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.comboDestino)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.sliderTop)
        Me.Controls.Add(Me.BunifuFlatButton1)
        Me.Controls.Add(Me.bunifuFlatButton7)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormBusquedaRutasActivas"
        Me.ShowIcon = False
        Me.Text = "Rutas activas"
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.comboDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As ListView
    Private WithEvents bunifuFlatButton7 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents comboDestino As Tools.ComboBoxAdv
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents idRuta As ColumnHeader
    Friend WithEvents ColRuta As ColumnHeader
    Friend WithEvents colIDHorario As ColumnHeader
    Friend WithEvents colHorario As ColumnHeader
End Class

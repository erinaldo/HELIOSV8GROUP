<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCGuiaDestinatario
    Inherits System.Windows.Forms.UserControl

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
        Me.txtdirecciodesti = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUbigDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.txtdirecPartida = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtUbiRemit = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.txtdirecciodesti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUbigDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdirecPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUbiRemit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtdirecciodesti
        '
        Me.txtdirecciodesti.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdirecciodesti.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtdirecciodesti.BorderColor = System.Drawing.Color.Silver
        Me.txtdirecciodesti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdirecciodesti.CornerRadius = 4
        Me.txtdirecciodesti.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdirecciodesti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdirecciodesti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdirecciodesti.Location = New System.Drawing.Point(11, 73)
        Me.txtdirecciodesti.MaxLength = 180
        Me.txtdirecciodesti.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdirecciodesti.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdirecciodesti.Name = "txtdirecciodesti"
        Me.txtdirecciodesti.Size = New System.Drawing.Size(305, 23)
        Me.txtdirecciodesti.TabIndex = 686
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 13)
        Me.Label9.TabIndex = 685
        Me.Label9.Text = "Dirección  llegada"
        '
        'txtUbigDestino
        '
        Me.txtUbigDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtUbigDestino.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtUbigDestino.BorderColor = System.Drawing.Color.Silver
        Me.txtUbigDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUbigDestino.CornerRadius = 4
        Me.txtUbigDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtUbigDestino.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbigDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUbigDestino.Location = New System.Drawing.Point(11, 27)
        Me.txtUbigDestino.MaxLength = 180
        Me.txtUbigDestino.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtUbigDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtUbigDestino.Name = "txtUbigDestino"
        Me.txtUbigDestino.Size = New System.Drawing.Size(116, 23)
        Me.txtUbigDestino.TabIndex = 673
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "Punto de llegada"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(11, 7)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(100, 18)
        Me.BunifuFlatButton3.TabIndex = 656
        Me.BunifuFlatButton3.Text = "Punto de llegada"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.SystemColors.HotTrack
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'txtdirecPartida
        '
        Me.txtdirecPartida.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdirecPartida.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtdirecPartida.BorderColor = System.Drawing.Color.Silver
        Me.txtdirecPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdirecPartida.CornerRadius = 4
        Me.txtdirecPartida.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdirecPartida.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdirecPartida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdirecPartida.Location = New System.Drawing.Point(8, 73)
        Me.txtdirecPartida.MaxLength = 180
        Me.txtdirecPartida.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdirecPartida.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdirecPartida.Name = "txtdirecPartida"
        Me.txtdirecPartida.Size = New System.Drawing.Size(263, 23)
        Me.txtdirecPartida.TabIndex = 852
        '
        'txtUbiRemit
        '
        Me.txtUbiRemit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtUbiRemit.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtUbiRemit.BorderColor = System.Drawing.Color.Silver
        Me.txtUbiRemit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUbiRemit.CornerRadius = 4
        Me.txtUbiRemit.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtUbiRemit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbiRemit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUbiRemit.Location = New System.Drawing.Point(7, 31)
        Me.txtUbiRemit.MaxLength = 180
        Me.txtUbiRemit.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtUbiRemit.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtUbiRemit.Name = "txtUbiRemit"
        Me.txtUbiRemit.Size = New System.Drawing.Size(153, 23)
        Me.txtUbiRemit.TabIndex = 850
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "Punto de partida"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Nothing
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(9, 11)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(100, 18)
        Me.BunifuFlatButton2.TabIndex = 849
        Me.BunifuFlatButton2.Text = "Punto de partida"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.SystemColors.HotTrack
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 851
        Me.Label6.Text = "Dirección partida"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.txtUbiRemit)
        Me.GradientPanel3.Controls.Add(Me.txtdirecPartida)
        Me.GradientPanel3.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel3.Controls.Add(Me.Label6)
        Me.GradientPanel3.Location = New System.Drawing.Point(21, 18)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(280, 110)
        Me.GradientPanel3.TabIndex = 686
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtdirecciodesti)
        Me.GradientPanel1.Controls.Add(Me.txtUbigDestino)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton3)
        Me.GradientPanel1.Location = New System.Drawing.Point(312, 18)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(328, 110)
        Me.GradientPanel1.TabIndex = 687
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UCGuiaDestinatario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Name = "UCGuiaDestinatario"
        Me.Size = New System.Drawing.Size(660, 146)
        CType(Me.txtdirecciodesti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUbigDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdirecPartida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUbiRemit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtdirecciodesti As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Friend WithEvents txtUbigDestino As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtdirecPartida As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtUbiRemit As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label6 As Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class

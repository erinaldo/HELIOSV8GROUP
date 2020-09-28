Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVentaBusquedaAvanzada
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVentaBusquedaAvanzada))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboFiltros = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvCategoria = New System.Windows.Forms.ListBox()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv10 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 216)
        Me.Panel1.TabIndex = 228
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(24, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "BÚSQUEDA AVANZADA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(834, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "X"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(536, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Estado"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(34, 73)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(189, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 229
        Me.Label1.Text = "FILTRAR POR"
        '
        'ComboFiltros
        '
        Me.ComboFiltros.BackColor = System.Drawing.Color.White
        Me.ComboFiltros.BeforeTouchSize = New System.Drawing.Size(253, 21)
        Me.ComboFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFiltros.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFiltros.Items.AddRange(New Object() {"CLASIFICACION", "MARCA"})
        Me.ComboFiltros.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFiltros, "CLASIFICACION"))
        Me.ComboFiltros.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFiltros, "MARCA"))
        Me.ComboFiltros.Location = New System.Drawing.Point(192, 45)
        Me.ComboFiltros.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboFiltros.Name = "ComboFiltros"
        Me.ComboFiltros.Size = New System.Drawing.Size(253, 21)
        Me.ComboFiltros.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboFiltros.TabIndex = 230
        Me.ComboFiltros.Text = "CLASIFICACION"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.White
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFiltrar.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtFiltrar.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.Location = New System.Drawing.Point(192, 99)
        Me.txtFiltrar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(253, 22)
        Me.txtFiltrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFiltrar.TabIndex = 401
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(189, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 402
        Me.Label2.Text = "DESCRIPCIÓN BÚSQUEDA"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(94, 46)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(218, 158)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(94, 46)
        Me.RoundButton21.TabIndex = 403
        Me.RoundButton21.Text = "ACEPTAR"
        Me.RoundButton21.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RoundButton21.UseVisualStyle = True
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcLikeCategoria.Controls.Add(Me.lsvCategoria)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv3)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv10)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(475, 158)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(193, 80)
        Me.pcLikeCategoria.TabIndex = 491
        Me.pcLikeCategoria.Visible = False
        '
        'lsvCategoria
        '
        Me.lsvCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvCategoria.FormattingEnabled = True
        Me.lsvCategoria.Location = New System.Drawing.Point(0, 0)
        Me.lsvCategoria.Name = "lsvCategoria"
        Me.lsvCategoria.Size = New System.Drawing.Size(191, 104)
        Me.lsvCategoria.TabIndex = 3
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.TabIndex = 2
        Me.ButtonAdv3.Text = "Cancel"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'ButtonAdv10
        '
        Me.ButtonAdv10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv10.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv10.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv10.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv10.IsBackStageButton = False
        Me.ButtonAdv10.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv10.Name = "ButtonAdv10"
        Me.ButtonAdv10.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.TabIndex = 1
        Me.ButtonAdv10.Text = "OK"
        Me.ButtonAdv10.UseVisualStyle = True
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.DimGray
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(94, 46)
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.Image = CType(resources.GetObject("RoundButton22.Image"), System.Drawing.Image)
        Me.RoundButton22.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(318, 158)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(94, 46)
        Me.RoundButton22.TabIndex = 492
        Me.RoundButton22.Text = "CANCELAR"
        Me.RoundButton22.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RoundButton22.UseVisualStyle = True
        '
        'FormVentaBusquedaAvanzada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(461, 216)
        Me.ControlBox = False
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFiltrar)
        Me.Controls.Add(Me.ComboFiltros)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormVentaBusquedaAvanzada"
        Me.ShowIcon = False
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboFiltros As Tools.ComboBoxAdv
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents lsvCategoria As ListBox
    Private WithEvents ButtonAdv3 As ButtonAdv
    Private WithEvents ButtonAdv10 As ButtonAdv
    Friend WithEvents RoundButton22 As RoundButton2
End Class

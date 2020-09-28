Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOrganigrama
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOrganigrama))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.cbtipoMuni = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cbSubNiveles = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton9 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton8 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton7 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboBoxAdv2 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.cbtipoMuni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSubNiveles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbtipoMuni
        '
        Me.cbtipoMuni.BackColor = System.Drawing.Color.White
        Me.cbtipoMuni.BeforeTouchSize = New System.Drawing.Size(204, 21)
        Me.cbtipoMuni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipoMuni.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtipoMuni.Location = New System.Drawing.Point(6, 90)
        Me.cbtipoMuni.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cbtipoMuni.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbtipoMuni.Name = "cbtipoMuni"
        Me.cbtipoMuni.Size = New System.Drawing.Size(204, 21)
        Me.cbtipoMuni.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbtipoMuni.TabIndex = 852
        '
        'cbSubNiveles
        '
        Me.cbSubNiveles.BackColor = System.Drawing.Color.White
        Me.cbSubNiveles.BeforeTouchSize = New System.Drawing.Size(310, 21)
        Me.cbSubNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSubNiveles.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubNiveles.Location = New System.Drawing.Point(219, 36)
        Me.cbSubNiveles.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cbSubNiveles.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbSubNiveles.Name = "cbSubNiveles"
        Me.cbSubNiveles.Size = New System.Drawing.Size(310, 21)
        Me.cbSubNiveles.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbSubNiveles.TabIndex = 867
        Me.cbSubNiveles.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(912, 8)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 868
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton9)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton8)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton7)
        Me.GradientPanel1.Controls.Add(Me.PictureBox9)
        Me.GradientPanel1.Controls.Add(Me.sliderTop)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(832, 38)
        Me.GradientPanel1.TabIndex = 857
        '
        'BunifuFlatButton9
        '
        Me.BunifuFlatButton9.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton9.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton9.BorderRadius = 0
        Me.BunifuFlatButton9.ButtonText = "MOSTRAR ARBOL"
        Me.BunifuFlatButton9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton9.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton9.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton9.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton9.Iconimage = Nothing
        Me.BunifuFlatButton9.Iconimage_right = Nothing
        Me.BunifuFlatButton9.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton9.Iconimage_Selected = Nothing
        Me.BunifuFlatButton9.IconMarginLeft = 0
        Me.BunifuFlatButton9.IconMarginRight = 0
        Me.BunifuFlatButton9.IconRightVisible = True
        Me.BunifuFlatButton9.IconRightZoom = 0R
        Me.BunifuFlatButton9.IconVisible = True
        Me.BunifuFlatButton9.IconZoom = 90.0R
        Me.BunifuFlatButton9.IsTab = False
        Me.BunifuFlatButton9.Location = New System.Drawing.Point(234, 8)
        Me.BunifuFlatButton9.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton9.Name = "BunifuFlatButton9"
        Me.BunifuFlatButton9.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton9.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton9.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton9.selected = False
        Me.BunifuFlatButton9.Size = New System.Drawing.Size(90, 18)
        Me.BunifuFlatButton9.TabIndex = 872
        Me.BunifuFlatButton9.Text = "MOSTRAR ARBOL"
        Me.BunifuFlatButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton9.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton9.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton8
        '
        Me.BunifuFlatButton8.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton8.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton8.BorderRadius = 0
        Me.BunifuFlatButton8.ButtonText = "UNI. ORG. ESPEC"
        Me.BunifuFlatButton8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton8.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton8.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton8.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton8.Iconimage = Nothing
        Me.BunifuFlatButton8.Iconimage_right = Nothing
        Me.BunifuFlatButton8.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton8.Iconimage_Selected = Nothing
        Me.BunifuFlatButton8.IconMarginLeft = 0
        Me.BunifuFlatButton8.IconMarginRight = 0
        Me.BunifuFlatButton8.IconRightVisible = True
        Me.BunifuFlatButton8.IconRightZoom = 0R
        Me.BunifuFlatButton8.IconVisible = True
        Me.BunifuFlatButton8.IconZoom = 90.0R
        Me.BunifuFlatButton8.IsTab = False
        Me.BunifuFlatButton8.Location = New System.Drawing.Point(121, 9)
        Me.BunifuFlatButton8.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton8.Name = "BunifuFlatButton8"
        Me.BunifuFlatButton8.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton8.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton8.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton8.selected = False
        Me.BunifuFlatButton8.Size = New System.Drawing.Size(90, 17)
        Me.BunifuFlatButton8.TabIndex = 871
        Me.BunifuFlatButton8.Text = "UNI. ORG. ESPEC"
        Me.BunifuFlatButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton8.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton8.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton7
        '
        Me.BunifuFlatButton7.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton7.BorderRadius = 0
        Me.BunifuFlatButton7.ButtonText = "UNI. ORGANICA"
        Me.BunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton7.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.Iconimage = Nothing
        Me.BunifuFlatButton7.Iconimage_right = Nothing
        Me.BunifuFlatButton7.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton7.Iconimage_Selected = Nothing
        Me.BunifuFlatButton7.IconMarginLeft = 0
        Me.BunifuFlatButton7.IconMarginRight = 0
        Me.BunifuFlatButton7.IconRightVisible = True
        Me.BunifuFlatButton7.IconRightZoom = 0R
        Me.BunifuFlatButton7.IconVisible = True
        Me.BunifuFlatButton7.IconZoom = 90.0R
        Me.BunifuFlatButton7.IsTab = False
        Me.BunifuFlatButton7.Location = New System.Drawing.Point(12, 8)
        Me.BunifuFlatButton7.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton7.Name = "BunifuFlatButton7"
        Me.BunifuFlatButton7.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton7.selected = False
        Me.BunifuFlatButton7.Size = New System.Drawing.Size(90, 18)
        Me.BunifuFlatButton7.TabIndex = 870
        Me.BunifuFlatButton7.Text = "UNI. ORGANICA"
        Me.BunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton7.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton7.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(10, 31)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(97, 5)
        Me.sliderTop.TabIndex = 867
        Me.sliderTop.TabStop = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(832, 468)
        Me.Panel1.TabIndex = 869
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(310, 21)
        Me.ComboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(219, 36)
        Me.ComboBoxAdv1.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ComboBoxAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(310, 21)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 867
        Me.ComboBoxAdv1.Visible = False
        '
        'ComboBoxAdv2
        '
        Me.ComboBoxAdv2.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv2.BeforeTouchSize = New System.Drawing.Size(204, 21)
        Me.ComboBoxAdv2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv2.Location = New System.Drawing.Point(6, 90)
        Me.ComboBoxAdv2.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ComboBoxAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ComboBoxAdv2.Name = "ComboBoxAdv2"
        Me.ComboBoxAdv2.Size = New System.Drawing.Size(204, 21)
        Me.ComboBoxAdv2.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv2.TabIndex = 852
        '
        'FormOrganigrama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Teal
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "ORGANIGRAMA"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(832, 506)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "FormOrganigrama"
        Me.ShowIcon = False
        CType(Me.cbtipoMuni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSubNiveles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbtipoMuni As Tools.ComboBoxAdv
    Friend WithEvents cbSubNiveles As Tools.ComboBoxAdv
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBoxAdv1 As Tools.ComboBoxAdv
    Friend WithEvents ComboBoxAdv2 As Tools.ComboBoxAdv
    Private WithEvents sliderTop As PictureBox
    Private WithEvents BunifuFlatButton7 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton9 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton8 As Bunifu.Framework.UI.BunifuFlatButton
End Class

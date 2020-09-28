<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptLibroMayor
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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptLibroMayor))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.rptLibroMayor = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboAnios = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.rbPorCuenta = New System.Windows.Forms.RadioButton()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.rbTodo = New System.Windows.Forms.RadioButton()
        Me.cboCuentas = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.rbMensual = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.cboAnios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptLibroMayor
        '
        Me.rptLibroMayor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptLibroMayor.Location = New System.Drawing.Point(90, 157)
        Me.rptLibroMayor.Name = "rptLibroMayor"
        Me.rptLibroMayor.Size = New System.Drawing.Size(806, 299)
        Me.rptLibroMayor.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(896, 157)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 299)
        Me.Panel4.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 157)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 299)
        Me.Panel3.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 129)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(986, 28)
        Me.Panel2.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.rbMensual)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboMes)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cboAnios)
        Me.Panel1.Controls.Add(Me.rbPorCuenta)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.rbTodo)
        Me.Panel1.Controls.Add(Me.cboCuentas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 129)
        Me.Panel1.TabIndex = 5
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(38, 12)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(922, 37)
        Me.GradientPanel1.TabIndex = 258
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LIBRO MAYOR"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(167, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 12)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "AÑO"
        '
        'cboAnios
        '
        Me.cboAnios.BackColor = System.Drawing.Color.White
        Me.cboAnios.BeforeTouchSize = New System.Drawing.Size(94, 21)
        Me.cboAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnios.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnios.Location = New System.Drawing.Point(165, 80)
        Me.cboAnios.Name = "cboAnios"
        Me.cboAnios.Size = New System.Drawing.Size(94, 21)
        Me.cboAnios.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnios.TabIndex = 256
        '
        'rbPorCuenta
        '
        Me.rbPorCuenta.AutoSize = True
        Me.rbPorCuenta.Location = New System.Drawing.Point(41, 62)
        Me.rbPorCuenta.Name = "rbPorCuenta"
        Me.rbPorCuenta.Size = New System.Drawing.Size(82, 17)
        Me.rbPorCuenta.TabIndex = 68
        Me.rbPorCuenta.Text = "Por Cuenta"
        Me.rbPorCuenta.UseVisualStyleBackColor = True
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(452, 69)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.TabIndex = 255
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.Checked = True
        Me.rbTodo.Location = New System.Drawing.Point(41, 84)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(50, 17)
        Me.rbTodo.TabIndex = 67
        Me.rbTodo.TabStop = True
        Me.rbTodo.Text = "Todo"
        Me.rbTodo.UseVisualStyleBackColor = True
        '
        'cboCuentas
        '
        Me.cboCuentas.Enabled = False
        Me.cboCuentas.FormattingEnabled = True
        Me.cboCuentas.Location = New System.Drawing.Point(271, 80)
        Me.cboCuentas.Name = "cboCuentas"
        Me.cboCuentas.Size = New System.Drawing.Size(137, 21)
        Me.cboCuentas.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(289, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 12)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "MES"
        Me.Label2.Visible = False
        '
        'cboMes
        '
        Me.cboMes.BackColor = System.Drawing.Color.White
        Me.cboMes.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "ENERO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "FEBRERO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "MARZO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "ABRIL"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "MAYO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "JUNIO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "JULIO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "AGOSTO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "SETIEMBRE"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "OCTUBRE"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "NOVIEMBRE"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "DICIEMBRE"))
        Me.cboMes.Location = New System.Drawing.Point(291, 80)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(121, 21)
        Me.cboMes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMes.TabIndex = 260
        Me.cboMes.Text = "ENERO"
        Me.cboMes.Visible = False
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(41, 106)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(69, 17)
        Me.rbMensual.TabIndex = 261
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'frmRptLibroMayor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        CaptionLabel1.Location = New System.Drawing.Point(65, 22)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Reporte"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(986, 456)
        Me.Controls.Add(Me.rptLibroMayor)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmRptLibroMayor"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.cboAnios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents rptLibroMayor As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rbPorCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents cboCuentas As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboAnios As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMes As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton

End Class

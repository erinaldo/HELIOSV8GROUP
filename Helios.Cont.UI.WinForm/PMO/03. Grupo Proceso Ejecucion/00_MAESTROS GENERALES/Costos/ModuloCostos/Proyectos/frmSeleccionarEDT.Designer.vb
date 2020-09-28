<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarEDT
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSubProyecto = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboProyectoGeneral = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboElemento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEntregable = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTipoProy = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.cboSubProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProyectoGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboElemento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntregable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(19, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Proyecto General"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(19, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Sub proyecto"
        '
        'cboSubProyecto
        '
        Me.cboSubProyecto.BackColor = System.Drawing.Color.White
        Me.cboSubProyecto.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboSubProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubProyecto.FlatBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.cboSubProyecto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubProyecto.Location = New System.Drawing.Point(22, 95)
        Me.cboSubProyecto.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboSubProyecto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboSubProyecto.Name = "cboSubProyecto"
        Me.cboSubProyecto.Size = New System.Drawing.Size(294, 21)
        Me.cboSubProyecto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboSubProyecto.TabIndex = 454
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.SeaGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(119, 37)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(172, 246)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(119, 37)
        Me.ButtonAdv1.TabIndex = 506
        Me.ButtonAdv1.Text = "Aceptar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cboProyectoGeneral
        '
        Me.cboProyectoGeneral.BackColor = System.Drawing.Color.White
        Me.cboProyectoGeneral.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboProyectoGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectoGeneral.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProyectoGeneral.Location = New System.Drawing.Point(22, 45)
        Me.cboProyectoGeneral.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboProyectoGeneral.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboProyectoGeneral.Name = "cboProyectoGeneral"
        Me.cboProyectoGeneral.Size = New System.Drawing.Size(294, 21)
        Me.cboProyectoGeneral.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboProyectoGeneral.TabIndex = 507
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.SeaGreen
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(101, 21)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(319, 45)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(101, 21)
        Me.ButtonAdv2.TabIndex = 508
        Me.ButtonAdv2.Text = "Ver Sub proyectos"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'cboElemento
        '
        Me.cboElemento.BackColor = System.Drawing.Color.White
        Me.cboElemento.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboElemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboElemento.FlatBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.cboElemento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboElemento.Location = New System.Drawing.Point(21, 205)
        Me.cboElemento.MetroBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.cboElemento.MetroColor = System.Drawing.Color.MediumSeaGreen
        Me.cboElemento.Name = "cboElemento"
        Me.cboElemento.Size = New System.Drawing.Size(294, 21)
        Me.cboElemento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboElemento.TabIndex = 510
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(19, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 14)
        Me.Label3.TabIndex = 511
        Me.Label3.Text = "Elemento del Costo"
        '
        'cboEntregable
        '
        Me.cboEntregable.BackColor = System.Drawing.Color.White
        Me.cboEntregable.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboEntregable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntregable.FlatBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.cboEntregable.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntregable.Location = New System.Drawing.Point(22, 147)
        Me.cboEntregable.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboEntregable.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboEntregable.Name = "cboEntregable"
        Me.cboEntregable.Size = New System.Drawing.Size(294, 21)
        Me.cboEntregable.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntregable.TabIndex = 513
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(19, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 14)
        Me.Label4.TabIndex = 512
        Me.Label4.Text = "Entregable / producto terminado"
        '
        'txtTipoProy
        '
        Me.txtTipoProy.Location = New System.Drawing.Point(322, 146)
        Me.txtTipoProy.Name = "txtTipoProy"
        Me.txtTipoProy.ReadOnly = True
        Me.txtTipoProy.Size = New System.Drawing.Size(101, 22)
        Me.txtTipoProy.TabIndex = 514
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(328, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 515
        Me.Label2.Text = "Tipo Costo"
        '
        'frmSeleccionarEDT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(432, 288)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTipoProy)
        Me.Controls.Add(Me.cboEntregable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboElemento)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.cboProyectoGeneral)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.cboSubProyecto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionarEDT"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.cboSubProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProyectoGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboElemento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntregable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSubProyecto As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboProyectoGeneral As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboElemento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEntregable As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipoProy As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class

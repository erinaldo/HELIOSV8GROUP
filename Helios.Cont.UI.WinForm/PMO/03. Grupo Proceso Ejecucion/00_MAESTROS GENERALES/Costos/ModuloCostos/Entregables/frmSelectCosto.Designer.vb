<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectCosto
    Inherits frmMaster

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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTipoProy = New System.Windows.Forms.TextBox()
        Me.cboEntregable = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProyectoGeneral = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboSubProyecto = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.cboEntregable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboProyectoGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSubProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(351, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 14)
        Me.Label7.TabIndex = 576
        Me.Label7.Text = "Estado Entregable"
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(345, 132)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(101, 22)
        Me.txtEstado.TabIndex = 575
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(517, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 574
        Me.Label2.Text = "Tipo Costo"
        '
        'txtTipoProy
        '
        Me.txtTipoProy.Location = New System.Drawing.Point(511, 102)
        Me.txtTipoProy.Name = "txtTipoProy"
        Me.txtTipoProy.ReadOnly = True
        Me.txtTipoProy.Size = New System.Drawing.Size(101, 22)
        Me.txtTipoProy.TabIndex = 573
        '
        'cboEntregable
        '
        Me.cboEntregable.BackColor = System.Drawing.Color.White
        Me.cboEntregable.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboEntregable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntregable.FlatBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.cboEntregable.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntregable.Location = New System.Drawing.Point(34, 133)
        Me.cboEntregable.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboEntregable.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboEntregable.Name = "cboEntregable"
        Me.cboEntregable.Size = New System.Drawing.Size(294, 21)
        Me.cboEntregable.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntregable.TabIndex = 572
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(31, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 14)
        Me.Label4.TabIndex = 571
        Me.Label4.Text = "Entregable / producto terminado"
        '
        'cboProyectoGeneral
        '
        Me.cboProyectoGeneral.BackColor = System.Drawing.Color.White
        Me.cboProyectoGeneral.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboProyectoGeneral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProyectoGeneral.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProyectoGeneral.Location = New System.Drawing.Point(34, 31)
        Me.cboProyectoGeneral.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboProyectoGeneral.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboProyectoGeneral.Name = "cboProyectoGeneral"
        Me.cboProyectoGeneral.Size = New System.Drawing.Size(294, 21)
        Me.cboProyectoGeneral.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboProyectoGeneral.TabIndex = 570
        '
        'cboSubProyecto
        '
        Me.cboSubProyecto.BackColor = System.Drawing.Color.White
        Me.cboSubProyecto.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboSubProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubProyecto.FlatBorderColor = System.Drawing.Color.MediumSeaGreen
        Me.cboSubProyecto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubProyecto.Location = New System.Drawing.Point(34, 81)
        Me.cboSubProyecto.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboSubProyecto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboSubProyecto.Name = "cboSubProyecto"
        Me.cboSubProyecto.Size = New System.Drawing.Size(294, 21)
        Me.cboSubProyecto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboSubProyecto.TabIndex = 569
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(31, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 14)
        Me.Label1.TabIndex = 568
        Me.Label1.Text = "Sub proyecto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(31, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 567
        Me.Label5.Text = "Proyecto General"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(119, 37)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(34, 171)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(119, 37)
        Me.ButtonAdv1.TabIndex = 577
        Me.ButtonAdv1.Text = "Aceptar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(345, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 578
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmSelectCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarHeight = 50
        Me.ClientSize = New System.Drawing.Size(458, 213)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTipoProy)
        Me.Controls.Add(Me.cboEntregable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboProyectoGeneral)
        Me.Controls.Add(Me.cboSubProyecto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmSelectCosto"
        Me.ShowIcon = False
        Me.Text = "Seleccion de Costo"
        CType(Me.cboEntregable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboProyectoGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSubProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTipoProy As TextBox
    Friend WithEvents cboEntregable As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents cboProyectoGeneral As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboSubProyecto As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Button1 As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteSaldoMercaderia
    Inherits System.Windows.Forms.Form

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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rptMercaderias = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(900, 124)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 355)
        Me.Panel4.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 124)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 355)
        Me.Panel3.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(990, 28)
        Me.Panel2.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboTipoExistencia)
        Me.Panel1.Controls.Add(Me.Label46)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.cboAlmacen)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 96)
        Me.Panel1.TabIndex = 12
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(211, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(407, 69)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(211, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 431
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(404, 50)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(79, 13)
        Me.Label46.TabIndex = 430
        Me.Label46.Text = "Tipo Existencia"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(101, 25)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(632, 65)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(101, 25)
        Me.ButtonAdv1.TabIndex = 429
        Me.ButtonAdv1.Text = "Consultar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(228, 21)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(162, 69)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(228, 21)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 428
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(159, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 427
        Me.Label4.Text = "Almacén"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(117, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(605, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "LIBRO DE INVENTARIOS Y BALANCES - DETALLE DEL SALDO DE LA CUENTA 20-21-22-24-25-2" & _
    "6-27"
        '
        'rptMercaderias
        '
        Me.rptMercaderias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptMercaderias.Location = New System.Drawing.Point(90, 124)
        Me.rptMercaderias.Name = "rptMercaderias"
        Me.rptMercaderias.Size = New System.Drawing.Size(810, 355)
        Me.rptMercaderias.TabIndex = 16
        '
        'frmReporteSaldoMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 479)
        Me.Controls.Add(Me.rptMercaderias)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReporteSaldoMercaderia"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboAlmacen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents rptMercaderias As Microsoft.Reporting.WinForms.ReportViewer

End Class

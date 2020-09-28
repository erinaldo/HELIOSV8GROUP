<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEnviosPendientesPse
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEnviosPendientesPse))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAnulados = New System.Windows.Forms.Label()
        Me.lblCpe = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.buttonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblAnulados)
        Me.Panel1.Controls.Add(Me.lblCpe)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.buttonAdv3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(473, 51)
        Me.Panel1.TabIndex = 0
        '
        'lblAnulados
        '
        Me.lblAnulados.AutoSize = True
        Me.lblAnulados.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnulados.ForeColor = System.Drawing.Color.Gold
        Me.lblAnulados.Location = New System.Drawing.Point(402, 14)
        Me.lblAnulados.Name = "lblAnulados"
        Me.lblAnulados.Size = New System.Drawing.Size(23, 25)
        Me.lblAnulados.TabIndex = 140
        Me.lblAnulados.Tag = "0"
        Me.lblAnulados.Text = "0"
        '
        'lblCpe
        '
        Me.lblCpe.AutoSize = True
        Me.lblCpe.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpe.ForeColor = System.Drawing.Color.Gold
        Me.lblCpe.Location = New System.Drawing.Point(195, 15)
        Me.lblCpe.Name = "lblCpe"
        Me.lblCpe.Size = New System.Drawing.Size(23, 25)
        Me.lblCpe.TabIndex = 0
        Me.lblCpe.Tag = "0"
        Me.lblCpe.Text = "0"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.Tomato
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(135, 31)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(255, 11)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(135, 31)
        Me.ButtonAdv1.TabIndex = 139
        Me.ButtonAdv1.Text = "ANULADOS"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'buttonAdv3
        '
        Me.buttonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.buttonAdv3.BackColor = System.Drawing.Color.DarkOrchid
        Me.buttonAdv3.BeforeTouchSize = New System.Drawing.Size(135, 31)
        Me.buttonAdv3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonAdv3.ForeColor = System.Drawing.Color.White
        Me.buttonAdv3.Image = CType(resources.GetObject("buttonAdv3.Image"), System.Drawing.Image)
        Me.buttonAdv3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonAdv3.IsBackStageButton = False
        Me.buttonAdv3.Location = New System.Drawing.Point(48, 10)
        Me.buttonAdv3.Name = "buttonAdv3"
        Me.buttonAdv3.Size = New System.Drawing.Size(135, 31)
        Me.buttonAdv3.TabIndex = 138
        Me.buttonAdv3.Text = "CPE"
        Me.buttonAdv3.UseVisualStyle = True
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 51)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(473, 292)
        Me.PanelBody.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Location = New System.Drawing.Point(-67, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1109, 3)
        Me.Panel2.TabIndex = 5
        '
        'FormEnviosPendientesPse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BorderColor = System.Drawing.Color.Gold
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gold
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(350, 24)
        CaptionLabel1.Text = "CPE Pendientes De Envio"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(473, 343)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormEnviosPendientesPse"
        Me.ShowIcon = False
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelBody As Panel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents buttonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents Panel2 As Panel
    Friend WithEvents lblAnulados As Label
    Friend WithEvents lblCpe As Label
End Class

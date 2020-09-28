<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalEmpresa))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNomCorto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFono = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtActividad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDomicilio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboRegimen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomCorto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRegimen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nro. - R.U.C.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre/Razón Social:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Otra descripción:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Domicilio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Teléfono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(131, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Actividad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Régimen:"
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtRuc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.Location = New System.Drawing.Point(15, 53)
        Me.txtRuc.MaxLength = 11
        Me.txtRuc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(140, 20)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtRuc.TabIndex = 7
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtRazon.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtRazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRazon.Location = New System.Drawing.Point(15, 99)
        Me.txtRazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(293, 20)
        Me.txtRazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtRazon.TabIndex = 8
        '
        'txtNomCorto
        '
        Me.txtNomCorto.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtNomCorto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNomCorto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtNomCorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomCorto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomCorto.Location = New System.Drawing.Point(15, 148)
        Me.txtNomCorto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNomCorto.Name = "txtNomCorto"
        Me.txtNomCorto.Size = New System.Drawing.Size(293, 20)
        Me.txtNomCorto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtNomCorto.TabIndex = 9
        '
        'txtFono
        '
        Me.txtFono.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtFono.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtFono.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtFono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFono.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFono.Location = New System.Drawing.Point(15, 195)
        Me.txtFono.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFono.Name = "txtFono"
        Me.txtFono.Size = New System.Drawing.Size(111, 20)
        Me.txtFono.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtFono.TabIndex = 10
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtActividad.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtActividad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividad.Location = New System.Drawing.Point(134, 195)
        Me.txtActividad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(174, 20)
        Me.txtActividad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtActividad.TabIndex = 11
        '
        'txtDomicilio
        '
        Me.txtDomicilio.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.txtDomicilio.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtDomicilio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDomicilio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDomicilio.Location = New System.Drawing.Point(15, 240)
        Me.txtDomicilio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(293, 20)
        Me.txtDomicilio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Office2007
        Me.txtDomicilio.TabIndex = 12
        '
        'cboRegimen
        '
        Me.cboRegimen.BackColor = System.Drawing.Color.White
        Me.cboRegimen.BeforeTouchSize = New System.Drawing.Size(293, 21)
        Me.cboRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegimen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRegimen.Items.AddRange(New Object() {"REGIMEN GENERAL", "REGIMEN ESPECIAL", "NUEVO RUS"})
        Me.cboRegimen.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboRegimen, "REGIMEN GENERAL"))
        Me.cboRegimen.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboRegimen, "REGIMEN ESPECIAL"))
        Me.cboRegimen.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboRegimen, "NUEVO RUS"))
        Me.cboRegimen.Location = New System.Drawing.Point(15, 284)
        Me.cboRegimen.Name = "cboRegimen"
        Me.cboRegimen.Size = New System.Drawing.Size(293, 21)
        Me.cboRegimen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboRegimen.TabIndex = 13
        Me.cboRegimen.Text = "REGIMEN GENERAL"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(327, 25)
        Me.ToolStrip3.TabIndex = 418
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.SaveToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.SaveToolStripButton.Text = "&Grabar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'frmModalEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 317)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.cboRegimen)
        Me.Controls.Add(Me.txtDomicilio)
        Me.Controls.Add(Me.txtActividad)
        Me.Controls.Add(Me.txtFono)
        Me.Controls.Add(Me.txtNomCorto)
        Me.Controls.Add(Me.txtRazon)
        Me.Controls.Add(Me.txtRuc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalEmpresa"
        Me.Text = "Empresa"
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomCorto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActividad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRegimen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtRazon As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNomCorto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtFono As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtActividad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtDomicilio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboRegimen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
End Class

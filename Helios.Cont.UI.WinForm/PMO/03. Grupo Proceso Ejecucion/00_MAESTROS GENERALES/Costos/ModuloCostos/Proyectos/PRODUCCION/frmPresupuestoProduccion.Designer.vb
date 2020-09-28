<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresupuestoProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPresupuestoProduccion))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.cboEntregable = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cbotipoRecurso = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtCategoria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtActividadActual = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.cboEntregable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbotipoRecurso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActividadActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboEntregable
        '
        Me.cboEntregable.BackColor = System.Drawing.Color.White
        Me.cboEntregable.BeforeTouchSize = New System.Drawing.Size(313, 21)
        Me.cboEntregable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntregable.DropDownWidth = 350
        Me.cboEntregable.Enabled = False
        Me.cboEntregable.FlatBorderColor = System.Drawing.Color.SeaGreen
        Me.cboEntregable.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntregable.Location = New System.Drawing.Point(32, 39)
        Me.cboEntregable.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEntregable.Name = "cboEntregable"
        Me.cboEntregable.Size = New System.Drawing.Size(313, 21)
        Me.cboEntregable.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntregable.TabIndex = 506
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 13)
        Me.Label4.TabIndex = 505
        Me.Label4.Text = "Entregable / Producto Terminado"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(111, 40)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(133, 254)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(111, 40)
        Me.ButtonAdv1.TabIndex = 504
        Me.ButtonAdv1.Text = "Grabar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'cbotipoRecurso
        '
        Me.cbotipoRecurso.BackColor = System.Drawing.Color.White
        Me.cbotipoRecurso.BeforeTouchSize = New System.Drawing.Size(250, 21)
        Me.cbotipoRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipoRecurso.DropDownWidth = 350
        Me.cbotipoRecurso.FlatBorderColor = System.Drawing.Color.SeaGreen
        Me.cbotipoRecurso.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipoRecurso.Items.AddRange(New Object() {"INVENTARIO", "MANO DE OBRA", "ACTIVOS INMOVILIZADOS", "TERCEROS"})
        Me.cbotipoRecurso.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipoRecurso, "INVENTARIO"))
        Me.cbotipoRecurso.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipoRecurso, "MANO DE OBRA"))
        Me.cbotipoRecurso.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipoRecurso, "ACTIVOS INMOVILIZADOS"))
        Me.cbotipoRecurso.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cbotipoRecurso, "TERCEROS"))
        Me.cbotipoRecurso.Location = New System.Drawing.Point(32, 204)
        Me.cbotipoRecurso.MetroBorderColor = System.Drawing.Color.Silver
        Me.cbotipoRecurso.Name = "cbotipoRecurso"
        Me.cbotipoRecurso.Size = New System.Drawing.Size(250, 21)
        Me.cbotipoRecurso.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbotipoRecurso.TabIndex = 503
        Me.cbotipoRecurso.Text = "INVENTARIO"
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.White
        Me.txtCategoria.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCategoria.BorderColor = System.Drawing.Color.Silver
        Me.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCategoria.Location = New System.Drawing.Point(32, 151)
        Me.txtCategoria.Metrocolor = System.Drawing.Color.Silver
        Me.txtCategoria.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.NearImage = CType(resources.GetObject("txtCategoria.NearImage"), System.Drawing.Image)
        Me.txtCategoria.Size = New System.Drawing.Size(313, 22)
        Me.txtCategoria.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCategoria.TabIndex = 497
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Tipo Recurso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Recurso a asignar"
        '
        'txtActividadActual
        '
        Me.txtActividadActual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtActividadActual.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtActividadActual.BorderColor = System.Drawing.Color.Silver
        Me.txtActividadActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActividadActual.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActividadActual.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtActividadActual.Location = New System.Drawing.Point(32, 98)
        Me.txtActividadActual.Metrocolor = System.Drawing.Color.Silver
        Me.txtActividadActual.Name = "txtActividadActual"
        Me.txtActividadActual.ReadOnly = True
        Me.txtActividadActual.Size = New System.Drawing.Size(313, 22)
        Me.txtActividadActual.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtActividadActual.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proceso / EDT"
        '
        'frmPresupuestoProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.OrangeRed
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Asignar Recurso"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.OrangeRed
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Presupuesto"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(371, 306)
        Me.Controls.Add(Me.cboEntregable)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.cbotipoRecurso)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActividadActual)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPresupuestoProduccion"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.cboEntregable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbotipoRecurso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActividadActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtActividadActual As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCategoria As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cbotipoRecurso As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboEntregable As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
End Class

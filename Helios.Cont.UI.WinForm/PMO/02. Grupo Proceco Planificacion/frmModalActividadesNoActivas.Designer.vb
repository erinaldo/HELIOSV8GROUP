<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalActividadesNoActivas
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalActividadesNoActivas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBUscar = New System.Windows.Forms.TextBox()
        Me.lsvModalBusqueda = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.coDescrip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.lblFase = New System.Windows.Forms.Label()
        Me.txtFase = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lblIdPadre = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Buscar:"
        '
        'txtBUscar
        '
        Me.txtBUscar.Location = New System.Drawing.Point(51, 88)
        Me.txtBUscar.Name = "txtBUscar"
        Me.txtBUscar.Size = New System.Drawing.Size(355, 20)
        Me.txtBUscar.TabIndex = 62
        '
        'lsvModalBusqueda
        '
        Me.lsvModalBusqueda.CheckBoxes = True
        Me.lsvModalBusqueda.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.coDescrip})
        Me.lsvModalBusqueda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lsvModalBusqueda.FullRowSelect = True
        Me.lsvModalBusqueda.GridLines = True
        Me.lsvModalBusqueda.HideSelection = False
        Me.lsvModalBusqueda.Location = New System.Drawing.Point(0, 141)
        Me.lsvModalBusqueda.MultiSelect = False
        Me.lsvModalBusqueda.Name = "lsvModalBusqueda"
        Me.lsvModalBusqueda.Size = New System.Drawing.Size(532, 225)
        Me.lsvModalBusqueda.TabIndex = 63
        Me.lsvModalBusqueda.UseCompatibleStateImageBehavior = False
        Me.lsvModalBusqueda.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'coDescrip
        '
        Me.coDescrip.Text = "Actividades"
        Me.coDescrip.Width = 533
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(2, 125)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(67, 13)
        Me.LinkLabel1.TabIndex = 64
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Enlazar todo"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.Location = New System.Drawing.Point(73, 125)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(85, 13)
        Me.LinkLabel2.TabIndex = 65
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Desenalzar todo"
        '
        'lblFase
        '
        Me.lblFase.AutoSize = True
        Me.lblFase.Location = New System.Drawing.Point(14, 66)
        Me.lblFase.Name = "lblFase"
        Me.lblFase.Size = New System.Drawing.Size(34, 13)
        Me.lblFase.TabIndex = 66
        Me.lblFase.Text = "Fase:"
        '
        'txtFase
        '
        Me.txtFase.Location = New System.Drawing.Point(51, 62)
        Me.txtFase.Name = "txtFase"
        Me.txtFase.ReadOnly = True
        Me.txtFase.Size = New System.Drawing.Size(355, 20)
        Me.txtFase.TabIndex = 67
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(532, 25)
        Me.ToolStrip1.TabIndex = 60
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(261, 22)
        Me.lblEstado.Text = "Búsqueda interactiva - (double click para seleccionar)"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.navBG
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.toolStripSeparator, Me.GuardarToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.GuardarToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(532, 25)
        Me.ToolStrip2.TabIndex = 59
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(93, 22)
        Me.lblTitulo.Text = "Actividades: EDT."
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Salir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GuardarToolStripButton1
        '
        Me.GuardarToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton1.Image = CType(resources.GetObject("GuardarToolStripButton1.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton1.Name = "GuardarToolStripButton1"
        Me.GuardarToolStripButton1.Size = New System.Drawing.Size(135, 22)
        Me.GuardarToolStripButton1.Text = "&Guardar seleccionados"
        '
        'lblIdPadre
        '
        Me.lblIdPadre.AutoSize = True
        Me.lblIdPadre.Location = New System.Drawing.Point(412, 66)
        Me.lblIdPadre.Name = "lblIdPadre"
        Me.lblIdPadre.Size = New System.Drawing.Size(19, 13)
        Me.lblIdPadre.TabIndex = 68
        Me.lblIdPadre.Text = "00"
        Me.lblIdPadre.Visible = False
        '
        'frmModalActividadesNoActivas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(532, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblIdPadre)
        Me.Controls.Add(Me.txtFase)
        Me.Controls.Add(Me.lblFase)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lsvModalBusqueda)
        Me.Controls.Add(Me.txtBUscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmModalActividadesNoActivas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBUscar As System.Windows.Forms.TextBox
    Friend WithEvents lsvModalBusqueda As System.Windows.Forms.ListView
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents coDescrip As System.Windows.Forms.ColumnHeader
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblFase As System.Windows.Forms.Label
    Friend WithEvents txtFase As System.Windows.Forms.TextBox
    Friend WithEvents lblIdPadre As System.Windows.Forms.Label
    Friend WithEvents GuardarToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class

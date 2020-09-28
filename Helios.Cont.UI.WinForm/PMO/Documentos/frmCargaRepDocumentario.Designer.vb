<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaRepDocumentario
    Inherits Helios.Cont.Presentation.WinForm.frmBase

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
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.btnExplorar = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblEtiqueta = New System.Windows.Forms.Label()
        Me.lblClaves = New System.Windows.Forms.Label()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.txtEtiqueta = New System.Windows.Forms.TextBox()
        Me.txtClaves = New System.Windows.Forms.TextBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        CType(Me.scPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scPrincipal.Panel1.SuspendLayout()
        Me.scPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'scPrincipal
        '
        '
        'scPrincipal.Panel1
        '
        Me.scPrincipal.Panel1.Controls.Add(Me.txtComentario)
        Me.scPrincipal.Panel1.Controls.Add(Me.txtClaves)
        Me.scPrincipal.Panel1.Controls.Add(Me.txtEtiqueta)
        Me.scPrincipal.Panel1.Controls.Add(Me.lblComentario)
        Me.scPrincipal.Panel1.Controls.Add(Me.lblClaves)
        Me.scPrincipal.Panel1.Controls.Add(Me.lblEtiqueta)
        Me.scPrincipal.Panel1.Controls.Add(Me.btnExplorar)
        Me.scPrincipal.Panel1.Controls.Add(Me.txtArchivo)
        Me.scPrincipal.Panel1.Controls.Add(Me.lblArchivo)
        Me.scPrincipal.Panel2Collapsed = True
        Me.scPrincipal.Size = New System.Drawing.Size(499, 296)
        Me.scPrincipal.SplitterDistance = 387
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(26, 16)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
        Me.lblArchivo.TabIndex = 0
        Me.lblArchivo.Text = "Archivo"
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(94, 16)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(344, 20)
        Me.txtArchivo.TabIndex = 1
        '
        'btnExplorar
        '
        Me.btnExplorar.Location = New System.Drawing.Point(445, 16)
        Me.btnExplorar.Name = "btnExplorar"
        Me.btnExplorar.Size = New System.Drawing.Size(29, 20)
        Me.btnExplorar.TabIndex = 2
        Me.btnExplorar.Text = "..."
        Me.btnExplorar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblEtiqueta
        '
        Me.lblEtiqueta.AutoSize = True
        Me.lblEtiqueta.Location = New System.Drawing.Point(26, 51)
        Me.lblEtiqueta.Name = "lblEtiqueta"
        Me.lblEtiqueta.Size = New System.Drawing.Size(47, 13)
        Me.lblEtiqueta.TabIndex = 3
        Me.lblEtiqueta.Text = "Etiqueta"
        '
        'lblClaves
        '
        Me.lblClaves.AutoSize = True
        Me.lblClaves.Location = New System.Drawing.Point(26, 185)
        Me.lblClaves.Name = "lblClaves"
        Me.lblClaves.Size = New System.Drawing.Size(213, 13)
        Me.lblClaves.TabIndex = 4
        Me.lblClaves.Text = "Palabras Claves (para buscar este archivo)"
        '
        'lblComentario
        '
        Me.lblComentario.AutoSize = True
        Me.lblComentario.Location = New System.Drawing.Point(26, 76)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Size = New System.Drawing.Size(67, 13)
        Me.lblComentario.TabIndex = 5
        Me.lblComentario.Text = "Comentarios"
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(94, 43)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(128, 20)
        Me.txtEtiqueta.TabIndex = 7
        '
        'txtClaves
        '
        Me.txtClaves.Location = New System.Drawing.Point(29, 201)
        Me.txtClaves.Multiline = True
        Me.txtClaves.Name = "txtClaves"
        Me.txtClaves.Size = New System.Drawing.Size(445, 75)
        Me.txtClaves.TabIndex = 8
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(29, 92)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(445, 75)
        Me.txtComentario.TabIndex = 9
        '
        'frmCargaRepDocumentario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 368)
        Me.Name = "frmCargaRepDocumentario"
        Me.Text = "frmCargaRepDocumentario"
        Me.scPrincipal.Panel1.ResumeLayout(False)
        Me.scPrincipal.Panel1.PerformLayout()
        CType(Me.scPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPrincipal.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents txtClaves As System.Windows.Forms.TextBox
    Friend WithEvents txtEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents lblComentario As System.Windows.Forms.Label
    Friend WithEvents lblClaves As System.Windows.Forms.Label
    Friend WithEvents lblEtiqueta As System.Windows.Forms.Label
    Friend WithEvents btnExplorar As System.Windows.Forms.Button
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class

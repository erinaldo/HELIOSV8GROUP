<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaSobrante
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
        Me.lsvNotificaciones = New System.Windows.Forms.ListView()
        Me.idDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.glosa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.idEmpresa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.idCentroCosto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.serie = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.numeroDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nombreProveedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lsvNotificaciones
        '
        Me.lsvNotificaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.idDocumento, Me.glosa, Me.idEmpresa, Me.idCentroCosto, Me.serie, Me.numeroDoc, Me.nombreProveedor, Me.ColumnHeader1})
        Me.lsvNotificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvNotificaciones.FullRowSelect = True
        Me.lsvNotificaciones.Location = New System.Drawing.Point(0, 0)
        Me.lsvNotificaciones.MultiSelect = False
        Me.lsvNotificaciones.Name = "lsvNotificaciones"
        Me.lsvNotificaciones.Size = New System.Drawing.Size(527, 327)
        Me.lsvNotificaciones.TabIndex = 0
        Me.lsvNotificaciones.UseCompatibleStateImageBehavior = False
        Me.lsvNotificaciones.View = System.Windows.Forms.View.Details
        '
        'idDocumento
        '
        Me.idDocumento.Text = "idDocumento"
        Me.idDocumento.Width = 50
        '
        'glosa
        '
        Me.glosa.DisplayIndex = 5
        Me.glosa.Text = "glosa"
        Me.glosa.Width = 500
        '
        'idEmpresa
        '
        Me.idEmpresa.DisplayIndex = 1
        Me.idEmpresa.Text = "idEmpresa"
        Me.idEmpresa.Width = 0
        '
        'idCentroCosto
        '
        Me.idCentroCosto.DisplayIndex = 2
        Me.idCentroCosto.Text = "idCentroCosto"
        Me.idCentroCosto.Width = 0
        '
        'serie
        '
        Me.serie.DisplayIndex = 3
        Me.serie.Text = "serie"
        Me.serie.Width = 0
        '
        'numeroDoc
        '
        Me.numeroDoc.DisplayIndex = 4
        Me.numeroDoc.Text = "numeroDoc"
        Me.numeroDoc.Width = 150
        '
        'nombreProveedor
        '
        Me.nombreProveedor.Text = "Nombre Proveedor"
        Me.nombreProveedor.Width = 0
        '
        'frmTransferenciaSobrante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 327)
        Me.Controls.Add(Me.lsvNotificaciones)
        Me.Name = "frmTransferenciaSobrante"
        Me.Text = "frmTransferenciaSobrante"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvNotificaciones As System.Windows.Forms.ListView
    Friend WithEvents idDocumento As System.Windows.Forms.ColumnHeader
    Friend WithEvents idEmpresa As System.Windows.Forms.ColumnHeader
    Friend WithEvents idCentroCosto As System.Windows.Forms.ColumnHeader
    Friend WithEvents serie As System.Windows.Forms.ColumnHeader
    Friend WithEvents numeroDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents glosa As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombreProveedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class

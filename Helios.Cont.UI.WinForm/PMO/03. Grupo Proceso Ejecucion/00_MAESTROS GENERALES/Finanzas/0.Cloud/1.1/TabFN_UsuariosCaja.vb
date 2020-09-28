Imports Helios.General.Constantes
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class TabFN_UsuariosCaja
    Public Property usuarioSA As New UsuarioSA
    Public Property usuarioBE As New Usuario
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetUsuarioCajas()
    End Sub

    Private Sub GetUsuarioCajas()
        UsuarioSA = New UsuarioSA

        Dim dt As New DataTable("Usuarios")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("dni", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombres", GetType(String)))
        dt.Columns.Add(New DataColumn("appat", GetType(String)))
        dt.Columns.Add(New DataColumn("apmat", GetType(String)))
        'dt.Columns.Add(New DataColumn("fechaActualizacion", GetType(String)))

        Dim str As String
        For Each i As Usuario In UsuarioSA.GetListaUsuarios()

            If i.Rol = "3" Or i.Rol = "4" Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                '  str = CDate(i.fechaActualizacion).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.IDUsuario
                If (Not IsNothing(i.NroDocumento)) Then
                    dr(1) = i.NroDocumento
                Else
                    dr(1) = ""
                End If
                dr(2) = i.Nombres
                dr(3) = i.ApellidoPaterno
                dr(4) = i.ApellidoMaterno
                'dr(4) = str
                dt.Rows.Add(dr)
            End If
        Next
        dgvUsuarios.DataSource = dt

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim f As New frmCrearUsuarioEmpresa
        f.strTipoAdmin = "CAJERO"
        f.GroupBox1.Visible = True
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetUsuarioCajas()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmModalAbrirCajaUsuario ' frmCreaUsuarioEmpresa
        f.cboMesCompra.Enabled = True
        f.txtDia.Value = DateTime.Now
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.txtPeriodo.Value = DateTime.Now
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class

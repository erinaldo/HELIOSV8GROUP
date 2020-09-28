Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity

Public Class frmAdminUsuariosCaja

#Region "Attributes"
    Public Property usuarioSA As New UsuarioSA
    Public Property usuarioBE As New Usuario
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetUsuarioCajas()
        FormatoGrid(dgvUsuarios)
    End Sub
#End Region

#Region "methods"
    Public Sub EliminarPersona(intIdPersona As Integer)
        usuarioSA = New UsuarioSA
        usuarioBE = New Usuario
        usuarioBE.IDUsuario = intIdPersona
        usuarioSA.DeletePersonaXCaja(usuarioBE)
        PanelError.Visible = True
        lblEstado.Text = "Usuario eliminado"
    End Sub

    Private Sub GetUsuarioCajas()
        usuarioSA = New UsuarioSA

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
#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim f As New frmCrearUsuarioEmpresa
        f.strTipoAdmin = "CAJERO"
        f.GroupBox1.Visible = True
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetUsuarioCajas()
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetUsuarioCajas()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
            With frmCrearUsuarioEmpresa
                .GroupBox1.Visible = False
                .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                .strTipoAdmin = "CAJERO"
                '.CargarDatos()
                .UbicarUsaurio(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                .idUsuario = (Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                GetUsuarioCajas()
            End With
        Else
            MessageBox.Show("Debe seleccionar un usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Try
            If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
                Dim cajaUsaurioSA As New cajaUsuarioSA
                Dim conteoCaja As Integer
                conteoCaja = cajaUsaurioSA.UbicarCajaXPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)

                If (conteoCaja = 0) Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                        Me.dgvUsuarios.Table.CurrentRecord.Delete()
                    End If
                Else
                    MessageBox.Show("No se puede eliminar usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
#End Region

End Class
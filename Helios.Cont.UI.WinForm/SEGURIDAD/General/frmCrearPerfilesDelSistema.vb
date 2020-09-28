Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCrearPerfilesDelSistema

#Region "Attributes"
    Public Property strEstadoManipulacion() As String
    Public Property RolSA As New RolSA
    Dim idRolAct As Integer
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        CargarCargos()
        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Text = DateTime.Now
        txtFecha.ReadOnly = True
        cboNombres.Focus()


    End Sub

    Public Sub New(idrol As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        CargarCargos()
        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Text = DateTime.Now
        txtFecha.ReadOnly = True
        UbicarRol(idrol)
        cboNombres.Focus()
    End Sub

#End Region

#Region "Methods"



    Public Sub CargarCargos()
        'Dim jerarquiaBE As New jerarquiaCargo
        'Dim CargosSA As New jerarquiaCargoSA

        'jerarquiaBE.IDEmpresa = Gempresas.IdEmpresaRuc
        'jerarquiaBE.IDEstablecimiento = GEstableciento.IdEstablecimiento

        'cboNombres.ValueMember = "idCargo"
        'cboNombres.DisplayMember = "descripcion"
        'cboNombres.DataSource = CargosSA.ListaDeCargos(jerarquiaBE)

        'cboNombres.SelectedValue = -1

    End Sub


    Public Sub Grabar()
        Dim rol As New Rol
        Try
            rol = New Rol With
            {
            .Action = BaseBE.EntityAction.INSERT,
                          .Nombre = cboNombres.Text,
            .Descripcion = txtDescripcion.Text,
            .UsuarioActualizacion = usuario.IDUsuario,
            .FechaActualizacion = Date.Now
            }

            idRolAct = RolSA.insertRol(rol).IDRol
            MessageBox.Show("Perfil grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            'Dim f As New frmNuevoAsegurable
            ''f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            'f.IdRol = idRolAct
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al grabar Perfil. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Public Sub UpdateRol()
        Dim rol As New Rol
        Try
            rol = New Rol
            With rol
                .Action = BaseBE.EntityAction.UPDATE
                .IDRol = idRolAct
                .Nombre = cboNombres.Text
                .Descripcion = txtDescripcion.Text
                .UsuarioActualizacion = usuario.IDUsuario
                .FechaActualizacion = Date.Now
            End With

            RolSA.updateRol(rol)
            MessageBox.Show("Perfil actualizado!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al grabar usuario. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Public Sub UbicarRol(idRol As Integer)
        Dim rol As New Rol
        Try
            rol = RolSA.ListadoRolesClienteXID(New Rol With {.IDRol = idRol})

            With rol
                idRolAct = .IDRol
                txtDescripcion.Text = .Descripcion
                cboNombres.Text = .Nombre
                txtFecha.Text = .FechaActualizacion
            End With

            ''RolSA.insertRol(rol)
            'MessageBox.Show("se ubico correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Close()

        Catch ex As Exception
            MsgBox("Error al ubicar usuario. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If cboNombres.Text.Trim.Length > 0 Then
            If txtDescripcion.Text.Trim.Length > 0 Then
                If txtFecha.Text.Trim.Length > 0 Then
                    Select Case strEstadoManipulacion
                        Case ENTITY_ACTIONS.INSERT
                            Grabar()
                        Case ENTITY_ACTIONS.UPDATE
                            UpdateRol()
                            Close()
                    End Select
                Else
                    MsgBox("Ingrese una fecha correcta.", MsgBoxStyle.Information, "!Atención")
                    txtFecha.Focus()

                End If
            Else
                MsgBox("Ingrese una descripción valido", MsgBoxStyle.Information, "!Atención")
                txtDescripcion.Focus()
            End If
        Else
            MsgBox("Ingrese el nombre(s).", MsgBoxStyle.Information, "!Atención")
            cboNombres.Focus()
        End If
    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtDescripcion.Select()
            End If
        Catch ex As Exception
            'txtNombres.Clear()
            cboNombres.Text = ""
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNombres.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles cboNombres.Leave
        'Dim strvalue As String = ComboBox1.Text
        'ComboBox1.Text = strvalue.ToUpper()
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombres.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper()
    End Sub

#End Region

End Class
Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmNuevoCargoGeneral

#Region "Atributos"

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListarCargosPadre()
    End Sub

    Sub New(idCargo As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        ListarCargosPadre()
        UbicarCargo(idCargo)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos"




    Public Sub UbicarCargo(id As Integer)
        Try


            Dim sa As New RolSA
            Dim obj As New Rol
            obj.IDRol = id





            Dim consulta = sa.RolSearch(obj)

            If consulta IsNot Nothing Then


                If consulta.tipoEF = "ADM" Then
                    cboTipoFF.Text = "ADMINISTRATIVO"
                ElseIf consulta.tipoEF = "POS" Then
                    cboTipoFF.Text = "POS"
                End If

                cboTipoFF.Enabled = False

                lbltipo.Text = consulta.tipo



                lblId.Text = consulta.IDRol
                txtDescripcion.Text = consulta.Nombre

                If consulta.idPadre IsNot Nothing Then


                End If




            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ListarCargosPadre()
        Dim sa As New RolSA
        Dim jerarquiBE As New Rol

        'jerarquiBE.idEmpresa = Gempresas.IdEmpresaRuc
        jerarquiBE.tipo = 2

        Dim consulta = sa.GetRolesXEstablecimiento(jerarquiBE)


        cboResponsables.ValueMember = "IDRol"
        cboResponsables.DisplayMember = "Nombre"
        cboResponsables.DataSource = consulta

    End Sub


    Public Sub GetUpdateCargos()
        Try

            Dim sa As New RolSA

            Dim obj As New Rol
            obj.IDRol = lblId.Text
            obj.Nombre = txtDescripcion.Text

            Dim cargo = sa.UpdateRole(obj)

            If cargo Is Nothing Then
                MessageBox.Show("No se pudo Editar")
            Else
                Dispose()
                MessageBox.Show("Se Actualizo correctamente")
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo Actualizar")
        End Try
    End Sub

    Public Sub CrearCargo()
        Try

            Dim sa As New RolSA
            Dim obj As New Rol
            'Dim rolGrupoEmprBE As New RolXGrupoEmp

            obj.Descripcion = txtDescripcion.Text
            obj.Nombre = txtDescripcion.Text
            obj.tipo = "U"
            obj.control = "GR"
            obj.UsuarioActualizacion = "Jiuni"
            obj.FechaActualizacion = DateTime.Now

            If CheckBox1.Checked = True Then

                obj.idPadre = cboResponsables.SelectedValue

            End If

            If cboTipoFF.Text = "ADMINISTRATIVO" Then

                obj.tipoEF = "ADM"

            ElseIf cboTipoFF.Text = "POS" Then

                obj.tipoEF = "POS"

            End If


            Dim cargo = sa.RolInsertSingle(obj)

            If cargo Is Nothing Then
                MessageBox.Show("No se pudo Grabar")
            Else
                Dispose()
                MessageBox.Show("Se Grabo Correctamente")
            End If

        Catch ex As Exception
            MessageBox.Show("No se pudo Grabar")
        End Try
    End Sub


    'Public Sub GrabarPermiso()
    '    Dim rol As New Rol
    '    Dim RolSA As New RolSA
    '    Try
    '        rol = New Rol With
    '        {
    '        .Action = BaseBE.EntityAction.INSERT,
    '                    .IDEmpresa = Gempresas.IdEmpresaRuc,
    '        .IDEstablecimiento = GEstableciento.IdEstablecimiento,
    '        .Nombre = txtDescripcion.Text,
    '        .Descripcion = txtDescripcion.Text,
    '        .UsuarioActualizacion = usuario.IDUsuario,
    '        .FechaActualizacion = Date.Now
    '        }

    '        Dim idRolAct = RolSA.insertRol(rol).IDRol
    '        MessageBox.Show("Perfil grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Close()
    '        'Dim f As New frmNuevoAsegurable
    '        ''f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
    '        'f.IdRol = idRolAct
    '        'f.StartPosition = FormStartPosition.CenterParent
    '        'f.ShowDialog()
    '    Catch ex As Exception
    '        MsgBox("Error al grabar Perfil. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

    '    End Try

    'End Sub

#End Region

    Private Sub frmNuevoCargo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

        If lbltipo.Text = "S" Then
            MessageBox.Show("Admin no se puede editar seleccione otro cargo")
            Exit Sub
        End If


        If txtDescripcion.Text.Trim.Length > 0 Then

            If lblId.Text > 0 Then
                GetUpdateCargos()

            Else
                CrearCargo()
            End If

        Else
            MessageBox.Show("Escriba un Nombre al Cargo")

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            cboResponsables.Visible = True
        Else

            cboResponsables.Visible = False
        End If
    End Sub
End Class
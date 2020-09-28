Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmEditarCargo

#Region "Variables"

#End Region



#Region "Constructor"



    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetPefiles()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If cboCargos.Text.Trim.Length > 0 Then
            If lblidusuario.Text > 0 Then
                AgregarCargo()
            End If
        End If
    End Sub

#End Region

#Region "Metodos"

    Public Sub GetPefiles()
        Dim CargosSA As New RolSA
        Dim jerarquiBE As New Rol

        jerarquiBE.idEmpresa = Gempresas.IdEmpresaRuc
        'jerarquiBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        cboCargos.ValueMember = "IDRol"
        cboCargos.DisplayMember = "Nombre"
        cboCargos.DataSource = CargosSA.RoleList(jerarquiBE).Where(Function(O) O.control <> "SA").ToList




    End Sub

    Public Sub AgregarCargo()

        Dim usuario As New UsuarioRol
        Dim usaurioSA As New UsuarioRolSA
        Dim usaurioSA2 As New UsuarioSA
        Try
            usuario = New UsuarioRol With
            {
            .Action = BaseBE.EntityAction.INSERT,
            .IDUsuario = lblidusuario.Text,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = GEstableciento.IdEstablecimiento,
            .IDRol = cboCargos.SelectedValue,
            .estado = "A",
            .predeterminado = False,
            .FechaActualizacion = DateTime.Now,
            .UsuarioActualizacion = "Jiuni"
            }

            usaurioSA.InserRoleUser(usuario)
            UsuariosList = usaurioSA2.ListadoUsuariosv2()
            Seguridad.General.ListaUsuariosSoftpack = UsuariosList
            MessageBox.Show("Cargo se agrego correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("No se pudo Agregar el Cargo. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try
    End Sub

#End Region

End Class
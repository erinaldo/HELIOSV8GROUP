Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmEditarContraseña

#Region "Constructor"

    Sub New(idUser As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        BuscarInformacion(idUser)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region


#Region "Metodos"




    Public Sub BuscarInformacion(idUser As Integer)
        Try


            Dim usuario As New AutenticacionUsuario
            Dim usaurioASA As New AutenticacionUsuarioSA

            usuario.IDUsuario = idUser

            Dim consulta = usaurioASA.BuscarContraseñaAliasUser(usuario)

            If consulta IsNot Nothing Then

                'txtPass.Text = consulta.Contrasena
                txtAlias.Text = consulta.Alias

            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub EditarContraseña()
        Dim usuario As New AutenticacionUsuario
        Dim usaurioSA As New AutenticacionUsuarioSA
        Dim usaurioSA2 As New UsuarioSA
        Try

            If (txtcontraRepetir.Text = txtPass.Text) Then
                usuario = New AutenticacionUsuario With
                            {
                            .Action = BaseBE.EntityAction.INSERT,
                            .IDUsuario = lblidusuario.Text,
                            .[Alias] = txtAlias.Text,
                            .Contrasena = txtPass.Text
                            }

                usaurioSA.UpdateContrasenaUsuario(usuario)
                UsuariosList = usaurioSA2.ListadoUsuariosv2()
                Seguridad.General.ListaUsuariosSoftpack = UsuariosList
                MessageBox.Show("codigo se cambio correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            Else
                MsgBox("Error verificar contraseña. ", MsgBoxStyle.Critical, "Aviso del Sistema!")

            End If



        Catch ex As Exception
            MsgBox("Error al cambiar la contraseña. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Try


            Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
            If txtAlias.Text.Trim.Length > 0 Then
                If txtPass.Text.Trim.Length > 0 Then

                    If AutenticacionUsuarioSA.getRecuperarUsaurioLogeo(New AutenticacionUsuario With {.IdEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .IDEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                       .[Alias] = txtAlias.Text,
                                                                       .Contrasena = txtContraAntiguo.Text}) Then
                        EditarContraseña()
                    Else
                        MessageBox.Show("VERIFICAR DATOS")
                    End If


                Else
                    MessageBox.Show("Escriba una Contraseña")
                End If
            Else
                MessageBox.Show("Escriba un Alias")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmEditarContraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

#End Region

End Class
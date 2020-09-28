Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmAsignarCodigo

#Region "Attributes"
    Public Property strEstadoManipulacion() As String
    Public Property usuarioID As Integer
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(idrol As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Methods"

    Public Sub Grabar()
        Dim usuario As New Usuario
        Dim usaurioSA As New UsuarioSA
        Try
            usuario = New Usuario With
            {
            .Action = BaseBE.EntityAction.INSERT,
            .IDUsuario = usuarioID,
            .codigo = txtNombres.Text
            }

            usaurioSA.UpdateUsuarioCodigoAsignado(usuario)
            UsuariosList = usaurioSA.ListadoUsuariosv2()
            Seguridad.General.ListaUsuariosSoftpack = UsuariosList
            MessageBox.Show("codigo se grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()

        Catch ex As Exception
            MsgBox("Error al grabar codigo. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If txtNombres.Text.Trim.Length > 0 Then

            Select Case strEstadoManipulacion
                        Case ENTITY_ACTIONS.INSERT
                            Grabar()
                    '    Case ENTITY_ACTIONS.UPDATE
                    '        UpdateRol()
                    'Close()
            End Select

        Else
            MsgBox("Ingrese el codigo(s).", MsgBoxStyle.Information, "!Atención")
            txtNombres.Focus()
        End If
    End Sub

#End Region

End Class
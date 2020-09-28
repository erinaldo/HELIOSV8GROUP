Imports Helios.Seguridad.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmVerPassword

#Region "Variables"
    Dim AutenticacionUsuarioSA As New AutenticacionUsuarioSA
#End Region



#Region "Constructor"

    Sub New(NombreAlias As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CARGARPASSWORD(NombreAlias)
    End Sub

    Public Sub CARGARPASSWORD(NombreAlias As String)
        Try


            Dim nombrePassword As String = AutenticacionUsuarioSA.EsUsuarioAutenticadoLoginRecuperarPassword(New AutenticacionUsuario With {.IdEmpresa = Gempresas.IdEmpresaRuc,
                                                                        .IDEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                        .IDUsuario = CInt(NombreAlias)})

            If (nombrePassword.Length > 0) Then
                txtPassword.Text = nombrePassword
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dispose()
    End Sub

#End Region
End Class
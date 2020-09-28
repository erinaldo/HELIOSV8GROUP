Public Class USubMaestroRRHH

    Public Property UCClientesTransportes As UCClientesTransportes
    Public Property UCConductorTransportes As UCConductorTransportes


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCClientesTransportes = New UCClientesTransportes With {.Dock = DockStyle.Fill, .Visible = True}
        PanelBodyPersona.Controls.Add(UCClientesTransportes)

        UCConductorTransportes = New UCConductorTransportes With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBodyPersona.Controls.Add(UCConductorTransportes)

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click, BunifuFlatButton3.Click
        Try

            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
            'PanelBodyPersona.Controls.Clear()
            Select Case btn.Tag

                Case "Clientes"
                    PanelBodyPersona.Visible = True
                    UCConductorTransportes.Visible = False
                    If UCClientesTransportes IsNot Nothing Then
                        UCClientesTransportes.Visible = True
                        UCClientesTransportes.BringToFront()
                        UCClientesTransportes.Show()
                    End If

                Case "Conductor"
                    PanelBodyPersona.Visible = True
                    UCClientesTransportes.Visible = False
                    If UCConductorTransportes IsNot Nothing Then
                        UCConductorTransportes.Visible = True
                        UCConductorTransportes.BringToFront()
                        UCConductorTransportes.Show()
                    End If

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class

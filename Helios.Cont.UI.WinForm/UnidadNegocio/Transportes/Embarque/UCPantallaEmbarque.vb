Public Class UCPantallaEmbarque

#Region "Attributes"
    Public Property UCManifestoEnEspera As UCManifestoEnEspera
    Public Property FormPurchase As FormControlTransporteVer2
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RoundButton27.Text = "Consolidar salida"
        RoundButton27.BackColor = Color.FromArgb(109, 188, 69)
        UCManifestoEnEspera = New UCManifestoEnEspera(Me, "En Espera") With {
                    .Dock = DockStyle.Fill
                }
        UCManifestoEnEspera.BringToFront()
        PanelBody.Controls.Add(UCManifestoEnEspera)
    End Sub

    Public Sub New(formRepTransporte As FormControlTransporteVer2)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RoundButton27.Text = "Consolidar salida"
        RoundButton27.BackColor = Color.FromArgb(109, 188, 69)
        UCManifestoEnEspera = New UCManifestoEnEspera(Me, "En Espera") With {
                    .Dock = DockStyle.Fill
                }
        UCManifestoEnEspera.BringToFront()
        PanelBody.Controls.Add(UCManifestoEnEspera)

        FormPurchase = formRepTransporte

    End Sub
#End Region

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        PanelBody.Controls.Clear()
        Select Case btn.Text
            Case "En Espera"
                RoundButton27.Text = "Consolidar salida"
                RoundButton27.BackColor = Color.FromArgb(109, 188, 69)
                UCManifestoEnEspera = New UCManifestoEnEspera(Me, "En Espera") With {
                    .Dock = DockStyle.Fill
                }
                UCManifestoEnEspera.BringToFront()
                PanelBody.Controls.Add(UCManifestoEnEspera)

            Case "En Curso"
                RoundButton27.BackColor = Color.FromKnownColor(KnownColor.HotTrack)
                RoundButton27.Text = "Terminar ruta"
                UCManifestoEnEspera = New UCManifestoEnEspera(Me, "En Curso") With {
                    .Dock = DockStyle.Fill
                }
                UCManifestoEnEspera.BringToFront()
                PanelBody.Controls.Add(UCManifestoEnEspera)
            Case "Culminados"
                RoundButton27.BackColor = Color.FromArgb(189, 15, 50)
                RoundButton27.Text = "Limpiar lista"
                UCManifestoEnEspera = New UCManifestoEnEspera(Me, "Limpiar lista") With {
                    .Dock = DockStyle.Fill
                }
                UCManifestoEnEspera.BringToFront()
                PanelBody.Controls.Add(UCManifestoEnEspera)

        End Select
    End Sub

    Private Sub RoundButton27_Click(sender As Object, e As EventArgs) Handles RoundButton27.Click
        If UCManifestoEnEspera IsNot Nothing Then
            Select Case RoundButton27.Text
                'Case "Consolidar salida"
                '    Dim f As New FormConsolidarSalidaEmbarque(UCManifestoEnEspera)
                '    f.StartPosition = FormStartPosition.CenterParent
                '    f.ShowDialog(Me)
                'Case "Terminar ruta"

                '    Dim f As New FormConcluirProgramacionRuta(UCManifestoEnEspera)
                '    f.StartPosition = FormStartPosition.CenterParent
                '    f.ShowDialog(Me)
            End Select

        End If
    End Sub

    Private Sub RoundButton26_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        Try
            FormPurchase.UCPantallaEmbarque.Visible = False
            If FormPurchase.TabTR_IdentificacionRuta IsNot Nothing Then
                FormPurchase.TabTR_IdentificacionRuta.Visible = True
                FormPurchase.TabTR_IdentificacionRuta.BringToFront()
                FormPurchase.TabTR_IdentificacionRuta.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class

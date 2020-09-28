Public Class UCPrincipalReportes

#Region "Atributos"

    Private UCSubReporteVentas As UCSubReporteVentas

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCSubReporteVentas = New UCSubReporteVentas With {.Dock = DockStyle.Fill, .Visible = True}
        PanelBody.Controls.Add(UCSubReporteVentas)
    End Sub

    Private Sub btnReporteVentas_Click(sender As Object, e As EventArgs) Handles btnReporteVentas.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "VENTAS"

                If UCSubReporteVentas IsNot Nothing Then
                    UCSubReporteVentas.Visible = True
                    UCSubReporteVentas.BringToFront()
                    UCSubReporteVentas.Show()
                End If


        End Select
    End Sub

#End Region

#Region "Metodos"

#End Region

End Class

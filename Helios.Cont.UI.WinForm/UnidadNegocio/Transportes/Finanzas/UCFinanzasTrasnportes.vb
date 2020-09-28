Public Class UCFinanzasTrasnportes

    Public Property TabFN_CuentasFinancieras As TabFN_CuentasFinancieras
    Public Property TabUsuarios As TabUsuarios
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TabFN_CuentasFinancieras = New TabFN_CuentasFinancieras() With {
                .Dock = DockStyle.Fill
              }
        TabFN_CuentasFinancieras.BringToFront()
        PanelBody.Controls.Add(TabFN_CuentasFinancieras)
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click, BunifuFlatButton4.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        PanelBody.Controls.Clear()
        Select Case btn.Tag
            Case "Cuentas"
                TabFN_CuentasFinancieras = New TabFN_CuentasFinancieras() With {
                .Dock = DockStyle.Fill
              }
                TabFN_CuentasFinancieras.BringToFront()
                PanelBody.Controls.Add(TabFN_CuentasFinancieras)
            Case "Usuarios"
                TabUsuarios = New TabUsuarios() With {
            .Dock = DockStyle.Fill
        }
                TabUsuarios.BringToFront()
                PanelBody.Controls.Add(TabUsuarios)

        End Select
    End Sub
End Class

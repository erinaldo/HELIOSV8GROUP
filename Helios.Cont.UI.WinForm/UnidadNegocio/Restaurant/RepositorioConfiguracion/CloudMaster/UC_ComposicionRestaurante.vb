Public Class UC_ComposicionRestaurante

    Private Tab_GestionComposicion As Tab_GestionComposicion

    Public Property TransporteID As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Tab_GestionComposicion = New Tab_GestionComposicion With {.Dock = DockStyle.Fill}


        PanelBody.Controls.Add(Tab_GestionComposicion)


        'General.Centrar(Me)



    End Sub

    'Private Sub bunifuImageButton2_Click_1(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
    '    Close()
    'End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Composición"

                If Tab_GestionComposicion IsNot Nothing Then
                    Tab_GestionComposicion.Visible = True
                    Tab_GestionComposicion.BringToFront()
                    Tab_GestionComposicion.Show()
                End If

        End Select
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs)
        Dim f As New frmCrearUsuariosDelSistema
        f.strEstadoManipulacion = General.ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'PanelBody.Controls.Clear()
    End Sub

End Class
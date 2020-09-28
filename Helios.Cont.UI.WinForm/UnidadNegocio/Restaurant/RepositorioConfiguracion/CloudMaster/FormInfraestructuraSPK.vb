Public Class FormInfraestructuraSPK

    Private TabMG_Componente As TabMG_Componente
    Private TabMG_Distribucion As TabMG_Distribucion
    Private TabMG_Infraestructura As TabMG_Infraestructura
    Private UCClasificacionInfraestructura As UCClasificacionInfraestructura
    Private UCSubClasificacionInfraestructura As UCSubClasificacionInfraestructura
    'Private UCCanastaVentaPrueba As UCCanastaVentaPrueba
    Public Property TransporteID As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabMG_Componente = New TabMG_Componente With {.Dock = DockStyle.Fill}
        TabMG_Distribucion = New TabMG_Distribucion With {.Dock = DockStyle.Fill}
        TabMG_Infraestructura = New TabMG_Infraestructura With {.Dock = DockStyle.Fill}
        UCClasificacionInfraestructura = New UCClasificacionInfraestructura With {.Dock = DockStyle.Fill}
        UCSubClasificacionInfraestructura = New UCSubClasificacionInfraestructura With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(TabMG_Componente)
        PanelBody.Controls.Add(TabMG_Distribucion)
        PanelBody.Controls.Add(TabMG_Infraestructura)
        PanelBody.Controls.Add(UCClasificacionInfraestructura)
        PanelBody.Controls.Add(UCSubClasificacionInfraestructura)

        General.Centrar(Me)
        BunifuFlatButton16.Enabled = True
        BunifuFlatButton1.Enabled = True

    End Sub

    'Private Sub bunifuImageButton2_Click_1(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
    '    Close()
    'End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Infraestructura"
                TabMG_Distribucion.Visible = False
                TabMG_Componente.Visible = False
                UCClasificacionInfraestructura.Visible = False
                UCSubClasificacionInfraestructura.Visible = False

                If TabMG_Infraestructura IsNot Nothing Then
                    TabMG_Infraestructura.Visible = True
                    TabMG_Infraestructura.BringToFront()
                    TabMG_Infraestructura.Show()
                End If

            Case "Componente"
                TabMG_Distribucion.Visible = False
                TabMG_Infraestructura.Visible = False
                UCClasificacionInfraestructura.Visible = False
                UCSubClasificacionInfraestructura.Visible = False

                If TabMG_Componente IsNot Nothing Then
                    TabMG_Componente.Visible = True
                    TabMG_Componente.BringToFront()
                    TabMG_Componente.Show()
                End If

            Case "Distribución"
                TabMG_Componente.Visible = False
                TabMG_Infraestructura.Visible = False
                UCClasificacionInfraestructura.Visible = False
                UCSubClasificacionInfraestructura.Visible = False

                If TabMG_Distribucion IsNot Nothing Then
                    TabMG_Distribucion.Visible = True
                    TabMG_Distribucion.BringToFront()
                    TabMG_Distribucion.Show()
                End If

            Case "Clasificación"
                TabMG_Componente.Visible = False
                TabMG_Infraestructura.Visible = False
                TabMG_Distribucion.Visible = False
                UCSubClasificacionInfraestructura.Visible = False

                If UCClasificacionInfraestructura IsNot Nothing Then
                    UCClasificacionInfraestructura.Visible = True
                    UCClasificacionInfraestructura.BringToFront()
                    UCClasificacionInfraestructura.Show()
                End If

            Case "Sub Clasificación"
                TabMG_Componente.Visible = False
                TabMG_Infraestructura.Visible = False
                TabMG_Distribucion.Visible = False
                UCClasificacionInfraestructura.Visible = False

                If UCSubClasificacionInfraestructura IsNot Nothing Then
                    UCSubClasificacionInfraestructura.Visible = True
                    UCSubClasificacionInfraestructura.BringToFront()
                    UCSubClasificacionInfraestructura.Show()
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
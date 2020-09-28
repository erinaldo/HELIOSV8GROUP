Public Class UCLogisticaCompra

#Region "Attributes"
    Public Property UCCompras As UCCompras
    'Public Property UCOtrasEntradas As UCOtrasEntradas
    Public Property FormRepositoryLogistica As FormRepositoryLogistica
    'Public Property UCOtrasSalidas As UCOtrasSalidas
#End Region

#Region "Constructors"
    Public Sub New(form As FormRepositoryLogistica)

        ' This call is required by the designer.
        InitializeComponent()
        FormRepositoryLogistica = form
        ' Add any initialization after the InitializeComponent() call.
        UCCompras = New UCCompras(Me)
        'UCOtrasEntradas = New UCOtrasEntradas
        'UCOtrasSalidas = New UCOtrasSalidas
        UCCompras.Dock = DockStyle.Fill
        PanelBody.Controls.Add(UCCompras)
        'PanelBody.Controls.Add(UCOtrasEntradas)
        'PanelBody.Controls.Add(UCOtrasSalidas)
    End Sub


#End Region

#Region "methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim f As New FormCrearCompra("COMPRAS")
            f.ComboComprobante.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Compras"
                'UCOtrasEntradas.Visible = False
                'UCOtrasSalidas.Visible = False
                If UCCompras IsNot Nothing Then
                    UCCompras.Visible = True
                    UCCompras.BringToFront()
                    UCCompras.Show()
                End If
            Case "Otras entradas"
                UCCompras.Visible = False
                'UCOtrasSalidas.Visible = False
                'If UCOtrasEntradas IsNot Nothing Then
                ' UCOtrasEntradas.Visible = True
                ' UCOtrasEntradas.BringToFront()
                'UCOtrasEntradas.Show()
                'End If
            Case "Otras sálidas"
                UCCompras.Visible = False
                'UCOtrasEntradas.Visible = False
                'If UCOtrasSalidas IsNot Nothing Then
                ' UCOtrasSalidas.Visible = True
                ' UCOtrasSalidas.BringToFront()
                ' UCOtrasSalidas.Show()
                ' End If
        End Select
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        Dim f As New FormDetalleLoteCompra
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click

    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click

    End Sub
#End Region

End Class
